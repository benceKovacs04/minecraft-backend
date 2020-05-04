using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Minecraft;
using Minecraft.Interfaces;
using MinecraftWebSocket.Hubs;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MinecraftWebSocket.Broadcasters
{
    public class BroadcasterHostedService : IHostedService, IDisposable
    {
        private readonly TimeSpan BroadcastInterval = TimeSpan.FromSeconds(5);
        private readonly IHubContext<GameHub> _hubContext;
        private Timer _broadcastLoop;
        private readonly IStateSupplier<Dictionary<int, Dictionary<int, Dictionary<int, Block>>>> _gameManager;

        public BroadcasterHostedService(IHubContext<GameHub> hubContext, IStateSupplier<Dictionary<int, Dictionary<int, Dictionary<int, Block>>>> gameManager)
        {
            _hubContext = hubContext;
            _gameManager = gameManager;
        }

        public async void BroadcastGameState(Object state)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveGameState", JsonConvert.SerializeObject(_gameManager.GetGameState(), new StringEnumConverter()));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _broadcastLoop = new Timer(BroadcastGameState, null, BroadcastInterval, BroadcastInterval);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _broadcastLoop?.Dispose();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _broadcastLoop?.Dispose();
        }
    }
}
