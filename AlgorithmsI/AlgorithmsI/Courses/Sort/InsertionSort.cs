using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.Sort
{
    public class InsertionSort : ISortingAlgorithm
    {
        public void Sort(ref IComparable[] a)
        {
            int N = a.Length;
            for (int j = 1; j < N; j++)
            {
                IComparable key = a[j];

                int i = j - 1;
                while (i >= 0 && key.CompareTo(a[i]) < 0)
                {
                    a[i + 1] = a[i];
                    i--;
                }
                a[i + 1] = key;
            }
        }
    }
}
