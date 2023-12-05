namespace Labyrinth.Tests
{
    [TestClass]
    public class LabyrinthTests
    {

        [TestMethod]
        public void Labyrinth_Validate_Rows()
        {
            var l = new char[,] {{ '*', 's', '*', '-', 'e', '*' },};
            _ = Assert.ThrowsException<ArgumentException>(() => { new Labyrinth(l); });
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
    }
}