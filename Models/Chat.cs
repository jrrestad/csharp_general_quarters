using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace General_Quarters.Hubs
{
    public class Chat : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}