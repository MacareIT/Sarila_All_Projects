using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AssignEmployees : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "123";
               if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                filldepartment();
                fillclinic();
                fillincentivehead();
                fillincentiveStaffList();
            }
        }

        private void fillincentiveStaffList()
        {
            try
            {
            ds=new DataSet();
            ds = objService.ListIncentiveStaff("permenent", ddlbranch.SelectedValue);
            GridView2.DataSource = ds.Tables[0];
            GridView2.DataBind();
            }
            catch(Exception ex)
            {

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
            ds = objService.ListDepartment_Staff(ddldepartment.SelectedValue,search);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            fillincentiveStaffList();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindstaffGrid(string.Empty);

        }
        protected void searchEmployee(object sender, EventArgs e)
        {
            bindstaffGrid(txtsearch.Text);
        }
        protected void searchEmployeecode(object sender, EventArgs e)
        {
            ds = new DataSet();
            ds = objService.ListDepartment_Staffcode(ddldepartment.SelectedValue, txtempcode.Text);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        protected void assignEmployee(object sender, EventArgs e)
        {
            try
            {
             int result;
             DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[] { new DataColumn("BRANCHID"), new DataColumn("HEADID"), new DataColumn("EMPCODE"),new DataColumn("EMPNAME")});            
            foreach (GridViewRow rw in GridView1.Rows)
            {
                CheckBox chk = rw.Cells[2].Controls[1] as CheckBox;
                if (chk != null && chk.Checked)
                {
                        //dt.Rows.Add(ddlbranch.SelectedValue,ddlhead.SelectedValue, rw.Cells[0].Text,rw.Cells[1].Text);
                        result=objService.Incentive_assignstaff( ddlbranch.SelectedValue, ddlhead.SelectedValue, rw.Cells[0].Text, rw.Cells[1].Text,"permenent","0");
                }              
            }
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Added Sucessfully');", true);

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