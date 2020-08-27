using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace General_Quarters.Models
{
    public class GamePlayer
    {
        [Key]
        public int GpId {get;set;}
        public string PlayerID {get;set;} 
        public string GameID {get;set;} 

        public string jPlayer {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}