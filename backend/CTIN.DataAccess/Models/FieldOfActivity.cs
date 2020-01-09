using CTIN.Common.Models;
using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.Models
{
    public partial class FieldOfActivity
    {
        public virtual int id { get; set; }
        public FieldOfActivityDataJson data { get; set; }
        public DataDbJson dataDb { get; set; }
        public class FieldOfActivityDataJson
        {
            public virtual string fieldOfActivityName { get; set; }
            public virtual int activityIndex { get; set; }
            public virtual string note { get; set; }
        }
    }
}
