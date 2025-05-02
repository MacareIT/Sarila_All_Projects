using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRF_Tracker_Latest
{
    public partial class Resolve_Helpdesk : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objService = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void Recommend_Click(object sender, GridViewSelectEventArgs e)
        {
            //int result = objService.Update_Approve_reject(ddl_crf.SelectedValue, txt_remarks.Text, "Coordinator Recommended", "", (string)Session["USERTYPE"]);
            //if (result == 1)
            //{
            //    Response.Write("<script>alert('CRF Recommended...!!')</script>");
            //    bindddlcrf();
            //}
        }
    }
}