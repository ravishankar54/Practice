namespace FirstTest
{
    public class Plateau
    {
        private Coordinates topRightCoordinates = new Coordinates(0, 0);
        private Coordinates bottomLeftCoordinates = new Coordinates(0, 0);
        public Plateau(int xCoordinate, int yCoordinate)
        {
            topRightCoordinates = topRightCoordinates.NewCoordinatesToStart(xCoordinate, yCoordinate);
        }

        public bool HasWithinBounds(Coordinates coordinates)
        {
            return bottomLeftCoordinates.HasOutsideBounds(coordinates) && topRightCoordinates.HasWithinBounds(coordinates);
        }
    }
}
