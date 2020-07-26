using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend
{
    public class DotnetQueue
    {
        private int maxSize;
        private long[] instanceArray;
        private int front;
        private int rear;
        private int nItems;

        public DotnetQueue(int size)
        {
            maxSize = size;
            instanceArray = new long[maxSize];
            front = 0;
            rear = -1;
            nItems = 0;
        }

        public void Insert(long item)
        {
            if (rear == maxSize - 1) rear = -1;
            instanceArray[++rear] = item;
        }

        // take item from front of queue:
        public long Remove()
        {
            long tempArray = instanceArray[front++];
            if (front == maxSize) front = 0;
            nItems--;
            return tempArray;
        }

        public long PeekFront()
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
