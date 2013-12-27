using System.Windows.Forms;
using Cselian.Chess.Game;

namespace Cselian.Chess
{
	public class UIModes
	{
		public enum UIState
		{
			Same_Window = 0,
			Dual_Window = 1,
			Remote = 2,
		}

		public UIState State { get; set; }

		public bool Clear { get; set; }

		public bool IsHost { get; private set; }

		public ChessGame Game { get; private set; }

		public UIModes(ChessGame game, UIState state, bool host)
			: this(state, host)
		{
			Game = game;
		}

		public UIModes(UIState state, bool host)
		{
			State = state;
			IsHost = host;
		}

		public Board Board { get; private set; }

		public Board InvertedBoard { get; private set; }

		public void CreateBoards(Control board, Control oppBoard, Control killed, Control oppKilled)
		{
			Board = new Board(board, killed, oppKilled, false);
			InvertedBoard = new Board(oppBoard, null, null, true);

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

		public void Show()
		{
			if (Game == null)
			{
				Game = new ChessGame(this);
			}

			Game.Show();
		}

		public void Hide()
		{
			if (Game != null)
			{
				Game.Hide();
			}
		}
	}
}
