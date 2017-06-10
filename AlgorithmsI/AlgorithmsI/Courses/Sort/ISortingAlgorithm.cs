using System;

namespace AlgorithmsI.Courses.Sort
{
    public interface ISortingAlgorithm
    {
        /**
         * Sorts an array of IComparable.
         */
        void Sort(ref IComparable[] a);
    }
}
