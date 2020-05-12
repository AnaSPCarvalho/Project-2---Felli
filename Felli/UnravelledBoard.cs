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
    }
}
