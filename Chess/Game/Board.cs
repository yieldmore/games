using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cselian.Chess.Game
{
	public class Board
	{

		#region Pieces and their starting places (static)

		private static Dictionary<PieceId, Point> pieces = new Dictionary<PieceId, Point>();

		static Board() 
		{
			//Pawn
			for (int i = 1; i < 9; i++)
			{
				pieces.Add(new PieceId(false, Who.Pawn, i), new Point(i, 2));
				pieces.Add(new PieceId(true, Who.Pawn, i), new Point(i, 7));
			}

			//Bishops
			pieces.Add(new PieceId(false, Who.Bishop, 1), new Point(3, 1));
			pieces.Add(new PieceId(false, Who.Bishop, 2), new Point(6, 1));
			pieces.Add(new PieceId(true, Who.Bishop, 1), new Point(3, 8));
			pieces.Add(new PieceId(true, Who.Bishop, 2), new Point(6, 8));

			//Knights
			pieces.Add(new PieceId(false, Who.Knight, 1), new Point(2, 1));
			pieces.Add(new PieceId(false, Who.Knight, 2), new Point(7, 1));
			pieces.Add(new PieceId(true, Who.Knight, 1), new Point(2, 8));
			pieces.Add(new PieceId(true, Who.Knight, 2), new Point(7, 8));

			//Rooks
			pieces.Add(new PieceId(false, Who.Rook, 1), new Point(1, 1));
			pieces.Add(new PieceId(false, Who.Rook, 2), new Point(8, 1));
			pieces.Add(new PieceId(true, Who.Rook, 1), new Point(1, 8));
			pieces.Add(new PieceId(true, Who.Rook, 2), new Point(8, 8));

			//QK
			pieces.Add(new PieceId(false, Who.Queen, 0), new Point(4, 1));
			pieces.Add(new PieceId(false, Who.King, 0), new Point(5, 1));
			pieces.Add(new PieceId(true, Who.Queen, 0), new Point(4, 8));
			pieces.Add(new PieceId(true, Who.King, 0), new Point(5, 8));
		}

		#endregion

		private readonly Square[,] AllSquares = new Square[9, 9];
		private readonly bool inverted; private bool blacksTurn;
		private readonly List<Piece> AllPieces = new List<Piece>();
		private readonly Control board, wKilled, bKilled;

		private Board otherBoard; 
		List<PieceId> moved = new List<PieceId>(); //track rooks and kings for castling

		public event EventHandler<PieceEventArgs> PieceMove;

		public Board(Control board, Control wKilled, Control bKilled, bool inverted)
		{
			this.board = board; this.wKilled = wKilled; this.bKilled = bKilled;
			this.inverted = inverted;
			for (int x = 1; x < 9; x++) for (int y = 1; y < 9; y++) AllSquares[x, y] = new Square(board, x, y, inverted);

			foreach (var item in pieces)
			{
				var piece = new Piece(board, item.Key, inverted) { Square = AllSquares[item.Value.X, item.Value.Y] };
				piece.BeforeMove += new EventHandler<PieceEventArgs>(piece_BeforeMove);
				piece.Move += new EventHandler<PieceEventArgs>(piece_Move);
				AllPieces.Add(piece);
			}
		}

		public void SetOtherBoard(Board board)
		{
			(otherBoard = board).PieceMove += new EventHandler<PieceEventArgs>(piece_Move);
		}

		private void piece_Move(object sender, PieceEventArgs e)
		{
			if (e.NewSquarePiece.HasValue)
			{
				xt.Item(AllPieces, e.NewSquarePiece.Value).Kill(board, bKilled, wKilled);
			}

			Piece p = xt.Item(AllPieces, (sender as Piece).Id);
			bool castling = p.Id.Who == Who.King && Math.Abs(e.NewSquare.X - p.Square.X) > 1;
			bool originatesHere = AllPieces.Contains(sender as Piece);

			moved.Add(p.Id);
			p.Square.Piece = null;
			p.Square = AllSquares[e.NewSquare.X, e.NewSquare.Y];

			if (!castling)
			{
				blacksTurn = !blacksTurn;
			}
			else if (originatesHere)
			{
				Piece rook = xt.Item(AllPieces, AllSquares[e.NewSquare.X >= 4 ? 8 : 1, p.Square.Y].Piece.Value);
				Square rookTo = AllSquares[e.NewSquare.X + (e.NewSquare.X >= 4 ? -1 : 1), p.Square.Y];
				piece_Move(rook, new PieceEventArgs(rookTo));
			}

			if (originatesHere && null != PieceMove)
				PieceMove(sender, e);
		}

		private void piece_BeforeMove(object sender, PieceEventArgs e)
		{
			Piece piece = sender as Piece;
			board.FindForm().Text = string.Format("Moving {0} from {1}", piece.Name, piece.Square.Name);
			if (piece.Id.Black != blacksTurn || (null != otherBoard && blacksTurn != inverted)) return;
			MoveResolver.Resolve(e.Options, piece, AllSquares, moved);
		}
	}
}
