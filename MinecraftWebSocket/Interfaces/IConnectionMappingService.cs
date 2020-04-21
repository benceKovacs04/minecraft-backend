using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftWebSocket.Interfaces
{
    interface IConnectionMappingService
    {
        void AddConnection(string username, string connectionId);

        IEnumerable<string> GetConnectionIds(string username);

        void RemoveConnectionIds(string username);
    }
}
