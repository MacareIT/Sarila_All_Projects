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
    public partial class Optical_StockView : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_Branch();
                Button1.Visible = false;
                //Load_Month(); Load_Year();
            }
        }
        public void Load_Branch()
        {
            DataTable dtBranch = objService.Select_unit().Tables[0];
            cmbBranch.DataSource = dtBranch;
            cmbBranch.DataBind();
        }
        //public void Load_Month()
        //{
        //    DataTable dtMonth = new DataTable();
        //    dtMonth.Columns.Add("MonthNo");
        //    dtMonth.Columns.Add("MonthName");
        //    dtMonth.Rows.Add("1", "January"); dtMonth.Rows.Add("2", "February"); dtMonth.Rows.Add("3", "March");
        //    dtMonth.Rows.Add("4", "April"); dtMonth.Rows.Add("5", "May"); dtMonth.Rows.Add("6", "June");
        //    dtMonth.Rows.Add("7", "July"); dtMonth.Rows.Add("8", "August"); dtMonth.Rows.Add("9", "September");
        //    dtMonth.Rows.Add("10", "October"); dtMonth.Rows.Add("11", "November"); dtMonth.Rows.Add("12", "December");
        //    cmbMnth.DataSource = dtMonth;
        //    cmbMnth.DataBind();
        //}
        //public void Load_Year()
        //{

        //    DataTable dtYr = new DataTable();
        //    dtYr.Columns.Add("Year");
        //    dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
        //    dtYr.Rows.Add(DateTime.Now.AddYears(-1).ToString("yyyy"));
        //    cmbYr.DataSource = dtYr;
        //    cmbYr.DataBind();

        //}
        public void load_Data()
        {
            if (string.IsNullOrEmpty(txtFromDate.Text) || string.IsNullOrEmpty(txtToDate.Text))
            {
            }
            else
            {
                DataTable dtAmbience = objService.Select_OpticalStockEntry(Convert.ToInt32(cmbBranch.SelectedValue),txtFromDate.Text,txtToDate.Text).Tables[0];
                if (dtAmbience.Rows.Count > 0)
                {
                    Grid_Ambience.DataSource = dtAmbience;
                    Grid_Ambience.DataBind();
                    Button1.Visible = true;
                }
                else
                {
                    Grid_Ambience.DataSource = null;
                    Grid_Ambience.DataBind();
                    Button1.Visible = false;
                }
    
            }
        }
        public void Load_file()
        {
            //DataTable dt = (DataTable)Session["Login_Table"];
            //DataTable dtSymCash = new DataTable();
            //dtSymCash.Columns.Add("Physical cash"); dtSymCash.Columns.Add("System cash"); dtSymCash.Columns.Add("Difference"); dtSymCash.Columns.Add("Remarks");
            //DataTable dtRegCash = new DataTable();
            //dtRegCash.Columns.Add("Physical cash"); dtRegCash.Columns.Add("Registerwise"); dtRegCash.Columns.Add("Difference"); dtRegCash.Columns.Add("Remarks");
            //if (cmbStaff.SelectedIndex == -1)
            //{

            //}
            //else
            //{
            //    DataTable dtChargeCash = objService.Select_ChargeRpt_Cash(Convert.ToInt32(cmbBranch.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];

            //    if (dtChargeCash.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dtChargeCash.Rows.Count; i++)
            //        {
            //            if (dtChargeCash.Rows[i]["physical1"].ToString() == "" && dtChargeCash.Rows[i]["system1"].ToString() == "" && dtChargeCash.Rows[i]["diff1"].ToString() == "")
            //                dtRegCash.Rows.Add(dtChargeCash.Rows[i]["physical2"].ToString(), dtChargeCash.Rows[i]["system2"].ToString(), dtChargeCash.Rows[i]["diff2"].ToString(), dtChargeCash.Rows[i]["remarks2"].ToString());
            //            else dtSymCash.Rows.Add(dtChargeCash.Rows[i]["physical1"].ToString(), dtChargeCash.Rows[i]["system1"].ToString(), dtChargeCash.Rows[i]["diff1"].ToString(), dtChargeCash.Rows[i]["remarks1"].ToString());
            //        }

                    //DataTable dtChargeKey = objService.Select_ChargeRpt_Key(Convert.ToInt32(cmbBranch.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];
                    //DataTable dtChargeKey_copy = dtChargeKey.Copy();
                    //dtChargeKey_copy.Columns.Remove("Id"); dtChargeKey_copy.Columns.Remove("Branch_Id"); dtChargeKey_copy.Columns.Remove("Log_user");
                    //dtChargeKey_copy.Columns.Remove("Date_"); dtChargeKey_copy.Columns.Remove("Entered_by");


                    //DataTable dtChargeReg = objService.Select_ChargeRpt_Registers(Convert.ToInt32(cmbBranch.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];
                    //DataTable dtChargeReg_copy = dtChargeReg.Copy();
                    //dtChargeReg_copy.Columns.Remove("Id"); dtChargeReg_copy.Columns.Remove("Branch_Id"); dtChargeReg_copy.Columns.Remove("Log_user");
                    //dtChargeReg_copy.Columns.Remove("Date_"); dtChargeReg_copy.Columns.Remove("Entered_by");

                    //DataTable dtMisAsst = new DataTable();
                    //dtMisAsst.Columns.Add("Asset_id"); dtMisAsst.Columns.Add("Item"); dtMisAsst.Columns.Add("Make"); dtMisAsst.Columns.Add("Model");
                    //DataTable dtDamAsst = new DataTable();
                    //dtDamAsst.Columns.Add("Asset_id"); dtDamAsst.Columns.Add("Item"); dtDamAsst.Columns.Add("Make"); dtDamAsst.Columns.Add("Model");
                    //DataTable dtExcAsst = new DataTable();
                    //dtExcAsst.Columns.Add("Asset_id"); dtExcAsst.Columns.Add("Item"); dtExcAsst.Columns.Add("Make"); dtExcAsst.Columns.Add("Model");
                    //DataTable dtBank = new DataTable();
                    //dtBank.Columns.Add("Asset_id"); dtBank.Columns.Add("Item"); dtBank.Columns.Add("Make");

                    //DataTable dtChargeAsset = objService.Select_ChargeRpt_Asset(Convert.ToInt32(cmbBranch.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];
                    //for (int i = 0; i < dtChargeAsset.Rows.Count; i++)
                    //{
                    //    if (dtChargeAsset.Rows[i]["Asset_type"].ToString() == "MISSTING ASSET")
                    //        dtMisAsst.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString(), dtChargeAsset.Rows[i]["Model"].ToString());
                    //    else if (dtChargeAsset.Rows[i]["Asset_type"].ToString() == "DAMAGE ASSET")
                    //        dtDamAsst.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString(), dtChargeAsset.Rows[i]["Model"].ToString());
                    //    else if (dtChargeAsset.Rows[i]["Asset_type"].ToString() == "EXCESS ASSET")
                    //        dtExcAsst.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString(), dtChargeAsset.Rows[i]["Model"].ToString());
                    //    else dtBank.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString());
                    //}

                    //DataTable dtChargeDctr = objService.Select_ChargeRpt_Doctors(Convert.ToInt32(cmbBranch.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];
                    //dtChargeDctr.Columns.Remove("Id"); dtChargeDctr.Columns.Remove("Branch_Id"); dtChargeDctr.Columns.Remove("Log_user");
                    //dtChargeDctr.Columns.Remove("Date_"); dtChargeDctr.Columns.Remove("Entered_by");

                    //DataTable dtChargeVertical = objService.Select_ChargeRpt_Vertical(Convert.ToInt32(cmbBranch.SelectedValue), cmbStaff.SelectedValue.ToString()).Tables[0];
                    //dtChargeVertical.Columns.Remove("Id"); dtChargeVertical.Columns.Remove("Branch_Id"); dtChargeVertical.Columns.Remove("Log_user");
                    //dtChargeVertical.Columns.Remove("Date_"); dtChargeVertical.Columns.Remove("Entered_by");
                    Table tb = new Table();
                    TableRow tr1 = new TableRow();
                    TableCell cell1 = new TableCell();
                    cell1.Text = "OPTICAL STOCK REPORT - "+cmbBranch.SelectedItem.ToString();
                    tr1.Cells.Add(cell1);

                    TableRow tr2 = new TableRow();
                    TableCell cell2 = new TableCell();
                    cell2.Text = " ";
                    tr2.Cells.Add(cell2);

                    TableRow tr3 = new TableRow();
                    TableCell cell3 = new TableCell(); 
                    cell3.Text = " ";
                    tr3.Cells.Add(cell3);

                    //TableRow tr4 = new TableRow();
                    //TableCell cell4 = new TableCell();
                    //cell4.Text = "Submitted by: " + dtChargeCash.Rows[0]["Log_user"].ToString() + " " + dtChargeCash.Rows[0]["entered_by"].ToString();
                    //tr4.Cells.Add(cell4);

                    //TableRow tr5 = new TableRow();
                    //TableCell cell5 = new TableCell();
                    //cell5.Text = "Submitted on: " + dtChargeCash.Rows[0]["Date_"].ToString();
                    //tr5.Cells.Add(cell5);

                    //TableRow tr6 = new TableRow();
                    //TableCell cell6 = new TableCell();
                    //cell6.Text = cmbBranch.SelectedItem.ToString();
                    //tr6.Cells.Add(cell6);

                    //TableRow tr7 = new TableRow();
                    //TableCell cell7 = new TableCell();
                    //cell7.Text = " ";
                    //tr7.Cells.Add(cell7);

                    //TableRow tr8 = new TableRow();
                    //TableCell cell8 = new TableCell();
                    //cell8.Text = "CASH POSITION STATUS";
                    //tr8.Cells.Add(cell8);

                    //GridView grid1 = new GridView();
                    //grid1.DataSource = dtSymCash;
                    //grid1.DataBind();
                    TableRow tr4 = new TableRow();
                    TableCell cell4 = new TableCell();
                    cell4.Controls.Add(Grid_Ambience);
                    tr4.Cells.Add(cell4);

                    //TableRow tr10 = new TableRow();
                    //TableCell cell10 = new TableCell();
                    //cell10.Text = " ";
                    //tr10.Cells.Add(cell10);

                    //GridView grid2 = new GridView();
                    //grid2.DataSource = dtRegCash;
                    //grid2.DataBind();
                    //TableRow tr11 = new TableRow();
                    //TableCell cell11 = new TableCell();
                    //cell11.Controls.Add(grid2);
                    //tr11.Cells.Add(cell11);

                    //TableRow tr12 = new TableRow();
                    //TableCell cell12 = new TableCell();
                    //cell12.Text = " ";
                    //tr12.Cells.Add(cell12);

                    //TableRow tr13 = new TableRow();
                    //TableCell cell13 = new TableCell();
                    //cell13.Text = "KEY STATUS";
                    //tr13.Cells.Add(cell13);

                    //GridView grid3 = new GridView();
                    //grid3.DataSource = dtChargeKey_copy;
                    //grid3.DataBind();
                    //TableRow tr14 = new TableRow();
                    //TableCell cell14 = new TableCell();
                    //cell14.Controls.Add(grid3);
                    //tr14.Cells.Add(cell14);

                    //TableRow tr15 = new TableRow();
                    //TableCell cell15 = new TableCell();
                    //cell15.Text = " ";
                    //tr15.Cells.Add(cell15);

                    //TableRow tr16 = new TableRow();
                    //TableCell cell16 = new TableCell();
                    //cell16.Text = "REGISTERS";
                    //tr16.Cells.Add(cell16);

                    //GridView grid4 = new GridView();
                    //grid4.DataSource = dtChargeReg_copy;
                    //grid4.DataBind();
                    //TableRow tr17 = new TableRow();
                    //TableCell cell17 = new TableCell();
                    //cell17.Controls.Add(grid4);
                    //tr17.Cells.Add(cell17);

                    //TableRow tr18 = new TableRow();
                    //TableCell cell18 = new TableCell();
                    //cell18.Text = " ";
                    //tr18.Cells.Add(cell18);

                    //TableRow tr19 = new TableRow();
                    //TableCell cell19 = new TableCell();
                    //cell19.Text = "ASSET VERIFICATION";
                    //tr19.Cells.Add(cell19);

                    //TableRow tr20 = new TableRow();
                    //TableCell cell20 = new TableCell();
                    //cell20.Text = "MISSING ASSET";
                    //tr20.Cells.Add(cell20);

                    //GridView grid5 = new GridView();
                    //grid5.DataSource = dtMisAsst;
                    //grid5.DataBind();
                    //TableRow tr21 = new TableRow();
                    //TableCell cell21 = new TableCell();
                    //cell21.Controls.Add(grid5);
                    //tr21.Cells.Add(cell21);

                    //TableRow tr22 = new TableRow();
                    //TableCell cell22 = new TableCell();
                    //cell22.Text = " ";
                    //tr22.Cells.Add(cell22);

                    //TableRow tr23 = new TableRow();
                    //TableCell cell23 = new TableCell();
                    //cell23.Text = "DAMAGE ASSET";
                    //tr23.Cells.Add(cell23);

                    //GridView grid6 = new GridView();
                    //grid6.DataSource = dtDamAsst;
                    //grid6.DataBind();
                    //TableRow tr24 = new TableRow();
                    //TableCell cell24 = new TableCell();
                    //cell24.Controls.Add(grid6);
                    //tr24.Cells.Add(cell24);

                    //TableRow tr25 = new TableRow();
                    //TableCell cell25 = new TableCell();
                    //cell25.Text = " ";
                    //tr25.Cells.Add(cell25);

                    //TableRow tr26 = new TableRow();
                    //TableCell cell26 = new TableCell();
                    //cell26.Text = "EXCESS ASSET";
                    //tr26.Cells.Add(cell26);

                    //GridView grid7 = new GridView();
                    //grid7.DataSource = dtExcAsst;
                    //grid7.DataBind();
                    //TableRow tr27 = new TableRow();
                    //TableCell cell27 = new TableCell();
                    //cell27.Controls.Add(grid7);
                    //tr27.Cells.Add(cell27);

                    //TableRow tr28 = new TableRow();
                    //TableCell cell28 = new TableCell();
                    //cell28.Text = " ";
                    //tr28.Cells.Add(cell28);

                    //TableRow tr29 = new TableRow();
                    //TableCell cell29 = new TableCell();
                    //cell29.Text = "BANK RECONCILIATION";
                    //tr29.Cells.Add(cell29);

                    //GridView grid8 = new GridView();
                    //grid8.DataSource = dtBank;
                    //grid8.DataBind();
                    //TableRow tr30 = new TableRow();
                    //TableCell cell30 = new TableCell();
                    //cell30.Controls.Add(grid8);
                    //tr30.Cells.Add(cell30);

                    //TableRow tr31 = new TableRow();
                    //TableCell cell31 = new TableCell();
                    //cell31.Text = " ";
                    //tr31.Cells.Add(cell31);

                    //TableRow tr32 = new TableRow();
                    //TableCell cell32 = new TableCell();
                    //cell32.Text = "DOCTORS AVAILABILITY";
                    //tr32.Cells.Add(cell32);

                    //GridView grid9 = new GridView();
                    //grid9.DataSource = dtChargeDctr;
                    //grid9.DataBind();
                    //TableRow tr33 = new TableRow();
                    //TableCell cell33 = new TableCell();
                    //cell33.Controls.Add(grid9);
                    //tr33.Cells.Add(cell33);

                    //TableRow tr34 = new TableRow();
                    //TableCell cell34 = new TableCell();
                    //cell34.Text = " ";
                    //tr34.Cells.Add(cell34);

                    //TableRow tr35 = new TableRow();
                    //TableCell cell35 = new TableCell();
                    //cell35.Text = "VERTICAL WISE STATUS";
                    //tr35.Cells.Add(cell35);

                    //GridView grid10 = new GridView();
                    //grid10.DataSource = dtChargeVertical;
                    //grid10.DataBind();
                    //TableRow tr36 = new TableRow();
                    //TableCell cell36 = new TableCell();
                    //cell36.Controls.Add(grid10);
                    //tr36.Cells.Add(cell36);

                    //TableRow tr37 = new TableRow();
                    //TableCell cell37 = new TableCell();
                    //cell37.Text = " ";
                    //tr37.Cells.Add(cell37);

                    //TableRow tr38 = new TableRow();
                    //TableCell cell38 = new TableCell();
                    //cell38.Text = "INVENTORY STATUS";
                    //tr38.Cells.Add(cell38);

                    //TableRow tr39 = new TableRow();
                    //TableCell cell39 = new TableCell();
                    //cell39.Controls.Add(gridview11);
                    //tr39.Cells.Add(cell39);

                    //TableRow tr40 = new TableRow();
                    //TableCell cell40 = new TableCell();
                    //cell40.Text = " ";
                    //tr40.Cells.Add(cell40);

                    tb.Rows.Add(tr1);
                    tb.Rows.Add(tr2);
                    tb.Rows.Add(tr3);
                    tb.Rows.Add(tr4);
                    //tb.Rows.Add(tr5);
                    //tb.Rows.Add(tr6);
                    //tb.Rows.Add(tr7);
                    //tb.Rows.Add(tr8);
                    //tb.Rows.Add(tr9);
                    //tb.Rows.Add(tr10);
                    //tb.Rows.Add(tr11);
                    //tb.Rows.Add(tr12);
                    //tb.Rows.Add(tr13);
                    //tb.Rows.Add(tr14);
                    //tb.Rows.Add(tr15);
                    //tb.Rows.Add(tr16);
                    //tb.Rows.Add(tr17);
                    //tb.Rows.Add(tr18);
                    //tb.Rows.Add(tr19);
                    //tb.Rows.Add(tr20);
                    //tb.Rows.Add(tr21);
                    //tb.Rows.Add(tr22);
                    //tb.Rows.Add(tr23);
                    //tb.Rows.Add(tr24);
                    //tb.Rows.Add(tr25);
                    //tb.Rows.Add(tr26);
                    //tb.Rows.Add(tr27);
                    //tb.Rows.Add(tr28);
                    //tb.Rows.Add(tr29);
                    //tb.Rows.Add(tr30);
                    //tb.Rows.Add(tr31);
                    //tb.Rows.Add(tr32);
                    //tb.Rows.Add(tr33);
                    //tb.Rows.Add(tr34);
                    //tb.Rows.Add(tr35);
                    //tb.Rows.Add(tr36);
                    //tb.Rows.Add(tr37);
                    //tb.Rows.Add(tr38);
                    //tb.Rows.Add(tr39);
                    //tb.Rows.Add(tr40);

                    //tb.RenderControl(hw);
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
            //    }

            //}

        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            load_Data();
        }
        protected void BtnReport_Click(object sender, EventArgs e)
        {
            Load_file();
        }
    }
}