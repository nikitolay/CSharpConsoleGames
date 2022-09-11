using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class TicTacToe
    {
        private const int rightArrowCol = 0, downArrowRow = 0;
        private char[,] table;
        public TicTacToe()
        {
            Console.Title = "Tic-Tac-Toe Game";
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowHeight = 10;
            Console.WindowWidth = 20;
            Console.BufferHeight = 10;
            Console.BufferWidth = 20;
            table = new char[5, 5];
        }
        ConsoleColor ConsoleColor()
        {
            Array values = Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)values.GetValue(random.Next(6));
            return randomColor;
        }
        void Start()
        {
            while (true)
            {

                Console.BackgroundColor = ConsoleColor();
                Console.Clear();
                FillsTheTableWithEmptyChars();
                int movesPlayed = 0;
                Random randomPlayer = new Random();
                int firstPlayer = randomPlayer.Next(0, 2);
                char playerTurn = ' ';

                while (true)
                {
                    if (firstPlayer % 2 == 0)
                    {
                        playerTurn = 'О';
                    }
                    else
                    {
                        playerTurn = 'X';
                    }
                    int row = 1;
                    int col = 1;
                    ResetArrows(table);



                    while (true)
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

                        DrawBoard(table);
                        ConsoleKeyInfo command = Console.ReadKey();
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
                            break;
                        }
                        else if (command.Key == ConsoleKey.Escape)
                        {
                            return;
                        }
                        Console.Clear();

                    }
                    if (table[row, col] == 'X' || table[row, col] == 'О')
                    {
                        Console.SetCursorPosition(1, 6);
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Тhe seat is already taken!");
                        Console.BackgroundColor = randomColor;
                        continue;
                    }

                    movesPlayed++;
                    table[row, col] = playerTurn;
                    firstPlayer++;
                    int isThereWinner = WinnerCheck(table);
                    Console.Clear();
                    DrawBoard(table);
                    if (isThereWinner == 1)
                    {
                        Console.SetCursorPosition(3, 5);
                        Console.WriteLine($"Player '{playerTurn}' won!");
                        break;
                    }
                    else if (isThereWinner == -1)
                    {
                        Console.SetCursorPosition(3, 5);
                        Console.WriteLine($"Player '{playerTurn}' won!");
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

        private void FillsTheTableWithEmptyChars()
        {
            for (int i = 0; i < table.GetLength(0); i++) // Fills the table with empty chars for easier showing on the console.
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = ' ';
                }
            }
        }
    }
}
}
