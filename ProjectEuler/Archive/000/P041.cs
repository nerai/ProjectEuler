using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Util;

/*
Pandigital prime
Problem 41
We shall say that an n-digit number is pandigital if it makes use of all the digits 1 to n exactly once. For example, 2143 is a 4-digit pandigital and is also prime.

What is the largest n-digit pandigital prime that exists?
*/

namespace ProjectEuler
{
	class P041
	{
		public P041 ()
		{
			uint max = 1;
			for (int len = 1; len <= 9; len++) {
				max *= 10;

				if (len < 3) {
					// 1, 12, 21 sind nicht prim
					continue;
				}
				if (len % 3 == 0) {
					// => ist durch 3 teilbar
					continue;
				}

				foreach (var prime in new Primes ().TakeWhile (x => x < max)) {
					if (Pandigital.IsNPandigital (prime)) {
						Console.WriteLine (prime);
					}
				}
			}
		}
	}
}
