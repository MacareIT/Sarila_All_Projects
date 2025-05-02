using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PurchaseCommittee
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session.RemoveAll();
                Session.Abandon();
                Session.Clear();
                Session.Remove("USERTYPE");
            }
            Label1.Visible = false;            
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_login(txt_username.Text, txt_password.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["type"].ToString() == "purchasehead" || dt.Rows[0]["type"].ToString() == "techlead" || dt.Rows[0]["type"].ToString() == "businesshead" || dt.Rows[0]["type"].ToString() == "cfo" || dt.Rows[0]["type"].ToString() == "cs"|| dt.Rows[0]["type"].ToString() == "accountshead" || dt.Rows[0]["type"].ToString() == "operationhead")
                {
                    string type = dt.Rows[0]["type"].ToString();
                    string username = dt.Rows[0]["username"].ToString();
                    string log_user = dt.Rows[0]["log_user"].ToString();
                    Session["USERTYPE"] = type;
                    Session["USERID"] = username;
                    Session["LOGUSER"] = log_user;
                    //objservice.updateUsage("ITTASKMANAGEMENT", username);
                    Response.Redirect("Dashboard.aspx");
                    Session.RemoveAll();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "You do not have sufficient privileges to open this module";
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