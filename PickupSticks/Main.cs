using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cselian.Games.PickupSticks
{
	public partial class Main : Form
	{
		private Stick[] sticks;

		public Main()
		{
			InitializeComponent();
			btnShuffle.PerformClick();
		}

		private void pnlSticks_Paint(object sender, PaintEventArgs e)
		{
			if (sticks == null) return;
			var pen = new Pen(Brushes.Black, 4);
			foreach (var s in sticks)
			{
				e.Graphics.DrawLine(pen, s.Start, s.End);
			}
			e.Dispose();
		}

		private void btnShuffle_Click(object sender, EventArgs e)
		{
			sticks = Stick.CreateSticks(new Point(pnlSticks.Width, pnlSticks.Height), 15);
			pnlSticks.Invalidate();
		}
	}
}
