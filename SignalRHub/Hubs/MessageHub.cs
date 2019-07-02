using System;
using System.Threading.Tasks;
using Bogus;
using Microsoft.AspNetCore.SignalR;

namespace SignalRHub.Hubs
{
    public class MessageHub : Hub
    {
        public async Task GetMessage()
        {
            //await Task.Delay(5000);
            await Clients.Caller.SendAsync("ReceiveMessage", $"[{DateTime.Now:s}] [connection {Context.ConnectionId}] Sent by {new Faker().Name.FullName()}");
        }
    }
}
