using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Common
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
