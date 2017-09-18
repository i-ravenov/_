using System.Collections.Generic;
using System.Linq;
using System;

namespace CodeWars
{
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
            IList<int> mapped = Map(_dictionary[val]);
            return Reduce(mapped);
        }

        private static IList<int> Map(ISet<Partition> input)
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
    }
}