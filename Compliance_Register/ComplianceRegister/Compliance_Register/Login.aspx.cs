using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Compliance_Register
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_login(txt_username.Text, txt_password.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["active"].ToString() == "1")
                {
                    string type = dt.Rows[0]["type"].ToString();
                    string username = dt.Rows[0]["username"].ToString();
                    string log_user = dt.Rows[0]["log_user"].ToString();
                    string branch_id = dt.Rows[0]["branchid"].ToString();
                    Session["USERTYPE"] = type;
                    Session["USERID"] = username;
                    Session["LOGUSER"] = log_user;
                    Session["BRNACHID"] = branch_id;
                    objservice.Insert_Usage(username);
                    Response.Redirect("Registration.aspx");
                    Session.RemoveAll();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "Access Denied !!!";
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