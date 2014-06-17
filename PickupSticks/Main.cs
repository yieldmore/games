using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cselian.Games.PickupSticks
{
	public partial class Main : Form
	{
		private List<Stick> sticks;

		public Main()
		{
			InitializeComponent();
			btnShuffle_Click(null, null);
		}

		private void pnlSticks_Paint(object sender, PaintEventArgs e)
		{
			if (sticks == null) return;
			foreach (var s in sticks)
			{
				if (s.Removed) continue;
				e.Graphics.DrawLine(s.Pen, s.Start, s.End);
			}
			e.Dispose();
		}

		private void btnShuffle_Click(object sender, EventArgs e)
		{
			sticks = Stick.CreateSticks(new Point(pnlSticks.Width, pnlSticks.Height), 15);
			pnlSticks.Invalidate();
		}

		private void pnlSticks_MouseDown(object sender, MouseEventArgs e)
		{
			var s = sticks.FirstOrDefault(x => x.Removed == false && x.IsUnderCursor(e.Location));
			if (s != null)
			{
				var ix = (sticks.IndexOf(s) + 1) + " " + s.Pen.Color.Name;
				if (s.IsOnTop())
				{
					lblMsg.Text = "Removed #" + ix;
					s.Removed = true;
					if (sticks.Any(x => x.Removed == false) == false)
					{
						lblMsg.Text += " - GAME OVER";
					}
					pnlSticks.Invalidate();
				}
				else
				{
					lblMsg.Text = "Could not remove #" + ix;
				}
			}
		}
	}
}
