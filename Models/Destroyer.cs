using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Quarters.Models
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            ShipLength = 2;
            OccupationType = OccupationType.Destroyer;
        }
    }
}