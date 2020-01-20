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
using System.Threading.Tasks;

namespace CTIN.Domain.Services
{
    public interface IExtraoneService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ExtraoneServiceModel model);
        Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model);

        Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ExtraoneServiceModel model);

        Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ExtraoneServiceModel model);

        Task<(int data, List<ErrorModel> errors)> Count(Count_ExtraoneServiceModel model);
    }

    public class ExtraoneService : IExtraoneService
    {
        private readonly ILogger<ExtraoneService> _log;
        private readonly NATemplateContext _db;
        public readonly ICurrentUserService _currentUserService;

        public ExtraoneService(ILogger<ExtraoneService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
            _currentUserService = currentUserService;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;
            var query = _db.Extraone.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
            }

            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }


        public async Task<(dynamic data, List<ErrorModel> errors)> Add(Add_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = new Extraone();
            var api = "api/Extraone/dowload";
            if (model.audioanswer != null)
            {
                var urlaudioanswer = $"/{api}/{model.audioanswer.FileName}";
                var textanswer = Path.GetFileNameWithoutExtension(model.audioanswer.FileName);
                byte[] sourceaudioanswer = null;
                using (var ms = new MemoryStream())
                {
                    await model.audioanswer.CopyToAsync(ms);
                    sourceaudioanswer = ms.ToArray();
                }

                data.audioanswer = sourceaudioanswer;
                data.textanswer = textanswer;
                data.urlaudioanswer = model.domain + urlaudioanswer;
            }

            if (model.audioquestion != null)
            {
                var urlaudioquestion = $"/{api}/{model.audioquestion.FileName}";
                var textquestion = Path.GetFileNameWithoutExtension(model.audioquestion.FileName);
                byte[] sourceaudioquestion = null;
                using (var ms = new MemoryStream())
                {
                    await model.audioquestion.CopyToAsync(ms);
                    sourceaudioquestion = ms.ToArray();
                }
                data.audioquestion = sourceaudioquestion;
                data.textquestion = textquestion;
                data.urlaudioquestion = model.domain + urlaudioquestion;
            }
            data.categoryfilmid = model.categoryfilmid;
            data.dataDb = new DataDbJson
            {
                createdBy = Int32.Parse(_currentUserService.userId),
                createdDate = DateTime.Now
            };
            _db.Extraone.Add(data);
            await _db.SaveChangesAsync();
            return (data, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Edit(int id, Edit_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Extraone.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            model.id = id;
            var update = data.Patch(model);
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Patch(int id, JObject model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Extraone.FirstOrDefaultAsync(x => x.id == id);
            if (data == null)
            {
                errors.Add(new ErrorModel { key = "", value = "share.notExist" });
            }
            var update = data.Patch(model);
            update.dataDb.modifiedBy = Int32.Parse(_currentUserService.userId);
            update.dataDb.modifiedDate = DateTime.Now;
            _db.Entry(data).CurrentValues.SetValues(update);
            if (await _db.SaveChangesAsync() > 0)
            {
                return (update, errors);
            }
            errors.Add(new ErrorModel { key = "", value = "update fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> Delete(Delete_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var data = await _db.Extraone.FirstOrDefaultAsync(x => x.id == model.id);
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

            errors.Add(new ErrorModel { key = "", value = "Extraone delete fail" });
            return (null, errors);
        }

        public async Task<(dynamic data, List<ErrorModel> errors)> FindOne(FindOne_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();
            var statusActive = (int)StatusDb.Nomal;
            var statusHide = (int)StatusDb.Hide;

            var query = _db.Extraone.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);

                if (!model.whereLoopback.HaveWhereStatusDb()) //default where statusdb is active
                {
                    query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
                }
            }
            else
            {
                query = query.Where(x =>
                   (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusActive || (int)DbFunction.JsonValue(x.dataDb, "$.status") == statusHide);
            }
            var result = await query.FirstOrDefaultAsync();
            return (result, errors);
        }

        public async Task<(int data, List<ErrorModel> errors)> Count(Count_ExtraoneServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.Extraone.AsQueryable();

            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }

            var result = await query.CountAsync();
            return (result, errors);
        }

    }
}
