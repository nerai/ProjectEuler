using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	class Triangle
	{
		/// <summary>
		/// Area inside triangle, times 2.
		/// </summary>
		/// <param name="coords">3 pairs of X and Y coordinates</param>
		public static long TwoTriangleArea (params long[] coords)
		{
			return ((coords[0] - coords[4]) * (coords[3] - coords[1]) - (coords[0] - coords[2]) * (coords[5] - coords[1]));
		}
	}
}
