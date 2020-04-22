using System;
using System.Collections.Generic;

namespace CTIN.DataAccess.ModelsRender
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string UserPassword { get; set; }
        public string Description { get; set; }
        public DateTime? Birthday { get; set; }
        public string DataDb { get; set; }
        public DateTime? LatestLogin { get; set; }
    }
}
