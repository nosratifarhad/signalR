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

namespace SignalR.Infrastructure.Repositorys.OnlineUserHubRepositorys
{
    public class OnlineUserHubRepository : IOnlineUserHubRepository
    {
        public async Task AddOnlineUserAsync(OnlineUserHubDTO onlineclient)
        {
            try
            {
                #region dapper
                //string connectionString = ConfigurationManager.ConnectionStrings["SignalRContext"].ConnectionString;
                using (IDbConnection conn = new SqlConnection("Data Source=DESKTOP-RE8CP45;Initial Catalog=SignalR_DB;Integrated Security=SSPI;"))
                {
                    await conn.ExecuteAsync("insert into TbOnlineUser " +
                        "(IpAddress,Browser,Country,EntryDate,OS,Url,ConnectionId) values " +
                        "(@IpAddress ,@Browser ,@Country ,@EntryDate,@OS,@Url,@ConnectionId)",
                        new
                        {
                            onlineclient.IpAddress,
                            onlineclient.Browser,
                            onlineclient.Country,
                            onlineclient.EntryDate,
                            onlineclient.OS,
                            onlineclient.Url,
                            onlineclient.ConnectionId
                        });
                }
                #endregion
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
                #region dapper

                //string connectionString = ConfigurationManager.ConnectionStrings["SignalRContext"].ConnectionString;
                using (IDbConnection conn = new SqlConnection("Data Source=DESKTOP-RE8CP45;Initial Catalog=SignalR_DB;Integrated Security=SSPI;"))
                {
                    await conn.ExecuteAsync("dbo.OnDisconnectedOnlineUserByConnectionId @Datetime ,@ConnectionId",
                        new
                        {
                            Datetime = dateTime,
                            ConnectionId = connectionId,
                        });
                }
                #endregion

            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }
    }
}
