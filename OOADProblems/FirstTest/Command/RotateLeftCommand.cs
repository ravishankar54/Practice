namespace FirstTest
{
    public class RotateLeftCommand : ICommand
    {
        public void Execute(ChandrayanRover rover)
        {
            rover.TurnLeft();
        }
    }
}
