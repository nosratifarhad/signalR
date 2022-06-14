using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SignalR.Infrastructure.Common
{
    public class AppConfig
    {
        public static string GetConnectionStrings()
        {
            return ConfigurationManager.ConnectionStrings["SignalRContext"].ConnectionString;
        }


    }
}
