using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyeFusen
{
    public partial class WebColorForm : Form
    {
        private static WebColors webColors = new WebColors();

        public event ColorSelectedEventHandler ColorSelected;// 一時的な変更、選択のみ
        public event ColorChangedEventHandler ColorChanged; // 確定

        public WebColorForm()
        {
            InitializeComponent();

            webColors.Sort((a, b) =>
            {
                if (a.GetHue() != b.GetHue())
                    return a.GetHue() < b.GetHue() ? 1 : -1;

                if (a.GetSaturation() != b.GetSaturation())
                    return a.GetSaturation() < b.GetSaturation() ? 1 : -1;

                return a.GetBrightness() < b.GetBrightness() ? 1 : -1;
            });

            WebColorListBox.DataSource = webColors;

            //20以上はスクロールにする。
            //FormのHeightはListBoxより4大きくしないと何故か1行空行ができてしまうので調整する。
            Height = Math.Min(webColors.Count, 20) * WebColorListBox.ItemHeight + 4;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Hide();
        }

        protected virtual void OnColorSelected(object sender, ColorSelectedEventArgs e)
        {
            //this.Hide();
            if (ColorSelected != null)
                ColorSelected(sender, e);
        }

        private void WebColorListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            OnColorSelected(sender, new ColorSelectedEventArgs((Color)WebColorListBox.SelectedValue));
        }

        private void WebColorListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //背景を描画する
            e.DrawBackground();

            //ListBoxが空のときにListBoxが選択されるとe.Indexが-1になる
            if (e.Index < 0)
                return;

            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                Rectangle rc1 = e.Bounds;
                rc1.Width = rc1.Height;

                Rectangle rc2 = rc1;
                rc2.Offset(rc1.Width + 2, 0);
                rc2.Width = e.Bounds.Width - (rc1.Width + 2);

                Color cl = webColors[e.Index];
                rc1.Inflate(-2, -2);
                e.Graphics.FillRectangle(new SolidBrush(cl), rc1);
                e.Graphics.DrawRectangle(SystemPens.ControlDarkDark, rc1);
                e.Graphics.DrawString(cl.Name, e.Font, brush, rc2);
            }
        }

        private void WebColorForm_VisibleChanged(object sender, EventArgs e)
        {
            if(ColorChanged != null && ! Visible)
                ColorChanged(sender, e);
        }

        private void WebColorForm_MouseLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

    }

    // イベントハンドラ引数定義
    public class ColorSelectedEventArgs : System.EventArgs
    {

        public ColorSelectedEventArgs(Color color)
        {
            WebColor = color;
        }

        public readonly Color WebColor;
    }

    //イベントハンドラの型定義
    public delegate void ColorSelectedEventHandler(object sender, ColorSelectedEventArgs e);
    public delegate void ColorChangedEventHandler(object sender, EventArgs e);
}
