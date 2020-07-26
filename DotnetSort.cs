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
        // O(N**2)
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

        public void SelectionSort()
        {
            int outer;
            int indexCorrespondingToMinValue;
            for (outer=0; outer<nElems -1; outer++)
            {
                indexCorrespondingToMinValue = outer;
                indexCorrespondingToMinValue= FindIndexCorrespondingToMinValueStartingAt(outer + 1, indexCorrespondingToMinValue);
                Swap(outer, indexCorrespondingToMinValue);
            }
        }

        public int FindIndexCorrespondingToMinValueStartingAt(int startAt, int indexCorrespondingToMinValue)
        {
            for (int inner = startAt; inner < nElems; inner++ )
            {
                if (instanceArray[inner]<instanceArray[indexCorrespondingToMinValue])
                {
                    return inner;
                }
            }
            return indexCorrespondingToMinValue;
        }

        public void Swap(int one, int two)
        {
            long valuePreviouslyAtOne = instanceArray[one];
            instanceArray[one] = instanceArray[two];
            instanceArray[two] = valuePreviouslyAtOne;
        }
    }
}
