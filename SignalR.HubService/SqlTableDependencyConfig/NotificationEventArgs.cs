using SignalR.HubService.Models.OnlineUsersHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency.SqlClient.Base.EventArgs;

namespace SignalR.HubService.SqlTableDependencyConfig
{
    public class NotificationEventArgs : EventArgs
    {
        public RecordChangedEventArgs<OnlineUser> ChatServerArgs { get; private set; }

        public NotificationEventArgs(RecordChangedEventArgs<OnlineUser> chatServerArgs)
        {
            this.ChatServerArgs = chatServerArgs;
        }
    }
    public delegate void NotificationEventHandler(OnlineUser chatServer, NotificationEventArgs e);

}
