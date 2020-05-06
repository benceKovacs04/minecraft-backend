using Microsoft.AspNetCore.SignalR;
using Minecraft;
using Minecraft.Game;
using Minecraft.Interfaces;
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
        private readonly IGameManager<Block[,]> _gameManager;
        public GameHub(IGameManager<Block[,]> manager)
        {
            _gameManager = manager;
        }

        public override Task OnConnectedAsync()
        {
            var state = _gameManager.GetGameState();

            /*for (int i = 0; i < 100; i++)
            {
                Clients.All.SendAsync("ReceiveGameState", JsonConvert.SerializeObject(state[i], new StringEnumConverter()));
            }*/

            Clients.All.SendAsync("ReceiveGameState", JsonConvert.SerializeObject(state, new StringEnumConverter()));


            return base.OnConnectedAsync();
        }
    }
}
