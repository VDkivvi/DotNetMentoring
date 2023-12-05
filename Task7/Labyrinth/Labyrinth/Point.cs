namespace Labyrinth;

public class Point
{
    public int Row;
    public int Column;
    public char Value;
    public Point? ParentNode;
    public bool Visited;
    public bool StartPoint;

    public Point((int row, int column) coords)
    {
        Row = coords.row;
        Column = coords.column;
    }
}