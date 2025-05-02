using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRM_Application
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        ServiceReference2.WebService_ModuleUsageSoapClient objservice1 = new ServiceReference2.WebService_ModuleUsageSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_login(Text_username.Text, Text_password.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string type = dt.Rows[0]["type"].ToString();
                string username = dt.Rows[0]["username"].ToString();
                string log_user = dt.Rows[0]["log_user"].ToString();
                string branch_id = dt.Rows[0]["branchid"].ToString();
                Session["USERTYPE"] = type;
                Session["USERID"] = username;
                Session["LOGUSER"] = log_user;
                Session["BRANCHID"] = branch_id;
                objservice1.insert_Module_Log("CRM Module", username, DateTime.Now.ToString("dd-MM-yyyy"));
                //objservice.Insert_Usage(username);
                Response.Redirect("Todays_Booking.aspx");
                Session.RemoveAll();
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Employee Id and Password is incorrect";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}