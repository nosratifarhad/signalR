using SignalR.ApplicationService.Contract.IOnlineUserServices;
using SignalR.ApplicationService.ViewModels.OnlineUserViewModels;
using SignalR.Infrastructure.Repositorys.OnlineUserRepositorys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.ApplicationService.Implementation.OnlineUserServices
{
    public class OnlineUserService : IOnlineUserService
    {
        #region ctor
        private IOnlineUserRepository _onlineUserRepository;

        public OnlineUserService(IOnlineUserRepository onlineUserRepository)
        {
            this._onlineUserRepository = onlineUserRepository;
        }

        #endregion

        public async Task<IList<OnlineUserViewModel>> GetOnlineUsers()
        {
            var onlineUserDTOs = await _onlineUserRepository.GetOnlineUsersAsync();
            IList<OnlineUserViewModel> onlineUserViewModels = new List<OnlineUserViewModel>();

            foreach (var item in onlineUserDTOs)
            {
                ///To Do Get PresenceDate
                string presencedate = string.Empty;
                //GetPresenceDate(item.EntryDate, item.OutDate, ref presencedate);
                ///
                onlineUserViewModels.Add(new OnlineUserViewModel
                {
                    IpAddress = item.IpAddress,
                    Browser = item.Browser,
                    Country = item.Country,
                    EntryDate = item.EntryDate.ToString(),
                    OutDate = item.OutDate.ToString() ?? "",
                    PresenceDate = presencedate??"",
                    OS = item.OS,
                    Url = item.Url
                });
            }
            return onlineUserViewModels;
        }

        public string GetPresenceDate(string outDate, string entryDate, ref string PresenceDate)
        {
            return "";
        }

    }
}
