using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace WebService_ModuleUsage
{
    
    public class OracleHelper
    {
        
        private string strConnectionString = "";
        public OracleHelper()
        {
            strConnectionString = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //strConnectionString = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True";
        }
        public int ExecuteNonQuery(string query)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            OracleCommand cmd = new OracleCommand(query, cnn);
            if ((query.StartsWith("INSERT") | query.StartsWith("insert") | query.StartsWith("UPDATE") | query.StartsWith("update") | query.StartsWith("DELETE") | query.StartsWith("delete")))
                cmd.CommandType = CommandType.Text;
            else
                cmd.CommandType = CommandType.StoredProcedure;
            int retval;
            try
            {
                cnn.Open();
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cnn.Dispose();
                cmd.Dispose();
            }
            return retval;
        }
        public int ExecuteNonQuery(string query, OracleParameter[] parameters_value)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            OracleCommand cmd = new OracleCommand(query, cnn);
            int retval = 0;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                int i;
                for (i = 0; i <= parameters_value.Length - 1; i++)
                    cmd.Parameters.Add(parameters_value[i]);
                cnn.Open();
                retval = cmd.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception ex)
            {
            }

            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                cnn.Dispose();
            }
            return retval;
        }
        public object ExecuteScalar(string query)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            OracleCommand cmd = new OracleCommand(query, cnn);
            object retval = new object();
            try
            {
                if ((query.StartsWith("SELECT") | query.StartsWith("select")))
                    cmd.CommandType = CommandType.Text;
                else
                    cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                retval = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                cnn.Dispose();
            }
            return retval;
        }

        public string ExecuteNonQuery1(string query, OracleParameter[] parameters_value)
        {
            string s = string.Empty;
            OracleConnection cnn = new OracleConnection(strConnectionString);
            OracleCommand cmd = new OracleCommand(query, cnn);
            //int retval = 0;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                int i;
                for (i = 0; i <= parameters_value.Length - 1; i++)
                    cmd.Parameters.Add(parameters_value[i]);
                cnn.Open();
                cmd.ExecuteNonQuery();
                s = cmd.Parameters[0].Value.ToString() + "#" + cmd.Parameters[1].Value.ToString();
                cnn.Close();
            }
            catch (Exception ex)
            {
            }

            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                cnn.Dispose();
            }
            return s;
        }
        public DataTable ExecuteDatatable(string query, OracleParameter[] parameters_value)
        {
            string s = string.Empty;
            DataTable dtVal = new DataTable(); dtVal.Columns.Add("Date_Val");
            OracleConnection cnn = new OracleConnection(strConnectionString);
            object retval = new object();
            OracleCommand cmd = new OracleCommand(query, cnn);
            try
            {
                if (query.StartsWith("SELECT") | query.StartsWith("select"))
                    cmd.CommandType = CommandType.Text;
                else
                    cmd.CommandType = CommandType.StoredProcedure;
                int i;
                for (i = 0; i <= parameters_value.Length - 1; i++)
                    cmd.Parameters.Add(parameters_value[i]);
                cnn.Open();

                retval = cmd.ExecuteNonQuery();
                s = cmd.Parameters[0].Value.ToString();
                dtVal.Rows.Add(s);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                cnn.Dispose();
            }
            return dtVal;
        }

        public int executeScalar(string query)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            OracleCommand cmd = new OracleCommand(query, cnn);
            int retval = 0;
            try
            {
                cnn.Open();
                cmd = new OracleCommand();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                retval = Convert.ToInt32(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cmd.Dispose();
                cnn.Dispose();

            }
            return retval;
        }

        public DataSet ExecuteDataSet(string query)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            var cmd = new OracleCommand(query, cnn);
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                if ((query.StartsWith("SELECT") | query.StartsWith("select")))
                    cmd.CommandType = CommandType.Text;
                else
                    cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;

                da.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                cnn.Dispose();
                da.Dispose();
            }
            return ds;
        }


        public DataSet ExecuteDataSet(string query, OracleParameter[] parameters_value)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            var cmd = new OracleCommand(query, cnn);
            OracleDataAdapter da = new OracleDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                if ((query.StartsWith("SELECT") | query.StartsWith("select")))
                    cmd.CommandType = CommandType.Text;
                else
                    cmd.CommandType = CommandType.StoredProcedure;
                int i;
                for (i = 0; i <= parameters_value.Length - 1; i++)
                    cmd.Parameters.Add(parameters_value[i]);

                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cmd.Parameters.Clear();
                cmd.Dispose();
                cnn.Dispose();
                da.Dispose();
            }
            return ds;
        }

        public DataSet ExecuteMDataSet(string[] query, string[] tables)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            DataSet ds = new DataSet();
            OracleDataAdapter da = new OracleDataAdapter();
            try
            {
                int i;
                for (i = 0; i <= query.GetUpperBound(0); i++)
                {
                    var cmd = new OracleCommand(query[i], cnn);
                    cmd.CommandType = CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(ds, tables[i]);
                    cmd.Dispose();
                    cmd.Parameters.Clear();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if ((cnn.State == ConnectionState.Open))
                    cnn.Close();
                cnn.Dispose();
                da.Dispose();
            }
            return ds;
        }

        public DataSet executeNonQuery_dataset(string query, OracleParameter[] parameters_value)
        {
            OracleConnection cnn = new OracleConnection(strConnectionString);
            var cmd = new OracleCommand(query, cnn);

            DataSet ds = new DataSet();
            try
            {
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                for (int i = 0; i < parameters_value.Length; i++)
                {
                    cmd.Parameters.Add(parameters_value[i]);
                }
                cmd.ExecuteNonQuery();
                OracleDataAdapter da = new OracleDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {   
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
                cmd.Dispose();
                cnn.Dispose();

            }
            return ds;
        }
    }
}