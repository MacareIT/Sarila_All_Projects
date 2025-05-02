using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRM_Application
{
    public partial class Edit_booking : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
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

        private void bindddldoctor()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctor_departmentforconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue), Text_date.Text).Tables[0];
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataTextField = "doctor_name";
            Ddl_doctor.DataValueField = "dr_id";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_BookingDtls_forconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            bindddldoctor();
        }

        protected void ddl_dr_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView1.Visible = true;
            bindgrid();
        }



        protected void ChangeDate_Event(object sender, EventArgs e)
        {
            bindddldoctor();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            //NewEditIndex property used to determine the index of the row being edited.  
            GridView1.EditIndex = e.NewEditIndex;
            bindgrid();
        }
        protected void GridView1_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            //Finding the controls from Gridview for the row which is going to update  
            Label id = GridView1.Rows[e.RowIndex].FindControl("lbl_bookingid") as Label;
            string name = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Text_name")).Text;
            string phone = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Text_phone")).Text;

            objservice.Update_Bookingdtl(Convert.ToInt32(id.Text), name, phone);
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            bindgrid();
        }
        protected void GridView1_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            //Setting the EditIndex property to -1 to cancel the Edit mode in Gridview  
            GridView1.EditIndex = -1;
            bindgrid();
        }
    }
}