using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace WebService_CRFTracker
{
    /// <summary>
    /// Summary description for WebService_CRFTracker
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_CRFTracker : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod()]
        public DataSet Login(string u_name, string pswd)
        {
            DataSet ds;
            ds = ObjOrclHelper.ExecuteDataSet("select a.*,b.name branch from Login_users a join hospital.clinic_master b on a.branchid=b.branch_id where username ='" + u_name + "' and password='" + pswd + "'");
            return ds;
        }

        //for getting the crfid
        [WebMethod()]
        public DataSet Get_CrfId()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select 'MAC'||seq_createcrf.nextval from dual");
            return DS;
        }

        //create a new crf (insert value to TASKMNG_NEWCRF)
        [WebMethod]
        public int Insert_NewCrf(string crf_id, string crf_name, string crf_description, string req_type, string priority, string crf_scope, string reference_name, string requestor_id, string requestor_name, string status,string designation)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into TASKMNG_NEWCRF( crf_id, crf_name, crf_description, req_type, priority, crf_scope, reference_doc,REQUESTED_DATE,REQUESTOR_ID,REQUESTOR_NAME,crf_status,reporting_head,designation) " +
                "values('" + crf_id + "','" + crf_name + "','" + crf_description + "','" + req_type + "','" + priority + "','" + crf_scope + "','" + reference_name + "',sysdate,'" + requestor_id + "','" + requestor_name + "','" + status + "','0','"+designation+"')");
            return id;
        }

        [WebMethod]
        public DataSet Get_Crf()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Crf_WithotId()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF");
            return DS;
        }

        [WebMethod]
        public DataSet Get_CrfwithId(string category)
        {
            DataSet DS = new DataSet();
            if (category == "Delayed")
                DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_id||'-'||crf_name as crf_name from TASKMNG_NEWCRF where crf_status!='User Confirmed' and head_remarks='Delayed'");
            if (category == "In Progress")
                DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_id||'-'||crf_name as crf_name from TASKMNG_NEWCRF where crf_status='Development Started' or crf_status='Development Completed' or crf_status='QA Started' " +
                    "or crf_status='QA Completed' or crf_status='UAT Started' or crf_status='UAT Completed' or crf_status='UAT Confirmed' and head_remarks='In Progress'");
            else if (category == "Live & Closed")
                DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_id||'-'||crf_name as crf_name from TASKMNG_NEWCRF where crf_status='User Confirmed'");
            else if(category=="All")
                DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_id||'-'||crf_name as crf_name from TASKMNG_NEWCRF");
            else
                DS= ObjOrclHelper.ExecuteDataSet("select crf_id,crf_id||'-'||crf_name as crf_name from TASKMNG_NEWCRF where crf_status='"+category+"'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_CrfDtls(string crfid)
        {
            DataSet DS = new DataSet();
            if (crfid == "0")
            {
                DS = ObjOrclHelper.ExecuteDataSet("select * from TASKMNG_NEWCRF");
            }
            else
            {
                DS = ObjOrclHelper.ExecuteDataSet("select * from TASKMNG_NEWCRF where crf_id='" + crfid + "'");
            }
            return DS;
        }

        [WebMethod]
        public DataSet Get_Crf_forRecommend()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF where crf_status like '%Requested%'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_CrfRecommend()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF where crf_status='Coordinator Recommended'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Crf_forApprove()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF where crf_Status='Coordinator Recommended'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_CrfApprove()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF where crf_Status='Cfo Approved'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Crf_forTA()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF where crf_Status='Cfo Approved' or crf_status='TA Completed'");
            return DS;
        }

        [WebMethod()]
        public DataSet Get_ta(string crfid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select ta.crf_id,ta.phase,ta.taskname,ta.manhours,ta.startdate,ta.enddate,ta.ta_id,u.log_user,ta.developer,ta.work_status " +
                                              "from TASKMNG_TA ta left outer join login_users u on ta.developer=u.username where crf_id='" + crfid + "' ORDER BY CASE WHEN ta.phase = 'Design' THEN 1 " +
                                              "WHEN ta.phase = 'Back End' THEN 2 WHEN ta.phase = 'Coding' THEN 3 ELSE 4 END ");
            return DS;
        }
        
        [WebMethod]
        public DataSet Get_Crfforaddta()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_id||'-'||crf_name as crf_name from TASKMNG_NEWCRF where crf_status like '%Cfo Approved' or crf_status in ('TA Completed')");
            return DS;
        }

        [WebMethod]
        public int Update_CRFwithTA(string crfid, string dev_startdate, string dev_enddate, string target_date, string manhours,string QA_startdate,string QA_enddate)
        {
            int id = 0;
            DataTable dt_tadate = ObjOrclHelper.ExecuteDataSet("select ta_date from TASKMNG_NEWCRF where crf_id='" + crfid + "' ").Tables[0];
            if (dt_tadate.Rows.Count > 0)
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='TA Completed',dev_startdate='" + dev_startdate + "',dev_enddate='" + dev_enddate + "',target_date='" + target_date + "',qa_startdate='"+QA_startdate+"',qa_enddate='"+QA_enddate+"',manhours='" + manhours + "',ta_status=1 where crf_id='" + crfid + "' ");
            else
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set ta_date=sysdate,crf_status='TA Completed',head_remarks='In Progress',dev_startdate='" + dev_startdate + "',dev_enddate='" + dev_enddate + "',target_date='" + target_date + "',qa_startdate='" + QA_startdate + "',qa_enddate='" + QA_enddate + "',manhours='" + manhours + "',ta_status=1 where crf_id='" + crfid + "' ");
            return id;
        }

        [WebMethod]
        public DataSet Get_developers()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select username developer,log_user from LOGIN_USERS where type in ('developer','techlead','itcoordinator') ");
            return DS;
        }

        [WebMethod]
        public int Update_TA(int TA_id, string phase, string taskname, string manhours, string startdate, string enddate, string developer)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_TA set phase='" + phase + "',taskname='" + taskname + "',manhours='" + manhours + "',startdate='" + startdate + "',enddate='" + enddate + "',developer='" + developer + "' where TA_id=" + TA_id + "");
            return id;
        }

        [WebMethod]
        public int Delete_TA(int TA_id)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("delete from TASKMNG_TA where TA_id=" + TA_id + "");
            return id;
        }

        [WebMethod]
        public int Insert_ta(string crf_id, string phase, string taskname, string manhours, string start_date, string end_date, string developer)
        {

            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into TASKMNG_TA(TA_id,crf_id,phase,taskname,manhours,startdate,enddate,developer,head_remarks) values(seq_ta.nextval,'" + crf_id + "','" + phase + "','" + taskname + "','" + manhours + "','" + start_date + "','" + end_date + "','" + developer + "','In Progress')");
            //DataTable dtMaxEnddate = ObjOrclHelper.ExecuteDataSet("select max(to_date(enddate,'dd-MM-yyyy')) end_date from TASKMNG_TA where crf_id='" + crf_id + "'").Tables[0];
            return id;
        }

         [WebMethod]
        public DataSet View_tamaster(string crfid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,manhours,dev_startdate,dev_enddate,target_date from taskmng_newcrf where crf_id='" + crfid+"' ");
            return DS;
        }

        [WebMethod]
        public DataSet View_ta(string crfid)
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select * from taskmng_ta where crf_id='"+crfid+ "' order by phase, to_date(startdate,'DD-MM-YYYY')");
            DS = ObjOrclHelper.ExecuteDataSet("select * from TASKMNG_TA where crf_id='" + crfid + "' ORDER BY CASE WHEN phase = 'Design' THEN 1 "+
                                              "WHEN phase = 'Back End' THEN 2 WHEN phase = 'Coding' THEN 3 ELSE 4 END");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Crfforstatus()
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF where crf_status!='User Confirmed' or crf_status not like '%Requested%' and approved=1 and ta_status=1");
            DS = ObjOrclHelper.ExecuteDataSet("select crf_id,crf_name from TASKMNG_NEWCRF where  crf_status not in ('User Confirmed','Cancelled','Completed','Closed') and approved=1 and ta_status=1");
            return DS;
        }

        [WebMethod]
        public int Update_Crfstatus(string crf_id, string crf_status, string curr_date, string remarks, string dly_status)
        {
            int id = 0;string crf_status1 = string.Empty;
            if (crf_status == "User Confirmed")
            {
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='" + crf_status + "',head_remarks='Live & Closed',techlead_remarks='" + remarks + "',  " + curr_date + " where crf_id='" + crf_id + "'");
            }
            else if (crf_status == "Completed")
            {
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='" + crf_status + "',head_remarks='Completed',techlead_remarks='" + remarks + "',  " + curr_date + " where crf_id='" + crf_id + "'");
            }
            else if (crf_status == "Cancelled")
            {
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='" + crf_status + "',head_remarks='Cancelled',techlead_remarks='" + remarks + "',  " + curr_date + " where crf_id='" + crf_id + "'");
            }
            else
            {
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='" + crf_status + "',head_remarks='" + dly_status + "',techlead_remarks='" + remarks + "',  " + curr_date + " where crf_id='" + crf_id + "'");
            }
                //else id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='" + crf_status + "',head_remarks='" + dly_status + "',techlead_remarks='" + remarks + "',  " + curr_date + " where crf_id='" + crf_id + "'");
            return id;
        }

        [WebMethod]
        public int Update_Approve_reject(string crf_id, string remarks, string status, string userid, string usertype)
        {
            int id = 0;
            if (usertype == "cfo")
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='" + status + "',cfo_remarks='" + remarks + "',cancel_by='" + userid + "',approved=1  where crf_id='" + crf_id + "'");
            else if (usertype == "itcoordinator")
                id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set crf_status='" + status + "',coordinator_remarks='" + remarks + "',cancel_by='" + userid + "'  where crf_id='" + crf_id + "'");
            return id;
        }

        [WebMethod]
        public int Update_Tastatus(string crf_id)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update TASKMNG_NEWCRF set ta_status=1,crf_status='TA Completed' where crf_id='" + crf_id + "'");
            return id;
        }

        [WebMethod]
        public DataSet Get_CRFreport(string status)
        {
            DataSet DS = new DataSet();
            if (status == "All")
            {
                DS = ObjOrclHelper.ExecuteDataSet("select p.crf_id,p.crf_name,LISTAGG(p.log_user,',') within group (order by p.log_user) developer,p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate," +
                                                  "p.target_date, p.manhours, p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, p.actualqa_enddate, p.uat_startdate, p.uat_enddate," +
                                                  "p.uat_confirmdate, p.livedate, p.userconfirm_date, p.crf_status,p.head_remarks, p.techlead_remarks  from(select distinct n.crf_id,n.crf_name, n.requestor_id, n.requestor_name, n.requested_date, " +
                                                  "n.designation department, n.dev_startdate, n.dev_enddate, n.target_date, n.manhours, n.qa_startdate,n.qa_enddate, n.actualdev_startdate, " +
                                                  "n.actualdev_enddate, n.actualqa_startdate, n.actualqa_enddate, n.uat_startdate, n.uat_enddate, n.uat_confirmdate,n.livedate, n.userconfirm_date, n.crf_status,n.head_remarks,n.techlead_remarks, l.log_user " +
                                                  "from taskmng_newcrf n left outer join taskmng_ta t on t.crf_id = n.crf_id left outer join login_users l on t.developer = l.username)p group by p.crf_id,p.crf_name," +
                                                  "p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate,p.target_date,p.manhours,p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, " +
                                                  "p.actualqa_enddate, p.uat_startdate, p.uat_enddate,p.uat_confirmdate,p.livedate, p.userconfirm_date, p.crf_status,p.techlead_remarks,p.head_remarks");
            }//case when n.requestor_id >1000 then (select designation from login_users where username = n.requestor_id and active=1) else null end department
            else
            {
                if (status == "TA Completed")
                    DS = ObjOrclHelper.ExecuteDataSet("select p.crf_id,p.crf_name,LISTAGG(p.log_user,',') within group (order by p.log_user) developer,p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate," +
                                                      "p.target_date, p.manhours, p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, p.actualqa_enddate, p.uat_startdate, p.uat_enddate," +
                                                      "p.uat_confirmdate, p.livedate, p.userconfirm_date, p.crf_status,p.head_remarks, p.techlead_remarks  from(select distinct n.crf_id,n.crf_name, n.requestor_id, n.requestor_name, n.requested_date, " +
                                                      "n.designation department, n.dev_startdate, n.dev_enddate, n.target_date, n.manhours, n.qa_startdate,n.qa_enddate, n.actualdev_startdate, " +
                                                      "n.actualdev_enddate, n.actualqa_startdate, n.actualqa_enddate, n.uat_startdate, n.uat_enddate, n.uat_confirmdate,n.livedate, n.userconfirm_date, n.crf_status,n.head_remarks,n.techlead_remarks, l.log_user " +
                                                      "from taskmng_newcrf n left outer join taskmng_ta t on t.crf_id = n.crf_id left outer join login_users l on t.developer = l.username where crf_status = 'TA Completed')p group by p.crf_id,p.crf_name," +
                                                      "p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate,p.target_date,p.manhours,p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, " +
                                                      "p.actualqa_enddate, p.uat_startdate, p.uat_enddate,p.uat_confirmdate,p.livedate, p.userconfirm_date, p.crf_status,p.techlead_remarks,p.head_remarks");
                else if (status == "In Progress")
                    DS = ObjOrclHelper.ExecuteDataSet("select p.crf_id, p.crf_name, LISTAGG(p.log_user, ',') within group(order by p.log_user) developer, p.requestor_name, p.department, p.requested_date, p.dev_startdate, p.dev_enddate, " +
                                                      "p.target_date, p.manhours, p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, p.actualqa_enddate, p.uat_startdate, p.uat_enddate," +
                                                      "p.uat_confirmdate, p.livedate, p.userconfirm_date, p.crf_status,p.head_remarks, p.techlead_remarks  from(select distinct n.crf_id,n.crf_name, n.requestor_id, n.requestor_name, n.requested_date, " +
                                                      "n.designation department, n.dev_startdate, n.dev_enddate, n.target_date, n.manhours, n.qa_startdate,n.qa_enddate, n.actualdev_startdate, " +
                                                      "n.actualdev_enddate, n.actualqa_startdate, n.actualqa_enddate, n.uat_startdate, n.uat_enddate, n.uat_confirmdate,n.livedate, n.userconfirm_date, n.crf_status,n.head_remarks,n.techlead_remarks, l.log_user " +
                                                      "from taskmng_newcrf n left outer join taskmng_ta t on t.crf_id = n.crf_id left outer join login_users l on t.developer = l.username where (n.crf_status='Development Started' or n.crf_status='Development Completed' or n.crf_status='QA Started' " +
                                                      "or n.crf_status='QA Completed' or n.crf_status='UAT Started' or n.crf_status='UAT Completed' or n.crf_status='UAT Confirmed' or n.crf_status='Live') and n.head_remarks='In Progress')p group by p.crf_id,p.crf_name," +
                                                      "p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate,p.target_date,p.manhours,p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, " +
                                                      "p.actualqa_enddate, p.uat_startdate, p.uat_enddate,p.uat_confirmdate,p.livedate, p.userconfirm_date, p.crf_status,p.techlead_remarks,p.head_remarks");

                else if (status == "Live & Closed")
                    DS = ObjOrclHelper.ExecuteDataSet("select p.crf_id, p.crf_name, LISTAGG(p.log_user, ',') within group(order by p.log_user) developer, p.requestor_name, p.department, p.requested_date, p.dev_startdate, p.dev_enddate, " +
                                                "p.target_date, p.manhours, p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, p.actualqa_enddate, p.uat_startdate, p.uat_enddate," +
                                                "p.uat_confirmdate, p.livedate, p.userconfirm_date, p.crf_status,p.head_remarks, p.techlead_remarks  from(select distinct n.crf_id,n.crf_name, n.requestor_id, n.requestor_name, n.requested_date, " +
                                                "n.designation department, n.dev_startdate, n.dev_enddate, n.target_date, n.manhours, n.qa_startdate,n.qa_enddate, n.actualdev_startdate, " +
                                                "n.actualdev_enddate, n.actualqa_startdate, n.actualqa_enddate, n.uat_startdate, n.uat_enddate, n.uat_confirmdate,n.livedate, n.userconfirm_date, n.crf_status,n.head_remarks,n.techlead_remarks, l.log_user " +
                                                "from taskmng_newcrf n left outer join taskmng_ta t on t.crf_id = n.crf_id left outer join login_users l on t.developer = l.username where n.crf_status='User Confirmed')p group by p.crf_id,p.crf_name," +
                                                "p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate,p.target_date,p.manhours,p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, " +
                                                "p.actualqa_enddate, p.uat_startdate, p.uat_enddate,p.uat_confirmdate,p.livedate, p.userconfirm_date, p.crf_status,p.techlead_remarks,p.head_remarks");

                else if (status == "Delayed")
                    DS = ObjOrclHelper.ExecuteDataSet("select p.crf_id, p.crf_name, LISTAGG(p.log_user, ',') within group(order by p.log_user) developer, p.requestor_name, p.department, p.requested_date, p.dev_startdate, p.dev_enddate, " +
                                                "p.target_date, p.manhours, p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, p.actualqa_enddate, p.uat_startdate, p.uat_enddate," +
                                                "p.uat_confirmdate, p.livedate, p.userconfirm_date, p.crf_status,p.head_remarks, p.techlead_remarks  from(select distinct n.crf_id,n.crf_name, n.requestor_id, n.requestor_name, n.requested_date, " +
                                                "n.designation department, n.dev_startdate, n.dev_enddate, n.target_date, n.manhours, n.qa_startdate,n.qa_enddate, n.actualdev_startdate, " +
                                                "n.actualdev_enddate, n.actualqa_startdate, n.actualqa_enddate, n.uat_startdate, n.uat_enddate, n.uat_confirmdate,n.livedate, n.userconfirm_date, n.crf_status,n.head_remarks,n.techlead_remarks, l.log_user " +
                                                "from taskmng_newcrf n left outer join taskmng_ta t on t.crf_id = n.crf_id left outer join login_users l on t.developer = l.username where n.head_remarks='Delayed' and n.crf_status not in ('User Confirmed','Completed','Cancelled'))p group by p.crf_id,p.crf_name," +
                                                "p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate,p.target_date,p.manhours,p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, " +
                                                "p.actualqa_enddate, p.uat_startdate, p.uat_enddate,p.uat_confirmdate,p.livedate, p.userconfirm_date, p.crf_status,p.techlead_remarks,p.head_remarks");
                else if (status == "Completed")
                    DS = ObjOrclHelper.ExecuteDataSet("select p.crf_id, p.crf_name, LISTAGG(p.log_user, ',') within group(order by p.log_user) developer, p.requestor_name, p.department, p.requested_date, p.dev_startdate, p.dev_enddate, " +
                                                "p.target_date, p.manhours, p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, p.actualqa_enddate, p.uat_startdate, p.uat_enddate," +
                                                "p.uat_confirmdate, p.livedate, p.userconfirm_date, p.crf_status,p.head_remarks, p.techlead_remarks  from(select distinct n.crf_id,n.crf_name, n.requestor_id, n.requestor_name, n.requested_date, " +
                                                "n.designation department, n.dev_startdate, n.dev_enddate, n.target_date, n.manhours, n.qa_startdate,n.qa_enddate, n.actualdev_startdate, " +
                                                "n.actualdev_enddate, n.actualqa_startdate, n.actualqa_enddate, n.uat_startdate, n.uat_enddate, n.uat_confirmdate,n.livedate, n.userconfirm_date, n.crf_status,n.head_remarks,n.techlead_remarks, l.log_user " +
                                                "from taskmng_newcrf n left outer join taskmng_ta t on t.crf_id = n.crf_id left outer join login_users l on t.developer = l.username where n.head_remarks='Completed')p group by p.crf_id,p.crf_name," +
                                                "p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate,p.target_date,p.manhours,p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, " +
                                                "p.actualqa_enddate, p.uat_startdate, p.uat_enddate,p.uat_confirmdate,p.livedate, p.userconfirm_date, p.crf_status,p.techlead_remarks,p.head_remarks");

                else
                    DS = ObjOrclHelper.ExecuteDataSet("select p.crf_id, p.crf_name, LISTAGG(p.log_user, ',') within group(order by p.log_user) developer, p.requestor_name, p.department, p.requested_date, p.dev_startdate, p.dev_enddate, " +
                                                "p.target_date, p.manhours, p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, p.actualqa_enddate, p.uat_startdate, p.uat_enddate," +
                                                "p.uat_confirmdate, p.livedate, p.userconfirm_date, p.crf_status,p.head_remarks, p.techlead_remarks  from(select distinct n.crf_id,n.crf_name, n.requestor_id, n.requestor_name, n.requested_date, " +
                                                "n.designation department, n.dev_startdate, n.dev_enddate, n.target_date, n.manhours, n.qa_startdate,n.qa_enddate, n.actualdev_startdate, " +
                                                "n.actualdev_enddate, n.actualqa_startdate, n.actualqa_enddate, n.uat_startdate, n.uat_enddate, n.uat_confirmdate,n.livedate, n.userconfirm_date, n.crf_status,n.head_remarks,n.techlead_remarks, l.log_user " +
                                                "from taskmng_newcrf n left outer join taskmng_ta t on t.crf_id = n.crf_id left outer join login_users l on t.developer = l.username where  n.crf_status='Cancelled')p group by p.crf_id,p.crf_name," +
                                                "p.requestor_name,p.department,p.requested_date,p.dev_startdate,p.dev_enddate,p.target_date,p.manhours,p.qa_startdate, p.qa_enddate, p.actualdev_startdate, p.actualdev_enddate, p.actualqa_startdate, " +
                                                "p.actualqa_enddate, p.uat_startdate, p.uat_enddate,p.uat_confirmdate,p.livedate, p.userconfirm_date, p.crf_status,p.techlead_remarks,p.head_remarks");

            }
            return DS;
        }
       
        [WebMethod]
        public DataSet Get_Crf_count()
        {
            DataSet DS = new DataSet();
            
                DS = ObjOrclHelper.ExecuteDataSet("select count(*) in_progress from TASKMNG_NEWCRF where (crf_status='Development Started' or crf_status='Development Completed' or crf_status='QA Started' " +
                    "or crf_status='QA Completed' or crf_status='UAT Started' or crf_status='UAT Completed' or crf_status='UAT Confirmed' ) or Head_remarks='In Progress' union all select count(*) delay from TASKMNG_NEWCRF " +
                    "where head_remarks='Delayed' and crf_status!='User Confirmed' union all select count(*) live from TASKMNG_NEWCRF where crf_status='User Confirmed' union all select count(*) ta from TASKMNG_NEWCRF " +
                    "where crf_status='TA Completed'");
            return DS;
        }

        
        [WebMethod]
        public DataSet Get_designation()
        {
            DataSet DS = new DataSet();

            DS = ObjOrclHelper.ExecuteDataSet("select distinct designation,type from login_users");
            return DS;
        }

        [WebMethod]
        public DataSet Get_users(string designation)
        {
            DataSet DS = new DataSet();

            DS = ObjOrclHelper.ExecuteDataSet("select username,log_user from login_users where designation='"+designation+"' and active=1");
            return DS;
        }

        //................................................................................................................................

        [WebMethod()]
        public DataSet Get_TicketId()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select seq_createcrf.nextval from dual");
            return DS;
        }

        [WebMethod]
        public int Insert_NewTicket(int ticket_no, string issued_by, string issue_detail,string ticket_type, string crf_desc)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into HELPDESK_TICKET(ticket_no,issued_date,issued_by,issue_detail, approve_status,resolve_status,ticket_type,crf_desc) " +
                "values(" + ticket_no + ",sysdate,'" + issued_by + "','" + issue_detail + "','Not Approved','Not Resolved','" + ticket_type + "','"+crf_desc+"')");
            return id;
        }

        [WebMethod]
        public DataSet Get_Tickets(int id)
        {
            DataSet DS = new DataSet();
            if (id == 0)
                DS = ObjOrclHelper.ExecuteDataSet("select ticket_no,issue_detail from HELPDESK_TICKET");
            else
                DS = ObjOrclHelper.ExecuteDataSet("select ticket_no,issue_detail from HELPDESK_TICKET where ticket_no=" + id);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Tickets_Dashboard(string type)
        {
            DataSet DS = new DataSet();
            if (type == "Pending")
            {
                DS = ObjOrclHelper.ExecuteDataSet("select C.TICKET_NO,to_char(C.ISSUED_DATE,'dd-MM-yyyy') ISSUED_DATE,C.ISSUED_BY,c.crf_desc," +
                    "C.ISSUE_DETAIL,C.APPROVED_BY,to_char(C.APPROVED_DATE,'dd-MM-yyyy') APPROVED_DATE,C.APPROVE_STATUS,C.TICKET_AGE,C.RESOLVED_BY," +
                    "to_char(C.RESOLVED_DATE,'dd-MM-yyyy') RESOLVED_DATE,C.RESOLVE_STATUS, C.REMARKS, C.TICKET_TYPE from HELPDESK_TICKET c " +
                    "where to_date(sysdate,'dd-MM-yyyy') - to_date(C.APPROVED_DATE, 'dd-MM-yyyy') > 5 " +
                    "and c.approve_status='Approved' and C.RESOLVE_STATUS='Not Resolved'");
            }
            else if (type == "Resolved")
            {
                DS = ObjOrclHelper.ExecuteDataSet("select C.TICKET_NO,to_char(C.ISSUED_DATE,'dd-MM-yyyy') ISSUED_DATE,C.ISSUED_BY,c.crf_desc," +
                "C.ISSUE_DETAIL,C.APPROVED_BY,to_char(C.APPROVED_DATE,'dd-MM-yyyy') APPROVED_DATE,C.APPROVE_STATUS,C.TICKET_AGE,C.RESOLVED_BY," +
                "to_char(C.RESOLVED_DATE,'dd-MM-yyyy') RESOLVED_DATE,C.RESOLVE_STATUS, C.REMARKS, C.TICKET_TYPE from HELPDESK_TICKET c " +
                "where C.RESOLVE_STATUS='Resolved'");
            }
            else if (type == "In Progress")
            {
                DS = ObjOrclHelper.ExecuteDataSet("select C.TICKET_NO,to_char(C.ISSUED_DATE,'dd-MM-yyyy') ISSUED_DATE,C.ISSUED_BY,c.crf_desc," +
                "C.ISSUE_DETAIL,C.APPROVED_BY,to_char(C.APPROVED_DATE,'dd-MM-yyyy') APPROVED_DATE,C.APPROVE_STATUS,C.TICKET_AGE,C.RESOLVED_BY," +
                "to_char(C.RESOLVED_DATE,'dd-MM-yyyy') RESOLVED_DATE,C.RESOLVE_STATUS, C.REMARKS, C.TICKET_TYPE from HELPDESK_TICKET c " +
                "where to_date(sysdate,'dd-MM-yyyy') - to_date(C.APPROVED_DATE, 'dd-MM-yyyy') <=5 " +
                "and approve_status='Approved'");
            }
            else
            {
                DS = ObjOrclHelper.ExecuteDataSet("select C.TICKET_NO,to_char(C.ISSUED_DATE,'dd-MM-yyyy') ISSUED_DATE,C.ISSUED_BY,c.crf_desc," +
                "C.ISSUE_DETAIL,C.APPROVED_BY,to_char(C.APPROVED_DATE,'dd-MM-yyyy') APPROVED_DATE,C.APPROVE_STATUS,C.TICKET_AGE,C.RESOLVED_BY," +
                "to_char(C.RESOLVED_DATE,'dd-MM-yyyy') RESOLVED_DATE,C.RESOLVE_STATUS, C.REMARKS, C.TICKET_TYPE from HELPDESK_TICKET c " +
                "order by C.ISSUED_DATE");
            }
            return DS;
        }

        [WebMethod]
        public DataSet Get_ticket_forApprove()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select h.*,null age from HELPDESK_TICKET h where h.APPROVE_status='Not Approved'");
            return DS;
        }
        [WebMethod]
        public DataSet Get_ticket_forResolve()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select h.*,(trunc(sysdate)-trunc(to_date(h.approved_date))) age from HELPDESK_TICKET h where h.APPROVE_status='Approved' and h.resolve_status='Not Resolved'");
            return DS;
        }
        [WebMethod]
        public DataSet Get_ticket_forResolve_byId(int id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select h.*,(trunc(sysdate)-trunc(to_date(h.approved_date))) age from HELPDESK_TICKET h where h.ticket_no=" + id);
            return DS;
        }
        [WebMethod]
        public int Update_Resolvestatus(int ticket_no, string resolve_status, string resolved_by, string remarks)
        {
            int id = 0; string crf_status1 = string.Empty;

            id = ObjOrclHelper.ExecuteNonQuery("update helpdesk_ticket set resolve_status='" + resolve_status + "',resolved_date=sysdate,resolved_by='" + resolved_by + "', remarks= '" + remarks + "' where ticket_no=" + ticket_no + "");
            return id;
        }
        [WebMethod]
        public int Update_Approvestatus(int ticket_no, string Approve_status, string Approved_by)
        {
            int id = 0; string crf_status1 = string.Empty;

            id = ObjOrclHelper.ExecuteNonQuery("update helpdesk_ticket set Approve_status='" + Approve_status + "',approved_date=sysdate,approved_by='" + Approved_by + "' where ticket_no=" + ticket_no + "");
            return id;
        }
    }
}
