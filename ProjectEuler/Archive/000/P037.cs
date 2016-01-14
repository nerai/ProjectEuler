using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectEuler.Util;

/*
Truncatable primes
Problem 37
The number 3797 has an interesting property. Being prime itself, it is possible to continuously remove digits from left to right, and remain prime at each stage: 3797, 797, 97, and 7. Similarly we can work from right to left: 3797, 379, 37, and 3.

Find the sum of the only eleven primes that are both truncatable from left to right and right to left.

NOTE: 2, 3, 5, and 7 are not considered to be truncatable primes.

*/

namespace ProjectEuler
{
	class P037
	{
		public P037 ()
		{
			var sum = 0ul;
			foreach (var p in Primes.Generate ().Where (x => Test (x)).Take (11)) {
				Console.WriteLine ("==> " + p);
				sum += p;
			}
			Console.WriteLine (sum);
		}

		private bool Test (ulong u)
		{
			if (u < 10) {
				return false;
			}

			var f = 1ul;
			var a = u;
			while (a >= 10) {
				a /= 10;
				f *= 10;
				if (!Primes.IsPrime_BitmapCached (a)) {
					return false;
				}
			}

			a = u;
			while (f >= 10) {
				a %= f;
				if (!Primes.IsPrime_BitmapCached (a)) {
					return false;
				}
				f /= 10;
			}

			Console.WriteLine ("xxx " + f + " " + u);
			return true;
		}

		/*
		private IEnumerable<ulong> GenerateLeftToRight ()
		{
			yield return 3;
			yield return 7;

			foreach (var basis in GenerateLeftToRight ()) {
				foreach (uint i in new[] { 3, 7, 9 }) {
					var u = 10 * basis + i;
					if (!Primes.IsPrime_BitmapCached (u)) {
						continue;
					}

					//Console.WriteLine ("test " + u);
					var f = 1ul;
					while (f < u) {
						f *= 10;
					}

					bool fail = false;
					while (f > 10) {
						f /= 10;
						var test = u % f;
						if (!Primes.IsPrime_BitmapCached (test)) {
							fail = true;
							break;
						}
					}

					if (!fail) {
						yield return u;
					}
				}
			}
		}
		*/

		/*
		static int XXX = 0;

		private IEnumerable<ulong> GenerateRightToLeft ()
		{
			var level = XXX;
			XXX++;

			yield return 3;
			yield return 7;

			foreach (var basis in GenerateRightToLeft ()) {
				var f = 1ul;
				while (f < basis) {
					f *= 10;
				}

				for (uint i = 1; i < 10; i++) {
					var u = f * i + basis;
					if (!Primes.IsPrime_BitmapCached (u)) {
						continue;
					}

					Console.WriteLine (new string ('\t', level) + level + " test " + u);
					if (Test2 (u / 10u)) {
						Console.WriteLine (new string ('\t', level) + level + " yield " + u);
						yield return u;
					}
				}
			}
		}

		private bool Test2 (ulong u)
		{
			while (u > 0) {
				if (!Primes.IsPrime_BitmapCached (u)) {
					return false;
				}
				u /= 10;
			}
			return true;
		}
		 */
	}
}
