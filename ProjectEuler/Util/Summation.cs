using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class Summation
	{
		private readonly Dictionary<ulong, SingleSum> All = new Dictionary<ulong, SingleSum> ();

		private IEnumerator<ulong> _Enu;
		private readonly List<ulong> _Bases = new List<ulong> ();
		private ulong _Max = 0;

		public Summation (IEnumerable<ulong> baseValues)
		{
			_Enu = baseValues.GetEnumerator ();
			if (!_Enu.MoveNext () || _Enu.Current < 1) {
				throw new ArgumentException ();
			}
		}

		public SingleSum Create (ulong u)
		{
			if (u < 1) {
				throw new ArgumentException ();
			}

			while (_Max < u) {
				_Max++;
				bool isBase = _Max == _Enu.Current;
				All.Add (_Max, new SingleSum (this, _Max, isBase));

				if (isBase) {
					_Bases.Add (_Max);
					if (!_Enu.MoveNext ()) {
						_Enu = null;
					}
				}
			}

			return All[u];
		}

		public class SingleSum
		{
			private readonly Summation Parent;
			public readonly ulong N;
			public readonly List<ulong[]> W = new List<ulong[]> ();

			internal SingleSum (Summation parent, ulong u, bool isBase)
			{
				Parent = parent;
				N = u;

				if (isBase) {
					W.Add (new ulong[] { u });
				}

				var add = new List<ulong[]> ();
				foreach (var prime in parent._Bases) {
					SingleSum lu;
					if (parent.All.TryGetValue (u - prime, out lu)) {
						add.AddRange (lu.W.Select (w =>
							w.Concat (new[] { prime })
							.OrderBy (x => x)
							.ToArray ()));
					}
				}

				W.AddRange (add
					.GroupBy (a => string.Join (",", a))
					.Select (g => g.First ()));
			}

			public override string ToString ()
			{
				var s = N + " = (" + W.Count + ") ";
				if (W.Count < 20) {
					s += string.Join ("; ", W.Select (w => string.Join (",", w)));
				}
				return s;
			}
		}
	}
}
