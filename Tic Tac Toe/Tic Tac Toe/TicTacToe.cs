
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Tic Tac Toe.Tests")]

namespace Tic_Tac_Toe
{
    public class TicTacToe
    {
        private readonly char[,] table;
        private const int rightArrowCol = 0, downArrowRow = 0;
        private int movesPlayed = 0;
        private Random randomPlayer;
        private int firstPlayer;
        private char playerTurnSymbol;
        private int playerTurnDigit;
        private int row = 1;
        private int col = 1;
        private int isThereWinner;
        public TicTacToe()
        {
            table = new char[5, 5];
            randomPlayer = new Random();
        }
        public int Table => table.GetLength(0);
        private void ConsoleFormat()
        {
            Console.Title = "Tic-Tac-Toe Game ❤";
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowHeight = 10;
            Console.WindowWidth = 20;
            Console.BufferHeight = 10;
            Console.BufferWidth = 20;
        }
        private ConsoleColor RandomConsoleColor()
        {
            Array values = Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)values.GetValue(random.Next(6));
            return randomColor;
        }
        public void Start()
        {
            ConsoleFormat();
            while (true)
            {
                ConsoleColor randomColor = RandomConsoleColor();
                Console.BackgroundColor = randomColor;
                Console.Clear();
                FillsTheTableWithEmptyChars(table);
                movesPlayed = 0;
                firstPlayer = randomPlayer.Next(0, 2);
                playerTurnDigit= firstPlayer;
                playerTurnSymbol = ' ';

                while (true)
                {
                    playerTurnSymbol = CheckPlayerTurn(playerTurnDigit);
                    row = 1;
                    col = 1;
                    ResetArrows(table);

                    while (true)
                    {
                        PrintWhichPlayerIsTurn(movesPlayed, playerTurnSymbol);

                        DrawBoard(table);
                        ConsoleKeyInfo command = Console.ReadKey();
                        int ArrowsMovedSuccessfully = MoveArrows(table, command, ref row, ref col);
                        if (ArrowsMovedSuccessfully == 1)
                        {
                            break;
                        }
                        else if (ArrowsMovedSuccessfully == -1)
                        {
                            return;
                        }
                        Console.Clear();
                    }
                    bool IsTakenTheSelectedSeat = CheckingIfTheSeatIsOccupied(table, row, col);
                    if (IsTakenTheSelectedSeat)
                    {
                        Console.SetCursorPosition(1, 6);
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Тhe seat is already taken!");
                        Console.BackgroundColor = randomColor;
                        continue;
                    }


                    movesPlayed++;
                    playerTurnDigit++;
                    table[row, col] = playerTurnSymbol;
                    isThereWinner = WinnerCheck(table);
                    Console.Clear();
                    DrawBoard(table);
                    if (isThereWinner == 1|| isThereWinner == -1)
                    {
                        Console.SetCursorPosition(3, 5);
                        Console.WriteLine($"Player '{playerTurnSymbol}' won!");
                        break;
                    }
                    else if (movesPlayed == 9)
                    {
                        Console.SetCursorPosition(8, 5);
                        Console.WriteLine("Draw!");
                        break;
                    }

                }
                Console.SetCursorPosition(7, 6);
                Console.WriteLine("Rematch?");
                if (movesPlayed == 9)
                {
                    Console.SetCursorPosition(3, 7);
                    Console.WriteLine("Press 'Enter' for rematch");
                }
                ConsoleKeyInfo clientResponse = Console.ReadKey();
                if (clientResponse.Key == ConsoleKey.Enter)
                {
                    continue;
                }
                else
                {
                    return;
                }
            }
        }

        internal bool CheckingIfTheSeatIsOccupied(char[,] table, int row, int col)
        {
            return table[row, col] == 'X' || table[row, col] == 'О';
        }

        private int MoveArrows(char[,] table, ConsoleKeyInfo command, ref int row, ref int col)
        {

            if (command.Key == ConsoleKey.UpArrow && IsInside(row - 1))
            {
                table[row, rightArrowCol] = ' ';
                row--;
                table[row, rightArrowCol] = '→';

            }
            else if (command.Key == ConsoleKey.DownArrow && IsInside(row + 1))
            {
                table[row, rightArrowCol] = ' ';
                row++;
                table[row, rightArrowCol] = '→';
            }
            else if (command.Key == ConsoleKey.LeftArrow && IsInside(col - 1))
            {
                table[downArrowRow, col] = ' ';
                col--;
                table[downArrowRow, col] = '↓';
            }
            else if (command.Key == ConsoleKey.RightArrow && IsInside(col + 1))
            {
                table[downArrowRow, col] = ' ';
                col++;
                table[downArrowRow, col] = '↓';
            }
            else if (command.Key == ConsoleKey.Enter)
            {
                return 1;

            }
            else if (command.Key == ConsoleKey.Escape)
            {
                return -1;
            }
            return 0;
        }

