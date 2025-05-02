using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountsApp
{
    public partial class Supplier_authorized_payments : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "1222"; 
                if (Session["USERID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                
            }
        }
        protected void viewreport(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds = objService.Supplier_AuthorizationReport(txtfrmdate.Text, txttodate.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                }
                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/AuthorizedPayment.rdlc");
                //ReportParameter Prm;
                //Prm = new ReportParameter("prm_head");
                //Prm.Values.Add("AUTHORIZATION REPORT AS ON " + txtfrmdate.Text + " to " + txttodate.Text);
                //ReportViewer1.LocalReport.SetParameters(Prm);
                //ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                //ReportViewer1.DataBind();
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(datasource);

            }
            catch (Exception ex)
            {

            }
        }
        protected void download_report(object sender, EventArgs e)
        {
            try
            {
                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();

                cell1.Controls.Add(GridView1);
                tr1.Cells.Add(cell1);


                tb.Rows.Add(tr1);
                //tb.Rows.Add(tr2);
                Response.ContentType = "application/x-msexcel";
                Response.AddHeader("Content-Disposition", "attachment;filename = adjust_cr_note_rpt_Report.xls");
                Response.ContentEncoding = Encoding.UTF8;
                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                tb.RenderControl(hw);
                Response.Write(tw.ToString());
                Response.End();

            }
            catch (Exception ex)
            {

            }
        }
    }
}