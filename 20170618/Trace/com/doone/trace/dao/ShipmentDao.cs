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
    class ShipmentDao
    {
        #region 查询总数
        public int queryCount(String quality)
        {
            StringBuilder countSql = new StringBuilder();
            countSql.Append("select count(1) from tf_shipment a where a.status='E' ");

            if (!string.IsNullOrEmpty(quality))
            {
                countSql.AppendFormat(" and a.quality like '%{0}%' ", quality);
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
        public DataTable queryPage(String quality, int pageSize, int pageIndex)
        {
            StringBuilder pageSql = new StringBuilder();
            pageSql.Append("select a.shipment_id,a.shipment_code,a.yield,a.yield_unit,a.quality,a.status,");
            pageSql.Append("strftime('%Y-%m-%d', a.create_date, 'localtime') CREATE_DATE,a.remark ");
            pageSql.Append(" from tf_shipment a where a.status='E' ");

            

            if (!string.IsNullOrEmpty(quality))
            {
                pageSql.AppendFormat(" and a.quality like '%{0}%' ", quality);
            }

            pageSql.AppendFormat("order by a.shipment_id desc limit {0} offset {1} ", pageSize, (pageIndex - 1) * pageSize);

            return DbHelper.GetDt(pageSql.ToString(), DbHelper._conn);
        }
        #endregion

        #region 新增
        public bool doAdd(DynamicParameters d)
        {
            StringBuilder saveSql = new StringBuilder();
            saveSql.Append("insert into tf_shipment");
            saveSql.Append("(shipment_code, yield, yield_unit, quality, status, create_date,");
            saveSql.Append("create_staff_id, state_date, remark) ");
            saveSql.Append("values('YDMT001', 1200, '元', '优', 'E', datetime('now'),");
            saveSql.Append("-1, datetime('now'), 'mememme');");

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
            updSql.Append("update tf_shipment set shipment_code=@shipmentCode,yield=@yield,yieldUnit=@yieldUnit");
            updSql.Append(",quality=@quality,remark=@remark where status='E' and shipment_id=@shipmentId;");

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
            delSql.Append("update tf_shipment set status='D' where shipment_id in (");
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
