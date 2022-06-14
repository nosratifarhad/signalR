using SignalR.ApplicationService.ViewModels.OnlineUserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.ApplicationService.Contract.IOnlineUserServices
{
    public interface IOnlineUserService
    {
        Task<IList<OnlineUserViewModel>> GetOnlineUsers();

    }
}
