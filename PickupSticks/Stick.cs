using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace Cselian.Games.PickupSticks
{
	public class Stick
	{
		private static Pen[] allPens;

		public Point Start { get; private set; }

		public Point End { get; private set; }

		public int Order { get; private set; }

		public Pen Pen { get; private set; }

		public bool Removed { get; private set; }

		static Stick()
		{
			var type = typeof(Pens);
			allPens = type.GetProperties(BindingFlags.Static | BindingFlags.Public)
				.Select(x => type.GetProperty(x.Name, BindingFlags.Static | BindingFlags.Public).GetValue(null, null))
				.Cast<Pen>().Select(x => new Pen(x.Color, 4))
				.Cast<Pen>().ToArray();
		}

		public static Stick[] CreateSticks(Point edge, int count)
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

				sticks.Insert(0, stick);
			}

			return sticks.ToArray();
		}

		public override string ToString()
		{
			return string.Concat(Start.X, ",", Start.Y, " - ", End.X, ",", End.Y);
		}
	}
}
