using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Counting Sundays
Problem 19
You are given the following information, but you may prefer to do some research for yourself.

1 Jan 1900 was a Monday.
Thirty days has September,
April, June and November.
All the rest have thirty-one,
Saving February alone,
Which has twenty-eight, rain or shine.
And on leap years, twenty-nine.
A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
*/

namespace ProjectEuler
{
	class P019
	{
		public P019 ()
		{
			int n = 0;
			var d = new DateTime (1901, 1, 1);
			while (d.Year < 2001) {
				if (d.DayOfWeek == DayOfWeek.Sunday && d.Day == 1) {
					n++;
				}
				d = d.AddDays (1);
			}
			Console.WriteLine (n);
		}
	}
}
