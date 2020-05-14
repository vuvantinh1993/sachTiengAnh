using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using CTIN.Common.Interfaces;
using CTIN.Common.Models;
using CTIN.DataAccess.Bases;
using CTIN.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CTIN.Domain.Models.FilesServiceModel;

namespace CTIN.Domain.Services
{

    public interface IFileService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_FilesServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_FilesServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_FilesServiceModel model);

        Task<(Files data, List<ErrorModel> errors)> FindOne(FindOne_FilesServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_FilesServiceModel model);

        Task UpdateFile(object filesNew, object fileOld = null);
    }

    public class FilesService : IFileService
    {
        private readonly ILogger<FilesService> _log;
        private readonly NATemplateContext _db;
        private readonly ICurrentUserService _currentUserService;

        public FilesService(ILogger<FilesService> log, NATemplateContext db)
        {
            _log = log; _db = db;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_FilesServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.Files.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
            }

            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_FilesServiceModel model)
        {
            var lstError = new List<ErrorModel>();
            var result = new JArray();
            #region logic temp
            //valid            
            var folderUpload = "upload";
            var api = "api/file/dowload";
            var directoryBase = Directory.GetCurrentDirectory();
            var folder = Path.Combine(directoryBase, "wwwroot", folderUpload);

            if (model.folder.HasValue())
            {
                folder = Path.Combine(folder, model.folder);
            }

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);

            }
            foreach (var file in model.file)
            {
                byte[] source = null;
                var name = Guid.NewGuid().ToString();
                var path = Path.Combine(folder, $"{name}{Path.GetExtension(file.FileName)}");
                //resize and zip                
                if ((Path.GetExtension(file.FileName).ToLower().Contains(".jpg") || Path.GetExtension(file.FileName).ToLower().Contains(".png") || Path.GetExtension(file.FileName).ToLower().Contains(".gif") || Path.GetExtension(file.FileName).ToLower().Contains(".ico")) && (model.width != 0 || model.height != 0))
                {
                    using (var image = new Bitmap(Image.FromStream(file.OpenReadStream())))
                    {
                        if (image.Width <= model.width && image.Height <= model.height)//no resize
                        {
                            if (model.folder.HasValue())
                            {
                                image.Save(path);
                            }
                            else
                            {
                                using (var ms = new MemoryStream())
                                {
                                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    source = ms.ToArray();
                                }
                            }
                        }
                        else
                        {
                            using (var ms = new MemoryStream(image.Resize(model.width, model.height, model.quantity, Path.GetExtension(file.FileName).ToLower()).ToArray()))
                            {
                                if (model.folder.HasValue())
                                {
                                    using (var streamSave = new FileStream(path, FileMode.Create))
                                    {
                                        await ms.CopyToAsync(streamSave);
                                    }
                                }
                                else
                                {
                                    source = ms.ToArray();
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (model.folder.HasValue())
                    {
                        using (var streamSave = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(streamSave);
                        }
                    }
                    else
                    {
                        using (var ms = new MemoryStream())
                        {
                            await file.CopyToAsync(ms);
                            source = ms.ToArray();
                        }
                    }
                }


                var urlFile = $"/{api}/{name}{Path.GetExtension(file.FileName)}";

                var data = new Files
                {
                    data = new Files.FilesDataJson
                    {
                        code = $"{name}{Path.GetExtension(file.FileName)}",
                        name = file.FileName,
                        extension = Path.GetExtension(file.FileName),
                        size = file.Length,
                        url = urlFile
                    },
                    source = source,
                    dataDb = new DataDbJson
                    {
                        status = (int)StatusDb.Nomal,
                        createdBy = model.creationBy,
                        createdDate = model.creationTime
                    }
                };
                _db.Files.Add(data);
                await _db.SaveChangesAsync();
                var item = JObject.FromObject(data.data);
                item.Add("id", data.id);
                item.Add("createdBy", model.creationBy);
                item.Add("createdDate", model.creationTime);
                item["url"] = model.domail + urlFile;
                result.Add(item);
            }
            #endregion
            return (result, lstError);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_FilesServiceModel model)
        {
            var errors = new List<ErrorModel>();
            model.delectationBy = _currentUserService.userId;
            model.delectationTime = DateTime.Now;
            var data = await _db.Files.FirstOrDefaultAsync(x => x.id == model.id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = new
            {
                dataDb = new
                {
                    status = (int)StatusDb.Delete,
                    model.delectationTime,
                    model.delectationBy
                }
            };
            _db.Entry(data).CurrentValues.SetValues(data.Patch(update));
            if (await _db.SaveChangesAsync() > 0)
            {
                return (data, errors);
            }

            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(Files data, List<ErrorModel> errors)> FindOne(FindOne_FilesServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.Files.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
            }

            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_FilesServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;

            var query = _db.Files.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

        public async Task UpdateFile(object filesNew, object fileOld = null)
        {
            var result = CheckDetail(JObject.FromObject(filesNew), JObject.FromObject(fileOld));

            foreach (var item in result.lstAdd)
            {
                var fileData = _db.Files.FirstOrDefaultAsync(x => x.id == item.id);
                if (fileData != null)
                {
                    var update = fileData.Patch(new
                    {
                        dataDb = new
                        {
                            status = (int)Common.Enums.StatusDb.Nomal
                        }
                    });
                    _db.Entry(fileData).CurrentValues.SetValues(update);
                }
            }

            foreach (var item in result.lstDelete)
            {
                var fileData = _db.Files.FirstOrDefaultAsync(x => x.id == item.id);
                if (fileData != null)
                {
                    var update = fileData.Patch(new
                    {
                        dataDb = new
                        {
                            status = (int)Common.Enums.StatusDb.Delete
                        }
                    });
                    _db.Entry(fileData).CurrentValues.SetValues(update);
                }
            }

            if (result.lstAdd.Count > 0 && result.lstDelete.Count > 0)
            {
                await _db.SaveChangesAsync();
            }

            (List<FileJson> lstAdd, List<FileJson> lstDelete) CheckDetail(JObject dataNew, JObject dataOld)
            {
                var lstAdd = new List<FileJson>();
                var lstDelete = new List<FileJson>();
                foreach (var property in dataNew)
                {
                    if (property.Value.Type == JTokenType.Object)
                    {
                        if (IsType<FileJson>(property.Value))
                        {
                            var valueNew = property.Value.ToObject<FileJson>();
                            if (dataOld == null)
                            {
                                lstAdd.Add(valueNew);
                            }
                            else
                            {
                                var valueOld = dataOld.GetValue(property.Key).ToObject<FileJson>();
                                if (valueNew.id != valueOld.id)
                                {
                                    lstAdd.Add(valueNew);
                                    lstDelete.Add(valueOld);
                                }
                            }
                        }
                        else
                        {
                            if (dataOld == null)
                            {
                                var result1 = CheckDetail(property.Value.Value<JObject>(), null);
                                lstAdd.AddRange(result1.lstAdd); lstDelete.AddRange(result1.lstDelete);
                            }
                            else
                            {
                                var result1 = CheckDetail(property.Value.Value<JObject>(), dataOld.Value<JObject>(property.Key));
                                lstAdd.AddRange(result1.lstAdd); lstDelete.AddRange(result1.lstDelete);
                            }
                        }
                    }
                    else if (property.Value.Type == JTokenType.Array)
                    {
                        for (int i = 0; i < property.Value.Count(); i++)
                        {
                            var item = property.Value.ElementAt(i);
                            if (item.Type == JTokenType.Object)
                            {
                                if (dataOld == null)
                                {
                                    var result2 = CheckDetail(item.Value<JObject>(), null);
                                }
                                else
                                {
                                    var valueOldArray = dataOld.Value<JArray>(property.Key);
                                    if (valueOldArray.Count > i)
                                    {
                                        var result2 = CheckDetail(item.Value<JObject>(), valueOldArray.ElementAt(i) as JObject);
                                        lstAdd.AddRange(result2.lstAdd); lstDelete.AddRange(result2.lstDelete);
                                    }
                                    else
                                    {
                                        var result2 = CheckDetail(item.Value<JObject>(), null);
                                        lstAdd.AddRange(result2.lstAdd); lstDelete.AddRange(result2.lstDelete);
                                    }
                                }
                            }
                        }
                    }
                }
                return (lstAdd, lstDelete);

                bool IsType<T>(object source) where T : class
                {
                    var objSource = JObject.FromObject(source);
                    var objCheck = typeof(T).GetProperties();
                    foreach (var pro in objSource)
                    {
                        if (!objCheck.Any(x => x.Name.ToLower() == pro.Key.ToLower()))
                        {
                            return false;
                        }
                    }
                    return true;
                }
            }
        }
    }
}
