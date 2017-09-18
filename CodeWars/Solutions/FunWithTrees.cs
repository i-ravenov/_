using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeWars.DataStructures;

namespace CodeWars.Solutions
{
    public class FunWithTrees
    {
        public static TreeNode ArrayToTree(int[] array)
        {
            return Load(array, 0);
        }

        private static TreeNode Load(int[] arr, int index)
        {
            return index >= arr.Length ? null :
                new TreeNode(arr[index], 
                Load(arr, 2 * index + 1), 
                Load(arr, 2 * index + 2));
        }
    }
}
