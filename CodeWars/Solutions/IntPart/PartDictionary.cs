using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
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
}