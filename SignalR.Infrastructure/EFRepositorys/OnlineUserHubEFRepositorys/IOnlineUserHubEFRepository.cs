using SignalR.Infrastructure.DTOs.OnlineUserHubDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Infrastructure.EFRepositorys.OnlineUserHubEFRepositorys
{
    public interface IOnlineUserHubEFRepository
    {
        Task OnDisconnectedOnlineUserAsync(string connectionId,DateTime dateTime);
        Task AddOnlineUserAsync(OnlineUserHubDTO onlineclient);
    }
}
