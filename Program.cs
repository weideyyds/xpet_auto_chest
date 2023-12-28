using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace xpet_openChest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLog($"XPET每日自动过任务工具 V:1.0 编译日期：2023年12月28日");
            WriteLog($"=====================================================");
            WriteLog($"Code BY;  https://x.com/weideyyds       WeChat:weidegod");
            WriteLog($"======================================================");
            while (true)
            {
                Console.WriteLine($"{DateTime.Now.ToString()} 开始新一轮任务");
                var tweet_ids = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "\\ids.txt");
                foreach (var tweet_id in tweet_ids)
                {
                    var Authorization = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Authorization.txt");
                    var url = $"https://api.xpet.tech/openChest?tweet_id={tweet_id}&type=random";

                    var ret = SendDataByGET(url, "", Authorization);
                    if (!string.IsNullOrEmpty(ret))
                    {
                        WriteLog($"完成任务成功,获取的奖励如下：{ret}");
                    }
                    


                    Thread.Sleep(1000 * 10);
                }

                Thread.Sleep(1000 * 60 * 60);
            }
          
           

        }

        public static string SendDataByGET(string Url, string postDataStr, string Authorization)
        {
            string retString = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Headers.Add("Authorization", Authorization);
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/119.0.0.0 Safari/537.36";
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

            }
            catch (WebException ex)
            {

                HttpWebResponse response = (HttpWebResponse)ex.Response;
                if (response != null)
                {
                    WriteLog($"服务器返回错误，错误代码{response.StatusCode}");
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        WriteLog($"错误内容：{reader.ReadToEnd()}");
                    }
                }
            }


            return retString;
        }

        public static void WriteLog(string logStr)
        {
            Console.WriteLine(logStr);
            var dirPath = AppDomain.CurrentDomain.BaseDirectory + "\\log\\";
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            var filePath = dirPath + DateTime.Today.ToString("yyyy-MM-dd") + ".log";

            File.AppendAllLines(filePath, new string[] { DateTime.Now.ToString() + "        " + logStr });

        }
    }
}
