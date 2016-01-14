using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class PentagonalNumbers
	{
		private List<ulong> _Cache1 = new List<ulong> ();
		private HashSet<ulong> _Cache2 = new HashSet<ulong> ();
		private IEnumerator<ulong> _Src = Pentagons ().GetEnumerator ();

		public PentagonalNumbers ()
		{
			_Cache1.Add (1);
			_Cache2.Add (1);
		}

		public static IEnumerable<ulong> Pentagons ()
		{
			ulong n = 1;
			for (; ; ) {
				yield return n * (3 * n - 1) / 2;
				n++;
			}
		}

		public ulong Pent (int index)
		{
			while (index >= _Cache1.Count) {
				_Src.MoveNext ();
				_Cache1.Add (_Src.Current);
				_Cache2.Add (_Src.Current);
			}
			return _Cache1[index];
		}

		public bool IsPent (ulong u)
		{
			while (_Cache1[_Cache1.Count - 1] < u) {
				_Src.MoveNext ();
				_Cache1.Add (_Src.Current);
				_Cache2.Add (_Src.Current);
			}
			return _Cache2.Contains (u);
		}
	}
}
