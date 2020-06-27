using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using System.IO;

//using System.Windows.Forms.ColorPicker;

namespace MyeFusen
{
    public partial class FusenForm : Form
    {
        [DllImport("user32.dll")]
        private static extern int HideCaret(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern int ShowCaret(IntPtr hWnd);

        // HitTest系WindowsAPI
        private const uint WM_NCHITTEST = 0x84;
        private enum HT { HTNONE = 0, HTLEFT = 10, HTRIGHT = 11, HTTOP = 12, HTTOPLEFT = 13, HTTOPRIGHT = 14, HTBOTTOM = 15, HTBOTTOMLEFT = 16, HTBOTTOMRIGHT = 17, HTBORDER = 18 };

        // 定数
        private int frmMgn = 3;

        // 内部変数
        private Point mousePoint = new Point(-1, -1);
        private FontForm fontForm = null;
        private WebColorForm webColorForm = null;
        private FusenImage fusenImage = new FusenImage();

        // メソッド
        public void DeleteImage() { fusenImage.DeleteImage(); }
        public void CopyText() { Clipboard.SetText(Text); }
        public void PasteText() { Text = Clipboard.GetText(); }

        // プロパティ
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public double FusenOpacity { get; set; } // 透明度
        public string FontName
        {
            get {return this.Font.Name ;} 
            set {this.Font = new Font(value, this.Font.Size);}
        }
        public float FontSize
        {
            get => Font.Size; set => Font = new Font(Font.Name, value);
        }
        public string ImageFilePath {
            get { return fusenImage.ImageFilePath; }
            set { fusenImage.LoadImageFromFile(value); }
        }
        public bool ArrangeMember { get; set; } // 整列の対象か

        public string FusenText { get => FusenTextBox.Text; set => FusenTextBox.Text = value; }

        public Color FusenTextColor { get => FusenTextBox.ForeColor; set => FusenTextBox.ForeColor = value; }
        public Color FusenBackColor { get => BackColor; set => BackColor = value; }

        public FusenForm()
        {
            InitializeComponent();

            frmMgn = MainForm.frameMargin; // フレームマージン
            ArrangeMember = true; // 整列対象

            // 不透明度の初期設定
            FusenOpacity = 0.8;
            Opacity = FusenOpacity;

            // 不透明度のメニュー
            for (int i = 10; i > 0; i--)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = string.Format("{0}%", i * 10);
                mi.Click += new EventHandler(
                    (sender, e) => {
                        FusenOpacity = (double)(int.Parse(sender.ToString().Replace("%", ""))) / 100.0;
                        this.Opacity = FusenOpacity;
                    });

                cmOpacity.DropDownItems.Add(mi);
            }

            // フォントサイズメニュー
            foreach (int fs in MainForm.fontSizes)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = string.Format("{0}", fs);
                mi.Click += new EventHandler((sender, e) => { FontSize = float.Parse(sender.ToString()); });

                cmFontSize.DropDownItems.Add(mi);
            }

            // テキストカラーメニュー
            CreateTextColorMenu();

            // Webカラー選択パネル
            if (webColorForm == null)
            {
                webColorForm = new WebColorForm();
                webColorForm.ColorSelected += new ColorSelectedEventHandler((sender, e) => { BackColor = e.WebColor; });
                webColorForm.ColorChanged += new ColorChangedEventHandler((sender, e) => {MainForm.userColors.AddUniqe(BackColor);});
            }

            //フォント選択BOX
            if (fontForm == null)
            {
                fontForm = new FontForm(this.Font.GdiCharSet);
                fontForm.FontSelected += new FontSelectedEventHandler((sender, e) => { FontName = e.FontName; });
            }
            fusenImage.LoadImageFromFile(ImageFilePath);

