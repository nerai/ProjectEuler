using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Util
{
	public class Divisors
	{
		public static void ReduceFraction (ref BigInteger nom, ref BigInteger denom)
		{
			var gcd = GCD (nom, denom);
			nom /= gcd;
			denom /= gcd;
		}

		private static BigInteger GCD (BigInteger a, BigInteger b)
		{
			while (b != 0) {
				var remainder = a % b;
				a = b;
				b = remainder;
			}
			return a;
		}

		public static IEnumerable<ulong> AllDivisors (ulong n)
		{
			if (n < 1) {
				throw new ArgumentException ();
			}

			yield return 1;

			var primedivs = PrimeFactors (n).ToArray ();
			var divs = AllUniqueProducts (primedivs).ToArray ();
			foreach (var f in divs) {
				yield return f;
			}
		}

		private static readonly Dictionary<ulong, ulong[]> PrimeFactorCache = new Dictionary<ulong, ulong[]> ();
		private static ulong PF_Miss = 0;
		private static ulong PF_Hit = 0;

		public static ulong[] PrimeFactors_Cached (ulong u)
		{
			ulong[] d;
			if (!PrimeFactorCache.TryGetValue (u, out d)) {
				d = PrimeFactors (u).ToArray ();
				PrimeFactorCache.Add (u, d);
				PF_Miss++;
			}
			else {
				PF_Hit++;
			}

			if ((PF_Miss) % 100000 == 0) {
				Console.WriteLine ("PF Cache " + PF_Hit + "/" + PF_Miss);
			}

			return d;
		}

		public static IEnumerable<ulong> PrimeFactors (ulong a)
		{
			for (ulong b = 2; a > 1; b++) {
				if (a % b == 0) {
					while (a % b == 0) {
						a /= b;
						yield return b;
					}
				}
			}
		}

		public static IEnumerable<ulong> AllUniqueProducts (ulong[] primeFactors)
		{
			for (int i = 0; i < primeFactors.Length; ) {
				ulong f = primeFactors[i];

				/*
				 * How often does this factor occur?
				 */
				int n = 1;
				while (i + n < primeFactors.Length && primeFactors[i + n] == f) {
					n++;
				}

				/*
				 * Skip all copies of this factor
				 */
				i += n;

				/*
				 * Look at all combinations of only THIS factor
				 */
				ulong pot = f;
				for (int j = 0; j < n; j++) {
					yield return pot;

					/*
					 * Look at all combinations from OTHER factors
					 */
					var otherFactors = primeFactors.Skip (i).ToArray ();
					foreach (var it in AllUniqueProducts (otherFactors)) {
						yield return pot * it;
					}

					pot *= f;
				}
			}
		}

		public static ulong GCD (ulong a, ulong b)
		{
			while (b != 0) {
				var remainder = a % b;
				a = b;
				b = remainder;
			}
			return a;
		}

		private static readonly Dictionary<ulong, Dictionary<ulong, ulong>> GcdCache = new Dictionary<ulong, Dictionary<ulong, ulong>> ();

		public static ulong GCD_Cached (ulong a, ulong b)
		{
			//Console.WriteLine ("GCD: " + a + "  " + b);

			Dictionary<ulong, ulong> d;
			if (!GcdCache.TryGetValue (a, out d)) {
				d = new Dictionary<ulong, ulong> ();
				GcdCache.Add (a, d);
			}

			ulong u;
			if (!d.TryGetValue (b, out u)) {
				u = GCD (a, b);
				d.Add (b, u);
			}

			return u;
		}

		public static ulong GCD_FullyCached (ulong a, ulong b)
		{
			//Console.WriteLine ("GCD: " + a + "  " + b);

			Dictionary<ulong, ulong> d;
			if (!GcdCache.TryGetValue (a, out d)) {
				d = new Dictionary<ulong, ulong> ();
				if (GcdCache.Count < 10000) {
					GcdCache.Add (a, d);
				}
			}

			ulong u;
			if (!d.TryGetValue (b, out u)) {
				var rem = a % b;
				if (rem == 0) {
					u = b;
				}
				else {
					u = GCD_FullyCached (b, rem);
				}
				if (d.Count < 1000) {
					d.Add (b, u);
				}
			}

			return u;
		}
	}
}
