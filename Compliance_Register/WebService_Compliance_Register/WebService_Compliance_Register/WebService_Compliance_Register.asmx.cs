using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OracleClient;

namespace WebService_Compliance_Register
{
    /// <summary>
    /// Summary description for WebService_Compliance_Register
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_Compliance_Register : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
      
        [WebMethod]
        public DataSet Get_login(string username, string password)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from LOGIN_USERS where username='" + username + "' and password='" + password + "' and active=1");
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
        public DataSet Get_grid()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select com_dept.dept_id,dep.dept_name,com_dept.dept_head,log_usr.log_user from compliance_dept_register com_dept join departments dep on com_dept.dept_id=dep.dept_id " +
                "join login_users log_usr on log_usr.username = com_dept.dept_head where com_dept.status = 1");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_gridbyid(int dept_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from compliance_dept_register where com_dept.dept_id ="+dept_id);
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public  List<string> GetEmpNames(string empcode)
        {
            string strConnectionString = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string strConnectionString = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True";
            List<string> Emp = new List<string>();

            string query = string.Format("SELECT username||'('||log_user||'-'||designation||')' FROM login_users WHERE username LIKE '%{0}%'", empcode);
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
            query = string.Format("SELECT username,username||'('||log_user||'-'||designation||')' name FROM login_users WHERE username LIKE '%{0}%'", empcode);
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int Insert_Compliance_Reg(int dept_id, string dept_head,int status)
        {
            int id = 0;
            string query = "";
            query= "delete from COMPLIANCE_DEPT_REGISTER where dept_id="+dept_id+"";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            query = "insert into COMPLIANCE_DEPT_REGISTER values (" + dept_id + ",'" + dept_head + "'," + status + ")";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Insert_Compliance_Calendar(int dept_id, string Com_type, string Comp_Description, string duratn_type, string due_date,string alert_date)
        {
            int id = 0;
            string query = "";
            query = "select max(com_id)+1 from COMPLIANCE_CALENDER";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id =Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into COMPLIANCE_CALENDER values ("+id+"," + dept_id + ",'" + Com_type + "','" + Comp_Description + "','" + duratn_type + "','"+due_date+"','"+alert_date+"',1,'Not Complied')";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Get_grid_Calendar(int dept_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from compliance_calender cc join departments dep on cc.dept_id=dep.dept_id where cc.dept_id = "+dept_id+" and cc.status = 1");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int Update_Compliance_Calendar(int com_id,int dept_id, string Com_type, string Comp_Description, string duratn_type,string due_date,string alert_date)
        {
            int id = 0;
            string query = "";
            query = "update COMPLIANCE_CALENDER set dept_id=" + dept_id + ",com_type='" + Com_type + "',com_desc='" + Comp_Description + "',duration_type='" + duratn_type + "',due_date='"+due_date+"',alert_on='"+alert_date+"'  where com_id="+com_id+"";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Delete_Compliance_Calendar(int com_id)
        {
            int id = 0;
            string query = "";
            query = "update COMPLIANCE_CALENDER set status=0 where com_id=" + com_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Select_Compliance_type(int dept_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = "select distinct com_type from compliance_calender where dept_id="+dept_id+"";
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Select_Compliance_REG(int dept_id,string com_type)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (com_type == "Internal")
            {
                query = "select a.com_id,b.com_desc from compliance_register_internal a join compliance_calender b on a.com_id=b.com_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<>to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') " +
                    "and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and b.dept_id="+dept_id+" union select com_id,com_desc from compliance_calender where com_id not in(select distinct com_id from compliance_register_internal) " +
                    "and com_type = 'Internal' and status = 1 and com_status='Not Complied' and dept_id="+dept_id+"";
            }
            else
            {
                // query = "select cal.com_id,cal.com_desc from COMPLIANCE_CALENDER cal where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and cal.com_status = 'Not Complied' and cal.dept_id = " + dept_id + " and cal.duration_type in ('Annually','Quarterly') and cal.status=1";
                query = "select cal.com_id,cal.com_desc from COMPLIANCE_CALENDER cal where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and cal.com_status = 'Not Complied' and cal.dept_id = "+dept_id+" and cal.duration_type in ('Annually','Quarterly') and cal.status=1 union select a.com_id,b.com_desc " +
                     "from compliance_register_statutory a join compliance_calender b on a.com_id = b.com_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') " +
                     "and b.dept_id = "+dept_id+" and b.com_status = 'Not Complied' union select com_id,com_desc from compliance_calender where com_id not in(select distinct com_id from compliance_register_statutory) and com_type = 'Statutory' and duration_type = 'Monthly' and status = 1 and com_status = 'Not Complied' and dept_id = "+dept_id+"";
                //SELECT EXTRACT(DAY FROM sysdate) FROM DUAL where EXTRACT(DAY FROM sysdate) between 1 and 15;
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Select_Compliance_Dashboard(int dept_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (dept_id > 0)
            {
                    
                //query = "select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from COMPLIANCE_CALENDER cal join departments d on cal.dept_id=d.dept_id where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and to_date(cal.due_date,'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy') and cal.com_status = 'Not Complied' " +
                //    " and cal.duration_type in ('Annually', 'Quarterly','Half Yearly') and cal.status = 1 and d.dept_id=" + dept_id+" union select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Over Due' status from COMPLIANCE_CALENDER cal join departments d on cal.dept_id = d.dept_id where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and to_date(cal.due_date,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') " +
                //    "and cal.com_status = 'Not Complied'  and cal.duration_type in ('Annually', 'Quarterly','Half Yearly') and cal.status = 1 and d.dept_id=" + dept_id + " union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_register_statutory a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') " +
                //    "and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and b.com_status = 'Not Complied' and duration_type = 'Monthly' and b.status = 1 and d.dept_id=" + dept_id + " and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) between 1 and 11 union select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from compliance_calender cal join departments d on cal.dept_id = d.dept_id " +
                //    "where com_id not in(select distinct com_id from compliance_register_statutory) and com_type = 'Statutory' and duration_type = 'Monthly' and cal.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 11 and d.dept_id=" + dept_id + " union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Over Due' status from compliance_register_statutory a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id " +
                //    "where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and b.com_status = 'Not Complied' and duration_type = 'Monthly' and b.status = 1 and d.dept_id=" + dept_id + " and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) not between 1 and 11 union select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Over Due' status " +
                //    "from compliance_calender cal join departments d on cal.dept_id = d.dept_id where com_id not in(select distinct com_id from compliance_register_statutory) and com_type = 'Statutory' and duration_type = 'Monthly' and cal.status = 1 and d.dept_id=" + dept_id + " and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) not between 1 and 11 union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_register_internal a join compliance_calender b on a.com_id = b.com_id " +
                //    "join departments d on b.dept_id = d.dept_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) between 1 and 5 and d.dept_id=" + dept_id + " union select b.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_calender b join departments d on b.dept_id = d.dept_id " +
                //    "where com_id not in(select distinct com_id from compliance_register_internal) and com_type = 'Internal' and b.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 5 and d.dept_id=" + dept_id + " union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Over Due' status from compliance_register_internal a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id " +
                //    "where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) not between 1 and 5 and d.dept_id=" + dept_id + " union select b.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Over Due' status from compliance_calender b join departments d on b.dept_id = d.dept_id where com_id not in(select distinct com_id " +
                //    "from compliance_register_internal) and com_type = 'Internal' and b.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) not between 1 and 5 and d.dept_id=" + dept_id + "";

            }
            else
            {
                // query = "select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from COMPLIANCE_CALENDER cal join departments d on cal.dept_id=d.dept_id where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and to_date(cal.due_date,'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy') and cal.com_status = 'Not Complied' " +
                //" and cal.duration_type in ('Annually','Quarterly','Half Yearly') and cal.status = 1 union select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Over Due' status from COMPLIANCE_CALENDER cal join departments d on cal.dept_id = d.dept_id where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and to_date(cal.due_date,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') " +
                //"and cal.com_status = 'Not Complied' and cal.duration_type in ('Annually', 'Quarterly','Half Yearly') and cal.status = 1 union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_register_statutory a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') " +
                //"and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and b.com_status = 'Not Complied' and duration_type = 'Monthly' and b.status = 1 and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) between 1 and 11 union select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from compliance_calender cal join departments d on cal.dept_id = d.dept_id " +
                //"where com_id not in(select distinct com_id from compliance_register_statutory) and com_type = 'Statutory' and duration_type = 'Monthly' and cal.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 11 union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Over Due' status from compliance_register_statutory a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id " +
                //"where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and b.com_status = 'Not Complied' and duration_type = 'Monthly' and b.status = 1 and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) not between 1 and 11 union select cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Over Due' status " +
                //"from compliance_calender cal join departments d on cal.dept_id = d.dept_id where com_id not in(select distinct com_id from compliance_register_statutory) and com_type = 'Statutory' and duration_type = 'Monthly' and cal.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) not between 1 and 11 union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_register_internal a join compliance_calender b on a.com_id = b.com_id " +
                //"join departments d on b.dept_id = d.dept_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) between 1 and 5 union select b.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_calender b join departments d on b.dept_id = d.dept_id " +
                //"where com_id not in(select distinct com_id from compliance_register_internal) and com_type = 'Internal' and b.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 5 union select a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Over Due' status from compliance_register_internal a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id " +
                //"where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) not between 1 and 5 union select b.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Over Due' status from compliance_calender b join departments d on b.dept_id = d.dept_id where com_id not in(select distinct com_id " +
                //"from compliance_register_internal) and com_type = 'Internal' and b.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) not between 1 and 5";
                //query = "select distinct cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from COMPLIANCE_CALENDER cal join departments d on cal.dept_id=d.dept_id where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and to_date(cal.due_date,'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy') and cal.com_status = 'Not Complied' and cal.duration_type in ('Annually', 'Quarterly', 'Half Yearly') and cal.status = 1 union select distinct a.com_id,d.dept_id,d.dept_name," +
                //    "b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_register_statutory a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and b.com_status = 'Not Complied' and duration_type = 'Monthly' and b.status = 1 " +
                //    "and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) between 1 and 11 union select distinct cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from compliance_calender cal join departments d on cal.dept_id = d.dept_id where com_id not in(select distinct com_id from compliance_register_statutory) and com_type = 'Statutory' and duration_type = 'Monthly' and cal.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 11 " +
                //    "union select distinct a.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_register_internal a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) " +
                //    "between 1 and 5 and a.com_id not in (select distinct aa.com_id from compliance_register_internal aa where to_char(to_date(aa.entered_date, 'DD-MM-YYYY'), 'Month')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(aa.entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and EXTRACT(DAY FROM to_date(aa.entered_date,'dd-MM-yyyy')) between 1 and 5) union select distinct b.com_id,d.dept_id,d.dept_name,b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from " +
                //    "compliance_calender b join departments d on b.dept_id = d.dept_id where com_id not in(select distinct com_id from compliance_register_internal) and com_type = 'Internal' and b.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 5 ";
                query = "select distinct cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from COMPLIANCE_CALENDER cal join departments d on cal.dept_id = d.dept_id where to_date(cal.alert_on,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') and to_date(cal.due_date,'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy') and cal.com_status = 'Not Complied' and cal.duration_type in ('Annually', 'Quarterly', 'Half Yearly') and cal.status = 1 union select distinct a.com_id,d.dept_id,d.dept_name," +
                    "b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_register_statutory a join compliance_calender b on a.com_id = b.com_id join departments d on b.dept_id = d.dept_id where to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Month')<> to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and b.com_status = 'Not Complied' and duration_type = 'Monthly' and b.status = 1 and EXTRACT(DAY FROM to_date(entered_date,'dd-MM-yyyy')) between 1 and 11 " +
                    "union select distinct cal.com_id,d.dept_id,d.dept_name,cal.com_type,cal.com_desc,cal.duration_type,cal.due_date,'Not Complied' status from compliance_calender cal join departments d on cal.dept_id = d.dept_id where com_id not in(select distinct com_id from compliance_register_statutory) and com_type = 'Statutory' and duration_type = 'Monthly' and cal.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 11 union select distinct c.com_id,d.dept_id,d.dept_name,c.com_type,c.com_desc,c.duration_type,c.due_date,'Not Complied' status " +
                    "from compliance_calender c join departments d on d.dept_id = c.dept_id where c.status = 1 and d.status = 1 and com_type = 'Internal' and c.com_id not in (select t.com_id from COMPLIANCE_REGISTER_INTERNAL t  where t.status = 1 and to_char(to_date(t.entered_date, 'DD-MM-YYYY'), 'Month')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Month') and to_char(to_date(t.entered_date, 'DD-MM-YYYY'), 'Year')= to_char(to_date(sysdate, 'DD-MM-YYYY'), 'Year') and EXTRACT(DAY FROM to_date(t.entered_date,'dd-MM-yyyy')) between 1 and 5) union select distinct b.com_id,d.dept_id,d.dept_name," +
                    "b.com_type,b.com_desc,b.duration_type,b.due_date,'Not Complied' status from compliance_calender b join departments d on b.dept_id = d.dept_id where com_id not in(select distinct com_id from compliance_register_internal) and com_type = 'Internal' and b.status = 1 and com_status = 'Not Complied' and EXTRACT(DAY FROM sysdate) between 1 and 5";
            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int Insert_Compliance_internal(int com_id, string entered_by, string entered_date, string verified_head,string head_verify_date,string verified_cs,string cs_verify_date,int comp_status,string remarks, byte[] attachment1, string file_name1, string contenttype1,int status)
        {
            int id = 0;int s = 0;
            string query1 = "";

            query1 = "select max(com_reg_id)+1 from compliance_register_internal";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query1).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());

            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                string query = "insert into compliance_register_internal(com_reg_id,com_id,entered_by, entered_date, verified_head,head_verify_date,verified_cs,cs_verify_date,attachment1, filename1, content_type1,status) values" +
                    "(:com_reg_id,:com_id,:entered_by,:entered_date,:verified_head,:head_verify_date,:verified_cs,:cs_verify_date,:attachment1,:filename1,:content_type1,:status)";
                    //"file_name_2, contenttype_2) values (:department_id, :type, sysdate, :submitted_by, :attachment, :file_name, :contenttype, :attachment2, " +
                    //":file_name2, :contenttype2)";
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue(":com_reg_id", id);
                    cmd.Parameters.AddWithValue(":com_id", com_id);
                    cmd.Parameters.AddWithValue(":entered_by", entered_by);
                    cmd.Parameters.AddWithValue(":entered_date", entered_date);
                    cmd.Parameters.AddWithValue(":verified_head", verified_head);
                    cmd.Parameters.AddWithValue(":head_verify_date", head_verify_date);
                    cmd.Parameters.AddWithValue(":verified_cs", verified_cs);
                    cmd.Parameters.AddWithValue(":cs_verify_date", cs_verify_date);
                    cmd.Parameters.AddWithValue(":attachment1", attachment1);
                    cmd.Parameters.AddWithValue(":filename1", file_name1);
                    cmd.Parameters.AddWithValue(":content_type1", contenttype1);
                    cmd.Parameters.AddWithValue(":status", status);
                    con.Open();
                    s=cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //int id1 = 0;
            return s;
        }

        [WebMethod]
        public int Insert_Compliance_statutory(int com_id, string entered_by, string entered_date, string verified_head, string head_verify_date, string verified_cs, string cs_verify_date, int comp_status, string remarks, byte[] attachment1, string file_name1, string contenttype1, int status)
        {
            int id = 0; int s = 0;
            string query1 = "";

            query1 = "select max(com_reg_id)+1 from compliance_register_statutory";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query1).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());

            string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
            //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
            using (OracleConnection con = new OracleConnection(constr))
            {
                string query = "insert into compliance_register_statutory(com_reg_id,com_id,entered_by, entered_date, verified_head,head_verify_date,verified_cs,cs_verify_date,attachment1, filename1, content_type1,status) values" +
                    "(:com_reg_id,:com_id,:entered_by,:entered_date,:verified_head,:head_verify_date,:verified_cs,:cs_verify_date,:attachment1,:filename1,:content_type1,:status)";
                //"file_name_2, contenttype_2) values (:department_id, :type, sysdate, :submitted_by, :attachment, :file_name, :contenttype, :attachment2, " +
                //":file_name2, :contenttype2)";
                using (OracleCommand cmd = new OracleCommand(query))
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue(":com_reg_id", id);
                    cmd.Parameters.AddWithValue(":com_id", com_id);
                    cmd.Parameters.AddWithValue(":entered_by", entered_by);
                    cmd.Parameters.AddWithValue(":entered_date", entered_date);
                    cmd.Parameters.AddWithValue(":verified_head", verified_head);
                    cmd.Parameters.AddWithValue(":head_verify_date", head_verify_date);
                    cmd.Parameters.AddWithValue(":verified_cs", verified_cs);
                    cmd.Parameters.AddWithValue(":cs_verify_date", cs_verify_date);
                    cmd.Parameters.AddWithValue(":attachment1", attachment1);
                    cmd.Parameters.AddWithValue(":filename1", file_name1);
                    cmd.Parameters.AddWithValue(":content_type1", contenttype1);
                    cmd.Parameters.AddWithValue(":status", status);
                    con.Open();
                    s = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //int id1 = 0;
            return s;
        }


        [WebMethod]
        public int update_Compliance_status(int com_id)
        {
            int id = 0;
            string query = "";
            query = "update COMPLIANCE_CALENDER set com_status='Complied' where com_id=" + com_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Select_com_Register(int dept_id, string com_type)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (com_type == "Internal")
                query = "select * from COMPLIANCE_REGISTER_INTERNAL t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and c.com_type='" + com_type + "' and c.dept_id=" + dept_id + " and c.com_status='Complied' and t.verified_head is null";
            else query = "select * from COMPLIANCE_REGISTER_STATUTORY t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and c.com_type='" + com_type + "' and c.dept_id=" + dept_id + " and c.com_status='Complied' and t.verified_head is null";
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_file(int com_reg_id,string type_)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (type_ == "Internal")
                query = ("select filename1, attachment1, content_type1 from compliance_register_internal where com_reg_id="+com_reg_id);
            else if(type_=="Statutory")
                query = ("select filename1, attachment1, content_type1 from compliance_register_statutory where com_reg_id=" + com_reg_id);
            else
            {

            }
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Select_for_HeadVerifn(int dept_id,string com_type)
        {
            DataSet DS = new DataSet();
       
            string query = "";
            if (com_type == "Internal")
                query = "select t.com_reg_id,t.com_id,t.entered_by,t.entered_date,c.com_type,c.com_desc,t.verified_head,t.head_verify_date,t.attachment1,t.filename1,t.content_type1 from COMPLIANCE_REGISTER_INTERNAL t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and verified_head is null and c.dept_id=" + dept_id+"";
           else
            query = "select t.com_reg_id,t.com_id,t.entered_by,t.entered_date,c.com_type,c.com_desc,t.verified_head,t.head_verify_date,t.attachment1,t.filename1,t.content_type1 from COMPLIANCE_REGISTER_STATUTORY t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and verified_head is null and c.dept_id=" + dept_id + "";
            DS = ObjOrclHelper.ExecuteDataSet(query);
        
            return DS;
        }

        [WebMethod]
        public DataSet Select_for_CSVerifn(string com_type)
        {
            DataSet DS = new DataSet();
            string query = "";
            if(com_type=="Internal")
               query = "select * from COMPLIANCE_REGISTER_INTERNAL t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and verified_cs is null and c.com_status='Complied' order by to_date(t.entered_date,'dd-MM-yyyy'),d.dept_id";
            else query = "select * from COMPLIANCE_REGISTER_STATUTORY t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and verified_cs is null and c.com_status='Complied'";
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
            //query = "select * from COMPLIANCE_REGISTER_INTERNAL t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and verified_head is not null and verified_cs is null and c.com_status='Complied'";
            //else query = "select * from COMPLIANCE_REGISTER_STATUTORY t join compliance_calender c on t.com_id=c.com_id join departments d on d.dept_id=c.dept_id where t.status = 1 and c.status = 1 and d.status = 1 and verified_head is not null and verified_cs is null and c.com_status='Complied'";
        }

        [WebMethod]
        public int Delete_Compliance_Register(int com_reg_id,string status)
        {
            int id = 0;
            string query = "";
            if (status == "Internal")
                query = "update COMPLIANCE_REGISTER_INTERNAL set status=0 where com_reg_id=" + com_reg_id + "";
            else
                query = "update COMPLIANCE_REGISTER_STATUTORY set status=0 where com_reg_id=" + com_reg_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int update_Compliance_status_back(int com_id)
        {
            int id = 0;
            string query = "";
            query = "update COMPLIANCE_CALENDER set com_status='Not Complied' where com_id=" + com_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Update_Verify_Head(int com_reg_id, string verified_by,string type)
        {
            int id = 0;
            string query = "";
            if(type=="Internal")
                 query = "update compliance_register_internal set verified_head = '" + verified_by + "', Head_verify_date = sysdate " +
                          "where com_reg_id = " + com_reg_id + "";
            else
                 query= "update compliance_register_statutory set verified_head = '" + verified_by + "', Head_verify_date = sysdate " +
                          "where com_reg_id = " + com_reg_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Update_Verify_CS(int com_reg_id, string verified_by, string type)
        {
            int id = 0;
            string query = "";
            if (type == "Internal")
                query = "update compliance_register_internal set verified_cs = '" + verified_by + "', cs_verify_date = sysdate " +
                         "where com_reg_id = " + com_reg_id + "";
            else
                query = "update compliance_register_statutory set verified_cs = '" + verified_by + "', cs_verify_date = sysdate " +
                         "where com_reg_id = " + com_reg_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }
        [WebMethod]
        public DataSet Select_Head_dept(string emp_code)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = "select * from COMPLIANCE_DEPT_REGISTER  where dept_head='" + emp_code + "'";
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Select_for_Report(string com_type, int dept_id)
        {
            DataSet DS = new DataSet();
            string query = "";
            if (com_type == "Internal")
                query = "select dep.dept_name,com.com_type,com.com_desc,com.duration_type,reg.entered_by,u.log_user,reg.entered_date,reg.cs_verify_date,reg.com_reg_id " +
                    "from departments dep join compliance_calender com on dep.dept_id = com.dept_id join compliance_register_internal reg on reg.com_id = com.com_id join login_users u on " +
                    "u.username = reg.entered_by where reg.status = 1 and com.status = 1  and dep.status = 1 and dep.dept_id = "+dept_id+ " order by to_date(reg.entered_date,'dd-MM-yyyy') desc ";
            else query = "select dep.dept_name,com.com_type,com.com_desc,com.duration_type,reg.entered_by,u.log_user,reg.entered_date,reg.cs_verify_date,reg.com_reg_id " +
                    "from departments dep join compliance_calender com on dep.dept_id = com.dept_id join compliance_register_statutory reg on reg.com_id = com.com_id join login_users u on " +
                    "u.username = reg.entered_by where reg.status = 1 and com.status = 1  and dep.status = 1 and dep.dept_id = "+dept_id+ " order by to_date(reg.entered_date,'dd-MM-yyyy') desc ";

            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int update_Compliance_afterverify(int com_id,string due_date,string alert_on)
        {
            int id = 0;
            string query = "";
            query = "update COMPLIANCE_CALENDER set com_status='Not Complied',due_date='"+due_date+"',alert_on='"+alert_on+"' where com_id=" + com_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Insert_AgreementRenewal(int agrmnt_id, string agrmnt_type, string agrmnt_party, string date_of_exectn, string next_renewal, string first_alert,string second_alert,string third_alert,string updated_on,string updated_by)
        {
            int id = 0;
            string query = "";
            query = "select max(agrmnt_id)+1 from AGREEMENT_RENEWAL";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into AGREEMENT_RENEWAL values ("+agrmnt_id+",'"+agrmnt_type+"','"+agrmnt_party+"','"+date_of_exectn+"','"+next_renewal+"','"+first_alert+"','"+second_alert+"','"+third_alert+"','"+updated_on+"','"+updated_by+"')";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int update_AgreementRenewal(int agrmnt_id, string agrmnt_type, string agrmnt_party, string date_of_exectn, string next_renewal, string first_alert, string second_alert, string third_alert, string updated_on, string updated_by)
        {
            int id = 0;
            string query = "";
            query = "update AGREEMENT_RENEWAL set agrmnt_type='"+agrmnt_type+"',agrmnt_party='" +agrmnt_party+ "',date_of_execution='" +date_of_exectn+ "',next_renewal='"+next_renewal+"',first_alert='"+first_alert+"',second_alert='"+second_alert+"',third_alert='"+third_alert+"',updated_on='"+updated_on+"',updated_by='"+updated_by+"' where agrmnt_id=" + agrmnt_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Get_grid_Agrmnt_renewal()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from AGREEMENT_RENEWAL");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int Insert_Usage(string username)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into module_usage_log values ('Compliance Register', '" + username + "', sysdate)");
            return id;
        }
    }
}
