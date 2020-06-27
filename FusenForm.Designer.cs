namespace MyeFusen
{
    partial class FusenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FusenTextBox = new System.Windows.Forms.TextBox();
            this.cmsText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmCut = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFusen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmNewFusen = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDeleteFusen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmScreenCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDeleteImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cmFontName = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFontSize = new System.Windows.Forms.ToolStripMenuItem();
            this.cmTextColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmUserColor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmWebColor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNewColor = new System.Windows.Forms.ToolStripMenuItem();
            this.cmOpacity = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.miArrangeScreenLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.miArrangeScreenRight = new System.Windows.Forms.ToolStripMenuItem();
            this.miArrangeHere = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.miNotArrange = new System.Windows.Forms.ToolStripMenuItem();
            this.miGather = new System.Windows.Forms.ToolStripMenuItem();
            this.miGatherScreenCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.miGatherHere = new System.Windows.Forms.ToolStripMenuItem();
            this.miChangeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.miImport = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportFusenData = new System.Windows.Forms.ToolStripMenuItem();
            this.miImportSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.miExport = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportThisFusenData = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportAllFusenData = new System.Windows.Forms.ToolStripMenuItem();
            this.miExportSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmExitApp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNewFusenFromCB = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFusenPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFusenCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsText.SuspendLayout();
            this.cmsFusen.SuspendLayout();
            this.SuspendLayout();
            // 
            // FusenTextBox
            // 
            this.FusenTextBox.AllowDrop = true;
            this.FusenTextBox.BackColor = System.Drawing.Color.White;
            this.FusenTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FusenTextBox.ContextMenuStrip = this.cmsText;
            this.FusenTextBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FusenTextBox.Location = new System.Drawing.Point(2, 2);
            this.FusenTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.FusenTextBox.Multiline = true;
            this.FusenTextBox.Name = "FusenTextBox";
            this.FusenTextBox.Size = new System.Drawing.Size(90, 30);
            this.FusenTextBox.TabIndex = 0;
            this.FusenTextBox.Visible = false;
            this.FusenTextBox.VisibleChanged += new System.EventHandler(this.FusenTextBox_VisibleChanged);
            this.FusenTextBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FusenText_MouseDoubleClick);
            // 
            // cmsText
            // 
            this.cmsText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmCut,
            this.cmCopy,
            this.cmPaste,
            this.cmDelete,
            this.cmSelectAll});
            this.cmsText.Name = "cmsText";
            this.cmsText.Size = new System.Drawing.Size(134, 114);
            this.cmsText.Opening += new System.ComponentModel.CancelEventHandler(this.cmsText_Opening);
            // 
            // cmCut
            // 
            this.cmCut.Name = "cmCut";
            this.cmCut.Size = new System.Drawing.Size(133, 22);
            this.cmCut.Text = "切り取り(&T)";
            this.cmCut.Click += new System.EventHandler(this.cmsCut_Click);
            // 
            // cmCopy
            // 
            this.cmCopy.Name = "cmCopy";
            this.cmCopy.Size = new System.Drawing.Size(133, 22);
            this.cmCopy.Text = "コピー(&C)";
            this.cmCopy.Click += new System.EventHandler(this.cmsCopy_Click);
            // 
            // cmPaste
            // 
            this.cmPaste.Name = "cmPaste";
            this.cmPaste.Size = new System.Drawing.Size(133, 22);
            this.cmPaste.Text = "貼り付け(&P)";
            this.cmPaste.Click += new System.EventHandler(this.cmsPaste_Click);
            // 
            // cmDelete
            // 
            this.cmDelete.Name = "cmDelete";
            this.cmDelete.Size = new System.Drawing.Size(133, 22);
            this.cmDelete.Text = "削除(&D)";
            this.cmDelete.Click += new System.EventHandler(this.cmDelete_Click);
            // 
            // cmSelectAll
            // 
            this.cmSelectAll.Name = "cmSelectAll";
            this.cmSelectAll.Size = new System.Drawing.Size(133, 22);
            this.cmSelectAll.Text = "全て選択(&L)";
            this.cmSelectAll.Click += new System.EventHandler(this.cmSelectAll_Click);
            // 
            // cmsFusen
            // 
            this.cmsFusen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmNewFusen,
            this.cmDeleteFusen,
            this.cmNewFusenFromCB,
            this.toolStripSeparator2,
            this.cmFusenCopy,
            this.cmFusenPaste,
            this.toolStripSeparator8,
            this.cmScreenCapture,
            this.cmDeleteImage,
            this.toolStripSeparator7,
            this.cmFontName,
            this.cmFontSize,
            this.cmTextColor,
            this.toolStripSeparator1,
            this.cmUserColor,
            this.cmWebColor,
            this.cmNewColor,
            this.cmOpacity,
            this.toolStripSeparator3,
            this.miArrange,
            this.miGather,
            this.miChangeOrder,
            this.toolStripSeparator5,
            this.miImport,
            this.miExport,
            this.toolStripSeparator4,
            this.cmExitApp});
            this.cmsFusen.Name = "contextMenuStrip1";
            this.cmsFusen.Size = new System.Drawing.Size(238, 508);
            this.cmsFusen.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFusen_Opening);
            // 
            // cmNewFusen
            // 
            this.cmNewFusen.Name = "cmNewFusen";
            this.cmNewFusen.Size = new System.Drawing.Size(237, 22);
            this.cmNewFusen.Text = "新しい付箋を作る(&N)";
            this.cmNewFusen.Click += new System.EventHandler(this.cmNewFusen_Click);
            // 
            // cmDeleteFusen
            // 
            this.cmDeleteFusen.Name = "cmDeleteFusen";
            this.cmDeleteFusen.Size = new System.Drawing.Size(237, 22);
            this.cmDeleteFusen.Text = "この付箋を削除(&D)";
            this.cmDeleteFusen.Click += new System.EventHandler(this.cmDeleteFusen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(234, 6);
            // 
            // cmScreenCapture
            // 
            this.cmScreenCapture.Name = "cmScreenCapture";
            this.cmScreenCapture.Size = new System.Drawing.Size(237, 22);
            this.cmScreenCapture.Text = "画面キャプチャ(&S)";
            this.cmScreenCapture.Click += new System.EventHandler(this.cmScreenCapture_Click);
            // 
            // cmDeleteImage
            // 
            this.cmDeleteImage.Name = "cmDeleteImage";
            this.cmDeleteImage.Size = new System.Drawing.Size(237, 22);
            this.cmDeleteImage.Text = "画像イメージを削除";
            this.cmDeleteImage.Click += new System.EventHandler(this.cmDeleteImage_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(234, 6);
            // 
            // cmFontName
            // 
            this.cmFontName.Name = "cmFontName";
            this.cmFontName.Size = new System.Drawing.Size(237, 22);
            this.cmFontName.Text = "フォント(&F)";
            this.cmFontName.Click += new System.EventHandler(this.cmFontName_Click);
            // 
            // cmFontSize
            // 
            this.cmFontSize.Name = "cmFontSize";
            this.cmFontSize.Size = new System.Drawing.Size(237, 22);
            this.cmFontSize.Text = "文字サイズ";
            // 
            // cmTextColor
            // 
            this.cmTextColor.Name = "cmTextColor";
            this.cmTextColor.Size = new System.Drawing.Size(237, 22);
            this.cmTextColor.Text = "文字色";
            this.cmTextColor.Click += new System.EventHandler(this.cmTextColor_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(234, 6);
            // 
            // cmUserColor
            // 
            this.cmUserColor.Name = "cmUserColor";
            this.cmUserColor.Size = new System.Drawing.Size(237, 22);
            this.cmUserColor.Text = "よく使う色から選択";
            // 
            // cmWebColor
            // 
            this.cmWebColor.Name = "cmWebColor";
            this.cmWebColor.Size = new System.Drawing.Size(237, 22);
            this.cmWebColor.Text = "Webカラーから選択";
            this.cmWebColor.Click += new System.EventHandler(this.cmWebColor_Click);
            // 
            // cmNewColor
            // 
            this.cmNewColor.Name = "cmNewColor";
            this.cmNewColor.Size = new System.Drawing.Size(237, 22);
            this.cmNewColor.Text = "新しい色を作る";
            this.cmNewColor.Click += new System.EventHandler(this.cmNewColor_Click);
            // 
            // cmOpacity
            // 
            this.cmOpacity.Name = "cmOpacity";
            this.cmOpacity.Size = new System.Drawing.Size(237, 22);
            this.cmOpacity.Text = "不透明度";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(234, 6);
            // 
            // miArrange
            // 
            this.miArrange.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miArrangeScreenLeft,
            this.miArrangeScreenRight,
            this.miArrangeHere,
            this.toolStripSeparator6,
            this.miNotArrange});
            this.miArrange.Name = "miArrange";
            this.miArrange.Size = new System.Drawing.Size(237, 22);
            this.miArrange.Text = "整列(&A)";
            // 
            // miArrangeScreenLeft
            // 
            this.miArrangeScreenLeft.Name = "miArrangeScreenLeft";
            this.miArrangeScreenLeft.Size = new System.Drawing.Size(196, 22);
            this.miArrangeScreenLeft.Text = "左端に整列";
            this.miArrangeScreenLeft.Click += new System.EventHandler(this.miArrangeScreenLeft_Click);
            // 
            // miArrangeScreenRight
            // 
            this.miArrangeScreenRight.Name = "miArrangeScreenRight";
            this.miArrangeScreenRight.Size = new System.Drawing.Size(196, 22);
            this.miArrangeScreenRight.Text = "右端に整列";
            this.miArrangeScreenRight.Click += new System.EventHandler(this.miArrangeScreenRight_Click);
            // 
            // miArrangeHere
            // 
            this.miArrangeHere.Name = "miArrangeHere";
            this.miArrangeHere.Size = new System.Drawing.Size(196, 22);
            this.miArrangeHere.Text = "ここに整列";
            this.miArrangeHere.Click += new System.EventHandler(this.miArrangeHere_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(193, 6);
            // 
            // miNotArrange
            // 
            this.miNotArrange.CheckOnClick = true;
            this.miNotArrange.Name = "miNotArrange";
            this.miNotArrange.Size = new System.Drawing.Size(196, 22);
            this.miNotArrange.Text = "この付箋は整列の対象外";
            this.miNotArrange.CheckedChanged += new System.EventHandler(this.miNotArrange_CheckedChanged);
            // 
            // miGather
            // 
            this.miGather.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGatherScreenCenter,
            this.miGatherHere});
            this.miGather.Name = "miGather";
            this.miGather.Size = new System.Drawing.Size(237, 22);
            this.miGather.Text = "集合(&G)";
            // 
            // miGatherScreenCenter
            // 
            this.miGatherScreenCenter.Name = "miGatherScreenCenter";
            this.miGatherScreenCenter.Size = new System.Drawing.Size(131, 22);
            this.miGatherScreenCenter.Text = "中央に集合";
            this.miGatherScreenCenter.Click += new System.EventHandler(this.miGatherScreenCenter_Click);
            // 
            // miGatherHere
            // 
            this.miGatherHere.Name = "miGatherHere";
            this.miGatherHere.Size = new System.Drawing.Size(131, 22);
            this.miGatherHere.Text = "ここに集合";
            this.miGatherHere.Click += new System.EventHandler(this.miGatherHere_Click);
            // 
            // miChangeOrder
            // 
            this.miChangeOrder.Name = "miChangeOrder";
            this.miChangeOrder.Size = new System.Drawing.Size(237, 22);
            this.miChangeOrder.Text = "並び順変更(&O)";
            this.miChangeOrder.Click += new System.EventHandler(this.miChangeOrder_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(234, 6);
            // 
            // miImport
            // 
            this.miImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImportFusenData,
            this.miImportSetting});
            this.miImport.Name = "miImport";
            this.miImport.Size = new System.Drawing.Size(237, 22);
            this.miImport.Text = "インポート";
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
            this.miExportThisFusenData,
            this.miExportAllFusenData,
            this.miExportSetting});
            this.miExport.Name = "miExport";
            this.miExport.Size = new System.Drawing.Size(237, 22);
            this.miExport.Text = "エクスポート";
            // 
            // miExportThisFusenData
            // 
            this.miExportThisFusenData.Name = "miExportThisFusenData";
            this.miExportThisFusenData.Size = new System.Drawing.Size(217, 22);
            this.miExportThisFusenData.Text = "この付箋データをエクスポート";
            this.miExportThisFusenData.Click += new System.EventHandler(this.miExportThisFusenData_Click);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(234, 6);
            // 
            // cmExitApp
            // 
            this.cmExitApp.Name = "cmExitApp";
            this.cmExitApp.Size = new System.Drawing.Size(237, 22);
            this.cmExitApp.Text = "アプリを終了する(&X)";
            this.cmExitApp.Click += new System.EventHandler(this.cmExitApp_Click);
            // 
            // cmNewFusenFromCB
            // 
            this.cmNewFusenFromCB.Name = "cmNewFusenFromCB";
            this.cmNewFusenFromCB.Size = new System.Drawing.Size(237, 22);
            this.cmNewFusenFromCB.Text = "クリップボードから新しい付箋を作る";
            this.cmNewFusenFromCB.Click += new System.EventHandler(this.cmNewFusenFromCB_Click);
            // 
            // cmFusenPaste
            // 
            this.cmFusenPaste.Name = "cmFusenPaste";
            this.cmFusenPaste.Size = new System.Drawing.Size(237, 22);
            this.cmFusenPaste.Text = "ペースト(&V)";
            this.cmFusenPaste.Click += new System.EventHandler(this.cmFusenPaste_Click);
            // 
            // cmFusenCopy
            // 
            this.cmFusenCopy.Name = "cmFusenCopy";
            this.cmFusenCopy.Size = new System.Drawing.Size(237, 22);
            this.cmFusenCopy.Text = "コピー(&C)";
            this.cmFusenCopy.Click += new System.EventHandler(this.cmFusenCopy_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(234, 6);
            // 
            // FusenForm
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Gold;
            this.ClientSize = new System.Drawing.Size(180, 60);
            this.ContextMenuStrip = this.cmsFusen;
            this.Controls.Add(this.FusenTextBox);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FusenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Deactivate += new System.EventHandler(this.FusenForm_Deactivate);
            this.Load += new System.EventHandler(this.FusenForm_Load);
            this.ResizeEnd += new System.EventHandler(this.FusenForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.FusenForm_SizeChanged);
            this.Click += new System.EventHandler(this.FusenForm_Click);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FusenForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FusenForm_DragEnter);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FusenForm_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FusenForm_KeyPress);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FusenForm_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FusenForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FusenForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FusenForm_MouseUp);
            this.cmsText.ResumeLayout(false);
            this.cmsFusen.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FusenTextBox;
        private System.Windows.Forms.ContextMenuStrip cmsFusen;
        private System.Windows.Forms.ToolStripMenuItem cmNewFusen;
        private System.Windows.Forms.ToolStripMenuItem cmDeleteFusen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmUserColor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmExitApp;
        private System.Windows.Forms.ContextMenuStrip cmsText;
        private System.Windows.Forms.ToolStripMenuItem cmCut;
        private System.Windows.Forms.ToolStripMenuItem cmCopy;
        private System.Windows.Forms.ToolStripMenuItem cmPaste;
        private System.Windows.Forms.ToolStripMenuItem cmDelete;
        private System.Windows.Forms.ToolStripMenuItem cmSelectAll;
        private System.Windows.Forms.ToolStripMenuItem cmFontName;
        private System.Windows.Forms.ToolStripMenuItem cmFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmOpacity;
        private System.Windows.Forms.ToolStripMenuItem cmWebColor;
        private System.Windows.Forms.ToolStripMenuItem cmNewColor;
        private System.Windows.Forms.ToolStripMenuItem cmTextColor;
        private System.Windows.Forms.ToolStripMenuItem miGather;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miArrange;
        private System.Windows.Forms.ToolStripMenuItem miArrangeScreenLeft;
        private System.Windows.Forms.ToolStripMenuItem miArrangeScreenRight;
        private System.Windows.Forms.ToolStripMenuItem miArrangeHere;
        private System.Windows.Forms.ToolStripMenuItem miGatherScreenCenter;
        private System.Windows.Forms.ToolStripMenuItem miGatherHere;
        private System.Windows.Forms.ToolStripMenuItem miChangeOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem miImport;
        private System.Windows.Forms.ToolStripMenuItem miExport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem miNotArrange;
        private System.Windows.Forms.ToolStripMenuItem miImportFusenData;
        private System.Windows.Forms.ToolStripMenuItem miImportSetting;
        private System.Windows.Forms.ToolStripMenuItem miExportThisFusenData;
        private System.Windows.Forms.ToolStripMenuItem miExportAllFusenData;
        private System.Windows.Forms.ToolStripMenuItem miExportSetting;
        private System.Windows.Forms.ToolStripMenuItem cmScreenCapture;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cmDeleteImage;
        private System.Windows.Forms.ToolStripMenuItem cmNewFusenFromCB;
        private System.Windows.Forms.ToolStripMenuItem cmFusenCopy;
        private System.Windows.Forms.ToolStripMenuItem cmFusenPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
    }
}