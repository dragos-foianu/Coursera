using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsI.Courses.UnionFind
{
    public class QuickFind : UnionFind
    {
        private List<int> components;

        /**
         * Provides a copy of the internal connected components list.
         */
        public List<int> Components { get { return new List<int>(components); } }

        public QuickFind(int n)
        {
            components = Enumerable.Range(0, n).ToList();
        }

        public void Union(int p, int q)
        {
            int pid = components[p];
            int qid = components[q];

            for (int i = 0; i < components.Count; i++)
            {
                if (components[i] == pid)
                {
                    components[i] = qid;
                }
            }
        }

        public bool Find(int p, int q)
        {
            return components[p] == components[q];
        }
    }
}
