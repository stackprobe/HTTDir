namespace HTTDir
{
	partial class SettingWin
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingWin));
			this.label1 = new System.Windows.Forms.Label();
			this.PortNo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DocRoot = new System.Windows.Forms.TextBox();
			this.DocRootMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.デフォルトDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.BtnOk = new System.Windows.Forms.Button();
			this.BtnDocRoot = new System.Windows.Forms.Button();
			this.DocRootMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "ポート番号：";
			// 
			// PortNo
			// 
			this.PortNo.Location = new System.Drawing.Point(105, 27);
			this.PortNo.MaxLength = 5;
			this.PortNo.Name = "PortNo";
			this.PortNo.Size = new System.Drawing.Size(100, 27);
			this.PortNo.TabIndex = 1;
			this.PortNo.Text = "65535";
			this.PortNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.PortNo.TextChanged += new System.EventHandler(this.PortNo_TextChanged);
			this.PortNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortNo_KeyPress);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "ドキュメント ルート：";
			// 
			// DocRoot
			// 
			this.DocRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DocRoot.ContextMenuStrip = this.DocRootMenu;
			this.DocRoot.Location = new System.Drawing.Point(161, 78);
			this.DocRoot.Name = "DocRoot";
			this.DocRoot.ReadOnly = true;
			this.DocRoot.Size = new System.Drawing.Size(226, 27);
			this.DocRoot.TabIndex = 3;
			this.DocRoot.Text = "DocRoot";
			this.DocRoot.TextChanged += new System.EventHandler(this.DocRoot_TextChanged);
			this.DocRoot.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DocRoot_KeyPress);
			// 
			// DocRootMenu
			// 
			this.DocRootMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.デフォルトDToolStripMenuItem});
			this.DocRootMenu.Name = "DocRootMenu";
			this.DocRootMenu.Size = new System.Drawing.Size(156, 26);
			// 
			// デフォルトDToolStripMenuItem
			// 
			this.デフォルトDToolStripMenuItem.Name = "デフォルトDToolStripMenuItem";
			this.デフォルトDToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.デフォルトDToolStripMenuItem.Text = "デフォルト(&D)";
			this.デフォルトDToolStripMenuItem.Click += new System.EventHandler(this.デフォルトDToolStripMenuItem_Click);
			// 
			// BtnCancel
			// 
			this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnCancel.Location = new System.Drawing.Point(354, 128);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(94, 38);
			this.BtnCancel.TabIndex = 6;
			this.BtnCancel.Text = "キャンセル";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// BtnOk
			// 
			this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnOk.Location = new System.Drawing.Point(254, 128);
			this.BtnOk.Name = "BtnOk";
			this.BtnOk.Size = new System.Drawing.Size(94, 38);
			this.BtnOk.TabIndex = 5;
			this.BtnOk.Text = "OK";
			this.BtnOk.UseVisualStyleBackColor = true;
			this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// BtnDocRoot
			// 
			this.BtnDocRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnDocRoot.Location = new System.Drawing.Point(393, 78);
			this.BtnDocRoot.Name = "BtnDocRoot";
			this.BtnDocRoot.Size = new System.Drawing.Size(55, 27);
			this.BtnDocRoot.TabIndex = 4;
			this.BtnDocRoot.Text = "変更";
			this.BtnDocRoot.UseVisualStyleBackColor = true;
			this.BtnDocRoot.Click += new System.EventHandler(this.BtnDocRoot_Click);
			// 
			// SettingWin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 178);
			this.Controls.Add(this.BtnDocRoot);
			this.Controls.Add(this.BtnOk);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.DocRoot);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.PortNo);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingWin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "HTTDir";
			this.TopMost = true;
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingWin_FormClosed);
			this.Load += new System.EventHandler(this.SettingWin_Load);
			this.Shown += new System.EventHandler(this.SettingWin_Shown);
			this.DocRootMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PortNo;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox DocRoot;
		private System.Windows.Forms.Button BtnCancel;
		private System.Windows.Forms.Button BtnOk;
		private System.Windows.Forms.Button BtnDocRoot;
		private System.Windows.Forms.ContextMenuStrip DocRootMenu;
		private System.Windows.Forms.ToolStripMenuItem デフォルトDToolStripMenuItem;
	}
}
