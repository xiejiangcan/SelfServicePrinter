using System.Collections.Generic;

using Newtonsoft.Json;
using System.Configuration;
using System.Windows.Forms;
using YUTU.BLL.Common;
using System;
using YUTU.BLL.Global;


namespace YUTU.ThirdPartyApi
{
    public class ApiYnHelper
    {
        private static string baseurl = ConfigurationManager.AppSettings["ThirdPartyBaseUrl"];
        private static ApiHelper helper = new ApiHelper();


        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public static bool LogOn(string userName,string userPass)
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Login/checkLogin";

                Dictionary<string, string> dics = new Dictionary<string, string>();
                dics.Add("uname", userName);
                dics.Add("upass", userPass);


                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"LogOn接口接收数据---{jsonData}。");
                string result = HttpHelper.Post(url, jsonData);
                LogMessage($"LogOn接口返回数据---{result}。");
                ResultLogOn dicRes = Tools.ConvertJsonToObj<ResultLogOn>(result);
                if (dicRes != null)
                {
                    LocalConfig.AccessToken = dicRes.data.token;
                    Login.UserName= dicRes.data.user.nickname;
                    Login.UserCode = dicRes.data.user.id.ToString();
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"LogOn接口调用异常，{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public static bool LogOut(string uid, string upass)
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Login/logout";

                Dictionary<string, string> dics = new Dictionary<string, string>();
                dics.Add("uid", uid);
                dics.Add("upass", upass);


                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"LogOut接口接收数据---{jsonData}。");
                string result = HttpHelper.Post(url, jsonData);
                LogMessage($"LogOut接口返回数据---{result}。");
                ResultLogOut dicRes = Tools.ConvertJsonToObj<ResultLogOut>(result);
                if (dicRes.code == "1")
                {
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                LogMessage($"LogOut接口调用异常，{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 获取公告列表
        /// </summary>
        /// <returns></returns>
        public static bool GetNoticeList(int page, int limit, out string title,out int id)
        {
            title = "";
            id = 0;
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getNoticeList";

                Dictionary<string, int> dics = new Dictionary<string, int>();
                dics.Add("page", page);
                dics.Add("limit", limit);


                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetNoticeList接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetNoticeList接口返回数据---{result}。");
                RootNotice dicRes = Tools.ConvertJsonToObj<RootNotice>(result);
                if (dicRes != null)
                {
                    title = dicRes.data.data[0].title;
                    id= dicRes.data.data[0].id; 
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetNoticeList接口调用异常，{ex.Message}");
                return false;
            }
        }

        public static bool GetNoticeList(int page, int limit, out List<DataNotice> dataNotices)
        {
            dataNotices = null;

            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getNoticeList";

                Dictionary<string, int> dics = new Dictionary<string, int>();
                dics.Add("page", page);
                dics.Add("limit", limit);


                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetNoticeList接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetNoticeList接口返回数据---{result}。");
                RootNotice dicRes = Tools.ConvertJsonToObj<RootNotice>(result);
                if (dicRes != null)
                {
                    dataNotices = dicRes.data.data;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetNoticeList接口调用异常，{ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// 获取公告详情
        /// </summary>
        /// <returns></returns>
        public static bool GetNoticeDetail(int id,out NoticeDetailData noticeDetailData)
        {
            noticeDetailData = null;
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getNoticeDetail";

                Dictionary<string, int> dics = new Dictionary<string, int>();
                dics.Add("id", id);

                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetNoticeDetail接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetNoticeDetail接口返回数据---{result}。");
                NoticeDetailRoot dicRes = Tools.ConvertJsonToObj<NoticeDetailRoot>(result);
                if (dicRes != null)
                {
                    noticeDetailData = dicRes.data;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetNoticeDetail接口调用异常，{ex.Message}");
                return false;
            }
        }




        /// <summary>
        /// 获取设备列表
        /// </summary>
        /// <returns></returns>
        public static bool GetComputerList()
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getComputerList";

                Dictionary<string, int> dics = new Dictionary<string, int>();
                //dics.Add("id", id);

                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetComputerList接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetComputerList接口返回数据---{result}。");
                RootComputer dicRes = Tools.ConvertJsonToObj<RootComputer>(result);
                if (dicRes != null)
                {

                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetComputerList接口调用异常，{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 获取打印配置
        /// </summary>
        /// <returns></returns>
        public static bool GetPrinterConfig()
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getPrinterConfig";

                Dictionary<string, int> dics = new Dictionary<string, int>();
                //dics.Add("id", id);

                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetPrinterConfig接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetPrinterConfig接口返回数据---{result}。");
                RootPrinter dicRes = Tools.ConvertJsonToObj<RootPrinter>(result);
                if (dicRes != null)
                {

                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetPrinterConfig接口调用异常，{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 获取当前店铺二维码
        /// </summary>
        /// <returns></returns>
        public static bool GetShopQrcode(out string imgUrl)
        {
            imgUrl = "";
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getShopQrcode";

                Dictionary<string, int> dics = new Dictionary<string, int>();
                //dics.Add("id", id);

                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetShopQrcode接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetShopQrcode接口返回数据---{result}。");
                RootShopQrcode dicRes = Tools.ConvertJsonToObj<RootShopQrcode>(result);
                if (dicRes != null)
                {
                    imgUrl = dicRes.data.url;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetShopQrcode接口调用异常，{ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// 获取远程打印任务
        /// </summary>
        /// <returns></returns>
        public static bool GetPrintTask(int computer_id)
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getPrintTask";

                Dictionary<string, int> dics = new Dictionary<string, int>();
                dics.Add("icomputer_idd", computer_id);

                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetPrintTask接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetPrintTask接口返回数据---{result}。");
                RootPrintTask dicRes = Tools.ConvertJsonToObj<RootPrintTask>(result);
                if (dicRes != null)
                {

                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetPrintTask接口调用异常，{ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns></returns>
        public static bool CreateOrder(int task_id,int total_money,int computer_id,string[] extra)
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/createOrder";

                Dictionary<string, object> dics = new Dictionary<string, object>();
                dics.Add("task_id", task_id);
                dics.Add("total_money", total_money);
                dics.Add("surcharge", computer_id);
                dics.Add("extra", extra);

                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"CreateOrder接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"CreateOrder接口返回数据---{result}。");
                RootOrder dicRes = Tools.ConvertJsonToObj<RootOrder>(result);
                if (dicRes != null)
                {

                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"CreateOrder接口调用异常，{ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns></returns>
        public static bool OpOrder(int type, string orderNo)
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/opOrder";

                Dictionary<string, object> dics = new Dictionary<string, object>();
                dics.Add("type", type);
                dics.Add("orderNo", orderNo);

                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"OpOrder接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"OpOrder接口返回数据---{result}。");
                ResultLogOn dicRes = Tools.ConvertJsonToObj<ResultLogOn>(result);
                if (dicRes != null)
                {

                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"OpOrder接口调用异常，{ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// 获取本地任务订单列表
        /// </summary>
        /// <returns></returns>
        public static bool GetLocalTaskOrder()
        {
            try
            {
                if (baseurl == null || string.IsNullOrEmpty(baseurl.Trim()))
                    return false;

                string url = $"{baseurl}/index/Home/getLocalTaskOrder";

                Dictionary<string, object> dics = new Dictionary<string, object>();


                var jsonData = JsonConvert.SerializeObject(dics);
                LogMessage($"GetLocalTaskOrder接口接收数据---{jsonData}。");
                string result = HttpHelper.HttpPostYinNiu(url, jsonData, LocalConfig.AccessToken);
                LogMessage($"GetLocalTaskOrder接口返回数据---{result}。");
                RootLocalTask dicRes = Tools.ConvertJsonToObj<RootLocalTask>(result);
                if (dicRes != null)
                {

                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"GetLocalTaskOrder接口调用异常，{ex.Message}");
                return false;
            }
        }




        #region 实体
        public class User
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 好大的一个店铺
            /// </summary>
            public string nickname { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public string token { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public User user { get; set; }
        }

        public class ResultLogOn
        {
            /// <summary>
            /// 登录成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string code { get; set; }
        }


        public class ResultLogOut
        {
            /// <summary>
            /// 登录成功
            /// </summary>
            public string msg { get; set; }
            /// 
            /// </summary>
            public string code { get; set; }
        }




        public class DataNotice
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 第一个公告
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DateTime create_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string type { get; set; }
        }

        public class DataNoticeShow
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 第一个公告
            /// </summary>
            public string title { get; set; }
            public string content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DateTime create_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int type { get; set; }
        }

        public class DataNoticeT
        {
            /// <summary>
            /// 
            /// </summary>
            public int total { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DataNotice> data { get; set; }
        }

        public class RootNotice
        {
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataNoticeT data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }



        //如果好用，请收藏地址，帮忙分享。
        public class NoticeDetailData
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 第一个公告
            /// </summary>
            public string title { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string create_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int type { get; set; }
        }

        public class NoticeDetailRoot
        {
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public NoticeDetailData data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }




        public class Pay
        {
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 微信
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string flag { get; set; }
        }

        public class DataComputer
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string basic { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string printer { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string remote { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string pay_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DateTime create_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Pay> pay { get; set; }
        }

        public class DataComputerT
        {
            /// <summary>
            /// 
            /// </summary>
            public int total { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DataComputer> data { get; set; }
        }

        public class RootComputer
        {
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataComputerT data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }




        public class Child
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 黑色
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string price { get; set; }
        }

        public class DataPrinter
        {
            /// <summary>
            /// 颜色
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Child> child { get; set; }
        }

        public class RootPrinter
        {
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DataPrinter> data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }



        public class DataShopQrcode
        {
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
        }

        public class RootShopQrcode
        {
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataShopQrcode data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }



        public class Files
        {
            /// <summary>
            /// 
            /// </summary>
            public string fileName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<int> param { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string print_range { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int num { get; set; }
        }

        public class DataPrintTask
        {
            /// <summary>
            /// 
            /// </summary>
            public int ostatus { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Files> files { get; set; }
        }

        public class RootPrintTask
        {
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DataPrintTask> data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }



        public class Qrcode_url
        {
            /// <summary>
            /// 
            /// </summary>
            public string wx_url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string zfb_url { get; set; }
        }

        public class DataOrder
        {
            /// <summary>
            /// 
            /// </summary>
            public string orderNo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Qrcode_url qrcode_url { get; set; }
        }

        public class RootOrder
        {
            /// <summary>
            /// 操作成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataOrder data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }




        public class Extra
        {
            /// <summary>
            /// 
            /// </summary>
            public string fileName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<int> param { get; set; }
        }

        public class DataLocalTask
        {
            /// <summary>
            /// 
            /// </summary>
            public int id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string orderNo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string total_money { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string surcharge { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<Extra> extra { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DateTime create_time { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int status { get; set; }
        }

        public class DataLocalTaskT
        {
            /// <summary>
            /// 
            /// </summary>
            public int total { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<DataLocalTask> data { get; set; }
        }

        public class RootLocalTask
        {
            /// <summary>
            /// 获取成功
            /// </summary>
            public string msg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public DataLocalTaskT data { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
        }



        #endregion


        #region 日志记录
        static string LogPath = Application.StartupPath + "\\ThirdPartyApiLog";

        static string lastLogMessage = "";

        private static void LogMessage(string message)
        {
            try
            {
                if (lastLogMessage == message) { return; }
                lastLogMessage = message;

                log logUtil = new log(LogPath);
                logUtil.WriteLog(message);
            }
            catch (Exception)
            {
            }
        }
        #endregion

    }
}
