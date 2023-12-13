using Microsoft.AspNetCore.SignalR;

namespace VideoCallAPI.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task RoomsUpdated(bool flag)
        {
            await Clients.Others.SendAsync("RoomsUpdated", flag);
        }
    }
}
