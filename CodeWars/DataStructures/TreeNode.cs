using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars.DataStructures
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int value, TreeNode left, TreeNode right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public TreeNode(int value)
        {
            this.value = value;
        }

        public override bool Equals(Object other)
        {
            var tn = other as TreeNode;
            return Equals(this, tn);
        }
            
        private bool Equals(TreeNode tn1, TreeNode tn2)
        {
            if (tn1 == tn2) return true;
            if ((tn1 == null) || (tn2 == null)) return false;

            // Do data checks and recursion of tree
            return ((tn1.value == tn2.value) && Equals(tn1.left, tn2.left)
                                           && Equals(tn1.right, tn2.right));
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
