using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;

namespace Trace.com.doone.trace.dao
{
    class DataHandlerDao
    {
        #region 查询要上传的数据
        public List<dynamic> queryBySql(string sql)
        {
            //查询XX表数据
            StringBuilder enterSql = new StringBuilder();
            enterSql.Append(sql);

            var conn = DbHelper.openConn();
            List<dynamic> list = new List<dynamic>();
            try
            {
                list = conn.Query<dynamic>(enterSql.ToString()).ToList();
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
        #endregion

        #region 更新上传状态
        public void updateState(Dictionary<String, Object> dict)
        {
            string tableName = "";
            string id = "";
            string key = "";
            foreach (var item in dict)
            {
                if ("tabName".Equals(item.Key))
                {
                    tableName = item.Value.ToString();
                }
                if ("tabId".Equals(item.Key))
                {
                    id = item.Value.ToString();
                }
                if ("tabIdName".Equals(item.Key))
                {
                    key = item.Value.ToString();
                }
            }

            StringBuilder updState = new StringBuilder();
            updState.Append("update ").Append(tableName).Append(" set ").Append("UPLOAD_STATE='E',UPLOAD_DATE=datetime('now') ");
            updState.Append(" where ").Append(key).Append("=").Append(id).Append(";") ;

            var conn = DbHelper.openConn();
            try
            {
                var list = conn.Query<dynamic>(updState.ToString()).ToList();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
