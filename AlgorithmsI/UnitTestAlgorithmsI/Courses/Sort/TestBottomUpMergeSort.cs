using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsI.Courses.UnionFind;
using System.Collections.Generic;

using AlgorithmsI.Courses.Sort;

namespace UnitTestAlgorithmsI
{
    [TestClass]
    public class TestBottomUpMergeSort
    {
        private Random rnd;
        private SortingAlgorithm sort;

        [TestInitialize]
        public void BottomUpMergeSort_Init()
        {
            rnd = new Random();
            sort = new BottomUpMergeSort();
        }

        [TestMethod]
        public void BottomUpMergeSort_EmptyList()
        {
            IComparable[] a = new IComparable[0];
            sort.Sort(ref a);
        }

        [TestMethod]
        public void BottomUpMergeSort_RandomInts()
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
    }
}
