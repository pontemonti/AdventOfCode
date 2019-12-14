using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Utilities
{
    public class EnumerableHelper
    {
        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> enumerable)
        {
            T[] items = enumerable.ToArray();
            if (items.Length == 1)
            {
                yield return enumerable;
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    T[] itemsToPermute = items.Take(i).Concat(items.Skip(i + 1)).ToArray();
                    IEnumerable<T>[] permutations = GetPermutations(itemsToPermute).ToArray();
                    foreach (IEnumerable<T> permutation in permutations)
                    {
                        List<T> list = new List<T>();
                        list.Add(items[i]);
                        list.AddRange(permutation);
                        yield return list;
                    }
                }
            }
        }
    }
}