            FusenTextBox.Hide();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST)
            {
                //Point pt = PointToClient(new Point(m.LParam.ToInt32() % 0x10000, m.LParam.ToInt32() / 0x10000));
                Point pt = new Point(m.LParam.ToInt32() % 0x10000, m.LParam.ToInt32() / 0x10000);

                Rectangle rc = new Rectangle(Location, Size);
                Rectangle rc1 = rc;
                rc1.Inflate(-10, -10);

                if (pt.X >= Left && pt.X <= rc1.Left)
                {
                    if (pt.Y >= Top && pt.Y < rc1.Top)
                    {
                        m.Result = (IntPtr)HT.HTTOPLEFT;
                        return;
                    }
                    if (pt.Y >= rc1.Top && pt.Y <= rc1.Bottom)
                    {
                        m.Result = (IntPtr)HT.HTLEFT;
                        return;
                    }
                    if (pt.Y > rc1.Bottom && pt.Y <= Bottom)
                    {
                        m.Result = (IntPtr)HT.HTBOTTOMLEFT;
                        return;
                    }
                }
                if (pt.X >= rc1.Right && pt.X <= Right)
                {
                    if (pt.Y >= Top && pt.Y < rc1.Top)
                    {
                        m.Result = (IntPtr)HT.HTTOPRIGHT;
                        return;
                    }
                    if (pt.Y >= rc1.Top && pt.Y <= rc1.Bottom)
                    {
                        m.Result = (IntPtr)HT.HTRIGHT;
                        return;
                    }
                    if (pt.Y > rc1.Bottom && pt.Y <= Bottom)
                    {
                        m.Result = (IntPtr)HT.HTBOTTOMRIGHT;
                        return;
                    }
                }
                if (pt.Y >= Top && pt.Y <= rc1.Top && pt.X >= rc1.Left && pt.X <= rc1.Right)
                {
                    m.Result = (IntPtr)HT.HTTOP;
                    return;
                }
                if (pt.Y >= rc1.Bottom && pt.Y <= Bottom && pt.X >= rc1.Left && pt.X <= rc1.Right)
                {
                    m.Result = (IntPtr)HT.HTBOTTOM;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void UpdateUserColorMenu()
        {
            // 一旦ユーザーカラーメニューを削除
            cmUserColor.DropDownItems.Clear();

            //ユーザーカラーメニューを構築
            foreach (Color cl in MainForm.userColors)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = ColorTranslator.ToHtml(cl);
                tsmi.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                //tsmi.Image = new Bitmap(

                Rectangle rc = new Rectangle(0, 0, tsmi.Height, tsmi.Height);
                Bitmap bmp = new Bitmap(rc.Width, rc.Height);
                
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    rc.Inflate(-2, -2);
                    g.FillRectangle(new SolidBrush(cl), rc);
                    g.DrawRectangle(SystemPens.ControlDarkDark, rc);
                }
                tsmi.Image = bmp;

                tsmi.Click += new EventHandler(
                    (sender, e) => {
                        BackColor = ColorTranslator.FromHtml(sender.ToString().Replace("#","0x"));
                        });
                cmUserColor.DropDownItems.Insert(0, tsmi);
            }
        }

