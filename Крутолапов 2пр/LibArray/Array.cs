using System;

namespace LibArray
{
    public class Array<T>
    {
        T[] _array;
        int _capacity;

        readonly int _defaultCapacity = 1;

        public T this[int index]
        {
            get { return _array[index]; }
            set { _array[index] = value; }
        }

        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value != _capacity)
                {
                    _capacity = value;

                    Array.Resize(ref _array, value);
                }
            }
        }

        public Array(int capacity)
        {
            _array = new T[capacity];
            Capacity = capacity;
        }

        public int Length
        {
            get; set;
        }

        /// <summary>
        /// Очистка массива
        /// </summary>
        public void Clear()
        {
            Capacity = _defaultCapacity;
            Length = 0;
            _array = new T[Capacity];
        }

        /// <summary>
        /// Добавляет несколько элементов в конец одномерного массива
        /// </summary>
        /// <param name="items">массив</param>
        public void AddRange(T[] items)
        {
            T[] temp = _array;

            Length += items.Length;
            Capacity = Length;

            _array = new T[Length];

            for (int i = 0; i < temp.Length; i++)
            {
                _array[i] = temp[i];
            }

            for (int i = temp.Length, j = 0; i < _array.Length; i++, j++)
            {
                _array[i] = items[j];
            }
        }

        /// <summary>
        /// Метод удаляет передаваемое число из массива
        /// </summary>
        /// <param name="item">удаляемое число</param>
        /// <returns>false если элемент не найден</returns>
        public bool Remove(T item)
        {
            var arrayCopy = _array;
            int itemIndex = -1;

            for (int i = 0; i < Length; i++)
            {
                if (CompareTo(arrayCopy[i], item) == 0)
                {
                    itemIndex = i;
                    break;
                }
            }

            if (itemIndex == -1)
            {
                return false;
            }

            Length -= 1;
            Capacity = Length;
            _array = new T[Length];

            for (int i = 0, j = 0; j < Length; i++, j++)
            {
                if (i == itemIndex)
                {
                    i++;
                }
                _array[j] = arrayCopy[i];
            }
            return true;
        }

        //вспомогательный метод для сравнения обобщённых элементов 
        public static int CompareTo(object obj, object obj1)
        {
            if ((int)obj > ((int)obj1))               //распаковка int из object
            {
                return 1;
            }
            else if ((int)obj < ((int)obj1))
            {
                return -1;
            }
            return 0;
        }
    }
}