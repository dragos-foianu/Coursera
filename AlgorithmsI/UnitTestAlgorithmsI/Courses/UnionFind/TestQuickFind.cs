using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsI.Courses.UnionFind;
using System.Collections.Generic;

namespace UnitTestAlgorithmsI
{
    [TestClass]
    public class TestQuickFind
    {
        private int CountConnectedComponents(List<int> components)
        {
            HashSet<int> set = new HashSet<int>(components);
            return set.Count;
        }

        [TestMethod]
        public void QuickFind_Union()
        {
            QuickFind qf = new QuickFind(10);
            List<int> components;

            /* Test union of two nodes */
            qf.Union(0, 1);
            components = qf.Components;
            Assert.AreEqual(components[0], components[1]);
            Assert.AreEqual(CountConnectedComponents(components), 9);

            /* Test union of three nodes */
            qf.Union(1, 2);
            components = qf.Components;
            Assert.AreEqual(components[0], components[1]);
            Assert.AreEqual(components[1], components[2]);
            Assert.AreEqual(CountConnectedComponents(components), 8);

            /* Test union of all nodes */
            for (int i = 3; i < components.Count; i++)
            {
                qf.Union(i - 1, i);
            }

            components = qf.Components;
            for (int i = 1; i < components.Count; i++)
            {
                Assert.AreEqual(components[i - 1], components[i]);
            }
            Assert.AreEqual(CountConnectedComponents(components), 1);
        }

        [TestMethod]
        public void QuickFind_Find()
        {
            QuickFind qf = new QuickFind(10);
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
