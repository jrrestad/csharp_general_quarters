using System.Collections.Generic;
using System.Linq;

namespace General_Quarters.Models
{
    public static class PanelExtensions
    {
        public static List<Panel> Range (this List<Panel> panels, int startRow, int startColumn, int endRow, int endColumn)
        {
            return panels
                .Where(panel => panel.Coordinates.Row >= startRow && panel.Coordinates.Column >= startColumn && panel.Coordinates.Row <= endRow && panel.Coordinates.Column <= endColumn)
                .ToList();
        }
    }
}