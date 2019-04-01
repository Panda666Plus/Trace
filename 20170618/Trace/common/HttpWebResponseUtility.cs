using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;



namespace Goku.Utils
{
    class HttpWebResponseUtility
    {



        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, Encoding charset)
        {

            HttpWebRequest request = null;
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Proxy = null;
            //request.ContentType = "text/xml";
            //request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            //如果需要POST数据
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, Uri.EscapeDataString(parameters[key]));
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, Uri.EscapeDataString(parameters[key]));
                    }
                    i++;
                }
                ///byte[] data = charset.GetBytes(parameters["requestBody"]);
                Console.WriteLine("ccanshuwei :" + buffer.ToString());
                byte[] data = charset.GetBytes(buffer.ToString());//将参数转换为byte
                request.ContentLength = data.Length;

                try
                {
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine("错误:" + e.Message);
                    return null;
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }

        //public static string Post(string url, IDictionary<string, string> parameters, Encoding charset)
        //{
        //    try
        //    {
        //        //// HttpWebResponse httpWebResponse = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters, charset);
        //        //HttpWebResponse httpWebResponse = HttpWebResponseUtility.CreatePostHttpResponse(url,parameters,charset);
        //        //Stream stream = httpWebResponse.GetResponseStream();
        //        //StreamReader strReader = new StreamReader(stream, Encoding.UTF8);

        //        //return strReader.ReadToEnd();
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        }
    }
//}



