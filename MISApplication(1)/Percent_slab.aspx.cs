using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class Percent_slab : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["USERID"] = "55";
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillclinic();
                fillpercent();
            }
        }

        private void fillpercent()
        {
            try
            {
                int res = 0;//objService.AddincentiveAmountPercent(ddlbranch.SelectedValue,txtpercent1.Text,txtpercent2.Text,txtpercent3.Text);
                if (res > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Revise Percent added...');", true);
                    fillpercent();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured while adding....');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured Try again....');", true);
            }
        }

        private void fillclinic()
        {
            ds = new DataSet();
            ds = objService.ListClinic();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Branch--", "0"));
        }
        protected void addpercent(object sender, EventArgs e)
        {

        }
    }
   
}