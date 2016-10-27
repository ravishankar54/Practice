namespace FirstTest
{
    public class MoveCommand : ICommand
    {
        public void Execute(ChandrayanRover rover)
        {
            rover.Move();
        }
    }
}
