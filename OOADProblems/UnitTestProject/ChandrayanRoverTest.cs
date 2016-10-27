using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class ChandrayanRoverTest
    {
        [TestMethod]
        public void canProvideCurrentLocationAsString()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(3, 3);

            //When
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //then
            Assert.AreEqual("3 3 N", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void canRotateLeft()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            chandrayanRover.TurnLeft();

            //then
            Assert.AreEqual("1 2 W", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void canRotateRight()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            chandrayanRover.TurnRight();

            //then
            Assert.AreEqual("1 2 E", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void canMove()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            chandrayanRover.Move();

            //then
            Assert.AreEqual("1 3 N", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void canRunCommandToRotateRight()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            chandrayanRover.Run("R");

            //then
            Assert.AreEqual("1 2 E", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void canRunCommandToRotateLeft()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            chandrayanRover.Run("L");

            //then
            Assert.AreEqual("1 2 W", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void canRunCommandToMove()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            chandrayanRover.Run("M");

            //then
            Assert.AreEqual("1 3 N", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void canRunCommandWithMultipleInstructions()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(3, 3);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.E), startingPosition);

            //When
            chandrayanRover.Run("MMR");
            var location1 = chandrayanRover.CurrentLocation();

            chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.E), startingPosition);
            chandrayanRover.Run("MMRMM");
            var location2 = chandrayanRover.CurrentLocation();

            chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.E), startingPosition);
            chandrayanRover.Run("MMRMMR");
            var location3 = chandrayanRover.CurrentLocation();

            chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.E), startingPosition);
            chandrayanRover.Run("MMRMMRMR");
            var location4 = chandrayanRover.CurrentLocation();

            chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.E), startingPosition);
            chandrayanRover.Run("MMRMMRMRRM");
            var location5 = chandrayanRover.CurrentLocation();

            //then
            Assert.AreEqual("5 1 E", chandrayanRover.CurrentLocation());
        }

        [TestMethod]
        public void wontDriveOffPlateau()
        {
            //Given
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(3, 3);
            ChandrayanRover chandrayanRover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            chandrayanRover.Run("MMMMMMMMMMR");

            //then
            Assert.AreEqual("3 5 E", chandrayanRover.CurrentLocation());
        }
    }
}
