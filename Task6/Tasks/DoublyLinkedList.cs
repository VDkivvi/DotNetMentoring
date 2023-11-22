using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks;

public class DoublyLinkedList<T> : IDoublyLinkedList<T>
{
    private Node<T> head;
    private Node<T> tail;
    private int size;

    private class Node<T>
    {
        public T item;
        public Node<T> next;
        public Node<T> prev;
    }

    public int Length => size;


    private Node<T> NodeAt(int index)
    {
        if (index >= size || index < 0 || head == null) throw new IndexOutOfRangeException();
        var ind = 0;
        var currentNode = head;
        while (ind < index)
        {
            currentNode = currentNode.next;
            ind++;
        }

        return currentNode;
    }

    private Node<T> FindTheFirstNodeWithValue(T itemValue)
    {
        if (head == null) throw new IndexOutOfRangeException();
        var currentNode = head;
        while (currentNode != null && !currentNode.item.Equals(itemValue)) currentNode = currentNode.next;

        return currentNode;
    }

    public void AddLast(T data)
    {
        var newNode = new Node<T> { item = data };
        if (head == null)
        {
            head = newNode;
            size++;
            return;
        }

        if (tail == null)
        {
            tail = newNode;
            tail.prev = head;
            head.next = tail;
            head.prev = null;
            size++;
            return;
        }

        var prevNode = tail;
        tail = newNode;
        prevNode.next = tail;
        tail.prev = prevNode;
        size++;
    }

    public void AddFirst(T data)
    {
        var newNode = new Node<T> { item = data };
        if (head == null)
        {
            head = newNode;
            size++;
            return;
        }

        if (tail == null)
        {
            tail = head;
            tail.prev = head;
            tail.next = null;

            head = newNode;
            head.next = tail;
            size++;
            return;
        }

        var firstNode = head;
        head = newNode;
        firstNode.prev = head;
        head.next = firstNode;
        size++;
    }

    public void RemoveFirst()
    {
        var nextNode = head.next;
        head = nextNode;
        if (nextNode != null)
            head.prev = null;
        size--;
    }

    public void RemoveLast()
    {
        var lastNode = tail.prev;
        tail = lastNode;
        if (lastNode != null)
            tail.next = null;
        size--;
    }


    public void Add(T e) => AddLast(e);

    public void AddAt(int index, T e)
    {
        var newNode = new Node<T> { item = e };
        if (index > size) throw new IndexOutOfRangeException();
        if (index == size)
        {
            AddLast(e);
        }
        else
        {
            var foundNode = NodeAt(index);
            if (index == 0)
            {
                head = newNode;
                head.next = foundNode;
            }
            else
            {
                newNode.next = foundNode;
                foundNode.prev.next = newNode;
                newNode.prev = foundNode.prev;
                foundNode.prev = newNode;
            }

            size++;
        }
    }

    public T ElementAt(int index) => NodeAt(index).item;

    public void Remove(T item)
    {
        var node = FindTheFirstNodeWithValue(item);
        if (node == null) return;

        var prevNode = node.prev;
        var nextNode = node.next;

        if (prevNode != null)
            prevNode.next = nextNode;
        else
            head = nextNode;

        if (nextNode != null)
            nextNode.prev = prevNode;
        else
            tail = prevNode;

        size--;
    }

    public T RemoveAt(int index)
    {
        var nodeToRemove = NodeAt(index);
        var prevNode = nodeToRemove.prev;
        var nextNode = nodeToRemove.next;
        if (nodeToRemove.next != null) nextNode.prev = prevNode;
        prevNode.next = nextNode;
        size--;
        return nodeToRemove.item;
    }

    public IEnumerator<T> GetEnumerator() => new EnumeratorImplementation(this);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    //WITHOUT YIELD RETURN:
    private class EnumeratorImplementation : IEnumerator<T>
    {
        private int _curIndex = -1;

        private readonly DoublyLinkedList<T> _self;

        public EnumeratorImplementation(DoublyLinkedList<T> self) => _self = self;

        private bool IsIndexValid => _curIndex >= 0 && _curIndex < _self.size;
        public T Current => IsIndexValid ? _self.ElementAt(_curIndex) : throw new IndexOutOfRangeException();
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_curIndex < _self.size)
                _curIndex++;
            return IsIndexValid;
        }

        public void Reset() => _curIndex = -1;
        public void Dispose() { }
    }
}