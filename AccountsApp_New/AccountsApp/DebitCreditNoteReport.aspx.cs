using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountsApp
{
    public partial class DebitCreditNoteReport : System.Web.UI.Page
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
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                    Response.Redirect("Login.aspx");
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
            ddlbranch.Items.Insert(0, "ALL PHARMACY");
        }
        protected void viewreport(object sender, EventArgs e)
        {
      
            try
            {
                ds = new DataSet();
                ds = objService.Debit_Credit_note_Report(txtfrmdate.Text, txttodate.Text,ddlbranch.SelectedIndex>0?ddlbranch.SelectedValue:"0",ddltype.SelectedValue);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/DebitCreditnote.rdlc");
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head");
                if(ddlbranch.SelectedIndex>0)
                    Prm.Values.Add("CREDIT NOTE REPORT OF BRANCH :"+ddlbranch.SelectedItem+" AS ON " + txtfrmdate.Text + " to " + txttodate.Text);
               else
                    Prm.Values.Add("CREDIT NOTE REPORT OF ALL BRANCHES AS ON " + txtfrmdate.Text + " to " + txttodate.Text);
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