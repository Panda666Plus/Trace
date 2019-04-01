using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;

namespace Trace.com.doone.trace.dao
{
    class RecordsDao
    {
        # region 查询总数
        public int doQueryCount(String enterpriseName, String farmLandName, String produceName)
        {
            //查询总数
            StringBuilder countSql = new StringBuilder();
            countSql.Append("select count(1) as count from tf_production a");
            countSql.Append(" left join tf_enterprise b on a.enterprise_id=b.enterprise_id left join td_farm_produce c");
            countSql.Append(" on a.produce_id=c.produce_id left join tf_farmland d on a.farmland_id=d.farmland_id ");
            countSql.Append(" where a.status='E' ");

            if (!string.IsNullOrEmpty(enterpriseName))
            {
                countSql.AppendFormat(" and b.enterprise_name like '%{0}%' ", enterpriseName);
            }

            if (!string.IsNullOrEmpty(farmLandName))
            {
                countSql.AppendFormat(" and d.farmland_name like '%{0}%' ", farmLandName);
            }

            if (!string.IsNullOrEmpty(produceName))
            {
                countSql.AppendFormat(" and c.produce_name like '%{0}%' ", produceName);
            }

            var count = 0;
            var conn = DbHelper.openConn();
            try
            {
                count = conn.Query<int>(countSql.ToString()).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine(">>>>>{0}" + ex);
            }
            finally
            {
                conn.Close();
            }

            return count;
        }
        #endregion

        # region 分页查询
        public DataTable doQeuryPage(String enterpriseName, String farmLandName, String produceName, int pageSize, int pageIndex)
        {
            //分页sql
            StringBuilder pageSql = new StringBuilder();
            pageSql.Append("SELECT a.PRODUCTION_ID,a.PRODUCTION_CODE,a.PRODUCTION_STATE,b.ENTERPRISE_ID,b.ENTERPRISE_NAME,");
            pageSql.Append("d.FARMLAND_ID,d.FARMLAND_NAME,c.PRODUCE_ID,c.PRODUCE_NAME,a.AMOUNT,a.AMOUNT_UNIT,");
            //pageSql.Append(",AMOUNT_UNIT,strftime('%Y-%m-%d %H:%M:%S',begin_date,'localtime') ");
            pageSql.Append("strftime('%Y-%m-%d',a.begin_date,'localtime') BEGIN_DATE,a.PLOUGH_DATE,a.SOW_DATE,a.PLANT_DATE,a.REMARK ");
            pageSql.Append("FROM tf_production a left join tf_enterprise b on a.enterprise_id=b.enterprise_id left join td_farm_produce c");
            pageSql.Append(" on a.produce_id=c.produce_id left join tf_farmland d on a.farmland_id=d.farmland_id ");
            pageSql.Append("where a.status='E' ");

            if (!string.IsNullOrEmpty(enterpriseName))
            {
                pageSql.AppendFormat(" and b.enterprise_name like '%{0}%' ", enterpriseName);
            }

            if (!string.IsNullOrEmpty(farmLandName))
            {
                pageSql.AppendFormat(" and d.farmland_name like '%{0}%' ", farmLandName);
            }

            if (!string.IsNullOrEmpty(produceName))
            {
                pageSql.AppendFormat(" and c.produce_name like '%{0}%' ", produceName);
            }

            pageSql.AppendFormat("order by production_id desc limit {0} offset {1} ", pageSize, (pageIndex - 1) * pageSize);

            return DbHelper.GetDt(pageSql.ToString(), DbHelper._conn);
        }
        #endregion

        # region 新增记录
        public bool doAdd(DynamicParameters d)
        {
            StringBuilder insertSql = new StringBuilder();
            insertSql.Append("insert into tf_production");
            insertSql.Append("(farmland_id,enterprise_id,produce_id,production_code,");
            insertSql.Append("production_state,amount,amount_unit,begin_date,status,remark)");
            insertSql.Append(" values(@farmLandId,@enterpriseId,@produceId,'-1','E',@amt,@amtUnit,@startDate,'E',@rmk);");

            var conn = DbHelper.openConn();
            try
            {
                var id = conn.Query<int>(insertSql.ToString(), d).FirstOrDefault();

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

        # region 修改记录
        public bool doModify(DynamicParameters d)
        {
            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("update tf_production set ");
            updateSql.Append("farmland_id=@farmLandId,enterprise_id=@enterpriseId,produce_id=@produceId,");
            updateSql.Append("amount=@amt,amount_unit=@amtUnit,begin_date=@startDate,remark=@rmk where production_id=@productionId;");

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
            delSql.Append("update tf_production set status='D' where production_id in (");
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

        #region 查询所有记录
        public List<dynamic> queryRecords()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("select a.production_id,c.farmland_id,c.farmland_name,b.produce_id,b.produce_name,");
            sql.Append("(c.farmland_name || '/' || b.produce_name) SHUOM ");
            sql.Append(" from tf_production a left join td_farm_produce b on a.produce_id = b.produce_id");
            sql.Append(" left join tf_farmland c on a.farmland_id = c.farmland_id where a.status = 'E';");

            var conn = DbHelper.openConn();
            List<dynamic> recordList = new List<dynamic>();
            try
            {
                //企业信息选择
                recordList = conn.Query<dynamic>(sql.ToString()).ToList();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }
            return recordList;
        }
        #endregion

        #region 企业下拉列表
        public List<dynamic> queryEnterprise()
        {
            //查询企业信息sql
            StringBuilder enterSql = new StringBuilder();
            enterSql.Append("select * from tf_enterprise;");

            var conn = DbHelper.openConn();
            List<dynamic> enterList = new List<dynamic>();
            try
            {
                //企业信息选择
                enterList = conn.Query<dynamic>(enterSql.ToString()).ToList();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }
            return enterList;
        }
        #endregion

        # region 地块下拉列表
        public List<dynamic> queryFarmland()
        {
            //查询田块信息sql
            StringBuilder farmLandSql = new StringBuilder();
            farmLandSql.Append("select * from tf_farmland;");

            var conn = DbHelper.openConn();
            List<dynamic> farmLandList = new List<dynamic>();
            try
            {
                //田块信息选择
                farmLandList = conn.Query<dynamic>(farmLandSql.ToString()).ToList();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }

            return farmLandList;
        }
        #endregion

        # region 农产品下拉列表
        public List<dynamic> queryProduce()
        {
            //查询农产品信息sql
            StringBuilder produceSql = new StringBuilder();
            produceSql.Append("select * from td_farm_produce;");

            var conn = DbHelper.openConn();
            List<dynamic> produceList = new List<dynamic>();
            try
            {

                //农产品信息选择
                produceList = conn.Query<dynamic>(produceSql.ToString()).ToList();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }

            return produceList;
        }
        #endregion
    }
}
