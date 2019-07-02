using System;
using Bogus;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRPoc.Hubs
{
    public class MessageHub : Hub
    {
        public async Task GetMessage()
        {
            //await Task.Delay(5000);
            await Clients.Caller.SendAsync("ReceiveMessage", $"[{DateTime.Now:s}] {new Faker().Address.FullAddress()} with connection {Context.ConnectionId}");
        }
    }
}
