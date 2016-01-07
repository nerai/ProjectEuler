using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
	class P052
	{
		public P052 ()
		{
			for (ulong u = 1; ; u++) {
				var s = Order (u);
				var fail = false;

				for (uint i = 2; i <= 6; i++) {
					if (Order (i * u) != s) {
						fail = true;
						break;
					}
				}

				if (!fail) {
					Console.WriteLine (u);
					return;
				}
			}
		}

		private string Order (ulong u)
		{
			return new string (u.ToString ().OrderBy (c => c).ToArray ());
		}
	}
}
