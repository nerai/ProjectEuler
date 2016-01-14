using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Util
{
	public static class Combinatoric
	{
		public static ulong FacultyU (ulong n)
		{
			var b = 1ul;
			for (ulong i = 2; i <= n; i++) {
				b *= i;
			}
			return b;
		}

		public static ulong FacultyUMod (ulong n, ulong mod)
		{
			var b = 1ul;
			for (ulong i = 2; i <= n; i++) {
				b *= i;
				b %= mod;
			}
			return b;
		}

		public static ulong FacultyUMod (ulong from, ulong to, ulong mod)
		{
			var b = 1ul;
			for (ulong i = from; i <= to; i++) {
				b *= i;
				b %= mod;
			}
			return b;
		}

		public static BigInteger Faculty (ulong n)
		{
			var b = BigInteger.One;
			for (ulong i = 2; i <= n; i++) {
				b *= i;
			}
			return b;
		}

		public static BigInteger Selections (uint select, uint from)
		{
			var res = Faculty (from) / Faculty (select) / Faculty (from - select);
			Console.WriteLine (select + " from " + from + " = " + res);
			return res;
		}

		/* ungetestet!
		public static BigInteger SelectionsUMod (uint select, uint from, ulong mod)
		{
			var nom = FacultyUMod (from - select + 1, from, mod);
			var den = FacultyUMod (select, mod);
			var res = nom / den;
			Console.WriteLine (select + " from " + from + " = " + res);
			return res;
		}*/
	}
}
