using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cselian.Chess.Game
{
	public class Piece
	{
		private static readonly string fol = @"pieces\";

		static Piece()
		{
			if (!Directory.Exists(fol)) fol = @"..\..\" + fol;
		}

		private readonly PictureBox ui = new PictureBox() { Height = Square.Size - 2 * Square.Padding, Width = Square.Size - 2 * Square.Padding, SizeMode = PictureBoxSizeMode.StretchImage };

		public readonly PieceId Id;
		public readonly string Name;
		private readonly bool inverted;

		/// <summary>
		/// Way for Piece to find out from the board whether 
		/// a move is allowed and if so, what the options are.
		/// </summary>
		public event EventHandler<PieceEventArgs> BeforeMove;
		
		/// <summary>
		/// Tells board to move.
		/// </summary>
		public event EventHandler<PieceEventArgs> Move;

		public override string ToString()
		{
			return Name + " @ " + Square.Name;
		}

		public Piece(Control parent, PieceId id, bool inverted)
		{
			this.inverted = inverted;
			Name = (Id = id).ToString();
			ui.Load(fol + (id.Black ? "b" : "w") + id.Who.ToString() + "46.gif");
			parent.Controls.Add(ui);
			ui.BringToFront();
			ui.MouseDown += new MouseEventHandler(ui_MouseDown);
			ui.MouseUp += new MouseEventHandler(ui_MouseUp);
			ui.MouseMove += new MouseEventHandler(ui_MouseMove);
		}

		public void Kill(Control board, Control bKilledList,Control wkilledList)
		{
			Square.Piece = null;
			board.Controls.Remove(ui);
			BeforeMove = Move = null;
			var killedList = Id.Black ? bKilledList : wkilledList;
			if (null != killedList)
			{
				ui.BackColor = killedList.BackColor;
				//ui.Height = ui.Width = ui.Height / 2;
				killedList.Controls.Add(ui);
			}
		}

		PieceEventArgs ev; Point starting; bool moving;

		void ui_MouseMove(object sender, MouseEventArgs e)
		{
			if (!moving) return;
			ui.Location = xt.Subtract(Control.MousePosition, starting);
		}

		void ui_MouseUp(object sender, MouseEventArgs e)
		{
			if (null == BeforeMove) return;
			Selected = false;
			if (ev == null) return;
			foreach (var item in ev.Options)
			{
				item.Hide = false;
			}
			bool found = false;
			foreach (var item in ev.Options)
			{
				var x = xt.ResolveX(item.X, inverted);
				var y = xt.ResolveY(item.Y, inverted);
				if (ui.Left > x && ui.Left - x < Square.Size - Square.Padding
					&& ui.Top > y && ui.Top - y < Square.Size - Square.Padding)
				{
					if (null != Move)
						Move(this, new PieceEventArgs(item));
					found = true;
					break;
				}
			}
			if (!found) Square = Square; //fall back
			ev = null;
			moving = false;
		}

		void ui_MouseDown(object sender, MouseEventArgs e)
		{
			if (null == BeforeMove) return;
			ev = new PieceEventArgs();
			BeforeMove(this, ev);
			if (!ev.Movable) return;
			moving = true;
			ui.BringToFront();
			starting = xt.Subtract(Control.MousePosition, ui.Location);
			Selected = true;
			foreach (var item in ev.Options)
			{
				item.Hide = true;
			}
		}

		private bool Selected { set { Square.Selected = value; ui.BackColor = value ? Square.SelectedColor : Square.Color; } }

		private Square sq;

		public Square Square
		{
			get { return sq; }
			set
			{

				sq = value;
				ui.Location = new Point(xt.ResolveX(sq.X, inverted) + 2 * Square.Padding,
					xt.ResolveY(sq.Y, inverted) + 2 * Square.Padding);
				ui.BackColor = sq.Color;
				if (sq == null) sq.Piece = null; else sq.Piece = Id;
			}
		}
	}
}
