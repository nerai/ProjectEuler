using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Util;

/*
Amicable numbers
Problem 21
Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

Evaluate the sum of all the amicable numbers under 10000.
*/

namespace ProjectEuler
{
	class P021
	{
		public P021 ()
		{
			var sum = 0UL;
			foreach (var pair in Amicable.GenerateAmicableNumbers ()) {
				if (pair.Item1 >= 10000 || pair.Item2 >= 10000) {
					break;
				}

				var d1 = Util.Divisors.AllDivisors (pair.Item1);
				foreach (var d in d1) {
					if (d == pair.Item1) {
						continue;
					}
					sum += d;
				}
				var d2 = Util.Divisors.AllDivisors (pair.Item2);
				foreach (var d in d2) {
					if (d == pair.Item2) {
						continue;
					}
					sum += d;
				}
			}
			Console.WriteLine (sum);
		}
	}
}
