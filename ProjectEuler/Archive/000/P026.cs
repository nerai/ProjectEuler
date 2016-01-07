using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Reciprocal cycles
Problem 26
A unit fraction contains 1 in the numerator. The decimal representation of the unit fractions with denominators 2 to 10 are given:

1/2	= 	0.5
1/3	= 	0.(3)
1/4	= 	0.25
1/5	= 	0.2
1/6	= 	0.1(6)
1/7	= 	0.(142857)
1/8	= 	0.125
1/9	= 	0.(1)
1/10	= 	0.1
Where 0.1(6) means 0.166666..., and has a 1-digit recurring cycle. It can be seen that 1/7 has a 6-digit recurring cycle.

Find the value of d < 1000 for which 1/d contains the longest recurring cycle in its decimal fraction part.
*/

namespace ProjectEuler
{
	class P026
	{
		public P026 ()
		{
			int best = 0;
			int bestI = 0;

			for (int i = 2; i < 1000; i++) {
				Console.Write ("1/" + i + " = 0.");

				int count = 0;
				int nom = 1;
				var known = new Dictionary<int, int> ();
				for (; ; ) {
					if (known.ContainsKey (nom)) {
						break;
					}
					known.Add (nom, count);

					count++;
					nom *= 10;

					while (nom < i) {
						count++;
						nom *= 10;
						Console.Write ("0");
					}

					int d = nom / i;
					Console.Write (d);
					nom -= i * d;
					if (nom == 0) {
						count = -1;
						break;
					}
				}
				if (count >= 0) {
					int len = count - known[nom];
					Console.Write (" repeats from nom " + nom + " first at " + known[nom] + " length " + len);
					if (len > best) {
						best = len;
						bestI = i;
					}
				}
				Console.WriteLine ();
			}
			Console.WriteLine ("Best " + best + " at " + bestI);
		}
	}
}
