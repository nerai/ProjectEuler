using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Util.Graph
{
	public class Vertex
	{
		public static Vertex[] CreateGraphFromWeightMatrix (long[][] matrix)
		{
			var V = Enumerable
				.Range (0, matrix.Length)
				.Select (id => new Vertex (id))
				.ToArray ();

			for (int i = 0; i < matrix.Length; i++) {
				var line = matrix[i];
				var v = V[i];

				for (int j = 0; j < line.Length; j++) {
					var c = line[j];
					if (c < 0) {
						continue;
					}
					v.E.Add (V[j], c);
				}
			}

			return V;
		}

		public readonly int ID;

		public Vertex (int id)
		{
			ID = id;
		}

		public Dictionary<Vertex, long> E = new Dictionary<Vertex, long> ();

		public Tuple<Vertex, long> MinE (IEnumerable<Vertex> except)
		{
			return E
				.Where (pair => !except.Contains (pair.Key))
				.OrderBy (pair => pair.Value)
				.Select (pair => new Tuple<Vertex, long> (pair.Key, pair.Value))
				.Concat (new[] { new Tuple<Vertex, long> (null, long.MaxValue) })
				.First ();
		}

		public override string ToString ()
		{
			return "" + ID;
		}
	}
}
