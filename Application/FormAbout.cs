using System.Diagnostics;
using System.Windows.Forms;

namespace OrbitViewer.Application
{
	public partial class FormAbout : Form
	{
		public FormAbout()
		{
			InitializeComponent();
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://jurakovic.github.io");
		}
	}
}
