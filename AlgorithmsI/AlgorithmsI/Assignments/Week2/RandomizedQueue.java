import java.util.Iterator;
import edu.princeton.cs.algs4.StdRandom;

/**
 * Implementation of a randomized queue.
 */
public class RandomizedQueue<Item> implements Iterable<Item> {

    private Item[] array;
    private int capacity;
    private int size;

    public RandomizedQueue() {
        capacity = 1;
        size = 0;
        array = (Item[]) new Object[capacity];
    }

    /**
     * Is the deque empty?
     * @return true if the deque is empty, false otherwise
     */
    public boolean isEmpty() {
        return size == 0;
    }

    /**
     * Returns the number of items in the deque.
     * @return the number of items in the deque
     */
    public int size() {
        return size;
    }

    /**
     * Adds an item to the queue.
     * @param item the item to be added.
     */
    public void enqueue(Item item) {
        if (item == null)
            throw new java.lang.NullPointerException();

        /* if full, double the capacity */
        if (size == capacity)
            resize(capacity * 2);

        array[size++] = item;
    }

    /**
     * Removes and returns the item at the front of the queue.
     * @return item at the front of the queue
     */
    public Item dequeue() {
        if (isEmpty())
            throw new java.util.NoSuchElementException();

        /* if the size is a quarter of the capacity, halve the capacity */
        if (size <= capacity / 4)
            resize(capacity / 2);

        int randomIndex = StdRandom.uniform(size);
        Item selectedItem = array[randomIndex];
        size--;

        array[randomIndex] = array[size];
        array[size] = null;

        return selectedItem;
    }

    /**
     * Returns a random item without removing it.
     * @return a random item
     */
    public Item sample() {
        if (isEmpty())
            throw new java.util.NoSuchElementException();

        int randomIndex = StdRandom.uniform(size);
        return array[randomIndex];
    }

    /**
     * Resizes the array to a new capacity.
     * @param the new capacity
     */
    private void resize(int newCapacity) {
        Item[] newArray = (Item[]) new Object[newCapacity];
        for (int i = 0; i < size; i++) {
            newArray[i] = array[i];
        }
        array = newArray;
        this.capacity = newCapacity;
    }

    /**
     * Returns an iterator that iterates over the items of the randomized queue.
     * @return a randomized queue iterator
     */
    public Iterator<Item> iterator() {
        return new RandomizedQueueIterator();
    }

    /**
     * Implementation of the iterator.
     */
    private class RandomizedQueueIterator implements Iterator<Item> {

        private Item[] shuffledArray;
        private int crt;

        public RandomizedQueueIterator() {
            crt = 0;
            shuffledArray = array.clone();
            if (size > 0)
                StdRandom.shuffle(shuffledArray, 0, size);
        }

        public boolean hasNext() {
            return crt < size;
        }

        public Item next() {
            if (hasNext()) {
                return shuffledArray[crt++];
            }
            throw new java.util.NoSuchElementException();
        }

        public void remove() {
            throw new java.lang.UnsupportedOperationException();
        }
    }
}