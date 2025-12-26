using System;
using System.Collections.Generic;

namespace _Content.Scripts.Utils
{
    public static class CollectionExtensions
    {
        private static Random _random = new Random();
        
        public static T RandomElement<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("List is null or empty");

            var index = _random.Next(list.Count);
            return list[index];
        }
        
        public static void Shuffle<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("List is null or empty");

            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = _random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
        
        public static IList<T> RandomElements<T>(this IList<T> list, int count)
        {
            if (list == null || list.Count == 0)
                throw new ArgumentException("List is null or empty");
            if (count < 0 || count > list.Count)
                throw new ArgumentOutOfRangeException("Count is out of range");

            var result = new List<T>(count);
            var selectedIndexes = new HashSet<int>();

            while (result.Count < count)
            {
                var index = _random.Next(list.Count);
                if (!selectedIndexes.Add(index)) continue;

                result.Add(list[index]);
            }

            return result;
        }
    }
}