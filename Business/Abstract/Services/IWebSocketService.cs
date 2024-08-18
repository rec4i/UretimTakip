using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Services
{
    public interface IWebSocketService
    {
        Task BroadcastAsync(string message);
        Task HandleWebSocketConnection(WebSocket webSocket);
    }
}