        private void PrintWhichPlayerIsTurn(int movesPlayed, char playerTurn)
        {
            Console.SetCursorPosition(1, 5);
            if (movesPlayed < 1)
            {
                Console.WriteLine($"First player is '{playerTurn}'");
            }
            else
            {
                Console.SetCursorPosition(2, 5);
                Console.WriteLine($"Player's '{playerTurn}' turn");
            }
        }

        internal char CheckPlayerTurn(int firstPlayer)
        {
            if (firstPlayer % 2 == 0)
            {
                playerTurnSymbol = 'О';
            }
            else
            {
                playerTurnSymbol = 'X';
            }
            return playerTurnSymbol;
        }

        internal void FillsTheTableWithEmptyChars(char[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++) // Fills the table with empty chars for easier showing on the console.
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = ' ';
                }
            }
        }
        private void DrawBoard(char[,] table)
        {

            Console.SetCursorPosition(6, 0);
            Console.WriteLine($"{table[0, 1]}   {table[0, 2]}   {table[0, 3]}");
            Console.SetCursorPosition(2, 1);
            Console.WriteLine($"{table[1, 0]} | {table[1, 1]} | {table[1, 2]} | {table[1, 3]} |");
            Console.SetCursorPosition(2, 2);

            Console.WriteLine($"{table[2, 0]} | {table[2, 1]} | {table[2, 2]} | {table[2, 3]} |");
            Console.SetCursorPosition(2, 3);

            Console.WriteLine($"{table[3, 0]} | {table[3, 1]} | {table[3, 2]} | {table[3, 3]} |");
        }
        internal void ResetArrows(char[,] table)
        {
            table[0, 1] = '↓';
            table[0, 2] = ' ';
            table[0, 3] = ' ';

            table[1, 0] = '→';
            table[2, 0] = ' ';
            table[3, 0] = ' ';

        }
        internal bool IsInside(int number)
        {
            return number >= 1 && number <= 3;
        }
        internal int WinnerCheck(char[,] table)
        {
            //Horizontal check if 'X' wins
            if (table[1, 1] == 'X' && table[1, 2] == 'X' && table[1, 3] == 'X')
            {
                return 1;
            }
            else if (table[2, 1] == 'X' && table[2, 2] == 'X' && table[2, 3] == 'X')
            {
                return 1;
            }
            else if (table[3, 1] == 'X' && table[3, 2] == 'X' && table[3, 3] == 'X')
            {
                return 1;
            }
            //Vertical check if 'X' wins
            if (table[1, 1] == 'X' && table[2, 1] == 'X' && table[3, 1] == 'X')
            {
                return 1;
            }
            else if (table[1, 2] == 'X' && table[2, 2] == 'X' && table[3, 2] == 'X')
            {
                return 1;
            }
            else if (table[1, 3] == 'X' && table[2, 3] == 'X' && table[3, 3] == 'X')
            {
                return 1;
            }
            //Тhe two diagonals check if 'X' wins
            else if (table[1, 1] == 'X' && table[2, 2] == 'X' && table[3, 3] == 'X')
            {
                return 1;
            }
            else if (table[1, 3] == 'X' && table[2, 2] == 'X' && table[3, 1] == 'X')
            {
                return 1;
            }

            //Horizontal check if 'О' wins
            if (table[1, 1] == 'О' && table[1, 2] == 'О' && table[1, 3] == 'О')
            {
                return -1;
            }
            else if (table[2, 1] == 'О' && table[2, 2] == 'О' && table[2, 3] == 'О')
            {
                return -1;
            }
            else if (table[3, 1] == 'О' && table[3, 2] == 'О' && table[3, 3] == 'О')
            {
                return -1;
            }
            //Vertical check if 'О' wins
            if (table[1, 1] == 'О' && table[2, 1] == 'О' && table[3, 1] == 'О')
            {
                return -1;
            }
            else if (table[1, 2] == 'О' && table[2, 2] == 'О' && table[3, 2] == 'О')
            {
                return -1;
            }
            else if (table[1, 3] == 'О' && table[2, 3] == 'О' && table[3, 3] == 'О')
            {
                return -1;
            }
            //Тhe two diagonals check if 'О' wins
            else if (table[1, 1] == 'О' && table[2, 2] == 'О' && table[3, 3] == 'О')
            {
                return -1;
            }
            else if (table[1, 3] == 'О' && table[2, 2] == 'О' && table[3, 1] == 'О')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}

