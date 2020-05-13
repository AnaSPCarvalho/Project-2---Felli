using System;

namespace Felli
{
    /// Main class for the whole program
    class Program
    {
        /// Entry function
        static void Main(string[] args)
        {
            // Set console to accept 'utf-8'
            // so we can put weird character in like the full bar and stuff
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Create a new board for the whole game
            Board board = new Board();

            // Ask player1 for their color
            int player1Color = AskPlayer1Color();

            // Then ask player one of they want to go first or not
            bool isPlayer1Turn = AskPlayer1First();

            // While each side has at least one piece, continue
            while (true)
            {
                if (!board.ExistsPieces(Board.White))
                {
                    Console.WriteLine("Black won!");
                    break;
                }

                if (!board.ExistsPieces(Board.Black))
                {
                    Console.WriteLine("White won!");
                    break;
                }

                // Display the board
                board.Display();

                // Check the turn
                if (isPlayer1Turn)
                {
                    Console.WriteLine("Player1, it's your turn!");
                    board.DoPieceTurn(player1Color);
                }
                else
                {
                    Console.WriteLine("Player2, it's your turn!");
                    board.DoPieceTurn(Board.PieceOppositeTeam(player1Color));
                }

                // And set the turn as the other one
                isPlayer1Turn = !isPlayer1Turn;
            }


            // Wait for key at the end
            Console.WriteLine("Press enter to exit!");
            Console.ReadLine();
        }

        /// Asks player 1 for their color
        private static int AskPlayer1Color()
        {
            Console.WriteLine("Player1, select your color!");

            // Loop while we try to get user input
            while (true)
            {
                Console.WriteLine("Usage: (w / W) or (b / B)");

                // Read the line the user
                String arg = Console.ReadLine();

                // Check if it was black or white and return it if so
                if (arg == "w" || arg == "W")
                {
                    return Board.White;
                }
                if (arg == "b" || arg == "B")
                {
                    return Board.Black;
                }

                // Else retry
                Console.WriteLine("Invalid color! Try again.");
            }
        }

        /// Asks player 1 if they want to go first
        private static bool AskPlayer1First()
        {
            Console.WriteLine("Player1, select if you go first!");

            // Loop while we try to get user input
            while (true)
            {
                Console.WriteLine("Usage: (y / Y) / (n / N)");

                // Read the line the user
                String arg = Console.ReadLine();

                // Check the answer
                if (arg == "y" || arg == "Y")
                {
                    return true;
                }
                if (arg == "n" || arg == "N")
                {
                    return false;
                }

                // Else retry
                Console.WriteLine("Invalid response! Try again.");
            }
        }
    }
}
