using System.Data;

namespace Labyrinth;

public class Labyrinth : ILabyrinth
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly char[] _availableChars = { 's', 'e', '*', '-' };

    private readonly char[,] _labyrinth;
    private readonly Point[,] _labyrinthPoints;

    public Labyrinth(char[,] data)
    {
        _labyrinth = data;
        _rows = data.GetLength(0);
        _columns = data.GetLength(1);
        Validate();

        _labyrinthPoints = new Point[_rows, _columns];
        for (var i = 0; i < _rows; i++)
            for (var j = 0; j < _columns; j++)
                _labyrinthPoints[i, j] = new Point((i, j)) { Value = _labyrinth[i, j] };
    }

    public (int row, int column) FindCharPosition(char ch)
    {
        throw new NotImplementedException();
    }

    public List<char> GetPathToTheEnd()
    {
        throw new NotImplementedException();
    }

    public List<Point?> DiscoverTheNeighborhood(Point p)
    {
        throw new NotImplementedException();
    }

    private void Validate()
    {
        var flatten = _labyrinth.Cast<char>();

        if (_labyrinth == null)
            throw new ArgumentNullException(paramName: nameof(_labyrinth));
        if (_rows <= 1 || _columns <= 1)
            throw new ArgumentException("Wrong number of cells. Should be more than 2 rows and columns");
        if (flatten.Distinct().Any(s => Array.IndexOf(_availableChars, s) == -1))
            throw new ApplicationException("The Labyrinth contains not allowed cell values");
        if (!flatten.Distinct().Contains('s') || !flatten.Distinct().Contains('e'))
            throw new ApplicationException("There's no start or end in the labyrinth");
        if (flatten.Where(x => x == 's').Count() > 1 || flatten.Where(x => x == 'e').Count() > 1)
            throw new ApplicationException("There are several starting or ending points in the labyrinth");
    }
}