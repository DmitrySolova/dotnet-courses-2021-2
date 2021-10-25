using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class OfficeEventArgs : EventArgs
    {
        private string _name;
        private DateTime _time;

        public DateTime Time
        {
            get => _time;
        }

        public string Name
        {
            get => _name;
        }

        public OfficeEventArgs (string name, DateTime time)
        {
            _name = name;
            _time = time;
        }
    }
}
