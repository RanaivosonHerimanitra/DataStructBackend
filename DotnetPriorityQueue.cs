using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend
{
    public class DotnetPriorityQueue<T> : DotnetQueue<T> where T : IComparable
    {
        public DotnetPriorityQueue(int size): base(size) 
        {
            maxSize = size;
            instanceArray = new T[maxSize];
            nItems = 0;
        }

        //redefinition de Insert:
        public override void Insert(T item)
        {
            int counter;
            if (nItems == 0) instanceArray[nItems++] = item;
            else
            {
                for(counter=nItems -1; counter>=0; counter--)
                {
                    if (item.CompareTo(instanceArray[counter])>=0) instanceArray[counter + 1] = instanceArray[counter];
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
        public override T Remove()
        {
            return instanceArray[--nItems];
        }

        //
        public T PeekMininimumItem()
        {
            return instanceArray[nItems - 1];
        }
    }
}
