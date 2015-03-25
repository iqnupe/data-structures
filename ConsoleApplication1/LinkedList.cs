using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
   public class LinkedList<T>
   {
      private ListNode<T> _current;
      private ListNode<T> _head;

      public LinkedList()
      {
         Count = 0;
         _head = null;
      }

      public int Count { get; private set; }

      public ListNode<T> Head
      {
         get { return _head; }
         set { _head = value; }
      }

      public ListNode<T> Current
      {
         get { return _current; }
      }

      public void Add(T data)
      {
         Count++;
         var newNode = new ListNode<T> { Content = data };

         if (_head == null)
            _head = newNode;
         else
            _current.Next = newNode;

         _current = newNode;
      }

      public void Delete(int position)
      {
         if (position == 0)
            _head = _current = null;

         if (position <= 1 || position > Count) return;

         var searchNode = _head;
         ListNode<T> lastNode = null;

         var count = 0;

         while (searchNode != null)
         {
            if (count == position)
               lastNode.Next = searchNode.Next;
            count++;

            lastNode = searchNode;
            searchNode = searchNode.Next;
         }
      }

      public ListNode<T> Retrieve(int position)
      {
         ListNode<T> retval = null;
         ListNode<T> searchNode = _head;

         var count = 0;

         while (retval == null && searchNode != null)
         {
            if (count == position)
               retval = searchNode;
            count ++;
            searchNode = searchNode.Next;
         }

         return retval;
      }
   }
}