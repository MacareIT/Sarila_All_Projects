using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class EditCamp : System.Web.UI.Page
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
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillCampdetails();
                fillbranch();
            }
        }
        private void fillbranch()
        {
            ds = new DataSet();
            ds = objService.ListClinic_Microlab();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Unit--", "0"));

        }
        protected void updatecamp(object sender, EventArgs e)
        {
            try
            {
                int res = objService.UpdateCamp(ddlcamp.SelectedValue,  txtname.Text, txtdescription.Text, txtcampdate.Text, txtplace.Text,ddlststus.SelectedValue,txtftime.Text,txtttime.Text,ddlbranch.SelectedValue);
                if (res > 0)
                {
                    fillCampdetails();
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Camp Details updated....');", true);

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to update camp....');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('unable to update Camp....');", true);
            }
        }
        private void fillCampdetails()
        {
            try
            {
                ds = new DataSet();
                ds = objService.Campdetails();
                ddlcamp.DataSource = ds.Tables[0];
                ddlcamp.DataTextField = "campname";
                ddlcamp.DataValueField = "campid";
                ddlcamp.DataBind();
                ddlcamp.Items.Insert(0, new ListItem("---Choose Camp--", "0"));

            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlcamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds = objService.Campdetails_ID(ddlcamp.SelectedValue);
            try
            {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtcampdate.Text = ds.Tables[0].Rows[0]["campdate"].ToString();
                    txtname.Text = ds.Tables[0].Rows[0]["name"].ToString();
                    txtplace.Text = ds.Tables[0].Rows[0]["place"].ToString();
                    txtdescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
                    txtftime.Text = ds.Tables[0].Rows[0]["fromtime"].ToString();
                    txtttime.Text = ds.Tables[0].Rows[0]["totime"].ToString();
                    ddlbranch.SelectedValue= ds.Tables[0].Rows[0]["unitid"].ToString();
                    ddlststus.SelectedValue= ds.Tables[0].Rows[0]["status"].ToString();
                }
                else
                {
                    txtdescription.Text = string.Empty;
                    txtcampdate.Text = string.Empty;
                    txtname.Text = string.Empty;
                    txtplace.Text = string.Empty;
                }

            }
            else
            {
                txtdescription.Text = string.Empty;
                txtcampdate.Text = string.Empty;
                txtname.Text = string.Empty;
                txtplace.Text = string.Empty;
            }
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}