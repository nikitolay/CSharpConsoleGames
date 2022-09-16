
using System;

namespace Tic_Tac_Toe.Tests
{
    public class TicTacToeTests
    {
        static char[,] table =
             {
                { ' ',' ',' ',' ',' '}
                ,
                { ' ','X',' ',' ',' '}
            };

        [Fact]
        public void TestMatrixInitializationInConstructor()
        {
            TicTacToe game = new TicTacToe();
            Assert.NotNull(game.Table);
        }

        [Theory]
        [InlineData('X', 0, 1)]
        [InlineData('X', 0, 2)]
        [InlineData('X', 0, 3)]
        [InlineData('X', 1, 1)]
        [InlineData('X', 1, 2)]
        [InlineData('X', 1, 3)]
        [InlineData('X', 2, 1)]
        [InlineData('X', 2, 2)]
        [InlineData('X', 2, 3)]
        [InlineData('X', 3, 1)]
        [InlineData('X', 3, 2)]
        [InlineData('X', 3, 3)]

        [InlineData('О', 0, 1)]
        [InlineData('О', 0, 2)]
        [InlineData('О', 0, 3)]
        [InlineData('О', 1, 1)]
        [InlineData('О', 1, 2)]
        [InlineData('О', 1, 3)]
        [InlineData('О', 2, 1)]
        [InlineData('О', 2, 2)]
        [InlineData('О', 2, 3)]
        [InlineData('О', 3, 1)]
        [InlineData('О', 3, 2)]
        [InlineData('О', 3, 3)]
        public void MethodShouldReturnTrueIfTheSeatIsOccupied(char symbol, int row, int col)
        {//da dobavq oshte case-ove tuk
            TicTacToe game = new TicTacToe();
            char[,] table =
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
            table[row, col] = symbol;
            bool isOccupied = game.CheckingIfTheSeatIsOccupied(table, row, col);
            Assert.True(isOccupied);
        }

    }
}