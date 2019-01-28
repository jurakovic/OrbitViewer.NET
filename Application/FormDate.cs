using OrbitViewer.Applet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OrbitViewer.Application
{
	public partial class FormDate : Form
	{
		#region Const

		private const string NextYear = "NextYear";
		private const string PrevYear = "PrevYear";

		#endregion

		#region Properties

		public ATime ATime { get; private set; }

		#endregion

		#region Constructor

		public FormDate(ATime atime)
		{
			InitializeComponent();

			numDay.Minimum = 0;
			numDay.Maximum = 32;
			numYear.Minimum = ATime.MinATime.Year;
			numYear.Maximum = ATime.MaxATime.Year;

			ATime = atime;
		}

		#endregion

		#region + EventHandling

		#region Form

		private void FormDate_Load(object sender, EventArgs e)
		{
			List<string> monthItems = new List<string>();
			monthItems.Add(NextYear);
			monthItems.AddRange(ATime.MonthAbbrConst.Reverse());
			monthItems.Add(PrevYear);

			domMonth.Items.AddRange(monthItems);
			domMonth.SelectedIndex = 13 - ATime.Month;
			numDay.Value = ATime.Day;
			numYear.Value = ATime.Year;
		}

		private void FormDate_FormClosed(object sender, FormClosedEventArgs e)
		{
			ATime = ATime.LimitATime(new ATime((int)numYear.Value, 13 - (int)domMonth.SelectedIndex, (double)numDay.Value, 0.0));
		}

		#endregion

		#region Date

		private void numDay_ValueChanged(object sender, EventArgs e)
		{
			if (numDay.Value <= numDay.Minimum)
			{
				domMonth.SelectedIndex++;
				numDay.Value = numDay.Maximum - 1;
			}
			else if (numDay.Value >= numDay.Maximum)
			{
				numDay.Value = numDay.Minimum + 1;
				domMonth.SelectedIndex--;
			}
		}

		private void domMonth_SelectedItemChanged(object sender, EventArgs e)
		{
			if ((string)domMonth.SelectedItem == NextYear)
			{
				domMonth.SelectedIndex = 12;
				numYear.Value++;
			}
			else if ((string)domMonth.SelectedItem == PrevYear)
			{
				domMonth.SelectedIndex = 1;
				numYear.Value--;
			}

			int month = 13 - domMonth.SelectedIndex;
			int daysInMonth = DateTime.DaysInMonth((int)numYear.Value, month);
			numDay.Maximum = daysInMonth + 1;

			if (numDay.Value >= numDay.Maximum)
				numDay.Value = numDay.Maximum - 1;
		}

		private void numYear_ValueChanged(object sender, EventArgs e)
		{
			if ((string)domMonth.SelectedItem == "Feb.")
			{
				int month = 13 - domMonth.SelectedIndex;
				int daysInMonth = DateTime.DaysInMonth((int)numYear.Value, month);
				numDay.Maximum = daysInMonth + 1;

				if (numDay.Value >= numDay.Maximum)
					numDay.Value = numDay.Maximum - 1;
			}
		}

		private void btnToday_Click(object sender, EventArgs e)
		{
			domMonth.SelectedIndex = 13 - DateTime.Now.Month;
			numDay.Value = DateTime.Now.Day;
			numYear.Value = DateTime.Now.Year;
		}

		#endregion

		#endregion
	}
}
