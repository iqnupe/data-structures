using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
   class Program : ConsoleAppBase
   {
      static void Main(string[] args)
      {
         var input = Console.ReadLine();
         Console.WriteLine(ReverseString(input));


         Console.WriteLine("Press any key to exit....");
         Console.ReadKey();

      }
   }
}
