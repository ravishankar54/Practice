namespace FirstTest
{
    public class Direction
    {
        public Direction(EnumDirection direction)
        {
            switch (direction)
            {
                case EnumDirection.N:
                    North();
                    break;
                case EnumDirection.S:
                    South();
                    break;
                case EnumDirection.E:
                    East();
                    break;
                case EnumDirection.W:
                    West();
                    break;
            }
            CurrentFacing = direction;
        }

        public int StepSizeForXAxis { get; set; }
        public int StepSizeForYAxis { get; set; }
        public EnumDirection CurrentFacing { get; set; }

        public Direction TurnRight()
        {

            switch (CurrentFacing)
            {
                case EnumDirection.N:
                    CurrentFacing = EnumDirection.E;
                    East();
                    break;
                case EnumDirection.S:
                    CurrentFacing = EnumDirection.W;
                    West();
                    break;
                case EnumDirection.E:
                    CurrentFacing = EnumDirection.S;
                    South();
                    break;
                case EnumDirection.W:
                    CurrentFacing = EnumDirection.N;
                    North();
                    break;
            }
            return this;
        }

        public Direction TurnLeft()
        {
            switch (CurrentFacing)
            {
                case EnumDirection.N:
                    CurrentFacing = EnumDirection.W;
                    break;
                case EnumDirection.S:
                    CurrentFacing = EnumDirection.E;
                    break;
                case EnumDirection.E:
                    CurrentFacing = EnumDirection.N;
                    break;
                case EnumDirection.W:
                    CurrentFacing = EnumDirection.S;
                    break;
            }
            return this;
        }

        private void North()
        {
            StepSizeForXAxis = 0;
            StepSizeForYAxis = 1;
        }
        private void South()
        {
            StepSizeForXAxis = 0;
            StepSizeForYAxis = -1;
        }
        private void East()
        {
            StepSizeForXAxis = 1;
            StepSizeForYAxis = 0;
        }
        private void West()
        {
            StepSizeForXAxis = -1;
            StepSizeForYAxis = 0;
        }
    }

    public enum EnumDirection
    {
        N = 0,
        S = 1,
        E = 2,
        W = 3
    }
}
