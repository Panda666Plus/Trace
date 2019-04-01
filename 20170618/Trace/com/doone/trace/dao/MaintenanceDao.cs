using Dapper;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;
using Trace.Common;

namespace Trace.com.doone.trace.dao
{
    class MaintenanceDao
    {
        #region 新增施肥记录
        public int doAdd(DynamicParameters d)
        {

            StringBuilder sfSql = new StringBuilder();
            sfSql.Append("insert into tf_enterprise_product_detail(corp_product_id, action_type, action_id,");
            sfSql.Append("action_value, amount, amount_unit, area, order_seq, status, action_date, action_staff_id, create_date)");
            sfSql.Append(" values(@productId, @actionType, @actionId, @actionValue, @amount,");
            sfSql.Append("@amountUnit, @area, 1, 'E', @actionDate, @actionPerson, datetime('now'));");

            //返回自增id
            sfSql.Append("SELECT LAST_INSERT_ROWID() FROM tf_enterprise_product_detail;");

            var conn = DbHelper.openConn();
            var id = 0;
            try
            {
                id = conn.Query<int>(sfSql.ToString(), d).FirstOrDefault();

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

        #region 查出施肥记录
        public List<dynamic> queryFertilization(string actionType, int produceId)
        {
            //StringBuilder sql = new StringBuilder();
            //sql.Append("select a.product_detail_id,a.corp_product_id,a.action_type,a.action_id,a.action_value,");
            //sql.Append("a.amount,a.amount_unit,a.area,strftime('%Y-%m-%d', a.action_date, 'localtime') ACTION_DATE ");
            //sql.Append(" from tf_enterprise_product_detail a left join tf_enterprise_product b on a.action_id=b.produce_id ");
            //sql.AppendFormat(" where a.action_type='{0}' and a.status='E' and a.action_id={1};", actionType, produceId);
            //return DbHelper.GetDt(sql.ToString(), DbHelper._conn);

            JObject obj = new JObject();
            obj.Add("actionType", actionType);
            obj.Add("produceId", produceId);

            var rst = HttpHelper.postQueryJson(Urls.QUERY_FERT_RECORD, obj);

            JArray jsonObj = JArray.Parse(rst);

            return jsonObj.ToList<dynamic>();
        }
        #endregion

        #region 施肥新增
        public bool doAddFertilization(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();
            saveSql.Append("insert into tf_enterprise_product");
            saveSql.Append("(CORP_PRODUCT_ID, ENTERPRISE_ID, PRODUCE_ID, FARMLAND_ID,");
            saveSql.Append("PRODUCT_NAME,PRODUCT_SOURCE, PRODUCT_TYPE, PLANT_DATE, PLANT_AREA, PLANT_AREA_UNIT, SEED_NAME, SEED_AMOUNT, BATCH_NUM)");
            saveSql.Append("IMAGE_ID,STATUS,CREATE_DATE,STATUS_DATE,ORIGIN_DESC,REMARK,UPLOAD_STATE,UPLOAD_DATE");
            saveSql.Append("  values(@CORP_PRODUCT_ID, @ENTERPRISE_ID,3, 4");
            saveSql.Append("5,6,7, 8,datetime('now'),@PLANT_AREA_UNIT,1,@SEED_NAME,45,76,'使用',datetime('now'),datetime('now'),@ORIGIN_DESC,@REMARK,开启,datetime('now')");

            var conn = DbHelper.openConn();
            try
            {
                var id = conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
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

        #region 查询施药记录
        public List<dynamic> queryPestRecord(string actionType, int produceId)
        {
            //StringBuilder pestSql = new StringBuilder();
            //pestSql.Append("select product_detail_id, action_value,'除虫菊素' YXCF,thickness,amount,area, ");
            //pestSql.Append(" strftime('%Y-%m-%d', action_date, 'localtime') ACTION_DATE,'7' AQJGQ ");
            //pestSql.AppendFormat(" from tf_enterprise_product_detail where action_type='{0}' and status='E' and action_id={1};", actionType, produceId);
            //return DbHelper.GetDt(pestSql.ToString(), DbHelper._conn);

            JObject obj = new JObject();
            obj.Add("actionType", actionType);
            obj.Add("produceId", produceId);

            var rst = HttpHelper.postQueryJson(Urls.QUERY_PEST_RECORD, obj);

            JArray jsonObj = JArray.Parse(rst);

            return jsonObj.ToList<dynamic>();

        }
        #endregion

        #region 施药新增
        public int doAddApplying(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("insert into tf_enterprise_product_detail(corp_product_id, action_type, action_id,");
            saveSql.Append("action_value, amount, amount_unit, area, thickness, order_seq, status, action_date, action_staff_id, create_date)");
            saveSql.Append("values(@productId, @actionType, @actionId, @actionValue, @amount, @amountUnit, @area,");
            saveSql.Append("@thinckNess, 1, 'E', @actionDate, @actionPerson, datetime('now'));");

            //返回自增id
            saveSql.Append("SELECT LAST_INSERT_ROWID() FROM tf_enterprise_product_detail;");

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

        #region 查出施药记录
        public DataTable queryApplying(int corpId)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("select b.ENTERPRISE_ID,a.PRODUCT_DETAIL_ID,a.THICKNESS,a.AMOUNT,a.AREA_UNIT,a.ACTION_DATE,a.UPLOAD_DATE-CREATE_DATE,a.COMMENT");
            sql.Append(" from tf_enterprise_product_detail a left join tf_enterprise_product b on a.CORP_PRODUCT_ID = b.CORP_PRODUCT_ID");
            // sql.AppendFormat(" where a.corp_product_id={0};", corpId);

            return DbHelper.GetDt(sql.ToString(), DbHelper._conn);
        }
        #endregion
    }
}
