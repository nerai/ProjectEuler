using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Util;

/*
Coin sums
Problem 31
In England the currency is made up of pound, £, and pence, p, and there are eight coins in general circulation:

1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
It is possible to make £2 in the following way:

1×£1 + 1×50p + 2×20p + 1×5p + 1×2p + 3×1p
How many different ways can £2 be made using any number of coins?
*/

namespace ProjectEuler
{
	class P031
	{
		public P031 ()
		{
			var options = new ulong[] { 1, 2, 5, 10, 20, 50, 100, 200 };
			var sums = new Summation (options);
			for (uint i = 1; i <= 200; i++) {
				Console.WriteLine (sums.Create (i));
			}
		}
	}
}
