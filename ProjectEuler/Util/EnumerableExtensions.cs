using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	// TODO include the jon skeet lib
	public static class EnumerableExtensions
	{
		public static T[] SubArray<T> (this T[] data, int index, int length)
		{
			T[] result = new T[length];
			Array.Copy (data, index, result, 0, length);
			return result;
		}

		public static T[] SubArray<T> (this IList<T> data, int index, int length)
		{
			T[] result = new T[length];
			for (int i = 0; i < length; i++) {
				result[i] = data[index + i];
			}
			return result;
		}

		public static TSource MinBy<TSource, TKey> (this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return source.MinBy (selector, Comparer<TKey>.Default);
		}

		public static TSource MinBy<TSource, TKey> (this IEnumerable<TSource> source,
		    Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			using (IEnumerator<TSource> sourceIterator = source.GetEnumerator ()) {
				if (!sourceIterator.MoveNext ()) {
					throw new InvalidOperationException ("Sequence was empty");
				}
				TSource min = sourceIterator.Current;
				TKey minKey = selector (min);
				while (sourceIterator.MoveNext ()) {
					TSource candidate = sourceIterator.Current;
					TKey candidateProjected = selector (candidate);
					if (comparer.Compare (candidateProjected, minKey) < 0) {
						min = candidate;
						minKey = candidateProjected;
					}
				}
				return min;
			}
		}
	}
}
