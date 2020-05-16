# Project-2---Felli

## Authors

* Afonso Teixeira(a21803282)
* Ana Carvalho(a21802128)
* Joana Silva(a21805651)

## Who did what

	Ana Carvalho
	* Board printing and display;
	* Piece characters, turns and movements;
	* Winning condition;
	* XML Documentation;
	* Report;
  
	Afonso Teixeira
	* Start base of the Program.cs script;
	* Pieces starting positions;
	* Color and turn order selection;
	* UML diagram;

	Joana Silva
	* Board printing and display;
	* Instructions;
	* Fix inability to eat pieces on the right side of the board;
	* Flowchart;
	* Report;
	* Doxygen;

   
## Solution architecture

Our solution was to interpret the board in a different way to facilitate
	the work that each class must do to check the player's movements.

The following is how the user sees the board, as reflected in the game's
interface:
```
  │ 1 2 3 4 5
──┼──────────
1 │ A B   C
2 │   D E F
3 │     G
4 │   H I J
5 │ K L   M
```

The following is how the class `Board` interprets the input from the user.
Any invalid squares are immediately rejected when asking for input.
In the code we call these coordinates "normal coordinates".
```
  │ 0 1 2
──┼──────
1 │ A B C
2 │ D E F
3 │   G
4 │ H I J
5 │ K L M
```

The reason we have merged some of the columns is because they don't have any 
	common squares vertically.
The `Board` class uses an `UnravelledBoard` to store the game pieces itself.
	The format that this underlying class uses is the following:
```
  │ 0 1 2
──┼──────
1 │ A B C
2 │ D E F
3 │ G G G
4 │ J I H
5 │ M L K
```

The bottom 2 rows are flipped horizontally and the middle row repeated so that
	all possible movements are either horizontal or vertical.All moves in this
	form can be represented as follows:
```
  │ 0   1   2
──┼──────────
1 │ A───B───C
  │ │   │   │
2 │ D───E───F
  │ │   │   │
3 │ G G   G
  │ │   │   │
4 │ J───I───H
  │ │   │   │
5 │ M───L───K
```

These coordinates are called "unravelled coordinates".
The algorithm to be able to switch between normal and unravelled coordinates is
implemented through all the functions in the class `UnravelledBoard`.


Functions of `Board` use `GetPiece`, `SetPiece`, `GetXDistanceAbs` and 
`GetYDistanceAbs` in order to be able to interact with the board itself, 
as the board member is private.

Most of the functions in `Board` are trivial, as they use the `UnravelledBoard`
	interface to interact with the board.
A non-trivial function is `Display` which, due to the internal representation
	of the board, has a lot of special cases to handle.

## UML Diagram:

![UML Diagram](https://cdn.discordapp.com/attachments/700720830618796102/711036139338858526/Felli_-_Diagrama_UML.png)

## Flowchart

![Flowchart](https://cdn.discordapp.com/attachments/700720830618796102/710975877068095488/Felli_-_Fluxogram.png)

## Referencies

We based most of our implementation from our previous project `Wolf and sheep`,
	thus we didn't use any other sources or references to implement this game.
UTF-8:
* Reused from last project, "Wolf and sheep".
	* [stackoverflow](https://stackoverflow.com/questions/5750203/how-to-write-unicode-characters-to-the-console)
```csharp
Console.OutputEncoding = System.Text.Encoding.UTF8
```