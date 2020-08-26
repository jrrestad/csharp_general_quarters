using System.ComponentModel.DataAnnotations;

namespace General_Quarters.Models
{
    public class Ship
    {
        public string Name {get;set;}
        public int ShipLength {get;set;}
        public char ShipType {get;set;}
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            ShipLength = 2;
            ShipType = 'D';
        }
    }
}