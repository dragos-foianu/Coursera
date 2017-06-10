using System;

namespace AlgorithmsI.Courses.Heap
{
    public interface IBinaryHeap
    {
        void Insert(IComparable item);
        IComparable Peek();
        IComparable Delete();
    }
}
