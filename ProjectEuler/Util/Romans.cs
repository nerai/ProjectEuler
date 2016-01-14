using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class Romans
	{
		static Romans ()
		{
			Debug.Assert (0 == Roman (""));
			Debug.Assert (1 == Roman ("I"));
			Debug.Assert (5 == Roman ("IIIII"));
			Debug.Assert (6 == Roman ("VI"));
			Debug.Assert (4 == Roman ("IV"));
			Debug.Assert (16 == Roman ("XVI"));
			Debug.Assert (29 == Roman ("XXIX"));
			Debug.Assert (19 == Roman ("XVIIII"));
			Debug.Assert (1606 == Roman ("MCCCCCCVI"));
			Debug.Assert (1606 == Roman ("MDCVI"));
			Debug.Assert (49 == Roman ("XXXXIIIIIIIII"));
			Debug.Assert (49 == Roman ("XXXXVIIII"));
			Debug.Assert (49 == Roman ("XXXXIX"));
			Debug.Assert (49 == Roman ("XLIIIIIIIII"));
			Debug.Assert (49 == Roman ("XLVIIII"));
			Debug.Assert (49 == Roman ("XLIX")); // (shortest)
			Debug.Assert (49 == Roman ("IL")); // (invalid)
		}

		public static ulong Roman (string roman)
		{
			ulong u = 0;
			int max = 1000;
			uint prevAdd = uint.MaxValue;

			foreach (var c in roman) {
				uint add;
				int nextMax;

				switch (c) {
					case 'M':
						add = 1000;
						nextMax = 1000;
						break;

					case 'D':
						add = 500;
						nextMax = 500 - 1;
						break;

					case 'C':
						add = 100;
						nextMax = 100;
						break;

					case 'L':
						add = 50;
						nextMax = 50 - 1;
						break;

					case 'X':
						add = 10;
						nextMax = 10;
						break;

					case 'V':
						add = 5;
						nextMax = 5 - 1;
						break;

					case 'I':
						add = 1;
						nextMax = 1;
						break;

					default:
						throw new ArgumentException ();
				}

				if (add > max) {
					max = -1; // denote that number is invalid or valid but not compact
				}
				max = Math.Min (max, nextMax);

				u += add;
				if (add > prevAdd) {
					u -= prevAdd * 2;
				}

				prevAdd = add;
			}

			return u;
		}

		public static string Roman (ulong u)
		{
			var s = "";
			while (u >= 1000) { u -= 1000; s += "M"; }
			while (u >= 900) { u -= 900; s += "CM"; }
			while (u >= 500) { u -= 500; s += "D"; }
			while (u >= 400) { u -= 400; s += "CD"; }
			while (u >= 100) { u -= 100; s += "C"; }
			while (u >= 90) { u -= 90; s += "XC"; }
			while (u >= 50) { u -= 50; s += "L"; }
			while (u >= 40) { u -= 40; s += "XL"; }
			while (u >= 10) { u -= 10; s += "X"; }
			while (u >= 9) { u -= 9; s += "IX"; }
			while (u >= 5) { u -= 5; s += "V"; }
			while (u >= 4) { u -= 4; s += "IV"; }
			while (u >= 1) { u -= 1; s += "I"; }
			return s;
		}
	}
}
