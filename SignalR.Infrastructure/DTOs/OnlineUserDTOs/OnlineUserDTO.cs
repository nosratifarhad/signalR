using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Infrastructure.DTOs.OnlineUserDTOs
{
    public class OnlineUserDTO
    {
        public string IpAddress { get;  set; }
        public string Browser { get;  set; }
        public string Country { get;  set; }
        public DateTime EntryDate { get;  set; }
        public DateTime OutDate { get;  set; }
        public string OS { get;  set; }
        public string Url { get;  set; }
    }
}
