using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pharmacy_Service
{
    /// <summary>
    /// Summary description for CRFService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CRFService : System.Web.Services.WebService
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
        public int Changepassword(string id, string newpwd, string username)
        {
            int res;
            string query = "update LOGIN_USERS set password='" + newpwd + "' where username='" + username + "'";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet ListClinic_Microlab()
        {
            ds = new DataSet();
            string query = "select * from HOSPITAL.CLINIC_MASTER t where  (t.firm_id=16  and t.status_id=1) or t.clinic_id=0";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet ListClinic_Microlab_Pharmacy()
        {
            ds = new DataSet();
            string query = "select t.branch_id,t.name from HOSPITAL.CLINIC_MASTER t where  (t.firm_id=16  and t.status_id=1) or t.clinic_id=0 " +
                           "union all select p.branch_id,p.branch_name name from hospital.pharmacy_master p";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }

        [WebMethod]
        public DataSet ListClinic()
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from HOSPITAL.CLINIC_MASTER t where t.status=1 and t.firm_id=16 and t.branch_type=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int Check_LoginExist(string username, string designation, string branchid)
        {
            string query;
            query = "select userid from login_users where username='" + username + "' and DESIGNATION='" + designation + "' and branchid=" + branchid + "";
            int count = Objorclhelper.executeScalar(query);
            return count;
        }
        [WebMethod]
        public int createLogin(string username, string password, string type, string designation, string mailid, string role, string branchid, string logusername, string enterduserid)
        {
            string query;
            query = "insert into LOGIN_USERS (userid,username,password,type,designation,mailid,role,branchid,log_user,updated_date,entered_by) values(SEQ_LOGIN.nextval,'" + username + "','" + password + "','" + type + "','" + designation + "','" + mailid + "','" + role + "','" + branchid + "','" + logusername + "',sysdate," + enterduserid + ")";
            int res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Select_Userslogin(string branchid)
        {
            ds = new DataSet();
            string query = "select * from LOGIN_USERS where branchid=" + branchid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public void UpdateUser_Status()
        {
            //string query;
            //query = "update LOGIN_USERS set active="+status+" where userid="+userid+"";
            //int res = Objorclhelper.executeNonQuery(query);
            //return res;
        }
        [WebMethod]
        public int UpdateUser_ChangeStatus(int userid, int status)
        {
            string query;
            query = "update LOGIN_USERS set active=" + status + " where userid=" + userid + "";
            int res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int createModule(string module, string desc)
        {
            string query; int res = 0;
            query = "insert into crf_tblmodule values(SEQ_CRFMODULE.nextval,'" + module + "','" + desc + "',1)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int createCRFRequest(string moduleid, string crfname, string desc, string path, string isweb, string iswin, string isapp, string reqdate, string livedate)
        {
            string query; int res = 0;
            query = "insert into crf_tblsubmenu values(seq_crf.nextval," + moduleid + ",'" + crfname + "','" + desc + "','" + path + "'," + isweb + "," + iswin + "," + isapp + ",'" + reqdate + "','" + livedate + "',1,0)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet ListModule()
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from crf_tblmodule t where t.isactive=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet List_CRF(string moduleid)
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from crf_tblsubmenu t where t.isactive=1 and t.moduleid=" + moduleid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet List_UsersbyModule(string type)
        {
            ds = new DataSet();
            string query = "select * from login_users where type in('" + type + "','developer','ithead','itcoordinator','qc')";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int InsertUsage_Users(string userid, string path)
        {
            string query; int res = 0;
            query = "insert into CRF_USAGE values(SEQ_CRFUSAGE.nextval,0,0," + userid + ",'" + path + "',sysdate)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet List_Usage_Count(string frmdt, string todt)
        {
            ds = new DataSet();
            string query = "select md.name Modulename,md.id moduleid,nvl(sum(usg.usage_count),0) UsageCount from crf_tblmodule md left outer join CRF_TBLSUBMENU sub on md.id=sub.moduleid left outer join crf_usage usg on usg.path=sub.path where to_date(usg.updated_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' group by md.name,md.id";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet List_Usage_Count_byuser(string userid, string frmdt, string todt)
        {
            ds = new DataSet();
            string query = "select sub.submenu_name submenu_name,nvl(sum(usg.usage_count),0) usage_count,usg.updated_user,usg.path from  CRF_TBLSUBMENU sub left outer join crf_usage usg on sub.path=usg.path where usg.updated_user=" + userid + " and to_date(usg.updated_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' group by sub.submenu_name,usg.updated_user,usg.path";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }

        [WebMethod]
        public DataSet List_Usage_Count_byuserdetails(string userid, string path, string frmdt, string todt)
        {
            ds = new DataSet();
            string query = "select count(usg.usage_count) usage_count,to_char(trunc(usg.updated_date,'DD')) updated_date from crf_usage usg where usg.updated_user=" + userid + " and usg.path='" + path + "' and to_date(usg.updated_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' group by to_char(trunc(usg.updated_date,'DD'))";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }

        [WebMethod]
        public DataSet List_Usage_details(string id, string frmdt, string todt)
        {
            ds = new DataSet();
            string query = "select sub.submenu_name CRFname,count(usg.usage_count) usagecount,usg.updated_user username from CRF_TBLSUBMENU sub right outer join crf_usage usg on usg.path=sub.path where sub.moduleid='" + id + "' and to_date(usg.updated_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' group by sub.submenu_name,usg.updated_user";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet List_Branches()
        {
            ds = new DataSet();
            string query = "select branch_id,name from hospital.clinic_master where name is not null or name<>'0' union all select branch_id, branch_name name from hospital.pharmacy_master";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int insert_unitmaster(int branch_id, string branch, string type)
        {
            string query; int res = 0;
            query = "insert into macare_unitmaster values(" + branch_id + ",'" + branch + "','" + type + "')";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet List_Branches_grid(string type)
        {
            ds = new DataSet();
            string query = "select * from macare_unitmaster where branch_type='" + type + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int delete_unitmaster(int branch_id)
        {
            string query; int res = 0;
            query = "delete from macare_unitmaster where branch_id=" + branch_id + "";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet List_users(int branch_id, string design)
        {
            ds = new DataSet();
            string query = "select * from login_users where branch_id=" + branch_id + " and designation='" + design + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet List_users_WithId(int userid)
        {
            ds = new DataSet();
            string query = "select * from login_users where userid=" + userid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
    }
}
