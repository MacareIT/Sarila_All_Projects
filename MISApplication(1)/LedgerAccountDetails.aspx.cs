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
    public partial class LedgerAccountDetails : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Session["USERID"] = "123";
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillvendors();

            }
        }

        private void fillvendors()
        {
            ds = new DataSet();
            ds = objService.VendorsList();
            ddlvendor.DataSource = ds.Tables[0];
            ddlvendor.DataTextField = "V_NAME";
            ddlvendor.DataValueField = "VENDOR_ID";
            ddlvendor.DataBind();
            ddlvendor.Items.Insert(0, new ListItem("---All Camp---", "0"));
        }
        protected void showreport(object sender, EventArgs e)
        {
            string header = string.Empty;
            try
            {
                ds = new DataSet();
                ds = objService.Vendor_Ledgerdetails(ddlvendor.SelectedValue);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/LedgerDetails.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("LEDGER ACCOUNT DETAILS");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "VENDOR " + ddlvendor.SelectedItem.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
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