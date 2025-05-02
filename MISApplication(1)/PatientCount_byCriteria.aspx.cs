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
    public partial class PatientCount_byCriteria : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillbranch();
                filldept();

            }
        }
        private void fillbranch()
        {
            ds = new DataSet();
            ds = objService.ListClinic();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "name";
            ddlbranch.DataValueField = "clinic_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Branch--", "0"));
        }
        private void filldept()
        {
            ds = new DataSet();
            ds = objService.Hospital_Departments();
            ddldepartment.DataSource = ds.Tables[0];
            ddldepartment.DataBind();
            ddldepartment.DataTextField = "dept_name";
            ddldepartment.DataValueField = "dept_id";
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, new ListItem("---All Department--", "0"));
        }
        protected void showreport(object sender, EventArgs e)
        {
            string header = string.Empty;
            try
            {
                ds = new DataSet();
                ds = objService.ListDoctors_VisitCount_Datewise(txtfrmdt.Text, txttodate.Text, ddlbranch.SelectedValue, ddldepartment.SelectedValue, ddloption.SelectedValue, txtcriteria.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/DoctorPatientVisit.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("DOCTORS PATIENT-VISIT OF : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text + " to " + txttodate.Text + " " + ddloption.SelectedValue + " " + (ddloption.SelectedIndex == 3 ? "" : txtcriteria.Text);
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