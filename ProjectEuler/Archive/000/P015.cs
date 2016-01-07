using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using ProjectEuler.Util;

/*
Lattice paths
Problem 15
Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down, there are exactly 6 routes to the bottom right corner.

How many such routes are there through a 20×20 grid?
*/

namespace ProjectEuler
{
	class P015
	{
		public P015 ()
		{
			var n = Faculty.Fac (40) / Faculty.Fac (20) / Faculty.Fac (20);
			Console.WriteLine (n);
		}
	}
}
