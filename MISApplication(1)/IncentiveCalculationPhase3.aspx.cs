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
    public partial class IncentiveCalculationPhase3 : System.Web.UI.Page
    {
        DataSet ds, ds1, ds2;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["USERID"] = "55";
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
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
        protected void showreportincentive(object sender, EventArgs e)
        {
            string pharmacyid1 = "0", pharmacyid2 = "0", opticalid1 = "0", dentalid = "0";

            try
            {
                if (ddlbranch.SelectedValue == "1256")///////Valappad Branch
                {
                    pharmacyid1 = "2435";/////Old pharmacy Valappad
                    pharmacyid2 = "3348";////new pharmacy valappad
                    opticalid1 = "3284";/////Optical valappad
                    dentalid = "3114";//////dental valappad
                }
                else if (ddlbranch.SelectedValue == "3250")//////Vatanapally
                {
                    pharmacyid1 = "3391";////pharmacy vatanapally
                    opticalid1 = "3449";/////optical vatanapally
                }
                else if (ddlbranch.SelectedValue == "3153")/////Katoor
                {
                    pharmacyid1 = "3390";/////pharmacy katoor
                    opticalid1 = "3451";/////optical katoor
                    dentalid = "3412";///////dental katoor
                }
                else if (ddlbranch.SelectedValue == "3458")/////Kanjani
                {
                    pharmacyid1 = "3460";/////pharmacy Kanjani
                    opticalid1 = "3459";/////optical Kanjani
                    //dentalid = "3412";///////dental Kanjani
                }
                else if (ddlbranch.SelectedValue == "3465")/////Cherppu
                {
                    pharmacyid1 = "3463";/////pharmacy 
                    opticalid1 = "3464";/////optical 
                    dentalid = "3469";///////dental 
                }
                else
                {
                    pharmacyid2 = "0";
                }
                string header = "";
                ds = new DataSet();
                ds = objService.Incentive_calcamount_phase3(ddlbranch.SelectedValue, txtfrmdt.Text, pharmacyid1,pharmacyid2, dentalid, opticalid1);
                ds1 = new DataSet();
                ds1 = objService.IncentiveAmount_reportHead(ddlbranch.SelectedValue, txtfrmdt.Text, txtfrmdt.Text);
                // ds1 = objService.IncentiveHeadAmount_details(ddlbranch.SelectedValue, txtfrmdt.Text);
                ds2 = new DataSet();
                ds2 = objService.IncentiveStaff_ListAmount(ddlbranch.SelectedValue,dentalid,opticalid1,pharmacyid1,pharmacyid2, txtfrmdt.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[0]);
                ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds2.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("DAILY INCENTIVE COLLECTION : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);

            }
            catch (Exception ex)
            {
                string header = "";
                ds = new DataSet();
                ds = objService.Incentive_details(ddlbranch.SelectedValue, txtfrmdt.Text);
                ds1 = new DataSet();
                ds1 = objService.IncentiveAmount_reportHead(ddlbranch.SelectedValue, txtfrmdt.Text,txtfrmdt.Text);
                //ds1 = objService.IncentiveHeadAmount_details(ddlbranch.SelectedValue, txtfrmdt.Text);
                ds2 = new DataSet();
                ds2 = objService.IncentiveStaff_ListAmount(ddlbranch.SelectedValue, dentalid, opticalid1, pharmacyid1, pharmacyid2, txtfrmdt.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportDataSource datasource2 = new ReportDataSource("DataSet2", ds1.Tables[0]);
                ReportDataSource datasource3 = new ReportDataSource("DataSet3", ds2.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("DAILY INCENTIVE COLLECTION : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportViewer1.LocalReport.DataSources.Add(datasource3);
            }

        }
        protected void showmicrolab(object sender, EventArgs e)
        {
            try
            {
                string header = "";
                ds = new DataSet();
                ds = objService.Incentive_calcMicrolab(ddlbranch.SelectedValue, txtfrmdt.Text);
                ds1 = new DataSet();
                ds1 = objService.IncentiveMicrolabStaffAmount_details(txtfrmdt.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/MicrolabIncentive.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds1.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("MICROLAB INCENTIVE COLLECTION : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
            }
            catch (Exception ex)
            {

            }
        }
        protected void showreport(object sender, EventArgs e)
        {
            string pharmacyid1 = "0", pharmacyid2 = "0", opticalid1 = "0", dentalid = "0";
            if (ddlbranch.SelectedValue == "1256")///////Valappad Branch
            {
                pharmacyid1 = "2435";/////Old pharmacy Valappad
                pharmacyid2 = "3348";////new pharmacy valappad
                opticalid1 = "3284";/////Optical valappad
                dentalid = "3114";//////dental valappad
            }
            else if (ddlbranch.SelectedValue == "3250")//////Vatanapally
            {
                pharmacyid1 = "3391";////pharmacy vatanapally
                opticalid1 = "3449";/////optical vatanapally
            }
            else if (ddlbranch.SelectedValue == "3153")/////Katoor
            {
                pharmacyid1 = "3390";/////pharmacy katoor
                opticalid1 = "3451";/////optical katoor
                dentalid = "3412";///////dental katoor
            }
            else if (ddlbranch.SelectedValue == "3458")/////Kanjani
            {
                pharmacyid1 = "3460";/////pharmacy Kanjani
                opticalid1 = "3459";/////optical Kanjani
                //dentalid = "3412";///////dental Kanjani
            }
            else if (ddlbranch.SelectedValue == "3465")/////Cherppu 
            {
                pharmacyid1 = "3463";/////pharmacy 
                opticalid1 = "3464";/////optical 
                dentalid = "3469";///////dental 
            }
            else
            {
                pharmacyid2 = "0";
            }
            string header = "";
            try
            {

                ds = new DataSet();
                ds = objService.Incentive_calc_phase3(ddlbranch.SelectedValue, txtfrmdt.Text, pharmacyid1, pharmacyid2, opticalid1, dentalid, Session["USERID"].ToString());
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IncentiveCollection.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("DAILY INCENTIVE COLLECTION : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            catch (Exception ex)
            {
                ds = new DataSet();
                ds = objService.Incentive_details(ddlbranch.SelectedValue, txtfrmdt.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/IncentiveCollection.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("DAILY INCENTIVE COLLECTION : " + ddlbranch.SelectedItem.Text + " BRANCH");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }

        }
    }
}