using SudokuBoard;

namespace SudokuSolutionValidator
{
    public class BoardValidatorTests
    {
        [Fact]
        public void Test_Board_Validate_Positive()
        {
            var s = new [,]
               {{ 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }};
            IBoardValidator sudokuBoardVal = new BoardValidator(s);
            Assert.True(sudokuBoardVal.ValidateBoard(), "This board is not valid");
        }

        [Fact]
        public void Test_Board_Validate_Negative()
        {
            var s = new [,]
               {{ 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                { 8, 5, 9, 6, 6, 1, 4, 2, 3 },
                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                { 2, 8, 7, 5, 1, 9, 6, 3, 5 },
                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }};
            IBoardValidator sudokuBoardVal = new BoardValidator(s);
            Assert.False(sudokuBoardVal.ValidateBoard(), "This board should be not valid");
        }

        [Fact]
        public void Test_Board_GetRow()
        {
            var s = new[,]
            {{ 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }};
            IBoardValidator sudokuBoardVal = new BoardValidator(s);
            Assert.Equal(sudokuBoardVal.GetRow(0), new int[] { 5, 3, 4, 6, 7, 8, 9, 1, 2 });
            Assert.Throws<ArgumentOutOfRangeException>(() => sudokuBoardVal.GetRow(10));
            Assert.Throws<ArgumentOutOfRangeException>(() => sudokuBoardVal.GetRow(-6));
        }

        [Fact]
        public void Test_Board_GetColumn()
        {
            var s = new[,]
               {{ 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }};
            IBoardValidator sudokuBoardVal = new BoardValidator(s);
            Assert.Equal(sudokuBoardVal.GetColumn(8), new int[] { 2, 8, 7, 3, 1, 6, 4, 5, 9 });
            Assert.Throws<ArgumentOutOfRangeException>(() => sudokuBoardVal.GetColumn(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => sudokuBoardVal.GetColumn(15));
        }

        [Fact]
        public void Test_Board_GetSubGridValues()
        {
            var s = new[,]
               {{ 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }};

            IBoardValidator sudokuBoardVal = new BoardValidator(s);
            var expectedSubgrid = new[] { 7, 6, 1, 8, 5, 3, 9, 2, 4 };
            var subgrid = sudokuBoardVal.GetSubGridValues((1, 1));

            Assert.True(!expectedSubgrid.Except(subgrid).Any() || !subgrid.Except(expectedSubgrid).Any());
            Assert.Throws<ArgumentOutOfRangeException>(() => sudokuBoardVal.GetSubGridValues((10, 1)));
            Assert.Throws<ArgumentOutOfRangeException>(() => sudokuBoardVal.GetSubGridValues((2, 5)));
            Assert.Throws<ArgumentOutOfRangeException>(() => sudokuBoardVal.GetSubGridValues((-1, -1)));
        }
    }
}