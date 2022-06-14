using SignalR.Infrastructure.Context;
using SignalR.Infrastructure.DBEntitys;
using SignalR.Infrastructure.DTOs.OnlineUserHubDTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace SignalR.Infrastructure.EFRepositorys.OnlineUserHubEFRepositorys
{
    public class OnlineUserHubEFRepository : IOnlineUserHubEFRepository
    {
        public async Task AddOnlineUserAsync(OnlineUserHubDTO onlineclient)
        {
            try
            {
                #region EF
                //using (SignalR_DBEntities Entities = new SignalR_DBEntities())
                //{
                //    TbOnlineUser tb = new TbOnlineUser();
                //    tb.IpAddress = onlineclient.IpAddress;
                //    tb.Browser = onlineclient.Browser;
                //    tb.Country = onlineclient.Country;
                //    tb.EntryDate = onlineclient.EntryDate;
                //    tb.OS = onlineclient.OS;
                //    tb.Url = onlineclient.Url;
                //    Entities.TbOnlineUsers.Add(tb);
                //    await Entities.SaveChangesAsync();
                //}
                #endregion

                //await Task.Run(() => Task.Delay(1000));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task OnDisconnectedOnlineUserAsync(string connectionId,DateTime dateTime)
        {
            try
            {
                #region EF
                //using (SignalR_DBEntities signalR_DBEntities = new SignalR_DBEntities())
                //{
                //    TbOnlineUser tbOnlineUser = signalR_DBEntities.TbOnlineUsers.Where(a => a.ConnectionId == connectionId && a.OutDate == null).FirstOrDefault();
                //    tbOnlineUser.OutDate = dateTime;
                //    await signalR_DBEntities.SaveChangesAsync();
                //}
                #endregion
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
