namespace Cselian.Games.PickupSticks
{
	partial class Main
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
			this.btnShuffle = new System.Windows.Forms.Button();
			this.pnlSticks = new System.Windows.Forms.Panel();
			this.lblMsg = new System.Windows.Forms.Label();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.chkShow = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnShuffle
			// 
			this.btnShuffle.Location = new System.Drawing.Point(147, 8);
			this.btnShuffle.Name = "btnShuffle";
			this.btnShuffle.Size = new System.Drawing.Size(75, 23);
			this.btnShuffle.TabIndex = 0;
			this.btnShuffle.Text = "&Shuffle";
			this.btnShuffle.UseVisualStyleBackColor = true;
			this.btnShuffle.Click += new System.EventHandler(this.btnShuffle_Click);
			// 
			// pnlSticks
			// 
			this.pnlSticks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlSticks.Location = new System.Drawing.Point(12, 41);
			this.pnlSticks.Name = "pnlSticks";
			this.pnlSticks.Size = new System.Drawing.Size(510, 259);
			this.pnlSticks.TabIndex = 1;
			this.pnlSticks.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSticks_Paint);
			this.pnlSticks.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlSticks_MouseDown);
			// 
			// lblMsg
			// 
			this.lblMsg.AutoSize = true;
			this.lblMsg.Location = new System.Drawing.Point(228, 13);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size(164, 13);
			this.lblMsg.TabIndex = 0;
			this.lblMsg.Text = "click the topmost line to remove it";
			// 
			// txtCount
			// 
			this.txtCount.Location = new System.Drawing.Point(116, 10);
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(25, 20);
			this.txtCount.TabIndex = 2;
			this.txtCount.Text = "15";
			// 
			// chkShow
			// 
			this.chkShow.AutoSize = true;
			this.chkShow.Location = new System.Drawing.Point(12, 12);
			this.chkShow.Name = "chkShow";
			this.chkShow.Size = new System.Drawing.Size(98, 17);
			this.chkShow.TabIndex = 3;
			this.chkShow.Text = "Show &Numbers";
			this.chkShow.UseVisualStyleBackColor = true;
			this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 312);
			this.Controls.Add(this.chkShow);
			this.Controls.Add(this.txtCount);
			this.Controls.Add(this.lblMsg);
			this.Controls.Add(this.pnlSticks);
			this.Controls.Add(this.btnShuffle);
			this.MinimumSize = new System.Drawing.Size(550, 350);
			this.Name = "Main";
			this.Text = "Cselian - Pickupsticks";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnShuffle;
		private System.Windows.Forms.Panel pnlSticks;
		private System.Windows.Forms.Label lblMsg;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.CheckBox chkShow;
	}
}

