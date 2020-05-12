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

            // Wait for newkey
            // Console.WriteLine("Press enter to exit!");
            // Console.ReadLine();
        }
    }
}