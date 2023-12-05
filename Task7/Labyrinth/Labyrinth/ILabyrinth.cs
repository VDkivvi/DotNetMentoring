namespace Labyrinth;

public interface ILabyrinth
{
    (int row, int column) FindCharPosition(char e);

    List<char> GetPathToTheEnd();

    List<Point?> DiscoverTheNeighborhood(Point p);
}