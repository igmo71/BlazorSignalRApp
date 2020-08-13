using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace BlazorSignalRApp.Client.Pages
{
    public partial class Clock : IDisposable
    {
        [Inject] 
        NavigationManager NavigationManager { get; set; }

        private DateTime currentTime = DateTime.Now;

        private HubConnection clockHubConnection;

        protected override async Task OnInitializedAsync()
        {
            clockHubConnection = new HubConnectionBuilder().WithUrl(NavigationManager.ToAbsoluteUri("/hubs/clock")).Build();
            clockHubConnection.On<DateTime>("ShowTime", currentTime => ShowTime(currentTime));
            await clockHubConnection.StartAsync();
        }

        private void ShowTime(DateTime dateTime)
        {
            currentTime = dateTime;
            StateHasChanged();
        }

        public void Dispose()
        {
            clockHubConnection.DisposeAsync();
        }
    }
}
