namespace Minesweeper
{
    public class BoxDetails
    {
        public BoxDetails(int xAxisPosition, int yAxisPosition, string flag)
        {
            XAxisPosition = xAxisPosition;
            YAxisPosition = yAxisPosition;
            Flag = flag;
            Value = MineBoxStatus.x.ToString();
        }
        public int XAxisPosition { get; set; }
        public int YAxisPosition { get; set; }
        public string Flag { get; set; }
        public string Value { get; set; }
        public int MinesCount { get; set; }
    }

    enum MineBoxStatus
    {
        x = 1,
        m = 2
    }

    public class Position
    {
        public Position(int xAxisPosition, int yAxisPosition)
        {
            XAxisPosition = xAxisPosition;
            YAxisPosition = yAxisPosition;
        }

        public int XAxisPosition { get; set; }
        public int YAxisPosition { get; set; }
    }
}
