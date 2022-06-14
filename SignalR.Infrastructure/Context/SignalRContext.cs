
using SignalR.Infrastructure.DBEntitys;
using System.Data.Entity;

namespace SignalR.Infrastructure.Context
{
    public class SignalRContext : DbContext
    {
        public DbSet<TbOnlineUser> tbOnlineUser { get; set; }
    }
}
