namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] table = new int[5, 5];
            Console.Title = "Tic-Tac-Toe Game";
            Console.WindowHeight = 10;
            Console.WindowWidth = 20;
            Console.BufferHeight = 10;
            Console.BufferWidth = 20;
            ///
            while (true)
            {

                Array values = Enum.GetValues(typeof(ConsoleColor));
                Random random = new Random();
                ConsoleColor randomColor = (ConsoleColor)values.GetValue(random.Next(6));
                Console.BackgroundColor = randomColor;
                Console.Clear();
                for (int i = 0; i < table.GetLength(0); i++) // Fills the table with empty chars for easier showing on the console.
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        table[i, j] = ' ';
                    }
                }
                Console.WriteLine();
            }
        }
    }
}