using System;

namespace LavaCave
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //create board
            Board myBoard = new Board(true);
            //point directions
            Point NORTH = new Point(new int[2] { -1, 0},"North.");
            Point EAST  = new Point(new int[2] { 0, 1 },"East.");
            Point SOUTH = new Point(new int[2] { 1, 0 },"South.");
            Point WEST  = new Point(new int[2] { 0, -1},"West.");
            //player vars
            int[] loc = myBoard.Ecoords;
            Point dir = NORTH;
            bool hasKey = false;

            //intro
            Intro();

            while (true)
            {
                //display sence
                Console.WriteLine("You are facing " + dir.cont);
                bool blast = false;
                try
                {

                    if (myBoard.myBoard[loc[0], loc[1]].cont == "T" && myBoard.myBoard[(loc[0] + dir.coord[0]), (loc[1] + dir.coord[1])].cont == "L")
                    {
                        Console.WriteLine("You sense a shiny glow and a blast of heat.");
                        blast = true;
                    }
                    else if (myBoard.myBoard[loc[0], loc[1]].cont == "K" && hasKey == false && myBoard.myBoard[(loc[0] + dir.coord[0]), (loc[1] + dir.coord[1])].cont == "L")
                    {
                        Console.WriteLine("You sense a rusty smell and a blast of heat.");
                        blast = true;
                    }
                    else if (myBoard.myBoard[(loc[0] + dir.coord[0]), (loc[1] + dir.coord[1])].cont == "L")
                    {
                        Console.WriteLine("You sense a blast of heat.");
                        blast = true;
                    }
                }
                catch(Exception ex)
                {
                }
                if (blast != true)
                {
                    if (myBoard.myBoard[loc[0], loc[1]].cont == "K" && hasKey == false)
                    {
                        Console.WriteLine("You sense a rusty smell.");
                    }
                    else if (myBoard.myBoard[loc[0], loc[1]].cont == "T")
                    {
                        Console.WriteLine("You sense a shiny glow.");
                    }
                    else
                    {
                        Console.WriteLine("You sense nothing unusual!");
                    }
                }


                Console.Write("Enter cmd: ");
                string ans = Console.ReadLine().ToUpper();
                Console.WriteLine(" ");
                if (ans == "X")
                {
                    Console.WriteLine(PrintBoard(myBoard));
                    Console.WriteLine("You are at: [" + loc[0] + ", " + loc[1] + "]");
                }
                else if (ans == "Q")
                {
                    Environment.Exit(0);
                }
                else if (ans == "S")
                {
                    if (myBoard.myBoard[loc[0], loc[1]].cont == "K")
                    {
                        if (hasKey == false)
                        {
                            Console.WriteLine("You find a key!");
                            hasKey = true;
                        }
                        else
                        {
                            Console.WriteLine("You sense nothing unusual.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can not find anything to pick up.");
                    }
                }
                else if (ans == "T")
                {
                    if (myBoard.myBoard[loc[0], loc[1]].cont == "T")
                    {
                        if (hasKey == true)
                        {
                            Console.WriteLine("You open the chest and find inner peace!");
                            Console.WriteLine("You Win!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("The treasure chest is locked.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can not find any treasure here.");
                    }
                }
                else if (ans == "L")
                {
                    if (dir == NORTH) dir = WEST;
                    else if (dir == WEST) dir = SOUTH;
                    else if (dir == SOUTH) dir = EAST;
                    else dir = NORTH;
                }
                else if (ans == "R")
                {
                    if (dir == NORTH) dir = EAST;
                    else if (dir == WEST) dir = NORTH;
                    else if (dir == SOUTH) dir = WEST;
                    else dir = SOUTH;
                }
                else if (ans == "F")
                {
                    try
                    {
                        myBoard.myBoard[(loc[0] + dir.coord[0]),
                            (loc[1] + dir.coord[1])].ToString();

                        loc[0] += dir.coord[0];
                        loc[1] += dir.coord[1];
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("You hit a wall!");
                    }

                }
                //check for death
                if(myBoard.myBoard[loc[0],loc[1]].cont == "L")
                {
                    Console.WriteLine("You fall into lava and burn to a crisp!");
                    Console.WriteLine("Game Over.");
                    break;
                }
            }
        }

        public static void Intro()
        {
            Console.Write("Welcome to Lava Cave!\n");
            Console.Write("Loot the treasure without falling into lava.\n");
            Console.Write("Try the following commands:\n");
            Console.Write("Move (F)orward, Turn (L)eft, Turn (R)ight,\n");
            Console.Write("(S)earch for items, Loot the (T)reasure,\n");
            Console.WriteLine("(Q)uit the game, Use(X) to cheat.\n");
        }

        public static string PrintBoard(Board myBoard)
        {
            Console.WriteLine("Cheat!");
            return myBoard.ToString();
        }
    }
}
