using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class Amicable
	{
		public static IEnumerable<Tuple<ulong, ulong>> GenerateAmicableNumbers ()
		{
			yield return new Tuple<ulong, ulong> (220, 284);
			yield return new Tuple<ulong, ulong> (1184, 1210);
			yield return new Tuple<ulong, ulong> (2620, 2924);
			yield return new Tuple<ulong, ulong> (5020, 5564);
			yield return new Tuple<ulong, ulong> (6232, 6368);
			yield return new Tuple<ulong, ulong> (10744, 10856);

			throw new NotImplementedException ();
		}
	}
}
