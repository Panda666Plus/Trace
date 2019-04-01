using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;

//出厂记录操作
namespace Trace.com.doone.trace.dao
{
    class HarvestDao
    {
        #region 查询总数
        public int queryCount(String produceName)
        {
            StringBuilder countSql = new StringBuilder();
            countSql.Append("select count(1) ");
            countSql.Append("from tf_harvest a left join td_farm_produce b on a.produce_id=b.produce_id where a.status='E' ");

            if (!string.IsNullOrEmpty(produceName))
            {
                countSql.AppendFormat(" and b.produce_name like '%{0}%' ;", produceName);
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

        #region 分页条件查询
        public DataTable queryPage(String produceName, int pageSize, int pageIndex)
        {
            StringBuilder pageSql = new StringBuilder();
            pageSql.Append("select a.harvest_id,a.harvest_code,a.amount,a.amount_unit,a.produce_id,b.produce_name,a.quality,a.status,");
            pageSql.Append("strftime('%Y-%m-%d', a.harvest_date, 'localtime') HARVEST_DATE,");
            pageSql.Append("strftime('%Y-%m-%d', a.create_date, 'localtime') CREATE_DATE,");
            pageSql.Append("a.create_staff_id,strftime('%Y-%m-%d', a.state_date, 'localtime') STATE_DATE,a.remark,a.upload_state,");
            pageSql.Append("strftime('%Y-%m-%d', a.upload_date, 'localtime') UPLOAD_DATE");
            pageSql.Append(" from tf_harvest a left join td_farm_produce b on a.produce_id=b.produce_id where a.status='E' ");

            if (!string.IsNullOrEmpty(produceName))
            {
                pageSql.AppendFormat(" and b.produce_name like '%{0}%' ", produceName);
            }

            pageSql.AppendFormat("order by a.harvest_id desc limit {0} offset {1} ;", pageSize, (pageIndex - 1) * pageSize);

            return DbHelper.GetDt(pageSql.ToString(), DbHelper._conn);
        }
        #endregion

        #region 新增
        public bool doAdd(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();
            saveSql.Append("insert into tf_harvest");
            saveSql.Append("(harvest_code,amount,amount_unit,produce_id,quality,");
            saveSql.Append("status,harvest_date,create_date,create_staff_id,state_date,remark) ");
            saveSql.Append("values(-1,@amount,@amountUnit,@produceId,-1,");
            saveSql.Append("'E',@harvestDate,datetime('now'),-1,'E',@remark);");

            //d.Add("", Convert.ToDateTime(harvestDate.Text).ToString("yyyy-MM-dd"));

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

        #region 更新
        public bool doUpdate(DynamicParameters d)
        {
            StringBuilder updSql = new StringBuilder();
            updSql.Append("update tf_harvest set amount=@amount,amount_unit=@amountUnit,");
            updSql.Append("produce_id=@produceId,remark=@remark ");
            updSql.Append(" where status='E' and harvest_id=@harvestId;");

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

        #region 批量删除
        public bool batchDel(String ids)
        {
            StringBuilder delSql = new StringBuilder();
            delSql.Append("update tf_harvest set status='D' where harvest_id in (");
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

        #region 采收
        public bool doHarv(DynamicParameters d)
        {
            StringBuilder harSql = new StringBuilder();
            harSql.Append("insert into tf_harvest_detail(harvest_id,production_id,status,harvest_date,create_date,create_staff_id,state_date,remark)");
            harSql.Append("values(@harvestId,@productionId,'E',@harvestDate,datetime('now'),-1,datetime('now'),@remark);");

            var conn = DbHelper.openConn();
            try
            {
                var id = conn.Query<int>(harSql.ToString(), d).FirstOrDefault();
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


            return true;
        }
        #endregion
    }
}
