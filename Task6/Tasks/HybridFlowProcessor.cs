using System;
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
        public T Dequeue()
        {
            throw new NotImplementedException();
        }

        public void Enqueue(T item)
        {
            throw new NotImplementedException();
        }

        public T Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(T item)
        {
            throw new NotImplementedException();
        }
    }
}
