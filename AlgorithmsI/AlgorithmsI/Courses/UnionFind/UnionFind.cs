using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.UnionFind
{
    public interface UnionFind
    {
        /**
         * Connects two nodes.
         */
        void Union(int p, int q);

        /**
         * Checks if two nodes are connected.
         */
        bool Find(int p, int q);
    }

}
