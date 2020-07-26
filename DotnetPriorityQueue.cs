using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend
{
    public class DotnetPriorityQueue : DotnetQueue
    {
        public DotnetPriorityQueue(int size): base(size) 
        {
            maxSize = size;
            instanceArray = new long[maxSize];
            nItems = 0;
        }

        //redefinition de Insert:
        public override void Insert(long item)
        {
            int counter;
            if (nItems == 0) instanceArray[nItems++] = item;
            else
            {
                for(counter=nItems -1; counter>=0; counter--)
                {
                    if (item > instanceArray[counter]) instanceArray[counter + 1] = instanceArray[counter];
                    else
                    {
                        break;
                    }
                   
                }
                instanceArray[counter + 1] = item;
                nItems++;
            }
        }

        // remove minimum item:
        public override long Remove()
        {
            return instanceArray[--nItems];
        }

        //
        public long PeekMininimumItem()
        {
            return instanceArray[nItems - 1];
        }
    }
}
