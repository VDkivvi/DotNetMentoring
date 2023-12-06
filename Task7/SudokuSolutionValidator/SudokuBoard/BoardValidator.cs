namespace SudokuBoard
{
    public class BoardValidator: IBoardValidator
    {
        private readonly int[,] board;

        public BoardValidator(int[,] board)
        {
            this.board = board;
        }

        public bool ValidateBoard()
        {
            var template = Enumerable.Range(1,9).ToArray();
            if (board.GetLength(0) != 9 || board.GetLength(1) != 9)
                throw new ArgumentException("Wrong number of rows for board");

            for (var i = 0; i < 9; i++)
            {
                var columns = GetColumn(i).OrderBy(x=>x).ToArray();
                var rows = GetRow(i).OrderBy(x => x).ToArray();
                var square = GetSubGridValues((i / 3, i % 3)).OrderBy(x => x).ToArray();

                if (!columns.SequenceEqual(template) || !rows.SequenceEqual(template) || !square.SequenceEqual(template))
                    return false;
            }
            return true;
        }

        public int[] GetRow(int rowIndex)
        {
            if (rowIndex > 8 || rowIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(rowIndex));
            var rowLength = board.GetLength(1);
            var row = new int[9];
            for (var i = 0; i < rowLength; i++)
            {
                row[i] = board[rowIndex, i];
            }
            return row;
        }

        public int[] GetColumn(int colIndex)
        {
            if (colIndex > 8 || colIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(colIndex));
            var column = new int[9];
            for (var i = 0; i < 9; i++)
            {
                column[i] = board[i, colIndex];
            }
            return column;
        }


        public int[] GetSubGridValues((int row, int col) subGridOrder)
        {
            if (subGridOrder.row > 3 || subGridOrder.col > 3 || subGridOrder.row < 0 || subGridOrder.col < 0)
                throw new ArgumentOutOfRangeException(nameof(subGridOrder));

            var column = new int[9];
            var rowPos = subGridOrder.row / 3 * 3;
            var colPos = subGridOrder.col / 3 * 3;
            var ind = 0;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    column[ind] = board[rowPos + i, colPos + j];
                    ind++;
                }
            }
            return column;
        }
    }
}