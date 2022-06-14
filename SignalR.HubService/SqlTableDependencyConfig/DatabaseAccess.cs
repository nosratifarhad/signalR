using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.HubService.SqlTableDependencyConfig
{
    public static class DatabaseAccess
    {
        public static string RetrieveConnectionString()
        {
            return "Data Source=DESKTOP-RE8CP45;Initial Catalog=SignalR_DB;Integrated Security=SSPI;";
        }

        public static string RetrieveSharedConnectionString()
        {
            return "Data Source=DESKTOP-RE8CP45;Initial Catalog=SignalR_DB;Integrated Security=SSPI;";
        }
    }
}
