using System.ComponentModel.DataAnnotations;

namespace General_Quarters.Models
{
    public class Ship
    {
        public string Name { get; set; }
        public int ShipLength { get; set; }
        public int ShipHealth {get;set;}
        public int ShipType { get; set; }
        public bool IsDead {get;set;}
        public int CoordID {get;set;}
        public Coordinates SLocation {get;set;}
    }

    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            ShipLength = 2;
            ShipHealth = 2;
            ShipType = 3;
            IsDead = false;

        }
    }
    public class Crusier : Ship
    {
        public Crusier()
        {
            Name = "Crusier";
            ShipLength = 3;
            ShipHealth = 3;
            ShipType = 4;
            IsDead = false;
        }
    }
    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            ShipLength = 3;
            ShipHealth = 3;
            ShipType = 5;
            IsDead = false;
        }
    }
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            ShipLength = 4;
            ShipHealth = 4;
            ShipType = 6;
            IsDead = false;
        }
    }
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            ShipLength = 5;
            ShipHealth = 5;
            ShipType = 7;
            IsDead = false;
        }
    }
}