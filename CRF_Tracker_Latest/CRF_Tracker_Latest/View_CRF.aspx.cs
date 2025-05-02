using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace CRF_Tracker_Latest
{
    public partial class View_CRF : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objService = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null)
                {
                    Response.Redirect("signin.aspx");
                }
                Panel1.Visible = false;
                //load_CRFDtls();
            }
        }

        protected void ddlcrf_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_CRFDtls();
        }
        public void load_CRFDtls()
        {
            DataTable dt = objService.Get_CrfDtls(ddl_crf.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Panel1.Visible = true;
                label_crfid.Text = dt.Rows[0]["crf_id"].ToString();
                label_crfname.Text = dt.Rows[0]["crf_name"].ToString();
                label_description.Text = dt.Rows[0]["crf_description"].ToString();
                Label_reqtype.Text = dt.Rows[0]["req_type"].ToString();
                Label_priority.Text = dt.Rows[0]["priority"].ToString();
                Label_scope.Text = dt.Rows[0]["crf_scope"].ToString();
                Label_requestor.Text = dt.Rows[0]["requestor_name"].ToString();
                DataSet ds = new DataSet();
                ds = objService.View_tamaster(ddl_crf.SelectedValue);
                if (ds.Tables[0].Rows[0]["dev_startdate"].ToString() != "" && ds.Tables[0].Rows[0]["dev_enddate"].ToString() != "")
                {
                    GridView2.DataSource = ds;
                    GridView2.DataBind();
                    DataSet ds1 = new DataSet();
                    ds1 = objService.View_ta(ddl_crf.SelectedValue);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        h5.Visible = true;
                        GridView3.DataSource = ds1;
                        GridView3.DataBind();
                    }
                    else
                    {
                        h5.Visible = true;
                        GridView3.DataSource = null;
                        GridView3.DataBind();
                    }
                }
            }
            else
            {
                h5.Visible = false;
                Panel1.Visible = false;
                GridView3.DataSource = null;
                GridView3.DataBind();
            }
        }
        protected void Btncrfdoc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objService.Get_CrfDtls(ddl_crf.SelectedValue).Tables[0];
            string docpath = dt.Rows[0]["reference_doc"].ToString();
            Response.Redirect(docpath);
        }

        protected void Btnqadoc_Click(object sender, EventArgs e)
        {
            if (GridView2.Rows.Count > 0)
            {
                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "TA Report - " + label_crfid.Text + " " + label_crfname.Text;
                tr1.Cells.Add(cell1);

                TableRow tr2 = new TableRow();
                TableCell cell2 = new TableCell();
                cell2.Text = " ";
                tr2.Cells.Add(cell2);

                TableRow tr3 = new TableRow();
                TableCell cell3 = new TableCell();
                cell3.Text = " ";
                tr3.Cells.Add(cell3);

                TableRow tr4 = new TableRow();
                TableCell cell4 = new TableCell();
                cell4.Controls.Add(GridView2);
                tr4.Cells.Add(cell4);

                TableRow tr5 = new TableRow();
                TableCell cell5 = new TableCell();
                cell5.Text = " ";
                tr5.Cells.Add(cell5);

                TableRow tr6 = new TableRow();
                TableCell cell6 = new TableCell();
                cell6.Controls.Add(GridView3);
                tr6.Cells.Add(cell6);

                tb.Rows.Add(tr1);
                tb.Rows.Add(tr2);
                tb.Rows.Add(tr3);
                tb.Rows.Add(tr4);
                tb.Rows.Add(tr5);
                tb.Rows.Add(tr6);

                Response.ContentType = "application/x-msexcel";
                Response.AddHeader("Content-Disposition", "attachment;filename = TAFile.xls");
                Response.ContentEncoding = Encoding.UTF8;
                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                tb.RenderControl(hw);
                Response.Write(tw.ToString());
                Response.End();
            }
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_type.SelectedValue == "---Select---")
            { }
            else
            {
                DataTable dt = objService.Get_CrfwithId(ddl_type.SelectedValue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    ddl_crf.DataSource = dt;
                    ddl_crf.DataTextField = "crf_name";
                    ddl_crf.DataValueField = "crf_id";
                    ddl_crf.DataBind();
                    load_CRFDtls();
                }
                else
                {
                    ddl_crf.DataSource = null;
                    ddl_crf.DataTextField = null;
                    ddl_crf.DataValueField = null;
                    ddl_crf.DataBind();
                    ddl_crf.SelectedValue = null;
                }
            }
        }
    }
}