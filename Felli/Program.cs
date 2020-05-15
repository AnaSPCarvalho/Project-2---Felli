using System;

namespace Felli
{
    /// <summary>
    /// Class that executes the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry function.
        /// </summary>
        static void Main()
        {
            // Set console to accept 'utf-8' which will allow us to put
            // different characters, like the lines to make the board.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Create a new board for the whole game.
            Board board = new Board();

            // Ask player1 for their color.
            int player1Color = AskPlayer1Color();

            // Then ask player one if they want to go first or not.
            bool isPlayer1Turn = AskPlayer1First();

            // While each side has at least one piece, continue.
            while (true)
            {
                if (!board.ExistsPieces(Board.White))
                {
                    // Display the board.
                    board.Display();
                    Console.WriteLine("Black won!");
                    break;
                }

                if (!board.ExistsPieces(Board.Black))
                {
                    // Display the board.
                    board.Display();
                    Console.WriteLine("White won!");
                    break;
                }

                // Display the board.
                board.Display();

                // Check the turn.
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

                // And set the turn as the other one.
                isPlayer1Turn = !isPlayer1Turn;
            }


            // Wait for key at the end.
            Console.WriteLine("Press enter to exit!");
            Console.ReadLine();
        }

        /// <summary>
        /// Ask player 1 for their color.
        /// </summary>
        /// <returns></returns>
        private static int AskPlayer1Color()
        {
            Console.WriteLine("Player1, select your color!");

            // Loop while we try to get user input.
            while (true)
            {
                Console.WriteLine("Select: White (w) or Black (b)");

                // Read user input.
                String arg = Console.ReadLine();

                // Check if it was black or white and return result.
                if (arg == "w" || arg == "W")
                {
                    return Board.White;
                }
                if (arg == "b" || arg == "B")
                {
                    return Board.Black;
                }

                // Else retry.
                Console.WriteLine("Invalid color! Try again.");
            }
        }

        /// <summary>
        /// Asks player 1 if he wants to go first.
        /// </summary>
        /// <returns>If player 1 wants to go first.</returns>
        private static bool AskPlayer1First()
        {
            Console.WriteLine("Player1, select if you go first!");

            // Loop while we try to get user input.
            while (true)
            {
                Console.WriteLine("Select: Yes(y) or Not (n)");

                // Read user input.
                String arg = Console.ReadLine();

                // Check the answer and return result.
                if (arg == "y" || arg == "Y")
                {
                    return true;
                }
                if (arg == "n" || arg == "N")
                {
                    return false;
                }

                // Else retry.
                Console.WriteLine("Invalid response! Try again.");
            }
        }
    }
}
