using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRF_Tracker_Latest
{
    public partial class Signin : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objservice = new ServiceReference1.WebService_CRFTrackerSoapClient();
        ServiceReference2.WebService_ModuleUsageSoapClient objservice1 = new ServiceReference2.WebService_ModuleUsageSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            Session["USERTYPE"] = null;
            Session["USERID"] = null;
            Session["LOGUSER"] = null;
        }
        protected void BtnSubmit()
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Login(txt_username.Text, txt_password.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Session["USERTYPE"] = dt.Rows[0]["type"].ToString();
                Session["USERID"] = dt.Rows[0]["username"].ToString();
                Session["LOGUSER"] = dt.Rows[0]["log_user"].ToString();
                Session["DESIGNATION"]= dt.Rows[0]["designation"].ToString();
                int result = objservice1.insert_Module_Log("Internal CRF Tracker", Session["USERID"].ToString(), DateTime.Now.ToString());
                Response.Redirect("CRF_Report.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}