using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*

 Lexicographic permutations
Problem 24
A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

012   021   102   120   201   210

What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

*/

namespace ProjectEuler
{
	class P024
	{
		public P024 ()
		{
			var source = "0123456789";
			/*var perms = Util.Permutation
				.Permutations (source)
				.Take (1000000 * 2 + 1)
				.ToArray ();*/
			var perm = Util.Permutation
				.Permutations (source)
				.Take (1000000 * 2 + 1)
				.OrderBy (x => x)
				.Skip (999999)
				.Take (1)
				.Single ();
			Console.WriteLine (perm);
			/*
			foreach (var p in perms) {
				Console.WriteLine (p);
			}
			*/
		}
	}
}
