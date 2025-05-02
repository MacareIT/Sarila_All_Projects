using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountsApp
{
    public partial class StaffAccount_details : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        public static string editid="0",empid="0",branchid="0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
            //Session["USERID"] = "1234";
            if (Session["USERID"] == null)
            {
                Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
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
            ds = objService.ListClinic_Microlab();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Branch--", "0"));
        }
        protected void updatedetails(object sender, EventArgs e)
        {
            try
            {
                int res=0;
                if(editid!="0" && branchid!="0")
                {
                res = objService.UpdateStaffAccountDetails(editid, txtbankname.Text, txtifsccode.Text, txtaccountno.Text,empid,txtbranch.Text,branchid);
                if(res>0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated sucessfully....');", true);
                    empid = "0";
                    branchid = "0";
                    editid = "0";
                        txtaccountno.Text = "";
                        txtbankname.Text = "";
                        txtbranch.Text = "";
                        txtifsccode.Text = "";
                        ds = new DataSet();
                        ds = objService.LoadIncentive_dep_staff(ddlbranch.SelectedValue, ddlhead.SelectedValue);
                        GridView1.DataSource = ds.Tables[0];
                        GridView1.DataBind();
                    }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updating failed....');", true);
                    empid = "0";
                    branchid = "0";
                    editid = "0";
                        txtaccountno.Text = "";
                        txtbankname.Text = "";
                        txtbranch.Text = "";
                        txtifsccode.Text = "";
                    }
                }
                
            }
            catch(Exception ex)
            {
                empid = "0";
                branchid = "0";
                editid = "0";
                txtaccountno.Text = "";
                txtbankname.Text = "";
                txtbranch.Text = "";
                txtifsccode.Text = "";
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert("+ex.Message+");", true);

            }
        }

        protected void ddlhead_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds = objService.LoadIncentive_dep_staff(ddlbranch.SelectedValue, ddlhead.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
            int row = e.NewSelectedIndex;
                editid=GridView1.DataKeys[e.NewSelectedIndex].Values["id"].ToString();
                empid = GridView1.DataKeys[e.NewSelectedIndex].Values["empcode"].ToString();
                branchid = GridView1.DataKeys[e.NewSelectedIndex].Values["branchid"].ToString();

                txtaccountno.Text = GridView1.Rows[row].Cells[4].Text== "&nbsp;" ? "": GridView1.Rows[row].Cells[4].Text;
                txtbankname.Text= GridView1.Rows[row].Cells[2].Text == "&nbsp;" ? "" : GridView1.Rows[row].Cells[2].Text;
                txtifsccode.Text= GridView1.Rows[row].Cells[3].Text == "&nbsp;" ? "" : GridView1.Rows[row].Cells[3].Text;
                txtbranch.Text= GridView1.Rows[row].Cells[5].Text == "&nbsp;" ? "" : GridView1.Rows[row].Cells[5].Text;

            }
            catch(Exception ex)
            {

            }
            

        }
       
        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds = objService.LoadIncentive_dep_staff(ddlbranch.SelectedValue,ddlhead.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

            }
        }

       
    }
}