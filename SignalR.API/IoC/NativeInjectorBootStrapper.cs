using Microsoft.Extensions.DependencyInjection;
using SignalR.ApplicationService.Contract.IOnlineUserServices;
using SignalR.ApplicationService.Implementation.OnlineUserServices;
using SignalR.HubService.Hubs;
using SignalR.HubService.Hubs.IHobs;
using SignalR.Infrastructure.Repositorys.OnlineUserHubRepositorys;
using SignalR.Infrastructure.Repositorys.OnlineUserRepositorys;

namespace SignalR.API.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            //return serv.AddScoped<IPostRepository, PostRepositorys>()
            //    .AddScoped<IPostServices, PostServices>();

            //// OnlineUserHubRepository - OnlineUserHub
            services.AddScoped<IOnlineUserHubRepository, OnlineUserHubRepository>()
                .AddScoped<IOnlineUserHub, OnlineUserHub>();

            //// OnlineUserRepository - OnlineUserService
            services.AddScoped<IOnlineUserRepository, OnlineUserRepository>().
                AddScoped<IOnlineUserService, OnlineUserService>();

            return services;
        }
    }
}
