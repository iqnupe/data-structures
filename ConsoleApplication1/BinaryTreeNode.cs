using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public class BinaryTreeNode<T> : Node<T>
   {
      public BinaryTreeNode() : base() { }

      public BinaryTreeNode(T data) : base(data, null) { }

      public BinaryTreeNode(T data, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
      {
         base.Value = data;
         var children = new NodeList<T>(2);
         children[0] = left;
         children[1] = right;

         Neighbors = children;
      }

      public BinaryTreeNode<T> Left
      {
         get
         {
            if (Neighbors == null)
               return null;

            return (BinaryTreeNode<T>)Neighbors[0];
         }
         set
         {
            if (Neighbors == null)
               Neighbors = new NodeList<T>(2);
            Neighbors[0] = value;
         }
      }

      public BinaryTreeNode<T> Right
      {
         get
         {
            if (Neighbors == null)
               return null;
            return (BinaryTreeNode<T>)Neighbors[1];
         }
         set
         {
            if (Neighbors == null)
               Neighbors = new NodeList<T>(2);
            Neighbors[1] = value;
         }
      }
   }
}
