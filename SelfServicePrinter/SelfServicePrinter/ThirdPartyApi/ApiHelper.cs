using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SelfServicePrinter.ThirdPartyApi
{
    public class ApiHelper
    {
        // Post请求
        public CallBackInfo PostResponse(string url, string jsonData)
        {
            // 获得回复  
            string result = string.Empty;
            try
            {
                byte[] data = new ASCIIEncoding().GetBytes(jsonData);
                // 发送请求  
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                //request.Headers.Add("Accept-Encoding", "gzip,deflate");
                request.ContentLength = data.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                    {
                        result = reader.ReadToEnd();
                    }
                }
                return JsonConvert.DeserializeObject<CallBackInfo>(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class CallBackInfo
    {
        public string code { get; set; }
        public string msg { get; set; }
    }
}
