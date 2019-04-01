using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trace.common
{
    class DbHelper
    {
        //private string _dbFile = @"D:\Workspace_Sets\ws_trace_vs\Trace_version 2.0.0\Trace\bin\Debug\HbTrace.sqlite";
        private static string _dbFile = @"HbTrace.sqlite";

        public static string _conn
        {
            get
            {

                //1.基础连接，FailIfMissing 参数 true=没有数据文件将异常;false=没有数据库文件则创建一个  
                //Data Source=test.db;Pooling=true;FailIfMissing=false  
                //2。使用utf-8 格式  
                //Data Source={0};Version=3;UTF8Encoding=True;  
                //3.禁用日志  
                //Data Source={0};Version=3;UTF8Encoding=True;Journal Mode=Off;  
                //4.连接池  
                //Data Source=c:\mydb.db;Version=3;Pooling=True;Max Pool Size=100;  

                //var conn = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;User Id=root;password=root;Database=test");

                return string.Format(@"Data Source={0};Pooling=true;FailIfMissing=false;Version=3;UTF8Encoding=True;Journal Mode=Off;", _dbFile);
                //return string.Format(@"Data Source={0};Pooling=true;", _dbFile);
            }
        }

        public static SQLiteConnection openConn()
        {
            return new SQLiteConnection(_conn);
        }

        public static DataTable GetDt(string sql, string conn)
        {

            SQLiteDataAdapter sda = new SQLiteDataAdapter(sql, conn);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            sda.Dispose();
            return dt;
        }

        //防止Sql注入
        public static DataTable FillTableLite(string sqlText, String Con, SQLiteParameter[] paraLite = null)
        {
            //DataTable newDT = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(Con))
                {
                    con.Open();
                    using (SQLiteCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = sqlText;
                        if (paraLite != null)
                        {
                            cmd.Parameters.Clear();
                            foreach (SQLiteParameter Para in paraLite)
                            {
                                cmd.Parameters.AddWithValue(Para.ParameterName, Para.Value);
                            }
                        }

                        SQLiteDataAdapter sdaLite = new SQLiteDataAdapter(cmd);
                        //sdaLite.Fill(newDT);
                        sdaLite.Fill(ds);
                        return ds.Tables[0];
                        //sdaLite.Dispose();
                        //cmd.Dispose();
                    }
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            //return newDT;
        }





        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(_conn))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }



        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

    }
}
