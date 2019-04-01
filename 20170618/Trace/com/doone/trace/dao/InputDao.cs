using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trace.common;
namespace Trace.com.doone.trace.dao
{
    class InputDao
    {

        #region 删除
        public bool delBatch(String ids)
        {
            StringBuilder delSql = new StringBuilder();
            delSql.Append("update td_inputs set STATUS='1' where inputsId in (");
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

        #region 新增
        public bool doAdd(DynamicParameters dp)
        {
            //StringBuilder insertSql = new StringBuilder();
            //insertSql.Append("insert into td_inputs");
            //insertSql.Append("(INPUTS_ID,INPUTS_CODE,INPUTS_NAME,INPUTS_TYPE,PARENT_ID,");
            //insertSql.Append("ENGLISH_NAME,PESTICIDE_CLASS,STATUS, EFFECT,REMARK  )");
            //insertSql.Append(" values('1',@inputsCode,@inputsName,'1','2',@englishName,@inputsType,'E','使用',@describe);");
            var commandtext = $"insert into td_inputs (INPUTS_ID,INPUTS_CODE,INPUTS_NAME,INPUTS_TYPE,PARENT_ID,ENGLISH_NAME,PESTICIDE_CLASS,STATUS, EFFECT,REMARK )  values('1',@inputsCode,@inputsName,'1','2',@englishName,@inputsType,'E','使用',@describe);";
            var conn = DbHelper.openConn();
            try
            {
                

                var number = conn.Execute(commandtext.ToString(), dp);
                return number == 0 ? false : true;
                //  var id = conn.Query<int>(insertSql.ToString(), dp).FirstOrDefault();

            }
            catch (Exception e)
            {
                return false;
                Console.WriteLine("异常->{0}", e);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region 修改
        public void doModify(DynamicParameters dp)
        {
            StringBuilder updateSql = new StringBuilder();
            updateSql.Append("update td_inputs set ");
            updateSql.Append("INPUTS_CODE=@inputsCode,INPUTS_NAME=@inputsName,ENGLISH_NAME=@englishName,");
            updateSql.Append("PESTICIDE_CLASS=@inputsType,REMARK=@describe where INPUTS_ID=@inputsId;");

            var conn = DbHelper.openConn();
            try
            {
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
        }
        #endregion      
    }

    //public class SQLCE : DbContext
    //{
    //   public virtual DbSet<TempData> TempDatas{ get;set;}
    //}
    //public class TempData
    //{
    //    [Key]
    //    public int INPUTS_ID { get; set; }
    //    public string INPUTS_CODE { get; set; }

    //    public string INPUTS_NAME { get; set; }
    //    public string INPUTS_TYPE { get; set; }
    //    public string PARENT_ID { get; set; }
    //    public string ENGLISH_NAME { get; set; }
    //}
}
