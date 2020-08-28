using System.ComponentModel.DataAnnotations;

namespace General_Quarters.Models
{
    public class Coordinates
    {
        [Key]
        public int CoordID {get;set;}
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Coordinates()
        {
            
        }
    }
}