using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AddPharmacyMargin : System.Web.UI.Page
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
            ds = new DataSet();
            ds = objService.Fill_pharmacymargin();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }

        private void fillclinic()
        {
            ds = new DataSet();
            ds = objService.ListPharmacy();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "branch_name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Branch--", "0"));
        }
        protected void addmargin(object sender, EventArgs e)
        {
            try
            {

                int result = 0;
                result = objService.AddPharmacymargin(txtbelowamt.Text,txtaboveamt.Text,txtpercent3.Text,txtpercent1.Text,txtpercent2.Text,txtdate.Text,ddlbranch.SelectedValue,txttargetmargin.Text);
                if (result > 0)
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Pharmacy Margin revise sucessfully');", true);
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to revise margin');", true);

                fillpercent();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured Try again....');", true);
            }
        }
    }
}