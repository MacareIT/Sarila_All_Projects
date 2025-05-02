using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

namespace Web_OperationModule
{
    public partial class FAssetCondition_Add : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_Month();
                Load_Year();
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
            cmbMnth.DataSource = dtMonth;
            cmbMnth.DataBind();
            cmbMnth.SelectedValue = DateTime.Now.Month.ToString();
        }
        public void Load_Year()
        {
            int status = 0;
            DataTable dtYear = new DataTable();
            dtYear.Columns.Add("Year");
            DataTable dtYear1 = objService.Select_Year().Tables[0];
            if (dtYear1.Rows.Count > 0)
            {
                for (int i = 0; i < dtYear1.Rows.Count; i++)
                {
                    dtYear.Rows.Add(dtYear1.Rows[i]["Year"].ToString());
                    if (dtYear1.Rows[i]["Year"].ToString() == DateTime.Now.ToString("yyyy"))
                        status = 1;
                }
                if (status == 0)
                    dtYear.Rows.Add(DateTime.Now.ToString("yyyy"));

                cmbYr.DataSource = dtYear;
                cmbYr.DataBind();
                cmbYr.SelectedValue = DateTime.Now.Year.ToString();
            }
            else
            {
                DataTable dtYr = new DataTable();
                dtYr.Columns.Add("Year");
                dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
                cmbYr.DataSource = dtYr;
                cmbYr.DataBind();
                cmbYr.SelectedValue = DateTime.Now.Year.ToString();
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Login_Table"];
            DataTable dsFAsset = objService.Select_FixedAssetEntry(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue)).Tables[0];
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
                cell1.Text = "FIXED ASSET STATUS ON " + cmbMnth.SelectedItem.ToString() + " " + cmbYr.SelectedItem.ToString();
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
            //else
            //    Load_FA();
        }
        public void Load_FA()
        {
            DataTable dt = (DataTable)Session["Login_Table"];
            try
            {
                DataSet dsFAsset = objService.Select_FixedAsset_Load(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()));
                if (dsFAsset.Tables[0].Rows.Count > 0)
                {
                    Branchname.Text = dsFAsset.Tables[0].Rows[0]["branch"].ToString();
                    GridAmbCondtn.DataSource = dsFAsset.Tables[0];
                    GridAmbCondtn.DataBind();
                }
            }
            catch (Exception ex)
            {
                DataTable dtFA = new DataTable();
                dtFA.Columns.Add("class_name"); dtFA.Columns.Add("asset_id"); dtFA.Columns.Add("item_name");
                dtFA.Columns.Add("make_name"); dtFA.Columns.Add("model_name"); dtFA.Columns.Add("working");
                dtFA.Columns.Add("notworking"); dtFA.Columns.Add("available");
                dtFA.Rows.Add("aa", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("ff", "gg", "hh", "ii", "jj", "0", "0", "0");
                dtFA.Rows.Add("ab", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("fj", "gg", "hh", "ii", "jj", "0", "0", "0");
                dtFA.Rows.Add("an", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("fg", "gg", "hh", "ii", "jj", "0", "0", "0");
                dtFA.Rows.Add("ac", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("fk", "gg", "hh", "ii", "jj", "0", "0", "0");
                dtFA.Rows.Add("ad", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("fu", "gg", "hh", "ii", "jj", "0", "0", "0");
                dtFA.Rows.Add("ap", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("aw", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("fh", "gg", "hh", "ii", "jj", "0", "0", "0");
                dtFA.Rows.Add("az", "bb", "cc", "dd", "ee", "0", "0", "0");
                dtFA.Rows.Add("fb", "gg", "hh", "ii", "jj", "0", "0", "0");
                dtFA.Rows.Add("fx", "gg", "hh", "ii", "jj", "0", "0", "0");
                GridAmbCondtn.DataSource = dtFA;
                GridAmbCondtn.DataBind();
            }

        }
        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

        }
    }
}