using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Cselian.Chess
{
	public static class WinHelper
	{
		private static Dictionary<CheckState, CheckState> Tristates = new Dictionary<CheckState, CheckState>
		{
			{ CheckState.Unchecked, CheckState.Indeterminate },
			{ CheckState.Indeterminate, CheckState.Checked },
			{ CheckState.Checked, CheckState.Unchecked },
		};

		public static void CycleTristate(ToolStripMenuItem itm, EventHandler checkedChanged)
		{
			itm.Click += tsitm_Click;
			itm.CheckedChanged += checkedChanged;
		}

		private static void tsitm_Click(object sender, EventArgs e)
		{
			var itm = (ToolStripMenuItem)sender;
			itm.CheckState = Tristates[itm.CheckState];
		}
	}
}
