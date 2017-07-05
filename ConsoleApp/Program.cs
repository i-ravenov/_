using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Gray;

            Tree tree = IntPart.ConstructTree(5);
            tree.ShowTree();

            Console.WriteLine(10.GetHashCode());
            
            Console.ReadKey();
        }
    }



}
