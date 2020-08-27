using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using General_Quarters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace General_Quarters.Hubs
{
    public class Chat : Hub
    {
        private GQContext db;
        public Chat(GQContext context)
        {
            db = context;
        }
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
            // await Clients.Group(groupName).SendAsync("Test");
        }

        public Task Test2(string groupName)
        {
            return Clients.Group(groupName).SendAsync("Test");
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

        public void addPlayer(
            string user,
            string groupName,
            Dictionary<string,string> Carrier,
            Dictionary<string,string> Battleship,
            Dictionary<string,string> Submarine,
            Dictionary<string,string> Cruiser,
            Dictionary<string,string> Destroyer
            )
        {
            Console.WriteLine("inside Add Player");
            Player player = new Player();
            Coordinates CarrierCoord = new Coordinates(int.Parse(Carrier["Col"]),int.Parse(Carrier["Row"]));
            Coordinates BattleshipCoord = new Coordinates(int.Parse(Battleship["Col"]),int.Parse(Battleship["Row"]));
            Coordinates SubmarineCoord = new Coordinates(int.Parse(Submarine["Col"]),int.Parse(Submarine["Row"]));
            Coordinates CruiserCoord = new Coordinates(int.Parse(Cruiser["Col"]),int.Parse(Cruiser["Row"]));
            Coordinates DestroyerCoord = new Coordinates(int.Parse(Destroyer["Col"]),int.Parse(Destroyer["Row"]));
            player.PlayerID = user;
            player.GameID = groupName;
            player.PlayerBoard.PlaceShip(player.PCarrier, CarrierCoord, (string)Carrier["Align"]);
            player.PlayerBoard.PlaceShip(player.PBattleship, BattleshipCoord, (string)Battleship["Align"]);
            player.PlayerBoard.PlaceShip(player.PSubmarine, SubmarineCoord, (string)Submarine["Align"]);
            player.PlayerBoard.PlaceShip(player.PCrusier, CruiserCoord, (string)Cruiser["Align"]);
            player.PlayerBoard.PlaceShip(player.PDestroyer, DestroyerCoord, (string)Destroyer["Align"]);
            string jsonObj;
            jsonObj = JsonSerializer.Serialize(player);
            Console.WriteLine(jsonObj);

            GamePlayer newPlayer = new GamePlayer();
            newPlayer.PlayerID = user;
            newPlayer.GameID = groupName;
            newPlayer.jPlayer = jsonObj;
            db.PlayingGame.Add(newPlayer);
            db.SaveChanges();
            
            //create new player
            //convert player to json
            //save player to database
            //return game message player(number) ready.
            Console.WriteLine("Something happened");
        }
    }
}