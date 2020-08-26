using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General_Quarters.Models
{    
    public class Game
    {
        [Key]
        public int GameId {get;set;}
        public string GameName {get;set;} = "General Quarters";
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //fk
        public int UserId {get;set;}
        //np
        public List<JoinGame> JoinGames {get;set;}
        public User Creator {get;set;}
    }
}
