using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinessweeperTests
{
    [TestClass]
    public class BoxDetailsTest
    {
        [TestMethod]
        public void TestInputPatternCreatesCorrectBoxDertails()
        {
            //Given
            var xPostion = 1;
            var yPostion = 2;
            var inputValue = "m";

            //When
            var box = new BoxDetails(xPostion, yPostion, inputValue);

            //Then
            Assert.AreEqual(1, box.XAxisPosition);
            Assert.AreEqual(2, box.YAxisPosition);
            Assert.AreEqual("m", box.Flag);
            Assert.AreEqual("x", box.Value);

        }
    }
}
