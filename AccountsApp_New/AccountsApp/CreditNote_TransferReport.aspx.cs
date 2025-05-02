using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;


namespace AccountsApp
{
    public partial class CreditNote_TransferReport : System.Web.UI.Page
    {
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void viewreport(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                if (ddltype.Text == "1")
                {
                    ds = objService.Accounts_CR_transfer_Report(txtfrmdate.Text, txttodate.Text);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CreditNote_Transfer.rdlc");
                }
                else
                {
                    ds = objService.Accounts_CR_Receive_Report(txtfrmdate.Text, txttodate.Text);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CreditNote_Receive.rdlc");
                }
                ReportParameter Prm1,Prm2;
                Prm1 = new ReportParameter("fromdate");Prm2 = new ReportParameter("todate");
                Prm1.Values.Add(txtfrmdate.Text);Prm2.Values.Add(txttodate.Text);
                ReportViewer1.LocalReport.SetParameters(Prm1); ReportViewer1.LocalReport.SetParameters(Prm2);
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);

            }
            catch (Exception ex)
            {

            }
        }
    }
}