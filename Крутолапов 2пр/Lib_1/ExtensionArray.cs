using LibArray;
using System;
using System.Data;

namespace Lib_1
{
    public static class ExtensionArray
    {
        /// <summary>
        /// создание и заполнение массива рандомными значениями
        /// </summary>
        /// <param name="array">целочисленный массив</param>
        /// <param name="count">размер массива</param>
        /// <param name="min">минимальные диапазон значений</param>
        /// <param name="max">максимальный диапазон значений</param>
        /// <returns>целочисленный массив</returns>
        public static Array<int> CreateArr(this Array<int> array, int count, int min, int max)
        {
            array = new Array<int>(count);

            Random rnd = new Random();

            for (int i = 0; i < count; i++)
            {
                array[i] = rnd.Next(min, max);
            }
            return array;
        }

        /// <summary>
        /// Метод для подсчета суммы чисел больше 5 в одномерном массиве
        /// </summary>
        /// <param name="array">массив</param>
        /// <returns>Целое число</returns>
        public static int SumB5(this Array<int> array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 5)
                {
                    sum += array[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Визуализирует одномерный массив с помощью DataGrid
        /// </summary>       
        public static DataTable ToDataTable<T>(this Array<int> arr)
        {
            var res = new DataTable();
            for (int i = 0; i < arr.Capacity; i++)
            {
                res.Columns.Add("#" + (i + 1), typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < arr.Capacity; i++)
            {
                row[i] = arr[i];
            }
            res.Rows.Add(row);
            return res;
        }

    }
}