using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class Harshad
	{
		static Harshad ()
		{
			Debug.Assert (IsHarshadNumber (201));
			Debug.Assert (!IsHarshadNumber (202));
			bool strong;
			Debug.Assert (IsTruncatableHarshadNumber (201, out strong) && strong);
			Debug.Assert (!IsTruncatableHarshadNumber (202, out strong));

			var sum10k = StrongTruncHershadsSum (10000);
			Debug.Assert (sum10k == 90619);
			Console.Clear ();

			var sum10k_ = GenerateStrongTruncatableHarshadPrimes ()
			       .TakeWhile (x => x < 10000ul)
			       .Sum (x => (long) x);
			Debug.Assert (sum10k_ == 90619);
		}

		public static IEnumerable<ulong> GenerateStrongTruncatableHarshadPrimes ()
		{
			foreach (var basis in GenerateTruncatableHarshads ()) {
				if (!MillerRabin.IsPrimeMR (basis / Numbers.DigitSum (basis))) {
					continue;
				}

				var u = basis * 10 + 1;
				for (ulong add = 0; add < 5; add++) {
					if (MillerRabin.IsPrimeMR (u)) {
						yield return u;
					}
					u += 2;
				}
			}
		}

		public static IEnumerable<ulong> GenerateTruncatableHarshads ()
		{
			/*
			 * Base 10: All numbers 1-9 are Harshad always
			 */
			for (ulong basis = 1; basis < 10; basis++) {
				yield return basis;
			}

			/*
			 * Append next digit, yield return if Harshad
			 */
			foreach (var basis in GenerateTruncatableHarshads ()) {
				var u = basis * 10;
				for (ulong add = 0; add < 10; add++) {
					if (IsHarshadNumber (u)) {
						yield return u;
					}
					u++;
				}
			}
		}

		private static ulong StrongTruncHershadsSum (ulong limit)
		{
			ulong sum = 0;
			ulong n = 0;

			foreach (var prime in Primes.Generate ().TakeWhile (x => x < limit)) {
				var u = prime / 10;
				bool strong;
				bool hersh = IsTruncatableHarshadNumber (u, out strong);
				if (hersh && strong) {
					sum += prime;
					n++;
					Console.WriteLine ("StrTruncHarsh prime " + prime + ", total " + n + " hershads with sum " + sum);
				}
			}

			return sum;
		}

		public static bool IsHarshadNumber (ulong number)
		{
			var d = number % Numbers.DigitSum (number);
			return d == 0;
		}

		public static bool IsTruncatableHarshadNumber (ulong number, out bool isStrong)
		{
			isStrong = false;
			if (number == 0) {
				return false;
			}

			ulong u = number;
			ulong digits0 = Numbers.DigitSum (number);
			ulong digits = digits0;

			while (u > 0) {
				if (u % digits != 0) {
					return false;
				}

				digits -= u % 10;
				u /= 10;
			}

			isStrong = Primes.IsPrime_BitmapCached (number / digits0);
			return true;
		}
	}
}
