using System;
using System.Windows.Forms;

namespace Cselian.Chess
{
	public partial class ChessGame : Form
	{
		Board b1, b2;

		public ChessGame()
		{
			InitializeComponent();

			this.DoubleClick += new EventHandler(ChessGame_DoubleClick);
			ChessGame_DoubleClick(null, null);

			All.SplitterDistance = Square.Size + 16;
			Boards.Panel1.AutoScroll = true;
			Boards.Panel1.AutoScrollMinSize = Board.Size;
			Boards.Panel2.AutoScroll = true;
			Boards.Panel2.AutoScrollMinSize = OppBoard.Size;
			All.FixedPanel = FixedPanel.Panel1;
			WinHelper.CycleTristate(RemoteMnu, RemoteMnu_CheckStateChanged);
		}

		void ChessGame_DoubleClick(object sender, EventArgs e)
		{
			if (b1 != null)
			{
				b1 = b2 = null;
				Board.Controls.Clear();
				OppBoard.Controls.Clear();
				OppKilled.Controls.Clear();
				MyKilled.Controls.Clear();
			}
			else
			{
				b1 = new Board(Board, OppKilled, MyKilled, false);
				b2 = new Board(OppBoard, null, null, true);
				b1.SetOtherBoard(b2);
				b2.SetOtherBoard(b1);
			}
		}

		private void RemoteMnu_CheckStateChanged(object sender, EventArgs e)
		{
			var itm = (ToolStripMenuItem)sender;
			MessageBox.Show("Changed to " + itm.CheckState); 
		}
	}
}
