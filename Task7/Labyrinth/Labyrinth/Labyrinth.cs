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

}