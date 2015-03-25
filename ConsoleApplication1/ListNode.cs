using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public class ListNode<T>
   {
      public T Content { get; set; }
      public ListNode<T> Next { get; set; } 
   }
}
