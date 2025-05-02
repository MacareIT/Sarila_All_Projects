using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class Login : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        ServiceReference1.WebService_ModuleUsageSoapClient objService1 = new ServiceReference1.WebService_ModuleUsageSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("Login_Table");
                Session.Remove("Amb_Id");
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            string username = Request["uname"];
            string password = Request["pass"];
            DataSet dsLogin = objService.Login(username, password);
            if (dsLogin.Tables[0].Rows.Count > 0)
            {
                //int result = objService.updateUsage("OPERATION", username);
                int result = objService1.insert_Module_Log("Operation Module", username, DateTime.Now.ToString("dd-MM-yyyy"));
                Session.Add("Login_Table", dsLogin.Tables[0]);
                if (dsLogin.Tables[0].Rows[0]["Role"].ToString() == "admin" && dsLogin.Tables[0].Rows[0]["Designation"].ToString() == "OPERATION HEAD")
                    Response.Redirect("~/AmbienceRegister.aspx");
                else
                    Response.Redirect("~/AmbienceCondtnReg.aspx");
            }
            else Response.Write("<script>alert('Invalid username and password');</script>");
        }
    }
}