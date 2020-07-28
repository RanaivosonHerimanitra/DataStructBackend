using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend
{
    public class DotnetQueue<T>
    {
        protected int maxSize;
        protected T[] instanceArray;
        public int front;
        public int rear;
        public int nItems;

        public DotnetQueue(int size)
        {
            maxSize = size;
            instanceArray = new T[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public virtual void Insert(T item)
        {
            if (rear == maxSize - 1) rear = -1;
            instanceArray[++rear] = item;
        }

        // take item from front of queue:
        public virtual T Remove()
        {
            T tempArray = instanceArray[front++];
            if (front == maxSize) front = 0;
            nItems--;
            return tempArray;
        }

        public T PeekFront()
        {
            return instanceArray[front];
        }

        public bool IsEmpty()
        {
            return nItems == 0;
        }

        public bool IsFull()
        {
            return nItems == maxSize;
        }

        public int Size()
        {
            return nItems;
        }
    }
}
