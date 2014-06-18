using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace Cselian.Sudoku
{
	public static class Extensions
	{
		/// <summary>
		/// Chained Add function that returns reference to the dictionary
		/// </summary>
		public static Dictionary<int, int> A(this Dictionary<int, int> d, int k, int v)
		{
			d.Add(k, v);
			return d;
		}

		public static IList A<T>(this IList l, T v)
		{
			l.Add(v);
			return l;
		}

		public static Rectangle Pad(this Size s, int padWith, int penWidth)
		{
			int offs = 1 - penWidth / 2;
			return new Rectangle(padWith, padWith, s.Width - 2 * padWith - offs, s.Height - 2 * padWith - offs);
		}

		public static List<Cell> MyList(this List<List<Cell>> allLists,Cell c)
		{
			foreach (var item in allLists)
				if (item.Contains(c)) return item;
			return null;
		}

		public static int Total(this List<Cell> list, out bool? hasDuplicates)
		{
			int total = 0; hasDuplicates = null; List<int> existing = new List<int>();
			foreach (var item in list)
			{
				if (item.Value.HasValue)
				{
					total += item.Value.Value;
					if (!hasDuplicates.HasValue)
					{
						if (existing.Contains(item.Value.Value))
						{
							hasDuplicates = true;
							item.Error = true;
						}
						else
							existing.Add(item.Value.Value);
					}
				}
			}
			if (total == 45) hasDuplicates = false;
			return total;
		}

		public static System.Drawing.Color Color(this bool? error)
		{
			if (error.HasValue == false)
				return System.Drawing.SystemColors.WindowText;
			else if (error.Value)
				return System.Drawing.Color.Red;
			else
				return System.Drawing.Color.Green;
		}

	}
}
