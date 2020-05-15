using System;
using System.Collections.Generic;
using System.Text;

namespace Felli
{
	// Board class, performs all turns and gets user input.
	class Board
	{
		public const int Empty = UnravelledBoard.Empty;
		public const int White = UnravelledBoard.White;
		public const int Black = UnravelledBoard.Black;

		// The unravelled board.
		UnravelledBoard board;

		// Board constructor.
		public Board()
		{
			// Create a new standard board.
			board = new UnravelledBoard();
		}

		// Checks if this board has any pieces of type 'piece'.
		public bool ExistsPieces(int piece)
		{
			// For each row.
			for (int y = 0; y < 5; y++)
			{
				// For each column.
				for (int x = 0; x < 3; x++)
				{
					// If the piece at 'x, y' is it, return true
					if (board.GetPiece(x, y) == piece)
					{
						return true;
					}
				}
			}

			// Else we don't have any pieces of those.
			return false;
		}

		// Converts a piece to it's character
		private static char PieceChar(int piece)
		{
			if (piece == Black)
			{
				return 'B';
			}
			else if (piece == White)
			{
				return 'W';
			}
			else
			{
				return '▫';
			}
		}

		// Converts a piece to it's name.
		private static string PieceName(int piece)
		{
			if (piece == Black)
			{
				return "Black";
			}
			else
			{
				return "White";
			}
		}

		// Returns the piece of the opposite team
		public static int PieceOppositeTeam(int piece)
		{
			if (piece == Black)
			{
				return White;
			}
			else
			{
				return Black;
			}
		}

		// Prints the board.
		public void Display()
		{
			//Write instructions.
			Console.WriteLine("\nFelli\n\n* Instructions *\n\nPrepare game:" +
				" Choose between the white(W) and black(B) pieces to play." +
				"\n              Decide which player starts the game. \n\n" +
				"Start game: Starting player picks a piece to move, knowing" +
				" only one piece can be moved at a turn.\n            To " +
				"pick a piece, select the coordinates(x, y) of that piece." +
				"\n            If the player decides to change the piece " +
				"he wants to move, press 'q' or 'Q', to select other piece." +
				"\n            After picking a piece, the player selects the" +
				" coordinates (x, y) of the house where to move the piece." +
				"\n\nPossible moves: The pice can be moved to an adjacent " +
				"free house, following the lines of the board.\n           " +
				"     Jump over an adjacent enemy piece, " +
				"landing at the next free house, eliminating the opponents" +
				" piece.\n                The player can only eliminate one " +
				"piece at a time.\n\nFinish game: When a player has " +
				"captured all of the enemy pieces..\n\n");

			// Write all xs.
			Console.WriteLine("  1 2 3 4 5");

			// Write the top line of the board box.
			Console.WriteLine(" ┌─────────┐");

			// Write all rows.
			for (int y = 0; y < 5; y++)
			{
				// Write the current y and left column.
				Console.Write(y + 1);
				Console.Write("│");

				// Write each column.
				for (int x = 0; x < 3; x++)
				{
					// Pad 1 space in between each piece.
					if (x != 0)
					{
						Console.Write(" ");
						// If this is the top or bottom, pad 2 more in the 
						//middle.
						if (y == 0 || y == 4)
						{
							Console.Write("  ");
						}
					}

					// If we're in the inner rows, pad the start.
					if ((y == 1 || y == 3) && x == 0)
					{
						Console.Write("  ");
					}

					// If we're not in the middle row or this is the middle of 
					//the middle row.
					if (y != 2 || (y == 2 && x == 1))
					{
						Console.Write(PieceChar(board.GetPiece(x, y)));
					}

					// Else just pad some spaces.
					else
					{
						Console.Write("   ");
					}

					// If we're in the inner rows, pad the end.
					if ((y == 1 || y == 3) && x == 2)
					{
						Console.Write("  ");
					}
				}

				// Write the right column.
				Console.WriteLine("│");
			}

			// Write the bottom line of the board box.
			Console.WriteLine(" └─────────┘");
		}

		// Processes a player's turn with color 'piece'.
		public void DoPieceTurn(int piece)
		{
			Console.WriteLine("Choose a piece, {0}!\n", PieceName(piece));

			// Loop while we try to get user input.
			while (true)
			{
				Console.WriteLine("Select an 'X,Y'");

				// Read the line the user entered and split it by commas.
				String[] args = Console.ReadLine().Split(',');

				// If we didn't receive 2 arguments, complain and restart.
				if (args.Length != 2)
				{
					Console.WriteLine("You must enter 2 arguments!");
					continue;
				}

				// Then try to parse both x and y.
				int x, y;
				if (!int.TryParse(args[0], out x))
				{
					Console.WriteLine("x must be int!");
					continue;
				}
				if (!int.TryParse(args[1], out y))
				{
					Console.WriteLine("y must be int!");
					continue;
				}

				// Decrement x and y by 1 to be 0-based.
				x--;
				y--;

				// If it's out of bounds, retry.
				if (y < 0 || y > 4 || x < 0 || x > 4)
				{
					Console.WriteLine("Out of bounds!");
					continue;
				}

				// If the user selected a square without a unit, retry.
				if (((y == 0 || y == 4) && (x == 1 || x == 3)) ||
					((y == 1 || y == 3) && (x == 0 || x == 4)) ||
					(y == 2 && x != 2))
				{
					Console.WriteLine("Not a valid playing position.");
					continue;
				}

				// Then scale x from 0..4 to 0..2
				// 0 & 1 -> 0
				//     2 -> 1
				// 3 & 4 -> 2
				if (x <= 2)
				{ // 0, 1, 2
					x /= 2;
				}
				else
				{ // 3, 4
					x = (x + 1) / 2;
				}

				// If it's not a piece of our color, retry.
				if (board.GetPiece(x, y) != piece)
				{
					Console.WriteLine("Not your piece!");
					continue;
				}

				// Else try to do the piece turn, if it returns 'false' it's 
				//because the user wants another piece.
				if (DoSingularPieceTurn(x, y))
				{
					return;
				}
				else
				{
					Console.WriteLine("Select another piece!");
					continue;
				}
			}
		}

