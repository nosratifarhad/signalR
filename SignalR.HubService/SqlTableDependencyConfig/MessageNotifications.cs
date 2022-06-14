using Microsoft.AspNetCore.SignalR;
using SignalR.HubService.Models.OnlineUsersHub;
using System;
using System.Threading.Tasks;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace SignalR.HubService.SqlTableDependencyConfig
{
    public class MessageNotifications : IDisposable
    {
        private static SqlTableDependency<OnlineUser> sqlTableDependency;
        private const string TableName = "TbOnlineUser";

        public MessageNotifications(string connectionString)
        {
            var mapper = new ModelToTableMapper<OnlineUser>();
            mapper.AddMapping(cs => cs.IpAddress, "IpAddress")
                  .AddMapping(cs => cs.Browser, "Browser")
                  .AddMapping(cs => cs.Country, "Country")
                  .AddMapping(cs => cs.EntryDate, "EntryDate")
                  .AddMapping(cs => cs.OutDate, "OutDate")
                  .AddMapping(cs => cs.OS, "OS")
                  .AddMapping(cs => cs.Url, "Url")
                  .AddMapping(cs => cs.ConnectionId, "ConnectionId");

            sqlTableDependency = new SqlTableDependency<OnlineUser>(connectionString, TableName, mapper: mapper);
            sqlTableDependency.OnChanged += HandleOnChanged;
            sqlTableDependency.Start();
        }

        ~MessageNotifications()
        {
            Dispose();
        }

        public event NotificationEventHandler OnNewMessage;

        // you need to remove your listeners from an event before you destroy a class instance
        private void HandleOnChanged(object sender, RecordChangedEventArgs<OnlineUser> e)
        {
            if (e.ChangeType == ChangeType.Insert ||
                e.ChangeType == ChangeType.Update ||
                e.ChangeType == ChangeType.Delete)
            {
                OnNewMessage?.Invoke(e.Entity, new NotificationEventArgs(e));
                sqlTableDependency.OnChanged -= HandleOnChanged;
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing && sqlTableDependency != null)
                {
                    sqlTableDependency.Stop();
                    sqlTableDependency.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
        }
    }
}
