using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace General_Quarters.Models
{
    [NotMapped]
    public class Player
    {
        [Key]
        public int ProfileId {get;set;}
        
        [Required]
        [MinLength(2)]
        [Display(Name = "User Name")]
        public string Name {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        // Foreign Keys
        public int UserId {get;set;}

        // Navigation Parameteres
        public User User {get;set;}
        public GameBoard GameBoard {get;set;}
        public FiringBoard FiringBoard {get;set;}
        public List<Ship> Ships {get;set;}

        public bool HasLost
        {
            get
            {
                return Ships.All(ship => ship.IsSunk);
            }
        }

        public Player() { }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Destroyer(),
                new Submarine(),
                new Cruiser(),
                new Battleship(),
                new Carrier()
            };
            GameBoard = new GameBoard();
            FiringBoard = new FiringBoard();
        }

        // Methods
        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                bool isOpen = true;
                while (isOpen)
                {
                    var startColumn = rand.Next(1, 11);
                    var startRow = rand.Next(1, 11);
                    int endRow = startRow, endColumn = startColumn;
                    var orientation = rand.Next(1, 101) % 2;

                    List<int> panelNumbers = new List<int>();
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endRow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endColumn++;
                        }
                    }

                    if(endRow > 10 || endColumn > 10)
                    {
                        isOpen = true;
                        continue;
                    }

                    var affectedPanels = GameBoard.Panels.Range(startRow, startColumn, endRow, endColumn);
                    if (affectedPanels.Any(panel => panel.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach(var panel in affectedPanels)
                    {
                        panel.OccupationType = ship.OccupationType;
                    }
                    isOpen = false;
                }
            }
        }

        public void OutputBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                         Firing Board:");
            for (int row = 1; row <= 10; row++)
            {
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(GameBoard.Panels.At(row, ownColumn).Status + " ");
                }
                Console.Write("                 ");
                for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
                {
                    Console.Write(FiringBoard.Panels.At(row, firingColumn).Status + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public Coordinates FireShot()
        {
            var hitNeighbors = FiringBoard.GetHitNeighbors();
            Coordinates coords;
            if (hitNeighbors.Any())
            {
                coords = SearchingShot();
            }
            else 
            {
                coords = RandomShot();
            }
            Console.WriteLine(Name + " says: \"Firing shot at " + coords.Row.ToString() + ", " + coords.Column.ToString() + "\"");
            return coords;
        }

        private Coordinates RandomShot()
        {
            var availablePanels = FiringBoard.GetOpenRandomPanels();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var panelId = rand.Next(availablePanels.Count);
            return availablePanels[panelId];
        }

        private Coordinates SearchingShot()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var hitNeighbors = FiringBoard.GetHitNeighbors();
            var neighborId = rand.Next(hitNeighbors.Count);
            return hitNeighbors[neighborId];
        }

        public ShotResult ProcessShot(Coordinates coords)
        {
            var panel = GameBoard.Panels.At(coords.Row, coords.Column);

            if (!panel.IsOccupied)
            {
                Console.WriteLine(Name + " says: \"Miss!\"");
                return ShotResult.Miss;
            }

            var ship = Ships.FirstOrDefault(s => s.OccupationType == panel.OccupationType);
            ship.Hits++;
            Console.WriteLine(Name + " says: \"Hit!\"");

            if (ship.IsSunk)
            {
                Console.WriteLine(Name + "says: \"You sunk my " + ship.Name + "!\""); 
            }

            return ShotResult.Hit;
        }

        public void ProcessShotResult(Coordinates coords, ShotResult result)
        {
            var panel = FiringBoard.Panels.At(coords.Row, coords.Column);
            switch(result)
            {
                case ShotResult.Hit:
                    panel.OccupationType = OccupationType.Hit;
                    break;

                default:
                    panel.OccupationType = OccupationType.Miss;
                    break;
            }
        }
    }
}