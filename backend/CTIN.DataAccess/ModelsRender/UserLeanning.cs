using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class UserLeanning
    {
        public int Id { get; set; }
        public string Filmleanning { get; set; }
        public int Point { get; set; }
        public string Listfrendid { get; set; }
        public string DataDb { get; set; }
        public string Information { get; set; }
        public string Filmforgeted { get; set; }
        public string Filmpunishing { get; set; }
        public string Filmfinish { get; set; }
    }
}
