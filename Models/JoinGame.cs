using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General_Quarters.Models
{
    public class JoinGame
    {
        [Key]
        public int JoinGameId {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;

        //fk
        public int UserId {get;set;}
        public int GameId {get;set;}
        public Game GameToJoin {get;set;}
        public User Joiner {get;set;}
    }
}
