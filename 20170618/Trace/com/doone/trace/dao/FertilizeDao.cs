using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;

//施肥
namespace Trace.com.doone.trace.dao
{
    class FertilizeDao
    {
        //新增施肥数据
        public bool doFertilize(DynamicParameters d)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into tf_production_detail");
            sql.Append("(production_id, action_type, action_id, amount, amount_unit, order_seq, status, action_date)");
            sql.Append(" values(@productionId,  @actionType, @actionId, @amount, @amountUnit, -1, 'E', datetime('now'));");

            var conn = DbHelper.openConn();
            try
            {
                conn.Query<int>(sql.ToString(), d);
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常->{0}", ex);
            }
            finally
            {
                conn.Close();
            }

            return true;
        }
    }
}
