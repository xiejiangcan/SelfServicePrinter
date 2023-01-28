using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YUTU.UIL.Main;

namespace YUTU
{
    public static class ProgramException
    {
        /// <summary>
        /// 异常处理方法
        /// </summary>
        public static void ExceptionControl()
        {
            //设置应用程序处理异常方式：ThreadException处理  
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常  
            Application.ThreadException += (sender, e) =>
            {
                var str = GetExceptionMsg(e.Exception, e.ToString());
                //var messageForm = new FrmExceptoin();
                //messageForm.SetMessage(str);
                //messageForm.ShowDialog();
            };
            //处理非UI线程异常  
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                var str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
                //var messageForm = new FrmExceptoin();
                //messageForm.SetMessage(str);
                //messageForm.ShowDialog();
            };

        }
        /// <summary>  
        /// 生成自定义异常消息  
        /// </summary>  
        /// <param name="ex">异常对象</param>  
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>  
        /// <returns>异常字符串文本</returns>  
        private static string GetExceptionMsg(Exception ex, string backStr)
        {
            var sb = new StringBuilder();
            if (ex == null)
            {
                sb.AppendLine("【异常信息】：" + backStr);
            }
            else
            {
                if (ex.GetType().Name.ToLower() == "exception")
                {
                    return ex.Message;
                }
                sb.AppendLine("【异常时间】：" + DateTime.Now);
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【StackTrace】：" + ex.StackTrace);
            }
            return sb.ToString();
        }
    }
}
