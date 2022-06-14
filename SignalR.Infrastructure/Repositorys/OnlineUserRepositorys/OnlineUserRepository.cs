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
namespace SignalR.Infrastructure.Repositorys.OnlineUserRepositorys
{
    public class OnlineUserRepository : IOnlineUserRepository
    {
        public async Task<IEnumerable<OnlineUserDTO>> GetOnlineUsersAsync()
        {
            #region dapper

            //string connectionString = ConfigurationManager.ConnectionStrings["SignalRContext"].ConnectionString;
            using (IDbConnection conn = new SqlConnection("Data Source=DESKTOP-RE8CP45;Initial Catalog=SignalR_DB;Integrated Security=SSPI;"))
            {
                return await conn.QueryAsync<OnlineUserDTO>("dbo.GetOnlineUser");
            }

            #endregion
        }
    }
}
