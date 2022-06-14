using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Infrastructure.DTOs.OnlineUserHubDTOs
{
    public class OnlineUserHubDTO
    {
        public string IpAddress { get; private set; }
        public string Browser { get; private set; }
        public string Country { get; private set; }
        public DateTime EntryDate { get; private set; }
        public string OS { get; private set; }
        public string Url { get; private set; }
        public string ConnectionId { get; private set; }
        public OnlineUserHubDTO(
        string ipAddress,
        string browserType,
        string country,
        string entryDate,
        string systemType,
        string route,
            string connectionId)
        {
            this.IpAddress = ipAddress;
            this.Browser = browserType;
            this.Country = country;
            this.EntryDate = DateTime.Parse(entryDate);
            this.OS = systemType;
            this.Url = route;
            this.ConnectionId = connectionId;
        }

        public bool IsEqualIpAddress(string ipAddress)
        {
            return this.IpAddress == ipAddress;
        }
    }
    //{
    //    public OnlineUserHubDTO()
    //    {

    //    }
    //    public string IpAddress { get; set; }
    //    public string BrowserType { get; set; }
    //    public string Country { get; set; }
    //    public string EntryDate { get; set; }
    //    public DateTime OutDate { get; set; }
    //    public DateTime PresenceDate { get; set; }
    //    public string SystemType { get; set; }
    //    public string Route { get; set; }
    //}
}
