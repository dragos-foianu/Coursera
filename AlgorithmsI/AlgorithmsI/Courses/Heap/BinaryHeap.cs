using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.Heap
{
    public interface IBinaryHeap
    {
        void Insert(IComparable item);
        IComparable Peek();
        IComparable Delete();
    }
}
