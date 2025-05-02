using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRF_Tracker_Latest
{
    public partial class CRF_Approve : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objService = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if ((string)Session["USERTYPE"] == "cfo")
                        btn_submit.Text = "APPROVE";
                    else btn_submit.Text = "RECOMMEND";
                    panel1.Visible = false;
                }

                bindddlcrf();
            }
        }

        private void bindddlcrf()
        {
            DataTable dt = new DataTable();
            if ((string)Session["USERTYPE"] == "itcoordinator")
                dt = objService.Get_Crf_forRecommend().Tables[0];
            else if ((string)Session["USERTYPE"] == "cfo")
                dt = objService.Get_Crf_forApprove().Tables[0];
            else { }
            if (dt.Rows.Count > 0)
            {
                ddl_crf.DataSource = dt;
                ddl_crf.DataTextField = "crf_name";
                ddl_crf.DataValueField = "crf_id";
                ddl_crf.DataBind();
                ddl_crf.Items.Insert(0, new ListItem("---Select---", "0"));
            }
        }
        protected void ddlcrf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objService.Get_CrfDtls(ddl_crf.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                panel1.Visible = true;
                label_crfid.Text = dt.Rows[0]["crf_id"].ToString();
                label_crfname.Text = dt.Rows[0]["crf_name"].ToString();
                label_description.Text = dt.Rows[0]["crf_description"].ToString();
                Label_reqtype.Text = dt.Rows[0]["req_type"].ToString();
                Label_priority.Text = dt.Rows[0]["priority"].ToString();
                Label_scope.Text = dt.Rows[0]["crf_scope"].ToString();
                Label_requestor.Text = dt.Rows[0]["requestor_name"].ToString();
                //Label_headremarks.Text = dt.Rows[0]["head_remarks"].ToString();
            }
            else panel1.Visible = false;
        }

        protected void Reject_Click(object sender, EventArgs e)
        {
            if ((string)Session["USERTYPE"] == "itcoordinator")
            {
                int result = objService.Update_Approve_reject(ddl_crf.SelectedValue, txt_remarks.Text, "Coordinator Rejected", (string)Session["USERID"], (string)Session["USERTYPE"]);
                if (result == 1)
                {
                    Response.Write("<script>alert('CRF Rejected...!!')</script>");
                    bindddlcrf();
                }
            }
            else if ((string)Session["USERTYPE"] == "cfo")
            {
                int result = objService.Update_Approve_reject(ddl_crf.SelectedValue, txt_remarks.Text, "Cfo Rejected", (string)Session["USERID"], (string)Session["USERTYPE"]);
                if (result == 1)
                {
                    Response.Write("<script>alert('CRF Rejected...!!')</script>");
                    bindddlcrf();
                }
            }
            else { }
        }

        protected void Recommend_Click(object sender, EventArgs e)
        {
            if ((string)Session["USERTYPE"] == "itcoordinator")
            {
                int result = objService.Update_Approve_reject(ddl_crf.SelectedValue, txt_remarks.Text, "Coordinator Recommended", "", (string)Session["USERTYPE"]);
                if (result == 1)
                {
                    Response.Write("<script>alert('CRF Recommended...!!')</script>");
                    bindddlcrf();
                }
            }
            else if ((string)Session["USERTYPE"] == "cfo")
            {
                int result = objService.Update_Approve_reject(ddl_crf.SelectedValue, txt_remarks.Text, "Cfo Approved", "", (string)Session["USERTYPE"]);
                if (result == 1)
                {
                    Response.Write("<script>alert('CRF Approved...!!')</script>");
                    bindddlcrf();
                }
            }

            else { }
        }

        protected void Btncrfdoc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objService.Get_CrfDtls(ddl_crf.SelectedValue).Tables[0];
            string docpath = dt.Rows[0]["reference_doc"].ToString();
            Response.Redirect(docpath);
            ddl_crf.Visible = false;
        }
    }
}