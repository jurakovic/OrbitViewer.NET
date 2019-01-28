using System;
using System.Threading;
using System.Windows.Forms;

namespace OrbitViewer.Application
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
				System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

				System.Windows.Forms.Application.EnableVisualStyles();
				System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
				System.Windows.Forms.Application.Run(new FormMain());
			}
			catch (TypeInitializationException)
			{
				ShowErrorMessage("OrbitViewer.dll not found");
			}
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs args)
		{
			ShowErrorMessage(args.Exception.Message);
		}

		private static void ShowErrorMessage(string message)
		{
			MessageBox.Show(message, "OrbitViewer.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
