import java.util.Iterator;

/**
 * Implementation of a deque.
 */
public class Deque<Item> implements Iterable<Item> {

    private Node head;
    private Node tail;
    private int size;

    private class Node {
        private Item value;
        private Node next;
        private Node prev;
    }

    public Deque() {
        size = 0;
        head = null;
        tail = null;
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
     * Adds an item to the front of the deque.
     * @param item the item to be added.
     */
    public void addFirst(Item item) {
        if (item == null)
            throw new java.lang.NullPointerException();
        
        Node n = new Node();
        n.value = item;
        n.next = head;

        if (head != null)
            head.prev = n;
        head = n;

        size++;
        /* if this is the first element that has been added, it must also be the tail */
        if (size == 1)
            tail = head;
    }

    /**
     * Adds an item to the back of the deque.
     * @param item the item to be added.
     */
    public void addLast(Item item) {
        if (item == null)
            throw new java.lang.NullPointerException();

        Node n = new Node();
        n.value = item;
        n.prev = tail;

        if (tail != null)
            tail.next = n;
        tail = n;

        size++;
        /* if this is the first element that has been added, it must also be the head */
        if (size == 1)
            head = tail;
    }

    /**
     * Removes and returns the item at the front of the deque.
     * @return item at the front of the deque
     */
    public Item removeFirst() {
        if (isEmpty())
            throw new java.util.NoSuchElementException();

        if (head.next != null)
            head.next.prev = null;

        Item value = head.value;
        head = head.next;

        size--;
        return value;
    }

    /**
     * Removes and returns the item at the back of the deque.
     * @return item at the back of the deque
     */
    public Item removeLast() {
        if (isEmpty())
            throw new java.util.NoSuchElementException();

        if (tail.prev != null)
            tail.prev.next = null;

        Item value = tail.value;
        tail = tail.prev;

        size--;
        return value;
    }

    /**
     * Returns an iterator that iterates over the items of the deque.
     * @return a deque iterator
     */
    public Iterator<Item> iterator() {
        return new DequeIterator();
    }

    /**
     * Implementation of the iterator.
     */
    private class DequeIterator implements Iterator<Item> {
        private Node crt;

        public DequeIterator() {
            crt = head;
        }

        @Override
        public boolean hasNext() {
            return crt != null;
        }

        @Override
        public Item next() {
            if (hasNext()) {
                Item crtItem = crt.value;
                crt = crt.next;
                return crtItem;
            }
            throw new java.util.NoSuchElementException();
        }

        @Override
        public void remove() {
            throw new java.lang.UnsupportedOperationException();
        }
    }
}