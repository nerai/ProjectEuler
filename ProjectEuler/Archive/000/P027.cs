using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Euler discovered the remarkable quadratic formula:

n² + n + 41

It turns out that the formula will produce 40 primes for the consecutive values n = 0 to 39. However, when n = 40, 402 + 40 + 41 = 40(40 + 1) + 41 is divisible by 41, and certainly when n = 41, 41² + 41 + 41 is clearly divisible by 41.

The incredible formula  n² − 79n + 1601 was discovered, which produces 80 primes for the consecutive values n = 0 to 79. The product of the coefficients, −79 and 1601, is −126479.

Considering quadratics of the form:

n² + an + b, where |a| < 1000 and |b| < 1000

where |n| is the modulus/absolute value of n
e.g. |11| = 11 and |−4| = 4
Find the product of the coefficients, a and b, for the quadratic expression that produces the maximum number of primes for consecutive values of n, starting with n = 0.

*/

namespace ProjectEuler
{
	class P027
	{
		public P027 ()
		{
			long best = 0;
			int range = 999999;

			for (int a = -range; a < range; a++) {
				for (int b = 0; b < range; b++) {
					var cur = Check (a, b);
					if (cur > best) {
						best = cur;
						Console.WriteLine (a + "\t" + b + "\t" + best + "\ta*b=" + a * b);
					}
				}
			}
		}

		private long Check (int a, int b)
		{
			long n = 0;
			for (; ; ) {
				var c = n * n + a * n + b;
				if (c <= 1 || !Util.Primes.IsPrime_BitmapCached ((ulong) c)) {
					return n;
				}
				n++;
			}
		}
	}
}
