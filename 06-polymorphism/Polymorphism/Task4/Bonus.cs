using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Bonus : GameObject, IMovable, IStatic
    {
        public int ReturnCharacterBonus()
        {
            int characterBonus = 1;
            return characterBonus;
        }
    }
}
