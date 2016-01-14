using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public static class Repunit
	{
		public static ulong FindFirstDividedRepunit (ulong n)
		{
			ulong k = 1;
			ulong mod = 1;

			for (; ; ) {
				mod %= n;
				if (mod == 0) {
					return k;
				}
				mod = 10 * mod + 1;
				k++;
			}
		}

		/// <summary>
		/// Is n-1 divisable by A(n)?
		///
		/// If n is prime, this is always true.
		/// </summary>
		public static bool IsDivisableByR (ulong n)
		{
			return 0 == (n - 1) % FindFirstDividedRepunit (n);
		}
	}
}
