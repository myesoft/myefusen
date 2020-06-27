using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace MyeFusen
{
    public class ColorList: List<Color>
    {
        public ColorList()
        {
        }

        public void ImportFrom(string listStr)
        {
            foreach (string s in listStr.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Add(ColorTranslator.FromHtml(s));
            }
        }
        public string ExportToString()
        {
            string s = "";

            foreach (Color cl in this)
            {
                s += string.Format("{0}:", ColorTranslator.ToHtml(cl));
            }
            return s;
        }

        public int[] ToIntArray()
        {
            List<int> il = new List<int>();

            foreach (Color cl in this)
            {
                il.Add(ColorTranslator.ToWin32(cl));
            }

            return il.ToArray();
        }

        public void FromIntArray(int[] iar)
        {
            this.Clear();
            foreach (int i in iar)
            {
                if(i != ColorTranslator.ToWin32(Color.White))
                    this.Add(ColorTranslator.FromWin32(i));
            }
        }
    }

    public class WebColors : ColorList 
    {
        // コンストラクタ
        public WebColors()
        {
            if (Count == 0)
            {
                foreach (PropertyInfo info in typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static))
                {
                    Color color = (Color)info.GetValue(null, null);
                    if (color.Name != "Transparent" && color.Name != "White")
                    {
                        Add(color);
                    }
                }
            }
        }
    }

    public class UserColorList : ColorList
    {
        public const int MaxCount = 16;

        public void AddUniqe(Color item)
        {
            if (!Exists((cl) => { return cl==item; }))
            {
                Add(item);
            }
            if (this.Count() > MaxCount)
            {
                RemoveAt(0); // 古いものから消していく
            }
        }

        public string ToHtmlString()
        {
            string s = "";
            foreach (var cl in this)
            {
                s += ColorTranslator.ToHtml(cl) + ":";
            }
            return s;
        }

        public void FromHtmlString(string s)
        {
            string[] sUserColors = s.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            Clear();
            foreach (string sColor in sUserColors)
            {
                Add(ColorTranslator.FromHtml(sColor.Replace("#", "0x")));
            }
        }

    }
}
