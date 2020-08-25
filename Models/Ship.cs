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
}