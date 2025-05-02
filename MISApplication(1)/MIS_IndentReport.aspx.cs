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
    public partial class MIS_IndentReport : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               ///Session["USERID"] = "123";
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                //chooseoption.Style.Add("display", "none");
                fillBranch();
                fillItems();

            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ConfirmBox", "ConfirmBox();", true);
        }
        private void fillItems()
        {
            ds = new DataSet();
            ds = objService.List_medicines();
            ddlmedicine.DataSource = ds.Tables[0];
            ddlmedicine.DataTextField = "item_name";
            ddlmedicine.DataValueField = "item_id";
            ddlmedicine.DataBind();
            ddlmedicine.Items.Insert(0, "Select");
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
                ds = new DataSet();
                ds = objService.MIS_IndentReport(ddlbranch.SelectedIndex > 0 ? ddlbranch.SelectedValue : "0", txtfrmdt.Text, txttodate.Text, "0", "datewise", "0");
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IndentReport.rdlc");
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("INTENT DETAILS OF  BRANCH : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text + "  to  " + txttodate.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                //ddlmedicine.SelectedIndex = 0;



            }
            catch (Exception ex)
            {
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
        protected void showmedicineList(object sender, EventArgs e)
        {
            try
            {
                if (txtindent.Text != string.Empty)
                {
                    string header = "";
                    ds = new DataSet();
                    ds = objService.MIS_IndentReport("0", txtfrmdt.Text, txttodate.Text, "0", "INDENTWISE", txtindent.Text);
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IndentReport.rdlc");
                    ReportParameter Prm;
                    Prm = new ReportParameter("prm_head1");
                    Prm.Values.Add("INTENT DETAILS OF INDENTID: " + txtindent.Text);
                    ReportViewer1.LocalReport.SetParameters(Prm);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }
                //ddlmedicine.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                ReportViewer1.LocalReport.DataSources.Clear();

            }
        }

        protected void ddlmedicine_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlmedicine.SelectedIndex > 0)
                {
                    //string header = "";
                    ds = new DataSet();
                    ds = objService.MIS_IndentReport("0", txtfrmdt.Text, txttodate.Text, ddlmedicine.SelectedValue, "medicinewise", "0");
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IndentReport.rdlc");
                    ReportParameter Prm;
                    Prm = new ReportParameter("prm_head1");
                    Prm.Values.Add("INTENT DETAILS OF  MEDICINE : " + ddlmedicine.SelectedItem);
                    ReportViewer1.LocalReport.SetParameters(Prm);
                    ReportViewer1.LocalReport.SetParameters(Prm);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }

                ddlmedicine.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ReportViewer1.LocalReport.DataSources.Clear();

            }

        }

        protected void Showsearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Showsearch.SelectedValue == "1")
                {

                    //string header = "";
                    ds = new DataSet();
                    ds = objService.MIS_IndentReport("0", txtfrmdt.Text, txttodate.Text, "0", "TRANSFERPENDING", "0");
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IndentReport.rdlc");
                    ReportParameter Prm;
                    Prm = new ReportParameter("prm_head1");
                    Prm.Values.Add("INTENT DETAILS OF  TRANSFERED PENDING MEDICINE ");
                    ReportViewer1.LocalReport.SetParameters(Prm);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }
                else if (Showsearch.SelectedValue == "2")
                {
                    //string header = "";
                    ds = new DataSet();
                    ds = objService.MIS_IndentReport("0", txtfrmdt.Text, txttodate.Text, "0", "RECEIVEDPENDING", "0");
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IndentReport.rdlc");
                    ReportParameter Prm;
                    Prm = new ReportParameter("prm_head1");
                    Prm.Values.Add("INTENT DETAILS OF  RECEIVED PENDING MEDICINE ");
                    ReportViewer1.LocalReport.SetParameters(Prm);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }
                else if (Showsearch.SelectedValue == "3")
                {
                    //string header = "";
                    ds = new DataSet();
                    ds = objService.MIS_IndentReport("0", txtfrmdt.Text, txttodate.Text, "0", "ALLPENDING", "0");
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IndentReport.rdlc");
                    ReportParameter Prm;
                    Prm = new ReportParameter("prm_head1");
                    Prm.Values.Add("ALL PENDING INDENT DETAILS ");
                    ReportViewer1.LocalReport.SetParameters(Prm);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.DataBind();
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                }
                ddlmedicine.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                ReportViewer1.LocalReport.DataSources.Clear();

            }


        }
    }
}