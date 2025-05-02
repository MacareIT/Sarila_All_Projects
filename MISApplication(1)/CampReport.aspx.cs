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
    public partial class CampReport : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "123";
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                //chooseoption.Style.Add("display", "none");
                fillCamp();

            }
        }

        private void fillCamp()
        {
            ds = new DataSet();
            ds = objService.Campdetails();
            ddlcamp.DataSource = ds.Tables[0];
            ddlcamp.DataTextField = "campname";
            ddlcamp.DataValueField = "campid";
            ddlcamp.DataBind();
            ddlcamp.Items.Insert(0, new ListItem("---All Camp---", "0"));
        }
        protected void showPatientreport(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds = objService.CampPatientdetails_campId(ddlcamp.SelectedIndex > 0 ? ddlcamp.SelectedValue : "0", txtfrmdt.Text, txttodate.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CampPatientList.rdlc");
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head");
                if (ddlcamp.SelectedIndex > 0)
                    Prm.Values.Add("PATIENTS LIST OF  CAMP: " + ddlcamp.SelectedItem.Text);
                else
                    Prm.Values.Add(" ALL PATIENTS LIST AS ON " + txtfrmdt.Text + " to " + txttodate.Text);
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
        protected void showConversionreport(object sender, EventArgs e)
        {
            try
            {
            ds = new DataSet();
            ds = objService.CampPatient_ConversionReport(ddlcamp.SelectedIndex>0?ddlcamp.SelectedValue:"0",txtfrmdt.Text,txttodate.Text);
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CampConversionList.rdlc");
            ReportParameter Prm;
            Prm = new ReportParameter("prm_head");
                if(ddlcamp.SelectedIndex>0)
                    Prm.Values.Add("PATIENTS CONVERSION LIST OF  CAMP: " + ddlcamp.SelectedItem.Text);
                else
                    Prm.Values.Add(" PATIENTS CONVERSION LIST AS ON "+txtfrmdt.Text+" to "+txttodate.Text);

                ReportViewer1.LocalReport.SetParameters(Prm);
            ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            catch(Exception ex)
            {

            }
            
        }
        protected void showallConversionreport(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds = objService.Allcamp_ConversionReport(txtfrmdt.Text, txttodate.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/CampConversionReport.rdlc");
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head");
                Prm.Values.Add("CONVERSION REPORT AS ON  "+txtfrmdt.Text+" to "+txttodate.Text);
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