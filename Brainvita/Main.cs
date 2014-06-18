using System.Collections.Generic;
using System.Windows.Forms;

namespace Cselian.Games.Brainvita
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			Marble.SetMarbles(this);
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
			Marble.Reset();
		}
	}
}
