using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Util
{
	class Numbers
	{
		public static ulong DigitSum (ulong u)
		{
			ulong digits = 0;

			while (u > 0) {
				digits += u % 10;
				u /= 10;
			}

			return digits;
		}

		public static ulong Reverse (ulong u, bool removeTrailingZeros = false)
		{
			if (!removeTrailingZeros && u % 10 == 0) {
				throw new Exception ();
			}

			ulong res = 0;
			while (u != 0) {
				var c = u % 10;
				u /= 10;
				res = res * 10 + c;
			}
			return res;
		}

		public static BigInteger Reverse (BigInteger u, bool removeTrailingZeros = false)
		{
			if (!removeTrailingZeros && u % 10 == 0) {
				throw new Exception ();
			}

			BigInteger res = 0;
			while (u != 0) {
				var c = u % 10;
				u /= 10;
				res = res * 10 + c;
			}
			return res;
		}

		public static bool ConsistsOnlyOfOddDigits (ulong u)
		{
			while (u != 0) {
				var c = u % 10;
				u /= 10;
				if (c % 2 == 0) {
					return false;
				}
			}
			return true;
		}

		public static bool IsBouncy (ulong u)
		{
			ulong max = ulong.MinValue;
			ulong min = ulong.MaxValue;

			while (u != 0) {
				ulong c = u % 10;

				if (c >= max) {
					max = c;
				}
				else {
					max = ulong.MaxValue;
				}

				if (c <= min) {
					min = c;
				}
				else {
					min = ulong.MinValue;
				}

				u /= 10;
			}

			return max == ulong.MaxValue && min == ulong.MinValue;
		}

		public static void TestBouncy ()
		{
			Debug.Assert (!IsBouncy (1));
			Debug.Assert (!IsBouncy (12));
			Debug.Assert (!IsBouncy (123456789));
			Debug.Assert (!IsBouncy (21));
			Debug.Assert (!IsBouncy (97530));
			Debug.Assert (IsBouncy (282));
			Debug.Assert (IsBouncy (828));
			Debug.Assert (IsBouncy (123234345));
		}

		public static int NumberOfTrailingZeros (int i)
		{
			return NumberOfTrailingZerosLookup[(i & -i) % 37];
		}

		private static readonly int[] NumberOfTrailingZerosLookup =
		{
			32, 0, 1, 26, 2, 23, 27, 0, 3, 16, 24, 30, 28, 11, 0, 13, 4, 7, 17,
			0, 25, 22, 31, 15, 29, 10, 12, 6, 0, 21, 14, 9, 5, 20, 8, 19, 18
		};

		public static int NumberOfTrailingZeros (ulong u)
		{
			if (u == 0) {
				return 64;
			}

			uint n = 63;
			ulong t;
			t = u << 32; if (t != 0) { n -= 32; u = t; }
			t = u << 16; if (t != 0) { n -= 16; u = t; }
			t = u << 8; if (t != 0) { n -= 8; u = t; }
			t = u << 4; if (t != 0) { n -= 4; u = t; }
			t = u << 2; if (t != 0) { n -= 2; u = t; }
			u = (u << 1) >> 63;
			return (int) (n - u);
		}

		static readonly long PerfectSquareMask = 0; // 0xC840C04048404040 computed below

		static Numbers ()
		{
			for (int i = 0; i < 64; ++i) {
				unchecked {
					PerfectSquareMask |= (long) ((ulong) (long.MinValue) >> (i * i));
				}
			}
		}

		// Source: http://stackoverflow.com/a/18686659/39590
		public static bool IsPerfectSquare (ulong x)
		{
			// This tests if the 6 least significant bits are right.
			// Moving the to be tested bit to the highest position saves us masking.
			if (PerfectSquareMask << (int) x >= 0) return false; // TODO int conversion not allowed???

			// Each square ends with an even number of zeros.
			int numberOfTrailingZeros = NumberOfTrailingZeros (x);
			if ((numberOfTrailingZeros & 1) != 0) return false;

			x >>= numberOfTrailingZeros;
			// Now x is either 0 or odd.
			// In binary each odd square ends with 001.
			// Postpone the sign test until now; handle zero in the branch.
			if ((x & 7) != 1 | x <= 0) return x == 0;

			// Do it in the classical way.
			// The correctness is not trivial as the conversion from long to double is lossy!
			var tst = (ulong) Math.Sqrt (x);
			return tst * tst == x;
		}

		private static readonly Dictionary<ulong, bool> PerfectNumberCache = new Dictionary<ulong, bool> ();

		public static bool IsPerfectSquare_Cached (ulong x)
		{
			bool n;
			if (!PerfectNumberCache.TryGetValue (x, out n)) {
				n = IsPerfectSquare (x);
				PerfectNumberCache.Add (x, n);
			}
			return n;
		}
	}
}
