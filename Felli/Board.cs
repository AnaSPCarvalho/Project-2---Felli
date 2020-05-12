using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    // Board class, stores the positions of all pieces on the map.
    class Board
    {
        public const int Empty = UnravelledBoard.Empty;
        public const int White = UnravelledBoard.White;
        public const int Black = UnravelledBoard.Black;
        public const int Wall = UnravelledBoard.Wall;

        // The unravelled board.
        UnravelledBoard board;

        // Board constructor.
        public Board()
        {
            // Create a new standard board.
            board = new UnravelledBoard();
        }

        // Prints the board
        public void Display()
        {
            // Write all xs
            Console.WriteLine("  1 2 3 4 5");

            // Write the top line of the board box
            Console.WriteLine(" ┌─────────┐");

            // Write all rows
            for (int y = 0; y < 5; y++)
            {
                // Write the current y and left column
                Console.Write(y + 1);
                Console.Write("│");

                // Write each column
                for (int x = 0; x < 3; x++)
                {
                    // Pad 1 space in between each piece
                    if (x != 0)
                    {
                        Console.Write(" ");
                        // If this is the top or bottom, pad 2 more in the 
                        // middle
                        if (y == 0 || y == 4)
                        {
                            Console.Write("  ");
                        }
                    }

                    // If we're in the inner rows, pad the start
                    if ((y == 1 || y == 3) && x == 0)
                    {
                        Console.Write("  ");
                    }

                    // If we're not in the middle row or this is the middle of 
                    // the middle row
                    if (y != 2 || (y == 2 && x == 1))
                    {
                        Console.Write("▫");
                    }

                    // Else just pad some spaces
                    else
                    {
                        Console.Write("   ");
                    }

                    // If we're in the inner rows, pad the end
                    if ((y == 1 || y == 3) && x == 2)
                    {
                        Console.Write("  ");
                    }
                }

                // Write the right column
                Console.WriteLine("│");
            }

            // Write the bottom line of the board box
            Console.WriteLine(" └─────────┘");
        }
    }
}