		// Processes a single piece's turn.
		private bool DoSingularPieceTurn(int x, int y)
		{
			Console.WriteLine("\nChoose where to move to.");

			// Loop while we try to get user input.
			while (true)
			{
				Console.WriteLine("\nSelect an 'X, Y' or 'q/Q' to select " +
					"other piece.");

				// Read the line the user entered and split it by commas.
				String[] args = Console.ReadLine().Split(',');

				// If we just received 1 argument and it was 'q' or 'Q',
				// return false.
				if (args.Length == 1 && (args[0] == "q" || args[0] == "Q"))
				{
					return false;
				}

				// If we didn't receive 2 arguments, complain and restart.
				if (args.Length != 2)
				{
					Console.WriteLine("You must enter 2 arguments!");
					continue;
				}

				// Then try to parse both xMove and yMove.
				int xMove, yMove;
				if (!int.TryParse(args[0], out xMove))
				{
					Console.WriteLine("xMove must be int!");
					continue;
				}
				if (!int.TryParse(args[1], out yMove))
				{
					Console.WriteLine("yMove must be int!");
					continue;
				}

				// Decrement x and y by 1 to be 0-based.
				xMove--;
				yMove--;

				// If it's out of bounds, retry.
				if (yMove < 0 || yMove > 4 || xMove < 0 || xMove > 4)
				{
					Console.WriteLine("Out of bounds!");
					continue;
				}

				// If the user selected a square without a unit, retry.
				if (((yMove == 0 || yMove == 4) && (xMove == 1 || xMove == 3))
					|| ((yMove == 1 || yMove == 3) && (xMove == 0 || xMove ==
					4)) || (yMove == 2 && xMove != 2))
				{
					Console.WriteLine("Not a valid playing position.");
					continue;
				}

				// Then scale xMove from 0..4 to 0..2
				// 0 & 1 -> 0
				//     2 -> 1
				// 3 & 4 -> 2
				if (xMove <= 2)
				{ // 0, 1, 2
					xMove /= 2;
				}
				else
				{ // 3, 4
					xMove = (xMove + 1) / 2;
				}

				// And try to move the piece.
				// 'MovePiece' returns 'true' if successful.
				if (MovePiece(x, y, xMove, yMove))
				{
					// Return if we succeeded.
					return true;
				}
				else
				{
					// Else warn and try again.
					Console.WriteLine("Can not move there!");
					continue;
				}
			}
		}

		// Checks if a piece can move to a position.
		private bool CanMovePiece(int x, int y, int xMove, int yMove)
		{
			// If the destination isn't empty, return false.
			if (board.GetPiece(xMove, yMove) != Empty)
			{
				return false;
			}

			// Get the distance we're moving across axis.
			int xDistAbs = board.GetXDistanceAbs(x, y, xMove, yMove);
			int yDistAbs = board.GetYDistanceAbs(x, y, xMove, yMove);

			// If we're moving 1 unit in either x or y only, we can do it.
			if ((xDistAbs == 1 && yDistAbs == 0) || (xDistAbs == 0 && yDistAbs
				== 1))
			{
				return true;
			}

			// If we're moving 2 units in either x or y only, we can do it if
			//the piece in between
			// if of the opposite team.
			if ((xDistAbs == 2 && yDistAbs == 0) || (xDistAbs == 0 && yDistAbs
				== 2))
			{
				// Note: No rounding errors because we know the distance is 
				//either 0 or 2 for each axis.
				return board.GetPiece((xMove + x) / 2, (yMove + y) / 2) ==
					PieceOppositeTeam(board.GetPiece(x, y));
			}

			// If we got here, we can't move.
			return false;
		}

		// Moves a piece to a position, handling removal of other pieces.
		private bool MovePiece(int x, int y, int xMove, int yMove)
		{
			// If we're moving into the middle row, set the xs to be equal.
			if (yMove == 2)
			{
				xMove = x;
			}

			// If we're moving from the middle row, set the xs to be equal
			if (y == 2)
			{
				x = xMove;
			}

			// If it can move there, move it and check for enemies in between.
			if (CanMovePiece(x, y, xMove, yMove))
			{
				// If we moved 2 units, then remove the piece in the middle.
				int xDistAbs = board.GetXDistanceAbs(x, y, xMove, yMove);
				int yDistAbs = board.GetYDistanceAbs(x, y, xMove, yMove);
				if (xDistAbs == 2 || yDistAbs == 2)
				{
					board.SetPiece((xMove + x) / 2, (yMove + y) / 2, Empty);
				}

				// And then move the piece.
				board.SetPiece(xMove, yMove, board.GetPiece(x, y));
				board.SetPiece(x, y, Empty);
				return true;
			}

			// Else return false.
			return false;
		}
	}
}
