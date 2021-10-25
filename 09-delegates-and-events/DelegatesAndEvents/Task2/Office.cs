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
            foreach (Person worker in workers)
            {
                PersonCame += (sender, OfficeEventArgs) => worker.OnCame(sender, OfficeEventArgs);
            }
            workers.Add(person);
            PersonCame?.Invoke(this, new OfficeEventArgs(person.Name, person.TimeCameToWork));
            PersonCame = null; // Очистка события. Иначе на следующий день повторятся вчерашние приветствия.
        }

        public void Leave(Person person)
        {
            Console.WriteLine($"{person.Name} ушел домой!");
            workers.Remove(person);
            foreach (Person worker in workers)
            {
                PersonLeft += (sender, OfficeEventArgs) => worker.OnLeave(sender, OfficeEventArgs);
            }
            PersonLeft?.Invoke(this, new OfficeEventArgs(person.Name, person.TimeCameToWork));
            PersonLeft = null; // Очистка события. Иначе на следующий день повторятся вчерашние приветствия.
        }
    }
}
