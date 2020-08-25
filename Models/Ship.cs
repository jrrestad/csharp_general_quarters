using System.ComponentModel.DataAnnotations;

namespace General_Quarters.Models
{
    public class Ship
    {
        [Key]
        public string Name {get;set;}
        public int ShipLength {get;set;}
    }
}