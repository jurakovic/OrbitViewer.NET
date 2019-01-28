namespace OrbitViewer.Application
{
	partial class FormDate
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
			this.numDay = new System.Windows.Forms.NumericUpDown();
			this.domMonth = new System.Windows.Forms.DomainUpDown();
			this.numYear = new System.Windows.Forms.NumericUpDown();
			this.btnToday = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numYear)).BeginInit();
			this.SuspendLayout();
			// 
			// numDay
			// 
			this.numDay.Location = new System.Drawing.Point(64, 3);
			this.numDay.Name = "numDay";
			this.numDay.Size = new System.Drawing.Size(58, 21);
			this.numDay.TabIndex = 1;
			this.numDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numDay.ValueChanged += new System.EventHandler(this.numDay_ValueChanged);
			// 
			// domMonth
			// 
			this.domMonth.BackColor = System.Drawing.SystemColors.Window;
			this.domMonth.Location = new System.Drawing.Point(3, 3);
			this.domMonth.Name = "domMonth";
			this.domMonth.ReadOnly = true;
			this.domMonth.Size = new System.Drawing.Size(58, 21);
			this.domMonth.TabIndex = 0;
			this.domMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.domMonth.SelectedItemChanged += new System.EventHandler(this.domMonth_SelectedItemChanged);
			// 
			// numYear
			// 
			this.numYear.Location = new System.Drawing.Point(124, 3);
			this.numYear.Name = "numYear";
			this.numYear.Size = new System.Drawing.Size(58, 21);
			this.numYear.TabIndex = 2;
			this.numYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numYear.ValueChanged += new System.EventHandler(this.numYear_ValueChanged);
			// 
			// btnToday
			// 
			this.btnToday.Location = new System.Drawing.Point(2, 26);
			this.btnToday.Name = "btnToday";
			this.btnToday.Size = new System.Drawing.Size(60, 23);
			this.btnToday.TabIndex = 3;
			this.btnToday.Text = "Today";
			this.btnToday.UseVisualStyleBackColor = true;
			this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(63, 26);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(60, 23);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(123, 26);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(60, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// FormDate
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(185, 52);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnToday);
			this.Controls.Add(this.numDay);
			this.Controls.Add(this.domMonth);
			this.Controls.Add(this.numYear);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormDate";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Date";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDate_FormClosed);
			this.Load += new System.EventHandler(this.FormDate_Load);
			((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numYear)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numDay;
		private System.Windows.Forms.DomainUpDown domMonth;
		private System.Windows.Forms.NumericUpDown numYear;
		private System.Windows.Forms.Button btnToday;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
	}
}