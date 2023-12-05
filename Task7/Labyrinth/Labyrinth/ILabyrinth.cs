namespace Labyrinth;

public interface ILabyrinth
{
    (int row, int column) FindCharPosition(char e);

    List<char> GetPathToTheEnd();

    Dictionary<char, Point?> DiscoverTheNeighborhood(Point p);
}