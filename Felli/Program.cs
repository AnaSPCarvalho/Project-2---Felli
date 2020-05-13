using System;

namespace Felli
{
    // Main class for the whole program
    class Program
    {
        // Entry function
        static void Main(string[] args)
        {
            // Set console to accept 'utf-8'
            // so we can put weird character in like the full bar and stuff
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Create a new board for the whole game
            Board board = new Board();

            // If the current turn is the white's
            bool isWhiteTurn = true;

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
                if (isWhiteTurn)
                {
                    board.DoPieceTurn(Board.White);
                }
                else
                {
                    board.DoPieceTurn(Board.Black);
                }

                // And set the turn as the other one
                isWhiteTurn = !isWhiteTurn;
            }
        }
    }
}