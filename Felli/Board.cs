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
    }
}
