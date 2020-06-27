using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MyeFusen
{
    public class FusenList : List<FusenForm>
    {
        public void DeleteAll()
        {
            foreach (FusenForm ff in this)
            {
                ff.Close();
                ff.Dispose();
            }
            Clear();
        }
        public void InvalidatedAll()
        {
            foreach (FusenForm ff in this)
            {
                ff.Invalidate();
            }
        }


        public void PutInsideRect(Rectangle rc)
        {
            foreach (FusenForm ff in this)
            {
                int topOffset = ff.Top - rc.Top;
                int bottomOffset = rc.Bottom - ff.Bottom;
                int leftOffset = ff.Left - rc.Left;
                int rightOffset = rc.Right - ff.Right;

                if (ff.Top < rc.Top)
                {
                    ff.Top = rc.Top;
                }
                if (ff.Bottom > rc.Bottom)
                {
                    ff.Top -= ff.Bottom - rc.Bottom;
                }
                if (ff.Left < rc.Left)
                {
                    ff.Left = rc.Left;
                }
                if (ff.Right > rc.Right)
                {
                    ff.Left -= ff.Right - rc.Right;
                }
            }
        }
    }
}
