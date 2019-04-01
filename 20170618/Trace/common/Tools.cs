using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.common
{
    class Tools
    {
        //遍历dynamic
        public static dynamic getDynamicVal(dynamic obj, string key)
        {
            foreach (dynamic item in obj)
            {
                if (!item.key != null)
                {
                    string _k = item.key;
                    if (_k.Equals(key))
                        return item.Value;
                }

            }
            return "";
        }

        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt32(ts.TotalSeconds).ToString();
        }

        public static string UrlEncode(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = System.Text.Encoding.UTF8.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
            for (int i = 0; i < byStr.Length; i++)
            {
                sb.Append(@"%" + Convert.ToString(byStr[i], 16));
            }

            return (sb.ToString());
        }

        //生成二维码规则
        public static string getQrcodeRule(string enterCode, string produceCode)
        {
            StringBuilder str = new StringBuilder();
            //厂商识别码
            str.Append(enterCode);//.Append("-");
            //物品代码(白菜111111，茄子222222，黄瓜333333)
            str.Append(produceCode);//.Append("-");
            //年月日+4位随机
            System.Random Random = new System.Random();
            string ymd = DateTime.Now.ToString("yyMMdd");
            string rd = Random.Next(0, 9999).ToString();

            str.Append(ymd).Append(rd);

            return str.ToString();
        }


    }
}
