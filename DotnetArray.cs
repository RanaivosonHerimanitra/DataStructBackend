using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStruct
{
    public class DotnetArray<T>
    {
        private T[] instanceArray;
        private int nElemens;

        // le constructeur de l Array
        public DotnetArray(int maxElement)
        {
            instanceArray = new T[maxElement];
            nElemens = 0;
        }
        // Naive version
        public bool Find(T searchKey)
        {
            int j;
            for (j = 0; j < nElemens; j++)
            {
                if (instanceArray[j].Equals(searchKey))
                {
                    return true;
                }
            }
            return false;
        }

        // Binary search
        public int BinarySearch(long searchKey)
        {
            int lowerBound = 0;
            int upperBound = nElemens - 1;
            int currentIndex;
            while (true)
            {
                currentIndex = (lowerBound + upperBound)/ 2;
                if (instanceArray[currentIndex].Equals(searchKey))
                {
                    return currentIndex;
                } else if (lowerBound > upperBound)
                {
                    return -1;
                } else
                {
                    // expect an ordered array:
                    var tmpArray = instanceArray[currentIndex] as long?;
                    if (tmpArray < searchKey)
                    {
                        lowerBound = currentIndex + 1;
                    } else
                    {
                        upperBound = currentIndex - 1;
                    }
                }
            }
        }

        public void Insert(T value)
        {
            instanceArray[nElemens] = value;
            nElemens += 1;
        }

        public bool Delete(T value)
        {
            int j;
            for (j = 0; j < nElemens; j++)
            {
                if (instanceArray[j].Equals(value))
                {
                    // rempli l espace memoire vide
                    // decalage a gauche
                    // value at k th will be erased
                    for (int k = j; k < nElemens; k++)
                    {
                        instanceArray[k] = instanceArray[k + 1];
                    }
                    // decremente le nbre total d element car on a perdu 1:
                    nElemens -= 1;
                    return true;
                }
            }
            return false;
        }

        public T[] toArray()
        {
            return instanceArray as T[];
        }
    }
}
