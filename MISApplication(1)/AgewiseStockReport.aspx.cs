using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AgewiseStockReport : System.Web.UI.Page
    {
        DataSet ds,ds1;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "123";
                if (Session["USERID"] == null)
                {
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillBranch();

            }
        }

        private void fillBranch()
        {
            ds = new DataSet();
            ds = objService.Hospital_pharmacy_Branch();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "branch_name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, "ALL");
        }
        protected void showreport(object sender, EventArgs e)
        {
            try
            {
                string header = "";
                ds = new DataSet();ds1 = new DataSet();
                ds = objService.Agewise_stockReport(ddlbranch.SelectedValue);
                ds1 = objService.Agewise_stock_criteria(ddlbranch.SelectedValue);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/AgewiseStockReport.rdlc");
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head");
                Prm.Values.Add("AGEWISE STOCK REPORT OF  BRANCH : " + ddlbranch.SelectedItem.Text);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[0]);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);

            }
            catch (Exception ex)
            {
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
    }
}