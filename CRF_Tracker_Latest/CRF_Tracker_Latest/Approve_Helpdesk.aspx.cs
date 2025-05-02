using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRF_Tracker_Latest
{
    public partial class Approve_Helpdesk : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objservice = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt_approve = objservice.Get_ticket_forApprove().Tables[0];
                if (dt_approve.Rows.Count > 0)
                {
                    GridView1.DataSource = dt_approve;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
        }
        protected void Recommend_Click(object sender, GridViewSelectEventArgs e)
        {
            int result = 0;
            foreach (GridViewRow gr in GridView1.Rows)
            {
                if (((DropDownList)gr.FindControl("DropDownList1")).SelectedItem.Text == "Approve")
                {
                    result = objservice.Update_Approvestatus(Convert.ToInt32(gr.Cells[0].Text), "Approved", Session["username"].ToString());
                }
                else
                {
                    result = objservice.Update_Approvestatus(Convert.ToInt32(gr.Cells[0].Text), "Rejected", Session["username"].ToString());
                }
            }
        }
    }
}