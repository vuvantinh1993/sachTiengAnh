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
                            var words = userClone.filmForgeted.Where(word => (word.check == 1 && (DateTime.UtcNow - word.time).TotalHours > 28)
                            || (word.check == 2 && (DateTime.UtcNow - word.time).TotalDays > 7)
                            || (word.check == 3 && (DateTime.UtcNow - word.time).TotalDays > 23)).ToArray();
                            userClone.filmPunishing.AddRange(words);
                            userClone.filmForgeted.RemoveAll(x => words.Contains(x));
                        }

                        // kiểm tra và quét cột film filmLearnning
                        if (userClone.filmLearnning.Count > 0)
                        {
                            var words = userClone.filmLearnning
                                .Where(word => (word.check == 1 && (DateTime.UtcNow - word.time).TotalHours > 20)
                                || (word.check == 2 && (DateTime.UtcNow - word.time).TotalDays > 5)
                                || (word.check == 3 && (DateTime.UtcNow - word.time).TotalDays > 18))
                                .ToArray();
                            userClone.filmForgeted.AddRange(words);
                            userClone.filmLearnning.RemoveAll(x => words.Contains(x));
                        }

                        // kiểm tra và quét cột film filmFinish
                        if (userClone.filmFinish.Count > 0)
                        {
                            var words = userClone.filmFinish
                                .Where(word => (DateTime.UtcNow - word.time).TotalHours > (10 + word.check * 5)).ToArray();
                            userClone.filmFinishForget.AddRange(words);
                            userClone.filmFinish.RemoveAll(x => words.Contains(x));
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
    }
}
