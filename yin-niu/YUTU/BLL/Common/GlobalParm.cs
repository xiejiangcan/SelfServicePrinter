
namespace YUTU.BLL.Common
{
    /// <summary>
    /// 存放程序全局参数
    /// </summary>
    public static class GlobalParm
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public static string  CompanyName { get; set; }

        /// <summary>
        /// 打印磅单抬头
        /// </summary>
        public static string PoundTop { get; set; }

        /// <summary>
        /// 打印磅单底部
        /// </summary>
        public static string PoundBottom { get; set; }

        /// <summary>
        /// 自动清除几天前的数据
        /// </summary>
        public static int AutoClearUnuseWeightDay { get; set; }

        /// <summary>
        /// 自动隐藏几天前的数据
        /// </summary>
        public static int AutoHideDay { get; set; }


        
    }
}
