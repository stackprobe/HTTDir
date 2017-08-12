using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HTTDir
{
	public partial class MainWin : Form
	{
		public MainWin()
		{
			InitializeComponent();

			Gnd.Sd.DoLoad();
			Gnd.HTTProc = new HTTProc();
			Gnd.OffIcon = new Icon(GetOffIconFile());
			Gnd.OnIcon = new Icon(GetOnIconFile());
			//Gnd.OnIcon = this.TaskTrayIcon.Icon;
			Gnd.AccessIcon = new Icon(GetAccessIconFile());
		}

		private static string GetOffIconFile()
		{
			string file = "OffIcon.dat";

			if (File.Exists(file) == false)
				file = @"..\..\httd_16_off.ico"; // dev env

			return file;
		}

		private static string GetOnIconFile()
		{
			string file = "OnIcon.dat";

			if (File.Exists(file) == false)
				file = @"..\..\httd_16_on.ico"; // dev env

			return file;
		}

		private static string GetAccessIconFile()
		{
			string file = "AccessIcon.dat";

			if (File.Exists(file) == false)
				file = @"..\..\httd_16_access.ico"; // dev env

			return file;
		}

		private void MainWin_Load(object sender, EventArgs e)
		{
			// noop
		}

		private void MainWin_Shown(object sender, EventArgs e)
		{
			this.Visible = false;
			this.TaskTrayIcon.Visible = true;
			this.MT_Enabled = true;
		}

		private void MainWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.MT_Enabled = false;
			this.TaskTrayIcon.Visible = false;

			Gnd.HTTProc.Destroy_BusyDlg();
			Gnd.HTTProc = null;
		}

		private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private bool MT_Enabled;
		private bool MT_Busy;
		private long MT_Count;

		private void MainTimer_Tick(object sender, EventArgs e)
		{
			if (this.MT_Enabled == false || this.MT_Busy)
				return;

			this.MT_Busy = true;

			try
			{
				if (Gnd.EndProcEvent.WaitOne(0))
				{
					this.Close();
					return;
				}

				{
					Icon icon;

					if (Gnd.HTTProc.IsRunning() == false)
						icon = Gnd.OffIcon;
					else if (Gnd.AccessIconEnabled == false || this.MT_Count % 2 == 0 || AccessMonitor.I.HasAccess() == false)
						icon = Gnd.OnIcon;
					else
						icon = Gnd.AccessIcon;

					if (this.TaskTrayIcon.Icon != icon)
						this.TaskTrayIcon.Icon = icon;
				}

				if (this.MT_Count % 1000 == 0)
				{
					GC.Collect();
				}
			}
			catch (Exception ex)
			{
				this.MT_Enabled = false;
				throw ex;
			}
			finally
			{
				this.MT_Count++;
				this.MT_Busy = false;
			}
		}

		private void 再起動ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.MT_Enabled = false;
			this.TaskTrayIcon.Visible = false;

			Gnd.HTTProc.Destroy_BusyDlg();
			Gnd.HTTProc = new HTTProc();

			this.TaskTrayIcon.Visible = true;
			this.MT_Enabled = true;
		}

		private void 設定ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.MT_Enabled = false;
			this.TaskTrayIcon.Visible = false;

			Gnd.HTTProc.Destroy_BusyDlg();
			Gnd.HTTProc = null;

			using (SettingWin f = new SettingWin())
			{
				f.ShowDialog();
			}

			Gnd.Sd.DoSave();
			Gnd.HTTProc = new HTTProc();

			this.TaskTrayIcon.Visible = true;
			this.MT_Enabled = true;
		}
	}
}
