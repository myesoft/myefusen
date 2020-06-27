using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace MyeFusen
{
    public class TransparentTextBox : System.Windows.Forms.TextBox
    {
        public TransparentTextBox() : base()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void DrawControl(Control c, PaintEventArgs pevent)
        {
            Point offset = new Point(this.Left - c.Left, this.Top - c.Top);

            // 原点を背面コントロールの座標へ
            pevent.Graphics.TranslateTransform(
                -offset.X, -offset.Y);

            // コントロールを描画
            this.InvokePaintBackground(c, pevent);
            this.InvokePaint(c, pevent);

            // 子コントロールを描画
            for (int j = c.Controls.Count - 1; j >= 0; --j)
            {
                Control child = c.Controls[j];
                if (!child.Visible) continue;   // 対象のコントロールが非表示
                DrawControl(child, pevent);
            }

            // 原点の座標を戻す
            pevent.Graphics.TranslateTransform(
                offset.X, offset.Y);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            // 親がいない場合は無視
            if (this.Parent == null) return;

            Point offset = new Point(this.Left, this.Top);

            // 原点を親コントロールの座標へ
            pevent.Graphics.TranslateTransform(
                -offset.X, -offset.Y);
            // 親コントロールを描画
            this.InvokePaintBackground(this.Parent, pevent);
            this.InvokePaint(this.Parent, pevent);
            // 原点の座標を戻す
            pevent.Graphics.TranslateTransform(offset.X, offset.Y);

            // 各背面コントロールを描画
            for (int i = this.Parent.Controls.Count - 1; i >= 0; --i)
            {
                Control c = this.Parent.Controls[i];

                if (c == this) break;   // 背面コントロールの描画終わり
                if (!c.Visible) continue;   // 対象のコントロールが非表示

                // 対象のコントロールが描画領域に含まれているか
                if (c.Bounds.IntersectsWith(this.Bounds))
                {
                    // 背面コントロールを描画
                    DrawControl(c, pevent);
                }
            }
        }

    }
}
