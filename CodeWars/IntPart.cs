using System.Collections.Generic;

namespace CodeWars
{
    public class IntPart
    {

        public void Part(long n)
        {
            Node root = new Node(5);

        }

        public static Tree ConstructTree(int n)
        {
            Node root = new Node(n);
            Node node = root;
            for (int i = 1; i < n; i++)
            {
                Node left = new Node(1);
                Node right = new Node(n-i);
                node.AddChild(left, right);
                node = right;
            }
            
            return new Tree(root);
        }

        public static Tree[] ConstructForest(int n)
        {
            Tree[] forest = new Tree[n/2];
            for (int i = 0; i < n / 2; i++)
            {
                Node root = new Node(n);
                Tree left = ConstructTree(i + 1);
                Tree right = ConstructTree(n / 2 - i + 1);
                forest[i] = new Tree(root, left, right);
            }
            return forest;
        }
    }
}