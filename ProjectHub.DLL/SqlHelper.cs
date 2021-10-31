using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHub.DLL
{
    [Serializable]
    public sealed class SqlHelper
    {
        public SqlHelper()
        {
        }

        #region ExcuteNonQuery
        public static int ExcuteNonQuery(string procName, SqlParameter[] paramObj)
        {
            return Excute(procName, paramObj);
        }

        public static int Excute(string procName, SqlParameter[] paramObj)
        {
            SqlConnection con = GetConnection("con");
            SqlCommand cmd = con.CreateCommand();
            try
            {
                int recCount = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
                foreach (var procParameter in paramObj)
                {
                    cmd.Parameters.AddWithValue(procParameter.ParameterName, procParameter.Value);
                }
                recCount = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();
                return recCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }

        }

        #endregion

        #region Excute Data Reader
        public static SqlDataReader ExcuteDataReader(string procName, SqlParameter[] paramObj)
        {
            return ExcuuteReader(procName, paramObj);
        }

        public static SqlDataReader ExcuuteReader(string procName, SqlParameter[] paramObj)
        {

            SqlConnection con = GetConnection("con");
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            try
            {
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = procName;
                if (paramObj.Length != 0)
                {
                    foreach (var procParameter in paramObj)
                    {
                        cmd.Parameters.AddWithValue(procParameter.ParameterName, procParameter.Value);
                    }
                }
                reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return reader;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
        public static SqlConnection GetConnection(string connectionName)
        {
            string cnstr = Convert.ToString(ConfigurationManager.ConnectionStrings["Con"]);
            SqlConnection cn = new SqlConnection(cnstr);
            cn.Open();
            return cn;
        }
    }
}
