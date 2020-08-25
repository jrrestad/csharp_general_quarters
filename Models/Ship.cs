using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace General_Quarters.Models
{
    [NotMapped]
    public class Ship
    {
        public string Name {get;set;}
        public int Width {get;set;}
        public int Hits {get;set;}
        public OccupationType OccupationType {get;set;}
        public bool IsSunk
        {
            get
            {
                return Hits >= Width;
            }
        }
        
    }
}