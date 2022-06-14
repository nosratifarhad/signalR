using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.API.Models.UserModels
{
    public class UserModel
    {
        public string IpAddress { get; set; }
        public string BrowserType { get; set; }
        public string Country { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime OutDate { get; set; }
        public DateTime PresenceDate { get; set; }
        public string SystemType { get; set; }
        public string Route { get; set; }
    }
}
