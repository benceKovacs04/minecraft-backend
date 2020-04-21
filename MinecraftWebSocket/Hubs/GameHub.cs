using Microsoft.AspNetCore.SignalR;
using MinecraftWebSocket.Interfaces;
using MinecraftWebSocket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftWebSocket.Hubs
{
    public class GameHub : Hub
    {
        private static readonly IConnectionMappingService _connections = new ConnectionMappingService();
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
