using CTIN.Common.Enums;
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

        public ScopedProcessingService(NATemplateContext db)
        {
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
                //update các từ trong 3 ô
                var listUser = _db.UserLeanning.ToList();
                if (listUser != null)
                {
                    foreach (UserLeanning user in listUser)
                    {
                        var userClone = user.JsonToString().JsonToObject<UserLeanning>();
                        // kiểm tra và quét cột film filmForgeted
                        if (userClone.filmForgeted.Count > 0)
                        {
                            foreach (var word in userClone.filmForgeted)
                            {
                                if (word.check == 1)
                                {
                                    if ((DateTime.UtcNow - word.time).TotalHours > 28)
                                    {
                                        // xóa từ cột leaning
                                        userClone.filmForgeted = userClone.filmForgeted.Where(x => x.idWord != word.idWord).ToList();
                                        // từ này học lần 1 sau 24h ngày chuyển từ filmForgeted sang FilmPunishing
                                        ChangeColumeWordBackGroundTasks(word, userClone.filmPunishing, ClassicWordEnum.FilmPunishing);
                                    }
                                }
                                if (word.check == 2)
                                {
                                    if ((DateTime.UtcNow - word.time).TotalDays > 7)
                                    {
                                        userClone.filmForgeted = userClone.filmForgeted.Where(x => x.idWord != word.idWord).ToList();
                                        // từ này học lần 2 sau 7 ngày chuyển từ filmForgeted sang FilmPunishing
                                        ChangeColumeWordBackGroundTasks(word, userClone.filmPunishing, ClassicWordEnum.FilmPunishing);
                                    }
                                }
                                if (word.check == 3)
                                {
                                    if ((DateTime.UtcNow - word.time).TotalDays > 23)
                                    {
                                        userClone.filmForgeted = userClone.filmForgeted.Where(x => x.idWord != word.idWord).ToList();
                                        // từ này học lần 3 sau 30 ngày chuyển từ filmForgeted sang FilmPunishing
                                        ChangeColumeWordBackGroundTasks(word, userClone.filmPunishing, ClassicWordEnum.FilmPunishing);
                                    }
                                }
                            }
                        }

                        // kiểm tra và quét cột film filmLearnning
                        if (userClone.filmLearnning.Count > 0)
                        {
                            foreach (var word in userClone.filmLearnning)
                            {
                                if (word.check == 1)
                                {
                                    if ((DateTime.UtcNow - word.time).TotalHours > 20)
                                    {
                                        userClone.filmLearnning = userClone.filmLearnning.Where(x => x.idWord != word.idWord).ToList();
                                        // từ này học lần 1 sau 24h ngày chuyển từ filmLearnning sang FilmForgeted
                                        ChangeColumeWordBackGroundTasks(word, userClone.filmForgeted, ClassicWordEnum.FilmForgeted);
                                    }
                                }
                                if (word.check == 2)
                                {
                                    if ((DateTime.UtcNow - word.time).TotalDays > 5)
                                    {
                                        userClone.filmLearnning = userClone.filmLearnning.Where(x => x.idWord != word.idWord).ToList();
                                        // từ này học lần 2 sau 7 ngày chuyển từ filmLearnning sang FilmForgeted
                                        ChangeColumeWordBackGroundTasks(word, userClone.filmForgeted, ClassicWordEnum.FilmForgeted);
                                    }
                                }
                                if (word.check == 3)
                                {
                                    if ((DateTime.UtcNow - word.time).TotalDays > 18)
                                    {
                                        userClone.filmLearnning = userClone.filmLearnning.Where(x => x.idWord != word.idWord).ToList();
                                        // từ này học lần 3 sau 30 ngày chuyển từ filmLearnning sang FilmForgeted
                                        ChangeColumeWordBackGroundTasks(word, userClone.filmForgeted, ClassicWordEnum.FilmForgeted);
                                    }
                                }
                            }
                        }

                        // kiểm tra và quét cột film filmFinish
                        if (userClone.filmFinish.Count > 0)
                        {
                            foreach (var word in userClone.filmFinish)
                            {
                                // nếu thời gian lớn hơn 20 ngày + check * 10 thì chuyển sang cột đã quên
                                if ((DateTime.UtcNow - word.time).TotalHours > (10 + word.check * 5))
                                {
                                    // xóa ở cột filmFinish
                                    userClone.filmFinish = userClone.filmFinish.Where(x => x.idWord != word.idWord).ToList();
                                    // từ này học lần 1 sau 24h ngày chuyển từ filmLearnning sang FilmForgeted
                                    ChangeColumeWordBackGroundTasks(word, userClone.filmFinishForget, ClassicWordEnum.FilmFinishForget);
                                }
                            }
                        }



                        // trừ điểm theo ngày
                        if (userClone.filmPunishing != null && userClone.filmPunishing.Count > 0)
                        {
                            var totalWordPunishing = 0;
                            foreach (var word in userClone.filmPunishing)
                            {
                                if (DateTime.UtcNow.Date >= word.time.Date)
                                {
                                    totalWordPunishing += 1;
                                    word.time = DateTime.UtcNow.Date.AddDays(1);
                                }
                            }

                            // đoạn này viết trừ điểm
                            var totalPointSub = totalWordPunishing * 1; // mỗi từ trừ 1 điểm nếu số điểm nhỏ hơn 0 thì sẽ bằng 0
                            if (userClone.point - totalPointSub < 0)
                            {
                                userClone.point = 0;
                            }
                            else
                            {
                                userClone.point -= totalPointSub;
                            }
                        }
                        // lưu DB
                        _db.Entry(user).CurrentValues.SetValues(userClone);
                        await _db.SaveChangesAsync();
                    }

                }
                await Task.Delay(3600000, stoppingToken); // delay 1h
            }

        }

        /// <summary>
        /// Hàm BackGroundTasks chạy ngầm thay đổi cột từ đang học sang cột quên, hay từ cột quên sang trừ điểm
        /// </summary>
        /// <param name="word">từ cần update</param>
        /// <param name="columeAdd">Cột nhận từ word</param>
        /// <param name="changeToColume">id của cột</param>
        public void ChangeColumeWordBackGroundTasks(wordleanedJson word, List<wordleanedJson> columeAdd, ClassicWordEnum changeToColume)
        {
            word.isforget = ForgetEnum.Forget;
            word.classic = changeToColume;
            columeAdd.Add(word);
        }

    }
}
