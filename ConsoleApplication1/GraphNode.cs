using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public class GraphNode<T> : Node<T>
   {
      private List<int> costs;

      public GraphNode() : base() { }

      public GraphNode(T value) : base(value) { }

      public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

      public new NodeList<T> Neighbors
      {
         get
         {
            if (Neighbors == null)
               base.Neighbors = new NodeList<T>();
            return Neighbors;
         }
      }

      public List<int> Costs
      {
         get
         {
            if (costs == null)
               costs = new List<int>();
            return costs;
         }
      }

   }
}