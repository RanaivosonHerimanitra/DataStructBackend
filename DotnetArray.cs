﻿using System;
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
        public int[] visitedIndexOnBinarySearch = { };
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
        public BinarySearchResult BinarySearch(long[] currentArray, long searchKey)
        {
            int lowerBound = 0;
            int upperBound = nElemens - 1;
            int currentIndex;
            Array.Sort(instanceArray);
            while (true)
            {
                currentIndex = (lowerBound + upperBound)/ 2;
                visitedIndexOnBinarySearch.Append(currentIndex);
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
        public int[] VisitedIndex {get;set;}
        public bool Found { get; set; }
    }

    public class BinarySearchQuery
    {
        public long[] Array { get; set; }
        public long searchKey { get; set; }
    }
}
