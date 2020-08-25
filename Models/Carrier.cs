using General_Quarters.Enums;

namespace General_Quarters.Models
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            Width = 5;
            OccupationType = OccupationType.Carrier;
        }
    }
}