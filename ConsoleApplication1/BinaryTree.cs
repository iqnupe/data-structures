using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public class BinaryTree<T>
   {
      public BinaryTree()
      {
         Root = null;
      }

      public virtual void Clear()
      {
         Root = null;
      }
      public BinaryTreeNode<T> Root { get; set; }
   }
}
