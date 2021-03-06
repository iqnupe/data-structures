﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   public class Node<T>
   {
      public Node() {}

      public Node(T data) : this(data, null) { }

      public Node(T data, NodeList<T> neighbors)
      {
         Value = data;
         Neighbors = neighbors;
      }

      public T Value { get; set; }

      protected NodeList<T> Neighbors { get; set; }
   }
}
