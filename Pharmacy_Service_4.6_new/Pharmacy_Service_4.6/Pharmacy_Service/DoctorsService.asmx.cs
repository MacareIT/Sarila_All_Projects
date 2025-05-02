using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pharmacy_Service
{
    /// <summary>
    /// Summary description for DoctorsService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DoctorsService : System.Web.Services.WebService
    {
        public DataSet ds;
        public DataTable dt;
        public OracleHelper Objorclhelper = new OracleHelper();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public int Changepassword(string id, string newpwd,string username)
        {
            int res;
            string query = "update LOGIN_USERS set password='" + newpwd + "' where username='"+username+ "'";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Validate_TaskLogin(string username, string password)
        {
            ds = new DataSet();
            string query = "select * from LOGIN_USERS where username='" + username + "' and password='" + password + "' and active=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Hospital_Departments()
        {
            ds = new DataSet();
            string query = "select t.dept_id, t.dept_name from HOSPITAL.DEPARTMENT t ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public int RegDocvisit(string name, string degree, string deptid, string place, string visiterid,string visitdate,string location_picpath)
        {
            string query; int res = 0;
            query = "insert into DOCTORS_VISIT values(seq_docvisit.nextval,'" + name + "','" + degree + "'," + deptid + ",'" + place + "'," + visiterid + ",'"+visitdate+"','"+location_picpath+"')";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int UpdateDocvisit(string name, string degree, string deptid, string place,string location_picpath,string visitid,string userid)
        {
            string query; int res = 0;
            query = "update DOCTORS_VISIT t set t.doctorname='"+name+"',t.degree='"+degree+"',t.deptid="+deptid+",t.place='"+place+"',t.locationpic='"+location_picpath+"' where t.id="+visitid+" and t.visitorid="+userid+"";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int RegExecutive(string name, string empcode, string branchid, string place, string designation)
        {
            string query; int res = 0;
            query = "insert into MARKETING_EXECUTIVE values(seq_docvisit.nextval,'" + name + "'," + empcode + ",'" + designation + "','" + place + "'," + branchid + ",0)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int createLogin_staff(string empcode,string emailid)
        {
            string query; int res = 0;
            query = "insert into LOGIN_USERS values("+empcode+",'"+empcode+ "','test','salesexecutive','salesexecutive','"+emailid+"','user')";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int update_login(string empcode)
        {
            string query; int res = 0;
            query = "update MARKETING_EXECUTIVE set isactive=1 where empcode="+empcode+"";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Marketing_AllExecutive()
        {
            ds = new DataSet();
            string query = "select * from marketing_executive where isactive=0";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Marketing_AllExecutiveLIST()
        {
            ds = new DataSet();
            string query = "select * from marketing_executive";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Hospital_ALLclinic()
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from HOSPITAL.CLINIC_MASTER t where clinic_id not in (0) and status!=0 and firm_id=16";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet MyReportList(string fromdt, string todt,string userid)
        {
            ds = new DataSet();
            string query = "select t.doctorname name,t.degree,t.place,t1.dept_name department,t.visitdate,t.visitorid,t.LOCATIONPIC,t.id visitid from DOCTORS_VISIT t  join HOSPITAL.DEPARTMENT t1 on t.deptid=t1.dept_id where t.visitorid='" + userid+ "' and t.visitdate between '"+fromdt+"' and '"+todt+ "' order by t.visitdate desc ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet MyVisitList_ID(string id, string userid)
        {
            ds = new DataSet();
            string query = "select t.doctorname name,t.degree,t.place,t1.dept_name department,t.visitdate,t.visitorid,t.LOCATIONPIC,t.id visitid,t1.dept_id from DOCTORS_VISIT t  join HOSPITAL.DEPARTMENT t1 on t.deptid=t1.dept_id where t.visitorid=" + userid + " and t.id =" + id + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet MyReportList_date(string dt,string userid)
        {
            ds = new DataSet();
            string query = "select t.doctorname name,t.degree,t.place,t1.dept_name department,t.visitdate,t.visitorid,t.LOCATIONPIC from DOCTORS_VISIT t  join HOSPITAL.DEPARTMENT t1 on t.deptid=t1.dept_id where t.visitorid="+userid+" and t.visitdate ='"+dt+ "' order by t.visitdate desc";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet ReportList_Mydashboard(string fromdt, string todt, string userid)
        {
            ds = new DataSet();
            string query = "select count(*) VisitCount ,to_char(trunc(t.visitdate,'DD')) DateofVisit from DOCTORS_VISIT t where t.visitorid="+userid+ " and to_date(t.visitdate,'DD-MM-YYYY') between '" + fromdt + "' and '" + todt + "' group by to_char(trunc(t.visitdate,'DD')) order by to_char(trunc(t.visitdate,'DD')) desc";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet ReportList_Admindashboard(string fromdt, string todt)
        {
            ds = new DataSet();
            string query = "select count(*) VisitCount ,to_char(trunc(t.visitdate,'DD')) DateofVisit,me.name,t.visitorid staffid  from DOCTORS_VISIT t join marketing_executive me on me.empcode=t.visitorid where to_date(t.visitdate,'DD-MM-YYYY') between '" + fromdt + "' and '" + todt + "' group by to_char(trunc(t.visitdate,'DD')),me.name,t.visitorid order by to_char(trunc(t.visitdate,'DD')) desc";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet AllReportList(string fromdt, string todt)
        {
            ds = new DataSet();
            string query = "select t.doctorname name,t.degree,t.place,t1.dept_name department,t.visitdate,t.visitorid,me.name executive ,t.LOCATIONPIC from DOCTORS_VISIT t  join HOSPITAL.DEPARTMENT t1 on t.deptid=t1.dept_id join marketing_executive me on t.visitorid=me.empcode where  t.visitdate between '" + fromdt + "' and '" + todt + "' ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int DoctorVisitCount(string fromdt, string todt)
        {
            int count=0;
            ds = new DataSet();
            string query = "select t.doctorname name,t.degree,t.place,t1.dept_name department,t.visitdate,t.visitorid  from DOCTORS_VISIT t  join HOSPITAL.DEPARTMENT t1 on t.deptid=t1.dept_id where  t.visitdate between '" + fromdt + "' and '" + todt + "' ";
            ds = Objorclhelper.ExecuteDataset(query);
            return count;

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
