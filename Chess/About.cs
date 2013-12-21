using System;
using System.Reflection;
using System.Windows.Forms;

namespace Cselian.Chess
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
			Text = String.Format("About Cselian's Chess");

			var yr = 2013;
			var dt = System.IO.File.GetLastWriteTime(System.Windows.Forms.Application.ExecutablePath).ToShortDateString();
			labelProductName.Text = "Simplified Chess";
			labelVersion.Text = String.Format("v{0} dated {1}", AssemblyVersion, dt);
			labelCopyright.Text = string.Format("(c) {0}{1}", DateTime.Now.Year.Equals(yr) ? string.Empty : yr + " to ", DateTime.Now.Year);
			labelCompanyName.Text = "Imran@cselian.com / builders@yieldmore.org";
		}

		#region Assembly Attribute Accessors

		public string AssemblyVersion
		{
			get
			{
				return "1.0.11"; // TODO: Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		#endregion

		private void About_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				Close();
			}
		}
	}
}
