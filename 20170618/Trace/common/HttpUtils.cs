using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;
using System.IO;

namespace Goku.Utils
{
    class HttpUtils
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="API_NAME">传递的参数</param>
        /// <param name="RequestMethon">请求类型 GET/POST</param>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string GetHttpWebRequest(string API_NAME, string RequestMethon, string url)
        {
       
            HttpWebRequest request;
            Stream strem;
            //创建一个请求
            request = (HttpWebRequest)WebRequest.Create(url);
            //使用那种方式    
            request.Method = RequestMethon;
            //编码方式
            //request.ContentType = "application/x-www-form-urlencoded"; //一般http请求
            request.ContentType = "text/xml";  //xml请求方式
            //获取字符串的字节流
            if (API_NAME != "")
            {
                byte[] bytes = Encoding.ASCII.GetBytes(API_NAME);

                try
                {
                    using (strem = request.GetRequestStream())  //获取到请求流
                    {
                        //进行数据的写入
                        strem.Write(bytes, 0, bytes.Length);
                    }
                }
                catch (Exception e)
                {
                 
                    return "请求错误:" + e.Message;
                }
            }


            try
            {
                //获取响应的数据

                using (Stream response = request.GetResponse().GetResponseStream()) //获取响应流
                {
                    StreamReader strReader = new StreamReader(response, Encoding.UTF8);

                    return strReader.ReadToEnd();

                }

            }
            catch (Exception e)
            {
               
                return "网络连接中断...." + e.Message;
            }


        }




    }
}
