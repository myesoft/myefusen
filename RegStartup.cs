using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MyeFusen
{
    // スタートアップにショートカットを登録するサポートクラス
    public class RegStartup
    {
        private string linkFile;
        private string scriptFile;
        private string appTitle;

        public bool IsRegisted => File.Exists(linkFile);
        public RegStartup()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var attribute = Attribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute)) as AssemblyTitleAttribute;
            appTitle = attribute.Title;

            // WSHスクリプト名
            scriptFile = Directory.GetParent(Application.ExecutablePath) + "\\addStartup.js";

            // ショートカットのリンク名
            String sMnu = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            linkFile = sMnu + "\\" + appTitle + ".lnk";
        }
        // 登録
        public void Regist()
        {
            // スタートアップフォルダにショートカット作成
            try
            {
                // WSHファイル作成
                using (StreamWriter w = new StreamWriter(scriptFile, false, Encoding.GetEncoding("shift_jis")))
                {
                    w.WriteLine("ws = WScript.CreateObject('WScript.Shell');");
                    w.WriteLine("ln = ws.SpecialFolders('Startup') + '\\\\' + '" + appTitle + ".lnk';");
                    w.WriteLine("sc = ws.CreateShortcut(ln);");
                    w.WriteLine("sc.TargetPath = ws.CurrentDirectory + '\\\\" + Path.GetFileName(Application.ExecutablePath) + "';");
                    w.WriteLine("sc.Save();");
                }

                // addStartup.jsを実行し、スタートアップにショートカット作成
                if (File.Exists(scriptFile))
                {
                    ProcessStartInfo psi = (new ProcessStartInfo());
                    psi.FileName = "cscript";
                    psi.Arguments = @"//e:jscript " + scriptFile;
                    psi.WindowStyle = ProcessWindowStyle.Hidden;
                    Process p = Process.Start(psi);

                    p.WaitForExit(10000); // 終了まで待つ(最大10秒)
                    File.Delete(scriptFile);
                }
                // スタートアップフォルダに登録されたか確認
                if (File.Exists(linkFile))
                {
                    MessageBox.Show(
                        "スタートアップに登録しました。\n\n" + linkFile, appTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        "スタートアップへの登録に失敗しました。\n\n" + linkFile, appTitle, 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "スタートアップへの登録に失敗しました。\n\n" + ex.Message, appTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
        // 登録解除
        public void UnRegist()
        {
            // スタートアップフォルダに登録済みか確認
            if (File.Exists(linkFile))
            {
                try
                {
                    File.Delete(linkFile);
                    MessageBox.Show(
                        "スタートアップから削除しました。", appTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                        "スタートアップからの削除に失敗しました。\n\n" + ex.Message, appTitle,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }
    }
}
