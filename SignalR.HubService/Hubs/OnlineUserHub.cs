using Microsoft.AspNetCore.SignalR;
using SignalR.HubService.Hubs.IHobs;
using SignalR.Infrastructure.DTOs.OnlineUserHubDTOs;
using SignalR.Infrastructure.Repositorys.OnlineUserHubRepositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.HubService.Hubs
{
    public class OnlineUserHub : Hub, IOnlineUserHub
    {
        #region ctor

        private readonly IOnlineUserHubRepository _onlineUserHubRepository;
        public OnlineUserHub(IOnlineUserHubRepository onlineUserHubRepository)
        {
            this._onlineUserHubRepository = onlineUserHubRepository;
        }

        #endregion

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await _onlineUserHubRepository.OnDisconnectedOnlineUserAsync(Context.ConnectionId, DateTime.Now);///ipAddtess
        }

        [HubMethodName("AddOnlineUserAsync")]
        public async Task AddOnlineUserAsync(string ipAddress, string browser, string country, string entrydate, string os, string url)//OnlineUserHobModel clientHobModel)
        {
            try
            {
                OnlineUserHubDTO onlineUserHubDTO = new OnlineUserHubDTO(ipAddress, browser, country, entrydate, os, url, Context.ConnectionId);

                //TODO Repository
                await _onlineUserHubRepository.AddOnlineUserAsync(onlineUserHubDTO);
                //TODO Repository

                //await Clients.All.SendAsync("ReciveMessage", ipAddress, true, "key");
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message);
            }
        }

    }

}
