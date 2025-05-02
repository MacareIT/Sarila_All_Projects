using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PurchaseCommittee
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_requested.Text = objservice.Get_totalrequested().ToString();
            lbl_scheduled.Text = objservice.Get_totalpending().ToString();
            lbl_rejected.Text = objservice.Get_totalrejected().ToString();
        }

        protected void Pending_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_PendingQuotations.aspx");
        }

        protected void Scheduled_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_Schedule.aspx");
        }

        protected void rejected_Click(object sender, EventArgs e)
        {
            Response.Redirect("View_Rejected.aspx");
        }
    }
}