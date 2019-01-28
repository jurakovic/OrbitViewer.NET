namespace OrbitViewer.Application
{
	partial class FormAbout
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
			this.btnOk = new System.Windows.Forms.Button();
			this.lblOrbitViewer = new System.Windows.Forms.Label();
			this.lblCopyright = new System.Windows.Forms.Label();
			this.linkLabel = new System.Windows.Forms.LinkLabel();
			this.pbcIcon = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbcIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(282, 77);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(70, 22);
			this.btnOk.TabIndex = 0;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// lblOrbitViewer
			// 
			this.lblOrbitViewer.AutoSize = true;
			this.lblOrbitViewer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblOrbitViewer.Location = new System.Drawing.Point(80, 15);
			this.lblOrbitViewer.Name = "lblOrbitViewer";
			this.lblOrbitViewer.Size = new System.Drawing.Size(116, 13);
			this.lblOrbitViewer.TabIndex = 1;
			this.lblOrbitViewer.Text = "OrbitViewer.NET 1.0";
			// 
			// lblCopyright
			// 
			this.lblCopyright.AutoSize = true;
			this.lblCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCopyright.Location = new System.Drawing.Point(80, 35);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(167, 13);
			this.lblCopyright.TabIndex = 2;
			this.lblCopyright.Text = "Copyright © 2019 Luka Jurakovic";
			// 
			// linkLabel
			// 
			this.linkLabel.ActiveLinkColor = System.Drawing.Color.Blue;
			this.linkLabel.AutoSize = true;
			this.linkLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.linkLabel.Location = new System.Drawing.Point(80, 55);
			this.linkLabel.Name = "linkLabel";
			this.linkLabel.Size = new System.Drawing.Size(96, 13);
			this.linkLabel.TabIndex = 3;
			this.linkLabel.TabStop = true;
			this.linkLabel.Text = "jurakovic.github.io";
			this.linkLabel.VisitedLinkColor = System.Drawing.Color.Blue;
			this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
			// 
			// pbcIcon
			// 
			this.pbcIcon.Image = global::OrbitViewer.Application.Properties.Resources.image;
			this.pbcIcon.Location = new System.Drawing.Point(15, 12);
			this.pbcIcon.Name = "pbcIcon";
			this.pbcIcon.Size = new System.Drawing.Size(50, 50);
			this.pbcIcon.TabIndex = 4;
			this.pbcIcon.TabStop = false;
			// 
			// FormAbout
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(364, 111);
			this.Controls.Add(this.pbcIcon);
			this.Controls.Add(this.linkLabel);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.lblOrbitViewer);
			this.Controls.Add(this.btnOk);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormAbout";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			((System.ComponentModel.ISupportInitialize)(this.pbcIcon)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblOrbitViewer;
		private System.Windows.Forms.Label lblCopyright;
		private System.Windows.Forms.LinkLabel linkLabel;
		private System.Windows.Forms.PictureBox pbcIcon;
	}
}