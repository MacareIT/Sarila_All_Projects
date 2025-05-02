using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace Web_OperationModule
{
    public partial class FAssetCondition_View : System.Web.UI.Page
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
                cmbYear.SelectedValue = DateTime.Now.Year.ToString();
            }
            else
            {
                DataTable dtYr = new DataTable();
                dtYr.Columns.Add("Year");
                dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
                cmbYear.DataSource = dtYr;
                cmbYear.DataBind();
                cmbYear.SelectedValue = DateTime.Now.Year.ToString();
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            //Load_Report();
            DataTable dt = (DataTable)Session["Login_Table"]; 

            DataTable dsFAsset = objService.Select_FixedAssetEntry(Convert.ToInt32(cmb_branch.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmbYear.SelectedValue)).Tables[0];
            if (dsFAsset.Rows.Count > 0)
            {
                DataTable copyDataTable;
                copyDataTable = dsFAsset.Copy();

                copyDataTable.Columns.Remove("branchid"); copyDataTable.Columns.Remove("month"); copyDataTable.Columns.Remove("year");
                copyDataTable.Columns.Remove("entered_by"); copyDataTable.Columns.Remove("entered_date");
                copyDataTable.Columns.Remove("log_user"); copyDataTable.Columns.Remove("branch");

                GridView grid = new GridView();
                grid.DataSource = copyDataTable;
                grid.DataBind();

                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "FIXED ASSET STATUS ON " + cmbMonth.SelectedItem.ToString() + " " + cmbYear.SelectedItem.ToString();
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
                cell4.Text = "Submitted by: " + dsFAsset.Rows[0]["Log_user"].ToString() + " " + dsFAsset.Rows[0]["Entered_by"].ToString();
                tr4.Cells.Add(cell4);

                TableRow tr5 = new TableRow();
                TableCell cell5 = new TableCell();
                cell5.Text = "Submitted on: " + dsFAsset.Rows[0]["Entered_date"].ToString();
                tr5.Cells.Add(cell5);

                TableRow tr6 = new TableRow();
                TableCell cell6 = new TableCell();
                cell6.Text = dsFAsset.Rows[0]["branch"].ToString();
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

        }
    }
}