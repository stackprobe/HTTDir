using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Drawing;
using System.IO;

namespace HTTDir
{
	public static class Gnd
	{
		public const string HTT_APP_UUID = "{4a33312e-c34a-424e-bc11-31842fcbd78f}";

		public static bool AccessIconEnabled = false;

		public static void LoadConfFile()
		{
			try
			{
				string[] lines = File.ReadAllLines(Path.Combine(BootTools.SelfDir, "HTTDir.conf"));
				lines = いらん行を除去(lines);
				int c = 0;

				AccessIconEnabled = int.Parse(lines[c++]) != 0;
				// ここへ追加..
			}
			catch
			{ }
		}

		private static string[] いらん行を除去(string[] src)
		{
			List<string> dest = new List<string>();

			foreach (string line in src)
				if (line != "" && line[0] != ';')
					dest.Add(line);

			return dest.ToArray();
		}

		public static EventWaitHandle EndProcEvent;
		public static SaveData Sd = new SaveData();
		public static HTTProc HTTProc;
		public static Icon OffIcon;
		public static Icon OnIcon;
		public static Icon AccessIcon;
	}
}
