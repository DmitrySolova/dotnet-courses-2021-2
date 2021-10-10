using System;

namespace Task1
{
    class DynamicArray<T> where T : new()
    {
        private int _lastEmptyCellIndex = 0;
        private int _lenght = 0;
        private int _capacity = 0;
        private T[] _dynamicArray;

        public DynamicArray()
        {
            _dynamicArray = new T[8];
            _capacity = 8;
        }

        public DynamicArray(int i)
        {
            _dynamicArray = new T[i];
            _capacity = i;
        }

        public DynamicArray(T[] array)
        {
            _dynamicArray = array;
        }

        public void Add(T element)
        {
            if (_lastEmptyCellIndex == _dynamicArray.Length)
            {
                Array.Resize(ref _dynamicArray, _dynamicArray.Length * 2);
                _capacity = _dynamicArray.Length * 2;
            }
            _dynamicArray[_lastEmptyCellIndex] = element;
            _lastEmptyCellIndex++;
            _lenght++;
        }

        public void AddRange(T[] array)
        {
            if (array.Length > _capacity - _lenght)
            {
                Array.Resize(ref _dynamicArray, array.Length + _capacity - _lenght);
                _capacity = array.Length + _capacity - _lenght;
            }
            foreach (T element in array)
            {
                this.Add(element);
            }
        }

        public bool Remove(T element)
        {
            int findIndex = Array.FindIndex(_dynamicArray, x => x.Equals(element));

            if (findIndex == -1)
            {
                return false;
            }

            T[] tempArray = new T[_capacity - 1];

            if (findIndex == 0)
            {
                for (int i = 0; i < _capacity - 1; i++)
                {
                    tempArray[i] = _dynamicArray[i];
                }
            }
            else if (findIndex == _dynamicArray.Length - 1)
            {
                for (int i = 0; i < _capacity - 1; i++)
                {
                    tempArray[i] = _dynamicArray[i];
                }
            }
            else
            {
                for (int i = 0; i < findIndex; i++)
                {
                    tempArray[i] = _dynamicArray[i];
                }
                for (; findIndex < _capacity - 1; findIndex++)
                {
                    tempArray[findIndex] = _dynamicArray[findIndex + 1];
                }
            }


            _dynamicArray = tempArray;

            return true;
        }

        public void Insert(int index, T element)
        {
            if (index > _capacity)
            {
                throw new ArgumentOutOfRangeException("Выход за границу массива");
            }

            T[] tempArray;

            if (_lastEmptyCellIndex == _dynamicArray.Length)
            {
                _capacity++;
                _lenght++;
                tempArray = new T[_capacity + 1];
            }

            tempArray = new T[_capacity];

            if (index == 0)
            {
                tempArray[index] = element;
                for (int i = 0; i < _capacity - 1; i++)
                {
                    tempArray[i + 1] = _dynamicArray[i];
                }
            }
            else if (index == _dynamicArray.Length - 1)
            {
                for (int i = 0; i < _capacity - 1; i++)
                {
                    tempArray[i] = _dynamicArray[i];
                }
                tempArray[index] = element;
            }
            else
            {
                for (int i = 0; i < index; i++)
                {
                    tempArray[i] = _dynamicArray[i];
                }
                tempArray[index] = element;
                for (; index < _capacity - 1; index++)
                {
                    tempArray[index + 1] = _dynamicArray[index];
                }
            }


            _dynamicArray = tempArray;

        }

        public int Length
        {
            get => _lenght;
        }

        public int Capacity
        {
            get => _capacity;
        }

        public T this[int i]
        {
            get
            {
                if (i >= _capacity)
                {
                    throw new ArgumentOutOfRangeException("Выход за границу массива");
                }
                return _dynamicArray[i];
            }
            set
            {
                if (i > _capacity)
                {
                    throw new ArgumentOutOfRangeException("Выход за границу массива");
                }
                _dynamicArray[i] = value;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DynamicArray<int> dynamicArray = new DynamicArray<int>();
            dynamicArray.Add(1);
            dynamicArray.Add(6);
            dynamicArray.Add(78);
            dynamicArray.Add(32);
            dynamicArray.Add(-123);
            
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(dynamicArray[i]);
            }
            Console.WriteLine();

            dynamicArray.Insert(0, 666);

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(dynamicArray[i]);
            }
            Console.WriteLine();

            dynamicArray.Insert(4, 333);

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(dynamicArray[i]);
            }
            Console.WriteLine();

            dynamicArray.Insert(dynamicArray.Length + 1, 999);

            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(dynamicArray[i]);
            }
            Console.WriteLine();

            dynamicArray.Remove(333);

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine(dynamicArray[i]);
            }
            Console.WriteLine();

            dynamicArray.Remove(12124);
        }
    }
}
