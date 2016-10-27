using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Position
{
    [TestClass]
    public class CoordinateTest
    {
        [TestMethod]
        public void XCoordinatesAreIncrementedForPositiveValue()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(2, 3);

            //When
            boundaryCoordinates = boundaryCoordinates.NewCoordinatesToStart(1, 0);

            //Then
            Assert.AreEqual("3 3", boundaryCoordinates.ToString());
        }

        [TestMethod]
        public void XCoordinatesAreDecrementedForNegativeValue()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(2, 3);

            //When
            boundaryCoordinates = boundaryCoordinates.NewCoordinatesToStart(-1, 0);

            //Then
            Assert.AreEqual("1 3", boundaryCoordinates.ToString());
        }

        [TestMethod]
        public void YCoordinatesAreIncrementedForPositiveValue()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(2, 3);

            //When
            boundaryCoordinates = boundaryCoordinates.NewCoordinatesToStart(0, 1);

            //Then
            Assert.AreEqual("2 4", boundaryCoordinates.ToString());
        }

        [TestMethod]
        public void YCoordinatesAreDecrementedForNegativeValue()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(2, 3);

            //When
            boundaryCoordinates = boundaryCoordinates.NewCoordinatesToStart(0, -1);

            //Then
            Assert.AreEqual("2 2", boundaryCoordinates.ToString());
        }

        [TestMethod]
        public void PointWithXCoordinateWithinBoundaryAreIdentified()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(5, 5);

            //When
            Coordinates internalPoint = new Coordinates(4, 5);

            //Then
            Assert.IsTrue(boundaryCoordinates.HasWithinBounds(internalPoint));
        }


        [TestMethod]
        public void PointWithYCoordinateWithinBoundaryAreIdentified()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(5, 5);

            //When
            Coordinates internalPoint = new Coordinates(5, 4);

            //Then
            Assert.IsTrue(boundaryCoordinates.HasWithinBounds(internalPoint));
        }


        [TestMethod]
        public void PointsWithXCoordinateOutsideBoundaryAreIdentified()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(5, 5);

            //When
            Coordinates externalPoint = new Coordinates(8, 5);

            //Then
            Assert.IsTrue(boundaryCoordinates.HasOutsideBounds(externalPoint));
        }


        [TestMethod]
        public void PointsWithYCoordinateOutsideBoundaryAreIdentified()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(5, 5);

            //When
            Coordinates externalPoint = new Coordinates(5, 8);

            //Then
            Assert.IsTrue(boundaryCoordinates.HasOutsideBounds(externalPoint));
        }

        [TestMethod]
        public void ImmutableCoordinatesAreCreatedForNewStepSize()
        {
            //Given
            Coordinates boundaryCoordinates = new Coordinates(5, 5);

            //When
            Coordinates newBoundary = boundaryCoordinates.NewCoordinatesForStepSize(1, -1);

            //Then
            Assert.AreEqual("6 4", newBoundary.ToString());
            Assert.AreEqual("5 5", boundaryCoordinates.ToString());
        }
    }
}
