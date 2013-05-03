namespace Cselian.Sudoku
{
	partial class Form1
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnPossibilities = new System.Windows.Forms.Button();
			this.btnSolve = new System.Windows.Forms.Button();
			this.btnRestart = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.Location = new System.Drawing.Point(10, 13);
			this.panel1.Margin = new System.Windows.Forms.Padding(3, 3, 100, 3);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(10);
			this.panel1.Size = new System.Drawing.Size(269, 247);
			this.panel1.TabIndex = 0;
			// 
			// btnReset
			// 
			this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnReset.Location = new System.Drawing.Point(408, 13);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(55, 23);
			this.btnReset.TabIndex = 1;
			this.btnReset.Text = "&Reset";
			this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnReset.UseVisualStyleBackColor = true;
			// 
			// btnPossibilities
			// 
			this.btnPossibilities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnPossibilities.Location = new System.Drawing.Point(408, 42);
			this.btnPossibilities.Name = "btnPossibilities";
			this.btnPossibilities.Size = new System.Drawing.Size(55, 23);
			this.btnPossibilities.TabIndex = 1;
			this.btnPossibilities.Text = "&Possible";
			this.btnPossibilities.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnPossibilities.UseVisualStyleBackColor = true;
			// 
			// btnSolve
			// 
			this.btnSolve.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSolve.Location = new System.Drawing.Point(408, 71);
			this.btnSolve.Name = "btnSolve";
			this.btnSolve.Size = new System.Drawing.Size(55, 23);
			this.btnSolve.TabIndex = 1;
			this.btnSolve.Text = "&Solve";
			this.btnSolve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSolve.UseVisualStyleBackColor = true;
			// 
			// btnRestart
			// 
			this.btnRestart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRestart.Location = new System.Drawing.Point(408, 100);
			this.btnRestart.Name = "btnRestart";
			this.btnRestart.Size = new System.Drawing.Size(55, 23);
			this.btnRestart.TabIndex = 1;
			this.btnRestart.Text = "Res&tart";
			this.btnRestart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRestart.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(472, 483);
			this.Controls.Add(this.btnSolve);
			this.Controls.Add(this.btnPossibilities);
			this.Controls.Add(this.btnRestart);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.panel1);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(480, 510);
			this.Name = "Form1";
			this.Padding = new System.Windows.Forms.Padding(10);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Sudoku";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnPossibilities;
		private System.Windows.Forms.Button btnSolve;
		private System.Windows.Forms.Button btnRestart;
	}
}

