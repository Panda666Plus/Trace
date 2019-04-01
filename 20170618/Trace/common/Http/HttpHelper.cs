using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Trace.common;

namespace Trace
{
    class HttpHelper
    {

        private static string ContentType = "application/x-www-form-urlencoded";

        private static string ContentTypeJson = "application/json";

        public static string post(string url, Dictionary<string, Object> param)
        {
            string json = JsonConvert.SerializeObject(param);
            Console.Write("Http Request : " + json);
            return postWebRequest(url, json, ContentType, Encoding.UTF8);
        }

        public static string postJson(string url, Dictionary<string, Object> param)
        {
            string json = JsonConvert.SerializeObject(param);
            Console.Write("Http Request : " + json);
            return postWebRequest(url, json, ContentTypeJson, Encoding.UTF8);
        }

        public static string postReqeust(string url, Dictionary<string, Object> param)
        {
            head heads = new head
            {
                channelCode = "010200000000010000000001",
                userIp = "172.16.4.8",
                reqTime = "20170101120000111",
                ticket = "WT2017010112000011100000000",
                token = "abeadedf-dcd8-4f22-a035-569168006ec1"
            };
            var reqModel = new RequestBody { head = heads, body = param };
            var pro = "requestBody=" + JsonConvert.SerializeObject(reqModel);
            Console.Write("Http Request = " + pro);
            return postReqeust(url, pro);
        }

        //数据查询时使用
        public static string postQueryJson(string url, JObject obj)
        {
            head heads = new head
            {
                channelCode = "010200000000010000000001",
                userIp = "172.16.4.8",
                reqTime = "20170101120000111",
                ticket = "WT2017010112000011100000000",
                token = "abeadedf-dcd8-4f22-a035-569168006ec1"
            };
            var reqModel = new QueryRequestBody { head = heads, body = obj.ToString() };
            return postReqeust(url, JsonConvert.SerializeObject(reqModel), ContentTypeJson);
        }



        //数据上传时使用
        public static string postReqeustJson(string url, Dictionary<string, Object> param)
        {
            head heads = new head
            {
                channelCode = "010200000000010000000001",
                userIp = "172.16.4.8",
                reqTime = "20170101120000111",
                ticket = "WT2017010112000011100000000",
                token = "abeadedf-dcd8-4f22-a035-569168006ec1"
            };
            //封装成数组格式
            List<dynamic> bodys = new List<dynamic>();
            bodys.Add(param);

            var reqModel = new AsynRequestBody { head = heads, body = bodys };
            //var pro = "requestBody=" + JsonConvert.SerializeObject(reqModel);
            //Console.Write("Http Request = " + pro);
            return postReqeust(url, JsonConvert.SerializeObject(reqModel), ContentTypeJson);
        }

        public static string postReqeust(string url, string param)
        {
            return postWebRequest(url, param, ContentType, Encoding.UTF8);
        }

        //数据上传时使用
        public static string postReqeust(string url, string param, string contentType)
        {
            return postWebRequest(url, param, contentType, Encoding.UTF8);
        }

        public static string postWebRequest(string postUrl, string paramData, string contentType, Encoding dataEncode)
        {
            string ret = string.Empty;
            try
            {
                byte[] byteArray = dataEncode.GetBytes(paramData);
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(new Uri(postUrl));
                webReq.Method = "POST";
                webReq.ContentType = contentType;
                webReq.ContentLength = byteArray.Length;
                Stream newStream = webReq.GetRequestStream();
                newStream.Write(byteArray, 0, byteArray.Length);//写入参数
                newStream.Close();
                HttpWebResponse response = (HttpWebResponse)webReq.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                ret = sr.ReadToEnd();
                sr.Close();
                response.Close();
                newStream.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return ret;
        }

        internal static string PostWebRequest(string url, IDictionary<string, string> parameter, Encoding uTF8)
        {
            throw new NotImplementedException();
        }
    }
}

