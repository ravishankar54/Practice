using System.Collections.Generic;
using FirstTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject.Parser
{
    [TestClass]
    public class RoverInputStringCommandParserTest
    {
        [TestMethod]
        public void InputStringLMapsToRotateLeftCommand()
        {
            //Given
            RoverInputStringCommandParser parser = new RoverInputStringCommandParser("L");

            //When
            List<ICommand> commands = parser.ToCommands();

            //Then
            Assert.IsTrue(commands[0] is RotateLeftCommand);
            Assert.AreEqual(1, commands.Count);
        }

        [TestMethod]
        public void InputStringRMapsToRotateRightCommand()
        {
            //Given
            RoverInputStringCommandParser parser = new RoverInputStringCommandParser("R");

            //When
            List<ICommand> commands = parser.ToCommands();

            //Then
            Assert.IsTrue(commands[0] is RotateRightCommand);
            Assert.AreEqual(1, commands.Count);
        }

        [TestMethod]
        public void InputStringMMapsToMoveCommand()
        {
            //Given
            RoverInputStringCommandParser parser = new RoverInputStringCommandParser("M");

            //When
            List<ICommand> commands = parser.ToCommands();

            //Then
            Assert.IsTrue(commands[0] is MoveCommand);
            Assert.AreEqual(1, commands.Count);
        }

        [TestMethod]
        public void InputEmptyStringResultsInEmptyCommandList()
        {
            //Given
            RoverInputStringCommandParser parser = new RoverInputStringCommandParser("");

            //When
            List<ICommand> commands = parser.ToCommands();

            //Then
            Assert.AreEqual(0, commands.Count);
        }

        [TestMethod]
        public void InputNullStringResultsInEmptyCommandList()
        {
            //Given
            RoverInputStringCommandParser parser = new RoverInputStringCommandParser(null);

            //When
            List<ICommand> commands = parser.ToCommands();

            //Then
            Assert.AreEqual(0, commands.Count);
        }

        [TestMethod]
        public void InputSringToCommandMappingIsCaseInsensitive()
        {
            //Given
            RoverInputStringCommandParser parser = new RoverInputStringCommandParser("mM");

            //When
            List<ICommand> commands = parser.ToCommands();

            //Then
            Assert.IsTrue(commands[0] is MoveCommand);
            Assert.IsTrue(commands[1] is MoveCommand);
        }

        [TestMethod]
        public void InputMultiCommandStringIsMappedToCommandsInSameOrder()
        {
            //Given
            RoverInputStringCommandParser parser = new RoverInputStringCommandParser("MRL");

            //When
            List<ICommand> commands = parser.ToCommands();

            //Then
            Assert.IsTrue(commands[0] is MoveCommand);
            Assert.IsTrue(commands[1] is RotateRightCommand);
            Assert.IsTrue(commands[2] is RotateLeftCommand);
        }
    }
}
