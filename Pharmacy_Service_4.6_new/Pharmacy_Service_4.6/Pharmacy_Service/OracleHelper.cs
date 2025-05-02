using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace Pharmacy_Service
{
    public class OracleHelper
    {
        public OracleConnection orclcon;
        public OracleCommand orclcmd;
        public OracleDataAdapter orclda;
        public OracleDataReader orcldr;
        public OracleTransaction orcltrans;
        public DataSet ds;
        public DataTable dt;
        public OracleHelper()
        {
            //ls_dbstring = ConfigurationManager.ConnectionStrings["OracleDbContext"].ToString();
            //orclcon = new OracleConnection(ls_dbstring);
         //orclcon = new OracleConnection("data source=macuat;user id = macare_internal; password = pass#1234");
        orclcon = new OracleConnection("data source=mbisdb;user id =hospital; password =koothara999");
        }
        public DataSet ExecuteDataset(string query)
        {
            ds = new DataSet();
            try
            {
                orclcon.Open();
                orclcmd = new OracleCommand();
                orclcmd.Connection = orclcon;
                orclcmd.CommandType = CommandType.Text;
                orclcmd.CommandText = query;
                // orclcmd.ExecuteNonQuery();
                orclda = new OracleDataAdapter(orclcmd);
                orclda.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (orclcon.State == ConnectionState.Open)
                {
                    orclcon.Close();
                }
                orclcmd.Dispose();
                orclcon.Close();

            }
            return ds;
        }
        public DataSet executeNonQuery_dataset(string query, OracleParameter[] parameters_value)
        {
            ds = new DataSet();
            try
            {
                orclcon.Open();
                orclcmd = new OracleCommand();
                orclcmd.Connection = orclcon;
                orclcmd.CommandType = CommandType.StoredProcedure;
                orclcmd.CommandText = query;
                for (int i = 0; i < parameters_value.Length; i++)
                {

                    orclcmd.Parameters.Add(parameters_value[i]);
                }
                orclcmd.ExecuteNonQuery();
                orclda = new OracleDataAdapter(orclcmd);
                orclda.Fill(ds);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (orclcon.State == ConnectionState.Open)
                {
                    orclcon.Close();
                }
                orclcmd.Dispose();
                orclcon.Dispose();

            }
            return ds;
        }
        public string executeNonQuery(string query, OracleParameter[] parameters_value)
        {
            string retval = string.Empty;
            try
            {
                orclcon.Open();
                orclcmd = new OracleCommand();
                orclcmd.Connection = orclcon;
                orclcmd.CommandType = CommandType.StoredProcedure;
                orclcmd.CommandText = query;
                for (int i = 0; i < parameters_value.Length; i++)
                {

                    orclcmd.Parameters.Add(parameters_value[i]);
                }
               //orclcmd.ExecuteNonQuery();
               retval = orclcmd.Parameters[1].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (orclcon.State == ConnectionState.Open)
                {
                    orclcon.Close();
                }
                orclcmd.Dispose();
                orclcon.Dispose();

            }
            return retval;
        }
        public int executeNonQuery_procedure(string query, OracleParameter[] parameters_value)
        {
            int retval = 0;
            try
            {
                orclcon.Open();
                orclcmd = new OracleCommand();
                orclcmd.Connection = orclcon;
                orclcmd.CommandType = CommandType.StoredProcedure;
                orclcmd.CommandText = query;
                for (int i = 0; i < parameters_value.Length; i++)
                {

                    orclcmd.Parameters.Add(parameters_value[i]);
                }
                retval = orclcmd.ExecuteNonQuery();
                //retval = orclcmd.Parameters[7].Value.ToString();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (orclcon.State == ConnectionState.Open)
                {
                    orclcon.Close();
                }
                orclcmd.Dispose();
                orclcon.Dispose();

            }
            return retval;
        }
        public int executeNonQuery(string query)
        {
            int retval = 0;
            try
            {
                //orclcon.Close();
                orclcon.Open();
                orclcmd = new OracleCommand();
                orclcmd.Connection = orclcon;
                orclcmd.CommandType = CommandType.Text;
                orclcmd.CommandText = query;
                retval = Convert.ToInt32(orclcmd.ExecuteNonQuery());

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (orclcon.State == ConnectionState.Open)
                {
                    orclcon.Close();
                }
                orclcmd.Dispose();
                //orclcon.Dispose();

            }
            return retval;
        }
        public int executeScalar(string query)
        {
            int retval = 0;
            try
            {
                orclcon.Open();
                orclcmd = new OracleCommand();
                orclcmd.Connection = orclcon;
                orclcmd.CommandType = CommandType.Text;
                orclcmd.CommandText = query;
                retval = Convert.ToInt32(orclcmd.ExecuteScalar());

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (orclcon.State == ConnectionState.Open)
                {
                    orclcon.Close();
                }
                orclcmd.Dispose();
                orclcon.Dispose();

            }
            return retval;
        }
    }
}