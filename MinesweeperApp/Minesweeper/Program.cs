using System;

namespace Minesweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            var minesweeper = new MinesweeperGame("xxm,xmx,xxx");
            minesweeper.StartGame("o(0,0)");

            Console.ReadLine();
        }
    }
}
