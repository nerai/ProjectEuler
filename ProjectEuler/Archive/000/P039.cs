using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Util;

/*
Integer right triangles
Problem 39
If p is the perimeter of a right angle triangle with integral length sides, {a,b,c}, there are exactly three solutions for p = 120.

{20,48,52}, {24,45,51}, {30,40,50}

For which value of p ≤ 1000, is the number of solutions maximised?

*/

namespace ProjectEuler
{
	class P039
	{
		public P039 ()
		{
			var res = new Dictionary<int, int> ();

			for (int p = 3; p <= 1000; p++) {
				int n = 0;
				for (int a = 1; a <= p - 2; a++) {
					for (int b = a; a + b <= p - 1; b++) {
						var c = p - a - b;
						if (a * a + b * b == c * c) {
							Console.WriteLine (p + "\t" + a + "\t" + b + "\t" + c);
							n++;
						}
					}
				}
				res.Add (p, n);
			}

			Console.WriteLine (res.MinBy (x => -x.Value));
		}
	}
}
