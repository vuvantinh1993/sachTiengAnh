using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Contexts;
using CTIN.DataAccess.Models;
using CTIN.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CTIN.Domain.Services
{
    public interface IUpdateDataBaseService
    {
        (dynamic data, List<ErrorModel> errors, PagingModel paging) updateWordDatabase1();
        (dynamic data, List<ErrorModel> errors, PagingModel paging) updateWordDatabase2();
    }

    public class UpdateDataBaseService : IUpdateDataBaseService
    {
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public UpdateDataBaseService(NATemplateContext db, ICurrentUserService currentUserService)
        {
            _db = db;
            _currentUserService = currentUserService;
        }

        public (dynamic data, List<ErrorModel> errors, PagingModel paging) updateWordDatabase1()
        {
            // Hàm chuyReadFolderAndThenUploadDBAndCopyFile
            // file đường dẫn thư mục ban đầu
            ReadFolderAndThenUploadDBAndCopyFile("C:\\Users\\TINHVU\\Desktop\\filecutextra2\\filecut");
            return (null, null, null);
        }

        public (dynamic data, List<ErrorModel> errors, PagingModel paging) updateWordDatabase2()
        {

            // Update vào 2 trường answerWrongEn và answerWrongVn trong DB
            var listId = _db.WordFilm.Where(x => x.categoryfilmid == 4).Select(x => x.id).ToList();
            foreach (var i in listId)
            {
                UpdateAnserWrong(i);
            }
            return (null, null, null);
        }

        public void updatedanhsachtuvaoDB()
        {
            // Update table Rank
            updateTableRank("C:\\Users\\TINHVU\\Desktop\\extra1\\rank.txt");
        }



        // Đọc toàn bộ thư mục video rồi lưu vào database và copy sang thư mục khác
        public void ReadFolderAndThenUploadDBAndCopyFile(string targetDirectory)
        {
            // Process the list of files found in the directory.
            DirectoryInfo di = new DirectoryInfo(targetDirectory);
            FileInfo[] fileEntries = di.GetFiles();
            int stt = 1;

            foreach (var file in fileEntries)
            {
                if (file != null)
                {
                    var fileName = file.FullName;
                    var size = file.Length;
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "extraTwo");

                    // cắt chuỗi textVN và TextEN
                    var name = Regex.Replace(fileName, ".*\\\\", "");
                    var textEn = name.Substring(name.IndexOf('.') + 1, name.IndexOf('-') - name.IndexOf('.') - 2);
                    var textVn = name.Substring(name.IndexOf('-') + 2);


                    // chỉnh sửa đường dẫn cho url
                    //var fullName = Regex.Replace(textEn, @"[\.\!\s\,\-\+\?\`]", "_");
                    var fullName = Regex.Replace(textEn, @"_$", "");
                    fullName = Regex.Replace(fullName, @"[\']", "");

                    textVn = textVn.Substring(0, textVn.Length - 4);
                    textEn = Regex.Replace(textEn, @"_$", "");
                    textEn = Regex.Replace(textEn, "_", " ");
                    textEn = Regex.Replace(textEn, "`", "?");
                    textVn = Regex.Replace(textVn, @"_$", "");
                    textVn = Regex.Replace(textVn, "_", " ");
                    textVn = Regex.Replace(textVn, "`", "?");

                    //// Kiểm tra nếu cuối câu trả lời có dấu '`' thì nó là câu hỏi, cần thêm dấu '?' vào cuối câu
                    //var checkQuest = textVn[textVn.Length - 1];
                    //if (checkQuest == '`')
                    //{
                    //    textEn = textEn + '?';
                    //    textVn = textVn.Substring(0, textVn.Length - 1) + '?';
                    //}

                    // fullname, urlaudio
                    var guid = Guid.NewGuid().ToString();
                    var fileNameNew = $"{stt}_{guid}_{fullName}" + ".mp4";
                    fullName = $"/files/extraOne/{fileNameNew}";
                    var urlaudio = $"http://localhost:5000{fullName}";
                    var stream = Path.Combine(folderPath, fileNameNew);

                    File.Copy(fileName, stream);

                    var data = new WordFilm();
                    data.categoryfilmid = 4;
                    data.size = size;
                    data.textEn = textEn;
                    data.textVn = textVn;
                    data.fullName = fullName;
                    data.urlaudio = urlaudio;
                    data.stt = Convert.ToInt32(stt);
                    data.dataDb = new DataDbJson
                    {
                        createdBy = _currentUserService.userId,
                        createdDate = DateTime.Now
                    };
                    _db.WordFilm.Add(data);
                    _db.SaveChanges();
                    stt = stt + 1;
                }
            }
        }

        // Update vào 2 trường answerWrongEn và answerWrongVn trong DB
        public void UpdateAnserWrong(int Idstt)
        {
            List<int> checkId = new List<int>();
            var listId = _db.WordFilm.Where(x => x.id != Idstt).Select(x => x.id).ToList();
            var data = _db.WordFilm.FirstOrDefault(x => x.id == Idstt);

            var random = new Random();
            int index = random.Next(listId.Count);

            string listStringEn = _db.WordFilm.Where(x => x.id == listId[index]).FirstOrDefault().textEn;
            string listStringVn = _db.WordFilm.Where(x => x.id == listId[index]).FirstOrDefault().textVn;

            for (int i = 0; i < 6; i++)
            {
                while (checkId.Contains(listId[index]))
                {
                    index = random.Next(listId.Count);
                }
                if (i != 0)
                {
                    var textEn = _db.WordFilm.Where(x => x.id == listId[index]).FirstOrDefault().textEn;
                    var textVn = _db.WordFilm.Where(x => x.id == listId[index]).FirstOrDefault().textVn;
                    listStringEn = listStringEn + " *** " + textEn;
                    listStringVn = listStringVn + " *** " + textVn;
                }
                checkId.Add(listId[index]);
            }
            var update = new
            {
                answerWrongEn = listStringEn,
                answerWrongVn = listStringVn
            };
            var model = data.Patch(update);
            _db.Entry(data).CurrentValues.SetValues(model);
            _db.SaveChanges();
        }

        public void updateTableRank(string path)
        {
            string stringFile = File.ReadAllText(path);
            var point = 0;
            List<string> arrlinetext = new List<string>(stringFile.Split(new string[] { "\r\n" }, StringSplitOptions.None));
            if (arrlinetext.Count() > 0)
            {
                for (int i = 0; i < arrlinetext.Count(); i++)
                {
                    var m = i;
                    var item = arrlinetext[m].Split('|');
                    if (item.Count() == 3)
                    {
                        var data = new Rank();
                        data.dataDb = new DataDbJson()
                        {
                            status = 1,
                            //createdBy = _currentUserService.userId,
                            //createdDate = DateTime.Now,
                        };
                        point += Convert.ToInt32(item[2]);
                        //var b = a.Patch(update);
                        data.name = item[0];
                        data.star = Convert.ToInt32(item[1]);
                        data.pointStage = point;
                        data.pointmaxStage = point;
                        _db.Rank.Add(data);
                        _db.SaveChanges();
                    }
                }

            }
        }
    }
}
