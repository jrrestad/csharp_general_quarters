using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Quarters.Models
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Aircraft Carrier";
            ShipLength = 5;
            OccupationType = OccupationType.Carrier;
        }
    }
}