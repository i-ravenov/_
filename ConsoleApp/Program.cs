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

            
            Tree[] forest = IntPart.ConstructForest(5);
            foreach (var tree1 in forest)
            {
                tree1.ShowTree();
            }

            Console.ReadKey();
        }
    }



}
