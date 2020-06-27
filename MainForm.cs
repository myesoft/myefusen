using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

//using Codeplex.Data;
using Microsoft.CSharp;
using Utf8Json;

using MyeSoft.ClipboardViewer;
using System.Drawing.Imaging;

namespace MyeFusen
{
    public partial class MainForm : Form
    {
        public enum ArrangeType { Fusen, ScreenLeft, ScreenRight };
        public static UserColorList userColors = new UserColorList();
        public static ColorList textColors = new ColorList {Color.Black, Color.White, Color.Red, Color.Blue, Color.Yellow, Color.Green};
        public static int[] fontSizes = new int[] {6,8,9,10,11,12,14,16,18,20,22,24,26,28,36,48,72};
        public static int frameMargin = 3;
        public static int adsorbMargin = 30;
        public static int ChangeOrderNum = 0;

        //public static string SupportImageFileExtentions;
        public static bool IsRegistedStartup => File.Exists(shortcutFilePath);
        public static string DataFilePath => dataFilePath;

        public static FusenList fusenList = new FusenList();

        private static string settingFilePath = Application.UserAppDataPath + "\\" + Application.ProductName + "-setting.json";
        private static string dataFilePath = Application.UserAppDataPath + "\\" + Application.ProductName + "-data.json";
        private static string importSettingFilePath = "";
        private static string exportSettingFilePath = "";
        private static string importDataFilePath = "";
        private static string exportDataFilePath = "";

