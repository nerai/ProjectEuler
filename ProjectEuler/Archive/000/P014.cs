using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.
*/

namespace ProjectEuler.P14_Longest_Collatz
{
	public class P014
	{
		private long bestLength = 0;
		private Dictionary<long, long> Lookup = new Dictionary<long, long> ();
		private double avg = 1;

		public P014 ()
		{
			int best = 0;
			for (int i = 1; i < 1000000; i++) {
				long res = Solve (i);
				if (res > bestLength) {
					bestLength = res;
					best = i;
				}
			}
			Console.WriteLine (best + ": " + bestLength + ", average search length " + avg);
		}

		private long Solve (int i)
		{
			var stack = new List<long> ();

			checked {
				long l = i;
				long c = 0;
				long lu = 0;
				while (l != 1) {
					if (Lookup.TryGetValue (l, out lu)) {
						c += lu;
						break;
					}

					stack.Add (l);
					c++;
					if (l % 2 == 0) {
						l /= 2;
					}
					else {
						l = 3 * l + 1;
					}
				}

				for (int index = 0; index < stack.Count; index++) {
					long number = stack[index];
					if (number < 1000000) {
						Lookup[number] = stack.Count - index + lu;
					}
				}

				avg = ((i - 1) * avg + stack.Count) / i;
				return c;
			}
		}
	}
}
