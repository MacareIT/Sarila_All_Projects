using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ModuleUsage
{
    public partial class Login : System.Web.UI.Page
    {     
        ServiceReference2.WebService_OperationSoapClient objservice = new ServiceReference2.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Login(txt_username.Text, txt_password.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string type = dt.Rows[0]["type"].ToString();
                string username = dt.Rows[0]["username"].ToString();
                string log_user = dt.Rows[0]["log_user"].ToString();
                if (type == "itcoordinator" || type == "techlead" || type == "developer")
                {
                    Session["USERTYPE"] = type;
                    Session["Username"] = username;
                    Session["LOGUSER"] = log_user;

                    //objservice.updateUsage("DOCTORSONDUTY", username);
                    Response.Redirect("Module_Usage.aspx");
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