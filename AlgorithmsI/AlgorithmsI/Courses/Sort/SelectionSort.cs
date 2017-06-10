using System;

namespace AlgorithmsI.Courses.Sort
{
    public class SelectionSort : ISortingAlgorithm
    {
        public void Sort(ref IComparable[] a)
        {
            int N = a.Length;
            for (int i = 0; i < N; i++)
            {
                IComparable min = a[i];
                int pos = i;

                for (int j = i + 1; j < N; j++)
                {
                    if (a[j].CompareTo(min) < 0)
                    {
                        min = a[j];
                        pos = j;
                    }
                }

                a[pos] = a[i];
                a[i] = min;
            }
        }
    }
}
