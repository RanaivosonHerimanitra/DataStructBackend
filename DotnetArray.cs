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
        private int nElemens;
        public List<int> visitedIndexOnBinarySearch = new List<int>();
        public IEnumerable visitedIndexOnLinearSearch = new List<int>();
        public bool found;
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
        // O(logN), each comparison is function 2**n, so to find the average step, we log so logN
        public SearchResult BinarySearch(long[] currentArray, long searchKey)
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
                    this.found = true;
                    return new SearchResult() { Found = this.found, VisitedIndex = visitedIndexOnBinarySearch };
                } else if (lowerBound > upperBound)
                {
                    this.found = false;
                    return new SearchResult() { Found = this.found, VisitedIndex = visitedIndexOnBinarySearch };
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

        // Linear search
        // oriented to be exposed at an API call
        // O(N), if the list is ordered and searchKey is the last item:
        public SearchResult LinearSearch(long[] currentArray, long searchKey)
        {
            for (int currentIndex = 0; currentIndex < currentArray.Length; currentIndex++)
            {
                if (currentArray[currentIndex] == searchKey)
                {
                    return new SearchResult() { Found = this.found, VisitedIndex = (List<int>)Enumerable.Range(0, currentIndex) };
                }
            }
            return new SearchResult() { Found = false, VisitedIndex = (List<int>)Enumerable.Range(0,currentArray.Length) };
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

    public class SearchResult
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
