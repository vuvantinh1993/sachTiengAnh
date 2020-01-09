using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class TimeSheetDetail
    {
        public int Id { get; set; }
        public int TimeSheetId { get; set; }
        public string Days { get; set; }
        public string Times { get; set; }
        public string DataDb { get; set; }
    }
}
