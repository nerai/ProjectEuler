using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public enum Perfectness
	{
		Perfect,
		Deficient,
		Abundant,
	}

	public static class Perfect
	{
		public static readonly ulong[] Known =
		{
			6,
			28,
			496,
			8128,
			33550336,
			8589869056,
			137438691328,
			2305843008139952128,
			//2658455991569831744654692615953842176,
			//191561942608236107294793378084303638130997321548169216
		};

		public static Perfectness Test (ulong u)
		{
			var sum = (ulong) Divisors
				.AllDivisors (u)
				.Where (x => x != u)
				.Sum (x => (long) x);

			if (sum < u) {
				return Perfectness.Deficient;
			}
			if (sum > u) {
				return Perfectness.Abundant;
			}
			return Perfectness.Perfect;
		}

		public static IEnumerable<ulong> Generate (Perfectness kind)
		{
			ulong u = 0;
			for (; ; ) {
				u++;
				if (Test (u) == kind) {
					yield return u;
				}
			}
		}
	}
}
