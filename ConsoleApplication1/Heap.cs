using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public partial class Heap<T>
           where T : IComparable<T>
   {
      private BinaryTreeNode<T> root;

      public T Peek
      {
         get
         {
            if (root == null)
            {
               return default(T);
            }
            return root.Value;
         }
      }
      public int Count { get; private set; }

      /// <summary>
      /// Adds an element to the heap
      /// </summary>
      /// <param name="element"></param>
      public void Add(T element)
      {
         if (root == null)
         {
            root = new BinaryTreeNode<T>(element);
            Count++;
            return;
         }

         var queue = new Queue<BinaryTreeNode<T>>();
         queue.Enqueue(root);
         while (queue.Any())
         {
            var node = queue.Dequeue();
            if (node.Left == null)
            {
               node.Left = new BinaryTreeNode<T>(element);
               break;
            }
            else
            {
               queue.Enqueue(node.Left);
            }
            if (node.Right == null)
            {
               node.Left = new BinaryTreeNode<T>(element);
               break;
            }
            else
            {
               queue.Enqueue(node.Right);
            }
         }
         //Restore heap property
         root = Heapify(root);
         Count++;
      }

      private BinaryTreeNode<T> Heapify(BinaryTreeNode<T> root)
      {

         root.Right = Heapify(root.Right);
         root.Left = Heapify(root.Left);
         int compareRight = root.Value.CompareTo(root.Right.Value);
         if (compareRight > 0)
         {
            //root is bigger than right
            SwapData(root, root.Right);
         }
         int compareLeft = root.Value.CompareTo(root.Left.Value);
         if (compareLeft > 0)
         {
            //root is bigger than left
            SwapData(root, root.Left);
         }
         return root;
      }

      private void SwapData(BinaryTreeNode<T> node1, BinaryTreeNode<T> node2)
      {
         T tempValue = node1.Value;
         node1.Value = node2.Value;
         node2.Value = tempValue;
      }

      public T GetMin()
      {
         if (root == null)
         {
            return default(T);
         }

         return root.Value;
      }

      private BinaryTreeNode<T> LastNode()
      {
         if (root == null)
         {
            return null;
         }

         var queue = new Queue<BinaryTreeNode<T>>();
         queue.Enqueue(root);
         Node<T> last = root;

         while (queue.Any())
         {
            var current = queue.Dequeue();
            last = current;
            if (current.Left != null)
            {
               queue.Enqueue(current.Left);
            }
            if (current.Right != null)
            {
               queue.Enqueue(current.Right);
            }
         }
         return last;
      }

      public T RemoveMin()
      {
         if (root == null)
         {
            return default(T);
         }

         var lastNode = LastNode();

         if (lastNode.Parent.Right == lastNode)
         {
            lastNode.Parent.Right = null;
         }
         if (lastNode.Parent.Left == lastNode)
         {
            lastNode.Parent.Left = null;
         }
         SwapData(root, lastNode);
         root = Heapify(root);
         Count--;
         return lastNode.Value;
      }
   }
}
