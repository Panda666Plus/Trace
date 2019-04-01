using Dapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;
using Trace.Common;

namespace Trace.com.doone.trace.dao
{
    class ArchivesDao
    {
        #region 查询所有的数据

        public List<dynamic> queryLocalArchives(string productName, string startDate, string endDate, int pageNo, int pageSize)
        {
            StringBuilder archSql = new StringBuilder();
            archSql.Append("select (select count(1) from tf_production where corp_product_id=a.corp_product_id and status='E') COUNT,");
            archSql.Append("a.corp_product_id,a.product_name,a.product_type,a.image_id,b.file_name,");
            archSql.Append("strftime('%Y-%m-%d', a.plant_date, 'localtime') PLANT_DATE,a.product_source,a.lab01,a.lab02,a.lab03,a.lab04 ");
            archSql.Append("from tf_enterprise_product a left join tf_farm_resource b on a.image_id=b.resource_id where a.status='E' ");

            if (!string.IsNullOrEmpty(productName))
            {
                archSql.AppendFormat(" and a.product_name like '%{0}%' ", productName);
            }

            archSql.AppendFormat("order by a.corp_product_id desc limit {0} offset {1} ", pageSize, (pageNo - 1) * pageSize);
            var conn = DbHelper.openConn();
            List<dynamic> list = new List<dynamic>();
            try
            {
                list = conn.Query<dynamic>(archSql.ToString()).ToList();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }

        public JArray queryArchives(string productName, string startDate, string endDate, int pageNo, int pageSize)
        {
            //调用服务器接口查询产品列表
            //StringBuilder archSql = new StringBuilder();
            //archSql.Append("SELECT (SELECT COUNT(1) FROM TF_PRODUCTION WHERE CORP_PRODUCT_ID=A.CORP_PRODUCT_ID AND STATUS='E') COUNT,");
            //archSql.Append("A.CORP_PRODUCT_ID,A.PRODUCT_NAME,A.PRODUCT_TYPE,A.IMAGE_ID,B.FILE_NAME,");
            //archSql.Append("DATE_FORMAT(A.PLANT_DATE,'%Y-%m-%d') PLANT_DATE,A.PRODUCT_SOURCE,A.LAB01,A.LAB02,A.LAB03,A.LAB04 ");
            //archSql.Append("FROM TF_ENTERPRISE_PRODUCT A LEFT JOIN TF_FARM_RESOURCE B ON A.IMAGE_ID=B.RESOURCE_ID WHERE A.STATUS='E' ");

            //if (!string.IsNullOrEmpty(productName))
            //{
            //    archSql.Append(" AND A.PRODUCT_NAME LIKE '%").Append(productName).Append("%' ");
            //}

            //archSql.AppendFormat("ORDER BY A.CORP_PRODUCT_ID DESC LIMIT ").Append((pageNo - 1) * pageSize).Append(",").Append(pageSize);

            JObject obj = new JObject();
            obj.Add("productName", productName);
            obj.Add("startDate", startDate);
            obj.Add("endDate", endDate);
            obj.Add("pageNo", pageNo);
            obj.Add("pageSize", pageSize);

            var rst = HttpHelper.postQueryJson(Urls.QUERY_PRODUCT_LIST_URL, obj);
            Console.Write(rst);
            JArray jsonObj = JArray.Parse(rst);
            return jsonObj;
        }
        #endregion

        #region 查询总数
        public int queryCount(string productName, string startDate, string endDate)
        {
            StringBuilder countSql = new StringBuilder();
            countSql.Append("select count(1) from tf_enterprise_product a where a.status='E' ");
            if (!string.IsNullOrEmpty(productName))
            {
                countSql.AppendFormat(" and a.product_name like '%{0}%' ", productName);
            }

            var conn = DbHelper.openConn();
            int count = 0;
            try
            {
                //
                count = conn.Query<int>(countSql.ToString()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }

            return count;
        }
        #endregion

        #region 通过id查询记录
        public dynamic queryById(int aid)
        {
            StringBuilder modSql = new StringBuilder();
            modSql.Append("select a.corp_product_id,a.enterprise_id,a.produce_id,b.produce_name,");
            modSql.Append("a.farmland_id,a.product_name,a.product_source,a.product_type,a.product_source,a.plant_date,");
            modSql.Append("a.origin_desc,a.remark from tf_enterprise_product a left join td_farm_produce b ");
            modSql.Append("on a.produce_id = b.produce_id where a.status = 'E' and a.corp_product_id=").Append(aid).Append(";");

            var conn = DbHelper.openConn();
            try
            {
                var mod = conn.Query<dynamic>(modSql.ToString()).ToList<dynamic>();
                return mod;
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>{0}" + ex);
            }
            finally
            {
                conn.Close();
            }

            return null;
        }
        #endregion

        #region 新增
        public int doAdd(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();
            saveSql.Append("insert into tf_enterprise_product");
            saveSql.Append("(enterprise_id, produce_id, farmland_id, product_name,");
            saveSql.Append("product_source,product_type, plant_date, image_id, status, create_date, status_date, origin_desc, remark)");
            saveSql.Append("  values(@enterpriseId, @produceId, -1, @productName, @productSource, -1,");
            saveSql.Append("datetime('now'), @imageId, 'E', datetime('now'), datetime('now'), @orginDesc, @remark);");

            //返回自增id
            saveSql.Append("SELECT LAST_INSERT_ROWID() FROM tf_enterprise_product;");

            var conn = DbHelper.openConn();
            int id = 0;
            try
            {
                id = conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }

            return id;
        }
        #endregion

        #region 修改
        public bool doModify(DynamicParameters d)
        {

            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("update tf_enterprise_product set ");
            updateSql.Append("produce_id=@produceId,product_name=@productName,");
            updateSql.Append("origin_desc=@orginDesc,remark=@remark where corp_product_id=@corpProductId;");

            var conn = DbHelper.openConn();
            try
            {
                var id = conn.Query<int>(updateSql.ToString(), d).FirstOrDefault();
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

        # region 批量删除
        public bool delBatch(String ids)
        {
            StringBuilder delSql = new StringBuilder();
            delSql.Append("update tf_enterprise_product set status='D' where corp_product_id in (");
            delSql.Append(ids).Append(");");

            var conn = DbHelper.openConn();
            try
            {
                conn.Query<int>(delSql.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>{0}" + ex);
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
