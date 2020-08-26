using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Quarters.Models
{
    public class Ship
    {
        [Key]
        public int ShipId { get; set; }
        public string Name {get;set;}
        public int ShipLength {get;set;}
        public int Hits {get;set;}
        public OccupationType OccupationType {get;set;}
    }

    // public class Cruiser : Ship
    // {
    //     public Cruiser()
    //     {
    //         Name = "Cruiser";
    //         ShipLength = 3;
    //         ShipType = 'C';
    //     }
    // }

    // public class Battleship : Ship
    // {
    //     public Battleship()
    //     {
    //         Name = "Battleship";
    //         ShipLength = 4;
    //         ShipType = 'B';
    //     }
    // }

    // public class Carrier : Ship
    // {
    //     public Carrier()
    //     {
    //         Name = "Carrier";
    //         ShipLength = 5;
    //         ShipType = 'A';
    //     }
    // }

    // public class Submarine : Ship
    // {
    //     public Submarine()
    //     {
    //         Name = "Submarine";
    //         ShipLength = 3;
    //         ShipType = 'S';
    //     }
    // }

}