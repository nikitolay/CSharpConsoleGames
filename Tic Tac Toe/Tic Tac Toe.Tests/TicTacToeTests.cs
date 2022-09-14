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

    }
}