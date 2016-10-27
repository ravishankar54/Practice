using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Command
{
    [TestClass]
    public class MoveCommandTest
    {
        [TestMethod]
        public void TestThatMoveCommandMovesTheNavigableObject()
        {
            //Given 
            MoveCommand command = new MoveCommand();
            Plateau plateau = new Plateau(5, 5);
            Coordinates startingPosition = new Coordinates(1, 2);
            ChandrayanRover rover = new ChandrayanRover(plateau, new Direction(EnumDirection.N), startingPosition);

            //When
            command.Execute(rover);
            var result = rover.CurrentLocation();

            //Then
            Assert.AreEqual("1 3 N", result);

        }
    }
}
