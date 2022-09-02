using System.Security.Cryptography.X509Certificates;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] table = new char[5, 5];
            Console.Title = "Tic-Tac-Toe Game";
            //Console.WindowHeight = 10;
            //Console.WindowWidth = 20;
            //Console.BufferHeight = 10;
            //Console.BufferWidth = 20;
            ///
            //while (true)
            //{

            //Array values = Enum.GetValues(typeof(ConsoleColor));
            //Random random = new Random();
            //ConsoleColor randomColor = (ConsoleColor)values.GetValue(random.Next(6));
            //Console.BackgroundColor = randomColor;
            //Console.Clear();
            for (int i = 0; i < table.GetLength(0); i++) // Fills the table with empty chars for easier showing on the console.
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = ' ';
                }
            }
            //int countPasteSymbols = 0;
            //Random randomPlayer=new Random();
            //int firstPlayer=randomPlayer.Next(0,2);
            //char playerTurn = ' ';
            //if (firstPlayer%2==0)
            //{
            //    playerTurn = 'O';
            //}
            //else
            //{
            //    playerTurn = 'X';
            //}






            ResetArrows(table);
            DrawBoard(table);


            //}
        }
            static void DrawBoard(char[,] table)
            {
            Console.SetCursorPosition(6, 0);
            Console.WriteLine($"{table[0, 1]}  {table[0, 2]}   {table[0,3]} ");
            Console.SetCursorPosition(2, 1);
            Console.WriteLine($"{table[1, 0]} | {table[1, 1]} | {table[1, 2]} | {table[1,3]} |");
            Console.SetCursorPosition(4, 2);

            Console.WriteLine($"| {table[2, 1]} | {table[2, 2]} | {table[2,3]} |");
            Console.SetCursorPosition(4, 3);

            Console.WriteLine($"| {table[3, 1]} | {table[3, 2]} | {table[3,3]} |");
            }
             static void ResetArrows(char[,] table)
             {
            table[0, 1] = '↓';
            table[0, 2] = ' ';
            table[0, 3] = ' ';

            table[1, 0] = '→';
            table[1, 1] = ' ';
            table[1, 2] = ' ';
            
             }
    }
}