using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRM_Application
{
    public partial class Doctor_Registration : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddldept();
                bindddlbranch();
            }
        }

        private void bindddlbranch()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Branch().Tables[0];
            Ddl_branch.DataSource = dt;
            Ddl_branch.DataTextField = "name";
            Ddl_branch.DataValueField = "branch_id";
            Ddl_branch.DataBind();
            Ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldept()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Department().Tables[0];
            Ddl_dept.DataSource = dt;
            Ddl_dept.DataTextField = "dept_name";
            Ddl_dept.DataValueField = "dept_id";
            Ddl_dept.DataBind();
            Ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldoctor()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctorfrmdrrreg(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue)).Tables[0];
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataTextField = "dr_name";
            Ddl_doctor.DataValueField = "dr_id";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddldoctor();
        }

        protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddldoctor();
            DataTable dt = new DataTable();
            dt = objservice.Get_Registereddoctors(Convert.ToInt32(Ddl_branch.SelectedValue)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            if(Ddl_doctor.SelectedValue=="0")
            {
                Response.Write("<script>alert('Please Select Doctor')</script>");
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                objservice.Insert_Doctor(Convert.ToInt32(Ddl_doctor.SelectedValue));
                Response.Write("<script>alert('Doctor Added Successfully')</script>");
                bindddldoctor();
                DataTable dt = new DataTable();
                dt = objservice.Get_Registereddoctors(Convert.ToInt32(Ddl_branch.SelectedValue)).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {

            }
        }
        protected void GridView1_rowdeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_drid") as Label;

            objservice.delete_select(Convert.ToInt32(id.Text));

            DataTable dt = new DataTable();
            dt = objservice.Get_Registereddoctors(Convert.ToInt32(Ddl_branch.SelectedValue)).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            bindddldoctor();
            Response.Write("<script>alert('Doctor Deleted Successfully...!!')</script>");
        }
    }
}