using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace ProjectEuler.Util
{
	// Miller-Rabin primality test as an extension method on the BigInteger type.
	// Based on the Ruby implementation on RosettaCode.
	public static class MillerRabin
	{
		/// <summary>
		/// Deterministic variant of Miller Rabin (100% certaincy)
		/// </summary>
		public static bool IsPrimeMR (this uint source)
		{
			return IsProbablePrime (source, new BigInteger[] { 2, 7, 61 });
		}

		/// <summary>
		/// Deterministic variant of Miller Rabin (100% certaincy)
		/// </summary>
		public static bool IsPrimeMR (this ulong source)
		{
			return IsProbablePrime (source, new BigInteger[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 });
		}

		private static readonly Dictionary<ulong, bool> _Cache = new Dictionary<ulong, bool> ();

		/// <summary>
		/// Deterministic variant of Miller Rabin (100% certaincy)
		/// </summary>
		public static bool IsPrimeMR_Cached (this ulong source)
		{
			bool prime;
			if (!_Cache.TryGetValue (source, out prime)) {
				if (_Cache.Count > 100000000) {
					_Cache.Clear ();
				}
				prime = IsProbablePrime (source, new BigInteger[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 });
				_Cache.Add (source, prime);
			}

			return prime;
		}

		private static readonly BigInteger MaxDetCheck = BigInteger.Parse ("3317044064679887385961981");

		/// <summary>
		/// Deterministic variant of Miller Rabin (100% certaincy)
		/// </summary>
		public static bool IsPrimeMR (this BigInteger source)
		{
			if (source >= MaxDetCheck) {
				throw new ArithmeticException ("Number too large for deterministic Miller-Rabin primality test.");
			}
			return IsProbablePrime (source, new BigInteger[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41 });
		}

		public static bool IsProbablePrime (this BigInteger source, int certainty)
		{
			// There is no built-in method for generating random BigInteger values.
			// Instead, random BigIntegers are constructed from randomly generated
			// byte arrays of the same length as the source.
			var rng = RandomNumberGenerator.Create ();
			var bytes = new byte[source.ToByteArray ().LongLength];

			var checks = Enumerable.Repeat (0, certainty).Select (x => {
				BigInteger a;
				do {
					rng.GetBytes (bytes);
					a = new BigInteger (bytes);
				}
				while (a < 2 || a >= source - 2);

				return a;
			});

			return IsProbablePrime (source, checks);
		}

		public static bool IsProbablePrime (this BigInteger source, IEnumerable<BigInteger> checks)
		{
			if (source == 2 || source == 3) {
				return true;
			}
			if (source < 2 || source % 2 == 0) {
				return false;
			}
			if (checks.Contains (source)) {
				return true;
			}

			BigInteger d = source - 1;
			int s = 0;

			while (d % 2 == 0) {
				d /= 2;
				s += 1;
			}

			foreach (var a in checks) {
				BigInteger x = BigInteger.ModPow (a, d, source);
				if (x == 1 || x == source - 1) {
					continue;
				}

				for (int r = 1; r < s; r++) {
					x = BigInteger.ModPow (x, 2, source);
					if (x == 1) {
						return false;
					}
					if (x == source - 1) {
						break;
					}
				}

				if (x != source - 1) {
					return false;
				}
			}

			return true;
		}
	}
}
