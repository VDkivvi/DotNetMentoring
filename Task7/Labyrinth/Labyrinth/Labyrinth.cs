using System.Data;

namespace Labyrinth;

public class Labyrinth : ILabyrinth
{
    private readonly int _rows;
    private readonly int _columns;
    private readonly char[] _availableChars = { 's', 'e', '*', '-' };

    private readonly char[,] _labyrinth;
    public readonly Point[,] labyrinthPoints;

    public Labyrinth(char[,] data)
    {
        _labyrinth = data;
        _rows = data.GetLength(0);
        _columns = data.GetLength(1);
        Validate();

        labyrinthPoints = new Point[_rows, _columns];
        for (var i = 0; i < _rows; i++)
            for (var j = 0; j < _columns; j++)
                labyrinthPoints[i, j] = new Point((i, j)) { Value = _labyrinth[i, j] };
    }

    public (int row, int column) FindCharPosition(char ch)
    {
        for (var i = 0; i < _rows; i++)
            for (var j = 0; j < _columns; j++)
                if (_labyrinth[i, j] == ch)
                    return (i, j);
        return (-1, -1);
    }

    public List<char> GetPathToTheEnd()
    {
        var start = FindStart();
        var fromStartPoint = new Point(start) { StartPoint = true };

        var list = new List<char>();
        var result = SearchPath(fromStartPoint, new List<char>());
        if (result.result)
        {
            result.path.Reverse();
            list.Add('S');
            list.AddRange(result.path);
            list.Add('E');
            return list;
        }
        throw new ApplicationException("No solution found");
    }

    public Dictionary<char, Point?> DiscoverTheNeighborhood(Point p)
    {
        return new Dictionary<char, Point?>
        {
            { 'U', p.Row != 0 ? labyrinthPoints[p.Row - 1, p.Column] : null },
            { 'D', p.Row != _rows - 1 ? labyrinthPoints[p.Row + 1, p.Column] : null },
            { 'L', p.Column != 0 ? labyrinthPoints[p.Row, p.Column - 1] : null },
            { 'R', p.Column != _columns - 1 ? labyrinthPoints[p.Row, p.Column + 1] : null }
        };
    }

    private (int row, int column) FindStart()
    {
        var coords = FindCharPosition('s');
        labyrinthPoints[coords.row, coords.column].Visited = true;
        labyrinthPoints[coords.row, coords.column].StartPoint = true;
        return coords;
    }

    private bool IsWalkable(Point node) => node is not null && node.Visited != true && node.Value != '*' && node.Value != 's';

    private Dictionary<char, Point> GetAdjacentWalkableNodes(Point fromNode)
    {
        var nextLocations = DiscoverTheNeighborhood(fromNode);

        var walkableNodes = new Dictionary<char, Point>();
        var filteredNodes = nextLocations.Where( x => IsWalkable(x.Value)).ToList();

        if (!filteredNodes.Any())
            return walkableNodes;

        filteredNodes.ForEach(next =>
        {
            next.Value.ParentNode = fromNode;
            walkableNodes.Add(next.Key, next.Value);
        });

        return walkableNodes;
    }

    private (List<char> path, bool result) SearchPath(Point currentNode, List<char> pathlist)
    {
        currentNode.Visited = true;
        var nextNodes = GetAdjacentWalkableNodes(currentNode);

        //TODO: sort walkable nodes by 'weight'.
        foreach (var nextNode in nextNodes)
        {
            if (nextNode.Value.Value == 'e')
            {
                pathlist.Add(nextNode.Key);
                return (pathlist, true);
            }

            if (!SearchPath(nextNode.Value, pathlist).result) continue;
            pathlist.Add(nextNode.Key);
            return (pathlist, true);
        }
        return (pathlist, false);
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