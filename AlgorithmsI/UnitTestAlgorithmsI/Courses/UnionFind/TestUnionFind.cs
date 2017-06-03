using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsI.Courses.UnionFind;

namespace UnitTestAlgorithmsI.Courses.UnionFind
{
    [TestClass]
    public class TestUnionFind
    {
        private int CountConnectedComponents(List<int> components)
        {
            HashSet<int> set = new HashSet<int>(components);
            return set.Count;
        }

        private void TestUnion(IUnionFind uf)
        {
            Assert.AreEqual(100, uf.Components().Count, "The given UnionFind algorithm must be defined for 100 nodes");

            List<int> components;

            /* Test union of two nodes */
            uf.Union(0, 1);
            components = uf.Components();
            Assert.AreEqual(components[0], components[1]);
            Assert.AreEqual(CountConnectedComponents(components), components.Count - 1);

            /* Test union of three nodes */
            uf.Union(1, 2);
            components = uf.Components();
            Assert.AreEqual(components[0], components[1]);
            Assert.AreEqual(components[1], components[2]);
            Assert.AreEqual(CountConnectedComponents(components), components.Count - 2);

            /* Test random unions */
            Random random = new Random();
            List<Tuple<int, int>> connections = new List<Tuple<int, int>>();
            for (int i = 0; i < components.Count; i++)
            {
                int p = random.Next(0, components.Count);
                int q = random.Next(0, components.Count);
                connections.Add(new Tuple<int, int>(p, q));
                uf.Union(p, q);
            }

            components = uf.Components();
            foreach (var con in connections)
            {
                Assert.AreEqual(components[con.Item1], components[con.Item2]);
            }
        }

        private void TestFind(IUnionFind uf)
        {
            Assert.AreEqual(100, uf.Components().Count, "The given UnionFind algorithm must be defined for 100 nodes");

            bool result;

            /* Initially, I find no path */
            result = uf.Find(0, 1);
            Assert.AreEqual(result, false);

            /* Test directly connected nodes */
            uf.Union(0, 1);
            result = uf.Find(0, 1);
            Assert.AreEqual(result, true);

            /* Test indirectly connected nodes */
            uf.Union(1, 2);
            result = uf.Find(0, 2);
            Assert.AreEqual(result, true);

            /* Test non-connected nodes */
            result = uf.Find(0, 9);
            Assert.AreEqual(result, false);

            /* Test find in an union of all nodes */
            Random random = new Random();
            List<int> components = uf.Components();
            for (int i = 3; i < components.Count; i++)
            {
                uf.Union(i - 1, i);
            }

            components = uf.Components();
            for (int i = 0; i < components.Count; i++)
            {
                int p = random.Next(0, components.Count);
                int q = random.Next(0, components.Count);
                result = uf.Find(p, q);
                Assert.AreEqual(result, true);
            }
            Assert.AreEqual(CountConnectedComponents(components), 1);
        }

        [TestMethod]
        public void TestQuickFind()
        {
            TestUnion(new QuickFind(100));
            TestFind(new QuickFind(100));
        }

        [TestMethod]
        public void TestQuickUnion()
        {
            TestUnion(new QuickUnion(100));
            TestFind(new QuickUnion(100));
        }

        [TestMethod]
        public void TestQuickUnionWeighted()
        {
            TestUnion(new QuickUnionWeighted(100));
            TestFind(new QuickUnionWeighted(100));
        }
    }
}