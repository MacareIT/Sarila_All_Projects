using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Text;
using System.IO;

namespace Web_OperationModule
{
    public partial class AmbienceView_Report : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Branch();
                Load_Month(); Load_Year();
                //cmbYear.SelectedValue = DateTime.Now.ToString("yyyy");
                string str = DateTime.Now.ToString("MM");
                cmbMonth.SelectedValue = DateTime.Now.Month.ToString();

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
        //public void Load_Report()
        //{
        //    ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //    //set path of the Local report
        //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rpt_Ambience.rdlc");
        //    //creating object of DataSet dsEmployee and filling the DataSet using SQLDataAdapter
        //    if (Convert.ToInt32(cmbYear.Text) > 0)
        //    {
        //        DataSet ds = objService.Select_AmbienceReport(Convert.ToInt32(cmbMonth.Text), Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmb_branch.SelectedValue));
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            // Providing DataSource for the Report
        //            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
        //            ReportViewer1.LocalReport.DataSources.Clear();
        //            //Add ReportDataSource
        //            ReportViewer1.LocalReport.DataSources.Add(rds);
        //        }
        //        else
        //        {
        //            ReportViewer1.LocalReport.DataSources.Clear();
        //        }
        //        DataSet dss = objService.AmbiencePic_Select(Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmbMonth.Text), Convert.ToInt32(cmb_branch.SelectedValue));
        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            // Providing DataSource for the Report
        //            ReportDataSource rds2 = new ReportDataSource("DataSet2", ds.Tables[0]);
        //            ReportViewer1.LocalReport.DataSources.Clear();
        //            //Add ReportDataSource
        //            ReportViewer1.LocalReport.DataSources.Add(rds2);
        //        }
        //        else
        //        {
        //            ReportViewer1.LocalReport.DataSources.Clear();
        //        }
        //    }
        //}

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            //Load_Report();
            DataTable dt = (DataTable)Session["Login_Table"]; int deptid = 0;
            //string fname = "";
            //if (dt.Rows.Count > 0)
            //{
            //    if (cmbdept.Visible == true)
            //        fname = "Inventory-" + cmbdept.SelectedValue.ToString() + "-" + cmbBranch.SelectedValue.ToString() + "-" + cmbMnth.Text + "-" + cmbYr.Text;
            //    else fname = "Inventory-" + cmbBranch.SelectedValue.ToString() + "-" + cmbMnth.Text + "-" + cmbYr.Text;
            //    if (File.Exists(Server.MapPath("~/Inventory_Rpt/" + fname + ".xls")))
            //    {
            //        Response.Redirect("Inventory_Rpt/" + fname + ".xls");
            //    }
            //    else
            //    {
            //        Response.Write("<script>alert('File Not found!!!');</script>");
            //    }
            //}
            //else
            //{
            //    Response.Write("<script>alert('Session time out!!!');</script>");
            //}

            DataTable dtAmbience = (objService.Select_AmbienceRpt(Convert.ToInt32(cmb_branch.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue))).Tables[0];
            if (dtAmbience.Rows.Count > 0)
            {
                DataTable copyDataTable;
                copyDataTable = dtAmbience.Copy();

                copyDataTable.Columns.Remove("branch_name"); copyDataTable.Columns.Remove("designation");
                copyDataTable.Columns.Remove("Log_user"); copyDataTable.Columns.Remove("AMB_ENTERED"); 

                GridView grid = new GridView();
                grid.DataSource = copyDataTable;
                grid.DataBind();

                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "AMBIENCE CONDITION ON " + cmbMonth.SelectedItem.ToString() + " " + cmbYear.SelectedItem.ToString();
                tr1.Cells.Add(cell1);

                TableRow tr2 = new TableRow();
                TableCell cell2 = new TableCell();
                cell2.Text = " ";
                tr2.Cells.Add(cell2);

                TableRow tr3 = new TableRow();
                TableCell cell3 = new TableCell();
                cell3.Text = " ";
                tr3.Cells.Add(cell3);

                TableRow tr4 = new TableRow();
                TableCell cell4 = new TableCell();
                cell4.Text = "Submitted by: " + dtAmbience.Rows[0]["Log_user"].ToString() + " " + dtAmbience.Rows[0]["AMB_ENTERED"].ToString();
                tr4.Cells.Add(cell4);

                TableRow tr5 = new TableRow();
                TableCell cell5 = new TableCell();
                cell5.Text = "Submitted on: " + dtAmbience.Rows[0]["OPERATION_AMBIENCECONDTN.AMB_DATE"].ToString();
                tr5.Cells.Add(cell5);

                TableRow tr6 = new TableRow();
                TableCell cell6 = new TableCell();
                cell6.Text = cmb_branch.SelectedItem.ToString();
                tr6.Cells.Add(cell6);

                TableRow tr7 = new TableRow();
                TableCell cell7 = new TableCell();
                cell7.Text = " ";
                tr7.Cells.Add(cell7);

                TableRow tr8 = new TableRow();
                TableCell cell8 = new TableCell();
                cell8.Controls.Add(grid);
                tr8.Cells.Add(cell8);

                tb.Rows.Add(tr1);
                tb.Rows.Add(tr2);
                tb.Rows.Add(tr3);
                tb.Rows.Add(tr4);
                tb.Rows.Add(tr5);
                tb.Rows.Add(tr6);
                tb.Rows.Add(tr7);
                tb.Rows.Add(tr8);

                //HttpContext.Current.Response.ContentType = "application/vnd.xls";
                //HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=1.xls");
                //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(stringWrite);
                //tb.RenderControl(hw);

                Response.ContentType = "application/x-msexcel";
                Response.AddHeader("Content-Disposition", "attachment;filename = ExcelFile.xls");
                Response.ContentEncoding = Encoding.UTF8;
                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                tb.RenderControl(hw);
                Response.Write(tw.ToString());
                Response.End();
            }
            else
                Response.Write("<script>alert('File not found!!!');</script>");

            //    }
            //}
            //int result = objService.InventoryStatus_InsertUpdate(fname, 0, ((DataTable)Session["Login_Table"]).Rows[0]["Username"].ToString(), "");
            //if (File.Exists(Server.MapPath("~/Inventory_Rpt/" + fname + ".xls")))
            //{
            //    //DataTable dtable = (DataTable)Session["Login_Table"];
            //    int result = objService.OperationStatus_InsertUpdate("Inventoryreport", "~/Inventory_Rpt/" + fname + ".xls", ((DataTable)Session["Login_Table"]).Rows[0]["branch_id"].ToString(), " ", cmbMnth.SelectedValue.ToString(), cmbYr.SelectedValue.ToString());
            //    if (result == 1)
            //    {
            //    }
            //    Response.Redirect("Inventory_Rpt/" + fname + ".xls");
            //}
        }

        //public void SavePDF(ReportViewer viewer, string savePath)

        //{
        //    byte[] Bytes = viewer.LocalReport.Render(format: "PDF", deviceInfo: "");

        //    using (FileStream stream = new FileStream(savePath, FileMode.Create))
        //    {
        //        stream.Write(Bytes, 0, Bytes.Length);
        //    }
        //}
    }
}