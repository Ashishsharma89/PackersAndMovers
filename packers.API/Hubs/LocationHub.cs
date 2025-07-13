using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace packers.API.Hubs
{
    public class LocationHub : Hub
    {
        // Called by drivers to update their location
        public async Task UpdateLocation(string driverId, double latitude, double longitude)
        {
            // Broadcast to all clients except the sender
            await Clients.Others.SendAsync("ReceiveLocation", driverId, latitude, longitude);
        }
    }
} 