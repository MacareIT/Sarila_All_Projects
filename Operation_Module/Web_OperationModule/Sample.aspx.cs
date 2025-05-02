using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace Web_OperationModule
{
    public partial class Sample : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        //string imageUrl = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load_Branch();
                //Load_Month(); Load_Year();
                //cmbYear.SelectedValue = DateTime.Now.ToString("yyyy");
               // string str = DateTime.Now.ToString("MM");
               // cmbMonth.SelectedValue = DateTime.Now.Month.ToString();

            }
        }
        public void Load_Branch()
        {
            DataTable dtBranch = objService.Select_Branch().Tables[0];
            if (dtBranch.Rows.Count > 0)
            {
                cmb_branch.DataSource = dtBranch;
                cmb_branch.DataBind();
            }
        }
        public void Load_Month()
        {
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("MonthNo");
            dtMonth.Columns.Add("MonthName");
            dtMonth.Rows.Add("1", "January"); dtMonth.Rows.Add("2", "February"); dtMonth.Rows.Add("3", "March");
            dtMonth.Rows.Add("4", "April"); dtMonth.Rows.Add("5", "May"); dtMonth.Rows.Add("6", "June");
            dtMonth.Rows.Add("7", "July"); dtMonth.Rows.Add("8", "August"); dtMonth.Rows.Add("9", "September");
            dtMonth.Rows.Add("10", "October"); dtMonth.Rows.Add("11", "November"); dtMonth.Rows.Add("12", "December");
            cmbMonth.DataSource = dtMonth;
            cmbMonth.DataBind();
        }
        public void Load_Year()
        {
            DataTable dtYear = new DataTable();
            dtYear = objService.Select_Year().Tables[0];
            if (dtYear.Rows.Count > 0)
            {
                cmbYear.DataSource = dtYear;
                cmbYear.DataBind();
            }
            else
            {
                DataTable dtYr = new DataTable();
                dtYr.Columns.Add("Year");
                dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
                cmbYear.DataSource = dtYr;
                cmbYear.DataBind();
            }
        }
        // public void Load_Report()
        // {



        //ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
        //string image = "file:///D:\\Images\\vishnu\\img.png";
        //ReportViewer1.LocalReport.EnableExternalImages = true;
        //ReportParameter parameter = new ReportParameter("pImageUrl", image);
        //ReportViewer1.LocalReport.SetParameters(parameter); 
        //ReportViewer1.LocalReport.Refresh();

        //DataSet dss = objService.AmbiencePic_Select(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.Text), Convert.ToInt32(cmb_branch.SelectedValue));
        //if (dss.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        //    {
        //        if (dss.Tables[0].Rows[i]["amb_pic_name"].ToString() == "Lab")
        //        {

        //ReportParameter pName = new ReportParameter("pName", dss.Tables[0].Rows[i]["amb_pic_name"].ToString());
        //ReportParameter pImageUrl = new ReportParameter("pImageUrl", dss.Tables[0].Rows[i]["amb_pic_path"].ToString());
        //this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pName, pImageUrl });
        //string image = new Uri(Server.MapPath("" + dss.Tables[0].Rows[i]["amb_pic_path"].ToString() + "")).AbsoluteUri;
        //string image = new Uri(Server.MapPath("file:///D:/WorkingDirectory/SorceCode/Operation_Module/Web_OperationModule/Ambience_Image/Lab92022bg_1.jpg")).AbsoluteUri;
        //string image= "file:///D:\\Images\\vishnu\\Untitled_design.png";
        //ReportParameter parameter = new ReportParameter("pImageUrl",image);
        //ReportViewer1.LocalReport.SetParameters(parameter);
        //ReportViewer1.LocalReport.Refresh();
        //}
        //if (dss.Tables[0].Rows[i]["amb_pic_name"].ToString() == "Board")
        //{
        //ReportParameter pName1 = new ReportParameter("pName1", dss.Tables[0].Rows[i]["amb_pic_name"].ToString());
        //ReportParameter pImageUrl1 = new ReportParameter("pImageUrl1", dss.Tables[0].Rows[i]["amb_pic_path"].ToString());
        //this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { pName1, pImageUrl1 });
        // }
        //}



        //ReportDataSource rds2 = new ReportDataSource("DataSet1", dss.Tables[0]);
        //ReportViewer1.LocalReport.DataSources.Clear();
        ////Add ReportDataSource
        //ReportViewer1.LocalReport.DataSources.Add(rds2);

        // this.ReportViewer1.RefreshReport();
        //for (int i = 0; i < dss.Tables[0].Rows.Count; i++)
        //{

        //}
        //ReportDataSource rds2 = new ReportDataSource("DataSet1", dss.Tables[0]);
        //ReportViewer1.LocalReport.DataSources.Clear();
        ////Add ReportDataSource
        //ReportViewer1.LocalReport.DataSources.Add(rds2);

        //this.ReportViewer1.LocalReport.EnableExternalImages = true;
        //HttpContext.Current.Response.Buffer = true;/* TODO ERROR: Skipped SkippedTokensTrivia */
        //HttpContext.Current.Response.Clear();
        //HttpContext.Current.Response.ContentType = "application/pdf";
        //HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=Report.pdf");
        //HttpContext.Current.Response.BinaryWrite(ReportViewer1.LocalReport.Render("pdf"));
        //HttpContext.Current.Response.Flush();
        //HttpContext.Current.Response.End();

        //}

        // }
        public void Load_Report()
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //set path of the Local report
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
            //creating object of DataSet dsEmployee and filling the DataSet using SQLDataAdapter
            //if (Convert.ToInt32(cmbYear.Text) > 0)
            //{
                DataSet ds = objService.Select_AmbienceReport(Convert.ToInt32(cmbMonth.Text), Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmb_branch.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Providing DataSource for the Report
                    ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
                    ReportViewer1.LocalReport.DataSources.Clear();
                    //Add ReportDataSource
                    ReportViewer1.LocalReport.DataSources.Add(rds);
                }
                else
                {
                    ReportViewer1.LocalReport.DataSources.Clear();
                }
                //DataSet dss = objService.AmbiencePic_Select(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.Text), Convert.ToInt32(cmb_branch.SelectedValue));
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    // Providing DataSource for the Report
                //    ReportDataSource rds2 = new ReportDataSource("DataSet2", ds.Tables[0]);
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    //Add ReportDataSource
                //    ReportViewer1.LocalReport.DataSources.Add(rds2);
                //}
                //else
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //}
           // }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            //Load_Report();
            Load_Report1();
        }
        public void Load_Report1()
        {
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
            ////ReportViewer1.LocalReport.EnableExternalImages = true;
            ////string imagePath = new Uri(Server.MapPath(""++"")).AbsoluteUri;
            ////ReportParameter parameter = new ReportParameter("ImagePath", imagePath);
            ////ReportViewer1.LocalReport.SetParameters(parameter);
            //DataSet dsPath = objService.AmbiencePic_Select(2022, 9, 0);
            //if (dsPath.Tables[0].Rows.Count > 0)
            //{
            //    // Providing DataSource for the Report
            //    ReportDataSource rds = new ReportDataSource("DataSet1", dsPath.Tables[0]);
            //    ReportViewer1.LocalReport.DataSources.Clear();
            //    //Add ReportDataSource
            //    ReportViewer1.LocalReport.DataSources.Add(rds);
            //}
            //ReportViewer1.LocalReport.Refresh();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
            DataSet dsPath = objService.AmbiencePic_Select(2022, 9, 0);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsPath.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}