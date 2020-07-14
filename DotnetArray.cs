using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStruct
{
    public class DotnetArray<T>
    {
        private T[] instanceArray;
        private static int MAX_ELEMENTS = 18;
        private int nElemens;
        public List<int> visitedIndexOnBinarySearch = new List<int>();
        public bool Found;
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
        // oriented to be exposed at an API call
        public BinarySearchResult BinarySearch(long[] currentArray, long searchKey)
        {
            int lowerBound = 0;
            int upperBound = currentArray.Length - 1;
            int currentIndex;
            int k = 0;
            Array.Sort(instanceArray);
           
            while (true)
            {
                currentIndex = (lowerBound + upperBound)/ 2;
                visitedIndexOnBinarySearch.Add(currentIndex);
                if (currentArray[currentIndex] == searchKey)
                {
                    this.Found = true;
                    return new BinarySearchResult() { Found = this.Found, VisitedIndex = visitedIndexOnBinarySearch};
                } else if (lowerBound > upperBound)
                {
                    this.Found = false;
                    return new BinarySearchResult() { Found = this.Found, VisitedIndex = visitedIndexOnBinarySearch };
                }
                else
                {
                    if (currentArray[currentIndex] < searchKey)
                    {
                        lowerBound = currentIndex + 1;
                    } else
                    {
                        upperBound = currentIndex - 1;
                    }
                }
                k += 1;
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
    public class BinarySearchResult
    {
        public List<int> VisitedIndex {get;set;}
        public bool Found { get; set; }
    }

    public class BinarySearchQuery
    {
        public long[] Array { get; set; }
        public long SearchKey { get; set; }
    }
}
