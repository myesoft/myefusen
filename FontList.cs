using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MyeFusen
{
    public class FontList : List<string>
    {
        //フォントリストアップ
        public void EnumlateFont(byte enumCharSet)
        {
            if (Count == 0)
            {
                foreach (FontFamily ff in FontFamily.Families)
                {
                    if (!ff.IsStyleAvailable(FontStyle.Regular))
                        continue;

                    using (Font font = new Font(ff.Name, 10))
                    {
                        unsafe
                        {
                            object lfObj = new LOGFONT();
                            font.ToLogFont(lfObj);
                            LOGFONT lf = (LOGFONT)lfObj;

                            //文字セットが一致するものだけを登録
                            if (lf.lfCharSet == enumCharSet)
                            {
                                Add(ff.Name);
                            }
                        }
                    }
                }
            }
        }
    }

    //LOGFONT構造体
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct LOGFONT
    {
        public const int LF_FACESIZE = 32;
        public int lfHeight;
        public int lfWidth;
        public int lfEscapement;
        public int lfOrientation;
        public int lfWeight;
        public byte lfItalic;
        public byte lfUnderline;
        public byte lfStrikeOut;
        public byte lfCharSet;
        public byte lfOutPrecision;
        public byte lfClipPrecision;
        public byte lfQuality;
        public byte lfPitchAndFamily;
        public fixed ushort lfFaceName[LF_FACESIZE];
    }
}
