using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
   public class Graph<T> : IEnumerable<T>
   {
      private NodeList<T> nodeSet;

      public Graph() : this(null) { }

      public Graph(NodeList<T> nodeSet)
      {
         if (nodeSet == null)
            this.nodeSet = new NodeList<T>();
         else
            this.nodeSet = nodeSet;
      }

      public NodeList<T> Nodes
      {
         get { return nodeSet; }
      }

      public int Count
      {
         get { return nodeSet.Count; }
      }

      public IEnumerator<T> GetEnumerator()
      {
         throw new NotImplementedException();
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      public void AddDirectedEdge(T from, T to, int cost)
      {
         AddDirectedEdge(new GraphNode<T> {Value = from}, new GraphNode<T> {Value = to}, cost);
      }

      public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
      {
         if (nodeSet.Contains(from) && nodeSet.Contains(to))
         {
            var nodeFrom = (GraphNode<T>)nodeSet.FindByValue(from.Value);
            nodeFrom.Neighbors.Add(to);
            nodeFrom.Costs.Add(cost);
         }
      }

      public void AddNode(GraphNode<T> node)
      {
         // adds a node to the graph
         nodeSet.Add(node);
      }

      public void AddNode(T value)
      {
         // adds a node to the graph
         nodeSet.Add(new GraphNode<T>(value));
      }

      public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
      {
         if (nodeSet.Contains(from) && nodeSet.Contains(to))
         {
            var nodeFrom = (GraphNode<T>)nodeSet.FindByValue(from.Value);
            var nodeTo = (GraphNode<T>)nodeSet.FindByValue(from.Value);

            nodeFrom.Neighbors.Add(to);
            nodeFrom.Costs.Add(cost);

            nodeTo.Neighbors.Add(from);
            nodeTo.Costs.Add(cost);
         }
      }

      public void AddUndirectedEdge(T from, T to, int cost)
      {
         AddUndirectedEdge(new GraphNode<T> { Value = from }, new GraphNode<T> { Value = to }, cost);
      }

      public bool AreRelated(GraphNode<T> from, GraphNode<T> to)
      {
         if (!nodeSet.Contains(from) || !nodeSet.Contains(to))
            return false;

         var inFrom = ((GraphNode<T>)nodeSet.FindByValue(from.Value)).Neighbors.Contains(to);
         var inTo = ((GraphNode<T>)nodeSet.FindByValue(to.Value)).Neighbors.Contains(from);

         return (inFrom && inTo);
      }

      public bool Contains(T value)
      {
         return nodeSet.FindByValue(value) != null;
      }

      public GraphNode<T> GetNode(T value)
      {
         return (GraphNode<T>)nodeSet.FindByValue(value);
      }

      public bool Remove(T value)
      {
         // first remove the node from the nodeset...
         var nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
         if (nodeToRemove == null) // node was not found...
            return false;

         nodeSet.Remove(nodeToRemove);

         //enumerate through each node in the nodeSet, removing edges to this node....
         foreach (GraphNode<T> node in nodeSet)
         {
            var idx = node.Neighbors.IndexOf(nodeToRemove);
            if (idx != -1)
            {
               // remove the reference to the node and associated cost...
               node.Neighbors.RemoveAt(idx);
               node.Costs.RemoveAt(idx);
            }
         }

         return true;
      }

      public Graph<T> Union(Graph<T> candidate)
      {
         // create new graph to be unifed
         var newGraph = new Graph<T>(new NodeList<T>());

         // for each node in the source graph
         foreach (var node in Nodes)
            // build the new graph if it doesn't already exist
            if (!newGraph.Contains(node.Value))
               newGraph.AddNode(node.Value);

         // for each node in the source graph
         foreach (GraphNode<T> node in Nodes)
            // for each neighbor of that node
            foreach (GraphNode<T> neighbor in node.Neighbors)
               // join the two in the new graph between neighbor and node if there isn't one already
               if (!node.Neighbors.Contains(neighbor))
                  newGraph.AddUndirectedEdge(node, neighbor, -1);

         // for each node in the candidate graph
         foreach (GraphNode<T> node in candidate.Nodes)
            // build the new graph if it doesn't already exist
            if (!newGraph.Contains(node.Value))
               newGraph.AddNode(node.Value);

         foreach (GraphNode<T> node in candidate.Nodes)
            // for each neighbor of that node
            foreach (GraphNode<T> neighbor in node.Neighbors)
               if (!node.Neighbors.Contains(neighbor))
                  newGraph.AddUndirectedEdge((GraphNode<T>)newGraph.Nodes.FindByValue(node.Value), (GraphNode<T>)newGraph.Nodes.FindByValue(neighbor.Value), -1);

         return newGraph;
      }
   }
}