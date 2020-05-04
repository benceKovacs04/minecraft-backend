using Microsoft.AspNetCore.SignalR;
using Minecraft.Game;
using MinecraftWebSocket.Broadcasters;
using MinecraftWebSocket.Interfaces;
using MinecraftWebSocket.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftWebSocket.Hubs
{
    public class GameHub : Hub
    {
        private readonly GameManager _gameManager;
        public GameHub(GameManager manager)
        {
            _gameManager = manager;
        }

        public override Task OnConnectedAsync()
        {
            var state = _gameManager.GetGameState();

            for (int i = 0; i < 100; i++)
            {
                Clients.All.SendAsync("ReceiveGameState", JsonConvert.SerializeObject(state[i], new StringEnumConverter()));
            }

            return base.OnConnectedAsync();
        }
    }
}
