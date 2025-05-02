using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PurchaseCommittee
{
    public partial class Add_Minutes : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string item_id = Request.QueryString["item_id"].ToString();
                DataSet ds = new DataSet();
                ds = objservice.View_Quotations(item_id);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                if (Session["USERTYPE"].ToString() == "purchasehead")
                {
                    appear.Visible = true;
                }
                else appear.Visible = false;
            }
            lbl_quotationid.Visible = false;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "quotation_view")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string quotation_id = (row.FindControl("lbl_quotationid") as Label).Text;

                DataTable dt = new DataTable();
                dt = objservice.View_IndividualQuotations(quotation_id).Tables[0];
                byte[] bytes;
                string fileName, contentType;
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["filename"].ToString() == "")
                    {
                        Response.Write("<script>alert('No file Uploaded')</script>");
                    }
                    else
                    {
                        fileName = dt.Rows[0]["filename"].ToString();
                        contentType = dt.Rows[0]["content_type"].ToString();
                        bytes = (byte[])dt.Rows[0]["attachment"];

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.ContentType = contentType;
                        Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                        Response.BinaryWrite(bytes);
                        Response.Flush();
                        Response.End();
                    }
                }
                else
                {
                    Response.Write("<script>alert('No file Uploaded')</script>");
                }
                //string docpath = dt.Rows[0]["quotation"].ToString();
                //Response.Redirect(docpath);
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            string item_id = Request.QueryString["item_id"].ToString();
            string quotation_id, negotiated_amt;
            DataTable dt = new DataTable();
            foreach (GridViewRow gr in GridView1.Rows)
            {
                if (((CheckBox)gr.Cells[0].FindControl("CheckBox1")).Checked == true)
                {
                    string participants = txt_participants.Text;
                    participants = participants.Replace("'", "''");

                    string decision = txt_decision.Text;
                    decision = decision.Replace("'", "''");

                    quotation_id = ((Label)gr.Cells[0].FindControl("lbl_quotationid")).Text;
                    negotiated_amt = ((TextBox)gr.Cells[0].FindControl("txt_negotiatedamt")).Text;
                    objservice.Add_minutes(item_id, quotation_id, participants, decision, ddl_status.SelectedValue,negotiated_amt);
                }
                else
                {
                    string participants = txt_participants.Text;
                    participants = participants.Replace("'", "''");

                    string decision = txt_decision.Text;
                    decision = decision.Replace("'", "''");

                    quotation_id = ((Label)gr.Cells[0].FindControl("lbl_quotationid")).Text;
                    negotiated_amt = ((TextBox)gr.Cells[0].FindControl("txt_negotiatedamt")).Text;
                    objservice.Add_nonapprovedminutes(item_id, quotation_id, participants, decision, ddl_status.SelectedValue, negotiated_amt);
                }
            }
            Response.Redirect("View_Schedule.aspx");
        }
    }
}