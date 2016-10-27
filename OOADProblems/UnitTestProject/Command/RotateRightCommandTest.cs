using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Command
{
    [TestClass]
    public class RotateRightCommandTest
    {
        [TestMethod]
        public void TestThatRotateRightCommandRotatesTheNavigableObjectRight()
        {
            //Given
            RotateRightCommand command = new RotateRightCommand();
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover rover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            command.Execute(rover);

            //Then
            Assert.AreEqual("1 2 E", rover.CurrentLocation());
        }
    }
}
