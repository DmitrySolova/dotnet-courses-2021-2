using System;
using System.Collections.Generic;
using System.Text;

namespace Task1
{
    class DynamicArray<T> where T : new()
    {
        private int _lastEmptyCellIndex = 0;
        // сколько ячеек в памяти
        private int _capacity = 0;
        // сколько занятых элеметов в массиве
        private int _lenght = 0;
        private T[] _array;

        public DynamicArray()
        {
            _array = new T[8];
            _capacity = 8;
        }

        public DynamicArray(int i)
        {
            _array = new T[i];
            _capacity = i;
        }

        public DynamicArray(T[] array)
        {
            _array = array;
        }
        public void EnsureCapacity(int min)
        {
            while (min >= _capacity - _lenght)
            {
                _capacity = _capacity * 2;
            }
            // проверку, а надо ли вообще менять массив
            Array.Resize(ref _array, _capacity);
        }
        public void Add(T element)
        {
            EnsureCapacity(1);
            _array[_lastEmptyCellIndex] = element;
            _lastEmptyCellIndex++;
            _lenght++;
        }
        public void AddRange(T[] array)
        {
            foreach (T element in array)
            {
                this.Add(element);
            }
        }
        public bool Remove(T element)
        {
            int findIndex = Array.FindIndex(_array, x => x.Equals(element));

            if (findIndex == -1)
            {
                return false;
            }

            if (findIndex < _lenght)
            {
                Array.Copy(_array, findIndex + 1, _array, findIndex, _lenght - findIndex - 1);
            }
            _array[_lenght - 1] = default(T);

            _lenght--;

            return true;
        }
        public void Insert(int index, T element)
        {
            if (index > _lenght)
            {
                throw new ArgumentOutOfRangeException("Выход за границу массива");
            }

            EnsureCapacity(_capacity - _capacity - index + 1);

            if (index < _lenght)
            {
                Array.Copy(_array, index, _array, index + 1, _lenght - index);
            }
            _array[index] = element;

            _lenght++;

        }

        public void ShowDynamicArray()
        {
            foreach (T element in _array)
            {
                Console.WriteLine(element);
            }
        }
        public int Length
        {
            get => _lenght;
        }

        public int Capacity
        {
            get => _array.Length;
        }

        public T this[int i]
        {
            get
            {
                if (i >= _lenght)
                {
                    throw new ArgumentOutOfRangeException("Выход за границу массива");
                }
                return _array[i];
            }
            set
            {
                if (i > _lenght)
                {
                    throw new ArgumentOutOfRangeException("Выход за границу массива");
                }
                _array[i] = value;
            }
        }
    }
}
