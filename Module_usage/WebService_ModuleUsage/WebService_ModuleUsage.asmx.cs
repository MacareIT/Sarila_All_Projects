using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace WebService_ModuleUsage
{
    /// <summary>
    /// Summary description for WebService_ModuleUsage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_ModuleUsage : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        DataSet ObjDataSet = new DataSet();
        DataTable ObjDatatb = new DataTable();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public DataSet Dept_Select()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select dept_id,dept_name from department_master");
            return ObjDataSet;
        }
        #region Module Insert/Update
        [WebMethod()]
        public int Module_InsertUpdate(int dept_Id, string module,string path,string createdby)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into module_usage (dept_id,Module,path,createdon,createdby) values ("+dept_Id+",'" +module+ "','"+path+"',sysdate,'"+createdby+"')");

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion
        [WebMethod()]
        public int delete_Module(string module)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("update module_usage set status=0 where Module='"+module+"'");
            return result;
        }

        [WebMethod]
        public DataSet Modules_Select()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select dept_name,Module,path from module_usage a join department_master b on a.dept_id=b.dept_id where a.status=1");
            return ObjDataSet;
        }

        [WebMethod()]
        public int insert_Module_Log(string module,string loguser,string logdate)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("insert into module_usage_log values('" + module + "','"+loguser+"',sysdate)");
            return result;
        }

        [WebMethod]
        public DataSet Usage_Select(string fromdt,string todt)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select t.module,0 as usagecount from MODULE_USAGE t where t.status=1 minus select t.module, 0 as usagecount from MODULE_USAGE t, MODULE_USAGE_LOG tl where t.module = tl.module and tl.log_logdate between '"+fromdt+"' and '"+todt+"' and t.status=1 group by t.module " +
                                                      "union all select t.module, count(tl.module) as usagecount from MODULE_USAGE t, MODULE_USAGE_LOG tl where t.module = tl.module and tl.log_logdate between '"+fromdt+"' and '"+todt+"' and t.status=1 group by t.module");
            return ObjDataSet;
        }

        [WebMethod]
        public DataSet Usage_Select_dtl(string fromdt, string todt)
        {
            //ObjDataSet = ObjOrclHelper.ExecuteDataSet("SELECT d.dept_name,tl.Module,LISTAGG(CAST(tl.Log_username AS VARCHAR2(12))||'('||CAST(tl.Log_logdate AS VARCHAR2(12))||')',',') WITHIN GROUP(ORDER BY tl.Module) Log_Details FROM module_usage_log tl, module_usage t, department_master d " +
            //                                          "where tl.module = t.module and t.dept_id = d.dept_id and tl.log_logdate between '" + fromdt + "' and '" + todt + "' and t.status=1 group by tl.Module, d.dept_name");
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("SELECT d.dept_name,tl.Module,count(tl.Log_username) Log_count FROM module_usage_log tl, module_usage t, department_master d where tl.module = t.module and t.dept_id = d.dept_id and tl.log_logdate between '"+fromdt+"' " +
                                                      "and '"+todt+"' and t.status = 1  group by d.dept_name, tl.Module order by d.dept_name, tl.Module");
            return ObjDataSet;
        }

    }
}
