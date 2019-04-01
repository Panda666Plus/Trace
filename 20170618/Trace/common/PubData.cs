using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.Common
{
    class PubData
    {

        // 施药
        public static string PRODUCT_ACTION_TYPE_P01 = "P01";

        // 施肥
        public static string PRODUCT_ACTION_TYPE_P02 = "P02";

        // 认证
        public static string PRODUCT_ACTION_TYPE_P03 = "P03";

        //数据上传路径
        public static string DATA_UPLOAD_URL = "http://59.173.8.184:27003/api/prodcution/synchroDb";

        //二维码查看
        public static string QR_CODE_URL = "http://59.173.8.184:20081/trace/wap/qrcode/toListArchives";

        //用户登录id
        public static string USER_ID_FIRST = "50";
    }
}
