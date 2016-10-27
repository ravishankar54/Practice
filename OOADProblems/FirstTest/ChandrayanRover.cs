using System.Collections.Generic;

namespace FirstTest
{
    public class ChandrayanRover
    {
        public Plateau Plateau { get; set; }
        public Direction CurrentDirection { get; set; }
        public Coordinates CurrentCoordinates { get; set; }

        public ChandrayanRover(Plateau plateau, Direction direction, Coordinates coordinates)
        {
            Plateau = plateau;
            CurrentDirection = direction;
            CurrentCoordinates = coordinates;
        }

        public void Run(string commandString)
        {
            List<ICommand> roverCommands = new RoverInputStringCommandParser(commandString).ToCommands();
            foreach (var command in roverCommands)
            {
                command.Execute(this);
            }
        }

        public void TurnRight()
        {
            CurrentDirection = CurrentDirection.TurnRight();
        }

        public void TurnLeft()
        {
            CurrentDirection = CurrentDirection.TurnLeft();
        }

        public string CurrentLocation()
        {
            return CurrentCoordinates.ToString() + " " + CurrentDirection.CurrentFacing.ToString();
        }

        public void Move()
        {
            Coordinates coordinateAfterMove = CurrentCoordinates.NewCoordinatesForStepSize(CurrentDirection.StepSizeForXAxis, CurrentDirection.StepSizeForYAxis);

            if (Plateau.HasWithinBounds(coordinateAfterMove))
            {
                CurrentCoordinates = CurrentCoordinates.NewCoordinatesToStart(CurrentDirection.StepSizeForXAxis, CurrentDirection.StepSizeForYAxis);
            }
        }
    }
}
