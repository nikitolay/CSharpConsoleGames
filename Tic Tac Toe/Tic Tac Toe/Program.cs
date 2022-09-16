using System.Text;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        const int rightArrowCol = 0, downArrowRow = 0;
        static void Main(string[] args)
        {
            TicTacToe game = new TicTacToe();
            game.Start();
            char[,] input =
             {
                { ' ',' ',' ',' ',' '}
                ,
                { ' ',' ',' ',' ',' '}
                , 
                { ' ',' ',' ',' ',' '}
                ,
                { ' ',' ',' ',' ',' '}
                ,
                { ' ',' ',' ',' ',' '}
            };

        }
    }
}