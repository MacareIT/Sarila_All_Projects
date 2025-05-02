using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class IncentiveDashboard : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {


                    if (Request.QueryString["userid"] != null && Request.QueryString["role"] != null || Request.QueryString["menu"] != null)
                    {
                        Session["USERID"] = Request.QueryString["userid"];
                        Session["ROLE"] = Request.QueryString["role"];
                        Session["USERTYPE"] = Request.QueryString["usertype"];
                        Session["DESIGNATION"] = Request.QueryString["designation"];
                        Session["MAILID"] = Request.QueryString["mailid"];
                        Label lb1 = (Label)this.Master.FindControl("lbllogged");
                        lb1.Text = Request.QueryString["userid"];
                        if (Request.QueryString["menu"] != null)
                        {
                            int res = objService.updateUsage(Request.QueryString["menu"], Request.QueryString["userid"]);
                        }
                        HttpContext.Current.Request.QueryString.Clear();

                    }
                    else if (Session["USERID"] != null && Session["ROLE"] != null)
                    {
                        Label lb1 = (Label)this.Master.FindControl("lbllogged");
                        lb1.Text = Session["USERID"].ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                        Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");

                    }

                }
                catch (Exception ex)
                {
                    // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
                }
            }
        }
    }
}