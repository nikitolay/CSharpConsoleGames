using Snake.GameObjects;
using Snake.Utilities;

namespace Snake
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(60, 20);
            Console.ReadKey();
        }
    }
}