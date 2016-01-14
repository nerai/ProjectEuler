using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Util
{
	public class Fibonacci
	{
		public static IEnumerable<BigInteger> Gen ()
		{
			BigInteger cur = 1;
			BigInteger prev = 0;

			for (; ; ) {
				yield return cur;
				var tmp = cur;
				cur += prev;
				prev = tmp;
			}
		}
	}
}
