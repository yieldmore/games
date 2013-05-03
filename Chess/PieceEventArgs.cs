using System;
using System.Collections.Generic;

namespace Cselian.Chess
{
	public class PieceEventArgs : EventArgs
	{

		public bool Movable { get { return Options.Count != 0; } }
		public readonly List<Square> Options = new List<Square>();
		public PieceEventArgs() { }

		public readonly Square NewSquare;
		public readonly PieceId? NewSquarePiece;
		public PieceEventArgs(Square newSquare) { NewSquarePiece = (NewSquare = newSquare).Piece; }
	
	}
}
