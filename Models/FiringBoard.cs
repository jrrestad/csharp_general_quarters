using System.Collections.Generic;
using System.Linq;
using General_Quarters.Enums;

namespace General_Quarters.Models
{
    public class FiringBoard : GameBoard
    {
        public List<Coordinates> GetHitNeighbors()
        {
            List<Panel> panels = new List<Panel>();
            var hits = panels.Where(panel =>  panel.OccupationType == OccupationType.Hit);
            foreach (var hit in hits)
            {
                panels.AddRange(GetNeighbors(hit.Coordinates).ToList());
            }
            return panels.Distinct()
                .Where(p => p.OccupationType == OccupationType.Empty)
                .Select(p => p.Coordinates)
                .ToList();
        }
        public List<Coordinates> GetOpenRandomPanels()
        { 
            return Panels.Where(p => p.OccupationType == OccupationType.Empty && p.IsRandomAvailable)
                .Select(p => p.Coordinates)
                .ToList();
        }
        public List<Panel> GetNeighbors(Coordinates coordinates) 
        { 
            
        }

        
    }
}