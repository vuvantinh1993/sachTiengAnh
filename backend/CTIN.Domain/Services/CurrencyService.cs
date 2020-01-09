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
using System.Linq;
using System.Threading.Tasks;

namespace CTIN.Domain.Services
{
    public interface ICurrencyService
    {
        Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_CurrencyServiceModel model);
    }

    public class CurrencyService : ICurrencyService
    {
        private readonly ILogger<CurrencyService> _log;
        private readonly NATemplateContext _db;

        public CurrencyService(ILogger<CurrencyService> log, NATemplateContext db, ICurrentUserService currentUserService)
        {
            _log = log;
            _db = db;
        }

        public async Task<(dynamic data, List<ErrorModel> errors, PagingModel paging)> Get(Search_CurrencyServiceModel model)
        {
            var errors = new List<ErrorModel>();

            var query = _db.Currency.AsQueryable();
            if (model.where != null)
            {
                query = query.WhereLoopback(model.whereLoopback);
            }
            query = query.OrderByLoopback(model.orderLoopback);
            var result = query.ToPaging(model);
            return (result.data, errors, result.paging);
        }
    }
}
