using System;
using System.Collections.Generic;
using System.Drawing;

namespace Cselian.Chess
{
	public static class xt
	{
		public static int ResolveX(int x, bool inverted)
		{
			return (inverted ? (8 - x) : (x - 1)) * Square.Size;
		}

		public static int ResolveY(int y, bool inverted)
		{
			return (inverted ? (y - 1) : (8 - y)) * Square.Size;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="allPieces"></param>
		/// <param name="id"></param>
		/// <returns>null when not found</returns>
		public static Piece Item(List<Piece> allPieces, PieceId id)
		{
			foreach (var item in allPieces) if (item.Id.Equals(id))
					return item;
			return null;
		}

		public static Point Subtract(Point pFrom, Point pWhat)
		{
			return new Point(pFrom.X - pWhat.X, pFrom.Y - pWhat.Y);
		}

		public static Size Grow(Size size, int xy)
		{
			return new Size(size.Width + xy, size.Height + xy);
		}

		public static T Last<T>(IList<T> list)
		{
			return list[list.Count - 1];
		}
	}
}
