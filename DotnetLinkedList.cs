using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace DataStructBackend
{
    /*
     * Linked list with simple operation:
     * inserting an item at the beginning of the list
     * deleting an item at the beginning of the list
     */
    public class DotnetLinkedList
    {
        public int iData;
        public decimal dData;
        public DotnetLinkedList first;
        public DotnetLinkedList next;

        public DotnetLinkedList(int id, decimal value)
        {
            iData = id;
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
    }
}
