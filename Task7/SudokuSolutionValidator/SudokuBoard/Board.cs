using System.Collections.Generic;

namespace SudokuBoard
{
    public class Board: IBoard
    {
        public bool IsValidSolution { get; set; }

        public Board(int[,] board)
        {
            IsValidSolution = ValidateBoard(board);
        }

        static bool ValidateBoard(int[,] board)
        {
            var template = Enumerable.Range(0,9).ToArray();
            if (board.GetLength(0) != 9 || board.GetLength(1) != 9)
                throw new ArgumentException("Wrong number of rows for board");

            for (var i = 0; i < 9; i++)
            {
                var columns = GetColumn(board, i).OrderBy(x=>x).ToArray();
                var rows = GetRow(board, i).OrderBy(x => x).ToArray();
                var square = GetSubGridValues(board, (i / 3, i % 3)).OrderBy(x => x).ToArray();
                if (columns != template || rows != template || square != template)
                {
                    return false;
                }
            }
            return true;
        }

        public static T[] GetRow<T>(T[,] array, int rowIndex)
        {
            var rowLength = array.GetLength(1);
            var row = new T[9];
            for (var i = 0; i < rowLength; i++)
            {
                row[i] = array[rowIndex, i];
            }
            return row;
        }

        public static T[] GetColumn<T>(T[,] array, int colIndex)
        {
            var column = new T[9];
            for (var i = 0; i < 9; i++)
            {
                column[i] = array[i, colIndex];
            }
            return column;
        }


        public static T[] GetSubGridValues<T>(T[,] array, (int row, int col) subGridOrder)
        {
            var column = new T[9];
            var rowPos = subGridOrder.row / 3 * 3;
            var colPos = subGridOrder.col / 3 * 3;
            var ind = 0;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    column[ind] = array[rowPos + i, colPos + j];
                    ind++;
                }
            }
            return column;
        }
    }
}