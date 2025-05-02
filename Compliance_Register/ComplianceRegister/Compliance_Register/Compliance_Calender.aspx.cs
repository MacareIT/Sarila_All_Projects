using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Compliance_Register
{
    public partial class Compliance_Calender : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddldept();
                bindgrid();
                if (ddl_duration.SelectedValue == "Monthly")
                {
                    txt_alert.Enabled = false;
                    txt_due.Enabled = false;
                }
                else
                {
                    txt_alert.Enabled = true;
                    txt_due.Enabled = true;
                }
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
            //ddl_Dept.SelectedValue = "0";
            txt_due.Text = string.Empty;
            txt_alert.Text = string.Empty;
            txt_desc.Text = string.Empty;
            lbl_id.Text = "0";
        }
        public void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_grid_Calendar(Convert.ToInt32(ddl_Dept.SelectedValue)).Tables[0];
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
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        //    if (e.CommandName == "select")
        //    {
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = GridView1.Rows[rowIndex];
        //        lbl_id.Text = row.Cells[0].Text;
        //        ddl_Dept.SelectedValue = row.Cells[1].Text;
        //        ddl_type.SelectedValue = row.Cells[3].Text;
        //        txt_desc.Text = row.Cells[4].Text;
        //        txt_date.Text = row.Cells[5].Text;
        //    }
        //    else if (e.CommandName == "delete")
        //    {
        //        int rowIndex = Convert.ToInt32(e.CommandArgument);
        //        GridViewRow row = GridView1.Rows[rowIndex];
        //        lbl_id.Text = row.Cells[0].Text;
        //        objservice.Delete_Compliance_Calendar(Convert.ToInt32(lbl_id.Text));
        //        clear();
        //        bindgrid();
        //    }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (Button button in e.Row.Cells[7].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete?')){ return false; };";
                    }
                }
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            if (lbl_id.Text == "0" || lbl_id.Text == "")
            {
                objservice.Insert_Compliance_Calendar(Convert.ToInt32(ddl_Dept.SelectedValue), ddl_type.Text.ToString(), txt_desc.Text,ddl_duration.SelectedValue,txt_due.Text,txt_alert.Text);
                Response.Write("<script>alert('Successfully Registered')</script>");
                clear();
                bindgrid();
            }
            else
            {
                objservice.Update_Compliance_Calendar(Convert.ToInt32(lbl_id.Text), Convert.ToInt32(ddl_Dept.SelectedValue),ddl_type.SelectedValue,txt_desc.Text, ddl_duration.SelectedValue,txt_due.Text,txt_alert.Text);
                Response.Write("<script>alert('Successfully Updated')</script>");
                clear();
                bindgrid();
            }
            bindgrid();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int index = e.NewSelectedIndex;
            GridViewRow row = GridView1.Rows[index];
            lbl_id.Text = GridView1.DataKeys[e.NewSelectedIndex].Values[0].ToString();
            int dept_Id = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Values[1]);
            ddl_Dept.SelectedValue = dept_Id.ToString();
            string str= row.Cells[3].Text;

            ddl_type.SelectedValue= row.Cells[3].Text;
            txt_desc.Text= row.Cells[4].Text;
            ddl_duration.SelectedValue= row.Cells[5].Text;
            txt_due.Text= row.Cells[6].Text;
            txt_alert.Text = row.Cells[7].Text;
        }

        protected void ddl_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = GridView1.Rows[index];
            int com_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            objservice.Delete_Compliance_Calendar(com_id);
            bindgrid();
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_duration.SelectedValue=="Monthly")
            {
                txt_alert.Enabled = false;
                txt_due.Enabled = false;
            }
            else
            {
                txt_alert.Enabled = true;
                txt_due.Enabled = true;
            }
        }

        protected void ddl_duration_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_duration.SelectedValue == "Monthly")
            {
                txt_alert.Enabled = false;
                txt_due.Enabled = false;
            }
            else
            {
                txt_alert.Enabled = true;
                txt_due.Enabled = true;
            }
        }
    }
}