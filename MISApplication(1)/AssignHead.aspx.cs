using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AssignHead : System.Web.UI.Page
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
                filldepartment();
                fillclinic();
                fillincentivehead();
                //fillincentiveStaffList();
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
        private void filldepartment()
        {
            ds = new DataSet();
            ds = objService.ListMainDepartment();
            ddldepartment.DataSource = ds.Tables[0];
            ddldepartment.DataTextField = "dep_name";
            ddldepartment.DataValueField = "dep_id";
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, new ListItem("---Choose Department--", "0"));
        }

        protected void ddldepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindstaffGrid(string.Empty);
           

        }

        private void bindstaffGrid(string search)
        {
            ds = new DataSet();
            ds = objService.ListDepartment_Staff(ddldepartment.SelectedValue, search);
            ddlstaff.DataSource = ds.Tables[0];
            ddlstaff.DataTextField = "name";
            ddlstaff.DataValueField = "emp_code";
            ddlstaff.DataBind();
            ddlstaff.Items.Insert(0, new ListItem("---Choose Staff--", "0"));
            
        }

       
        protected void searchEmployee(object sender, EventArgs e)
        {
            //bindstaffGrid(txtsearch.Text);
        }
        protected void searchEmployeecode(object sender, EventArgs e)
        {
            //ds = new DataSet();
            //ds = objService.ListDepartment_Staffcode(ddldepartment.SelectedValue, txtempcode.Text);
            //GridView1.DataSource = ds.Tables[0];
            //GridView1.DataBind();
        }
        private void fillincentiveStaffList()
        {
            try
            {
            ds = new DataSet();
            ds = objService.ListIncentiveStaff("", ddlbranch.SelectedValue);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            }
            catch(Exception ex)
            {
            }           

        }
        protected void assignEmployee(object sender, EventArgs e)
        {
            try
            {

                if(ddltype.SelectedIndex>0 && ddlstaff.SelectedIndex>0)
                {
                  objService.Incentive_assignstaff(ddlbranch.SelectedValue, ddlhead.SelectedValue,ddlstaff.SelectedValue,ddlstaff.SelectedItem.Text,ddltype.SelectedValue,"");
                  ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added sucessfully...');", true);
                  fillincentiveStaffList();

                }
                else
                {
                   ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please choose properly....');", true);

                }

                //string result = "";
                //DataTable dt = new DataTable();
                ////dt.Columns.AddRange(new DataColumn[] { new DataColumn("BRANCHID"), new DataColumn("HEADID"), new DataColumn("EMPCODE"),new DataColumn("EMPNAME")});            
                //foreach (GridViewRow rw in GridView1.Rows)
                //{
                //    CheckBox chk = rw.Cells[2].Controls[1] as CheckBox;
                //    if (chk != null && chk.Checked)
                //    {
                //        //dt.Rows.Add(ddlbranch.SelectedValue,ddlhead.SelectedValue, rw.Cells[0].Text,rw.Cells[1].Text);
                //        result = objService.Incentive_assignstaff(ddlbranch.SelectedValue, ddlhead.SelectedValue, rw.Cells[0].Text, rw.Cells[1].Text,ddltype.SelectedValue,"");
                //    }
                //}
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + result + "');", true);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('unable to assign staff....');", true);

            }

        }

        protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillincentiveStaffList();
        }
    }
}