        //private static string shortcutFileName = Application.ProductName + ".lnk";
        private static string shortcutFileName = "MYE付箋.lnk";
        private static string shortcutFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), shortcutFileName);

        // コンストラクタ
        public MainForm()
        {
            //cbViewer = new MyClipboardViewer(this);
            //cbViewer.ClipboardHandler += this.OnClipBoardChanged;

            InitializeComponent();

            //FileVersionInfo ver = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            miVersion.Text = string.Format("{0} Ver{1}", Application.ProductName, Application.ProductVersion);

            // 起動時のスタートアップへの登録確認
            if (!IsRegistedStartup)
            {
                DialogResult dr = MessageBox.Show(
                    "スタートアップに登録してWindows起動時にMYE付箋を自動起動するようにしますか？（おすすめ）",
                    "MYE付箋", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    CreateStartupShortcut();
                }
            }
            miStartup.Checked = IsRegistedStartup;
        }

        // クリップボードにテキストがコピーされると呼び出される
        private void OnClipBoardChanged(object sender, ClipboardEventArgs args)
        {
        }
        
        // スタートアップにショートカット作成
        private void CreateStartupShortcut()
        {
            if (IsRegistedStartup)
                return; // すでにショートカットがあれば何もしない

            string targetPath = Application.ExecutablePath; //ショートカットのリンク先

            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            //ショートカットのパスを指定して、WshShortcutを作成
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutFilePath);
            try
            {
                shortcut.TargetPath = targetPath;
                shortcut.IconLocation = Application.ExecutablePath + ",0";
                shortcut.Save();
            }
            finally
            {   //後始末
                Marshal.ReleaseComObject(shortcut);
            }
        }
        private void RemoveStartupShortcut()
        {
            File.Delete(shortcutFilePath);
        }

        // 終了
        public static void ExitApp()
        {
            // 設定保存
            SaveSetting();

            // 付箋データ保存
            SaveFusenData();

            // 付箋削除
            fusenList.DeleteAll();
            Application.Exit();
        }

        // 新規付箋追加
        public static FusenForm AddNewFusen()
        {
            return AddNewFusen(new Point(-1, -1));
        }
        public static FusenForm AddNewFusen(Point pt)
        {
            FusenForm fusen = new FusenForm();

            if (pt.X < 0)
            {
                fusen.StartPosition = FormStartPosition.WindowsDefaultLocation;
            }
            else
            {
                fusen.StartPosition = FormStartPosition.Manual;
                fusen.SetDesktopLocation(pt.X, pt.Y);
            }
            // 作成日時
            fusen.CreateDateTime = DateTime.Now;
            fusen.UpdateDateTime = fusen.CreateDateTime;

            fusenList.Add(fusen);
            fusen.Show();

            // 非同期処理でデータ保存
            SaveFusenDataAsync();

            return fusen;
        }

        //付箋削除
        public static void DeleteFusen(FusenForm fusen)
        {
            fusenList.Remove(fusen);
            fusen.DeleteImage();
            fusen.Close();

            SaveFusenDataAsync(); // 削除をJSONに反映する
        }

        // 近くの付箋に吸着する
        public static void AdsorbNearFusen(FusenForm fusen)
        {
            foreach (FusenForm ff in fusenList)
            {
                if (ff == fusen)
                    continue;

                if (Math.Abs(ff.Bottom - fusen.Top) <= adsorbMargin && Math.Abs(ff.Left - fusen.Left) <= adsorbMargin)
                {
                    // 上にくっつける
                    if (fusen.Left != ff.Left || fusen.Top != ff.Bottom)
                    {
                        fusen.Left = ff.Left;
                        fusen.Top = ff.Bottom;
                    }
                }
                if (Math.Abs(ff.Right - fusen.Left) <= adsorbMargin && Math.Abs(ff.Top - fusen.Top) <= adsorbMargin)
                {
                    // 左にくっつける
                    if (fusen.Top != ff.Top || fusen.Left != ff.Right)
                    {
                        fusen.Left = ff.Right;
                        fusen.Top = ff.Top;
                    }
                }
            }
        }

        // 画面端に吸着する
        public static void AdsorbScreenEdge(FusenForm fusen)
        {
            Point pt = new Point(fusen.Left, fusen.Top);
            Rectangle sc = Screen.GetBounds(fusen);

            if (Math.Abs(sc.Left - fusen.Left) <= adsorbMargin)
            {
                fusen.Left = sc.Left;
            }
            if (Math.Abs(sc.Top - fusen.Top) <= adsorbMargin)
            {
                fusen.Top = sc.Top;
            }
            if (Math.Abs(sc.Right - fusen.Right) <= adsorbMargin)
            {
                fusen.Left = sc.Right - fusen.Width;
            }
            if (Math.Abs(sc.Bottom - fusen.Bottom) <= adsorbMargin)
            {
                fusen.Top = sc.Bottom - fusen.Height;
            }
        }

        // 付箋を集合させる
        public static void GatherFusen()
        {
            GatherFusen(null);
        }
        public static void GatherFusen(FusenForm fusen)
        {
            Rectangle rc = Screen.PrimaryScreen.Bounds;
            Point pt = new Point(rc.Left + rc.Width / 2, rc.Top + rc.Height / 2);

            if (fusen != null)
            {
                pt = new Point(fusen.Left, fusen.Top);
                pt.Offset(20, 20);
            }

            foreach (FusenForm ff in fusenList)
            {
                if (fusen == ff)
                    continue;

                ff.Left = pt.X;
                ff.Top = pt.Y;
                pt.Offset(20, 20);
                ff.Activate(); // 順番に重ねるためにActivateする
            }
        }

        // 付箋を整列させる
        public static void ArrangeFusen(ArrangeType arrangeType, FusenForm fusen)
        {
            Rectangle rc = Screen.GetBounds(fusen);
            Point pt = new Point(rc.Left, rc.Top);

            if (arrangeType == ArrangeType.ScreenRight)
            {
                // 右端に整列（整列対象メンバーのみ）の準備
                int maxWidth = fusenList.Max((a) => { return a.ArrangeMember ? a.Width : 0; });
                pt.X = rc.Right - maxWidth;
            }
            else if (arrangeType == ArrangeType.Fusen && fusen != null)
            {
                pt.X = fusen.Left;
                pt.Y = fusen.Bottom;
            }

            foreach (FusenForm ff in fusenList)
            {
                if (arrangeType == ArrangeType.Fusen && fusen == ff)
                    continue;

                if (!ff.ArrangeMember)
                    continue;

                ff.Left = pt.X;
                ff.Top = pt.Y;
                pt.Y = ff.Bottom;

                if (pt.Y >= rc.Bottom)
                    break; // 画面下にはみ出たら終わり
            }
        }

        // データファイルの場所指定
        public static void SetDataFilePath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = Path.GetFileName(dataFilePath);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                dataFilePath = ofd.FileName;
            }
        }

        public static void ImportSetting()
        {
            if (importSettingFilePath.Length <= 0)
            {
                importSettingFilePath = settingFilePath;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(importSettingFilePath);
            ofd.FileName = Path.GetFileName(importSettingFilePath);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadSetting(ofd.FileName);

                if (importSettingFilePath != ofd.FileName)
                {
                    importSettingFilePath = ofd.FileName;
                    SaveSettingAsync(); // Pathが変わったので設定保存
                }
                // 画面に収める
                //fusenList.PutInsideRect(Screen.PrimaryScreen.Bounds);
            }
        }

        public static void ImportFusenData()
        {
            if (importDataFilePath.Length <= 0)
            {
                importDataFilePath = dataFilePath;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Path.GetDirectoryName(importDataFilePath);
            ofd.FileName = Path.GetFileName(importDataFilePath);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                LoadFusenData(ofd.FileName);

                if (importDataFilePath != ofd.FileName)
                {
                    importDataFilePath = ofd.FileName;
                    SaveSettingAsync(); // Pathが変わったので設定保存
                }
                // 画面に収める
                //fusenList.PutInsideRect(Screen.PrimaryScreen.Bounds);
            }
        }

        public static void ExportSetting()
        {
            if (exportSettingFilePath.Length <= 0)
            {
                exportSettingFilePath = settingFilePath;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.GetDirectoryName(exportSettingFilePath);
            sfd.FileName = Path.GetFileName(exportSettingFilePath);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveSetting(sfd.FileName);

                if (exportSettingFilePath != sfd.FileName)
                {
                    exportSettingFilePath = sfd.FileName;
                    SaveSettingAsync(); // Pathが変わったので設定保存
                }
            }
        }
        public static void ExportFusenData()
        {
            ExportFusenData(null);
        }
        public static void ExportFusenData(FusenForm fusen)
        {
            if (exportDataFilePath.Length <= 0)
            {
                exportDataFilePath = dataFilePath;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Path.GetDirectoryName(exportDataFilePath);
            sfd.FileName = Path.GetFileName(exportDataFilePath);

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SaveFusenData(fusen, sfd.FileName);

                if (exportDataFilePath != sfd.FileName)
                {
                    exportDataFilePath = sfd.FileName;
                    SaveSettingAsync(); // Pathが変わったので設定保存
                }
            }
        }

        public static void StartChangeOrder(bool bStart)
        {
            ChangeOrderNum = bStart ? 1 : 0; // 0の時は並べ替えしない
            fusenList.InvalidatedAll();
        }

        public static void ChangeOrder(FusenForm fusen)
        {
            if (ChangeOrderNum > 0)
            {
                FusenForm ff = fusenList[ChangeOrderNum - 1];
                int idx = fusenList.IndexOf(fusen);

                fusenList[ChangeOrderNum - 1] = fusen;
                fusenList[idx] = ff;

                ChangeOrderNum = (ChangeOrderNum + 1) % (fusenList.Count + 1);

                fusenList.InvalidatedAll();
            }
        }

        // 設定保存
        public static void SaveSettingAsync()
        {
            var task = Task.Factory.StartNew(SaveSetting);
        }
        public static void SaveSetting()
        {
            SaveSetting(settingFilePath);
        }
        public static void SaveSetting(string filePath)
        {
            // 全体
            FusenConfig cfg = new FusenConfig()
            {
                FrameMargin = frameMargin,
                AdsorbMargin = adsorbMargin,
                DataFilePath = dataFilePath,
                ImportSettingFilePath = importSettingFilePath,
                ExportSettingFilePath = exportSettingFilePath,
                ImportDataFilePath = importDataFilePath,
                ExportDataFilePath = exportDataFilePath,
                UserColors = userColors.ToHtmlString()
            };
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(JsonSerializer.PrettyPrint(JsonSerializer.Serialize(cfg)));
            }
        }

        // 付箋データ保存
        public static void SaveFusenDataAsync()
        {
            var task = Task.Factory.StartNew(SaveFusenData);
        }
        public static void SaveFusenData()
        {
            SaveFusenData(null);
        }
        public static void SaveFusenData(FusenForm fusen)
        {
            SaveFusenData(fusen, dataFilePath);
        }
        public static void SaveFusenData(FusenForm fusen, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                List<FusenData> fusenDataList = new List<FusenData>();

                FusenList fusens = new FusenList();
                if(fusen == null)
                {
                    fusens = fusenList;
                }
                else
                {   // 付箋の指定があるときは1つだけのExportなので指定付箋1つだけの新規リストを作る
                    fusens = new FusenList() { fusen };
                }

                foreach (var f in fusens)
                {
                    FusenData fusenData = new FusenData()
                    {
                        CreateDateTime = f.CreateDateTime,
                        UpdateDateTime = f.UpdateDateTime,
                        Left = f.Left,
                        Top = f.Top,
                        Width = f.Width,
                        Height = f.Height,
                        Text = f.Text,
                        FontName = f.FontName,
                        FontSize = f.FontSize,
                        ImageFilePath = f.ImageFilePath,
                        ForeColor = ColorTranslator.ToHtml(f.ForeColor),
                        BackColor = ColorTranslator.ToHtml(f.BackColor),
                        Opacity = f.Opacity,
                        ArrangeMember = f.ArrangeMember
                    };
                    fusenDataList.Add(fusenData);
                }
                sw.Write(JsonSerializer.PrettyPrint(JsonSerializer.Serialize(fusenDataList)));
            }
        }

        // 設定読み出し
        public static void LoadSetting()
        {
            LoadSetting(settingFilePath);
        }
        public static void LoadSetting(string filePath)
        {
            try
            {
                // 読み込み
                using (StreamReader sr = new StreamReader(filePath))
                {
                    FusenConfig cfg = new FusenConfig();
                    cfg = JsonSerializer.Deserialize<FusenConfig>(sr.ReadToEnd());

                    frameMargin = cfg.FrameMargin;
                    adsorbMargin = cfg.AdsorbMargin;
                    dataFilePath = cfg.DataFilePath;
                    importSettingFilePath = cfg.ImportSettingFilePath;
                    exportSettingFilePath = cfg.ExportSettingFilePath;
                    importDataFilePath = cfg.ImportDataFilePath;
                    exportDataFilePath = cfg.ExportDataFilePath;
                    userColors.FromHtmlString(cfg.UserColors);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
            }
            catch (Exception ee)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}\r\n{2}", ee.Message, ee.Source, ee.StackTrace));
            }
        }

        // 設定読み出し
        public static void LoadFusenData()
        {
            LoadFusenData(dataFilePath);
        }
        public static void LoadFusenData(string filePath)
        {
            try
            {
                // 読み込み
                using (StreamReader sr = new StreamReader(filePath))
                {
                    List<FusenData> fusenDataList = new List<FusenData>();

                    fusenDataList = JsonSerializer.Deserialize<List<FusenData>>(sr.ReadToEnd());

                    foreach (var fd in fusenDataList)
                    {
                        FusenForm ff = new FusenForm()
                        {
                            CreateDateTime = fd.CreateDateTime,
                            UpdateDateTime = fd.UpdateDateTime,
                            Left = fd.Left,
                            Top = fd.Top,
                            Width = fd.Width,
                            Height = fd.Height,
                            Text = fd.Text,
                            FontName = fd.FontName,
                            FontSize = fd.FontSize,
                            ImageFilePath = fd.ImageFilePath,
                            ForeColor = ColorTranslator.FromHtml(((string)(fd.ForeColor)).Replace("#", "0x")),
                            BackColor = ColorTranslator.FromHtml(((string)(fd.BackColor)).Replace("#", "0x")),
                            Opacity = fd.Opacity,
                            ArrangeMember = fd.ArrangeMember
                        };
                        fusenList.Add(ff);
                        ff.Show();
                        // Showした後でもう一度サイズ指定しないと小サイズの時サイズが変わってしまう
                        ff.Width = fd.Width;
                        ff.Height = fd.Height;
                    }
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (Exception ee)
            {
                MessageBox.Show(string.Format("{0}\r\n{1}\r\n{2}", ee.Message, ee.Source, ee.StackTrace));
            }
        }
        
        // イベントハンドラ
        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {
            TopMost = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Hide(); // メインフォームは非表示

            LoadSetting();
            LoadFusenData();

            // 1つもなかったら1つ作る
            if (fusenList.Count() == 0)
            {
                AddNewFusen();
                fusenList[0].StartPosition = FormStartPosition.WindowsDefaultLocation;
            }
        }

        private void miNewFusen_Click(object sender, EventArgs e)
        {
            AddNewFusen();
        }

        private void cmExit_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void notifyIconMain_DoubleClick(object sender, EventArgs e)
        {
            AddNewFusen();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIconMain.Visible = false;
        }

        private void miGatherFusen_Click(object sender, EventArgs e)
        {
            GatherFusen();
        }

        private void miArrangeScreenLeft_Click(object sender, EventArgs e)
        {
            ArrangeFusen(ArrangeType.ScreenLeft, fusenList[0]);
        }

        private void miArrangeScreenRight_Click(object sender, EventArgs e)
        {
            ArrangeFusen(ArrangeType.ScreenRight, fusenList[0]);
        }

        private void miChangeOrder_Click(object sender, EventArgs e)
        {
            StartChangeOrder(true);
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                StartChangeOrder(false);
            }
        }

        private void miStatusFilePath_Click(object sender, EventArgs e)
        {
            SetDataFilePath();
        }

        private void miExportAllFusenData_Click(object sender, EventArgs e)
        {
            ExportFusenData();
        }

        private void miExportSetting_Click(object sender, EventArgs e)
        {
            ExportSetting();
        }

        private void miImportFusenData_Click(object sender, EventArgs e)
        {
            ImportFusenData();
        }

        private void miImportSetting_Click(object sender, EventArgs e)
        {
            ImportSetting();
        }

        private void miPutInsideScreen_Click(object sender, EventArgs e)
        {
            fusenList.PutInsideRect(Screen.PrimaryScreen.Bounds);
        }

        private void miStartup_CheckedChanged(object sender, EventArgs e)
        {
            if(miStartup.Checked)
            {
                CreateStartupShortcut();
            }
            else
            {
                File.Delete(shortcutFilePath);
            }
        }

        private void miHelp_Click(object sender, EventArgs e)
        {
            string helpFilePath = string.Format("{0}\\MYE付箋説明書.hta", Path.GetDirectoryName(Application.ExecutablePath));
            if (File.Exists(helpFilePath))
            {
                Process.Start(helpFilePath);
            }
        }
    }
}
