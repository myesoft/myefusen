using System;
using System.Collections.Generic;
using System.Text;

namespace MyeFusen
{
    // 付箋のオプション設定のクラス（JSONシリアライズ用）
    public class FusenConfig
    {
        public int FrameMargin { get; set; } // 外枠から文字領域までのマージン
        public int AdsorbMargin { get; set; } // 吸着距離（0は吸着しない）
        public string DataFilePath { get; set; }
        public string ImportSettingFilePath { get; set; }
        public string ExportSettingFilePath { get; set; }
        public string ImportDataFilePath { get; set; }
        public string ExportDataFilePath { get; set; }
        public string UserColors { get; set; }
    }
}
