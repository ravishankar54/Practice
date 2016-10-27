using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Position
{
    [TestClass]
    public class DirectionTest
    {

        [TestMethod]
        public void westIsOnLeftOfNorth()
        {
            //Given
            Direction north = new Direction(EnumDirection.N);

            //When
            Direction west = north.TurnLeft();

            //Then
            Assert.AreEqual(EnumDirection.W, west.CurrentFacing);
        }

        [TestMethod]
        public void eastIsOnRightOfNorth()
        {
            //Given
            Direction north = new Direction(EnumDirection.N);

            //When
            Direction east = north.TurnRight();

            //Then
            Assert.AreEqual(EnumDirection.E, east.CurrentFacing);
        }

        [TestMethod]
        public void northIsOnRightOfWest()
        {
            //Given
            Direction west = new Direction(EnumDirection.W);

            //When
            Direction north = west.TurnRight();

            //Then
            Assert.AreEqual(EnumDirection.N, north.CurrentFacing);
        }

        [TestMethod]
        public void southIsOnLeftOfWest()
        {
            //Given
            Direction west = new Direction(EnumDirection.W);

            //When
            Direction south = west.TurnLeft();

            //Then
            Assert.AreEqual(EnumDirection.S, south.CurrentFacing);
        }

        [TestMethod]
        public void eastIsOnLeftOfSouth()
        {
            //Given
            Direction south = new Direction(EnumDirection.S);

            //When
            Direction east = south.TurnLeft();

            //Then
            Assert.AreEqual(EnumDirection.E, east.CurrentFacing);
        }

        [TestMethod]
        public void westIsOnRightOfSouth()
        {
            //Given
            Direction south = new Direction(EnumDirection.S);

            //When
            Direction west = south.TurnRight();

            //Then
            Assert.AreEqual(EnumDirection.W, west.CurrentFacing);
        }

        [TestMethod]
        public void northIsOnLeftOfEast()
        {
            //Given
            Direction east = new Direction(EnumDirection.E);

            //When
            Direction north = east.TurnLeft();

            //Then
            Assert.AreEqual(EnumDirection.N, north.CurrentFacing);
        }

        [TestMethod]
        public void southIsOnRightOfEast()
        {
            //Given
            Direction east = new Direction(EnumDirection.E);

            //When
            Direction south = east.TurnRight();

            //Then
            Assert.AreEqual(EnumDirection.S, south.CurrentFacing);
        }

        [TestMethod]
        public void eastIsOneStepForwardOnXAxis()
        {
            //Given
            Direction east = new Direction(EnumDirection.E);

            //When
            int stepSize = east.StepSizeForXAxis;

            //Then
            Assert.AreEqual(1, stepSize);
        }

        [TestMethod]
        public void eastIsStationaryOnYAxis()
        {
            //Given
            Direction east = new Direction(EnumDirection.E);

            //When
            int stepSize = east.StepSizeForYAxis;

            //Then
            Assert.AreEqual(0, stepSize);
        }

        [TestMethod]
        public void westIsOneStepBackOnXAxis()
        {
            //Given
            Direction west = new Direction(EnumDirection.W);

            //When
            int stepSize = west.StepSizeForXAxis;

            //Then
            Assert.AreEqual(-1, stepSize);
        }

        [TestMethod]
        public void westIsStationaryOnYAxis()
        {
            //Given
            Direction west = new Direction(EnumDirection.W);

            //When
            int stepSize = west.StepSizeForYAxis;

            //Then
            Assert.AreEqual(0, stepSize);
        }

        [TestMethod]
        public void northIsOneStepForwardOnYAxis()
        {
            //Given
            Direction north = new Direction(EnumDirection.N);

            //When
            int stepSize = north.StepSizeForYAxis;

            //Then
            Assert.AreEqual(1, stepSize);
        }

        [TestMethod]
        public void northIsStationaryOnXAxis()
        {
            //Given
            Direction north = new Direction(EnumDirection.N);

            //When
            int stepSize = north.StepSizeForXAxis;

            //Then
            Assert.AreEqual(0, stepSize);
        }

        [TestMethod]
        public void southIsOneStepBackOnYAxis()
        {
            //Given
            Direction south = new Direction(EnumDirection.S);

            //When
            int stepSize = south.StepSizeForYAxis;

            //Then
            Assert.AreEqual(-1, stepSize);
        }

        [TestMethod]
        public void southIsStationaryOnXAxis()
        {
            //Given
            Direction south = new Direction(EnumDirection.S);

            //When
            int stepSize = south.StepSizeForXAxis;

            //Then
            Assert.AreEqual(0, stepSize);
        }
    }
}
