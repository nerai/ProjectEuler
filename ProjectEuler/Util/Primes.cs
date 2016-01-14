using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	using PrimeT = UInt64;

	public class Primes
	{
		private static Dictionary<UInt16, HashSet<ulong>> _Primes = new Dictionary<UInt16, HashSet<PrimeT>> ();
		private static IEnumerator<PrimeT> _Gen = Generate ().GetEnumerator ();
		private static PrimeT _GenMax = 0;

		static Primes ()
		{
			for (int i = 0; i < 256 * 256; i++) {
				_Primes.Add ((UInt16) i, new HashSet<PrimeT> ());
			}
		}

		public static bool IsPrime_BitmapCached (ulong n)
		{
			while (n > _GenMax) {
				_Gen.MoveNext ();
				_GenMax = _Gen.Current;
				var genhash = (uint) _GenMax;
				genhash ^= (uint) (n >> 32);
				genhash ^= (uint) (genhash >> 16);

				_Primes[unchecked ((UInt16) genhash)].Add (_GenMax);
			}

			var hash = (uint) n;
			hash ^= (uint) (n >> 32);
			hash ^= (uint) (hash >> 16);
			return _Primes[unchecked ((UInt16) hash)].Contains (n);
		}

		public static IEnumerable<PrimeT> Generate ()
		{
			yield return 2;
			yield return 3;

			var dct = new Dictionary<PrimeT, PrimeT> ();
			PrimeT bp = 3;
			PrimeT q = 9;
			IEnumerator<PrimeT> bps = null;

			checked {
				for (var n = (PrimeT) 5; ; n += 2) {
					if (n >= q) { // always equal or less...
						if (q <= 9) {
							bps = Generate ().GetEnumerator ();
							bps.MoveNext ();
							bps.MoveNext ();
						} // move to 3...
						bps.MoveNext ();
						var nbp = bps.Current;
						q = nbp * nbp;
						var adv = bp + bp;
						bp = nbp;
						dct.Add (n + adv, adv);
					}
					else {
						if (dct.ContainsKey (n)) {
							PrimeT nadv;
							dct.TryGetValue (n, out nadv);
							dct.Remove (n);
							var nc = n + nadv;
							while (dct.ContainsKey (nc)) {
								nc += nadv;
							}
							dct.Add (nc, nadv);
						}
						else {
							yield return n;
						}
					}
				}
			}
		}

		public static IEnumerable<PrimeT> GenerateComposites ()
		{
			ulong u = 1;

			foreach (var prime in Generate ()) {
				while (u < prime) {
					yield return u;
					u++;
				}
				u++;
			}
		}
	}
}
