using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
namespace MinessweeperTests
{
    [TestClass]
    public class StringInputPatternParserTest
    {
        [TestMethod]
        public void TestStringInputPatternIsValid()
        {
            //Given 
            string inputPattern = "xxm,xmx,xxx";
            StringInputPatternParser patternparser = new StringInputPatternParser(inputPattern);

            //When 
            var matrix = patternparser.ConstructMinesweeperMatrix();
            var fisrtElement = matrix.First();
            var thirdElement = matrix[2];

            //Then
            Assert.AreEqual("x", fisrtElement.Value);
            Assert.AreEqual("m", thirdElement.Flag);
            Assert.AreEqual("x", thirdElement.Value);
        }

        [TestMethod]
        public void TestStringInputPatternIsValidIsInValidPostion()
        {
            //Given 
            string inputPattern = "xxm,xmx,xxx";
            StringInputPatternParser patternparser = new StringInputPatternParser(inputPattern);

            //When 
            var matrix = patternparser.ConstructMinesweeperMatrix();
            var thirdElement = matrix[2];

            //Then
            Assert.AreEqual(0, thirdElement.XAxisPosition);
            Assert.AreEqual(2, thirdElement.YAxisPosition);
        }
    }
}
