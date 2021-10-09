using System;

namespace Task4
{
    interface Game
    {

    }

    class GameLogic : Game
    {
        private bool _errorGameLogic;

        public void Save() { }

        public void Load() { }

        public bool checkGameLogic()
        {
            if (_errorGameLogic)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    class GameLoop : Game
    {
        private bool _gameEnded;

        public void StartGame()
        {

        }

        public void EndGame()
        {

        }
    }

    interface GameField : Game
    {
        protected void Drow() { }
    }

    class GameObject : GameField
    {
        protected int _x;
        protected int _y;
        protected int _z;
        protected string _status;
        protected void Logic() { }

        protected void Move() { }

    }

    class Bonus : GameObject
    {
        
    }

    class Obstacle : GameObject
    {

    }

    class Player : GameObject
    {
        int[] characteristics = new int[5];

        protected void Attack() { }
        protected void Heal () { }
    }

    class Monster : GameObject
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
