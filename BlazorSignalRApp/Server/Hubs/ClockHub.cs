using BlazorSignalRApp.Shared;
using Microsoft.AspNetCore.SignalR;

namespace BlazorSignalRApp.Server.Hubs
{
    public class ClockHub : Hub<IClock>
    {
        //public async Task SendTimeToClients(DateTime dateTime)
        //{
        //    await Clients.All.ShowTime(dateTime);
        //}
    }
}
