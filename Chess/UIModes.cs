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

		public bool IsHost { get; set; }

		public UIModes(UIState state, bool host)
		{
			State = state;
			IsHost = host;
		}
	}
}
