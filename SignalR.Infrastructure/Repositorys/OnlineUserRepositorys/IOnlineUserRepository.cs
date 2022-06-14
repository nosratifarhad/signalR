using SignalR.Infrastructure.DTOs.OnlineUserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Infrastructure.Repositorys.OnlineUserRepositorys
{
    public interface IOnlineUserRepository
    {
        Task<IEnumerable<OnlineUserDTO>> GetOnlineUsersAsync();
    }
}
