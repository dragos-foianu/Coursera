using System.Collections.Generic;

namespace AlgorithmsI.Courses.UnionFind
{
    public interface IUnionFind
    {
        /**
        * Provides a copy of the internal connected components list.
        */
        List<int> Components();

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
