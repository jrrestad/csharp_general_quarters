using System.ComponentModel.DataAnnotations.Schema;

namespace General_Quarters.Models
{
    [NotMapped]
    public class Coordinates
    {
        public int Row {get;set;}
        public int Column {get;set;}

        public Coordinates() {}

        public Coordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}