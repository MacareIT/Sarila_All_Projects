using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AddHeadPercent : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        public static string percentid ="0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "123";
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillBranch();
            }
        }

        private void fillBranch()
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
            try
            {

                int result=0;
                result = objService.Add_incentiveheadstaff_percent(ddlbranch.SelectedValue,txtdate.Text,ddltype.SelectedValue,txtpercent.Text,Session["USERID"].ToString(),percentid);
                if(result>0)
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Revised IncentivePercent for head...');", true);
                else
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to revise incentive percent for staff');", true);

                fillgrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured Try again....');", true);
            }
        }

        private void fillgrid()
        {
            try
            {
                ds = new DataSet();
                ds = objService.LoadHeadPercentDetails(ddlbranch.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error while loading....');", true);

            }


        }

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillgrid();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
            percentid = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = new DataSet();
            ds = objService.LoadHeadPercentDetails_ID (percentid);
            ddlbranch.SelectedValue = ds.Tables[0].Rows[0]["BRANCHID"].ToString();
            ddltype.SelectedValue = ds.Tables[0].Rows[0]["INCENTIVE_HEADTYPE"].ToString();
            txtdate.Text = ds.Tables[0].Rows[0]["ENTEREDDATE"].ToString();
            txtpercent.Text = ds.Tables[0].Rows[0]["INCENTIVE_PERCENT"].ToString();
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}