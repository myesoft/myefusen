namespace MyeFusen
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miNewFusen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miArrangeScreenLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.miArrangeScreenRight = new System.Windows.Forms.ToolStripMenuItem();
            this.miGatherFusen = new System.Windows.Forms.ToolStripMenuItem();
            this.miPutInsideScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miImport = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportFusenData = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportAllFusenData = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.miStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.ContextMenuStrip = this.cmsMain;
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Mye付箋";
            this.notifyIconMain.Visible = true;
            this.notifyIconMain.DoubleClick += new System.EventHandler(this.notifyIconMain_DoubleClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewFusen,
            this.toolStripSeparator1,
            this.miArrangeScreenLeft,
            this.miArrangeScreenRight,
            this.miGatherFusen,
            this.miPutInsideScreen,
            this.miChangeOrder,
            this.toolStripSeparator3,
            this.miImport,
            this.miExport,
            this.miStartup,
            this.toolStripSeparator2,
            this.miHelp,
            this.miVersion,
            this.toolStripSeparator4,
            this.miExit});
            this.cmsMain.Name = "contextMenuStrip1";
            this.cmsMain.Size = new System.Drawing.Size(179, 314);
            this.cmsMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMain_Opening);
            // 
            // miNewFusen
            // 
            this.miNewFusen.Name = "miNewFusen";
            this.miNewFusen.Size = new System.Drawing.Size(178, 22);
            this.miNewFusen.Text = "新しい付箋を作成(&N)";
            this.miNewFusen.Click += new System.EventHandler(this.miNewFusen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // miArrangeScreenLeft
            // 
            this.miArrangeScreenLeft.Name = "miArrangeScreenLeft";
            this.miArrangeScreenLeft.Size = new System.Drawing.Size(178, 22);
            this.miArrangeScreenLeft.Text = "左端に整列";
            this.miArrangeScreenLeft.Click += new System.EventHandler(this.miArrangeScreenLeft_Click);
            // 
            // miArrangeScreenRight
            // 
            this.miArrangeScreenRight.Name = "miArrangeScreenRight";
            this.miArrangeScreenRight.Size = new System.Drawing.Size(178, 22);
            this.miArrangeScreenRight.Text = "右端に整列";
            this.miArrangeScreenRight.Click += new System.EventHandler(this.miArrangeScreenRight_Click);
            // 
            // miGatherFusen
            // 
            this.miGatherFusen.Name = "miGatherFusen";
            this.miGatherFusen.Size = new System.Drawing.Size(178, 22);
            this.miGatherFusen.Text = "中央に集合";
            this.miGatherFusen.Click += new System.EventHandler(this.miGatherFusen_Click);
            // 
            // miPutInsideScreen
            // 
            this.miPutInsideScreen.Name = "miPutInsideScreen";
            this.miPutInsideScreen.Size = new System.Drawing.Size(178, 22);
            this.miPutInsideScreen.Text = "画面内に収める";
            this.miPutInsideScreen.ToolTipText = "プライマリモニタの画面内に付箋を再配置します";
            this.miPutInsideScreen.Click += new System.EventHandler(this.miPutInsideScreen_Click);
            // 
            // miChangeOrder
            // 
            this.miChangeOrder.Name = "miChangeOrder";
            this.miChangeOrder.Size = new System.Drawing.Size(178, 22);
            this.miChangeOrder.Text = "並び順変更";
            this.miChangeOrder.Click += new System.EventHandler(this.miChangeOrder_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(175, 6);
            // 
            // miImport
            // 
            this.miImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImportFusenData,
            this.miImportSetting});
            this.miImport.Name = "miImport";
            this.miImport.Size = new System.Drawing.Size(178, 22);
            this.miImport.Text = "インポート(&I)";
            // 
            // miImportFusenData
            // 
            this.miImportFusenData.Name = "miImportFusenData";
            this.miImportFusenData.Size = new System.Drawing.Size(177, 22);
            this.miImportFusenData.Text = "付箋データをインポート";
            this.miImportFusenData.Click += new System.EventHandler(this.miImportFusenData_Click);
            // 
            // miImportSetting
            // 
            this.miImportSetting.Name = "miImportSetting";
            this.miImportSetting.Size = new System.Drawing.Size(177, 22);
            this.miImportSetting.Text = "設定をインポート";
            this.miImportSetting.Click += new System.EventHandler(this.miImportSetting_Click);
            // 
            // miExport
            // 
            this.miExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExportAllFusenData,
            this.miExportSetting});
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(178, 22);
            this.miExport.Text = "エクスポート(&E)";
            // 
            // miExportAllFusenData
            // 
            this.miExportAllFusenData.Name = "miExportAllFusenData";
            this.miExportAllFusenData.Size = new System.Drawing.Size(217, 22);
            this.miExportAllFusenData.Text = "全ての付箋データをエクスポート";
            this.miExportAllFusenData.Click += new System.EventHandler(this.miExportAllFusenData_Click);
            // 
            // miExportSetting
            // 
            this.miExportSetting.Name = "miExportSetting";
            this.miExportSetting.Size = new System.Drawing.Size(217, 22);
            this.miExportSetting.Text = "設定をエクスポート";
            this.miExportSetting.Click += new System.EventHandler(this.miExportSetting_Click);
            // 
            // miStartup
            // 
            this.miStartup.CheckOnClick = true;
            this.miStartup.Name = "miStartup";
            this.miStartup.Size = new System.Drawing.Size(178, 22);
            this.miStartup.Text = "自動起動する";
            this.miStartup.CheckedChanged += new System.EventHandler(this.miStartup_CheckedChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(175, 6);
            // 
            // miVersion
            // 
            this.miVersion.Name = "miVersion";
            this.miVersion.Size = new System.Drawing.Size(178, 22);
            this.miVersion.Text = "バージョン";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(175, 6);
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(178, 22);
            this.miExit.Text = "アプリを終了する(&X)";
            this.miExit.Click += new System.EventHandler(this.cmExit_Click);
            // 
            // miHelp
            // 
            this.miHelp.Name = "miHelp";
            this.miHelp.Size = new System.Drawing.Size(178, 22);
            this.miHelp.Text = "ヘルプ(&H)";
            this.miHelp.Click += new System.EventHandler(this.miHelp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(167, 50);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Mye Fusen";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem miNewFusen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.ToolStripMenuItem miImport;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem miGatherFusen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miArrangeScreenRight;
        private System.Windows.Forms.ToolStripMenuItem miArrangeScreenLeft;
        private System.Windows.Forms.ToolStripMenuItem miChangeOrder;
        private System.Windows.Forms.ToolStripMenuItem miImportFusenData;
        private System.Windows.Forms.ToolStripMenuItem miImportSetting;
        private System.Windows.Forms.ToolStripMenuItem miExportAllFusenData;
        private System.Windows.Forms.ToolStripMenuItem miExportSetting;
        private System.Windows.Forms.ToolStripMenuItem miPutInsideScreen;
        private System.Windows.Forms.ToolStripMenuItem miVersion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miStartup;
        private System.Windows.Forms.ToolStripMenuItem miHelp;
    }
}

