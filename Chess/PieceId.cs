namespace Cselian.Chess
{
	public struct PieceId
	{
		public readonly bool Black;
		public readonly Who Who;
		public readonly int Index;

		public PieceId(bool black, Who who, int index)
		{
			Black = black;
			Who = who;
			Index = index;
		}

		public override string ToString()
		{
			return (Black ? "Black " : "White ") + Who.ToString() + (Index > 0 ? " " + Index : string.Empty);
		}
	}
}
