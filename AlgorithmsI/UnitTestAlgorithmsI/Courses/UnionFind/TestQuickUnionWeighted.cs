using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsI.Courses.UnionFind;
using System.Collections.Generic;

namespace UnitTestAlgorithmsI
{
    [TestClass]
    public class TestQuickUnionWeighted
    {
        private int CountConnectedComponents(List<int> components)
        {
            int count = 0;
            for (int i = 0; i < components.Count; i++)
            {
                int root = components[i];
                if (i == root)
                {
                    count++;
                    continue;
                }
            }

            return count;
        }

        [TestMethod]
        public void QuickUnionWeighted_Union()
        {
            QuickUnionWeighted qf = new QuickUnionWeighted(100);
            List<int> components;

            /* Test union of two nodes */
            qf.Union(0, 1);
            components = qf.Components;
            Assert.AreEqual(qf.Root(components[0]), qf.Root(components[1]));
            Assert.AreEqual(CountConnectedComponents(components), components.Count - 1);

            /* Test union of three nodes */
            qf.Union(1, 2);
            components = qf.Components;
            Assert.AreEqual(qf.Root(components[0]), qf.Root(components[1]));
            Assert.AreEqual(qf.Root(components[1]), qf.Root(components[2]));
            Assert.AreEqual(CountConnectedComponents(components), components.Count - 2);

            /* Test random unions */
            Random random = new Random();
            List<Tuple<int, int>> connections = new List<Tuple<int, int>>();
            for (int i = 0; i < 100; i++)
            {
                int p = random.Next(0, components.Count);
                int q = random.Next(0, components.Count);
                connections.Add(new Tuple<int, int>(p, q));
                qf.Union(p, q);
            }

            components = qf.Components;
            foreach (var con in connections)
            {
                Assert.AreEqual(qf.Root(con.Item1), qf.Root(con.Item2));
            }
        }

        [TestMethod]
        public void QuickUnionWeighted_Find()
        {
            QuickUnionWeighted qf = new QuickUnionWeighted(100);
            bool result;

            /* Initially, I find no path */
            result = qf.Find(0, 1);
            Assert.AreEqual(result, false);

            /* Test directly connected nodes */
            qf.Union(0, 1);
            result = qf.Find(0, 1);
            Assert.AreEqual(result, true);

            /* Test indirectly connected nodes */
            qf.Union(1, 2);
            result = qf.Find(0, 2);
            Assert.AreEqual(result, true);

            /* Test non-connected nodes */
            result = qf.Find(0, 9);
            Assert.AreEqual(result, false);

            /* Test find in an union of all nodes */
            Random random = new Random();
            List<int> components = qf.Components;
            for (int i = 3; i < components.Count; i++)
            {
                qf.Union(i - 1, i);
            }

            components = qf.Components;
            for (int i = 0; i < 100; i++)
            {
                int p = random.Next(0, components.Count);
                int q = random.Next(0, components.Count);
                result = qf.Find(p, q);
                Assert.AreEqual(result, true);
            }
            Assert.AreEqual(CountConnectedComponents(components), 1);
        }
    }
}
