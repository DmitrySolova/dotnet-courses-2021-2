using System;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString("abcdefj");
            MyString myString1 = new MyString("deff");

            Console.WriteLine(myString - myString1);
        }
    }
}
