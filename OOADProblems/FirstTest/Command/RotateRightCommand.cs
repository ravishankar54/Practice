namespace FirstTest
{
    public class RotateRightCommand : ICommand
    {
        public void Execute(ChandrayanRover rover)
        {
            rover.TurnRight();
        }
    }
}
