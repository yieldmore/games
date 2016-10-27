using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace Cselian.Sudoku
{
	public class Cell
	{

		public static readonly int[] AllValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
		public readonly static int
			Gap = 2, InterGap = 5,
			Grid = TextBoxEx.Grid + Gap,
			Sq = 3, Cnt = 9, End = Grid * Cnt + 2 * InterGap;


		TextBoxEx txt;
		public int Number { get; private set; }
		public int? Value { get { return txt.Value; } }
		public int X { get; private set; }
		public int Y { get; private set; }
		public bool Error { get { return txt.Error; } set { txt.Error = value; } }

		#region Constructors
		public Cell(int number, Cell block, Control playingArea, int value)
			: this(number, block, playingArea)
		{
			txt.ReadOnly = true;
			txt.SetValue(value);
			Highlight(true);
		}

		public Cell(int number, Cell block, Control playingArea)
			: this(number)
		{
			txt = new TextBoxEx()
			{
				Left = block.X * (Sq * Grid + InterGap) + X * Grid,
				Top = block.Y * (Sq * Grid + InterGap) + Y * Grid
			};
			txt.ValueChanged += new EventHandler(txt_ValueChanged);
			playingArea.Controls.Add(txt);
		}

		public event EventHandler ValueChanged;
		void txt_ValueChanged(object sender, EventArgs e)
		{
			if (null != ValueChanged) ValueChanged(this, EventArgs.Empty);
		}

		public Cell(int number)
		{
			Number = number;
			X = Number % Sq;
			Y = Number / Sq;
		}

		#endregion

		public void SetPossible(List<int> possibilities, bool autoSet)
		{
			if (autoSet && null != possibilities && possibilities.Count == 1)
				txt.SetValue(possibilities[0]);
			else
				txt.SetPossible(possibilities);
		}

		public void Highlight(bool reset) { txt.BackColor = reset ? SystemColors.Window : Color.LightPink; }

		public void Refresh() { txt.Invalidate(); }

		public void Reset() { txt.SetValue(txt.ReadOnly ? txt.Value : null); }


		public override string ToString()
		{
			return Number + " " + (Value.HasValue ? Value.Value.ToString() : string.Empty);
		}

		public class TextBoxEx : Control
		{
			public const float TxtSize = 18;
			public static readonly int Grid = new TextBox() { Font = new Font(Control.DefaultFont.FontFamily, TxtSize) }.Height;

			private static Font font = new Font(Control.DefaultFont.FontFamily, 18, FontStyle.Bold);
			private static Font poss = new Font(Control.DefaultFont.FontFamily, 6);
			private static SolidBrush b = new SolidBrush(Color.Gray);

			private List<int> possibilities;
			public bool ReadOnly { get; set; }
			public override Color ForeColor
			{
				get
				{
					if (ReadOnly) return Color.Gray; else if (Error) return Color.Red; else return base.ForeColor;
				}
				set
				{
					base.ForeColor = value;
				}
			}

			public TextBoxEx()
			{
				Height = Width = Grid;
				AutoSize = false;
				SetStyle(ControlStyles.UserPaint, true);
				Font = font;
				BackColor = SystemColors.Window;
			}

			public void SetPossible(List<int> p)
			{
				possibilities = p;
				Invalidate();
			}

			protected override void OnMouseEnter(System.EventArgs e)
			{
				base.OnMouseEnter(e);
				Focus();
				Invalidate();
			}

			protected override void OnLostFocus(System.EventArgs e)
			{
				base.OnLostFocus(e);
				Invalidate();
			}

			public bool Error { get; set; }
			public int? Value { get; private set; }
			public event EventHandler ValueChanged;

			protected override void OnKeyDown(KeyEventArgs e)
			{
				base.OnKeyDown(e);
				if (ReadOnly) return;
				if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
					SetValue(null);
				else if ((e.KeyValue < 49 || e.KeyValue > 57) == false)
					SetValue(e.KeyValue - 48);
			}

			public void SetValue(int? v)
			{
				Value = v;
				Text = v.HasValue ? v.Value.ToString() : string.Empty;
				if (null != ValueChanged) ValueChanged(this, EventArgs.Empty);
				Invalidate();
			}


			protected override void OnPaint(PaintEventArgs e)
			{
				base.OnPaint(e);
				if (null != possibilities)
				{
					foreach (int i in possibilities)
						e.Graphics.DrawString(i.ToString(), poss, b, 3 + Width / 3 * ((i - 1) % 3), 3 + Height / 3 * ((i - 1) / 3));
				}
				SizeF s = e.Graphics.MeasureString(Text, Font);
				e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), (Width - s.Width) / 2, (Height - s.Height) / 2);
				int penWidth = Focused ? 2 : 1;
				e.Graphics.DrawRectangle(new Pen(Focused ? Color.Red : Color.Black, penWidth), Size.Pad(Focused ? 3 : 0, penWidth));
			}
		}

	}
}
