using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Quarters.Models
{
    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            ShipLength = 3;
            OccupationType = OccupationType.Submarine;
        }
    }
}