using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

/*
Coded triangle numbers
Problem 42
The nth term of the sequence of triangle numbers is given by, tn = ½n(n+1); so the first ten triangle numbers are:

1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...

By converting each letter in a word to a number corresponding to its alphabetical position and adding these values we form a word value. For example, the word value for SKY is 19 + 11 + 25 = 55 = t10. If the word value is a triangle number then we shall call the word a triangle word.

Using words.txt (right click and 'Save Link/Target As...'), a 16K text file containing nearly two-thousand common English words, how many are triangle words?
*/

namespace ProjectEuler
{
	class P042
	{
		public P042 ()
		{
			var words = File.ReadAllText ("P042.txt").Replace ("\"", "").Split (',').ToArray ();
			var tris = Enumerable.Range (1, 30).Select (x => x * (x + 1) / 2).ToArray ();
			var n = words.Count (w => tris.Contains (w.Sum (c => c - 'A' + 1)));
			Console.WriteLine (n);
		}
	}
}
