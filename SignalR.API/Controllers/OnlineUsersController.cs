using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalR.ApplicationService.Contract;
using SignalR.ApplicationService.Contract.IOnlineUserServices;
using SignalR.ApplicationService.ViewModels.OnlineUserViewModels;

namespace SignalR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnlineUserController : ControllerBase
    {
        private readonly IOnlineUserService _onlineUserService;

        public OnlineUserController(IOnlineUserService onlineUserService)
        {
            this._onlineUserService = onlineUserService;
        }

        [HttpGet("Get")]
        public async Task<IList<OnlineUserViewModel>> GetOnlineUsers()
        {
            return await _onlineUserService.GetOnlineUsers();
        }

    }
}
