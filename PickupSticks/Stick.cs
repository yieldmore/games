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
				.Cast<Pen>().Where(x => NotTooLight(x.Color))
				.Select(x => new Pen(x.Color, StickWidth)).ToArray();
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
			Point p1 = s.Start, q1 = s.End, p2 = Start, q2 = End;
			int o1 = Orientation(p1, q1, p2);
			int o2 = Orientation(p1, q1, q2);
			int o3 = Orientation(p2, q2, p1);
			int o4 = Orientation(p2, q2, q1);

			// General case
			if (o1 != o2 && o3 != o4)
				return true;

			// Special Cases
			// p1, q1 and p2 are colinear and p2 lies on segment p1q1
			if (o1 == 0 && OnSegment(p1, p2, q1)) return true;

			// p1, q1 and p2 are colinear and q2 lies on segment p1q1
			if (o2 == 0 && OnSegment(p1, q2, q1)) return true;

			// p2, q2 and p1 are colinear and p1 lies on segment p2q2
			if (o3 == 0 && OnSegment(p2, p1, q2)) return true;

			// p2, q2 and q1 are colinear and q1 lies on segment p2q2
			if (o4 == 0 && OnSegment(p2, q1, q2)) return true;

			return false; // dont bother checking if collinear
		}

		//http://www.geeksforgeeks.org/check-if-two-given-line-segments-intersect/
		private int Orientation(Point p, Point q, Point r)
		{
			int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

			if (val == 0) return 0;  // colinear

			return (val > 0) ? 1 : 2; // clock or counterclock wise
		}

		private bool OnSegment(Point p, Point q, Point r)
		{
			if (q.X <= Math.Max(p.X, r.X) && q.X >= Math.Min(p.X, r.X) &&
				q.Y <= Math.Max(p.Y, r.Y) && q.Y >= Math.Min(p.Y, r.Y))
				return true;

			return false;
		}

		private static bool NotTooLight(Color c)
		{
			return c.R * c.G * c.B <= 8000000;
		}
	}
}
