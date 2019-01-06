using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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

		public static void AntiWindowsDefenderSmartScreen()
		{
			WriteLog("awdss_1");

			if (初回起動Flag)
			{
				WriteLog("awdss_2");

				foreach (string exeFile in Directory.GetFiles(BootTools.SelfDir, "*.exe", SearchOption.AllDirectories))
				{
					try
					{
						WriteLog("awdss_exeFile: " + exeFile);

						if (exeFile.ToLower() == BootTools.SelfFile.ToLower())
						{
							WriteLog("awdss_self_noop");
						}
						else
						{
							byte[] exeData = File.ReadAllBytes(exeFile);
							File.Delete(exeFile);
							File.WriteAllBytes(exeFile, exeData);
						}
						WriteLog("awdss_OK");
					}
					catch (Exception e)
					{
						WriteLog(e);
					}
				}
				WriteLog("awdss_3");
			}
			WriteLog("awdss_4");
		}

		private static bool 初回起動Flag = false;
		private static string LogFile = null;
		private static long WL_Count = 0;

		public static void WriteLog(object message)
		{
			try
			{
				if (LogFile == null)
				{
					LogFile = Path.Combine(BootTools.SelfDir, Path.GetFileNameWithoutExtension(BootTools.SelfFile) + ".log");

					初回起動Flag = File.Exists(LogFile) == false;
				}

				using (StreamWriter writer = new StreamWriter(LogFile, WL_Count++ % 1000 != 0, Encoding.UTF8))
				{
					writer.WriteLine("[" + DateTime.Now + "] " + message);
				}
			}
			catch
			{ }
		}
	}
}
