using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;

namespace Trace.com.doone.trace.dao
{
/*
     Author: wushenghu
     Time: June 21, 2017
     E-mail: sheng-hu.wu @doone.com.cn
*/
    class ProductDao
    {
        #region 新增图片
        public bool daoAddProduct(DynamicParameters d)
        {
            StringBuilder ImageSql = new StringBuilder();
            ImageSql.Append("insert into tf_enterprise_product_life");
            ImageSql.Append("(PRODUCT_LIFE_ID,CORP_PRODUCT_ID,IMAGE_NAME,REAL_PATH,PATH,");
            ImageSql.Append("IMAGE_SIZE,IMAGE_BLOB,ORDER_SEQ,STATUS,CREATE_DATE,");
            ImageSql.Append("CREATE_STAFF_ID,REMARK,UPLOAD_STATE,UPLOAD_DATE )");
            ImageSql.Append("  VALUES (12,13,cucumber,Images,");           
            ImageSql.Append("Images,'76.0kb',90, 'uu','yy',");
            ImageSql.Append("2017 - 09 - 07','12'，'备注', '09-07', '2017-09-07')");

            var conn = DbHelper.openConn();
            try
            {
                var id = conn.Query<int>(ImageSql.ToString(), d).FirstOrDefault();

            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }

            return true;
        }
        #endregion
    }
}