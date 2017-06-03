using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.Sort
{
    public interface SortingAlgorithm
    {
        /**
         * Sorts an array of IComparable.
         */
        void Sort(ref IComparable[] a);
    }
}
