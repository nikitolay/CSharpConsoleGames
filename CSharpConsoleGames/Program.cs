namespace CSharpConsoleGames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Tic-Tac-Toe Game";
            Console.WindowHeight = 10;
            Console.WindowWidth = 20;
            Console.BufferHeight = 10;
            Console.BufferWidth = 20;

            Array values = Enum.GetValues(typeof(ConsoleColor));
            Random random = new Random();
            ConsoleColor randomColor = (ConsoleColor)values.GetValue(random.Next(6));
            Console.BackgroundColor = randomColor;
        }
    }
}