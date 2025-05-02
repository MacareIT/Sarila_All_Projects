using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountsApp
{
    public partial class OpticalPO_ConfirmReport : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["USERID"] = "1222"; 
            if (Session["USERID"] == null)
            {
                //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                Response.Redirect("Login.aspx");
            }
        }
        protected void viewreport(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                //ds = objService.Optical_PO_confirmation("1256",txtfrmdate.Text, txttodate.Text);
                ds = objService.Optical_Invoice_confirmation("1256", txtfrmdate.Text, txttodate.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/OpticalPO_confirmation.rdlc");
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head");
                Prm.Values.Add("OPTICAL INVOICE CONFIRMATION REPORT AS ON " + txtfrmdate.Text + " to " + txttodate.Text);
                ReportViewer1.LocalReport.SetParameters(Prm);
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