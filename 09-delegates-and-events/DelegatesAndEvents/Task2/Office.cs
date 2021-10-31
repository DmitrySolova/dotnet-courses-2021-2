using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    class Office
    {
        private delegate void OfficeHandler(object sender, OfficeEventArgs officeEventArgs);
        private event OfficeHandler PersonCame;
        private event OfficeHandler PersonLeft;

        HashSet<Person> workers = new HashSet<Person>();

        public void Come(Person person)
        {
            Console.WriteLine($"[На работу пришел {person.Name}]");
            PersonCame?.Invoke(this, new OfficeEventArgs(person.Name, person.TimeCameToWork));
            PersonCame += person.OnCame;
            PersonLeft += person.OnLeave;
        }

        public void Leave(Person person)
        {
            Console.WriteLine($"{person.Name} ушел домой!");
            PersonLeft -= person.OnCame;
            PersonLeft -= person.OnLeave;
            PersonLeft?.Invoke(this, new OfficeEventArgs(person.Name, person.TimeCameToWork));
        }
    }
}
