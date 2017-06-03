using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.Sort
{
    public class ShellSort : ISortingAlgorithm
    {
        private void Sort(ref IComparable[] a, int h)
        {
            int N = a.Length;
            for (int j = h; j < N; j++)
            {
                IComparable key = a[j];

                int i = j - h;
                while (i >= 0 && key.CompareTo(a[i]) < 0)
                {
                    a[i + h] = a[i];
                    i -= h;
                }
                a[i + h] = key;
            }
        }

        public void Sort(ref IComparable[] a)
        {
            int N = a.Length;

            /* Find the largest increment in Knuth's sequence */
            int h = 1;
            while (h < N / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                /* h-sort the array */
                Sort(ref a, h);

                /* next increment */
                h = h / 3;
            }
        }
    }
}
