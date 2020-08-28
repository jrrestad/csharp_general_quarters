namespace General_Quarters.Models
{
    public class Player
    {   

        public string PlayerID {get;set;}
        public string PlayerName {get;set;}
        public string GameID {get;set;} 
        public bool hasLost {get;set;} = false;
        public Board PlayerBoard {get;set;} = new Board();
        public Destroyer PDestroyer {get;set;} = new Destroyer();
        public Crusier PCrusier {get;set;} = new Crusier();
        public Submarine PSubmarine {get;set;} = new Submarine();
        public Battleship PBattleship {get;set;} = new Battleship();
        public Carrier PCarrier {get;set;} = new Carrier();

        public Player()
        {
            
        }

        public bool CheckBoard()
        {
            int DE=0, CR=0, SU=0, BA=0, CA = 0;
            for(int i = 0;i<11;i++)
            {
                for(int j=0;j<11;j++)
                {
                    if(this.PlayerBoard.board[i][j] == 3)
                    {
                        DE = DE +1;
                    }
                    if(this.PlayerBoard.board[i][j] == 4)
                    {
                        CR = CR +1;
                    }
                    if(this.PlayerBoard.board[i][j] == 5)
                    {
                        SU = SU +1;
                    }
                    if(this.PlayerBoard.board[i][j] == 6)
                    {
                        BA = BA +1;
                    }
                    if(this.PlayerBoard.board[i][j] == 7)
                    {
                        CA = CA +1;
                    }
                }
            }
            if(DE == 0)
            {
                this.PDestroyer.IsDead = true;
            }
            this.PDestroyer.ShipHealth = DE;
            if(CR == 0)
            {
                this.PCrusier.IsDead = true;
            }
            this.PCrusier.ShipHealth = CR;
            if(SU == 0)
            {
                this.PSubmarine.IsDead = true;
            }
            this.PSubmarine.ShipHealth = SU;
            if(BA == 0)
            {
                this.PBattleship.IsDead = true;
            }
            this.PBattleship.ShipHealth = BA;
            if(CA == 0)
            {
                this.PCarrier.IsDead = true;
            }
            this.PCarrier.ShipHealth = CA;

            if(
                this.PDestroyer.IsDead == true &&
                this.PCrusier.IsDead == true &&
                this.PSubmarine.IsDead == true &&
                this.PBattleship.IsDead == true &&
                this.PCarrier.IsDead == true
            )
            {
                this.hasLost = true;
                return this.hasLost;
            }
            else
            {
                return this.hasLost;
            }
        }

    }
}