using System;
using System.Drawing;
using System.Windows.Forms;

namespace Cselian.Chess.Game
{
	public class Square
	{
		public const int Size = 50, Padding = 10;

		private readonly Label ui = new Label() { AutoSize = false, Height = Size, Width = Size, TextAlign=System.Drawing.ContentAlignment.MiddleCenter, BorderStyle = BorderStyle.Fixed3D, Text = "." };

		public readonly string Name;
		public readonly int X;
		public readonly int Y;
		public readonly Color Color;
		public PieceId? Piece { get; set; }

		public static readonly Color SelectedColor = Color.LightGreen;
		public bool Selected { get { return ui.BackColor == SelectedColor; } set { ui.BackColor = value ? SelectedColor : Color; } }
		public bool Hide { set { ui.BackColor = value ? System.Drawing.Color.LightCyan : Color; } }

		public override string ToString()
		{
			return Name;
		}

		public Square(Control parent, int x, int y, bool inverted)
		{
			ui.Location = new Point(xt.ResolveX(X = x, inverted) + Padding, xt.ResolveY(Y = y, inverted) + Padding);
			//ui.Font = new Font(ui.Font.FontFamily, 6);
			//ui.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			ui.Text = Name = char.ConvertFromUtf32(64 + x) + y;
			ui.BackColor = Color = (X + Y) % 2 != 0 ? Color.WhiteSmoke : Color.Silver;
			parent.Controls.Add(ui);
			ui.DoubleClick += new EventHandler(ui_DoubleClick);
		}

		void ui_DoubleClick(object sender, EventArgs e)
		{
			ui.Text = Piece?.ToString() ?? "null";
		}
	}
}
