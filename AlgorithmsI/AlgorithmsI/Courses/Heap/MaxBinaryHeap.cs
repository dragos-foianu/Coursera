using System;

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
            while (index != 0 && (index - 1) / 2 >= 0)
            {
                int parent = (index - 1) / 2;
                if (heap[index].CompareTo(heap[parent]) > 0)
                Swap(index, parent);
                index = parent;
            }
        }

        private void Sink()
        {
            int index = 0;
            while (2 * index + 1 < size)
            {
                int left = 2 * index + 1;

                int larger = left;
                if (2 * index + 2 < size)
                {
                    int right = 2 * index + 2;
                    if (heap[right].CompareTo(heap[left]) > 0)
                        larger = right;
                }

                if (heap[index].CompareTo(heap[larger]) < 0)
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
