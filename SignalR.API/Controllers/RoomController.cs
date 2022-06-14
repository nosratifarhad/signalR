using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.ApplicationService.Contract.IOnlineUserServices;
using SignalR.HubService.Hubs;
using SignalR.HubService.Models.OnlineUsersHub;
using SignalR.HubService.SqlTableDependencyConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR.API.Controllers
{
    public class RoomController : Controller
    {
        #region ctor
        private readonly IOnlineUserService _onlineUserService;
        private readonly IHubContext<OnlineUserHub> _context;
        private readonly MessageNotifications notifications;

        public RoomController(IHubContext<OnlineUserHub> context, IOnlineUserService onlineUserService)
        {
            this._onlineUserService = onlineUserService;
            this._context = context;
            notifications = new MessageNotifications(DatabaseAccess.RetrieveConnectionString());
            notifications.OnNewMessage += Rooms_OnEnteredRoom;
        }
        #endregion

        private void Rooms_OnEnteredRoom(OnlineUser server, NotificationEventArgs e)
        {
            var res =  Task.Run(() => _onlineUserService.GetOnlineUsers());
            _context.Clients.All.SendAsync("RecieveDBUpdates", res);
        }

        public ActionResult OnGet()
        {
            return View();
        }
    }
}
