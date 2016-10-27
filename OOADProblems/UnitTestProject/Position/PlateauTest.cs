using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Position
{
    [TestClass]
    public class PlateauTest
    {
        [TestMethod]
        public void LocationWithCoordinateWithinBoundsIsIdentified()
        {
            //Given
            Plateau mars = new Plateau(5, 5);

            //When
            Coordinates plateauCoordinates = new Coordinates(5, 0);

            //Then
            Assert.IsTrue(mars.HasWithinBounds(plateauCoordinates));
        }

        [TestMethod]
        public void LocationWithPositiveXCoordinateOutsideBoundsIsIdentified()
        {
            //Given
            Plateau mars = new Plateau(5, 5);

            //When
            Coordinates coordinates = new Coordinates(6, 0);

            //Then
            Assert.IsFalse(mars.HasWithinBounds(coordinates));
        }

        [TestMethod]
        public void LocationWithNegativeXCoordinateOutsideBoundsIsIdentified()
        {
            //Given
            Plateau mars = new Plateau(5, 5);

            //When
            Coordinates coordinates = new Coordinates(-1, 0);


            //Then
            Assert.IsFalse(mars.HasWithinBounds(coordinates));
        }

        [TestMethod]
        public void LocationWithPositiveYCoordinateOutsideBoundsIsIdentified()
        {
            //Given
            Plateau mars = new Plateau(5, 5);

            //When
            Coordinates coordinates = new Coordinates(0, 6);


            //Then
            Assert.IsFalse(mars.HasWithinBounds(coordinates));
        }

        [TestMethod]
        public void LocationWithNegativeYCoordinateOutsideBoundsIsIdentified()
        {
            //Given
            Plateau mars = new Plateau(5, 5);

            //When
            Coordinates coordinates = new Coordinates(0, -1);


            //Then
            Assert.IsFalse(mars.HasWithinBounds(coordinates));
        }
    }
}
