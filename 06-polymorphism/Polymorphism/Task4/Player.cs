using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class Player : GameObject, IMovable
    {
        int[] characteristics = new int[5];

        protected void Attack() { }
        protected void Heal() { }
    }
}
