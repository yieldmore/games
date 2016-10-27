using System;
using System.Windows.Forms;

namespace Cselian.Cards
{
	public partial class CardGame : Form
	{
		public CardGame()
		{
			InitializeComponent();
		}

		private void Solitaire_Load(object sender, EventArgs e)
		{
			newGameToolStripMenuItem.PerformClick();
		}

		private void PlayingRegion_SizeChanged(object sender, EventArgs e)
		{
			this.AutoScrollMinSize = PlayingRegion.ClientSize;
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayingRegion.Controls.Clear();
			new Freecell(PlayingRegion);
		}
	}
}
