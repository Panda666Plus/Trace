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
    class BatchDao
    {

        #region 查询产品批次记录
        public List<dynamic> queryBatchRecord(int corpId)
        {
            //StringBuilder sql = new StringBuilder();
            //sql.AppendFormat("select (select count(1) from tf_production where corp_product_id={0}) count,production_id,corp_product_id,production_code,strftime('%Y-%m-%d', harvest_date, 'localtime') HARVEST_DATE from tf_production where status='E' and corp_product_id={1};", corpId, corpId);
            //return DbHelper.GetDt(sql.ToString(), DbHelper._conn);

            JObject obj = new JObject();
            obj.Add("corpId", corpId);

            var rst = HttpHelper.postQueryJson(Urls.QUERY_BATCH_LIST_URL, obj);
            Console.Write(rst);
            JArray jsonObj = JArray.Parse(rst);

            return jsonObj.ToList<dynamic>();
        }
        #endregion

        #region 产品历史检测情况
        public List<dynamic> queryQualitys(int corpId)
        {
            //StringBuilder sql = new StringBuilder();
            //sql.Append("select strftime('%Y-%m-%d', b.check_date, 'localtime') CHECK_DATE,");
            //sql.Append("(select code_name from td_code_name where code_type='SAMPLE_TYPE' and code_val=b.sample_type) SAMPLE_TYPE,");
            //sql.Append("(select code_name from td_code_name where code_type='QUALITY_CHECK_TYPE' and code_val=b.check_mode) CHECK_MODE,");
            //sql.Append("b.check_person,a.quality_result");
            //sql.Append(" from tf_production a left join tf_production_quality b on a.production_id = b.production_id ");
            //sql.AppendFormat(" where a.corp_product_id={0};", corpId);

            //return DbHelper.GetDt(sql.ToString(), DbHelper._conn);

            JObject obj = new JObject();
            obj.Add("corpId", corpId);

            var rst = HttpHelper.postQueryJson(Urls.QUERY_PEST_CK_RECORD, obj);
            
            JArray jsonObj = JArray.Parse(rst);

            return jsonObj.ToList<dynamic>();
        }
        #endregion

        #region 新增 production
        public int doAddProduction(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("insert into tf_production");
            saveSql.Append("(corp_product_id, production_code, quality_result,");
            saveSql.Append("status, create_date, create_staff_id, state_date) ");
            saveSql.Append("values(@corpProductId,@productionCode,@qualityResult,'E',datetime('now'),-1,datetime('now'));");
            //返回自增id
            saveSql.Append("SELECT LAST_INSERT_ROWID() FROM tf_production");

            int uid = 0;
            var conn = DbHelper.openConn();
            try
            {
                uid = conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }
            return uid;
        }
        #endregion

        #region 编辑 production
        public bool doEcitProduction(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("update tf_production set ");
            saveSql.Append("quality_result=@qualityResult ");
            saveSql.Append("where production_id=@productionId;");

            var conn = DbHelper.openConn();
            try
            {
                conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
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

        #region 新增农残检测
        public int doAddQuality(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("insert into tf_production_quality");
            saveSql.Append("(production_id,quality_code,check_name,check_mode,check_type,sample_type,");
            saveSql.Append("check_date,check_person,status,create_date,create_staff_id) ");
            saveSql.Append("values(@productionId,-1,-1,@checkMode,'T01',@sampleType,@checkDate,@checkPerson,'E',datetime('now'),-1);");
            //返回自增id
            saveSql.Append("SELECT LAST_INSERT_ROWID() FROM tf_production_quality;");

            var conn = DbHelper.openConn();
            var uid = 0;
            try
            {
                uid = conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }
            return uid;
        }
        #endregion

        #region 检测值
        public int doAddItemVal(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("insert into tf_production_quality_item");
            saveSql.Append("(quality_id,check_item_id,check_item_value,status) ");
            saveSql.Append(" values(@qualityId,1,@checkItemVal,'E');");

            //返回自增id
            saveSql.Append("SELECT LAST_INSERT_ROWID() FROM tf_production_quality_item;");
            var uid = 0;
            var conn = DbHelper.openConn();
            try
            {
                uid = conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }
            return uid;
        }
        #endregion

        #region 编辑农残检测
        public void doEditQuality(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("update tf_production_quality set ");
            saveSql.Append("sample_type=@sampleType,check_mode=@checkMode,");
            saveSql.Append("check_date=@checkDate,check_person=@checkPerson ");
            saveSql.Append("where production_id=@productionId;");
            var conn = DbHelper.openConn();
            try
            {
                var uid = conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion

        #region 编辑农残检测值
        public void doEditQalityItem(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("update tf_production_quality_item set ");
            saveSql.Append("check_item_value=@checkItemVal ");
            saveSql.Append("where quality_id=@qualityId;");
            var conn = DbHelper.openConn();
            try
            {
                var uid = conn.Query<int>(saveSql.ToString(), d).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }

        }
        #endregion

        #region 新增 采收
        public bool doUpdHarvest(DynamicParameters d)
        {
            StringBuilder updSql = new StringBuilder();

            updSql.Append("update tf_production set ");
            updSql.Append("harvest_date=@harvestDate, harvest_amount=@harvestAmout, harvest_amount_unit=@harvestAmountUnit ");
            updSql.Append(" where production_id=@productionId;");

            var conn = DbHelper.openConn();
            try
            {
                var id = conn.Query<int>(updSql.ToString(), d).FirstOrDefault();
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

        #region 新增 销售去向
        public int doAddSales(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("insert into tf_production_sales");
            saveSql.Append("(production_id, sales_type, sales_date, buy_unit, contact_way, loco, status, create_date, create_staff_id)");
            saveSql.Append("values(@productionId,@salesType,@salesDate,@buyUnit,@contactWay,@loco,'E',datetime('now'),-1);");

            //返回自增id
            saveSql.Append("SELECT LAST_INSERT_ROWID() FROM tf_production_sales;");

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

        #region 更新 销售去向
        public bool doUpdSales(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();

            saveSql.Append("update tf_production_sales set");
            saveSql.Append(" sales_type=@salesType, sales_date=@salesDate, buy_unit=@buyUnit,");
            saveSql.Append("contact_way=@contactWay, loco=@loco where production_id=@productionId;");

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

        #region 删除批次
        public bool delProduction(int productionId)
        {
            StringBuilder delSql = new StringBuilder();
            delSql.Append("update tf_production set status='D' where production_id in (");
            delSql.Append(productionId).Append(");");

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

        #region 通过Id查询
        public dynamic queryProductionById(int productionId)
        {
            StringBuilder idsql = new StringBuilder();

            idsql.Append("select a.*,b.*,c.*,d.* from tf_production a left join tf_production_quality b ");
            idsql.Append("on a.production_id=b.production_id left join tf_production_sales c ");
            idsql.Append("on a.production_id=c.production_id left join tf_production_quality_item d ");
            idsql.Append("on b.quality_id=d.quality_id ");
            idsql.AppendFormat("where b.status='E' and c.status='E' and a.production_id={0};", productionId);

            var conn = DbHelper.openConn();
            try
            {
                var pro = conn.Query<dynamic>(idsql.ToString()).ToList<dynamic>();
                return pro;
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        #endregion

        //查询企业码与产品码
        public dynamic queryEnterAndProduceCode(int corpProductId)
        {
            StringBuilder idsql = new StringBuilder();

            idsql.Append("select b.*,c.* from tf_enterprise_product a left join tf_enterprise b on a.enterprise_id=b.enterprise_id ");
            idsql.Append(" left join td_farm_produce c on a.produce_id=c.produce_id ");
            idsql.AppendFormat("where a.status='E' and a.corp_product_id={0};", corpProductId);

            var conn = DbHelper.openConn();
            try
            {
                var pro = conn.Query<dynamic>(idsql.ToString()).ToList<dynamic>();
                return pro;
            }
            catch (Exception e)
            {
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
    }
}
