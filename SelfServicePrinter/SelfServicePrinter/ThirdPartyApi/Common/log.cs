using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi.Common
{
    public class log
    {
        /// <summary>
        /// 日志文件大小
        /// </summary>
        private int fileSize;

        /// <summary>
        /// 日志文件的路径
        /// </summary>
        private string fileLogPath;

        /// <summary>
        /// 日志文件的名称
        /// </summary>
        private string logFileName;

        public log()
        {
            //初始化大于2M日志文件将自动删除;
            this.fileSize = 2048 * 1024;//2M

            //默认路径
            this.fileLogPath = @"d:\logFils\";
            this.logFileName = "日志.txt";
        }
        public log(string filePath)
        {
            //初始化大于2M日志文件将自动删除;
            this.fileSize = 2048 * 1024;//2M

            //默认路径
            this.fileLogPath = filePath + "\\";
            this.logFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";

            if (DateTime.Now.Hour >= 0 && DateTime.Now.Hour <= 6)
            {
                this.logFileName = DateTime.Now.ToString("yyyyMMdd") + "_1.txt";
            }
            if (DateTime.Now.Hour > 6 && DateTime.Now.Hour <= 12)
            {
                this.logFileName = DateTime.Now.ToString("yyyyMMdd") + "_2.txt";
            }
            if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 18)
            {
                this.logFileName = DateTime.Now.ToString("yyyyMMdd") + "_3.txt";
            }
            if (DateTime.Now.Hour > 18 && DateTime.Now.Hour <= 24)
            {
                this.logFileName = DateTime.Now.ToString("yyyyMMdd") + "_4.txt";
            }
        }
        public log(string filePath, string fileName)
        {
            //初始化大于2M日志文件将自动删除;
            this.fileSize = 2048 * 1024;//2M

            //默认路径
            this.fileLogPath = filePath + "\\";
            this.logFileName = fileName;
        }

        /// <summary>
        /// 获取或设置定义日志文件大小
        /// </summary>
        public int FileSize
        {
            set
            {
                fileSize = value;
            }
            get
            {
                return fileSize;
            }
        }

        /// <summary>
        /// 获取或设置日志文件的路径
        /// </summary>
        public string FileLogPath
        {
            set
            {
                this.fileLogPath = value;
            }
            get
            {
                return this.fileLogPath;
            }
        }

        /// <summary>
        /// 获取或设置日志文件的名称
        /// </summary>
        public string LogFileName
        {
            set
            {
                this.logFileName = value;
            }
            get
            {
                return this.logFileName;
            }

        }

        /// <summary>
        /// 向指定目录中的指定的文件中追加日志文件
        /// </summary>
        /// <param name="Message">要写入的内容</param>
        public void WriteLog(string Message)
        {
            this.WriteLog(this.logFileName, Message);
        }

        /// <summary>
        /// 向指定目录中的文件中追加日志文件,日志文件的名称将由传递的参数决定.
        /// </summary>
        /// <param name="LogFileName">日志文件的名称,如:mylog.txt ,如果没有自动创建,如果存在将追加写入日志</param>
        /// <param name="Message">要写入的内容</param>
        public void WriteLog(string LogFileName, string Message)
        {
            //如果日志文件目录不存在,则创建
            if (!Directory.Exists(this.fileLogPath))
            {
                Directory.CreateDirectory(this.fileLogPath);
            }

            FileInfo finfo = new FileInfo(this.fileLogPath + LogFileName);
            if (finfo.Exists && finfo.Length > fileSize)
            {
                finfo.Delete();
            }

            try
            {
                FileStream fs = new FileStream(this.fileLogPath + LogFileName, FileMode.Append);
                StreamWriter strwriter = new StreamWriter(fs);
                try
                {
                    DateTime d = DateTime.Now;
                    strwriter.WriteLine("时间:" + d.ToString("yyyy-MM-dd HH:mm:ss:fff"));
                    strwriter.WriteLine(Message);
                    strwriter.WriteLine();
                    strwriter.Flush();
                }
                catch (Exception ee)
                {
                    Console.WriteLine("日志文件写入失败信息:" + ee.ToString());
                }
                finally
                {
                    strwriter.Close();
                    strwriter = null;
                    fs.Close();
                    fs = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("日志文件没有打开,详细信息如下:" + ex.Message);
            }
        }
    }
}
