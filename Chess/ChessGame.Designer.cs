namespace Cselian.Chess
{
	partial class ChessGame
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.All = new System.Windows.Forms.SplitContainer();
			this.Killed = new System.Windows.Forms.SplitContainer();
			this.OppKilled = new System.Windows.Forms.FlowLayoutPanel();
			this.MyKilled = new System.Windows.Forms.FlowLayoutPanel();
			this.Boards = new System.Windows.Forms.SplitContainer();
			this.Board = new System.Windows.Forms.Panel();
			this.OppBoard = new System.Windows.Forms.Panel();
			this.MenuCtl = new System.Windows.Forms.ToolStrip();
			this.UIModeMnu = new System.Windows.Forms.ToolStripSplitButton();
			this.ModeDualMnu = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeSeparateMnu = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeRemoteMnu = new System.Windows.Forms.ToolStripMenuItem();
			this.ModeMyIP = new System.Windows.Forms.ToolStripTextBox();
			this.ModeOtherIP = new System.Windows.Forms.ToolStripTextBox();
			this.AboutMnu = new System.Windows.Forms.ToolStripButton();
			this.All.Panel1.SuspendLayout();
			this.All.Panel2.SuspendLayout();
			this.All.SuspendLayout();
			this.Killed.Panel1.SuspendLayout();
			this.Killed.Panel2.SuspendLayout();
			this.Killed.SuspendLayout();
			this.Boards.Panel1.SuspendLayout();
			this.Boards.Panel2.SuspendLayout();
			this.Boards.SuspendLayout();
			this.MenuCtl.SuspendLayout();
			this.SuspendLayout();
			// 
			// All
			// 
			this.All.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.All.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.All.Location = new System.Drawing.Point(10, 38);
			this.All.Name = "All";
			// 
			// All.Panel1
			// 
			this.All.Panel1.Controls.Add(this.Killed);
			// 
			// All.Panel2
			// 
			this.All.Panel2.Controls.Add(this.Boards);
			this.All.Size = new System.Drawing.Size(408, 248);
			this.All.SplitterDistance = 136;
			this.All.TabIndex = 5;
			// 
			// Killed
			// 
			this.Killed.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Killed.Location = new System.Drawing.Point(0, 0);
			this.Killed.Name = "Killed";
			this.Killed.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// Killed.Panel1
			// 
			this.Killed.Panel1.Controls.Add(this.OppKilled);
			// 
			// Killed.Panel2
			// 
			this.Killed.Panel2.Controls.Add(this.MyKilled);
			this.Killed.Size = new System.Drawing.Size(136, 248);
			this.Killed.SplitterDistance = 117;
			this.Killed.SplitterWidth = 6;
			this.Killed.TabIndex = 1;
			// 
			// OppKilled
			// 
			this.OppKilled.AutoScroll = true;
			this.OppKilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.OppKilled.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OppKilled.Location = new System.Drawing.Point(0, 0);
			this.OppKilled.Name = "OppKilled";
			this.OppKilled.Size = new System.Drawing.Size(136, 117);
			this.OppKilled.TabIndex = 3;
			// 
			// MyKilled
			// 
			this.MyKilled.AutoScroll = true;
			this.MyKilled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MyKilled.Dock = System.Windows.Forms.DockStyle.Fill;
			this.MyKilled.Location = new System.Drawing.Point(0, 0);
			this.MyKilled.Name = "MyKilled";
			this.MyKilled.Size = new System.Drawing.Size(136, 125);
			this.MyKilled.TabIndex = 3;
			// 
			// Boards
			// 
			this.Boards.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Boards.Location = new System.Drawing.Point(0, 0);
			this.Boards.Name = "Boards";
			// 
			// Boards.Panel1
			// 
			this.Boards.Panel1.Controls.Add(this.Board);
			// 
			// Boards.Panel2
			// 
			this.Boards.Panel2.Controls.Add(this.OppBoard);
			this.Boards.Size = new System.Drawing.Size(268, 248);
			this.Boards.SplitterDistance = 134;
			this.Boards.TabIndex = 0;
			// 
			// Board
			// 
			this.Board.AutoSize = true;
			this.Board.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.Board.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Board.Location = new System.Drawing.Point(0, 0);
			this.Board.Name = "Board";
			this.Board.Padding = new System.Windows.Forms.Padding(5);
			this.Board.Size = new System.Drawing.Size(143, 119);
			this.Board.TabIndex = 3;
			// 
			// OppBoard
			// 
			this.OppBoard.AutoSize = true;
			this.OppBoard.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.OppBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.OppBoard.Location = new System.Drawing.Point(0, 0);
			this.OppBoard.Name = "OppBoard";
			this.OppBoard.Padding = new System.Windows.Forms.Padding(5);
			this.OppBoard.Size = new System.Drawing.Size(149, 119);
			this.OppBoard.TabIndex = 5;
			// 
			// MenuCtl
			// 
			this.MenuCtl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UIModeMnu,
            this.AboutMnu});
			this.MenuCtl.Location = new System.Drawing.Point(10, 10);
			this.MenuCtl.Name = "MenuCtl";
			this.MenuCtl.Size = new System.Drawing.Size(408, 25);
			this.MenuCtl.TabIndex = 6;
			this.MenuCtl.Text = "MainMenu";
			// 
			// UIModeMnu
			// 
			this.UIModeMnu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.UIModeMnu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModeDualMnu,
            this.ModeSeparateMnu,
            this.ModeRemoteMnu,
            this.ModeMyIP,
            this.ModeOtherIP});
			this.UIModeMnu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.UIModeMnu.Name = "UIModeMnu";
			this.UIModeMnu.Size = new System.Drawing.Size(59, 22);
			this.UIModeMnu.Text = "&Modes";
			// 
			// ModeDualMnu
			// 
			this.ModeDualMnu.Name = "ModeDualMnu";
			this.ModeDualMnu.Size = new System.Drawing.Size(171, 22);
			this.ModeDualMnu.Text = "&Same Screen";
			// 
			// ModeSeparateMnu
			// 
			this.ModeSeparateMnu.Name = "ModeSeparateMnu";
			this.ModeSeparateMnu.Size = new System.Drawing.Size(171, 22);
			this.ModeSeparateMnu.Text = "&Dual Screens";
			// 
			// ModeRemoteMnu
			// 
			this.ModeRemoteMnu.Name = "ModeRemoteMnu";
			this.ModeRemoteMnu.Size = new System.Drawing.Size(171, 22);
			this.ModeRemoteMnu.Text = "&Remote";
			// 
			// ModeMyIP
			// 
			this.ModeMyIP.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ModeMyIP.Name = "ModeMyIP";
			this.ModeMyIP.ReadOnly = true;
			this.ModeMyIP.Size = new System.Drawing.Size(100, 23);
			this.ModeMyIP.Text = "122.164.121.127";
			this.ModeMyIP.Visible = false;
			// 
			// ModeOtherIP
			// 
			this.ModeOtherIP.Name = "ModeOtherIP";
			this.ModeOtherIP.Size = new System.Drawing.Size(100, 23);
			this.ModeOtherIP.Visible = false;
			// 
			// AboutMnu
			// 
			this.AboutMnu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.AboutMnu.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.AboutMnu.Name = "AboutMnu";
			this.AboutMnu.Size = new System.Drawing.Size(44, 22);
			this.AboutMnu.Text = "&About";
			// 
			// ChessGame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(428, 296);
			this.Controls.Add(this.MenuCtl);
			this.Controls.Add(this.All);
			this.Name = "ChessGame";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.Text = "Chess by Cselian";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.All.Panel1.ResumeLayout(false);
			this.All.Panel2.ResumeLayout(false);
			this.All.ResumeLayout(false);
			this.Killed.Panel1.ResumeLayout(false);
			this.Killed.Panel2.ResumeLayout(false);
			this.Killed.ResumeLayout(false);
			this.Boards.Panel1.ResumeLayout(false);
			this.Boards.Panel1.PerformLayout();
			this.Boards.Panel2.ResumeLayout(false);
			this.Boards.Panel2.PerformLayout();
			this.Boards.ResumeLayout(false);
			this.MenuCtl.ResumeLayout(false);
			this.MenuCtl.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer All;
		private System.Windows.Forms.SplitContainer Killed;
		private System.Windows.Forms.FlowLayoutPanel OppKilled;
		private System.Windows.Forms.FlowLayoutPanel MyKilled;
		private System.Windows.Forms.SplitContainer Boards;
		private System.Windows.Forms.Panel Board;
		private System.Windows.Forms.Panel OppBoard;
		private System.Windows.Forms.ToolStrip MenuCtl;
		private System.Windows.Forms.ToolStripSplitButton UIModeMnu;
		private System.Windows.Forms.ToolStripMenuItem ModeDualMnu;
		private System.Windows.Forms.ToolStripMenuItem ModeSeparateMnu;
		private System.Windows.Forms.ToolStripMenuItem ModeRemoteMnu;
		private System.Windows.Forms.ToolStripTextBox ModeMyIP;
		private System.Windows.Forms.ToolStripTextBox ModeOtherIP;
		private System.Windows.Forms.ToolStripButton AboutMnu;


	}
}

