using System.Collections.Generic;

namespace Cselian.Chess
{
	public class MoveResolver
	{
		/// <summary>
		/// Options
		/// </summary>
		private List<Square> o;
		private Piece p;
		private Square s;
		readonly Square[,] squares;
		readonly List<PieceId> moved;


		public MoveResolver(List<Square> list, Piece piece, Square[,] s, List<PieceId> moved)
		{
			o = list; p = piece; this.s = p.Square; squares = s; this.moved = moved;
		}

		public void Resolve()
		{
			switch (p.Id.Who)
			{
				case Who.Pawn:
					var dirn = p.Id.Black == false ? 1 : -1;

					TryAddSquare(s, -1, dirn, p.Id, false, true);

					TryAddSquare(s, 1, dirn, p.Id, false, true);

					TryAddSquare(s, 0, dirn, p.Id, true, false);

					if ((s.Y == 2 && (p.Id.Black == false)) || (s.Y == 7 && (p.Id.Black == true)))
						TryAddSquare(s, 0, dirn + dirn, p.Id, true, false);

					break;
				case Who.Bishop:
					CheckSides(true);
					break;
				case Who.Knight:
					for (int i = 0; i < 4; i++)
					{
						int x = i % 2 == 0 ? 1 : -1;
						int y = i < 2 ? -1 : 1;
						TryAddSquare(s, x * 2, y, p.Id, false, false);
						TryAddSquare(s, x, y * 2, p.Id, false, false);
					}
					break;
				case Who.Rook:
					CheckSides(false);
					break;
				case Who.Queen:
					CheckSides(false);
					CheckSides(true);
					break;
				case Who.King:
					CheckSides(false);
					CheckSides(true);
					CheckCastle();
					break;
				default:
					break;
			}

		}

		private void CheckCastle()
		{
			if (moved.Contains(p.Id)) return;
			bool lesser = true, greater = true;
			for (int i = 2; i < 8; i++)
			{
				if (i != p.Square.X && squares[i, p.Square.Y].Piece.HasValue)
				{
					if (i < p.Square.X) lesser = false; else greater = false;
				}
			}
			Square lesserRook = squares[1, p.Square.Y];
			if (lesser && lesserRook.Piece.HasValue && lesserRook.Piece.Value.Who == Who.Rook && moved.Contains(lesserRook.Piece.Value) == false)
			{
				o.Add(squares[p.Square.X - 2, p.Square.Y]);
			}
			Square greaterRook = squares[8, p.Square.Y];
			if (greater && greaterRook.Piece.HasValue && greaterRook.Piece.Value.Who == Who.Rook && moved.Contains(greaterRook.Piece.Value) == false)
			{
				o.Add(squares[p.Square.X + 2, p.Square.Y]);
			}
		}

		

		private void CheckSides(bool diagonal)
		{
			for (int i = 0; i < 4; i++)
			{
				Square s1 = s;
				int x = i % 2 == 0 ? 1 : -1;
				int y = i < 2 ? -1 : 1;
				if (!diagonal)
				{
					x = x * i % 2 == 0 ? 1 : 0; if (i > 1) x = x * -1;
					y = y * i % 2 == 0 ? 0 : 1; if (i > 1) y = y * -1;
				}
				while (TryAddSquare(s1, x, y, p.Id, false, false))
				{
					s1 = xt.Last(o);
					if (p.Id.Who == Who.King || s1.Piece.HasValue)
						break;
				}
			}
		}

		private bool TryAddSquare(Square s, int x, int y, PieceId piece, bool pawnForward, bool pawnSide)
		{
			int newX = s.X + x, newY = s.Y + y;
			if (newX > 8 || newX < 1 || newY > 8 || newY < 1)
				return false;

			Square sq = squares[newX, newY];

			if (pawnSide && (sq.Piece.HasValue == false || sq.Piece.Value.Black == piece.Black))
				return false; //if pawn & sideways, should not be blank or same color

			if (sq.Piece.HasValue && (pawnForward || sq.Piece.Value.Black == piece.Black))
				return false; //blocked by same color / any is pawn going forward

			o.Add(sq);
			return true;
		}
	}
}
