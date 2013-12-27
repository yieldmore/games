using System;
using System.Windows.Forms;
using Cselian.Chess.Game;

namespace Cselian.Chess
{
	public partial class ChessGame : Form
	{
		private UIModes Mode;

		Board b1, b2;

		public ChessGame(UIModes mode = null)
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

			Mode = mode ?? new UIModes(UIModes.UIState.Dual_Window, false);
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);

			UIModeMnu.CycleStates<UIModes.UIState>(UIModeMnu_StateChanged);
			SetUIState();
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

		private void UIModeMnu_StateChanged(object sender, EventArgs e)
		{
			Mode.State = UIModeMnu.GetState<UIModes.UIState>();
			SetUIState();
		}

		private void SetUIState()
		{
			var txt = Mode.State.ToString().Replace("_", " ");
			// MessageBox.Show("Changed to " + txt);
			UIModeMnu.Text = "UI: " + txt;

			if (Mode.State == UIModes.UIState.Dual_Window && Mode.IsHost == false)
			{
				//new ChessGame(new UIModes(Mode.State, true)).Show();
			}
		}

		private void AboutMnu_Click(object sender, EventArgs e)
		{
			new About().ShowDialog();
		}
	}
}
