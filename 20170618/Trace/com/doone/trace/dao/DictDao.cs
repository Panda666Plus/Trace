using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Trace.common;

namespace Trace.com.doone.trace.dao
{
    class DictDao
    {
        public List<dynamic> queryDictByType(string type)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendFormat("select code_id,code_type,code_val,code_name,code_flag,order_seq,status,status_date from td_code_name where code_type='{0}' and status='E' ", type);

            Console.WriteLine(sql.ToString());

            var conn = DbHelper.openConn();
            List<dynamic> list = new List<dynamic>();
            try
            {
                list = conn.Query<dynamic>(sql.ToString()).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常->{0}", ex);
            }
            finally
            {
                conn.Close();
            }
            return list;
        }
    }
}
