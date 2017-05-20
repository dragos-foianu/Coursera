using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsI.Courses.UnionFind
{
    /**
     * Operations:
     *  Initialize:     O(n)
     *  Union:          O(log*n)
     *  Find:           O(logn)
     */
    public class QuickUnionWeighted
    {
        private List<int> components;
        private List<int> size;

        /**
         * Provides a copy of the internal connected components list.
         */
        public List<int> Components { get { return new List<int>(components); } }

        public QuickUnionWeighted(int n)
        {
            components = Enumerable.Range(0, n).ToList();
            size = Enumerable.Repeat(1, n).ToList();
        }

        public void Union(int p, int q)
        {
            int rp = Root(p);
            int rq = Root(q);
            if (rp == rq) return;

            /* pick the smaller tree and set the root of the larger tree to it */
            if (size[rp] < size[rq])
            {
                components[rp] = rq;
                size[rq] += size[rp];
            }
            else
            {
                components[rq] = rp;
                size[rp] += size[rq];
            }
        }

        public bool Find(int p, int q)
        {
            return Root(p) == Root(q);
        }

        /**
         * Provides the root id of the connected component which i is part of.
         */
        public int Root(int i)
        {
            while (i != components[i])
            {
                /* Before moving the root, move to the grandparent.
                 * This halves the tree size.
                 * An additional optimization is flattening the tree completely.
                 */
                components[i] = components[components[i]];
                i = components[i];
            }
            return i;
        }
    }
}
