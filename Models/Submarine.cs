using System.ComponentModel.DataAnnotations.Schema;
using General_Quarters.Enums;

namespace General_Quarters.Models
{
    [NotMapped]
    public class Submarine : Ship
    {
        public Submarine()
        {
            Name = "Submarine";
            Width = 3;
            OccupationType = OccupationType.Submarine;
        }
    }
}