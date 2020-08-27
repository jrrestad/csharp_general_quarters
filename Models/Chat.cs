using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace General_Quarters.Hubs
{
    public class Chat : Hub
    {
        // public async Task SendMessage(string user, string message)
        // {
        //     await Clients.All.SendAsync("ReceiveMessage", user, message);
        // }

        public Task SendMessageToGroup(string groupName, string message, string user)
        {

            // return Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId}: {message}");
            return Clients.Group(groupName).SendAsync("Send", $"[{groupName}] {user} says: {message}");
        }

        public async Task AddToGroup(string groupName, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{user} has joined {groupName} chat.");
        }

        public async Task RemoveFromGroup(string groupName, string user)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("Send", $"{user} has left {groupName} chat.");
        }

        public Task SendPrivateMessage(string user, string message)
        {
            return Clients.User(user).SendAsync("ReceiveMessage", message);
        }

        public void addPlayer()
        {
            Console.WriteLine("Something happened");
        }
    }
}