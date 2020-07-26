using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend
{
    public class DotnetSort
    {
        private long[] instanceArray;
        private int nElems;

        public DotnetSort(int max)
        {
            instanceArray = new long[max];
            nElems = 0;
        }

        public void Insert(long value)
        {
            instanceArray[nElems] = value;
            nElems++;
        }

        public void BubbleSort()
        {
            int outer;
            int inner;
            for (outer = nElems -1; outer > 1; outer--)
            {
                for(inner = 0; inner < outer; outer--)
                {
                    if (instanceArray[inner] > instanceArray[inner + 1]) Swap(inner, inner + 1);
                }
            }
        }

        public void Swap(int one, int two)
        {
            long valuePreviouslyAtOne = instanceArray[one];
            instanceArray[one] = instanceArray[two];
            instanceArray[two] = valuePreviouslyAtOne;
        }
    }
}
