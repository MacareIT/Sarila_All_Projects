using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationDashboard
{
    public partial class Agreement_Renewal : System.Web.UI.Page
    {
        ServiceReference1.WebService_OperationDashboardSoapClient objService = new ServiceReference1.WebService_OperationDashboardSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HiddenField1.Value = "0";
                bindgrid();
            }
        }
        public void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objService.Get_grid_Agrmnt_renewal().Tables[0];
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
        
        public void clear()
        {
            txt_Agrmnt_type.Text = string.Empty;
            txt_Agrmnt_party.Text = string.Empty;
            txt_reminder2.Text = string.Empty;
            txt_renewal.Text = string.Empty;
            txt_reminder3.Text = string.Empty;
            txt_reminder1.Text = string.Empty;
            txt_dt_Exectn.Text = string.Empty;
            HiddenField1.Value = "0";
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            //Session.Add("username","150739");
            if (HiddenField1.Value == "0")
                result = objService.Insert_AgreementRenewal(0, txt_Agrmnt_type.Text, txt_Agrmnt_party.Text, txt_dt_Exectn.Text, txt_renewal.Text, txt_reminder1.Text, txt_reminder2.Text, txt_reminder3.Text, DateTime.Now.ToString("dd-MM-yyyy"), Session["username"].ToString());
            else result = objService.update_AgreementRenewal(Convert.ToInt32(HiddenField1.Value), txt_Agrmnt_type.Text, txt_Agrmnt_party.Text, txt_dt_Exectn.Text, txt_renewal.Text, txt_reminder1.Text, txt_reminder2.Text, txt_reminder3.Text, DateTime.Now.ToString("dd-MM-yyyy"), Session["username"].ToString());

            if (result > 0)
            {
                Response.Write("<script>alert('Successfully Registered')</script>");
                bindgrid();
                clear();
            }
            else
            {
                Response.Write("<script>alert('Error Occured')</script>");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                //if (rowIndex==0) rowIndex
                GridViewRow row = GridView1.Rows[rowIndex];
                string id = GridView1.DataKeys[rowIndex].Value.ToString();
                HiddenField1.Value = id;
                txt_Agrmnt_type.Text = row.Cells[1].Text;
                txt_Agrmnt_party.Text = row.Cells[2].Text;
                txt_dt_Exectn.Text = row.Cells[3].Text;
                txt_renewal.Text = row.Cells[4].Text;
                txt_reminder1.Text = row.Cells[5].Text;
                txt_reminder2.Text = row.Cells[6].Text;
                txt_reminder3.Text = row.Cells[7].Text;
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString(); int result = 0;
            //result = objService.delete_AgreementRenewal(Convert.ToInt32(id));
            if (result == 1)
            {
                Response.Write("<script>alert('Deleted Registered')</script>");
                bindgrid();
            }
            else
            {
                Response.Write("<script>alert('Error Occured')</script>");
            }
        }
    }
}