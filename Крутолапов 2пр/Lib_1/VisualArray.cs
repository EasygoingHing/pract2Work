using LibArray;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_1
{
    internal static class VisualArray
    {       
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
