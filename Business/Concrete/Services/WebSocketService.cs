using Business.Abstract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Services
{

    public class WebSocketService : IWebSocketService
    {
        private static readonly HashSet<WebSocket> _clients = new HashSet<WebSocket>();
        private static readonly object _lock = new object();

        public async Task HandleWebSocketConnection(WebSocket webSocket)
        {
            lock (_lock)
            {
                _clients.Add(webSocket);
            }

            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            while (!result.CloseStatus.HasValue)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                // Broadcast the message to all connected clients
                await BroadcastAsync(message);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            lock (_lock)
            {
                _clients.Remove(webSocket);
            }

            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }

        public Task BroadcastAsync(string message)
        {
            lock (_lock)
            {
                var tasks = _clients.Select(client => SendMessageAsync(client, message));
                return Task.WhenAll(tasks);
            }
        }

        private async Task SendMessageAsync(WebSocket webSocket, string message)
        {
            var buffer = Encoding.UTF8.GetBytes(message);
            var segment = new ArraySegment<byte>(buffer);

            if (webSocket.State == WebSocketState.Open)
            {
                await webSocket.SendAsync(segment, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
