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
}