using System;
namespace LavaCave
{
    public class Board
    {
        public Point[,] myBoard;
        public int[] Ecoords; 
        public Board()
        {
            myBoard = new Point[4, 4];

            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    myBoard[i, j] = new Point(new int[]{i,j},".");
                }

            }
            //set rooms
            myBoard[0, 2].SetCont("L");
            myBoard[0, 3].SetCont("K");
            myBoard[1, 1].SetCont("E");
            Ecoords = new int[] { 1,1};
            myBoard[2, 0].SetCont("L");
            myBoard[2, 1].SetCont("L");
            myBoard[3, 3].SetCont("T");
        }
        public Board(bool random)
        {
            myBoard = new Point[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    myBoard[i, j] = new Point(new int[] { i, j }, ".");
                }

            }
            //set rooms
            myBoard[0, 2].SetCont("L");
            myBoard[0, 3].SetCont("K");
            myBoard[1, 1].SetCont("E");
            myBoard[2, 0].SetCont("L");
            myBoard[2, 1].SetCont("L");
            myBoard[3, 3].SetCont("T");

            //remix
            Random rn = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int x = rn.Next(0, 4);
                    int y = rn.Next(0, 4);
                    string temp = myBoard[i, j].cont;
                    myBoard[i, j].SetCont(myBoard[x, y].cont);
                    myBoard[x, y].SetCont(temp);
                }

            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if(myBoard[i, j].cont == "E")
                    {
                        Ecoords = new int[] { i, j };
                    }
                }

            }
        }

        public override string ToString()
        {
            string str = "";
            str += "========\n";
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    str = str + myBoard[i, j].cont;
                    str += " ";
                }
                str += "\n";
            }
            str += "========\n";
            return str;
        }
    }
}
