using Nancy.Diagnostics;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace SelfServicePrinter.Common.Models
{
    public enum EnumPrintColor
    {
        [Description("黑白")]
        BlackAndWhite = 0,
        [Description("黑白")]
        Colors = 1,
    }

    public enum EnumPrintPageType
    {
        [Description("单页")]
        SinglePage,
        [Description("双页")]
        DoublePage,
    }

    public enum EnumPageOrientation
    {
        [Description("横向")]
        Horizontal,
        [Description("纵向")]
        Vertical,
    }

    public enum EnumPageLayout
    {
        [Description("无缩放")]
        NoScale,
        [Description("每版打印1页")]
        OnePage,
        [Description("每版打印2页")]
        TwoPage,
        [Description("每版打印4页")]
        FourPage,
        [Description("每版打印6页")]
        SixPage,
        [Description("每版打印9页")]
        NinePage,
    }
}
