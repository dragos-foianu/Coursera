using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsI.Courses.UnionFind;
using System.Collections.Generic;

using AlgorithmsI.Courses.Sort;

namespace UnitTestAlgorithmsI
{
    [TestClass]
    public class TestSortingAlgorithm
    {
        private Random rnd;

        [TestInitialize]
        public void MergeSort_Init()
        {
            rnd = new Random();
        }

        private void TestEmptyList(ISortingAlgorithm sort)
        {
            IComparable[] a = new IComparable[0];
            sort.Sort(ref a);
        }

        private void TestRandomInts(ISortingAlgorithm sort)
        {
            /* Randomize numbers 0..49 */
            IComparable[] a = Enumerable.Range(0, 50).OrderBy(r => rnd.Next()).Select(x => x as IComparable).ToArray();
            sort.Sort(ref a);

            /* Make sure they are sorted */
            for (int i = 1; i < a.Length; i++)
            {
                Assert.AreEqual(true, a[i - 1].CompareTo(a[i]) < 0);
            }
        }

        [TestMethod]
        public void MergeSort_EmptyList()
        {
            TestEmptyList(new MergeSort());
        }

        [TestMethod]
        public void MergeSort_RandomInts()
        {
            TestRandomInts(new MergeSort());
        }

        [TestMethod]
        public void BottomUpMergeSort_EmptyList()
        {
            TestEmptyList(new BottomUpMergeSort());
        }

        [TestMethod]
        public void BottomUpMergeSort_RandomInts()
        {
            TestRandomInts(new BottomUpMergeSort());
        }
    }
}
