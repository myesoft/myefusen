using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace MyeFusen
{
    public class FusenImage
    {
        // 内部変数
        private static string SupportImageFileExtentions = "";
        public Image ImageObj = null;
        public string ImageFilePath => imgFilePath; 

        private string imgFilePath;
        public FusenImage()
        {
            Init();
        }
        private static void Init()
        {
            if (SupportImageFileExtentions.Length == 0)
            {
                // Imageがサポートしているファイルの拡張子を連結
                foreach (ImageCodecInfo ici in ImageCodecInfo.GetImageDecoders())
                {
                    SupportImageFileExtentions += ici.FilenameExtension.ToLower().Replace(";", "").Replace("*", "");
                }
            }
        }

        // Staticメソッド
        public static bool IsSupportedImageFile(string filePath)
        {
            Init();
            return SupportImageFileExtentions.IndexOf(Path.GetExtension(filePath).ToLower()) >= 0;
        }
        public void LoadImageFromFile(string filePath)
        {
            if (!File.Exists(filePath)) return;

            if (ImageObj != null)
            {
                ImageObj.Dispose();
            }
            ImageObj = Image.FromFile(filePath);
            imgFilePath = filePath;
        }
        // オリジナルを付箋データの場所にコピーして読み込む
        public void CopyAndLoadImageFromFile(string filePath)
        {
            // 保持しているイメージとファイルを削除
            DeleteImage();

            // Imageフォルダが無い時は作る
            string imgDir = string.Format("{0}\\Image", Path.GetDirectoryName(MainForm.DataFilePath));
            if (! Directory.Exists(imgDir))
            {
                Directory.CreateDirectory(imgDir);
            }
            // 新しいイメージをコピー＆ロード
            imgFilePath = string.Format("{0}\\{1}", imgDir, Path.GetFileName(filePath));

            if(filePath != imgFilePath)
            {
                File.Copy(filePath, imgFilePath, true); // 上書きコピー
            }
            LoadImageFromFile(imgFilePath);
        }

        public void LoadImageFromBitmap(Bitmap bmp)
        {
            // Bitmapを一時ファイルに保存
            string tmpFilePath = string.Format("{0}\\capture{1}.bmp", Path.GetDirectoryName(MainForm.DataFilePath), DateTime.Now.ToString("yyyyMMdd-hhmmss"));
            bmp.Save(tmpFilePath,ImageFormat.Bmp);
            
            //イメージファイルをDropした時と同じ処理
            CopyAndLoadImageFromFile(tmpFilePath);

            //一時ファイルを削除
            File.Delete(tmpFilePath);
        }
        public void DeleteImage()
        {
            if (ImageObj != null)
            {
                ImageObj.Dispose();
                ImageObj = null;
            }
            // イメージファイル削除
            if(File.Exists(imgFilePath))
            {
                File.Delete(imgFilePath);
                imgFilePath = "";
            }
        }
    }
}
