using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Util;

/*
Palindromic sums
Problem 125
The palindromic number 595 is interesting because it can be written as the sum of consecutive squares: 62 + 72 + 82 + 92 + 102 + 112 + 122.

There are exactly eleven palindromes below one-thousand that can be written as consecutive square sums, and the sum of these palindromes is 4164. Note that 1 = 02 + 12 has not been included as this problem is concerned with the squares of positive integers.

Find the sum of all the numbers less than 108 that are both palindromic and can be written as the sum of consecutive squares.
*/

namespace ProjectEuler
{
	class P125
	{
		public P125 ()
		{
			ulong max = 100000000;
			var set = new HashSet<ulong> ();

			for (ulong start = 1; start < max; start++) {
				ulong sum = start * start;

				for (ulong cur = start + 1; ; cur++) {
					sum += cur * cur;
					if (sum >= max) {
						break;
					}
					if (Palindrome.IsPalindrome (sum)) {
						Console.WriteLine (sum + "\t" + start + "\t" + cur);
						set.Add (sum);
					}
				}
			}

			Console.WriteLine (set.Sum (x => (long) x));
		}
	}
}
