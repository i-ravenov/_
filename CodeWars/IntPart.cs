using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class Partition
    {
        private readonly int[] _partition;

        public Partition(int a)
        {
            _partition = new[] { a };
        }

        public Partition(int[] parts)
        {
            _partition = parts;
        }

        public int Length
        {
            get { return _partition.Length; }
        }

        public override bool Equals(object obj)
        {
            Partition that = obj as Partition;
            int length = _partition.Length;
            if (that != null && length != that._partition.Length)
                return false;

            Array.Sort(this._partition);
            Array.Sort(that._partition);
            for (int i = 0; i < length; i++)
            {
                if (_partition[i] != that._partition[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return _partition.Sum();
        }

        public static Partition operator +(Partition p1, Partition p2)
        {
            return new Partition(p1._partition.Concat(p2._partition).ToArray());
        }

        public static ISet<Partition> Decart(ISet<Partition> left, ISet<Partition> right)
        {
            ISet<Partition> res = new HashSet<Partition>();

            foreach (var partL in left)
            {
                foreach (var partR in right)
                {
                    res.Add(partL + partR);
                }
            }

            return res;
        }
    }

    public class PartDictionary
    {
        private readonly IDictionary<int, ISet<Partition>> _dictionary;

        public PartDictionary(int n)
        {
            _dictionary = new Dictionary<int, ISet<Partition>>(n);
            PopulateUpToN(n);
        }

        // should return value for client, not set, string
        public ISet<Partition> this[int n]
        {
            get
            {
                if (!_dictionary.Keys.Contains(n))
                {
                    throw new Exception($"Partition for {n} haven't been calculated yet");
                }
                return _dictionary[n];
            }
        }

        private void PopulateUpToN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                _dictionary[i] = new HashSet<Partition> {new Partition(i)};
                for (int j = 1; j <= i / 2; j++)
                {
                    _dictionary[i].UnionWith(Partition.Decart(_dictionary[j],_dictionary[i-j]));
                }
            }
        }
    }


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



        
    }
}