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
    public partial class Inventory_View : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Branch();
                int Branch_id = Convert.ToInt32(cmbBranch.SelectedValue);
                if (Branch_id == 1256 || Branch_id == 3250 || Branch_id == 3153)
                    Load_Department(Branch_id);
                else
                {
                    cmbdept.Visible = false;
                    lblDept.Visible = false;
                }
                Load_Month();
                Load_Year();
                if (GridAmbCondtn.Rows.Count > 0)
                    Btn_Submit.Visible = true;
                else Btn_Submit.Visible = false;
            }
        }
        public void Load_Branch()
        {
            DataTable dtBranch = objService.Select_Branch().Tables[0];
            cmbBranch.DataSource = dtBranch;
            cmbBranch.DataBind();
        }
        public void Load_Department(int branch_id)
        {
            //DataTable dt = (DataTable)Session["Login_Table"];
            DataTable dtDept = objService.Select_Department(branch_id).Tables[0];
            if (dtDept.Rows.Count > 0)
            {
                cmbdept.DataSource = dtDept;
                cmbdept.DataBind();
                cmbdept.SelectedIndex = 0;
                cmbdept.Visible = true;
                lblDept.Visible = true;
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
            DataTable dtYr = new DataTable();
            dtYr.Columns.Add("Year");
            dtYr.Rows.Add(DateTime.Now.AddYears(-1).ToString("yyyy"));
            dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
            dtYr.Rows.Add(DateTime.Now.AddYears(1).ToString("yyyy"));
            cmbYr.DataSource = dtYr;
            cmbYr.DataBind();
        }
        //public void Load_Inventory()
        //{
        //    DataTable dt = (DataTable)Session["Login_Table"];
        //    DataTable dtInv = new DataTable();
        //    if (cmbdept.Visible == false)
        //        dtInv = objService.Select_Inventory(Convert.ToInt32(dt.Rows[0]["Branch_id"].ToString()), -1).Tables[0];
        //    else dtInv = objService.Select_Inventory(Convert.ToInt32(dt.Rows[0]["Branch_id"].ToString()), Convert.ToInt32(cmbdept.SelectedValue)).Tables[0];
        //    if (dtInv.Rows.Count > 0)
        //    {
        //        GridAmbCondtn.DataSource = dtInv;
        //        GridAmbCondtn.DataBind();
        //        Btn_Submit.Visible = true;
        //    }
        //    else
        //    {
        //        Btn_Submit.Visible = false;
        //        GridAmbCondtn.DataSource = null;
        //        GridAmbCondtn.DataBind();
        //    }
        //}
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Login_Table"];int deptid = 0;
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
            if (cmbdept.Visible == true)
                deptid = Convert.ToInt32(cmbdept.SelectedValue);
            DataTable dtInventory = (objService.Select_InventoryStatus(Convert.ToInt32(cmbBranch.SelectedValue), deptid, cmbMnth.SelectedItem.ToString(), Convert.ToInt32(cmbYr.SelectedValue),cmbType.SelectedItem.ToString())).Tables[0];
            if (dtInventory.Rows.Count > 0)
            {
                DataTable copyDataTable;
                copyDataTable = dtInventory.Copy();

                copyDataTable.Columns.Remove("Id"); copyDataTable.Columns.Remove("branch_id"); copyDataTable.Columns.Remove("dept_id");
                copyDataTable.Columns.Remove("department"); copyDataTable.Columns.Remove("month_"); copyDataTable.Columns.Remove("year_");
                copyDataTable.Columns.Remove("date_"); copyDataTable.Columns.Remove("entered_by"); copyDataTable.Columns.Remove("Log_user");
                copyDataTable.Columns.Remove("month_type");

                GridView grid = new GridView();
                grid.DataSource = copyDataTable;
                grid.DataBind();

                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "INVENTORY STATUS ON " + cmbMnth.SelectedItem.ToString() + " " + cmbYr.SelectedItem.ToString();
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
                cell4.Text = "Submitted by: " + dtInventory.Rows[0]["Log_user"].ToString() + " " + dtInventory.Rows[0]["Entered_by"].ToString();
                tr4.Cells.Add(cell4);

                TableRow tr5 = new TableRow();
                TableCell cell5 = new TableCell();
                cell5.Text = "Submitted on: " + dtInventory.Rows[0]["Date_"].ToString();
                tr5.Cells.Add(cell5);

                TableRow tr6 = new TableRow();
                TableCell cell6 = new TableCell();
                if (cmbdept.Visible == true)
                    cell6.Text = cmbBranch.SelectedItem.ToString() + "-" + cmbdept.SelectedItem.ToString();
                else cell6.Text = cmbBranch.SelectedItem.ToString();
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
    

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {

        }

        protected void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Branch_id = Convert.ToInt32(cmbBranch.SelectedValue);
            if (Branch_id == 1256 || Branch_id == 3250 || Branch_id == 3153)
                Load_Department(Branch_id);
            else
            {
                cmbdept.Visible = false;
                lblDept.Visible = false;
            }
        }
    }
}