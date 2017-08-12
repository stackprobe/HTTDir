using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HTTDir
{
	public class SystemTools
	{
		public static Queue<string> GetArgq()
		{
			string[] args = Environment.GetCommandLineArgs();
			Queue<string> argq = new Queue<string>();

			for (int index = 1; index < args.Length; index++)
				argq.Enqueue(args[index]);

			return argq;
		}

		public static void Error(Exception e)
		{
			try
			{
				MessageBox.Show(
					"" + e,
					Program.APP_TITLE + " / Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
			catch
			{ }
		}
	}
}
