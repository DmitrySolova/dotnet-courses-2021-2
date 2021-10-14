using System;
using System.Collections.Generic;
using System.Text;

namespace Task4
{
    class MyString
    {
        private char[] _myString;

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

            _myString = inputString.ToCharArray();

        }

        public MyString(char[] arrayChars)
        {
            _myString = new char[arrayChars.Length];

            Array.Copy(arrayChars, _myString, arrayChars.Length);
        }

        public override string ToString()
        {

            return String.Join("", _myString);

        }

        public static MyString operator +(MyString myString1, MyString myString2)
        {
            string resutString = myString1.ToString() + myString2.ToString();
            return new MyString(resutString);
        }

        public static MyString operator -(MyString myString1, MyString myString2)
        {
            bool hasMatch = false;
            int index = 0;
            int nextIndex = 1;

            for (var i = 0; i < myString2._myString.Length; i++)
            {
                char myString2Charr = myString2._myString[i];
                for (var j = 0; j < myString1._myString.Length; j++)
                {
                    char myString1Charr = myString1._myString[j];
                    if (myString2Charr == myString1Charr)
                    {
                        nextIndex = j;
                        if (index < nextIndex)
                        {
                            index = j;
                            hasMatch = true;
                            break;
                        }
                        else
                        {
                            hasMatch = false;
                            break;
                        }
                    }
                    else
                    {
                        hasMatch = false;
                    }
                }
            }

            if (!hasMatch)
            {
                return myString1;
            }

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

            return new MyString(totalString);
        }
        public static bool operator ==(MyString myString1, MyString myString2)
        {
            if (myString1._myString.Length == myString2._myString.Length)
            {
                for (int i = 0; i < myString1._myString.Length; i++)
                {
                    if (myString1._myString[i] != myString2._myString[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(MyString myString1, MyString myString2)
        {
            return !(myString1._myString == myString2._myString);
        }
    }
}
