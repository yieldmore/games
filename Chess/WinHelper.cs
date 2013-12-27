using System;
using System.Windows.Forms;

namespace Cselian.Chess
{
	public static class WinHelper
	{
		public static void CycleStates<T>(ToolStripSplitButton mnu, EventHandler setState)
		{
			var cnt = Enum.GetValues(typeof(T)).Length;
			mnu.Tag = new CnC(cnt, setState);
			for (int i = 0; i < cnt; i++)
			{
				var itm = (ToolStripMenuItem)mnu.DropDownItems[i];
				itm.Tag = mnu;
				itm.Click += tsitm_Click;
			}

			mnu.ButtonClick += mnuitm_Click;
		}

		public static T GetState<T>(ToolStripSplitButton mnu)
		{
			var tag = (CnC)mnu.Tag;
			object op = 0;
			for (int i = 0; i < tag.Count; i++)
			{
				var itm = (ToolStripMenuItem)mnu.DropDownItems[i];
				if (itm.Checked)
				{
					op = i;
				}
			}

			return (T)op;
		}

		private static void mnuitm_Click(object sender, EventArgs e)
		{
			var mnu = (ToolStripSplitButton)sender;
			var tag = (CnC)mnu.Tag;
			var ix = GetState<int>(mnu) + 1;
			if (ix == tag.Count)
			{
				ix = 0;
			}

			var itm = (ToolStripMenuItem)mnu.DropDownItems[ix];
			itm.PerformClick();
		}

		private static void tsitm_Click(object sender, EventArgs e)
		{
			var selected = (ToolStripMenuItem)sender;
			var mnu = (ToolStripSplitButton)selected.Tag;
			var tag = (CnC)mnu.Tag;
			for (int i = 0; i < tag.Count; i++)
			{
				var itm = (ToolStripMenuItem)mnu.DropDownItems[i];
				itm.Checked = itm == selected;
			}

			tag.Callback.Invoke(mnu, EventArgs.Empty);
		}

		/// <summary>
		/// Holds the Item Count and Callback Action
		/// </summary>
		private class CnC
		{
			public int Count { get; private set; }

			public EventHandler Callback { get; private set; }

			public CnC(int count, EventHandler callback)
			{
				Count = count;
				Callback = callback;
			}
		}
	}
}
