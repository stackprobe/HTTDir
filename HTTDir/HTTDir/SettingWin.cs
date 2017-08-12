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
	public partial class SettingWin : Form
	{
		public SettingWin()
		{
			InitializeComponent();
		}

		private void SettingWin_Load(object sender, EventArgs e)
		{
			this.MinimumSize = this.Size;
			this.DoLoad();
		}

		private void SettingWin_Shown(object sender, EventArgs e)
		{
			this.PortNo.SelectAll();
			this.DocRoot.SelectionStart = this.DocRoot.Text.Length;
		}

		private void SettingWin_FormClosed(object sender, FormClosedEventArgs e)
		{
			// noop
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			this.DoSave();
			this.Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// データ読み書き >

		private void DoLoad()
		{
			try
			{
				this.PortNo.Text = "" + Gnd.Sd.PortNo;
				this.DocRoot.Text = DocRootFltr(File.ReadAllLines(DOC_ROOT_FILE, StringTools.ENCODING_SJIS)[0].Substring("default ".Length));
			}
			catch
			{ }
		}

		private void DoSave()
		{
			try
			{
				Gnd.Sd.PortNo = IntTools.Parse(this.PortNo.Text, 80, 1, 65535);

				File.WriteAllLines(
					DOC_ROOT_FILE,
					new string[] { "default " + DocRootFltr(this.DocRoot.Text) },
					StringTools.ENCODING_SJIS
					);
			}
			catch
			{ }
		}

		private static readonly string DOC_ROOT_FILE = "DocRoot.dat";

		// < データ読み書き

		private static string DocRootFltr(string dir, bool errDlgFlg = false)
		{
			try
			{
				if (dir.StartsWith("\\\\"))
					throw new Exception("ネットワークフォルダは使用できません。");

				if (dir != StringTools.ENCODING_SJIS.GetString(StringTools.ENCODING_SJIS.GetBytes(dir)))
					throw new Exception("Shift_JIS に変換出来ない文字を含むパスは使用できません。");

				dir = dir.Trim();

				if (dir == "")
					throw new Exception("空文字列は使用できません。");

				dir = Path.GetFullPath(dir);
			}
			catch (Exception e)
			{
				if (errDlgFlg)
				{
					MessageBox.Show(
						"" + e.Message,
						"パスの設定に失敗しました",
						MessageBoxButtons.OK,
						MessageBoxIcon.Warning
						);
				}
				return DEF_DOC_ROOT;
			}

			{
				string currDir = Directory.GetCurrentDirectory();
				currDir += "\\";
				currDir = currDir.Replace("\\\\", "\\");

				if (currDir.Length < dir.Length && StringTools.EqualsIgnoreCase(currDir, dir.Substring(0, currDir.Length)))
					dir = dir.Substring(currDir.Length);
			}

			return dir;
		}

		private void BtnDocRoot_Click(object sender, EventArgs e)
		{
			string homeDir = Directory.GetCurrentDirectory();

			try
			{
				//FolderBrowserDialogクラスのインスタンスを作成
				using (FolderBrowserDialog fbd = new FolderBrowserDialog())
				{
					//上部に表示する説明テキストを指定する
					//fbd.Description = "フォルダを指定してください。";
					fbd.Description = "ドキュメント ルート を指定してください。";
					//ルートフォルダを指定する
					//デフォルトでDesktop
					fbd.RootFolder = Environment.SpecialFolder.Desktop;
					//最初に選択するフォルダを指定する
					//RootFolder以下にあるフォルダである必要がある
					//fbd.SelectedPath = @"C:\Windows";
					fbd.SelectedPath = Path.GetFullPath(DocRootFltr(this.DocRoot.Text));
					//ユーザーが新しいフォルダを作成できるようにする
					//デフォルトでTrue
					fbd.ShowNewFolderButton = true;

					//ダイアログを表示する
					if (fbd.ShowDialog(this) == DialogResult.OK)
					{
						//選択されたフォルダを表示する
						//Console.WriteLine(fbd.SelectedPath);
						this.DocRoot.Text = DocRootFltr(fbd.SelectedPath, true);
						this.DocRoot.Focus();
						this.DocRoot.SelectAll();
					}
				}
			}
			catch
			{
				this.DocRoot.Text = DEF_DOC_ROOT;
			}
			finally
			{
				Directory.SetCurrentDirectory(homeDir);
			}
		}

		private void PortNo_TextChanged(object sender, EventArgs e)
		{
			if (this.PortNo.Text == "" + IntTools.ToRange(IntTools.Parse(this.PortNo.Text, 1), 1, 65535))
				this.PortNo.ForeColor = Color.Black;
			else
				this.PortNo.ForeColor = Color.Red;
		}

		private void PortNo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				e.Handled = true;
				this.DocRoot.Focus();
			}
		}

		private void DocRoot_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)13)
			{
				e.Handled = true;
				this.BtnOk.Focus();
			}
			else if (e.KeyChar == (char)32)
			{
				e.Handled = true;
				this.BtnDocRoot_Click(null, null);
			}
			else if (e.KeyChar == (char)1)
			{
				e.Handled = true;
				this.DocRoot.SelectAll();
			}
		}

		private void デフォルトDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.DocRoot.Text = DEF_DOC_ROOT;
		}

		private const string DEF_DOC_ROOT = "DocRoot";

		private void DocRoot_TextChanged(object sender, EventArgs e)
		{
			// noop
		}
	}
}
