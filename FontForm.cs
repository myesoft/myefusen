using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace MyeFusen
{
    public partial class FontForm : Form
    {
        private static FontList fonts = new FontList();

        public string CurrentFontName;
        public event FontSelectedEventHandler FontSelected;

        // コンストラクタ
        public FontForm(byte enumCharSet)
        {
            InitializeComponent();

            // フォントリスト作成
            fonts.EnumlateFont(enumCharSet);
            FontListBox.DataSource = fonts;

            //20以上はスクロールにする。
            //FormのHeightはListBoxより4大きくしないと何故か1行空行ができてしまうので調整する。
            Height = Math.Min(fonts.Count, 20) * FontListBox.ItemHeight + 4;
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Hide();
        }

        protected virtual void OnFontSelected(object sender, FontSelectedEventArgs e)
        {
            //this.Hide();
            if (FontSelected != null)
                FontSelected(sender, e);
        }

        private void FontListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            OnFontSelected(sender, new FontSelectedEventArgs((string)FontListBox.SelectedValue));
        }

        private void FontListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            //背景を描画する
            e.DrawBackground();

            //ListBoxが空のときにListBoxが選択されるとe.Indexが-1になる
            if (e.Index < 0)
                return;

            string sampleStr = "漢あ";

            using (Brush brush = new SolidBrush(e.ForeColor))
            {
                string fontName = ((ListBox)sender).Items[e.Index].ToString();
                using (Font font = new Font(fontName, e.Font.Size))
                {
                    Rectangle rc1 = e.Bounds;
                    rc1.Width = 40;

                    Rectangle rc2 = rc1;
                    rc2.Offset(rc1.Width + 2, 0);
                    rc2.Width = e.Bounds.Width - (rc1.Width + 2);

                    bool bSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
                    
                    if(bSelected)
                        e.Graphics.FillRectangle(SystemBrushes.MenuHighlight, rc1);
                    else if (CurrentFontName == fontName)
                        e.Graphics.FillRectangle(SystemBrushes.InactiveCaption, rc1);
                    else
                        e.Graphics.FillRectangle(SystemBrushes.Menu, rc1);

                    e.Graphics.DrawString(sampleStr, font, brush, rc1);
                    e.Graphics.DrawString(fontName, FontListBox.Font, brush, rc2);
                }
            }
        }

        private void FontForm_MouseLeave(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FontForm_Activated(object sender, EventArgs e)
        {
            FontListBox.SelectedItem = CurrentFontName;
        }
    }

    public class FontSelectedEventArgs : System.EventArgs
    {

        public FontSelectedEventArgs(string fontName)
        {
            FontName = fontName;
        }

        public readonly string FontName;
    }
    public delegate void FontSelectedEventHandler(object sender, FontSelectedEventArgs e);

}
