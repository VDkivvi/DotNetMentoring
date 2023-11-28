using System;
using System.Text;
using Tasks.DoNotChange;

/*
 Implement the interface IHybridFlowProcessor<T> (HybridFlowProcessor.cs) 
        using single internal item "storage" for both FILO and FIFO flows. 
        Use a Double linked list in your implementation. 
        Reusing your code from the previous task is desirable. 
 */
namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        readonly DoublyLinkedList<T> storage = new();

        public T Dequeue()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException();
           
            return storage.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            storage.AddAt(storage.Length, item);
        }

        public T Pop()
        {
            if (storage.Length == 0)
                throw new InvalidOperationException();
            storage.RemoveAt(storage.Length - 1);
            return storage.ElementAt(storage.Length -1);
        }

        public void Push(T item)
        {
            storage.AddAt(storage.Length, item);
        }

        public string GetAllItems()
        {
            var sb = new StringBuilder();
            foreach (var item in storage)
            {
                sb.Append(item).Append(" ");
            }
            return sb.ToString();
        }

    }
}
