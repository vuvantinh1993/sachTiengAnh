using CTIN.Common.Enums;
using CTIN.Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace CTIN.Common.Models
{
    public interface IPagingSizeModel
    {
        string order { get; set; }

        int page { get; set; }

        int size { get; set; }

    }

    public interface IPagingCountModel
    {
        int? totalPage { get; set; }
        long? count { get; set; }
    }

    public interface IFileModel
    {
        string code { get; set; }

        string name { get; set; }

        string extension { get; set; }

        string url { get; set; }

        long size { get; set; }
    }

    public class PagingModel : IPagingSizeModel, IPagingCountModel
    {

        public int? totalPage { get; set; }
        public long? count { get; set; }
        public string order { get; set; }
        public int page { get; set; }
        public int size { get; set; }

    }

    public class WhereModel
    {
        public virtual string where { get; set; }

        [JsonIgnore]
        public virtual JObject whereLoopback
        {
            get { return where.HasValue() ? JsonConvert.DeserializeObject<JObject>(where) : null; }
        }

        public virtual string select { get; set; }

        [JsonIgnore]
        public virtual JObject selectLoopback
        {
            get { return select.HasValue() ? JsonConvert.DeserializeObject<JObject>(select) : null; }
        }
    }

    public class SearchModel : WhereModel, IPagingSizeModel
    {
        public SearchModel()
        {
            order = "[{\"id\": true}]";
            page = 1;
            size = 5;
        }

        [JsonIgnore]
        public virtual JArray orderLoopback
        {
            get { return order.HasValue() ? JsonConvert.DeserializeObject<JArray>(order) : null; }
        }

        public virtual string order { get; set; }
        public virtual int page { get; set; }

        private int _size;
        public virtual int size
        {
            get { return _size; }
            set
            {
                if (value > 200)
                {
                    _size = 200;
                }
                else
                {
                    _size = value;
                }
            }
        }
    }

    public class ResultModel<T>
    {
        public SerializableError error { get; set; }

        public T data { get; set; }

        public PagingModel paging { get; set; }
    }

    public class ErrorModel
    {
        public string key { get; set; }

        public string value { get; set; }
    }

    public class FileJson : IFileModel
    {
        public virtual long id { get; set; }
        public virtual string code { get; set; }
        public virtual string name { get; set; }
        public virtual string extension { get; set; }
        public virtual string url { get; set; }
        public virtual long size { get; set; }
        public virtual long createdBy { get; set; }
        public virtual DateTime createdDate { get; set; } = DateTime.Now;
    }

    public class DataDbJson
    {
        public virtual short status { get; set; } = (byte)StatusDb.Nomal;
        public virtual DateTime createdDate { get; set; } = DateTime.Now;
        public virtual long createdBy { get; set; }
        public virtual DateTime? modifiedDate { get; set; }
        public virtual long? modifiedBy { get; set; }
        public virtual DateTime? deletedDate { get; set; }
        public virtual long? deletedBy { get; set; }
    }
}
