using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Digit fifth powers
Problem 30
Surprisingly there are only three numbers that can be written as the sum of fourth powers of their digits:

1634 = 14 + 64 + 34 + 44
8208 = 84 + 24 + 04 + 84
9474 = 94 + 44 + 74 + 44
As 1 = 14 is not a sum it is not included.

The sum of these numbers is 1634 + 8208 + 9474 = 19316.

Find the sum of all the numbers that can be written as the sum of fifth powers of their digits.

*/

namespace ProjectEuler
{
	/*
	 * 1 * 9^5 = 59049  length 5
	 * 2 * 9^5 = 118098 length 6
	 * 3 * 9^5 = 177147 length 6
	 * 4 * 9^5 = 236196 length 6
	 * 5 * 9^5 = 295245 length 6
	 * 6 * 9^5 = 354294 length 6
	 * 7 * 9^5 = 413343 length 6 but would require 7!
	 *
	 * So, the maximum digit number is 6.
	 */

	class P030
	{
		public P030 ()
		{
			int global = 0;

			for (int i = 2; i <= 999999; i++) {
				int sum = 0;
				int c = i;
				while (c > 0) {
					int d = c % 10;
					c /= 10;
					sum += d * d * d * d * d;
				}
				if (sum == i) {
					Console.WriteLine (i);
					global += i;
				}
			}

			Console.WriteLine ("Sum:" + global);
		}
	}
}
