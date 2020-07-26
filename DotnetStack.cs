using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend
{
    public class DotnetStack
    {
        private int maxSize;
        private long[] instanceArray;
        private int topOfStack;
        public DotnetStack(int stackSize)
        {
            maxSize = stackSize;
            instanceArray = new long[maxSize];
            topOfStack = -1;
        }

        // push: put item on top of the stack:
        public void Push(long item)
        {
            instanceArray[++topOfStack] = item;
        }

        // pop: take item from top of the stack:
        public long Pop()
        {
            return instanceArray[topOfStack--];
        }

        // peek: peek at top of the stack:
        public long Peek()
        {
            return instanceArray[topOfStack];
        }

        public bool IsEmpty()
        {
            return topOfStack == -1;
        }

        public bool IsFull()
        {
            return topOfStack == maxSize -1;
        }
    }
}
