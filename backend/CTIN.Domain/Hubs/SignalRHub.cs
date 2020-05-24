using CTIN.Common.Enums;
using CTIN.Common.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CTIN.Domain.Hubs
{
    public class ChartHub : Hub
    {
    }

    public class NotificationByReceiver
    {
        public string id { get; set; }
        public object data { get; set; }
        public NotificationStatusEnum status { get; set; }
        public string fullName { get; set; }
        public string avatar { get; set; }
        public DataDbJson dataDb { get; set; }
    }
}
