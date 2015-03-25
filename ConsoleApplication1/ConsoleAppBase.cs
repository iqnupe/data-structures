using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   class ConsoleAppBase
   {
      protected static uint ReverseBytes(string input)
      {
         uint value;

         if (!uint.TryParse(input, out value))
            return default(uint);

         return (value & 0x000000FFU) << 24 | (value & 0x0000FF00U) << 8 | (value & 0x00FF0000U) >> 8 | (value & 0xFF000000U) >> 24;
      }

      protected static string ReverseString(string input)
      {
         char[] characters = input.ToCharArray();
         int len = characters.Length - 1;

         for (int i = 0; i < len; i++ , len--)
         {
            characters[i] ^= characters[len];
            characters[len] ^= characters[i];
            characters[i] ^= characters[len];
         }

         return new string(characters);
      }

      protected static void CreateBinaryTree()
      {
         var btree = new BinaryTree<int> { Root = new BinaryTreeNode<int>(1) };
         btree.Root.Left = new BinaryTreeNode<int>(2);
         btree.Root.Right = new BinaryTreeNode<int>(3);

      }
   }
}
