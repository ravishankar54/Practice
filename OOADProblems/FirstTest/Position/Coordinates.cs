using System.Text;

namespace FirstTest
{
    public class Coordinates
    {
        public Coordinates(int xCoordnidate, int yCoordinate)
        {
            XCoordinate = xCoordnidate;
            YCoordinate = yCoordinate;
        }
        public Coordinates NewCoordinatesToStart(int xCoordinateStepValue, int yCoordinateStepValue)
        {
            return new Coordinates(XCoordinate + xCoordinateStepValue, YCoordinate + yCoordinateStepValue);
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public bool IsXCoordinateInOutsideBounds(int xCoordinate)
        {
            return xCoordinate >= this.XCoordinate;
        }
        public bool IsYCoordinateInOutsideBounds(int yCoordinate)
        {
            return yCoordinate >= this.YCoordinate;
        }

        public bool IsXCoordinateWithinBounds(int xCoordinate)
        {
            return xCoordinate <= this.XCoordinate;

        }

        public bool IsYCoordinateWithinBounds(int yCoordinate)
        {
            return yCoordinate <= this.YCoordinate;

        }

        public bool HasWithinBounds(Coordinates coordinates)
        {
            return IsXCoordinateWithinBounds(coordinates.XCoordinate) && IsYCoordinateWithinBounds(coordinates.YCoordinate);
        }

        public bool HasOutsideBounds(Coordinates coordinates)
        {
            return IsXCoordinateInOutsideBounds(coordinates.XCoordinate) && IsYCoordinateInOutsideBounds(coordinates.YCoordinate);
        }

        public Coordinates NewCoordinatesForStepSize(int xCoordinateStepValue, int yCoordinateStepValue)
        {
            return new Coordinates(XCoordinate + xCoordinateStepValue, YCoordinate + yCoordinateStepValue);
        }

        public override string ToString()
        {
            StringBuilder coordinateOutput = new StringBuilder();
            coordinateOutput.Append(XCoordinate);
            coordinateOutput.Append(" ");
            coordinateOutput.Append(YCoordinate);
            return coordinateOutput.ToString();
        }
    }
}
