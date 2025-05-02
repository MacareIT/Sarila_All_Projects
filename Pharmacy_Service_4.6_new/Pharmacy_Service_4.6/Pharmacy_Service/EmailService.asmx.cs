using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pharmacy_Service
{
    /// <summary>
    /// Summary description for EmailService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmailService : System.Web.Services.WebService
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
        public DataSet PR_Details(string frmdt, string todt,string branchid)
        {
            //frmdt = "21-Jun-2012";todt = "21-Jun-2015";
            ds = new DataSet();
            string query = "select itm.item_name,dt.batch_no,dt.qty from HOSPITAL.PHARMA_PR_MASTER t join  HOSPITAL.Pharma_Pr_Dtl dt on t.pr_no=dt.pr_no left outer join HOSPITAL.PHARMA_ITEM_MASTER itm on itm.item_id=dt.item_id where t.branch_id="+branchid+" and to_date(t.tra_dt,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.accept_dt is null ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
    }
}
