
namespace Tic_Tac_Toe.Tests
{
    public class TicTacToeTests
    {
        char[,] table;
        TicTacToe game;
        public TicTacToeTests()
        {
            game = new TicTacToe();
            table = new char[5, 5];
        }

        [Fact]
        public void TestMatrixInitializationInConstructor()
        {
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
        {

            table[row, col] = symbol;
            bool isOccupied = game.CheckingIfTheSeatIsOccupied(table, row, col);
            Assert.True(isOccupied);
        }


        [Theory]
        [InlineData(1, 'X')]
        [InlineData(2, 'О')]
        public void TheMethodChecksIfThePlayerTurnIsChangedCorrectly(int movesPLayed, char expectedSymbol)
        {
            char playerTurn = game.CheckPlayerTurn(movesPLayed);
            Assert.Equal(expectedSymbol, playerTurn);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(0, 4)]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 0)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(3, 0)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        [InlineData(4, 0)]
        [InlineData(4, 1)]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        public void ChecksIfTheTableIsFilledWithEmptyCharacters(int row, int col)
        {
            game.FillsTheTableWithEmptyChars(table);
            Assert.Equal(' ', table[row, col]);
        }

        [Theory]
        [InlineData('↓',0,1)]
        [InlineData('→', 1,0)]
        public void hg(char symbol,int row,int col)
        {
            game.ResetArrows(table);
            Assert.Equal(symbol, table[row, col]);
        }
    }
}