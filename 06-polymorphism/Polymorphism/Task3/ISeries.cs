using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    interface ISeries
    {
        double GetCurrent();
        bool MoveNext();
        void Reset();

    }
}
