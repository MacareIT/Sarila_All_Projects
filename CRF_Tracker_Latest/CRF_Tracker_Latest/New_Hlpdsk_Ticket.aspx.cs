using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRF_Tracker_Latest
{
    public partial class New_Hlpdsk_Ticket : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objService = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_designtn(); 
                Load_users();
                if (ddl_type.SelectedItem.ToString() == "CRF Based")
                {
                    txt_crf.Enabled = true;
                }
                else
                {
                    txt_crf.Enabled = false;
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); int result = 0; string crf_id = string.Empty;
            ds = objService.Get_TicketId();
            string Crfid = ds.Tables[0].Rows[0].ItemArray[0].ToString();

            result = objService.Insert_NewTicket(Convert.ToInt32(Crfid), ddl_emp.SelectedValue, txt_issue.Text, ddl_type.SelectedItem.ToString(), txt_crf.Text);
            if (result == 1)
            {
                Response.Write("<script>alert('CRF Added Successfully...!!')</script>");
                txt_issue.Text = string.Empty;
            }
        }

        public void Load_designtn()
        {
            DataSet ds = new DataSet();
            ds = objService.Get_designation();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_dept.DataSource = ds.Tables[0];
                ddl_dept.DataTextField = "designation";
                ddl_dept.DataValueField = "type";
                ddl_dept.DataBind();
            }
        }

        public void Load_users()
        {
            DataSet ds = new DataSet();
            ds = objService.Get_users(ddl_dept.SelectedItem.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_emp.DataSource = ds.Tables[0];
                ddl_emp.DataTextField = "log_user";
                ddl_emp.DataValueField = "username";
                ddl_emp.DataBind();
            }
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_users();
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_type.SelectedItem.ToString() == "CRF Based")
            {
                txt_crf.Enabled = true;
            }
            else
            {
                txt_crf.Enabled = false;
            }
        }
    }
}