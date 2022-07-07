using Microsoft.AspNetCore.SignalR;
using Moq;
using SignalR.HubService.Hubs;
using SignalR.HubService.Hubs.IHobs;
using SignalR.Infrastructure.Repositorys.OnlineUserHubRepositorys;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        //private readonly IOnlineUserHub _onlineUserHub;
        private readonly Mock<IOnlineUserHubRepository> _onlineUserHubRepositoryMoq;

        public UnitTest1()
        {
            _onlineUserHubRepositoryMoq = new Mock<IOnlineUserHubRepository>();
        }

        [Fact]
        public async Task testFortest()
        {
            // arrange
            Mock<IHubCallerClients> mockClients = new Mock<IHubCallerClients>();
            Mock<IClientProxy> mockClientProxy = new Mock<IClientProxy>();
            string ipAddress = "192.168.1.1";
            string browser = "chrome";
            string country = "Tehran";
            string entrydate = DateTime.UtcNow.ToString();
            string os = "windows";
            string url = "/home";

            mockClients.Setup(clients => clients.All).Returns(mockClientProxy.Object);

            OnlineUserHub simpleHub = new OnlineUserHub(_onlineUserHubRepositoryMoq.Object)
            {
                Clients = mockClients.Object
            };
            OnlineUserHub _onlineUserHub = new OnlineUserHub(_onlineUserHubRepositoryMoq.Object);

            // act
            await _onlineUserHub.AddOnlineUserAsync(ipAddress, browser, country, entrydate, os, url);

            await simpleHub.AddOnlineUserAsync(ipAddress, browser, country, entrydate, os, url);


            // assert
            mockClients.Verify(clients => clients.All, Times.Once);

            mockClientProxy.Verify(
                clientProxy => clientProxy.SendCoreAsync(
                    "welcome",
                    It.Is<object[]>(o => o != null && o.Length == 1 && ((object[])o[0]).Length == 3),
                    default(CancellationToken)),
                Times.Once);

        }
    }
}
