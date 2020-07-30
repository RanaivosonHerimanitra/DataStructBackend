using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructBackend
{
    /*
     * Linked list with simple operations:
     * inserting an item at the beginning of the chain
     * deleting an item at the beginning of the chain
     * ability to find and delete specified link
     */
    public class DotnetLinkedList
    {
        public int key;
        public decimal dData;
        public DotnetLinkedList first;
        public DotnetLinkedList next;

        public DotnetLinkedList(int id, decimal value)
        {
            key = id;
            dData = value;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void InsertFirst(int id, decimal value)
        {
            DotnetLinkedList newLink = new DotnetLinkedList(id, value);
            newLink.next = first;
            first = newLink;
        }

        public void DeleteFirst()
        {
            first = first.next;
        }

        public DotnetLinkedList FindLinear(int key)
        {
            DotnetLinkedList currentLink = first; //start at the first link item
            while (currentLink.key != key)
            {
                if (currentLink.next == null) return null;
                currentLink = currentLink.next;
            }
            return currentLink;
        }

        // assumes a non empty list:
        public DotnetLinkedList Delete(int key)
        {
            DotnetLinkedList currentLink = first;
            DotnetLinkedList previousLink = first;
            while (currentLink.key != key)
            {
                if (currentLink.next == null) return null;
                previousLink = currentLink;
                currentLink = currentLink.next;
            }
            if (currentLink == first)
            {
                first = first.next;
            }
            else
            {
                //currentLink which is the node to be deleted will be bypass
                previousLink.next = currentLink.next;
            }
            return currentLink;
        }
    }
}
