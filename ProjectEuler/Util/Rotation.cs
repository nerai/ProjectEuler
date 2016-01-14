using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util
{
	public class Rotation
	{
		public static IEnumerable<T[]> Rotations<T> (T[] values)
		{
			var list = new LinkedList<T> (values);
			for (int i = 1; i < values.Length; i++) {
				var first = list.First;
				list.RemoveFirst ();
				list.AddLast (first);

				yield return list.ToArray ();
			}
		}
	}
}
