using System;
using System.Collections.Generic;
namespace Minesweeper
{
    public class StringInputPatternParser
    {
        private string inputString;
        public int DimensionOfMatrix = 0;
        public StringInputPatternParser(string inputString)
        {
            this.inputString = inputString;
        }

        public List<BoxDetails> ConstructMinesweeperMatrix()
        {
            List<BoxDetails> minesweeperMatrix = new List<BoxDetails>();
            string[] inputPattern = ReadInputString();
            if (ValidateInputPattern(inputPattern))
            {
                PrintInputPattern(inputPattern);
                minesweeperMatrix = BuildMinesweeperMatrix(inputPattern);
            }
            return minesweeperMatrix;
        }
        private string[] ReadInputString()
        {
            return inputString.Split(',');
        }

        private bool ValidateInputPattern(string[] inputPatternArray)
        {
            var isPatternValid = true;
            foreach (string pattern in inputPatternArray)
            {
                if (pattern.ToString().Length != inputPatternArray.Length)
                {
                    isPatternValid = false;
                    Console.WriteLine("Please enter valid pattern");
                    break;
                }
            }
            if (isPatternValid)
            {
                DimensionOfMatrix = inputPatternArray.Length;
            }
            return isPatternValid;
        }

        private void PrintInputPattern(string[] inputPatternArray)
        {
            foreach (string pattern in inputPatternArray)
            {
                Console.WriteLine(pattern);
            }
        }

        private List<BoxDetails> BuildMinesweeperMatrix(string[] inputPatternArray)
        {
            List<BoxDetails> minesweeperMatrix = new List<BoxDetails>();
            for (int i = 0; i < inputPatternArray.Length; i++)//XAxis
            {
                var pattern = inputPatternArray[i];//taking whole string of horizontal and creating box for each character
                for (int j = 0; j < pattern.Length; j++)//YAxiis
                {
                    var minesweeperBox = new BoxDetails(i, j, pattern[j].ToString().ToLower());
                    minesweeperMatrix.Add(minesweeperBox);
                }
            }
            CountBesideMines(minesweeperMatrix);
            return minesweeperMatrix;
        }

        private void CountBesideMines(List<BoxDetails> minesweeperMatrix)
        {
            foreach (var box in minesweeperMatrix)
            {
                if (box.Flag == MineBoxStatus.m.ToString())
                {
                    var currentXPosition = box.XAxisPosition;
                    var currentYPosition = box.YAxisPosition;
                    minesweeperMatrix.FindAll(findBox =>
                   ((Math.Abs(findBox.XAxisPosition - currentXPosition) == 1 && findBox.YAxisPosition == currentYPosition))
                   || ((Math.Abs(findBox.YAxisPosition - currentYPosition) == 1 && findBox.XAxisPosition == currentXPosition)))
                   .ForEach(selectedNode => { selectedNode.MinesCount = selectedNode.MinesCount++; });

                }
            }
        }
    }
}
