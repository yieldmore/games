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
			this.SuspendLayout();
			// 
			// btnShuffle
			// 
			this.btnShuffle.Location = new System.Drawing.Point(12, 12);
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
			this.pnlSticks.Size = new System.Drawing.Size(535, 262);
			this.pnlSticks.TabIndex = 1;
			this.pnlSticks.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSticks_Paint);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(559, 315);
			this.Controls.Add(this.pnlSticks);
			this.Controls.Add(this.btnShuffle);
			this.Name = "Main";
			this.Text = "Cselian - Pickupsticks";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnShuffle;
		private System.Windows.Forms.Panel pnlSticks;
	}
}

