using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Util
{
	public class Palindrome
	{
		public static bool IsPalindrome(ulong p)
		{
			if (p % 10 == 0)
			{
				return false;
			}

			// TODO
			return IsPalindrome(p.ToString());
		}

		public static bool IsPalindrome(BigInteger p)
		{
			if (p % 10 == 0)
			{
				return false;
			}

			// TODO
			return IsPalindrome(p.ToString());
		}

		public static bool IsPalindrome (string s)
		{
			var rev = new string (s.Reverse ().ToArray ());
			return s.Equals (rev);
		}
	}
}
