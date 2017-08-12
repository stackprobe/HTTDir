﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTDir
{
	public class SaveData
	{
		public int PortNo = 80;
		public int ConsoleMode = 0; // 隠しモード, 0-2 == { hide, minimum, normal }

		public void DoLoad()
		{
			try
			{
				string[] lines = File.ReadAllLines(DAT_FILE, StringTools.ENCODING_SJIS);
				int c = 0;

				// ---- load data ----

				this.PortNo = IntTools.ToRange(int.Parse(lines[c++]), 1, 65535);
				this.ConsoleMode = IntTools.ToRange(int.Parse(lines[c++]), 0, 2);

				// ----
			}
			catch
			{ }
		}

		public void DoSave()
		{
			try
			{
				List<string> lines = new List<string>();

				// ---- save data ----

				lines.Add("" + this.PortNo);
				lines.Add("" + this.ConsoleMode);

				// ----

				File.WriteAllLines(DAT_FILE, lines, StringTools.ENCODING_SJIS);
			}
			catch
			{ }
		}

		private static string DAT_FILE
		{
			get
			{
				return Path.Combine(BootTools.SelfDir, "HTTDir.dat");
			}
		}
	}
}
