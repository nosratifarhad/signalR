using SignalR.Infrastructure.DTOs.OnlineUserDTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using SignalR.Infrastructure.Common;
using Dapper;
namespace SignalR.Infrastructure.EFRepositorys.OnlineUserEFRepositorys
{
    public class OnlineUserEFRepository : IOnlineUserEFRepository
    {
        public async Task<IEnumerable<OnlineUserDTO>> GetOnlineUsersAsync()
        {
            #region EF
            //IList<OnlineUserDTO> onlineUserDTOs = new List<OnlineUserDTO>();
            //using (SignalR_DBEntities signalR_DBEntities = new SignalR_DBEntities())
            //{
            //    IList<TbOnlineUser> users = signalR_DBEntities.TbOnlineUsers.Where(t => t.OutDate == null).ToList();
            //    foreach (var item in users)
            //    {
            //        onlineUserDTOs.Add(new OnlineUserDTO()
            //        {
            //            IpAddress = item.IpAddress,
            //            Browser = item.Browser,
            //            Country = item.Country,
            //            EntryDate = item.EntryDate,
            //            OutDate = item.OutDate ?? DateTime.Now,
            //            OS = item.OS,
            //            Url = item.Url,
            //            ConnectionId = item.ConnectionId
            //        });
            //    }
            //    await signalR_DBEntities.SaveChangesAsync();
            //}
            #endregion
            //await Task.Run(() => Task.Delay(1000));
            throw new NotImplementedException();
        }
    }
}
