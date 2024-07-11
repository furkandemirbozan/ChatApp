using Microsoft.AspNetCore.SignalR.Client;

namespace ChatAppWebUI.Helpers
{
    public class SignalrConnection : ISignalrConnection
    {
        HubConnection connection;
        public bool IsConnected()
        {
            return connection != null && connection.State==HubConnectionState.Connected;
        }

        public HubConnection StartConnection()
        {
            var hostInfo = "http://localhost:5100";
            if (connection != null && connection.State == HubConnectionState.Connected)
            {
                return connection;
            }
            connection = new HubConnectionBuilder()
                .WithUrl($"{hostInfo}/chathub")
                .WithKeepAliveInterval(TimeSpan.FromDays(1))
                .WithServerTimeout(TimeSpan.FromDays(1))
                .WithAutomaticReconnect()
                .Build();
            if (connection.State == HubConnectionState.Disconnected)
            {
                connection.StartAsync().Wait();
            }
            return connection;

        }
    }
}
