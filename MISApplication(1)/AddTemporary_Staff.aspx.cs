using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AddTemporary_Staff : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillclinic();
                fillincentivehead();
            }
        }

        private void fillincentivehead()
        {
            ds = new DataSet();
            ds = objService.ListIncentiveHead();
            ddlhead.DataSource = ds.Tables[0];
            ddlhead.DataTextField = "incentivehead";
            ddlhead.DataValueField = "id";
            ddlhead.DataBind();
            ddlhead.Items.Insert(0, new ListItem("---Choose IncentiveHead---", "0"));
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
        protected void assignEmployee(object sender, EventArgs e)
        {
            objService.Incentive_assignstaff(ddlbranch.SelectedValue, ddlhead.SelectedValue, "0", txtname.Text,"temporary", "");
            ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added sucessfully...');", true);
            fillincentiveStaffList();
        }
        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillincentiveStaffList();
        }

        private void fillincentiveStaffList()
        {
            try
            {
                ds = new DataSet();
                ds = objService.ListIncentiveStaff("temporary", ddlbranch.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
            }
        }
    }
}