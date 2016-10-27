using System;

namespace Minesweeper
{
    public class StringInputOptionParser
    {
        private string inputOption;
        public int xAxixPoistion;
        public int yAxixPoistion;
        public string inputFlagValue;
        public StringInputOptionParser(string inputOption)
        {
            this.inputOption = inputOption;
        }

        public StringInputOptionParser ParserInputOption()
        {
            if (!ValdiateInputOption()) return null;
            inputFlagValue = inputOption.Substring(0, 1);
            xAxixPoistion = Convert.ToInt32(inputOption.Substring(2, 1));
            yAxixPoistion = Convert.ToInt32(inputOption.Substring(4, 1));
            return this;

        }

        private bool ValdiateInputOption()
        {
            return inputOption.Length == 6;
        }
    }
}
