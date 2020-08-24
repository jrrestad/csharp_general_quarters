using System;
using System.ComponentModel.DataAnnotations;

namespace General_Quarters.Models
{
    public class BattlePosition
    {
        [Key]
        public int BattlePositionId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Foreign Keys
        public bool CheckAvailablePositionForNewShip { get; set; }
        public bool AddBattleShip { get; set; }
        public bool IsAlLShipDamaged { get; set; }
        public bool IsFire { get; set; }


        // Navigation Properties
        public User Player { get; set; }
        public Grid GridLine { get; set; }
        public Ship BattleShip { get; set; }

    }
}