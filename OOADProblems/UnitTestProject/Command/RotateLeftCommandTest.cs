using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Command
{
    [TestClass]
    public class RotateLeftCommandTest
    {
        [TestMethod]
        public void TestThatRotateLeftCommandRotatesTheNavigableObjectLeft()
        {
            //Given 
            RotateLeftCommand command = new RotateLeftCommand();
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover rover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            command.Execute(rover);

            //Then
            Assert.AreEqual("1 2 W", rover.CurrentLocation());

        }
    }
}
