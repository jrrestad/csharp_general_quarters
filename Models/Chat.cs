using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using General_Quarters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Linq;

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
            return Clients.Group(groupName).SendAsync("Send", $"[{groupName}] {user} says: {message}");
        }
        
        public async Task AddToGroup(string groupName, string user)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            await Clients.Group(groupName).SendAsync("SendOutput", $"{user} has entered the battlespace...");
            await Clients.Group(groupName).SendAsync("Send", $"{user} has joined {groupName} chat.");
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
            //query database to see if record exits with same game id
            // if it does do this
            if(db.PlayingGame.Any(g=>g.GameID==groupName))
            {
                GamePlayer newPlayer = new GamePlayer();
                newPlayer.PlayerID = user;
                newPlayer.GameID = groupName;
                newPlayer.jPlayer = jsonObj;
                db.PlayingGame.Add(newPlayer);
                db.SaveChanges();
                string message = $"{user} is ready to play!";
                Clients.Group(groupName).SendAsync("SendOutput", message);
                //add the start game function here and hide their 
                //attack board.
            }
            else{
                GamePlayer newPlayer = new GamePlayer();
                newPlayer.PlayerID = user;
                newPlayer.GameID = groupName;
                newPlayer.jPlayer = jsonObj;
                db.PlayingGame.Add(newPlayer);
                db.SaveChanges();
                //add player status to messages.
            }
        }
        // public void Round(string user, string gameId, int x, int y)
        public void Round(string user, string gameId, int x, int y)
        {
            Console.WriteLine("we made it to the first line of Round");
            // int X = int.Parse(x);
            // int Y = int.Parse(y);
            int X = x;
            int Y = y;
            GamePlayer OpponentBoard = db.PlayingGame
            .FirstOrDefault(g=>g.GameID == gameId && g.PlayerID != user);
            Player Opp = new Player(); 
            Opp = JsonSerializer.Deserialize<Player>(OpponentBoard.jPlayer);
            int TileState = Opp.PlayerBoard.FireAt(X,Y);
            bool GameStatus = Opp.CheckBoard();
            string YY = "";
            if(Y == 1)
            {
                YY = "A";
            }
            if(Y == 2)
            {
                YY = "B";
            }
            if(Y == 3)
            {
                YY = "C";
            }
            if(Y == 4)
            {
                YY = "D";
            }
            if(Y == 5)
            {
                YY = "E";
            }
            if(Y == 6)
            {
                YY = "F";
            }
            if(Y == 7)
            {
                YY = "G";
            }
            if(Y == 8)
            {
                YY = "H";
            }
            if(Y == 9)
            {
                YY = "I";
            }
            if(Y == 10)
            {
                YY = "J";
            }

            if(!GameStatus){
                string JsonObj = JsonSerializer.Serialize(Opp);
                OpponentBoard.jPlayer = JsonObj;
                db.PlayingGame.Update(OpponentBoard);
                db.SaveChanges();
                //logic to call the JQuery side and send
                // GameState / TileState / user / gameId
                string message = $"{user} has attacked {YY} - {X}!!";
                // Clients.Group(gameId).SendAsync("Send", message);
                Clients.OthersInGroup(gameId).SendAsync("SendOutput", message);
            }
            Clients.Group(gameId).SendAsync("UpdateBoards", user, x, y, TileState);

        }

        // public Task SendReadyMessage(string groupName, string user)
        // {
        //     string message = $"{user} is ready!";
        //     return Clients.Group(groupName).SendAsync("Send", message);

        // }
    }
}