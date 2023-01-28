using System;
using System.Collections.Generic;
using System.Reflection;
using YUTU.BLL.Common.Cryptography;
using System.Management;
using System.IO.Ports;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace YUTU.BLL.Common
{
    /// <summary>
    /// 常用工具类
    /// </summary>
    internal static class Tools
    {
        /// <summary>
        /// 获取服务器时间的字符串形式
        /// </summary>
        public static string Now { get { return GetDateTimeString(); } }

        /// <summary>
        /// 获取时间：yyyyMMdd
        /// </summary>
        public static string YearMonthDay
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMdd");
            }
        }
        /// <summary>
        /// 获取时间：yyyy-MM-dd
        /// </summary>
        public static string YearMonthDay2
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns>服务器时间</returns>
        public static DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 获取服务器时间的字符串形式，等同于属性Now
        /// </summary>
        /// <returns>服务器时间的字符串形式</returns>
        public static string GetDateTimeString()
        {
            return GetDateTime().ToString("yyyy-MM-dd HH:mm:ss");
        }


        /// <summary>
        /// 补齐数位
        /// </summary>
        /// <param name="source">数值</param>
        /// <param name="length">长度</param>
        /// <returns>结果字符串</returns>
        public static string FillLength(int source, int length)
        {
            string result = source.ToString();
            if (result.Length > length)
            {
                throw new ArgumentException("source本身的长度已经超过指定的length", "source");
            }
            while (result.Length < length)
            {
                result = "0" + result;
            }
            return result;
        }

        public static string ChineseCap(string ChineseStr)
        {
            string Capstr = "";
            byte[] ZW = new byte[2];
            long ChineseStr_int;
            string CharStr, ChinaStr = " ";
            for (int i = 0; i <= ChineseStr.Length - 1; i++)
            {
                CharStr = ChineseStr.Substring(i, 1).ToString();
                ZW = System.Text.Encoding.Default.GetBytes(CharStr);
                //得到汉字符的字节数组 
                if (ZW.Length == 2)
                {
                    int i1 = (short)(ZW[0]);
                    int i2 = (short)(ZW[1]);
                    ChineseStr_int = i1 * 256 + i2;
                    if ((ChineseStr_int >= 45217) && (ChineseStr_int <= 45252))
                    {
                        ChinaStr = "A ";
                    }
                    else if ((ChineseStr_int >= 45253) && (ChineseStr_int <= 45760))
                    {
                        ChinaStr = "B ";
                    }
                    else if ((ChineseStr_int >= 45761) && (ChineseStr_int <= 46317))
                    {
                        ChinaStr = "C ";
                    }
                    else if ((ChineseStr_int >= 46318) && (ChineseStr_int <= 46825))
                    {
                        ChinaStr = "D ";
                    }
                    else if ((ChineseStr_int >= 46826) && (ChineseStr_int <= 47009))
                    {
                        ChinaStr = "E ";
                    }
                    else if ((ChineseStr_int >= 47010) && (ChineseStr_int <= 47296))
                    {
                        ChinaStr = "F ";
                    }
                    else if ((ChineseStr_int >= 47297) && (ChineseStr_int <= 47613))
                    {
                        ChinaStr = "G ";
                    }
                    else if ((ChineseStr_int >= 47614) && (ChineseStr_int <= 48118))
                    {
                        ChinaStr = "H ";
                    }
                    else if ((ChineseStr_int >= 48119) && (ChineseStr_int <= 49061))
                    {
                        ChinaStr = "J ";
                    }
                    else if ((ChineseStr_int >= 49062) && (ChineseStr_int <= 49323))
                    {
                        ChinaStr = "K ";
                    }
                    else if ((ChineseStr_int >= 49324) && (ChineseStr_int <= 49895))
                    {
                        ChinaStr = "L ";
                    }
                    else if ((ChineseStr_int >= 49896) && (ChineseStr_int <= 50370))
                    {
                        ChinaStr = "M ";
                    }
                    else if ((ChineseStr_int >= 50371) && (ChineseStr_int <= 50613))
                    {
                        ChinaStr = "N ";
                    }
                    else if ((ChineseStr_int >= 50614) && (ChineseStr_int <= 50621))
                    {
                        ChinaStr = "O ";
                    }
                    else if ((ChineseStr_int >= 50622) && (ChineseStr_int <= 50905))
                    {
                        ChinaStr = "P ";
                    }
                    else if ((ChineseStr_int >= 50906) && (ChineseStr_int <= 51386))
                    {
                        ChinaStr = "Q ";
                    }
                    else if ((ChineseStr_int >= 51387) && (ChineseStr_int <= 51445))
                    {
                        ChinaStr = "R ";
                    }
                    else if ((ChineseStr_int >= 51446) && (ChineseStr_int <= 52217))
                    {
                        ChinaStr = "S ";
                    }
                    else if ((ChineseStr_int >= 52218) && (ChineseStr_int <= 52697))
                    {
                        ChinaStr = "T ";
                    }
                    else if ((ChineseStr_int >= 52698) && (ChineseStr_int <= 52979))
                    {
                        ChinaStr = "W ";
                    }
                    else if ((ChineseStr_int >= 52980) && (ChineseStr_int <= 53640))
                    {
                        ChinaStr = "X ";
                    }
                    else if ((ChineseStr_int >= 53689) && (ChineseStr_int <= 54480))
                    {
                        ChinaStr = "Y ";
                    }
                    else if ((ChineseStr_int >= 54481) && (ChineseStr_int <= 55289))
                    {
                        ChinaStr = "Z ";
                    }
                }
                else
                {
                    //Capstr = ChineseStr;
                    ChinaStr = CharStr;
                    //break;
                }
                Capstr = Capstr + ChinaStr;
            }
            return Capstr;
        }

        /// <summary>
        /// 获得一个类中的所有属性的中文标注
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns>属性名称与中文标注的字典</returns>
        public static Dictionary<string, string> GetChineseDescriptions(Type type)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (PropertyInfo pi in type.GetProperties())
            {
                string pName = pi.Name;
                string pText = ((ChineseDescriptionAttribute)Attribute.GetCustomAttribute(pi, typeof(ChineseDescriptionAttribute))).Text;
                result.Add(pName, pText);
            }
            return result;
        }

        public static decimal GetTimeDiffHours(string time1, string time2)
        {
            decimal hours = 0;
            int days = 0, hour = 0;
            decimal minutes = 0;
            DateTime datetime1 = Convert.ToDateTime(time1);
            DateTime datetime2 = Convert.ToDateTime(time2);
            TimeSpan span1 = new TimeSpan(datetime1.Ticks);
            TimeSpan span2 = new TimeSpan(datetime2.Ticks);
            TimeSpan span = span1.Subtract(span2).Duration();
            days = span.Days;
            hour = span.Hours;
            minutes = span.Minutes;
            hours = days * 24 + hour + minutes / 60;
            //hours = float.Parse(hours.ToString("0.00"));
            return hours;
        }
        /// <summary>
        /// 格式化时间格式20051105
        /// </summary>
        /// <returns></returns>
        public static string GetFormatDate()
        {
            DateTime dt = DateTime.Now;
            string newDate = string.Format("{0:u}", dt);//2005-11-05 14:23:23Z
            return newDate.Substring(0, 4) + newDate.Substring(5, 2) + newDate.Substring(8, 2);
        }
        /// <summary>
        /// 返回加固定天数后日期，类型格式2013-05-10
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public static string GetDateAddDay(int day)
        {
            return DateTime.Now.AddDays(day).ToShortDateString();
        }

        public static long GetDateTimeDiffSecond(DateTime dt1, DateTime dt2)
        {
            //DateTime dt1 = DateTime.Parse(t1);
            //DateTime dt2 = DateTime.Parse(t2);
            TimeSpan ts = dt2 - dt1;
            return ts.Days * 24 * 60 * 60 + ts.Hours * 60 * 60 + ts.Minutes * 60 + ts.Seconds;
        }
        /// <summary>
        /// 获取硬盘号
        /// </summary>
        /// <returns></returns>
        public static string GetDiskInfo()
        {
            try
            {
                HardDiskInfo hdd = AtapiDevice.GetHddInfo(0); // 第一个硬盘
                //string hardinfo = "硬盘型号：" + hdd.ModuleNumber + "  硬盘ID号：" + hdd.SerialNumber + "  固件版本：" + hdd.Firmware + "  硬盘容量：" + hdd.Capacity;
                string hardinfo = hdd.SerialNumber;
                return hardinfo;
            }
            catch
            {
                return "unknow";
            }
        }
        public static string GetDiskInfo2()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                String strHardDiskID = "unknow";
                foreach (ManagementObject mo in searcher.Get())
                {
                    strHardDiskID = mo["SerialNumber"].ToString().Trim();
                    break;
                }
                return strHardDiskID;
            }
            catch
            {
                return "unknow";
            }
        }
        public static string GetEncryptStr(string empower)
        {
            return EncryptCommon.EncryptStr(empower);
        }
        public static string GetDecryptStr(string empower)
        {
            return EncryptCommon.DecryptStr(empower);
        }

        public static DateTime AddDay(string date, int day)
        {
            return DateTime.Parse(date).AddDays(day);
        }

        public static DateTime AddMinutes(int min)
        {
            return DateTime.Now.AddMinutes(min);
        }

        public static string GetCurrentPath()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// 设置串口号
        /// </summary>
        /// <param name="obj"></param>
        public static void SetPortNameValues(ComboBox obj)
        {
            obj.Items.Clear();
            string[] systemPort = SerialPort.GetPortNames();
            string temp;
            int int1, int2;
            int count = systemPort.Length;
            if (count < 1) return;
            for (int i = 1; i < count; i++)
            {
                for (int j = 0; j < count - 1; j++)
                {
                    int1 = int.Parse(systemPort[j].Substring(3, systemPort[j].Length - 3));
                    int2 = int.Parse(systemPort[j + 1].Substring(3, systemPort[j + 1].Length - 3));
                    if (int1 > int2)
                    {
                        temp = systemPort[j];
                        systemPort[j] = systemPort[j + 1];
                        systemPort[j + 1] = temp;
                    }
                }
            }
            foreach (string str in systemPort)
            {
                obj.Items.Add(str);
            }
        }

        /// <summary>
        /// 两个时间相隔的分钟
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static int GetDateTimeDiff(string t1, string t2)
        {
            DateTime dt1 = DateTime.Parse(t1);
            DateTime dt2 = DateTime.Parse(t2);
            TimeSpan ts = dt2 - dt1;
            return ts.Days * 24 * 60 + ts.Hours * 60 + ts.Minutes;
        }

        public static long GetDateTimeDiffSecond(string t1, string t2)
        {
            DateTime dt1 = DateTime.Parse(t1);
            DateTime dt2 = DateTime.Parse(t2);
            TimeSpan ts = dt2 - dt1;
            return ts.Days * 24 * 60 * 60 + ts.Hours * 60 * 60 + ts.Minutes * 60 + ts.Seconds;
        }

        public static int ConvertToInt(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? 0 : int.Parse(str);
            }
            catch (Exception e)
            {

                throw new Exception("ConvertToInt的参数" + str + "转换int异常，详情：" + e.Message);
            }

        }

        public static decimal ConvertToDecimal(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? 0 : decimal.Parse(str);
            }
            catch (Exception e)
            {

                throw new Exception("ConvertToDecimal的参数" + str + "转换decimal异常，详情：" + e.Message);
            }

        }

        public static double ConvertToDouble(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? 0 : double.Parse(str);
            }
            catch (Exception e)
            {

                throw new Exception("ConvertToDouble的参数" + str + "转换double异常，详情：" + e.Message);
            }
        }

        public static DateTime ConvertToDateTime(string str)
        {
            try
            {
                return string.IsNullOrEmpty(str) ? Convert.ToDateTime(null) : DateTime.Parse(str);
            }
            catch (Exception e)
            {

                throw new Exception("ConvertToDateTime的参数" + str + "转换double异常，详情：" + e.Message);
            }
        }

        public static string ConvertDateTimeToString(DateTime dt)
        {
            try
            {
                return dt.Equals(null) ? "" : dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception e)
            {

                throw new Exception("ConvertDateTimeToString的参数" + dt + "转换DateTime异常，详情：" + e.Message);
            }
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="str">传入的字符串</param>
        /// <param name="len">取长度</param>
        /// <returns></returns>
        public static string CutString(string str, int len)
        {
            string result = str;
            if (!string.IsNullOrEmpty(str))
            {
                int _len = 0;//中文算两个的字符串长度
                int _clen = 0; //中文个数
                foreach (char c in str)
                {
                    _len++;
                    if (System.Convert.ToInt32(c) > 255) //判断汉字
                    {
                        _len++; //中文多加1
                        _clen++;//中文个数++
                    }

                    if (_len >= len)
                    {
                        result = str.Substring(0, _len - _clen - (_len - len));//这句比较拗口,见下面的解释吧。
                        break;
                    }
                }
            }
            return result;
        }

        public static Dictionary<string, object> JsonToDictionary(string jsonString)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Deserialize<Dictionary<string, object>>(jsonString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string DictionaryToJson(Dictionary<string, object> dic)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(dic);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static string ObjectToJson(object o)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                return jss.Serialize(o);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static object JsonToObject(string json, object obj)
        {
            try
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                MemoryStream mStream = new MemoryStream(Encoding.UTF8.GetBytes(json));
                return serializer.ReadObject(mStream);
            }
            catch (Exception e)
            {
                throw new Exception("JsonToObject转换json时异常");
            }


        }

        public static T ConvertJsonToObj<T>(string jsonStr)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                return jss.Deserialize<T>(jsonStr);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal Round(decimal v, int x)
        {
            bool isNegative = false;
            //如果是负数
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }

            int IValue = 1;
            for (int i = 1; i <= x; i++)
            {
                IValue = IValue * 10;
            }
            decimal Int = Math.Floor(v * IValue);

            //if (Int % 2 == 0)
            //{
            decimal d = v;
            if ((v - Int / IValue) >= (decimal)0.5 / IValue) { d = v + (decimal)(0.1 / IValue); } else { d = v; }
            v = Math.Round(d, x);
            //}
            //else
            //{
            //    v = Math.Round(v, x);
            //}

            if (isNegative)
            {
                v = -v;
            }

            return v;
        }

        public static string ObjectEquel<T>(T oldVO, T newVO)
        {
            try
            {
                string result = "";
                Type type1 = oldVO.GetType();
                Type type2 = newVO.GetType();

                System.Reflection.PropertyInfo[] properties1 = type1.GetProperties();
                System.Reflection.PropertyInfo[] properties2 = type2.GetProperties();

                for (int i = 0; i < properties1.Length; i++)
                {
                    string name = properties1[i].Name;
                    string obj1value = properties1[i].GetValue(oldVO, null) == null ? "" : properties1[i].GetValue(oldVO, null).ToString();
                    string obj2value = properties2[i].GetValue(newVO, null) == null ? "" : properties2[i].GetValue(newVO, null).ToString();

                    if (obj1value == obj2value) continue;

                    if (properties1[i].PropertyType.Name == typeof(int).Name)
                    {
                        if (int.Parse(obj1value) == int.Parse(obj2value)) continue;
                    }
                    if (properties1[i].PropertyType.Name == typeof(decimal).Name)
                    {
                        if (decimal.Parse(obj1value) == decimal.Parse(obj2value)) continue;
                    }
                    if (obj1value != obj2value)
                    {
                        result += string.Format("修改字段{0}原值：{1}修改后：{2}", name, obj1value, obj2value);
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        /// <summary>
        /// 解密并验证派车单编号二维码（加密后）
        /// </summary>
        /// <param name="qrCode"></param>
        public static string VerifyQRCode(string qrCode)
        {
            try
            {
                var decrypyStr = Tools.GetDecryptStr(qrCode);
                if (!decrypyStr.Contains("@"))
                    throw new Exception("此二维码解析异常，请刷新二维码重新操作。");
                var dispatchCode = decrypyStr.Replace("@", "|").Split('|')[0];
                var validDt = decrypyStr.Replace("@", "|").Split('|')[1];
                if (DateTime.Parse(validDt).Subtract(DateTime.Now).TotalMilliseconds < 0)
                    throw new Exception("此二维码已过期，请刷新二维码重新操作。");
                return dispatchCode;
            }
            catch (Exception e)
            {
                throw new Exception("二维码验证发生异常，" + e.Message);
            }
        }
        /// <summary>
        /// 截去字符串中的数字
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static string FetchType(string Code)
        {
            return Regex.Replace(Code, "[0-9]", "", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 计算密码强度
        /// </summary>
        /// <param name="password">密码字符串</param>
        /// <returns></returns>
        public static Strength PasswordStrength(string password)
        {
            //空字符串强度值为0
            if (password == "") return Strength.Invalid;
            //字符统计
            int iNum = 0, iLtt = 0, iSym = 0;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9') iNum++;
                else if (c >= 'a' && c <= 'z') iLtt++;
                else if (c >= 'A' && c <= 'Z') iLtt++;
                else iSym++;
            }
            if (iLtt == 0 && iSym == 0) return Strength.Weak; //纯数字密码
            if (iNum == 0 && iLtt == 0) return Strength.Weak; //纯符号密码
            if (iNum == 0 && iSym == 0) return Strength.Weak; //纯字母密码
            if (password.Length <= 6) return Strength.Weak; //长度不大于6的密码
            if (iLtt == 0) return Strength.Normal; //数字和符号构成的密码
            if (iSym == 0) return Strength.Normal; //数字和字母构成的密码
            if (iNum == 0) return Strength.Normal; //字母和符号构成的密码
            if (password.Length <= 10) return Strength.Normal; //长度不大于10的密码
            return Strength.Strong; //由数字、字母、符号构成的密码
        }
    }
    /// <summary>
    /// 密码强度
    /// </summary>
    public enum Strength
    {
        Invalid = 0, //无效密码
        Weak = 1, //低强度密码
        Normal = 2, //中强度密码
        Strong = 3 //高强度密码
    };
}
