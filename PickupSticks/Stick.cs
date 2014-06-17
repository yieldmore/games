using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace Cselian.Games.PickupSticks
{
	public class Stick
	{
		private const int StickWidth = 4;

		private static Pen[] allPens;

		public Point Start { get; private set; }

		public Point End { get; private set; }

		public int Order { get; private set; }

		public Pen Pen { get; private set; }

		public Stick[] Above { get; private set; }

		public bool Removed { get; set; }

		static Stick()
		{
			var type = typeof(Pens);
			allPens = type.GetProperties(BindingFlags.Static | BindingFlags.Public)
				.Select(x => type.GetProperty(x.Name, BindingFlags.Static | BindingFlags.Public).GetValue(null, null))
				.Cast<Pen>().Select(x => new Pen(x.Color, StickWidth))
				.Cast<Pen>().ToArray();
		}

		public static List<Stick> CreateSticks(Point edge, int count)
		{
			var sticks = new List<Stick>();

			var r = new Random();
			var allQuadrants = new List<Point> { new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(0, 0) };
			var halfX = edge.X / 2;
			var halfY = edge.Y / 2;
			while (sticks.Count < count)
			{
				var stick = new Stick
				{
					Start = new Point(r.Next(edge.X), r.Next(edge.Y)),
					Pen = allPens[r.Next(allPens.Length)],
					Order = sticks.Count
				};

				// ensure end is in another quadrant so that a minimum size line is possible.
				var quadrants = new List<Point>(allQuadrants);
				var qIndex = 3;

				if (stick.Start.X > halfX && stick.Start.Y > halfY) qIndex = 1;
				else if (stick.Start.X < halfX && stick.Start.Y > halfY) qIndex = 0;
				else if (stick.Start.X > halfX && stick.Start.Y < halfY) qIndex = 2;
				quadrants.RemoveAt(qIndex);

				var q = quadrants[r.Next(quadrants.Count)];
				stick.End = new Point(q.X * halfX + r.Next(halfX), q.Y * halfY + r.Next(halfY));
				stick.Above = sticks.Where(x => stick.Intersects(x)).ToArray();

				sticks.Insert(0, stick);
			}

			return sticks;
		}

		public override string ToString()
		{
			return string.Concat(Start.X, ",", Start.Y, " - ", End.X, ",", End.Y);
		}

		public bool IsOnTop()
		{
			return Above.Any(x => x.Removed == false) == false;
		}

		public bool IsUnderCursor(Point point)
		{
			var cursor = new Stick
			{
				Start = new Point(point.X - StickWidth, point.Y - StickWidth),
				End = new Point(point.X + StickWidth, point.Y + StickWidth)
			};

			return Intersects(cursor);
		}

		private bool Intersects(Stick s)
		{
			int o1 = Orientation(s.Start, s.End, Start);
			int o2 = Orientation(s.Start, s.End, End);
			int o3 = Orientation(Start, End, s.Start);
			int o4 = Orientation(Start, End, s.End);

			// General case
			if (o1 != o2 && o3 != o4)
				return true;

			return false; // dont bother checking if collinear
		}

		//http://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
		private int Orientation(Point p, Point q, Point r)
		{
			int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

			if (val == 0) return 0;  // colinear

			return (val > 0) ? 1 : 2; // clock or counterclock wise
		}
	}
}
