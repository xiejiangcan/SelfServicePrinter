using System;

namespace YUTU.BLL.Common
{
    public class ChineseDescriptionAttribute : Attribute
    {
        public string Text { get; set; }

        public ChineseDescriptionAttribute(string text)
        {
            Text = text;
        }
    }
}
