using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.
*/

namespace ProjectEuler
{
	class P004
	{
		public P004 ()
		{
			int max = 0;
			for (int i1 = 900; i1 <= 999; i1++) {
				Console.WriteLine ((i1 - 900) / 100.0);
				for (int i2 = 999; i2 > 900; i2--) {
					var p = i1 * i2;
					if (p < max) {
						continue;
					}

					var s = p.ToString ();
					var rev = new string (s.Reverse ().ToArray ());
					if (!s.Equals (rev)) {
						continue;
					}

					max = p;
					Console.WriteLine (p);
				}
			}
		}
	}
}
