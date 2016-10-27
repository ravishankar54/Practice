using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinessweeperTests

{
    [TestClass]
    public class StringInputOptionParserTest
    {
        [TestMethod]
        public void TestInputionOptionParserIsValidLength()
        {
            // Given
            var inputOption = "f(0, 2)";
            StringInputOptionParser parser = new StringInputOptionParser(inputOption);
            //When

            parser = parser.ParserInputOption();

            //Then
            Assert.AreEqual("f", parser.inputFlagValue);
            Assert.AreEqual(0, parser.xAxixPoistion);
            Assert.AreEqual(2, parser.yAxixPoistion);

        }
        [TestMethod]
        public void TestInputionOptionParserInValidLength()
        {
            // Given
            var inputOption = "f(0, 2)2";
            StringInputOptionParser parser = new StringInputOptionParser(inputOption);
            //When

            parser = parser.ParserInputOption();

            //Then
            Assert.IsNull(parser);

        }

    }
}
