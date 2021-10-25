using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Person
    {
        private string _name = "";
        private DateTime _timeCameToWork;

        public Person (string name, DateTime time)
        {
            Name = name;
            TimeCameToWork = time;
        }

        private void Greet( OfficeEventArgs officeEventArgs)
        {
            if (officeEventArgs.Time.Hour < 12)
            {
                Console.WriteLine($"'Доброе утро, {officeEventArgs.Name}!', - сказал {Name}");
            }
            else if (officeEventArgs.Time.Hour > 12 && officeEventArgs.Time.Hour < 17)
            {
                Console.WriteLine($"'Добрый день, {officeEventArgs.Name}!', - сказал {Name}");
            }
            else
            {
                Console.WriteLine($"'Добрый вечер, {officeEventArgs.Name}!', - сказал {Name}");
            }
        }

        private void SayGoodbye(OfficeEventArgs officeEventArgs)
        {
            Console.WriteLine($"'До свидания, {officeEventArgs.Name}!', - сказал {Name}");
        }

        public void OnCame(object sender, OfficeEventArgs officeEventArgs)
        {
            Greet(officeEventArgs);
        }

        public void OnLeave(object sender, OfficeEventArgs officeEventArgs)
        {
            SayGoodbye(officeEventArgs);
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DateTime TimeCameToWork
        {
            get => _timeCameToWork;
            set => _timeCameToWork = value;
        }
    }
}
