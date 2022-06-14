using SignalR.Infrastructure.DTOs.OnlineUserHubDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Infrastructure.Repositorys.OnlineUserHubRepositorys
{
    public interface IOnlineUserHubRepository
    {
        Task OnDisconnectedOnlineUserAsync(string connectionId,DateTime dateTime);
        Task AddOnlineUserAsync(OnlineUserHubDTO onlineclient);
    }
}
