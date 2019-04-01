using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.Common
{
    class Urls
    {
        public static string SERVER_URL = "http://59.173.8.184:27003";
        //public static string SERVER_URL = "http://127.0.0.1:7003";

        // 登录
        public static string LOGIN_URL = SERVER_URL + "/api/login/loginPost";

        // 产品档案查询
        public static string QUERY_PRODUCT_LIST_URL = SERVER_URL + "/api/prodcution/rmt_Query_Product_List";

        //产品批次查询
        public static string QUERY_BATCH_LIST_URL = SERVER_URL + "/api/prodcution/rmt_Query_Batch_List";

        //农残检测记录
        public static string QUERY_PEST_CK_RECORD = SERVER_URL + "/api/prodcution/rmt_Query_Pest_Ck_Record";

        //查询施肥记录
        public static string QUERY_FERT_RECORD = SERVER_URL + "/api/prodcution/rmt_Query_Fert_Record";

        //查询施药记录
        public static string QUERY_PEST_RECORD = SERVER_URL + "/api/prodcution/rmt_Query_Pest_Record";
    }
}
