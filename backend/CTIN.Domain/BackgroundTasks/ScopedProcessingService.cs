using CTIN.Common.Extentions;
using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CTIN.Domain.BackgroundTasks
{
    public interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    public class ScopedProcessingService : IScopedProcessingService
    {

        private readonly NATemplateContext _db;
        private readonly ILogger _logger;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, NATemplateContext db)
        {
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Hàm chạy ngần quét 2 cột phim dang học, phim đã quên để update
        /// vào vị trí tương tứng lenning, isforget, punishing
        /// </summary>
        /// <param name="stoppingToken">éo biết</param>
        /// <returns></returns>
        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var listUser = _db.User.Where(x => (int)DbFunction.JsonValue(x.dataDb, "$.status") != 3).ToList();
                if (listUser != null)
                {
                    foreach (User userOld in listUser)
                    {
                        var userNew1 = userOld.JsonToString().JsonToObject<User>();
                        List<userfilmleanningDataJson> listfilmLeanning = new List<userfilmleanningDataJson>();
                        List<userfilmleanningDataJson> listfilmForgeted1 = new List<userfilmleanningDataJson>();
                        List<userfilmleanningDataJson> listfilmForgeted2 = new List<userfilmleanningDataJson>();
                        List<userfilmleanningDataJson> listfilmPunishing = new List<userfilmleanningDataJson>();

                        if (userNew1.filmforgeted != null)
                        {
                            foreach (userfilmleanningDataJson film in userNew1.filmforgeted)
                            {
                                var filmNew = film.JsonToString().JsonToObject<userfilmleanningDataJson>();
                                List<wordleanedDataJson> listWordForgeted = new List<wordleanedDataJson>();
                                List<wordleanedDataJson> listWordPunishing = new List<wordleanedDataJson>();

                                foreach (wordleanedDataJson word in filmNew.wordleaned)
                                {
                                    wordleanedDataJson iteamWordLeaned = new wordleanedDataJson();
                                    if (word.check == 1)
                                    {
                                        if ((DateTime.UtcNow - word.time).TotalHours > 28)
                                        {
                                            iteamWordLeaned.stt = word.stt;
                                            iteamWordLeaned.time = word.time;
                                            iteamWordLeaned.isforget = 1;
                                            iteamWordLeaned.check = word.check;
                                            iteamWordLeaned.classic = 3; // là từ bị phạt mà ko học
                                            listWordPunishing.Add(iteamWordLeaned);
                                        }
                                        else
                                        {
                                            listWordForgeted.Add(word);
                                        }
                                    }
                                    if (word.check == 2)
                                    {
                                        if ((DateTime.UtcNow - word.time).TotalDays > 8)
                                        {
                                            iteamWordLeaned.stt = word.stt;
                                            iteamWordLeaned.time = word.time;
                                            iteamWordLeaned.isforget = 1;
                                            iteamWordLeaned.check = word.check;
                                            iteamWordLeaned.classic = 3;
                                            listWordPunishing.Add(iteamWordLeaned);
                                        }
                                        else
                                        {
                                            listWordForgeted.Add(word);
                                        }
                                    }
                                }
                                foreach (var a in userNew1.filmpunishing)
                                {
                                    if (a.filmid == film.filmid)
                                    {
                                        if (a.wordleaned.Count > 0)
                                        {
                                            foreach (var b in a.wordleaned)
                                            {
                                                listWordPunishing.Add(b);
                                            }
                                        }
                                    }
                                }
                                // add dữ liệu lại trường Punishing
                                film.wordleaned = listWordPunishing;
                                listfilmPunishing.Add(film);
                                // add dữ liệu lại trường isforgeted
                                filmNew.wordleaned = listWordForgeted;
                                listfilmForgeted1.Add(filmNew);
                            }

                            var update1 = new
                            {
                                filmforgeted = listfilmForgeted1,
                                filmpunishing = listfilmPunishing
                            };

                            userNew1 = userNew1.Patch(update1);
                        }

                        var userNew2 = userNew1.JsonToString().JsonToObject<User>();

                        if (userNew2.filmleanning != null)
                        {
                            foreach (userfilmleanningDataJson film in userNew2.filmleanning)
                            {
                                var filmNew = film.JsonToString().JsonToObject<userfilmleanningDataJson>();
                                List<wordleanedDataJson> listWordLeanning = new List<wordleanedDataJson>();
                                List<wordleanedDataJson> listWordForgeted = new List<wordleanedDataJson>();

                                foreach (wordleanedDataJson word in filmNew.wordleaned)
                                {
                                    wordleanedDataJson iteamWordLeaned = new wordleanedDataJson();
                                    if (word.check == 1)
                                    {
                                        if ((DateTime.UtcNow - word.time).TotalHours > 20)
                                        {
                                            iteamWordLeaned.stt = word.stt;
                                            iteamWordLeaned.time = word.time;
                                            iteamWordLeaned.isforget = 1;
                                            iteamWordLeaned.check = word.check;
                                            iteamWordLeaned.classic = 2;
                                            listWordForgeted.Add(iteamWordLeaned);
                                        }
                                        else
                                        {
                                            listWordLeanning.Add(word);
                                        }
                                    }
                                    if (word.check == 2)
                                    {
                                        if ((DateTime.UtcNow - word.time).TotalDays > 6)
                                        {
                                            iteamWordLeaned.stt = word.stt;
                                            iteamWordLeaned.time = word.time;
                                            iteamWordLeaned.isforget = 1;
                                            iteamWordLeaned.check = word.check;
                                            iteamWordLeaned.classic = 2;
                                            listWordForgeted.Add(iteamWordLeaned);
                                        }
                                        else
                                        {
                                            listWordLeanning.Add(word);
                                        }
                                    }
                                }
                                foreach (var a in userNew2.filmforgeted)
                                {
                                    if (a.filmid == film.filmid)
                                    {
                                        if (a.wordleaned.Count > 0)
                                        {
                                            foreach (var b in a.wordleaned)
                                            {
                                                listWordForgeted.Add(b);
                                            }
                                        }
                                    }
                                }
                                // add dữ liệu lại trường leanning
                                film.wordleaned = listWordLeanning;
                                listfilmLeanning.Add(film);
                                // add dữ liệu lại trường isforgeted
                                filmNew.wordleaned = listWordForgeted;
                                listfilmForgeted2.Add(filmNew);
                            }
                            var update2 = new
                            {
                                filmforgeted = listfilmForgeted2,
                                filmleanning = listfilmLeanning
                            };
                            userNew2 = userNew2.Patch(update2);
                        }
                        // nếu không có gì thay đổi thì không lưu DB
                        _db.Entry(userOld).CurrentValues.SetValues(userNew2);
                        await _db.SaveChangesAsync();
                    }
                }

                await Task.Delay(3600000, stoppingToken); // delay 1h
            }
        }

    }
}
