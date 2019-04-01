using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;

namespace Trace.com.doone.trace.dao
{
    class HarmlesDao
    {
        #region 新增
        public bool doAdd(DynamicParameters dp)
        {
            StringBuilder insertSql = new StringBuilder();
            insertSql.Append("insert into tf_harmless");
            insertSql.Append("(HARMLESS_ID,PRODUCTION_ID,PRODUCE_ID,PRODUCTION_ADDR,ENTERPRISE_NAME,HANDLER,");
            insertSql.Append("PRODUCT_AMOUNT,PRODUCT_STATE,CAUSE,HANDLER_DATE,HANDLER_MODE,HANDLER_PERSON,STATUS,");
            insertSql.Append("CREATE_DATE,CREATE_STAFF_ID,STATE_DATE,REMARK,UPLOAD_STATE,UPLOAD_DATE)");
            insertSql.Append(" values('1','2',@PRODUCTION_ID,@ENTERPRISE_NAME,@ENTERPRISE_NAME,'Admin',@PRODUCT_AMOUNT,@PRODUCT_STATE,@CAUSE,");
            insertSql.Append("@HANDLER_DATE,@HANDLER_MODE,@HANDLER_PERSON,'使用',@HANDLER_DATE,5,@HANDLER_DATE,'',@UPLOAD_STATE,@HANDLER_DATE);");
            //insertSql.Append(" values(@farmLandId,@enterpriseId,@produceId,'-1','E',@amt,@amtUnit,@startDate,'E',@rmk);");

            var conn = DbHelper.openConn();
            try
            {
                var id = conn.Query<int>(insertSql.ToString(), dp).FirstOrDefault();

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

        #region 修改
        public bool doModify(DynamicParameters dp)
        {
            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("update tf_harmless set ");
            updateSql.Append("ENTERPRISE_NAME=@ENTERPRISE_NAME,");
            updateSql.Append("PRODUCT_STATE=@PRODUCT_STATE,");
            updateSql.Append("CAUSE=@CAUSE,");
            updateSql.Append("HANDLER_DATE=@HANDLER_DATE,");
            updateSql.Append("HANDLER_MODE=@HANDLER_MODE,");
            updateSql.Append("HANDLER_PERSON=@HANDLER_PERSON,");
            updateSql.Append("UPLOAD_STATE=@HANDLER_DATE");
            updateSql.Append("where PRODUCTION_ID = @PRODUCTION_ID");

            //var id = 0;

            //SqlParameter[] parameters = {
            //    new SqlParameter("@PRODUCTION_ID", SqlDbType.Int,4),
            //    new SqlParameter("@ENTERPRISE_NAME", SqlDbType.Char,4),
            //    new SqlParameter("@ENTERPRISE_NAME", SqlDbType.Char,4),
            //    new SqlParameter("@PRODUCT_AMOUNT", SqlDbType.Int,4),
            //    new SqlParameter("@PRODUCT_STATE", SqlDbType.DateTime,4),
            //    new SqlParameter("@CAUSE", SqlDbType.Char,4),
            //    new SqlParameter("@HANDLER_DATE", SqlDbType.DateTime,4),
            //    new SqlParameter("@HANDLER_MODE", SqlDbType.Char,4),
            //    new SqlParameter("@HANDLER_PERSON", SqlDbType.Char,4),
            //    new SqlParameter("@UPLOAD_STATE", SqlDbType.DateTime,4),
            //        };


            //parameters[0].Value = model.PRODUCTION_ID;
            //parameters[1].Value = model.ENTERPRISE_NAME;
            //parameters[3].Value = model.ENTERPRISE_NAME;
            //parameters[4].Value = model.PRODUCT_AMOUNT;
            //parameters[5].Value = model.PRODUCT_STATE;
            //parameters[6].Value = model.CAUSE;
            //parameters[7].Value = model.HANDLER_DATE;
            //parameters[8].Value = model.HANDLER_MODE;
            //parameters[9].Value = model.HANDLER_PERSON;
            //parameters[10].Value = model.UPLOAD_STATE;

            //object obj = DbHelper.ExecuteSql(updateSql.ToString(), parameters);
            //if (obj == null)
            //{
            //    return 1;
            //}
            //else
            //{
            //    return Convert.ToInt32(obj);
            //}

            var conn = DbHelper.openConn();
            try
            {
                 //id = DbHelper.ExecuteSql(updateSql.ToString(), parameters);
               var id = conn.Query<int>(updateSql.ToString(), dp).FirstOrDefault();
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

        #region 删除
        public bool delBatch(String ids)
        {
            StringBuilder delSql = new StringBuilder();
            delSql.Append("update tf_harmless set STATUS='E' where HARMLESS_ID in (");
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

        #region 生产者下拉列表
        public List<dynamic> queryProducer()
        {
            //查询企业信息sql
            StringBuilder producerSql = new StringBuilder();
            producerSql.Append("select ENTERPRISE_NAME from tf_harmless;");

            var conn = DbHelper.openConn();
            List<dynamic> producerList = new List<dynamic>();
            try
            {
                // 生产者下拉列表选择
                producerList = conn.Query<dynamic>(producerSql.ToString()).ToList();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("异常：{0}", ex);
            }
            finally
            {
                conn.Close();
            }
            return producerList;
        }
        #endregion
    }
}
