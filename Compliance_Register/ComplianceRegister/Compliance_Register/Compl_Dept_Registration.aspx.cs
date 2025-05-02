using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Compliance_Register
{
    public partial class Compl_Dept_Registration : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddldept();
                bindgrid();
            }
        }
        private void bindddldept()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_depertment().Tables[0];
            ddl_Dept.DataSource = dt1;
            ddl_Dept.DataTextField = "dept_name";
            ddl_Dept.DataValueField = "dept_id";
            ddl_Dept.DataBind();
            ddl_Dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        public void clear()
        {
            ddl_Dept.SelectedIndex = 0;
            txtAutoComplete.Text = string.Empty;
        }
        public void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_grid().Tables[0];
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
        }

        protected void txtAutoComplete_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_empcode(txtAutoComplete.Text).Tables[0];
            ddl_empcode.DataSource = dt1;
            ddl_empcode.DataTextField = "name";
            ddl_empcode.DataValueField = "username";
            ddl_empcode.DataBind();
            ddl_empcode.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //if (rowIndex==0) rowIndex
                GridViewRow row = GridView1.Rows[rowIndex];
                ddl_Dept.SelectedValue = row.Cells[0].Text;
                txtAutoComplete.Text = row.Cells[2].Text;

            }
        }
        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            objservice.Insert_Compliance_Reg(Convert.ToInt32(ddl_Dept.SelectedValue), txtAutoComplete.Text,1);
            Response.Write("<script>alert('Successfully Registered')</script>");
            bindgrid();
            clear();
        }

        protected void ddl_empcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAutoComplete.Text = ddl_empcode.SelectedValue;
        }

  
        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            GridViewRow row = GridView1.Rows[index];
            int Id = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Values[0]);
            ddl_Dept.SelectedValue = Id.ToString();
            txtAutoComplete.Text = row.Cells[2].Text;
           
        }
    }
}