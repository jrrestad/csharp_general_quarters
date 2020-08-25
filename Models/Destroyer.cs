using System.ComponentModel.DataAnnotations.Schema;
using General_Quarters.Enums;

namespace General_Quarters.Models
{
    [NotMapped]
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Width = 2;
            OccupationType = OccupationType.Destroyer;
        }
    }
}