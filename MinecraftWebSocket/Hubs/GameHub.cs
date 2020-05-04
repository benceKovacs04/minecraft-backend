using Microsoft.AspNetCore.SignalR;
using MinecraftWebSocket.Broadcasters;
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


        /*private static readonly IConnectionMappingService _connections = new ConnectionMappingService();
        
        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;

            _connections.AddConnection(name, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            _connections.RemoveConnectionIds(Context.User.Identity.Name);
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendData(string username)
        {
            var userConnections = _connections.GetConnectionIds(username);
        } */
    }
}
