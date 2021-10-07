using System;
// доделать с массивом чаров + учесть переделки в следующем задании!
namespace Task4
{
    class MyString
    {
        protected char[] _myString;

        public MyString()
        {
            _myString = new char[] { };
        }

        public MyString(string inputString)
        {
            if (inputString is null)
            {
                throw new ArgumentNullException(nameof(inputString));
            }

            _myString = new char[inputString.Length];

            for (int i = 0; i < inputString.Length; i++)
            {
                _myString[i] = inputString[i];
            }

        }

        public MyString(char[] arrayChars)
        {
            _myString = new char[arrayChars.Length];

            Array.Copy(arrayChars, _myString, arrayChars.Length);
        }

        public override string ToString()
        {
            string returnedString = "";

            foreach (char ch in _myString)
            {
                returnedString += ch;
            }

            return returnedString;
        }

        public static MyString operator +(MyString myString1, MyString myString2)
        {
            char[] returnedString = new char[myString1._myString.Length + myString2._myString.Length];
            Array.Copy(myString1._myString, returnedString, myString1._myString.Length);
            Array.Copy(myString2._myString, 0, returnedString, myString1._myString.Length, myString2._myString.Length);

            return new MyString
            {
                _myString = returnedString
            };
        }

        public static MyString operator -(MyString myString1, MyString myString2)
        {
            char[] sourceString = myString1._myString;

            char[] substring = myString2._myString;

            char[] totalString = new char[sourceString.Length - substring.Length];

            int findedIndex = 0;

            for (int i = 0; i < sourceString.Length; i++)
            {
                if (sourceString[i] == substring[0])
                {
                    findedIndex = i;
                    break;
                }
            }

            if (findedIndex == 0)
            {
                Array.Copy(sourceString, substring.Length, totalString, 0, sourceString.Length - substring.Length);
            }
            else if (findedIndex == sourceString.Length - substring.Length)
            {
                Array.Copy(sourceString, 0, totalString, 0, sourceString.Length - substring.Length);
            }
            else
            {
                Array.Copy(sourceString, 0, totalString, 0, findedIndex);
                Array.Copy(sourceString, findedIndex + substring.Length, totalString, findedIndex, sourceString.Length - findedIndex - substring.Length);
            }

            return new MyString { _myString = totalString };
        }

        public static bool operator ==(MyString myString1, MyString myString2)
        {
            for(int i = 0; i < myString1._myString.Length; i++)
            {
                if (myString1._myString[i] != myString2._myString[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator !=(MyString myString1, MyString myString2)
        {
            for (int i = 0; i < myString1._myString.Length; i++)
            {
                if (myString1._myString[i] != myString2._myString[i])
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyString myString = new MyString("Ляляляяик");
            MyString myString1 = new MyString("ик");

            Console.WriteLine(myString - myString1);
        }
    }
}
