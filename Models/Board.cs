using System;

namespace General_Quarters.Models
{
    public class Board
    {

        public int[][] board {get;set;}
        public Board()
        {
            int[][] jagArr = new int[11][];
                jagArr[0] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[1] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[2] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[3] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[4] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[5] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[6] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[7] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[8] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[9] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
                jagArr[10] = new int[] {0,0,0,0,0,0,0,0,0,0,0};
            
            this.board = jagArr;
        }

        public bool PlaceShip(Ship aShip, Coordinates coords, string direction)
        {
            Board myBoard = this;
            if (direction == "H")
            {
                if (coords.X + aShip.ShipLength - 1 <= 10)
                {

                    for (int i = 0; i < aShip.ShipLength; i++)
                    {
                        if (myBoard.board[coords.Y][coords.X + i] != 0)
                        {
                            return false;
                        }
                        myBoard.board[coords.Y][coords.X + i] = aShip.ShipType;
                        aShip.SLocation = coords;
                    }
                    return true;
                }
                return false;
            }
            if (direction == "V")
            {
                if (coords.Y + aShip.ShipLength - 1 <= 10)
                {
                    for (int i = 0; i < aShip.ShipLength; i++)
                    {
                        if (myBoard.board[coords.Y + i][coords.X] != 0)
                        {
                            return false;
                        }
                        myBoard.board[coords.Y + i][ coords.X] = aShip.ShipType;
                        aShip.SLocation = coords;
                    }
                    return true;
                }
            }
            return false;
        }
        public int FireAt(int x, int y)
        {
            // 0=open water | 1 = miss | 2 = hit | -1=invalid //
            int BoardValue = this.board[y][x];
            if(BoardValue == 0)
            {
                this.board[y][x] = 1;
                return 1;
            }
            else if(BoardValue == 1)
            {
                return -1; // cant hit a miss this should be sorted on the client side
            }
            else if(BoardValue == 2)
            {
                return -2; //cant hit a hit already this should be sorted on the client side
            }
            else
            {
                this.board[y][x] = 2;
                return 2;
            }
        }
        
        public void printGrid()
        {
            Board myBoard = this;
            string row = "";
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    row = row + ", " + myBoard.board[i][j];
                }
                row = row.Substring(1);
                Console.WriteLine(row);
                row = "";
            }
        }
        
    }
}