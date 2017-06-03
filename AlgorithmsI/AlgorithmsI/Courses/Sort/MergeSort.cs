using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.Sort
{
    /**
    * Operations:
    *  Merge:     O(n)
    *  Sort:      O(logn)
    *  Total:     O(nlogn)
    */
    public class MergeSort : ISortingAlgorithm
    {
        private void Merge(ref IComparable[] a, ref IComparable[] aux, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;

            for (int k = lo; k <= hi; k++) {
                aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (aux[j].CompareTo(aux[i]) < 0)
                    a[k] = aux[j++];
                else
                    a[k] = aux[i++];
            }
        }

        private void Sort(ref IComparable[] a, ref IComparable[] aux, int lo, int hi)
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(ref a, ref aux, lo, mid);
            Sort(ref a, ref aux, mid + 1, hi);
            Merge(ref a, ref aux, lo, mid, hi);
        }

        public void Sort(ref IComparable[] a)
        {
            IComparable[] aux = new IComparable[a.Length];
            Sort(ref a, ref aux, 0, a.Length - 1);
        }
    }
}
