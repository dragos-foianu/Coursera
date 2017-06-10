using System;

namespace AlgorithmsI.Courses.Sort
{
    /**
    * Operations:
    *  Merge:     O(n)
    *  Sort:      O(logn)
    *  Total:     O(nlogn)
    */
    public class BottomUpMergeSort : ISortingAlgorithm
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

        public void Sort(ref IComparable[] a)
        {
            int N = a.Length;
            IComparable[] aux = new IComparable[N];
            
            for (int sz = 1; sz < N; sz = sz + sz)
            {
                for (int lo = 0; lo < N - sz; lo += sz + sz)
                {
                    Merge(ref a, ref aux, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, N - 1));
                }
            }
        }
    }
}
