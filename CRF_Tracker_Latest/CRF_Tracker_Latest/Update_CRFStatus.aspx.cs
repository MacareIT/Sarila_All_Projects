using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRF_Tracker_Latest
{
    public partial class Update_CRFStatus : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objService = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null)
                {
                    Response.Redirect("signin.aspx");
                }

                DataTable dt = new DataTable();
                dt = objService.Get_Crfforstatus().Tables[0];
                ddl_crf.DataSource = dt;
                ddl_crf.DataTextField = "crf_name";
                ddl_crf.DataValueField = "crf_id";
                ddl_crf.DataBind();
                ddl_crf.Items.Insert(0, new ListItem("---Select---", "0"));
            }
        }

        protected void update_Click(object sender, EventArgs e)
        {
            string curr_datefield = string.Empty;
            if (ddl_status.SelectedValue == "Development Started")
                curr_datefield = "actualdev_startdate=sysdate";
            else if (ddl_status.SelectedValue == "Development Completed")
                curr_datefield = "actualdev_enddate=sysdate";
            else if (ddl_status.SelectedValue == "QA Started")
                curr_datefield = "actualqa_startdate=sysdate";
            else if (ddl_status.SelectedValue == "QA Completed")
                curr_datefield = "actualqa_enddate=sysdate";
            else if (ddl_status.SelectedValue == "UAT Started")
                curr_datefield = "uat_startdate=sysdate";
            else if (ddl_status.SelectedValue == "UAT Completed")
                curr_datefield = "uat_enddate=sysdate";
            else if (ddl_status.SelectedValue == "UAT Confirmed")
                curr_datefield = "uat_confirmdate=sysdate";
            else if (ddl_status.SelectedValue == "Live")
                curr_datefield = "livedate=sysdate";
            else if (ddl_status.SelectedValue == "User Confirmed")
                curr_datefield = "userconfirm_date=sysdate";
            else if (ddl_status.SelectedValue == "Cancelled")
                curr_datefield = "userconfirm_date=''";
            else if (ddl_status.SelectedValue == "Completed")
                curr_datefield = "userconfirm_date=sysdate";
            else { }
            int result = objService.Update_Crfstatus(ddl_crf.SelectedValue, ddl_status.SelectedValue, curr_datefield,txt_remarks.Text,ddl_delay.SelectedValue);
            if (result == 1)
            {
                Response.Write("<script>alert('CRF status Updated...!!')</script>");
                ddl_crf.ClearSelection();
                ddl_status.ClearSelection();
            }

        }
    }
}