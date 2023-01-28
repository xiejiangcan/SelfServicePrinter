using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUTU.BLL.Common
{
    public class RuntimeMonitor
    {
        private readonly static Stopwatch watch = new Stopwatch();
        public static void StartMonit()
        {
            watch.Start();
        }

        public static void StopMonit()
        {
            watch.Stop();
        }

        public static string GetTimeLen()
        {
            return formatLongToTimeStr(watch.ElapsedMilliseconds);
        }
        private static String formatLongToTimeStr(long l)
        {
            String str = "";
            int hour = 0;
            int minute = 0;
            int second = 0;
            second = (int)(l / 1000);

            if (second > 60)
            {
                minute = second / 60;
                second = second % 60;
            }
            if (minute > 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            return $"{hour}小时{minute} 分钟{second} 秒";
        }
    }
}
