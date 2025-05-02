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
    public partial class IncentiveAmountReport : System.Web.UI.Page
    {
        DataSet ds,ds1;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

        
            //Session["USERID"] = "122";
            if (Session["USERID"] == null)
            {
                //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
            }
            fillclinic(); 
            }
        }

        private void fillclinic()
        {
            ds = new DataSet();
            ds = objService.ListClinic();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Branch--", "0"));
        }
        protected void showreport(object sender, EventArgs e)
        {
            try
            {
                ///////////////REPORT-----------------
                string header = string.Empty;
                ds = new DataSet();ds1 = new DataSet();
                ds = objService.IncentiveAmount_reportstaff(ddlbranch.SelectedValue, txtfrmdt.Text, txttodt.Text);
                ds1 = objService.IncentiveAmount_reportHead(ddlbranch.SelectedValue, txtfrmdt.Text, txttodt.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IncentiveStaffDetails.rdlc");
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("INCENTIVE AMOUNT DETAILS OF : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text+ "  to  "+txttodt.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[0]);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);

            }
            catch (Exception ex)
            {

            }
           

        }
    }
}