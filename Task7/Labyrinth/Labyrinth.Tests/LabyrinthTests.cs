namespace Labyrinth.Tests
{
    [TestClass]
    public class LabyrinthTests
    {

        [TestMethod]
        public void Labyrinth_Validate_Rows()
        {
            var l = new char[,] {{ '*', 's', '*', '-', 'e', '*' },};
            _ = Assert.ThrowsException<ArgumentException>(() => { _ = new Labyrinth(l); });
        }

        [TestMethod]
        public void Labyrinth_Validate_Cols()
        {
            var l = new char[,]
               {{ '*' },
                { 's' },
                { '*' },
                { '-' },
                { '*' },
                { 'e' },
                { '*' }};
            Assert.ThrowsException<ArgumentException>(() => { new Labyrinth(l); });
        }

        [TestMethod]
        public void Labyrinth_Validate_Start()
        {
            var l = new char[,]
            {{ '*', '*', '*', '*', 'e', '*' },
             { '*', '-', '*', '*', '-', '*' },
             { '*', '-', '-', '*', '*', '*' },};
            Assert.ThrowsException<ApplicationException>(() => { new Labyrinth(l); });
        }

        [TestMethod]
        public void Labyrinth_Validate_End()
        {
            var l = new char[,]
            {{ '*', '*', '*', '*', '-', '*' },
             { '*', '-', '*', '*', '-', '*' },
             { '*', '-', '-', '*', 's', '*' },};
            Assert.ThrowsException<ApplicationException>(() => { new Labyrinth(l); });
        }

        [TestMethod]
        public void Labyrinth_Validate_Wrong_Symbols()
        {
            var l = new char[,]
            {{ '*', 'e', '*', '*', '-', '*' },
             { '*', '-', '*', 'i', '-', '*' },
             { '*', '-', '-', '*', 's', '*' },};
            Assert.ThrowsException<ApplicationException>(() => { new Labyrinth(l); });
        }

        [TestMethod]
        public void Labyrinth_Validate_Several_Starts()
        {
            var l = new char[,]
            {{ '*', 's', '*', '*', '-', '*' },
             { '*', '-', '*', '-', '-', '*' },
             { '*', '-', '-', '*', 's', 'e' },};
            Assert.ThrowsException<ApplicationException>(() => { new Labyrinth(l); });
        }

        [TestMethod]
        public void Labyrinth_Validate_Several_Ends()
        {
            var l = new char[,]
            {{ '*', 'e', '*', '*', '-', '*' },
             { '*', '-', '*', '-', '-', '*' },
             { '*', '-', '-', '*', 's', 'e' },};
            Assert.ThrowsException<ApplicationException>(() => { new Labyrinth(l); });
        }


        [DataTestMethod]
        [DataRow('s', 2, 1)]
        [DataRow('-', 1, 1)]
        [DataRow('q', -1, -1)]
        public void Labyrinth_FindCharPosition(char ch, int row, int column)
        {
            var l = new char[,]
            {
                { '*', '*', '*', '*', '*', '*' },
                { '*', '-', '*', '*', '-', '*' },
                { '*', 's', '-', '*', '*', '*' },
                { '*', '*', '-', '*', '*', '*' },
                { '*', '-', '-', '*', '*', '*' },
                { '*', '-', '*', '*', '-', '*' },
                { '*', '-', '-', '-', '-', '*' },
                { '*', '*', '-', '-', 'e', '*' },
                { '*', '*', '*', '*', '*', '*' },
                { '*', '*', '*', '*', '*', '*' }};
            var lab = new Labyrinth(l);
            Assert.AreEqual(lab.FindCharPosition(ch), (row, column));
        }

        [TestMethod]
        public void Labyrinth_DiscoverTheNeighborhood()
        {
            var l = new char[,]
            {
                { '*', '*', '*', '*', '*', '*' },
                { '*', '-', '*', '*', '-', '*' },
                { '*', 's', '-', '*', '*', '*' },
                { '*', '*', '-', '*', '*', '*' },
                { '*', '-', '-', '*', '*', '*' },
                { '*', '-', '*', '*', '-', '*' },
                { '*', '-', '-', '-', '-', '*' },
                { '*', '*', '-', '-', 'e', '*' },
                { '*', '*', '*', '*', '*', '*' },
                { '*', '*', '*', '*', '*', '*' }};
            var lab = new Labyrinth(l);
            var grid = lab.labyrinthPoints;

            Assert.IsTrue(IsEqual(
                lab.DiscoverTheNeighborhood(new Point((2, 1))),
                new Dictionary<char, Point?> {
                    {'U', grid[1, 1] },
                    {'D', grid[3, 1] },
                    {'R', grid[2, 2] },
                    {'L', grid[2, 0] } }));
            Assert.IsTrue(IsEqual(lab.DiscoverTheNeighborhood(new Point((0, 0))),
                new Dictionary<char, Point?> {
                    {'U', null },
                    {'D', grid[1, 0] },
                    {'R', grid[0, 1] },
                    {'L', null } }));

            Assert.IsTrue(IsEqual(lab.DiscoverTheNeighborhood(new Point((9, 5))),
                new Dictionary<char, Point?> {
                    {'U', grid[8, 5] },
                    {'D', null },
                    {'R', null },
                    {'L', grid[9, 4] } }));
        }

        static bool IsEqual(Dictionary<char, Point?> a1, Dictionary<char, Point?> a2) 
            => a1.Count == a2.Count
                && a1.All(kvp => a2.TryGetValue(kvp.Key, out var value)
                && kvp.Value == value);


        [TestMethod]
        public void Labyrinth_GetPathToTheEnd()
        {
            var l = new char[,]
            {
                { '*', 's', '*', '*', '*', '*' },
                { '*', '-', '*', '*', '-', '*' },
                { '*', '-', '*', '*', '-', '*' },
                { '*', '-', '-', '*', '-', '-' },
                { '*', '*', '-', '*', '*', '-' },
                { '*', '*', '-', '*', '*', '*' },
                { '*', '*', '-', '-', '-', '*' },
                { '*', '*', '*', '*', 'e', '*' },
                { '*', '*', '*', '*', '-', '*' },
                { '*', '*', '*', '*', '-', '*' }};
            var lab = new Labyrinth(l);
            var solvedPath = lab.GetPathToTheEnd();
            Assert.IsTrue(possibleSolutions.Any(path => path.SequenceEqual(solvedPath)));
        }

        List<List<char>> possibleSolutions = new()
        {
             new List<char> { 'S', 'D', 'D', 'D', 'R', 'D', 'D', 'D', 'R', 'R', 'D', 'E' },
             //etc. until the mechanism of choosing the optimal path is added
        };


        [TestMethod]
        public void Labyrinth_GetPathToTheEnd_NoPath()
        {
            var l = new char[,]
            {
                { '*', 's', '*', '*', '*', '*' },
                { '*', '-', '*', '*', '-', '*' },
                { '*', '*', '*', '*', '*', '*' },
                { '*', '-', '-', '*', '*', '*' },
                { '*', '*', '-', '*', '*', '*' },
                { '*', '*', '-', '*', '-', '*' },
                { '*', '*', '-', '-', '-', '*' },
                { '*', '*', '-', '-', 'e', '*' },
                { '*', '*', '*', '*', '*', '*' },
                { '*', '*', '*', '*', '*', '*' }};
            var lab = new Labyrinth(l);
            Assert.ThrowsException<ApplicationException>(() => { lab.GetPathToTheEnd(); });
        }
    }
}