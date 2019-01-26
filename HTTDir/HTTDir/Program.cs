using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace HTTDir
{
	static class Program
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			BootTools.OnBoot();

			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			SystemEvents.SessionEnding += new SessionEndingEventHandler(SessionEnding);

			Gnd.EndProcEvent = new EventWaitHandle(false, EventResetMode.AutoReset, "{8bf2b6c0-0a08-48ae-98f3-b875ce5736d6}");

			foreach (string arg in SystemTools.GetArgq())
			{
				if (StringTools.EqualsIgnoreCase(arg, "/T"))
				{
					Gnd.EndProcEvent.Set();
					return;
				}
			}
			Mutex procMutex = new Mutex(false, "{3b5530f0-a0ee-47b9-95fc-8bafab17654c}");

			if (procMutex.WaitOne(0) && GlobalProcMtx.Create("{44e1b3d2-e451-429e-b0c3-40c377244f10}", APP_TITLE))
			{
				CheckSelfDir();
				CheckCopiedExe();

				SystemTools.AntiWindowsDefenderSmartScreen();

				Gnd.LoadConfFile();

				// HTT.exe ゾンビ対策は HTTProc.ctor でやってる。

				// orig >

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainWin());

				// < orig

				GlobalProcMtx.Release();
				procMutex.ReleaseMutex();
			}
			procMutex.Close();
		}

		public const string APP_TITLE = "HTTDir";

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			try
			{
				MessageBox.Show(
					"[Application_ThreadException]\n" + e.Exception,
					APP_TITLE + " / Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
			catch
			{ }

			Environment.Exit(1);
		}

		private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				MessageBox.Show(
					"[CurrentDomain_UnhandledException]\n" + e.ExceptionObject,
					APP_TITLE + " / Error",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);
			}
			catch
			{ }

			Environment.Exit(2);
		}

		private static void SessionEnding(object sender, SessionEndingEventArgs e)
		{
			Environment.Exit(3);
		}

		private static void CheckSelfDir()
		{
			string dir = BootTools.SelfDir;
			Encoding SJIS = Encoding.GetEncoding(932);

			if (dir != SJIS.GetString(SJIS.GetBytes(dir)))
			{
				MessageBox.Show(
					"Shift_JIS に変換出来ない文字を含むパスからは実行できません。",
					APP_TITLE + " / エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);

				Environment.Exit(4);
			}
			if (dir.StartsWith("\\\\"))
			{
				MessageBox.Show(
					"ネットワークフォルダからは実行できません。",
					APP_TITLE + " / エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error
					);

				Environment.Exit(5);
			}
		}

		private static void CheckCopiedExe()
		{
			if (File.Exists("OffIcon.dat")) // リリースに含まれるファイル
				return;

			if (Directory.Exists(@"..\Debug")) // ? devenv
				return;

			MessageBox.Show(
				"WHY AM I ALONE ?",
				"",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error
				);

			Environment.Exit(6);
		}
	}
}
