using Bogus;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRHub.Hubs
{
    public class MessageHub : Hub
    {
        public async Task GetMessage()
        {
            for (var i = 0; ; i++)
            {
                await Clients.Caller.SendAsync("ReceiveMessage", $"[{DateTime.Now:s}] [{i}] Sent by {new Faker().Name.FullName()}");
                await Task.Delay(5000);
            }
        }
    }
}
