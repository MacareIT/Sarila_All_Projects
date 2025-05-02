using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationDashboard
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceReference1.WebService_OperationDashboardSoapClient objService = new ServiceReference1.WebService_OperationDashboardSoapClient();
        ServiceReference2.WebService_ModuleUsageSoapClient objservice1 = new ServiceReference2.WebService_ModuleUsageSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["USERTYPE"] = null;
                Session["Username"] = null;
                Session["LOGUSER"] = null;
                Label1.Visible = false;
            }
        }
        
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objService.Login(txt_username.Text, txt_password.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string type = dt.Rows[0]["type"].ToString();
                string username = dt.Rows[0]["username"].ToString();
                string log_user = dt.Rows[0]["log_user"].ToString();
                if (type == "operation" || type == "techlead" || type == "operationhead")
                {
                    Session["USERTYPE"] = type;
                    Session["Username"] = username;
                    Session["LOGUSER"] = log_user;
                    int result = objservice1.insert_Module_Log("Operation Dashboard", username, DateTime.Now.ToString("dd-MM-yyyy"));

                    //objservice.updateUsage("DOCTORSONDUTY", username);
                    Response.Redirect("Dashboard.aspx");
                    //Response.Redirect("Agreement_Renewal.aspx");
                    //Session.RemoveAll();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "You can't access this !..........";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
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