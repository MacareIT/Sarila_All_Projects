using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace MISApplication
{
    public partial class PatientCount_Report : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if(!IsPostBack)
            {
                fillbranch();
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
            //ddlbranch.Items.Insert(0, new ListItem("---Choose Branch--", "0"));
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string header = string.Empty;
            try
            {
                ds = new DataSet();
                ds = objService.ListDoctors_VisitCount(txtfrmdt.Text, txttodate.Text, ddlbranch.SelectedValue);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/DoctorVisitCount.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("CLINICWISE DOCTORS PATIENTVISIT OF : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text + " to " + txttodate.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                //ReportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ItemDetailsSubReportProcessing);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            catch (Exception ex)
            {

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}