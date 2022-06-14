using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.ApplicationService.ViewModels.OnlineUserViewModels
{
    public class OnlineUserViewModel
    {
        public string IpAddress { get; set; }
        public string Browser { get; set; }
        public string Country { get; set; }
        public string EntryDate { get; set; }
        public string PresenceDate { get; set; }
        public string OutDate { get; set; }        
        public string OS { get; set; }
        public string Url { get; set; }

    }
}
