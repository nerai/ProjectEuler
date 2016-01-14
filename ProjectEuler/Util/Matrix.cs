using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	class Matrix
	{
		public static long[][] FromFile (string path)
		{
			var matrix = File
				.ReadAllLines (path)
				.Select (line => line
					.Split (',')
					.Select (s => s == "-" ? -1 : long.Parse (s))
					.ToArray ())
				.ToArray ();
			return matrix;
		}
	}
}
