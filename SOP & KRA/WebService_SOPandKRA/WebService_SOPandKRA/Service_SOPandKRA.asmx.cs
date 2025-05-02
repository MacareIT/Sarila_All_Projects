using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OracleClient;

namespace WebService_SOPandKRA
{
    /// <summary>
    /// Summary description for Service_SOPandKRA
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service_SOPandKRA : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        DataSet ObjDataSet = new DataSet();
        DataTable ObjDatatb = new DataTable();

        [WebMethod]
        public DataSet Get_login(string username, string password)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from LOGIN_USERS where username = '" + username + "' and password = '" + password + "'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_dapartment()
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select distinct dep_name from HOSPITAL.DEPARTMENT_MST where dep_name like 'MACARE%'");
            DS = ObjOrclHelper.ExecuteDataSet("select dept_id, dept_name from department_master order by dept_name");
            return DS;
        }

        [WebMethod]
        public int Add_Sopkra(string sopkraid,string dep_name, string designation, string sop_doc, string kra_doc)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into sop_kra_registration values('" + sopkraid + "', '" + dep_name + "', '" + designation + "', " +
                "'" + sop_doc + "', '" + kra_doc + "')");
            return id;
        }

        [WebMethod()]
        public DataSet Get_sopkraid()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select SEQ_SOPKRA.nextval from dual");
            return DS;
        }


        [WebMethod()]
        public DataSet Get_viewsopkra()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from sop_kra_registration ");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_registerddesignation(int dept_id)
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select * from sop_kra_registration where department = '" + dep_name + "'");
            DS = ObjOrclHelper.ExecuteDataSet("select a.*,dept_name from sop_kra_registration a join department_master b on a.department=dept_id where department = "+dept_id+"");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_registerdsopkra(string sop_kra_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from sop_kra_registration where sop_kra_id = '" + sop_kra_id + "'");
            return DS;
        }

        [WebMethod]
        public int Update_sop(string sop_kra_id, byte[] sop_attachment, string sop_filename, string sop_contenttype)
        {
            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                string query = "update sop_kra_registration set sop_attachment = :sop_attachment, sop_filename = :sop_filename, sop_contenttype = " +
                    ":sop_contenttype where sop_kra_id = :sop_kra_id";
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue(":sop_kra_id", sop_kra_id);
                    cmd.Parameters.AddWithValue(":sop_attachment", sop_attachment);
                    cmd.Parameters.AddWithValue(":sop_filename", sop_filename);
                    cmd.Parameters.AddWithValue(":sop_contenttype", sop_contenttype);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 0;
            return id;
        }

        [WebMethod]
        public int Update_kra(string sop_kra_id, byte[] kra_attachment, string kra_filename, string kra_contenttype)
        {
            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                string query = "update sop_kra_registration set kra_attachment = :kra_attachment, kra_filename = :kra_filename, kra_contenttype = " +
                    ":kra_contenttype where sop_kra_id = :sop_kra_id";
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue(":sop_kra_id", sop_kra_id);
                    cmd.Parameters.AddWithValue(":sop_attachment", kra_attachment);
                    cmd.Parameters.AddWithValue(":sop_filename", kra_filename);
                    cmd.Parameters.AddWithValue(":sop_contenttype", kra_contenttype);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 0;
            return id;
        }

        [WebMethod]
        public int Update_sopkra(string sop_kra_id, byte[] sop_attachment, string sop_filename, string sop_contenttype, byte[] kra_attachment, string kra_filename, string kra_contenttype)
        {
            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                string query = "update sop_kra_registration set sop_attachment = :sop_attachment, sop_filename = :sop_filename, sop_contenttype = " +
                    ":sop_contenttype, kra_attachment = :kra_attachment, kra_filename = :kra_filename, kra_contenttype = :kra_contenttype where sop_kra_id = " +
                    ":sop_kra_id";
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue(":sop_kra_id", sop_kra_id);
                    cmd.Parameters.AddWithValue(":sop_attachment", sop_attachment);
                    cmd.Parameters.AddWithValue(":sop_filename", sop_filename);
                    cmd.Parameters.AddWithValue(":sop_contenttype", sop_contenttype);
                    cmd.Parameters.AddWithValue(":kra_attachment", kra_attachment);
                    cmd.Parameters.AddWithValue(":kra_filename", kra_filename);
                    cmd.Parameters.AddWithValue(":kra_contenttype", kra_contenttype);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 0;
            return id;
        }

        [WebMethod]
        public int Insert_Compliance(string dept_id, string designation, byte[] sop_attachment, string sop_filename, string sop_contenttype, byte[] kra_attachment, string kra_filename, string kra_contenttype)
        {
            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                string query = "insert into sop_kra_registration values (SEQ_SOPKRA.nextval, :dept_id, :designation, :sop_attachment, :sop_filename, " +
                    ":sop_contenttype, :kra_attachment, :kra_filename, :kra_contenttype)";
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue(":dept_id", dept_id);
                    cmd.Parameters.AddWithValue(":designation", designation);
                    cmd.Parameters.AddWithValue(":sop_attachment", sop_attachment);
                    cmd.Parameters.AddWithValue(":sop_filename", sop_filename);
                    cmd.Parameters.AddWithValue(":sop_contenttype", sop_contenttype);
                    cmd.Parameters.AddWithValue(":kra_attachment", kra_attachment);
                    cmd.Parameters.AddWithValue(":kra_filename", kra_filename);
                    cmd.Parameters.AddWithValue(":kra_contenttype", kra_contenttype);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 0;
            return id;
        }
    }
}
