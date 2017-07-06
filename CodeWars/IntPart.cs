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

        public int Composition()
        {
            int res = 1;
            foreach (var i in _partition)
            {
                res *= i;
            }
            return res;
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
                    PopulateUpToN(n);
                }
                return _dictionary[n];
            }
        }

        public static IList<int> Map(ISet<Partition> input)
        {
            ISet<int> set = new HashSet<int>();
            foreach (var p in input)
            {
                set.Add(p.Composition());
            }
            List<int> res = set.ToList();
            res.Sort();
            return res;
        }

        public static string Reduce(IList<int> input)
        {
            int size = input.Count;
            int range = input.Last() - input.First();
            float average = input.Sum() / (float)input.Count;
            float median = input.Count % 2 == 0 ? (input[size / 2] + input[size / 2 - 1]) / 2 : input[size / 2];

            return $"Range: {range} Average: {average:0.00} Median: {median:0.00}";
        }

        private void PopulateUpToN(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if(_dictionary.ContainsKey(i)) continue;;

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
        private static PartDictionary _dictionary;

        static IntPart()
        {
            _dictionary = new PartDictionary(3);
        }

        public static string Part(long n)
        {
            int val = (int)n;
            IList<int> mapped = PartDictionary.Map(_dictionary[val]);
            return PartDictionary.Reduce(mapped);
        }
    }
}