using System;
using System.Collections.Generic;
using Utf8Json;
using Utf8Json.Formatters;

namespace MyeFusen
{
    //個々の付箋のプロパティ
    public class FusenData
    {
        [JsonFormatter(typeof(DateTimeFormatter), "yyyyMMdd-HHmmss")]
        public DateTime CreateDateTime {get;set;}
        [JsonFormatter(typeof(DateTimeFormatter), "yyyyMMdd-HHmmss")]
        public DateTime UpdateDateTime { get; set; }
        public int Left {get;set;}
        public int Top { get; set; }
        public int Width {get;set;}
        public int Height {get;set;}
        public string Text {get;set;}
        public string FontName {get;set;}
        public float FontSize { get; set; }
        public string ImageFilePath { get; set; }
        public string ForeColor {get;set;}
        public string BackColor {get;set;}
        public double Opacity {get;set;}
        public bool ArrangeMember {get;set;}
    }
}
