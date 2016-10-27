using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class MinesweeperGame
    {
        private string inputPattern;
        private List<BoxDetails> minesweeperMatrix;
        private StringInputPatternParser inputPatternParser;
        public string[] updateInputPatternArray;
        public string[] besideMinesCountForEachBoxinMatrix;
        public MinesweeperGame(string inputPattern)
        {
            this.inputPattern = inputPattern;
            inputPatternParser = new StringInputPatternParser(inputPattern);
            minesweeperMatrix = inputPatternParser.ConstructMinesweeperMatrix();

        }

        public void StartGame(string inputOption)
        {
            var parser = new StringInputOptionParser(inputOption).ParserInputOption();
            if (parser != null)
            {
                foreach (var option in minesweeperMatrix)
                {
                    if (option.XAxisPosition == parser.xAxixPoistion && option.YAxisPosition == parser.yAxixPoistion)
                    {
                        option.Value = parser.inputFlagValue;
                    }
                }
            }
            PrintUpdatedMatrix();
        }

        private void PrintUpdatedMatrix()
        {
            var minesweeperMatrixArray = minesweeperMatrix.ToArray();
            var printPattern = string.Empty;
            var minesCountPatter = string.Empty;
            var counter = 1;
            var updateArrayCounter = 0;
            updateInputPatternArray = new string[inputPatternParser.DimensionOfMatrix];
            besideMinesCountForEachBoxinMatrix = new string[inputPatternParser.DimensionOfMatrix];
            for (int i = 0; i < minesweeperMatrixArray.Length; i++)
            {
                if (counter <= inputPatternParser.DimensionOfMatrix)
                {
                    printPattern += minesweeperMatrixArray[i].Value;
                    minesCountPatter += minesweeperMatrixArray[i].MinesCount.ToString();
                    counter++;
                }
                if (counter > inputPatternParser.DimensionOfMatrix)
                {
                    if (updateArrayCounter < updateInputPatternArray.Length)
                    {
                        updateInputPatternArray[updateArrayCounter] = printPattern;
                        besideMinesCountForEachBoxinMatrix[updateArrayCounter] = minesCountPatter;
                        updateArrayCounter++;
                    }
                    Console.WriteLine(printPattern);
                    counter = 1;
                    printPattern = string.Empty;
                    minesCountPatter = string.Empty;
                }
            }
        }

    }
}
