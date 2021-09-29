using System;

namespace Task4
{
    class MyString
    {
        string _myString;

        public MyString()
        {
            _myString = "";
        }

        public MyString(string inputString)
        {
            if (inputString is null)
            {
                throw new ArgumentNullException(nameof(inputString));
            }
            _myString = inputString;
        }

        public MyString(char[] arrayChars)
        {
            _myString = "";

            foreach (char ch in arrayChars)
            {
                _myString += ch;
            }
        }

        public override string ToString()
        {
            return _myString;
        }

        public static MyString operator +(MyString myString1, MyString myString2)
        {
            return new MyString { _myString = myString1._myString + myString2._myString };
        }

        public static MyString operator -(MyString myString1, MyString myString2)
        {
            return new MyString { _myString = myString1._myString.Replace(myString2._myString, "") };
        }

        public static bool operator ==(MyString myString1, MyString myString2)
        {
            return myString1._myString == myString2._myString;
        }

        public static bool operator !=(MyString myString1, MyString myString2)
        {
            return !(myString1._myString == myString2._myString);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString("Ляляля");
            Console.WriteLine(myString.ToString());
        }
    }
}
