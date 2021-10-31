using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Office office = new Office();

            Person dima = new Person("Дима", new DateTime(2021, 10, 25, 7, 7, 7));
            Person oleg = new Person("Олег", new DateTime(2021, 10, 25, 7, 7, 7));
            Person sasha = new Person("Саша", new DateTime(2021, 10, 25, 16, 7, 7));
            Person jack = new Person("Джек", new DateTime(2021, 10, 25, 20, 7, 7));

            office.Come(dima);
            office.Come(sasha);
            office.Come(jack);
            office.Come(oleg);
            office.Leave(dima);
            office.Leave(sasha);
            office.Leave(jack);
            office.Leave(oleg);

        }
    }
}
