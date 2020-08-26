using System;

namespace General_Quarters.Models
{
    public class GamePlayer
    {
        public int PlayerID {get;set;}
        public int GameID {get;set;} 

        public string jPlayer {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}