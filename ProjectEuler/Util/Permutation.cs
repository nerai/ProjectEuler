﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class Permutation
	{
		public static IEnumerable<string> Permutations (string s)
		{
			return Permutations (s.ToCharArray ()).Select (ca => new string (ca));
		}

		public static IEnumerable<T[]> Permutations<T> (T[] values, int fromInd = 0)
		{
			if (fromInd + 1 == values.Length) {
				yield return values;
				yield break;
			}

			foreach (var v in Permutations (values, fromInd + 1)) {
				yield return v;
			}

			for (var i = fromInd + 1; i < values.Length; i++) {
				SwapValues (values, fromInd, i);
				foreach (var v in Permutations (values, fromInd + 1)) {
					yield return v;
				}
				SwapValues (values, fromInd, i);
			}
		}

		private static void SwapValues<T> (T[] values, int pos1, int pos2)
		{
			if (pos1 != pos2) {
				T tmp = values[pos1];
				values[pos1] = values[pos2];
				values[pos2] = tmp;
			}
		}
	}
}
