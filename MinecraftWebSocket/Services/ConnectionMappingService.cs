using MinecraftWebSocket.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftWebSocket.Services
{
    public class ConnectionMappingService : IConnectionMapping
    {
        private readonly Dictionary<string, HashSet<string>> _connections = new Dictionary<string, HashSet<string>>();

        public void AddConnection(string username, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if(!_connections.TryGetValue(username, out connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(username, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }

            }
        }

        public IEnumerable<string> GetConnectionIds(string username)
        {
            HashSet<string> connections;
            if(_connections.TryGetValue(username, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void RemoveConnectionIds(string username)
        {
            lock (_connections)
            {
                if(_connections.ContainsKey(username))
                {
                    _connections.Remove(username);
                }
            }
        }
    }
}
