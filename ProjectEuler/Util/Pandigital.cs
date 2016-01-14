using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	/// <summary>
	/// An n-digit number is pandigital if it makes use of all the digits 1 to n exactly once.
	/// </summary>
	public class Pandigital
	{
		/// <summary>
		/// Checks if the concatenation of argument numbers is 1 to 9-pandigital.
		/// </summary>
		/// <returns>
		/// 0 if any duplicate letter,
		/// else the number of distinct letters (maximum 9)
		/// </returns>
		public static int Is1to9Pandigital (params ulong[] us)
		{
			var check = new bool[10];

			foreach (var u0 in us) {
				var u = u0;
				while (u != 0) {
					var c = u % 10;
					if (c == 0 || check[c]) {
						return 0;
					}
					else {
						check[c] = true;
					}
					u /= 10;
				}
			}
			return check.Count (x => x);
		}

		/// <summary>
		/// Checks if the concatenation of argument numbers is 0 to 9-pandigital.
		/// </summary>
		/// <returns>
		/// 0 if any duplicate letter,
		/// else the number of distinct letters (maximum 10)
		/// </returns>
		public static int Is0to9Pandigital (params ulong[] us)
		{
			var check = new bool[10];

			foreach (var u0 in us) {
				var u = u0;
				while (u != 0) {
					var c = u % 10;
					if (check[c]) {
						return 0;
					}
					else {
						check[c] = true;
					}
					u /= 10;
				}
			}
			return check.Count (x => x);
		}

		/// <summary>
		/// Checks if the concatenation of argument numbers is 9-pandigital.
		/// </summary>
		/// <returns>
		/// 0 if any duplicate letter,
		/// else the number of distinct letters (maximum 9)
		/// </returns>
		public static int IsPandigital (string u)
		{
			var check = new bool[10];

			while (u != "") {
				var c = u[0] - '0';
				if (c == 0 || check[c]) {
					return 0;
				}
				else {
					check[c] = true;
				}
				u = u.Substring (1);
			}

			return check.Count (x => x);
		}

		public static bool IsNPandigital (ulong u)
		{
			var s = u.ToString ();
			var len = s.Length;

			if (len < 3) {
				// 1, 12, 21 sind nicht prim
				return false;
			}
			if (len % 3 == 0) {
				// => ist durch 3 teilbar
				return false;
			}

			bool fail = false;
			for (int check = len + 1; check <= 9; check++) {
				if (s.Contains (check.ToString ())) {
					return false;
				}
			}

			return Is1to9Pandigital (u) >= len;
		}
	}
}
