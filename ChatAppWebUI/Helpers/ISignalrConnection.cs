using Microsoft.AspNetCore.SignalR.Client;

namespace ChatAppWebUI.Helpers
{
    public interface ISignalrConnection
    {
        HubConnection StartConnection();
        bool IsConnected();
    }
}
