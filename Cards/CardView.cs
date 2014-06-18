using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
	
namespace Cselian.Cards
{
	public partial class CardView : UserControl
	{

		public Card Card { get; private set; }

		public CardView(Card card, int column, int row)
		{
			InitializeComponent();

			Card = card;
			
			var file = card.GetFileName().Replace(".png", string.Empty).Replace("-", "_");
			BackgroundImage = Resources.ResourceManager.GetObject(file) as Bitmap;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			
			SetLocation(column, row);
		}

		#region Position

		public int Column { get; private set; }
		public int Row { get; private set; }

		public const int ColumnWidth = 90;

		public void SetLocation(int column, int row)
		{
			Column = column;
			Row = row;
			label1.Text = string.Concat(column, ",", row);
			int negativeYOffset = row == -1 ? -70 : 0; //50 will be used
			Location = new System.Drawing.Point(column * ColumnWidth,
				120 + negativeYOffset + row * 50);
		}

		#endregion

		bool moving; Point starting; bool? teno;

		/// <summary>
		/// Null if not taregetted (snap drop). true if not allowed. false if allowed.
		/// </summary>
		public bool? TargetedErrorNotOk { get { return teno; } set { teno = value; Refresh(); } }

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (TargetedErrorNotOk.HasValue)
			{
				e.FillTranslucent(TargetedErrorNotOk.Value ? Color.Red : Color.Green);
			}
			else if (moving)
			{
				e.FillTranslucent(SystemColors.Highlight);
			}
		}

		List<CardView> cardSet;

		public class CardSetEventArgs : EventArgs
		{

			/// <summary>
			/// Can these cards be moved together
			/// </summary>
			public bool Valid { get; set; }

			/// <summary>
			/// The set of cards to be moved
			/// </summary>
			public List<CardView> CardSet { get; set; }
		}

		public delegate void CardSetHandler(CardView sender, CardSetEventArgs e);

		public event CardSetHandler PreBeginMove;
		public event CardSetHandler WhileMove;
		public event CardSetHandler MoveComplete;
		public event CardSetHandler CardDoubleClick;

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			CardDoubleClick(this, null);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			if (null != PreBeginMove)
			{
				CardSetEventArgs ev = new CardSetEventArgs();
				PreBeginMove(this, ev);
				if (ev.Valid)
				{
					cardSet = ev.CardSet;
					foreach (CardView c in cardSet) c.BeginMove();
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (moving)
			{
				WhileMove(this, new CardSetEventArgs() { CardSet = cardSet });
				foreach (CardView c in cardSet) c.MoveSet();
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (null != cardSet)
			{
				CardSetEventArgs ev = new CardSetEventArgs() { CardSet = cardSet };
				MoveComplete(this, ev);
				foreach (CardView c in cardSet)
				{
					if (ev.Valid == false) c.SetLocation(c.Column, c.Row);
					c.EndMove();
				}
				cardSet = null;
			}
		}

		protected void BeginMove()
		{
			starting = Control.MousePosition.Subtract(FindForm().Location).Subtract(this.Location);
			Cursor = Cursors.SizeAll;
			BringToFront();
			moving = true;
			Refresh();
		}

		protected void MoveSet()
		{
			this.Location = Control.MousePosition.Subtract(FindForm().Location).Subtract(starting);
		}

		protected void EndMove()
		{
			ResetCursor();
			moving = false;
			Refresh();
		}
	}

	static partial class extensions
	{
		public static Color FillTranslucent(this PaintEventArgs e, Color whatColor)
		{
			Color translucent = Color.FromArgb(150, whatColor);
			Brush solidBrush = new SolidBrush(translucent);
			e.Graphics.FillRectangle(solidBrush, e.ClipRectangle);
			return whatColor;
		}

		public static Point Subtract(this Point pFrom, Point pWhat)
		{
			return new Point(pFrom.X - pWhat.X, pFrom.Y - pWhat.Y);
		}
	}
}
