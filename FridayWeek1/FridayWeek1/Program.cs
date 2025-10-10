using System;
using System.Collections.Generic;

namespace FridayWeek1
{
    internal class Program
    {
        // Constants for room dimensions and characters
        private const int RoomRows = 10;
        private const int RoomCols = 10;
        private const char EmptyChar = '.';
        private const char PlayerChar = 'P';
        private const char WallChar = '#';
        private const char BreadcrumbChar = '*';
        private const char ExitChar = 'E';
        private const int WallCount = 20;

        static void Main(string[] args)
        {
            char[,] room = new char[RoomRows, RoomCols];

            // Initialise each cell to '.' using nested loops
            for (int i = 0; i < RoomRows; i++)
                for (int j = 0; j < RoomCols; j++)
                    room[i, j] = EmptyChar;

            // Add random walls
            Random rnd = new Random();
            int placedWalls = 0;
            while (placedWalls < WallCount)
            {
                int wallRow = rnd.Next(RoomRows);
                int wallCol = rnd.Next(RoomCols);
                if (room[wallRow, wallCol] == EmptyChar)
                {
                    room[wallRow, wallCol] = WallChar;
                    placedWalls++;
                }
            }

            // Pick a random starting position for the player (not inside a wall)
            int playerRow, playerCol;
            do
            {
                playerRow = rnd.Next(RoomRows);
                playerCol = rnd.Next(RoomCols);
            } while (room[playerRow, playerCol] != EmptyChar);

            room[playerRow, playerCol] = PlayerChar;

            // Pick a random exit location (not inside a wall or player)
            int exitRow, exitCol;
            do
            {
                exitRow = rnd.Next(RoomRows);
                exitCol = rnd.Next(RoomCols);
            } while (room[exitRow, exitCol] != EmptyChar || (exitRow == playerRow && exitCol == playerCol));

            room[exitRow, exitCol] = ExitChar;

            // Game loop flag and move counter
            bool gameOver = false;
            int moveCount = 0;

            // Stack to store player positions for undo
            Stack<(int row, int col)> moveHistory = new Stack<(int, int)>();

            while (!gameOver)
            {
                Console.Clear();
                Draw(room);
                Console.WriteLine();
                Console.WriteLine("Press Q to quit.");
                Console.WriteLine("Use W/A/S/D to move up/left/down/right.");
                Console.WriteLine("Press Backspace to undo your last move.");
                Console.WriteLine($"Moves: {moveCount}");

                int oldRow = playerRow;
                int oldCol = playerCol;

                var key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                {
                    gameOver = true;
                }
                else if (key == ConsoleKey.Backspace)
                {
                    // Undo last move
                    if (moveHistory.Count > 0)
                    {
                        // Remove player from current position
                        room[playerRow, playerCol] = BreadcrumbChar;
                        var prev = moveHistory.Pop();
                        playerRow = prev.row;
                        playerCol = prev.col;
                        room[playerRow, playerCol] = PlayerChar;
                        moveCount--;
                    }
                }
                else
                {
                    int newRow = playerRow;
                    int newCol = playerCol;

                    switch (key)
                    {
                        case ConsoleKey.W:
                            if (playerRow > 0) newRow--;
                            break;
                        case ConsoleKey.S:
                            if (playerRow < RoomRows - 1) newRow++;
                            break;
                        case ConsoleKey.A:
                            if (playerCol > 0) newCol--;
                            break;
                        case ConsoleKey.D:
                            if (playerCol < RoomCols - 1) newCol++;
                            break;
                    }

                    // Check if move is allowed (not into a wall, breadcrumb, or out of bounds)
                    if (IsMoveAllowed(room, newRow, newCol))
                    {
                        // If moving to exit, end game
                        if (room[newRow, newCol] == ExitChar)
                        {
                            room[playerRow, playerCol] = BreadcrumbChar;
                            room[newRow, newCol] = PlayerChar;
                            Console.Clear();
                            Draw(room);
                            Console.WriteLine("\nCongratulations! You reached the exit!");
                            Console.WriteLine($"Total moves: {moveCount + 1}");
                            break;
                        }

                        // Leave breadcrumb at old position
                        room[oldRow, oldCol] = BreadcrumbChar;
                        // Store old position for undo
                        moveHistory.Push((oldRow, oldCol));
                        // Move player
                        room[newRow, newCol] = PlayerChar;
                        playerRow = newRow;
                        playerCol = newCol;
                        moveCount++;
                    }
                }
            }
        }

        static void Draw(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(grid[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        // Move is allowed if not a wall, not a breadcrumb, and not out of bounds
        static bool IsMoveAllowed(char[,] grid, int row, int col)
        {
            char cell = grid[row, col];
            return cell != WallChar && cell != BreadcrumbChar;
        }
    }
}