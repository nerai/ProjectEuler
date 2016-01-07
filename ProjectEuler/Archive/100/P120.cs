using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

/*
Square remainders
Problem 120
Let r be the remainder when (a−1)n + (a+1)n is divided by a2.

For example, if a = 7 and n = 3, then r = 42: 63 + 83 = 728 ≡ 42 mod 49. And as n varies, so too will r, but for a = 7 it turns out that rmax = 42.

For 3 ≤ a ≤ 1000, find ∑ rmax.
*/

namespace ProjectEuler
{
	class P120
	{
		public P120 ()
		{
			var sum = 0ul;
			for (ulong a = 3; a <= 1000; a++) {
				var r = RMax (a);
				Console.WriteLine (a + "\t" + r);
				sum += r;
			}
			Console.WriteLine (sum);
		}

		private ulong RMax (ulong a)
		{
			var s1 = BigInteger.One;
			var s2 = BigInteger.One;
			var max = 0ul;

			for (ulong n = 1; n < a * 2; n++) { // ??? guessing...
				s1 *= a - 1;
				s2 *= a + 1;
				var sum = s1 + s2;
				var rem = (ulong) (sum % (a * a));
				max = Math.Max (max, rem);
			}

			return max;
		}
	}
}
