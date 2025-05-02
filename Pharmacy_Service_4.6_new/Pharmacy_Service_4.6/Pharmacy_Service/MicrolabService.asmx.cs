using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pharmacy_Service
{
    /// <summary>
    /// Summary description for MicrolabService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MicrolabService : System.Web.Services.WebService
    {
        public DataSet ds;
        public DataTable dt;
        public OracleHelper Objorclhelper = new OracleHelper();

        [WebMethod]
        public DataSet Validate_TaskLogin(string username, string password)
        {
            ds = new DataSet();
            string query = "select * from LOGIN_USERS where username='" + username + "' and password='" + password + "' and active=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Hospital_MicrolabList()
        {
            ds = new DataSet();
            string query = "select * from hospital.clinic_master cm where cm.firm_id=16 and cm.clinic_id not in (37,14,18) and  cm.branch_type =4 union select * from hospital.clinic_master cmm where cmm.clinic_id=2";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Emrm_doctordeskDetails(string branchid, string fromdt, string todate, string userid, string typ)
        {
            ds = new DataSet();
            string query;
            if (typ == "user")
            {
                query = "select cust.branch_id,cust.custname,cust.address,cust.phone_no_1,cust.collected_by,cust.age,cust.gender,cust.entered_date,cust.user_id,emp.emp_name staffname from hospital.emrm_tble_custneed cust join hospital.employee_master emp on cust.collected_by = emp.emp_code where to_date(cust.entered_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todate + "' and cust.branch_id=" + branchid + " and cust.user_id=" + userid + "";
            }
            else
            {
                query = "select cust.branch_id,cust.custname,cust.address,cust.phone_no_1,cust.collected_by,cust.age,cust.gender,cust.entered_date,cust.user_id,emp.emp_name staffname from hospital.emrm_tble_custneed cust join hospital.employee_master emp on cust.collected_by = emp.emp_code where to_date(cust.entered_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todate + "' and cust.branch_id=" + branchid + "";
            }
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int Regcustomer(string name, string address, string phone, string age, string sex, string place, string userid, string branchid)
        {
            string query; int res = 0;
            query = "insert into LAB_DOCTORDESK values(seq_docdesk.nextval,'" + name + "','" + address + "','" + phone + "','" + age + "','" + sex + "','" + place + "'," + userid + "," + branchid + ")";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int updateUsage(string path, string userid)
        {
            //string query; int res = 0;
            //query = "update  CRF_USAGE set USAGE_COUNT=USAGE_COUNT+1,UPDATED_DATE=sysdate  where UPDATED_USER=" + userid + " and path='" + path + "'";
            //res = Objorclhelper.executeNonQuery(query);
            //return res;
            string query; int res = 0;
            query = "insert into CRF_USAGE values(SEQ_CRFUSAGE.nextval,0,1," + userid + ",'" + path + "',sysdate)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
    }
    }
