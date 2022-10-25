using Snake.GameObjects;
using Snake.Utilities;
using SnakeGame.Core;

namespace SnakeGame
{
    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            Wall wall = new Wall(60, 20);
            Snnake snake = new Snnake(wall);
            Engine engine = new Engine(snake, wall);
            engine.Run();
        }
    }
}