using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.UnionFind
{
    /**
     * Operations:
     *  Initialize:     O(n)
     *  Union:          O(n)
     *  Find:           O(1)
     */
    public class QuickUnion
    {
        private List<int> components;

        /**
         * Provides a copy of the internal connected components list.
         */
        public List<int> Components { get { return new List<int>(components); } }

        public QuickUnion(int n)
        {
            components = Enumerable.Range(0, n).ToList();
        }

        public void Union(int p, int q)
        {
            int rp = Root(p);
            int rq = Root(q);
            components[rp] = rq;
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
                i = components[i];
            }
            return i;
        }
    }
}