        private void CreateTextColorMenu()
        {
            // 一旦テキストカラーメニューを削除
            cmTextColor.DropDownItems.Clear();

            //テキストカラーメニューを構築
            foreach (Color cl in MainForm.textColors)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem();
                tsmi.Text = ColorTranslator.ToHtml(cl);
                tsmi.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

                Rectangle rc = new Rectangle(0, 0, tsmi.Height, tsmi.Height);
                Bitmap bmp = new Bitmap(rc.Width, rc.Height);

                using (Graphics g = Graphics.FromImage(bmp))
                {
                    rc.Inflate(-2, -2);
                    g.FillRectangle(new SolidBrush(cl), rc);
                    g.DrawRectangle(SystemPens.ControlDarkDark, rc);
                }
                tsmi.Image = bmp;

                tsmi.Click += new EventHandler(
                    (sender, e) =>
                    {
                        ForeColor = ColorTranslator.FromHtml(sender.ToString().Replace("#", "0x"));
                    });
                cmTextColor.DropDownItems.Add(tsmi);
            }
        }

        private void FusenForm_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true); // リサイズ時に再描画させる
            this.SetStyle(ControlStyles.Opaque, true);  // 背景の消去をしない

            // ダブルバッファリングで描画する
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void FusenForm_SizeChanged(object sender, EventArgs e)
        {
            FusenTextBox.Height = Height - frmMgn * 2;
            FusenTextBox.Width = Width - frmMgn * 2;
            FusenTextBox.Top = frmMgn;
            FusenTextBox.Left = frmMgn;
        }

        private void FusenForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //移動開始
                mousePoint.X = e.X;
                mousePoint.Y = e.Y;
            }
        }

        private void FusenForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FusenTextBox.Font = this.Font;
            FusenTextBox.Show();
        }

        private void FusenForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePoint.X >= 0)
            {
                //移動中
                SetDesktopLocation(Left + e.X - mousePoint.X, Top + e.Y - mousePoint.Y);
            }
        }

        private void FusenForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // 移動終了
                mousePoint = new Point(-1, -1);

                MainForm.AdsorbNearFusen(this); //近くの付箋に吸着
                MainForm.AdsorbScreenEdge(this); //画面端に吸着

                MainForm.SaveFusenDataAsync();//位置保存
            }
        }

        private void FusenForm_Deactivate(object sender, EventArgs e)
        {
            FusenTextBox.Hide();
        }

        private void FusenText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FusenTextBox.Hide();
        }

        private void cmNewFusen_Click(object sender, EventArgs e)
        {
            Point pt = this.Location;
            pt.Offset(30, 30);
            MainForm.AddNewFusen(pt);
        }
        private void cmNewFusenFromCB_Click(object sender, EventArgs e)
        {
            Point pt = this.Location;
            pt.Offset(30, 30);

            FusenForm fusen = MainForm.AddNewFusen(pt);
            fusen.PasteText();
        }

        private void cmDeleteFusen_Click(object sender, EventArgs e)
        {
            MainForm.DeleteFusen(this);
        }

        private void cmExitApp_Click(object sender, EventArgs e)
        {
            MainForm.ExitApp();
        }

        private void cmsCut_Click(object sender, EventArgs e)
        {
            FusenTextBox.Cut();
        }

        private void cmsCopy_Click(object sender, EventArgs e)
        {
            FusenTextBox.Copy();
        }

        private void cmsPaste_Click(object sender, EventArgs e)
        {
            FusenTextBox.Paste();
        }

        private void cmsText_Opening(object sender, CancelEventArgs e)
        {
            cmCut.Enabled = (FusenTextBox.SelectionLength > 0);
            cmCopy.Enabled = (FusenTextBox.SelectionLength > 0);
            cmPaste.Enabled = Clipboard.ContainsText();
            cmDelete.Enabled = (FusenTextBox.SelectionLength > 0);
            cmSelectAll.Enabled = (FusenTextBox.TextLength > 0);
        }

        private void cmSelectAll_Click(object sender, EventArgs e)
        {
            FusenTextBox.SelectAll();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            FusenTextBox.Clear(); // Clipboardには影響を与えない。
        }

        private void cmNewColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();

            cd.Color = BackColor;
            cd.AnyColor = false;
            cd.FullOpen = true;
            cd.CustomColors = MainForm.userColors.ToIntArray();

            if (cd.ShowDialog() == DialogResult.OK)
            {
                BackColor = cd.Color;
                MainForm.userColors.FromIntArray(cd.CustomColors);
            }
            FusenTextBox.Hide();
        }

        private void cmsFusen_Opening(object sender, CancelEventArgs e)
        {
            UpdateUserColorMenu();　//ユーザーカラーメニュー構築

            // 不透明度メニューのチェック
            ((ToolStripMenuItem)(cmOpacity.DropDownItems[10 - ((int)(Opacity * 10))])).Checked = true;
            for (int i = 1; i <= 10; i++ )
            {
                ((ToolStripMenuItem)(cmOpacity.DropDownItems[i - 1])).Checked = (Opacity * 10 == 10 - i + 1);
            }

            // フォントサイズメニューのチェック
            foreach (var tsmi in cmFontSize.DropDownItems)
            {
                ((ToolStripMenuItem)tsmi).Checked = (FontSize==float.Parse(((ToolStripMenuItem)tsmi).Text));
            }

            miNotArrange.Checked = !ArrangeMember; // 整列対象外
        }

        private void FusenForm_Paint(object sender, PaintEventArgs e)
        {
            // ダブルバッファリングでの描画
            Rectangle rc = new Rectangle(new Point(0, 0), new Size(Width, Height));
            e.Graphics.FillRectangle(new SolidBrush(BackColor), rc);
            rc.Inflate(-frmMgn, -frmMgn);

            if(fusenImage.ImageObj != null)
            {   // イメージ付箋の描画
                e.Graphics.DrawImage(fusenImage.ImageObj, rc);
            }
            else
            {   // テキスト付箋の描画
                e.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), rc);
            }

            //順番指定モード
            if (MainForm.ChangeOrderNum > 0)
            {
                int num = MainForm.fusenList.IndexOf(this) + 1;
                
                Rectangle rcNum = rc;
                Font fnt = new Font("Arial", 20);                
                SizeF sz = e.Graphics.MeasureString(num.ToString(), fnt);
                
                rcNum.Width = (int)sz.Width;
                rcNum.Height = (int)sz.Height;

                e.Graphics.FillRectangle(new SolidBrush(Color.Black), rcNum);
                e.Graphics.DrawString(num.ToString(), fnt, new SolidBrush(Color.White), rcNum);
            }
        }

        private void FusenTextBox_VisibleChanged(object sender, EventArgs e)
        {
            if (FusenTextBox.Visible)
            {
                FusenTextBox.Text = Text;
                FusenTextBox.Select(FusenTextBox.TextLength, 0);
                Opacity = 1; // 
            }
            else
            {
                if (Text != FusenTextBox.Text)
                {
                    Text = FusenTextBox.Text;
                    UpdateDateTime = DateTime.Now; // 更新日時
                }
                if (FusenOpacity > 0)
                {
                    Opacity = FusenOpacity;
                }
                MainForm.SaveFusenDataAsync();
            }
        }

        private void cmFontName_Click(object sender, EventArgs e)
        {
            fontForm.Location = new Point(cmsFusen.Bounds.Left, cmsFusen.Bounds.Top);
            fontForm.CurrentFontName = FontName;
            fontForm.Show();
        }

        private void cmWebColor_Click(object sender, EventArgs e)
        {
            webColorForm.Location = new Point(cmsFusen.Bounds.Left, cmsFusen.Bounds.Top);
            webColorForm.Show();
        }

        private void cmOpacityItem_Click(object sender, EventArgs e)
        {

        }

        private void cmTextColor_Click(object sender, EventArgs e)
        {

        }
        private void FusenForm_Click(object sender, EventArgs e)
        {
            MainForm.ChangeOrder(this);
        }

        private void miArrangeHere_Click(object sender, EventArgs e)
        {
            MainForm.ArrangeFusen(MainForm.ArrangeType.Fusen, this);
        }

        private void miArrangeScreenRight_Click(object sender, EventArgs e)
        {
            MainForm.ArrangeFusen(MainForm.ArrangeType.ScreenRight, this);
        }

        private void miArrangeScreenLeft_Click(object sender, EventArgs e)
        {
            MainForm.ArrangeFusen(MainForm.ArrangeType.ScreenLeft, this);
        }

        private void miGatherScreenCenter_Click(object sender, EventArgs e)
        {
            MainForm.GatherFusen();
        }

        private void miGatherHere_Click(object sender, EventArgs e)
        {
            MainForm.GatherFusen(this);
        }

        private void miChangeOrder_Click(object sender, EventArgs e)
        {
            MainForm.StartChangeOrder(true);
        }

        private void FusenForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            MainForm.StartChangeOrder(false);
        }

        private void miNotArrange_CheckedChanged(object sender, EventArgs e)
        {
            ArrangeMember = !miNotArrange.Checked;
        }

        private void miImportFusenData_Click(object sender, EventArgs e)
        {
            MainForm.ImportFusenData();
        }

        private void miImportSetting_Click(object sender, EventArgs e)
        {
            MainForm.ImportSetting();
        }

        private void miExportThisFusenData_Click(object sender, EventArgs e)
        {
            MainForm.ExportFusenData(this);
        }

        private void miExportAllFusenData_Click(object sender, EventArgs e)
        {
            MainForm.ExportFusenData();
        }

        private void miExportSetting_Click(object sender, EventArgs e)
        {
            MainForm.ExportSetting();
        }

        private void FusenForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] drags = (string[])e.Data.GetData(DataFormats.FileDrop);

                string filePath = drags[0];
                if(File.Exists(filePath))
                {
                    // サポートしているイメージファイルかチェック
                    if(FusenImage.IsSupportedImageFile(filePath))
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                }
            }
        }

        private void FusenForm_DragDrop(object sender, DragEventArgs e)
        {
            // ドラッグ＆ドロップされたファイル
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            fusenImage.CopyAndLoadImageFromFile(files[0]);

            Refresh();//直ちに再描画

            MainForm.SaveFusenDataAsync();
        }

        private void FusenForm_ResizeEnd(object sender, EventArgs e)
        {
            // サイズ変更終了時に保存
            MainForm.SaveFusenDataAsync();
        }

        private void cmScreenCapture_Click(object sender, EventArgs e)
        {
            Hide();

            System.Threading.Thread.Sleep(300); // IE11でPageによってはおかしくなる問題の対策

            // 内側のサイズ
            Rectangle rc = new Rectangle(new Point(Left, Top), new Size(Width, Height));
            rc.Inflate(-frmMgn, -frmMgn);

            Bitmap bmp = ScreenCapture.CaptureRect(rc);
            fusenImage.LoadImageFromBitmap(bmp);
            bmp.Dispose();

            Show();
            Refresh();

            MainForm.SaveFusenDataAsync();
        }

        private void cmDeleteImage_Click(object sender, EventArgs e)
        {
            fusenImage.DeleteImage();

            Refresh();//再描画

            MainForm.SaveFusenDataAsync();
        }

        private void cmFusenCopy_Click(object sender, EventArgs e)
        {
            this.CopyText();
        }

        private void cmFusenPaste_Click(object sender, EventArgs e)
        {
            this.PasteText();
            Refresh();
        }
    }
}
