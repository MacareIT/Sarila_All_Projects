using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OracleClient;

namespace WebService_CustComplaint
{
    /// <summary>
    /// Summary description for WebService_CustComplaint
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_CustComplaint : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        DataSet ObjDataSet = new DataSet();
        DataTable ObjDatatb = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod()]
        public DataSet Login(string u_name, string pswd)
        {
            DataSet ds;
            ds = ObjOrclHelper.ExecuteDataSet("select user_id,user_privilege from Users_Login where user_name='" + u_name + "' and user_pswd='" + pswd + "'");
            return ds;
        }

        [WebMethod()]
        public string Customer_Complaint_insert(string Cust_Name, string Cust_Mob, string Department,
                                       string Email, string compalint, string replay)
        {

            OracleParameter[] pr = new OracleParameter[7];

            pr[0] = new OracleParameter("Prm_Customer_Name", OracleType.NVarChar);
            pr[0].Value = Cust_Name;
            pr[0].Direction = ParameterDirection.Input;

            pr[1] = new OracleParameter("Prm_Customer_Mob", OracleType.NVarChar);
            pr[1].Value = Cust_Mob;
            pr[1].Direction = ParameterDirection.Input;

            pr[2] = new OracleParameter("Prm_Department", OracleType.NVarChar);
            pr[2].Value = Department;
            pr[2].Direction = ParameterDirection.Input;

            pr[3] = new OracleParameter("Prm_Email", OracleType.NVarChar);
            pr[3].Value = Email;
            pr[3].Direction = ParameterDirection.Input;

            pr[4] = new OracleParameter("Prm_Complaint", OracleType.NVarChar);
            pr[4].Value = compalint;
            pr[4].Direction = ParameterDirection.Input;

            pr[5] = new OracleParameter("Prm_Replay", OracleType.NVarChar);
            pr[5].Value = replay;
            pr[5].Direction = ParameterDirection.Input;

            pr[6] = new OracleParameter("Prm_Message", OracleType.NVarChar, 1000);
            pr[6].Direction = ParameterDirection.Output;

            ObjOrclHelper.ExecuteDataSet("PROC_Customer_ComplaintInsert", pr);

            string message = pr[6].Value.ToString();

            return message;
        }

        [WebMethod()]
        public string Customer_Complaint_replay(int Complaint_Id, string Replay)
        {
            OracleParameter[] pr = new OracleParameter[3];

            pr[0] = new OracleParameter("Prm_Complaint_Id", OracleType.Number);
            pr[0].Value = Complaint_Id;
            pr[0].Direction = ParameterDirection.Input;

            pr[1] = new OracleParameter("Prm_Replay", OracleType.NVarChar);
            pr[1].Value = Replay;
            pr[1].Direction = ParameterDirection.Input;

            pr[2] = new OracleParameter("Prm_Message", OracleType.NVarChar, 1000);
            pr[2].Direction = ParameterDirection.Output;

            ObjOrclHelper.ExecuteDataSet("PROC_Customer_ComplaintReplay", pr);

            string message = pr[2].Value.ToString();

            return message;
        }

        [WebMethod()]
        public DataSet All_ComplaintSelect()
        {
            OracleParameter[] pr = new OracleParameter[2];
            pr[0] = new OracleParameter("Prm_Message", OracleType.NVarChar, 1000);
            pr[0].Direction = ParameterDirection.Output;

            pr[1] = new OracleParameter("Prm_Cursor", OracleType.Cursor);
            pr[1].Direction = ParameterDirection.Output;

            DataSet ds = ObjOrclHelper.ExecuteDataSet("PROC_Customer_ComplaintSelect", pr);

            //string message = pr[2].Value.ToString();

            return ds;
        }
    }
}
