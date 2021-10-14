using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class GameLogic
    {
        private bool _errorGameLogic;

        public void Save() { }

        public void Load() { }

        public bool СheckGameLogic()
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

}
