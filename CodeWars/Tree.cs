using System;
using System.Collections.Generic;

namespace CodeWars
{
    public class Tree
    {
        private Node _root;

        public Tree(Node root)
        {
            _root = root;
        }

        public Tree(Node root, Tree leftSubTree, Tree rightSubTree)
        {
            root.AddChild(leftSubTree._root, rightSubTree._root);
            _root = root;
        }

        public void ShowTree()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(_root);
            Console.WriteLine(_root.data.weight);
            while (queue.Count != 0)
            {
                Node curr = queue.Dequeue();
                foreach (var nd in curr.Children)
                {
                    queue.Enqueue(nd);
                    Console.Write(nd.data.weight + " ");
                }
                Console.WriteLine();
            }
        }
    }


    // Struct to safe Depth and weight of the Node
    public class Data
    {
        private int depth;

        public int Depth
        {
            get { return depth; }
            set
            {
                depth = value;
            }
        }
        public int weight;

        public Data(int w)
        {
            weight = w;
            Depth = 1;
        }
    }

    public class Node
    {
        public Data data { get; set; }

        public List<Node> Children { get; }

        public Node(int weight)
        {
            data = new Data(weight);
            Children = new List<Node>();
        }

        public void AddChild(int weight)
        {
            Node child = new Node(weight);
            child.data.Depth = this.data.Depth + 1;
            Children.Add(child);
        }

        public void AddChild(params Node[] children)
        {
            Queue<Node> queue = new Queue<Node>();
            foreach (var ch in children)
            {
                Children.Add(ch);
                queue.Enqueue(ch);
                while (queue.Count != 0)
                {
                    Node child = queue.Dequeue();
                    child.data.Depth++;
                    foreach (var x in child.Children)
                    {
                        queue.Enqueue(x);
                    }
                }
            }
        }

    }

}
