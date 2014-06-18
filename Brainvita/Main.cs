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

		void Main_MouseDoubleClick(object sender, MouseEventArgs e)
		{
		}
	}
}
