using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OracleClient;

namespace Service_ComplianceRegister
{
    /// <summary>
    /// Summary description for Service_ComplianceRegister
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service_ComplianceRegister : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();

        [WebMethod]
        public DataSet Get_login(string username, string password)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from LOGIN_USERS where username='" + username + "' and password='" + password + "'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_depertment()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select dept_id, dept_name from departments order by dept_name ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
        [WebMethod]
        public static void get_p()
        {

        }

        [WebMethod]
        public static List<string> GetEmpNames(string empcode)
        {
            //string strConnectionString = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            string strConnectionString = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True";
            List<string> Emp = new List<string>();
            
            string query = string.Format("SELECT username"+"("+"log_user"+"-"+",designation"+")"+ "FROM login_users WHERE username LIKE '%{0}%'", empcode);
            using (OracleConnection con = new OracleConnection(strConnectionString))
            {
                using (OracleCommand cmd = new OracleCommand(query, con))
                {
                    con.Open();
                    OracleDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Emp.Add(reader.GetString(0));
                    }
                }
            }
            return Emp;
        }

        [WebMethod]
        public DataSet Get_empcode(string empcode)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select username, log_user,designation from login_users where  username like '"+empcode+"%'");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }


        [WebMethod]
        public DataSet Get_verifypending(string type)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select department_id, type, entered_date, submitted_by from compliance_register where verified_by is null and type = '" + type + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_verifypending1(string type)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select c.*, d.dept_name, l.log_user from compliance_register c join " +
                "department_master d on d.dept_id = c.department_id join login_users l on l.username = c.submitted_by where c.verified_by is null and " +
                "c.type = '" + type + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_quarterlyflag()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select case when ((extract(day from sysdate) between 1 and 10) and (extract(month from sysdate) = 1 or extract(month from sysdate) = " +
                "4 or extract(month from sysdate) = 7 or extract(month from sysdate) = 10)) then 1 else 0 end flag from dual ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_monthlyflag()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select case when (extract(day from sysdate) between 1 and 10) then 1 else 0 end flag from dual ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_duplicationflag(string type, string dept_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select case when ((extract(month from to_date(entered_date)) = extract(month from sysdate)) and (extract(year from to_date" +
                "(entered_date)) = extract(year from sysdate)) and type = '" + type + "' and department_id = '" + dept_id + "') then 0 else 1 end flag " +
                "from compliance_register where to_date(entered_date) = (select max(to_date(entered_date)) from compliance_register where type = " +
                "'" + type + "' and department_id = '" + dept_id + "') ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int Insert_Compliance(string dept_id, string type, string submitted_by, byte[] attachment, string file_name, string contenttype, byte[] attachment2, string file_name2, string contenttype2)
        {
            //string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                string query = "insert into compliance_register (department_id, type, entered_date, submitted_by, attachmnet, file_name, contenttype, attachment_2, " +
                    "file_name_2, contenttype_2) values (:department_id, :type, sysdate, :submitted_by, :attachment, :file_name, :contenttype, :attachment2, " +
                    ":file_name2, :contenttype2)";
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con; 
                    cmd.Parameters.AddWithValue(":department_id", dept_id);
                    cmd.Parameters.AddWithValue(":type", type);
                    cmd.Parameters.AddWithValue(":submitted_by", submitted_by);
                    cmd.Parameters.AddWithValue(":attachment", attachment);
                    cmd.Parameters.AddWithValue(":file_name", file_name);
                    cmd.Parameters.AddWithValue(":contenttype", contenttype);
                    cmd.Parameters.AddWithValue(":attachment2", attachment2);
                    cmd.Parameters.AddWithValue(":file_name2", file_name2);
                    cmd.Parameters.AddWithValue(":contenttype2", contenttype2);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            int id = 0;
            return id;
        }

        [WebMethod]
        public DataSet Get_file(string entered_date, string dept_id, string type)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select file_name, attachmnet, contenttype from compliance_register where entered_date = '" + entered_date + "' and department_id = " +
                "'" + dept_id + "' and type = '" + type + "' ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_file2(string entered_date, string dept_id, string type)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select file_name_2, attachment_2, contenttype_2 from compliance_register where entered_date = '" + entered_date + "' and department_id = " +
                "'" + dept_id + "' and type = '" + type + "' and file_name_2 is not null ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_report(string dept_id, string month, string type, string year)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select c.*, d.dept_name, l.log_user from compliance_register c join department_master d on d.dept_id = c.department_id join " +
                "login_users l on l.username = c.submitted_by where c.type = '" + type + "' and c.department_id = '" + dept_id + "' and extract(month " +
                "from to_date(c.entered_date)) = '" + month + "' and extract(year from to_date(c.entered_date)) = '" + year + "' and verified_by is " +
                "not null ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_dashboard(string month, string type, string year)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select d.dept_name, l.log_user, c.*, case when c.attachmnet is null then 'NC' else 'C' end status from department_master d left " +
                "outer join compliance_register c on d.dept_id = c.department_id left outer join login_users l on l.username = c.submitted_by where " +
                "(c.type = '" + type + "' and extract(month from to_date(c.entered_date)) = '" + month + "' and extract(year from to_date" +
                "(c.entered_date)) = '" + year + "') or c.attachmnet is null order by status ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        //[WebMethod]
        //public DataSet Get_file(string entered_date, string dept_id, string type)
        //{
        //    DataSet DS = new DataSet();
        //    //string query = "";
        //    //query = ("select file_name, attachmnet, contenttype from compliance_register where entered_date = '" + entered_date + "' and submitted_by " +
        //    //    "= '" + submitted_by + "' ");
        //    //DS = ObjOrclHelper.ExecuteDataSet(query);
        //    OracleDataAdapter da = new OracleDataAdapter();
        //    string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
        //    using (OracleConnection con = new OracleConnection(constr))
        //    {
        //        using (OracleCommand cmd = new OracleCommand())
        //        {
        //            cmd.CommandText = "select file_name, attachmnet, contenttype from compliance_register where entered_date = '" + entered_date + "' and " +
        //                "department_id = '" + dept_id + "' and type = '" + type + "' ";
        //            cmd.Connection = con;
        //            con.Open();
        //            da.SelectCommand = cmd;

        //            da.Fill(DS);
        //            con.Close();
        //        }
        //    }

        //    return DS;
        //}

        [WebMethod]
        public int Update_Verify(string dept_id, string type, string entered_date, string verified_by, string comments)
        {
            int id = 0;
            string query = "";
            query = ("update compliance_register set verified_by = '" + verified_by + "', verified_date = sysdate, comments " +
                "= '" + comments + "' where department_id = '" + dept_id + "' and type = '" + type + "' and entered_date = '" + entered_date + "' ");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }
    }
}
