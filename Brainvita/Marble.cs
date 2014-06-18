using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Cselian.Games.Brainvita
{
	public class Marble
	{
		public enum Direction
		{
			N, S, E, W
		}

		public const int MarbleSize = 60;

		private static Dictionary<int, Marble> Marbles;

		public static void SetMarbles(Form frm)
		{
			var marbles = new List<Marble>();
			for (int x = 1; x < 10; x++)
			{
				for (int y = 1; y < 10; y++)
				{
					if ((x < 4 && y < 4) || (x < 4 && y > 6) || (x > 6 && y < 4) || (x > 6 && y > 6))
						continue;
					marbles.Add(new Marble(frm, x, y));
				}
			}

			Marbles = marbles.ToDictionary(x => x.Key, x => x);
			Marbles[55].SetState(0);
		}

		private PictureBox pic;
		private int X, Y, Key, State;

		public Marble(Form frm, int x, int y)
		{
			X = x;
			Y = y;
			Key = x * 10 + y;

			pic = new PictureBox
			{
				Image = Properties.Resources.marble,
				Left = (x - 1) * MarbleSize + 10,
				Top = (y - 1) * MarbleSize + 10,
				Height = MarbleSize,
				Width = MarbleSize,
				Visible = true,
			};

			pic.MouseDown += pic_MouseDown;
			pic.MouseMove += pic_MouseMove;
			pic.MouseUp += pic_MouseUp;

			frm.Controls.Add(pic);
		}

		public void SetState(int state)
		{
			State = state;
			if (state == 0)
				pic.Image = Properties.Resources.hole;
			else if (state == 1)
				pic.Image = Properties.Resources.marble;
			else
				pic.Image = Properties.Resources.hilite;
		}

		private void pic_MouseDown(object sender, MouseEventArgs e)
		{
		}

		private void pic_MouseMove(object sender, MouseEventArgs e)
		{
		}

		private void pic_MouseUp(object sender, MouseEventArgs e)
		{
		}
	}
}
