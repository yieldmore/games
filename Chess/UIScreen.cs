using System.Windows.Forms;
using Cselian.Chess.Game;

namespace Cselian.Chess
{
	public class UIScreen
	{
		public enum UIState
		{
			Same_Screen = 0,
			Dual_Screens = 1,
			Remote = 2,
		}

		public UIState State { get; set; }

		public bool Clear { get; set; }

		public bool IsHost { get; private set; }

		public ChessGame Game { get; private set; }

		public UIScreen(ChessGame game, UIState state, bool host)
			: this(state, host)
		{
			Game = game;
		}

		public UIScreen(UIState state, bool host)
		{
			State = state;
			IsHost = host;
		}

		public Board Board { get; private set; }

		public Board InvertedBoard { get; private set; }

		public void CreateBoards(Control board, Control oppBoard, Control killed, Control oppKilled)
		{
			var inverseForWhite = !IsHost;
			Board = new Board(board, killed, oppKilled, inverseForWhite);
			InvertedBoard = new Board(oppBoard, null, null, !inverseForWhite);

			Board.SetOtherBoard(InvertedBoard);
			InvertedBoard.SetOtherBoard(Board);
		}

		public void ClearBoards(Control board, Control oppBoard, Control killed, Control oppKilled)
		{
			board.Controls.Clear();
			oppBoard.Controls.Clear();
			oppKilled.Controls.Clear();
			killed.Controls.Clear();
		}

		public void CreateGame()
		{
			Game = new ChessGame(this);
		}

		public void SetState()
		{
			Game.SetOtherVisible(State == UIState.Same_Screen);

			switch (State)
			{
				case UIState.Dual_Screens:
					Game.Text = "[" + (IsHost ? "White" : "Black") + "] Chess by Cselian";
					break;
				case UIState.Remote:
					Game.Text = "Remote Chess by Cselian [with: " + Game.GetOtherIP() + "]";
					break;
				case UIState.Same_Screen:
				default:
					Game.Text = "Chess by Cselian";
					break;
			}
		}
	}
}
