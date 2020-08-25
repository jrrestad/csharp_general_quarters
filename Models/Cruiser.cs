using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Quarters.Models
{
    public class Cruiser : Ship
    {
        public Cruiser()
        {
            Name = "Cruiser";
            ShipLength = 3;
            OccupationType = OccupationType.Cruiser;
        }
    }
}