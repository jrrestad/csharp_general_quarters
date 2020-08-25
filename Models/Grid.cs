using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace General_Quarters.Models
{
    public class Grid
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Grid(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}