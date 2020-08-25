using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Quarters.Models
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            ShipLength = 4;
            OccupationType = OccupationType.Battleship;
        }
    }
}