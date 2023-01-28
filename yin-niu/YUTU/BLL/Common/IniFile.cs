using System;
using System.Runtime.InteropServices;
using System.Text;

namespace YUTU.BLL.Common
{
    public class IniFile
    {

        #region 声明读写INI文件的API函数

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, Byte[] retVal, int size, string filePath);

        #endregion
        
        /// <summary>
        /// 写Ini文件
        /// </summary>
        /// <param name="section">段</param>
        /// <param name="key">键</param>
        /// <param name="iValue">值</param>
        /// <param name="filePath">文件路径</param>
        public static void IniWriteValue(string section, string key, string iValue, string filePath)
        {
            WritePrivateProfileString(section, key, iValue, filePath);
        }

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段落</param>
        /// <param name="key">键</param>
        /// <param name="filePath">路径</param>
        /// <returns>返回键值</returns>
        public static string IniReadValue(string section, string key, string filePath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(section, key, "", temp, 255, filePath);
            return temp.ToString();
        }
        
        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">段，格式[]</param>
        /// <param name="key">键</param>
        /// <param name="filePath">路径</param>
        /// <returns>返回byte类型的section组或键值组</returns>
        public static byte[] IniReadValuesB(string section,string key, string filePath)
        {
            byte[] temp = new byte[255];
            int i = GetPrivateProfileString(section, key, "", temp, 255, filePath);
            return temp;
        }

    }
}
