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
    class QualityDao
    {
        #region 查询总数
        public int queryCount(String qualityName)
        {
            StringBuilder countSql = new StringBuilder();
            countSql.Append("select count(1) ");
            countSql.Append("from tf_quality a where a.status='E' ");

            if (!string.IsNullOrEmpty(qualityName))
            {
                countSql.AppendFormat(" and a.check_name like '%{0}%' ;", qualityName);
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
        public DataTable queryPage(String qualityName, int pageSize, int pageIndex)
        {
            StringBuilder pageSql = new StringBuilder();

            pageSql.Append("select a.quality_id,a.production_id,a.quality_code,a.check_name,");
            pageSql.Append("a.check_type,strftime('%Y-%m-%d', a.check_date, 'localtime') CHECK_DATE,");
            pageSql.Append("a.check_person,a.status,strftime('%Y-%m-%d', a.create_date, 'localtime') CREATE_DATE,");
            pageSql.Append("a.create_staff_id,strftime('%Y-%m-%d', a.state_date, 'localtime') STATE_DATE,");
            pageSql.Append("strftime('%Y-%m-%d', a.upload_date, 'localtime') UPLOAD_DATE,a.remark");
            pageSql.Append(" from tf_quality a where a.status = 'E' ");


            if (!string.IsNullOrEmpty(qualityName))
            {
                pageSql.AppendFormat(" and a.check_name like '%{0}%' ", qualityName);
            }

            pageSql.AppendFormat("order by a.quality_id desc limit {0} offset {1} ;", pageSize, (pageIndex - 1) * pageSize);

            return DbHelper.GetDt(pageSql.ToString(), DbHelper._conn);
        }
        #endregion

        #region 新增
        public bool doAdd(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();
            saveSql.Append("insert into tf_quality");
            saveSql.Append("(production_id, quality_code, check_name, check_type, check_date,");
            saveSql.Append("check_person, status, create_date, create_staff_id,remark) ");
            saveSql.Append("values(@productionId, @qualityCode, @checkName, @qualityType, @checkDate,");
            saveSql.Append("@checkPerson, 'E', datetime('now'), -1,@remark);");

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
            updSql.Append("update tf_quality set production_id=@productionId,quality_code=@qualityCode,check_name=@checkName,");
            updSql.Append("check_type=@qualityType,check_date=@checkDate,check_person=@checkPerson,remark=@remark ");
            updSql.Append(" where status='E' and quality_id=@qualityId;");

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
            delSql.Append("update tf_quality set status='D' where quality_id in (");
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
