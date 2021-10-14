using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLoop gameLoop = new GameLoop();
            GameLogic gameLogic = new GameLogic();
            GameField gameField = new GameField();

            gameLoop.Loop();
        }
    }
}
