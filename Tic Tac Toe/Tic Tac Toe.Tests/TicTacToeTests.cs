
using System;

namespace Tic_Tac_Toe.Tests
{
    public class TicTacToeTests
    {
        [Fact]
        public void TestMatrixInitializationInConstructor()
        {
            TicTacToe game = new TicTacToe();
            Assert.NotNull(game.Table);
        }
        [Fact]
        public void MethodShouldReturnTrueIfTheSeatIsOccupied()
        {
            TicTacToe game = new TicTacToe();
            char[,] table =
            {
                { ' ',' ',' ',' ',' '}
                ,
                { ' ','X',' ',' ',' '}
            };
            int row = 1;
            int col = 1;
            bool isOccupied = game.CheckingIfTheSeatIsOccupied(table, row, col);
            Assert.True(isOccupied);
        }

    }
}