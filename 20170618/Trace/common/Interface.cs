using System.IO;
using System.Net;
using System.Text;

namespace HttpUtilsInterface
{
    public class WebQ
    {
        public CookieContainer Cookie { get; set; } = new CookieContainer();
        public Encoding Encoding { get; set; } = Encoding.UTF8;
        public string UserAgent { get; set; } = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.221 Safari/537.36 SE 2.X MetaSr 1.0";
        public int Timeout { get; set; } = 100000;
        public bool KeepAlive { get; set; } = true;
        public string Referer { get; set; }
        public string Location { get; private set; }

        static WebQ()
        {
            ServicePointManager.DefaultConnectionLimit = 2048;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => { return true; };
        }

        public string UploadData(string url, byte[] bytes, string contentType = "application/x-www-form-urlencoded")
        {
            var web = Create(url);
            if (web == null)
                return null;

            web.Method = "POST";
            web.ContentType = contentType;
            web.ContentLength = bytes.Length;

            try
            {
                using (var reqstream = web.GetRequestStream())
                    reqstream.Write(bytes, 0, bytes.Length);

                return GetResponseText(web);
            }
            catch
            {
                return null;
            }
            finally
            {
                web.Abort();
            }
        }

        public string UploadString(string url, string data, string contentType = "application/x-www-form-urlencoded")
        {
            byte[] bytes = Encoding.GetBytes(data);
            return UploadData(url, bytes, contentType);
        }

        public string DownloadString(string url, string contentType = null)
        {
            var web = Create(url);
            if (web == null)
                return null;
            web.ContentType = contentType;

            try
            {
                return GetResponseText(web);
            }
            catch
            {
                return null;
            }
            finally
            {
                web.Abort();
            }
        }

        public byte[] DownloadData(string url, string contentType = null)
        {
            var web = Create(url);
            if (web == null)
                return null;

            web.ContentType = contentType;
            try
            {
                return GetResponseData(web);
            }
            catch
            {
                return null;
            }
            finally
            {
                web.Abort();
            }
        }

        private HttpWebRequest Create(string url)
        {
            HttpWebRequest web = null;
            try
            {
                web = (HttpWebRequest)WebRequest.Create(url);
            }
            catch
            {
                return null;
            }

            web.Timeout = Timeout;
            web.UserAgent = UserAgent;
            web.CookieContainer = Cookie;
            web.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            web.KeepAlive = KeepAlive;
            web.Referer = Referer;

            return web;
        }

        private string GetResponseText(HttpWebRequest web)
        {
            using (var res = (HttpWebResponse)web.GetResponse())
            using (var sr = new StreamReader(res.GetResponseStream(), Encoding))
            {
                Location = res.Headers["Location"];
                Cookie.Add(res.Cookies);

                return sr.ReadToEnd();
            }
        }

        private byte[] GetResponseData(HttpWebRequest web)
        {
            using (var res = (HttpWebResponse)web.GetResponse())
            using (var rs = res.GetResponseStream())
            {
                Location = res.Headers["Location"];
                Cookie.Add(res.Cookies);

                byte[] buffer = new byte[2048];
                int count = (int)res.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = rs.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                return buf;
            }
        }
    }
}