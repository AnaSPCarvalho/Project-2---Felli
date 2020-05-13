using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
    /// <summary>
    /// /// An unravelled board
    /// </summary>
    class UnravelledBoard
    {
        public const int Empty = 0;
        public const int White = 1;
        public const int Black = 2;
        public const int Wall = 3;

        /// <summary>
        /// /// The whole board in it's unraveled form
        /// </summary>
        private int[][] board;

        /// <summary>
        /// /// Constructor
        /// </summary>
        public UnravelledBoard()
        {
            // Create the board
            board = new int[5][] {
                new int[3] { Black, Black, Black },
                new int[3] { Black, Black, Black },
                new int[1] { Empty },
                new int[3] { White, White, White },
                new int[3] { White, White, White },
            };
        }

        // Returns the piece at `x, y`
        public int GetPiece(int x, int y)
        {
            // If we're on the first 2 rows, just return it normally
            if (y < 2)
            {
                return board[y][x];
            }

            // If we're on the last 2 rows, invert x
            else if (y > 2)
            {
                return board[y][2 - x];
            }

            // Else we're on the middle row, so return the 0th column
            else
            {
                return board[y][0];
            }
        }

        // Sets the piece at `x, y`
        public void SetPiece(int x, int y, int piece)
        {
            // If we're on the first 2 rows, just set it normally
            if (y < 2)
            {
                board[y][x] = piece;
            }

            // If we're on the last 2 rows, invert x
            else if (y > 2)
            {
                board[y][2 - x] = piece;
            }

            // Else we're on the middle row, so set the 0th column
            else
            {
                board[y][0] = piece;
            }
        }

        // Returns the absolute distance between two points across the X axis
        public int GetXDistanceAbs(int x0, int y0, int x1, int y1)
        {
            // If one of the positions are in the middle, their X distance is 0
            if (y0 == 2 || y1 == 2)
            {
                return 0;
            }

            // If any of the ys are in the bottom part, invert x
            if (y0 > 2)
            {
                x0 = 2 - x0;
            }

            if (y1 > 2)
            {
                x1 = 2 - x1;
            }

            // Else return the difference between their X coordinates
            return Math.Abs(x1 - x0);
        }

        // Returns the absolute distance between two points across the Y axis
        public int GetYDistanceAbs(int x0, int y0, int x1, int y1)
        {
            // Simply return the difference between their Y coordinates
            return Math.Abs(y1 - y0);
        }
    }
}
