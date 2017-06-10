using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AlgorithmsI.Courses.Heap;

namespace UnitTestAlgorithmsI.Courses.Heap
{
    [TestClass]
    public class TestBinaryHeap
    {
        private Random rnd;

        [TestInitialize]
        public void MergeSort_Init()
        {
            rnd = new Random();
        }

        private enum HeapType {
            MIN_HEAP,
            MAX_HEAP
        }

        private void TestInsert(IBinaryHeap bh, HeapType ht)
        {
            IComparable[] a = Enumerable.Range(0, 50).OrderBy(r => rnd.Next()).Select(x => x as IComparable).ToArray();

            IComparable expectedRoot = a[0];
            bh.Insert(a[0]);
            Assert.AreEqual(0, bh.Peek().CompareTo(a[0]));

            for (int i = 1; i < a.Length; i++)
            {
                if (ht == HeapType.MAX_HEAP && a[i].CompareTo(expectedRoot) > 0)
                    expectedRoot = a[i];
                if (ht == HeapType.MIN_HEAP && a[i].CompareTo(expectedRoot) < 0)
                    expectedRoot = a[i];

                bh.Insert(a[i]);
                Assert.AreEqual(expectedRoot, bh.Peek());
            }
        }

        private void TestRemove(IBinaryHeap bh, HeapType ht)
        {
            IComparable[] a = Enumerable.Range(0, 50).OrderBy(r => rnd.Next()).Select(x => x as IComparable).ToArray();

            IComparable[] sorted = new IComparable[a.Length];
            a.CopyTo(sorted, 0);
            Array.Sort(sorted);

            IComparable expectedRoot = null;
            IComparable expectedNext = null;
            if (ht == HeapType.MAX_HEAP)
            {
                expectedRoot = sorted[a.Length - 1];
                expectedNext = sorted[a.Length - 2];
            }
            else if (ht == HeapType.MIN_HEAP)
            {
                expectedRoot = sorted[0];
                expectedNext = sorted[1];
            }

            for (int i = 0; i < a.Length; i++)
                bh.Insert(a[i]);

            IComparable root = bh.Delete();
            IComparable next = bh.Delete();
            Assert.AreEqual(0, root.CompareTo(expectedRoot));
            Assert.AreEqual(0, next.CompareTo(expectedNext));

            for (int i = 0; i < a.Length - 2; i++)
                bh.Delete();

            try
            {
                bh.Delete();
                throw new Exception();
            } catch(IndexOutOfRangeException)
            {
            } catch(Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestMaxBinaryHeap()
        {
            MaxBinaryHeap mbh = new MaxBinaryHeap();
            TestInsert(mbh, HeapType.MAX_HEAP);

            mbh = new MaxBinaryHeap();
            TestRemove(mbh, HeapType.MAX_HEAP);
        }

        [TestMethod]
        public void TestMinBinaryHeap()
        {
            MinBinaryHeap mbh = new MinBinaryHeap();
            TestInsert(mbh, HeapType.MIN_HEAP);

            mbh = new MinBinaryHeap();
            TestRemove(mbh, HeapType.MIN_HEAP);
        }
    }
}
