using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AddHead : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "12";
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillgrid();
            }
        }
        protected void addincentivehead(object sender, EventArgs e)
        {
            try
            {
                int res = objService.AddincentiveHead(txtincentievhead.Text, Session["USERID"].ToString());
                if (res > 0)
                {
                    fillgrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to add head....');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('unable to add head....');", true);
            }
        }
        private void fillgrid()
        {
            try
            {
                ds = new DataSet();
                ds = objService.ListIncentiveHead();
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data not found!!!!');", true);
            }

        }
    }
}