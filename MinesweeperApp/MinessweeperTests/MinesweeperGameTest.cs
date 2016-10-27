using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinessweeperTests
{
    [TestClass]
    public class MinesweeperGameTest
    {
        [TestMethod]
        public void TestMinesweeperGameWithValidInput()
        {
            // Given
            string validInputPattern = "xxm,xmx,xxx";
            MinesweeperGame game = new MinesweeperGame(validInputPattern);

            // When 
            game.StartGame("o(0,0)");
            //game.StartGame("o(0,1)");
            //game.StartGame("o(0,2)");
            ////Then 
            //Assert.AreEqual("oof", game.updateInputPatternArray[0].ToString());
            //Assert.AreEqual("xxx", game.updateInputPatternArray[1].ToString());
            //Assert.AreEqual("xxx", game.updateInputPatternArray[2].ToString());

            Assert.AreEqual("020", game.besideMinesCountForEachBoxinMatrix[0].ToString());
            Assert.AreEqual("102", game.besideMinesCountForEachBoxinMatrix[1].ToString());
            Assert.AreEqual("010", game.besideMinesCountForEachBoxinMatrix[2].ToString());
        }
    }
}
