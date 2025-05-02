using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace Web_OperationModule
{
    public partial class BranchVisit_View : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Branch();
                Load_Month();
                Load_Year();
                Load_staff();
            }
        }
        public void Load_Branch()
        {
            DataTable dtBranch = objService.Select_Branch().Tables[0];
            cmbBranch.DataSource = dtBranch;
            cmbBranch.DataBind();
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
            DataTable dtYr = new DataTable();
            dtYr.Columns.Add("Year");
            dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
            dtYr.Rows.Add(DateTime.Now.AddYears(1).ToString("yyyy"));
            cmbYr.DataSource = dtYr;
            cmbYr.DataBind();
        }
        public void Load_staff()
        {
            DataTable dtuser = new DataTable();
            dtuser = objService.Select_Branchvisit_EnteredStaff(Convert.ToInt32(cmbBranch.SelectedValue), cmbMnth.SelectedItem.ToString(), Convert.ToInt32(cmbYr.SelectedValue)).Tables[0];
            cmbStaff.DataSource = dtuser;
            cmbStaff.DataBind();
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dtSymCash = new DataTable();
            dtSymCash.Columns.Add("Physical cash"); dtSymCash.Columns.Add("System cash"); dtSymCash.Columns.Add("Difference");
            DataTable dtRegCash = new DataTable();
            dtRegCash.Columns.Add("Physical cash"); dtRegCash.Columns.Add("Registerwise"); dtRegCash.Columns.Add("Difference");

            DataTable dtBranchCash = objService.Select_Branchvisit_Cashposition(Convert.ToInt32(cmbBranch.SelectedValue), cmbMnth.SelectedItem.ToString(), Convert.ToInt32(cmbYr.SelectedValue),cmbStaff.SelectedValue.ToString()).Tables[0];
            for (int i = 0; i < dtBranchCash.Rows.Count; i++)
            {
                if (dtBranchCash.Rows[i]["physicalcash1"].ToString() == "" && dtBranchCash.Rows[i]["systemcash1"].ToString() == "" && dtBranchCash.Rows[i]["diff1"].ToString() == "")
                    dtRegCash.Rows.Add(dtBranchCash.Rows[i]["physicalcash2"].ToString(), dtBranchCash.Rows[i]["systemcash2"].ToString(), dtBranchCash.Rows[i]["diff2"].ToString());
                else dtSymCash.Rows.Add(dtBranchCash.Rows[i]["physicalcash1"].ToString(), dtBranchCash.Rows[i]["systemcash1"].ToString(), dtBranchCash.Rows[i]["diff1"].ToString());
            }

            DataTable dtBranchReg = objService.Select_Branchvisit_Registers(Convert.ToInt32(cmbBranch.SelectedValue), cmbMnth.SelectedItem.ToString(), Convert.ToInt32(cmbYr.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];
            DataTable dtBranchReg_copy = dtBranchReg.Copy();
            dtBranchReg_copy.Columns.Remove("Id"); dtBranchReg_copy.Columns.Remove("Branch_Id"); dtBranchReg_copy.Columns.Remove("Month_"); dtBranchReg_copy.Columns.Remove("Log_user");
            dtBranchReg_copy.Columns.Remove("Year_"); dtBranchReg_copy.Columns.Remove("Date_"); dtBranchReg_copy.Columns.Remove("Entered_by");

            DataTable dtAsset = objService.Select_Branchvisit_Asset(Convert.ToInt32(cmbBranch.SelectedValue), cmbMnth.SelectedItem.ToString(), Convert.ToInt32(cmbYr.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];
            DataTable dtAsset_copy = dtAsset.Copy();
            dtAsset_copy.Columns.Remove("Id"); dtAsset_copy.Columns.Remove("Branch_Id"); dtAsset_copy.Columns.Remove("Month_"); dtAsset_copy.Columns.Remove("Log_user");
            dtAsset_copy.Columns.Remove("Year_"); dtAsset_copy.Columns.Remove("Date_"); dtAsset_copy.Columns.Remove("Entered_by");


            //Label1.Visible = true;
            //Label2.Visible = true;
            //Label3.Visible = true;
            //Btn_Submit2.Visible = true;

            if (dtBranchCash.Rows.Count > 0)
            {
                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "BRANCH VISIT REPORT" + cmbMnth.SelectedItem.ToString() + " " + cmbYr.SelectedItem.ToString();
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
                cell4.Text = "Submitted by: " + dtBranchCash.Rows[0]["Log_user"].ToString() + " " + dtBranchCash.Rows[0]["Entered_by"].ToString();
                tr4.Cells.Add(cell4);

                TableRow tr5 = new TableRow();
                TableCell cell5 = new TableCell();
                cell5.Text = "Submitted on: " + dtBranchCash.Rows[0]["Date_"].ToString();
                tr5.Cells.Add(cell5);

                TableRow tr6 = new TableRow();
                TableCell cell6 = new TableCell();
                cell6.Text = cmbBranch.SelectedItem.ToString();
                tr6.Cells.Add(cell6);

                TableRow tr7 = new TableRow();
                TableCell cell7 = new TableCell();
                cell7.Text = " ";
                tr7.Cells.Add(cell7);

                TableRow tr8 = new TableRow();
                TableCell cell8 = new TableCell();
                cell8.Text = "CASH POSITION STATUS";
                tr8.Cells.Add(cell8);

                GridView grid1 = new GridView();
                grid1.DataSource = dtSymCash;
                grid1.DataBind();
                TableRow tr9 = new TableRow();
                TableCell cell9 = new TableCell();
                cell9.Controls.Add(grid1);
                tr9.Cells.Add(cell9);

                TableRow tr10 = new TableRow();
                TableCell cell10 = new TableCell();
                cell10.Text = " ";
                tr10.Cells.Add(cell10);

                GridView grid2 = new GridView();
                grid2.DataSource = dtRegCash;
                grid2.DataBind();
                TableRow tr11 = new TableRow();
                TableCell cell11 = new TableCell();
                cell11.Controls.Add(grid2);
                tr11.Cells.Add(cell11);

                TableRow tr12 = new TableRow();
                TableCell cell12 = new TableCell();
                cell12.Text = " ";
                tr12.Cells.Add(cell12);

                TableRow tr13 = new TableRow();
                TableCell cell13 = new TableCell();
                cell13.Text = "REGISTERS";
                tr13.Cells.Add(cell13);

                GridView grid3 = new GridView();
                grid3.DataSource = dtBranchReg_copy;
                grid3.DataBind();
                TableRow tr14 = new TableRow();
                TableCell cell14 = new TableCell();
                cell14.Controls.Add(grid3);
                tr14.Cells.Add(cell14);

                TableRow tr15 = new TableRow();
                TableCell cell15 = new TableCell();
                cell15.Text = " ";
                tr15.Cells.Add(cell15);

                TableRow tr16 = new TableRow();
                TableCell cell16 = new TableCell();
                cell16.Text = "ASSET VERIFICATION";
                tr16.Cells.Add(cell16);

                GridView grid4 = new GridView();
                grid4.DataSource = dtAsset_copy;
                grid4.DataBind();
                TableRow tr17 = new TableRow();
                TableCell cell17 = new TableCell();
                cell17.Controls.Add(grid4);
                tr17.Cells.Add(cell17);

                tb.Rows.Add(tr1);
                tb.Rows.Add(tr2);
                tb.Rows.Add(tr3);
                tb.Rows.Add(tr4);
                tb.Rows.Add(tr5);
                tb.Rows.Add(tr6);
                tb.Rows.Add(tr7);
                tb.Rows.Add(tr8);
                tb.Rows.Add(tr9);
                tb.Rows.Add(tr10);
                tb.Rows.Add(tr11);
                tb.Rows.Add(tr12);
                tb.Rows.Add(tr13);
                tb.Rows.Add(tr14);
                tb.Rows.Add(tr15);
                tb.Rows.Add(tr16);
                tb.Rows.Add(tr17);
                Response.ContentType = "application/x-msexcel";
                Response.AddHeader("Content-Disposition", "attachment;filename = ExcelFile.xls");
                Response.ContentEncoding = Encoding.UTF8;
                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                tb.RenderControl(hw);
                Response.Write(tw.ToString());
                Response.End();

                //Response.Output.Write(sw.ToString());
                //Response.Flush();

            }
        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_staff();
        }
    }
}