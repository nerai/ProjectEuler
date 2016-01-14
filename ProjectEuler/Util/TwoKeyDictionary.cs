using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class TwoKeyDictionary<TK1, TK2, TV>
	{
		private Dictionary<TK1, Dictionary<TK2, TV>> D = new Dictionary<TK1, Dictionary<TK2, TV>> ();

		private Dictionary<TK2, TV> D1 (TK1 k1, bool createIfMissing)
		{
			Dictionary<TK2, TV> d;
			if (!D.TryGetValue (k1, out d)) {
				if (createIfMissing) {
					d = new Dictionary<TK2, TV> ();
					D.Add (k1, d);
				}
				else {
					return null;
				}
			}
			return d;
		}

		public void Add (TK1 key1, TK2 key2, TV value)
		{
			D1 (key1, true).Add (key2, value);
		}

		public bool ContainsKey (TK1 key1, TK2 key2)
		{
			throw new NotImplementedException ();
		}

		public ICollection<Tuple<TK1, TK2>> Keys
		{
			get
			{
				throw new NotImplementedException ();
			}
		}

		public bool Remove (TK1 key1, TK2 key2)
		{
			throw new NotImplementedException ();
		}

		public bool TryGetValue (TK1 key1, TK2 key2, out TV value)
		{
			var d = D1 (key1, false);
			if (d == null) {
				value = default (TV);
				return false;
			}
			return d.TryGetValue (key2, out value);
		}

		public ICollection<TV> Values
		{
			get
			{
				throw new NotImplementedException ();
			}
		}

		public TV this[TK1 key1, TK2 key2]
		{
			get
			{
				throw new NotImplementedException ();
			}
			set
			{
				throw new NotImplementedException ();
			}
		}

		public void Clear ()
		{
			throw new NotImplementedException ();
		}

		public int Count
		{
			get
			{
				throw new NotImplementedException ();
			}
		}
	}
}
