using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Util;

/*
We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once; for example, the 5-digit number, 15234, is 1 through 5 pandigital.

The product 7254 is unusual, as the identity, 39 × 186 = 7254, containing multiplicand, multiplier, and product is 1 through 9 pandigital.

Find the sum of all products whose multiplicand/multiplier/product identity can be written as a 1 through 9 pandigital.

HINT: Some products can be obtained in more than one way so be sure to only include it once in your sum.
*/

namespace ProjectEuler
{
	class P032
	{
		public P032 ()
		{
			ulong max = 987654321 / 2;
			var all = new HashSet<ulong> ();

			for (ulong a = max; a > 0; a--) {
				if (false
					|| (a % 10000000 == 0)
					|| (a < 10000000 && a % 100000 == 0)
					|| (a < 1000000 && a % 10000 == 0)
					|| (a < 100000 && a % 1000 == 0)
					|| (a < 10000 && a % 100 == 0)
					|| (a < 1000 && a % 10 == 0)
					|| (a < 100 && a % 1 == 0)
					) {
					Console.WriteLine ("a = " + a);
				}

				if (0 == Pandigital.Is1to9Pandigital (a)) {
					continue;
				}
				if (a % 10 == 1) {
					// x1 * yz = ??z
					continue;
				}

				for (ulong b = a; b <= max / a; b++) {
					if (b % 10 == 1) {
						// x1 * yz = ??z, thus can never be pandigital
						continue;
					}

					ulong c = a * b;
					var pan = Pandigital.Is1to9Pandigital (a, b, c);
					if (9 != pan) {
						continue;
					}
					all.Add (c);
					Console.WriteLine (a + " x " + b + " = " + c + "\t\ttotal: " + all.Count + ", sum " + all.Sum (x => (long) x));
				}
			}
		}
	}
}
