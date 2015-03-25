using System.Collections.Generic;

namespace ConsoleApplication1
{
   public class ReverseLinkedList<T>
   {
      public void ReverseLinkedList(LinkedList<T> linkedList)
      {
         var start = linkedList.Head;
         LinkedListNode<T> temp = null;

// ------------------------------------------------------------
// Loop through until null node (next node of the latest node) is found
// ------------------------------------------------------------

         while (start != null)
         {
// ------------------------------------------------------------
// Swap the “Next” and “Previous” node properties
// ------------------------------------------------------------

            temp = start.Next;
            start.Next = start.Previous;
            start.Previous = temp;

// ------------------------------------------------------------
// Head property needs to point to the latest node
// ------------------------------------------------------------

            if (start.Previous == null)
            {
               linkedList.Head = start;
            }

// ------------------------------------------------------------
// Move on to the next node (since we just swapped 
// “Next” and “Previous”
// “Next” is actually the “Previous”
// ------------------------------------------------------------

            start = start.Previous;
         }

// ------------------------------------------------------------
// That's it!
// ------------------------------------------------------------
      }
   }
}