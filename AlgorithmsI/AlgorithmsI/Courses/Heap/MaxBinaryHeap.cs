using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsI.Courses.Heap
{
    public class MaxBinaryHeap : IBinaryHeap
    {
        private IComparable[] heap;
        int size;
        int capacity;

        public MaxBinaryHeap(int capacity)
        {
            size = 0;
            this.capacity = capacity;
            heap = new IComparable[capacity];
        }

        public MaxBinaryHeap() : this(1) {
        }

        public void Insert(IComparable item)
        {
            if (size == capacity)
                Resize(capacity * 2);

            heap[size++] = item;
            Swim();
        }

        public IComparable Delete()
        {
            if (size == 0)
                throw new IndexOutOfRangeException();

            IComparable item = heap[0];
            heap[0] = heap[size - 1];
            size--;
            Sink();

            if (size < capacity / 4)
                Resize(capacity / 2);

            return item;
        }

        public IComparable Peek()
        {
            if (size == 0)
                throw new IndexOutOfRangeException();
            return heap[0];
        }

        private void Resize(int newCapacity)
        {
            capacity = newCapacity;
            IComparable[] newHeap = new IComparable[newCapacity];
            for (int i = 0; i < size; i++)
                newHeap[i] = heap[i];
            heap = newHeap;
        }

        private void Swim()
        {
            int index = size - 1;
            while (heap[index].CompareTo(heap[index / 2]) > 0)
            {
                Swap(index, index / 2);
                index = index / 2;
            }
        }

        private void Sink()
        {
            int index = 0;
            while (2 * index + 1 < size)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                int larger = left;
                if (right < size && heap[right].CompareTo(heap[right]) > 0)
                    larger = right;

                if (heap[index].CompareTo(heap[larger]) > 0)
                    break;
                else
                    Swap(index, larger);
                index = larger;
            }
        }

        private void Swap(int index1, int index2)
        {
            IComparable aux = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = aux;
        }
    }
}
