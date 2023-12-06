namespace SudokuBoard;

public interface IBoardValidator
{
    bool ValidateBoard();
    int[] GetRow(int rowIndex);
    int[] GetColumn(int colIndex);
    int[] GetSubGridValues((int row, int col) subGridOrder);
}