
using DotNet4.Utilities;
using Goku.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Trace.Common;

namespace Trace.com.doone.trace.service
{
    class LoginService
    {
        public static string _STURLInterface = "http://59.173.8.184:27003";
        public static string _STURL = "http://59.173.8.184:27001";
        public JObject login(string account, string password)
        {
            JObject jobject = new JObject();
            Dictionary<string, Object> map = new Dictionary<string, object>();
            map.Add("account", account);
            map.Add("password", password);
            string resultJson = HttpHelper.postJson(Urls.LOGIN_URL, map);
            Console.Write("登录验证返回结果：" + resultJson);
            JObject json = (JObject)Json_Check(resultJson);
            jobject["login"] = json;
            return jobject;
        }

        public JObject oldLogin(string account, string password)
        {
            //调登陆接口
            JObject j1 = new JObject();
            string post = "{\"account\":\"" + account + "\",\"password\":\"" + password + "\"}";


            DotNet4.Utilities.HttpHelper hh = new DotNet4.Utilities.HttpHelper();
            HttpItem hi = new HttpItem()
            {
                URL = LoginService._STURLInterface + "/api/login/loginPost",
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko",
                Accept = "application/json",
                Method = "POST",
                ContentType = "application/json",
                Postdata = post,
                Referer = "http://59.173.8.184:27001/login",
                KeepAlive = true,
            };
            hi.Header.Add("Accept-Encoding", "gzip,deflate");
            hi.Header.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");

            HttpResult hr = hh.GetHtml(hi);

            JObject json = (JObject)Json_Check(hr.Html);

            if (json != null && json["head"]["respCode"] != null && json["head"]["respCode"].ToString() == "0")
            {
                string userandpwd = EncryptDES(account + "----" + password + "----" + null, "ab123456");
                string strpath = System.Environment.CurrentDirectory;
                StreamWriter sw = new StreamWriter(strpath + "\\" + "account.txt", false, Encoding.UTF8);

                sw.WriteLine(userandpwd);
                sw.Close();

                j1["login"] = json;

                //企业接口
                //string url = FactoryRecord121._STURLInterface + "/api/prodcution/qryQualityRegister";
                var reqModel = new Jobject()
                {
                    head = new head
                    {
                        channelCode = "010200000000010000000001",
                        userIp = "172.16.4.1",
                        reqTime = "20170101120000111",
                        ticket = "WT2017010112000011100000000",
                        token = "abeadedf-dcd8-4f22-a035-569168006ec1"

                    },
                    body = new body
                    {
                        status = "",
                        area = "",
                        page = "",
                        pageSize = ""

                    }
                };

                JObject jsonpost = new JObject();
                JObject jsonheader = new JObject();
                JObject jsonbody = new JObject();
                jsonheader["channelCode"] = "010200000000010000000001";
                jsonheader["userIp"] = "172.16.4.1";
                jsonheader["reqTime"] = "20170101120000111";
                jsonheader["ticket"] = "WT2017010112000011100000000";
                jsonheader["token"] = "abeadedf-dcd8-4f22-a035-569168006ec1";
                jsonbody["enterprise"] = null;
                jsonbody["status"] = "";
                jsonbody["area"] = "";
                jsonbody["page"] = "";
                jsonbody["pageSize"] = "";
                jsonpost["head"] = jsonheader;
                jsonpost["body"] = jsonbody;
                string post2 = "requestBody=" + JsonConvert.SerializeObject(jsonpost).ToString();
                //post2 = "requestBody={\"head\":{\"channelCode\":\"010200000000010000000001\",\"userIp\":\"172.16.4.1\",\"reqTime\":\"20170101120000111\",\"ticket\":\"WT2017010112000011100000000\",\"token\":\"abeadedf-dcd8-4f22-a035-569168006ec1\"},\"body\":{\"enterprise\":null,\"status\":\"\",\"area\":\"\",\"page\":\"\",\"pageSize\":\"\"}}";

                //var pro = "requestBody=" + JsonConvert.SerializeObject(reqModel);
                hi = new HttpItem()
                {
                    URL = LoginService._STURLInterface + "/api/prodcution/qryQualityRegister",
                    UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko",
                    Accept = "application/json",
                    Method = "POST",
                    ContentType = "application/x-www-form-urlencoded",
                    PostDataType = PostDataType.Byte,
                    PostdataByte = Encoding.Default.GetBytes(post2),
                    Referer = "http://59.173.8.184:27001/login",
                    KeepAlive = true,
                };
                hi.Header.Add("Accept-Encoding", "gzip,deflate");
                hi.Header.Add("Accept-Language", "zh-Hans-CN,zh-Hans;q=0.5");
                hr = hh.GetHtml(hi);
                json = (JObject)Json_Check(hr.Html);
                j1["en"] = json;
            }
            return j1;
        }

        private static object Json_Check(string s)
        {
            try
            {
                string a = Regex.Match(s, @"\((?<json>.+?)\)").Groups["json"].Value;
                if (a == string.Empty)
                {
                    return JsonConvert.DeserializeObject(s.TrimStart(new char[] { '(' }).TrimEnd(new char[] { ')' }).Trim());
                }
                else
                {
                    return JsonConvert.DeserializeObject(a);
                }
            }
            catch
            {
                return null;
            }

        }

        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /**/
        /**/
        /**/
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /**/
        /**/
        /**/
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

    }
}
