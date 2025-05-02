using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_OperationModule
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetInitialRow();
                SetInitialRow1();
                SetInitialRow2();
                SetInitialRow3();
                SetInitialRow4();
                DataTable dt = (DataTable)Session["Login_Table"];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["type"].ToString() == "unithead")
                    {
                        Load_Grid();
                    }
                    else
                    {
                        Response.Write("<script>alert('Permission Denied')</script>");
                        Response.Write("<script>window.location.href='AmbienceCondtnReg.aspx';</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Session Expired')</script>");
                }
            }
        }

        public void Load_Grid()
        {
            DataTable dtCash = new DataTable();
            dtCash.Columns.Add("Name");
            dtCash.Columns.Add("Status");
            dtCash.Columns.Add("Diff");
            dtCash.Columns.Add("Remarks");
            dtCash.Rows.Add("", "", "", "");
            GridCashPosition1.DataSource = dtCash;
            GridCashPosition1.DataBind();

            GridCashPosition2.DataSource = dtCash;
            GridCashPosition2.DataBind();

            dtCash.Rows.Clear();
            dtCash.Rows.Add("Shutter Key", "", "", "");
            dtCash.Rows.Add("Glass Door Key", "", "", "");
            dtCash.Rows.Add("Almira Key", "", "", "");
            dtCash.Rows.Add("Cupboard", "", "", "");
            dtCash.Rows.Add("OP Key", "", "", "");

            GridKeyStatus.DataSource = dtCash;
            GridKeyStatus.DataBind();
            dtCash.Rows.Clear();

            dtCash.Rows.Add("Movement Register", "", "", "");
            dtCash.Rows.Add("Attendance Register", "", "", "");
            dtCash.Rows.Add("Procedure Register", "", "", "");
            dtCash.Rows.Add("Fixed Asset Register", "", "", "");
            dtCash.Rows.Add("Petty Cash Register", "", "", "");
            dtCash.Rows.Add("Cash Book/Cash Stock Register", "", "", "");
            dtCash.Rows.Add("Cash in Transit Register", "", "", "");
            dtCash.Rows.Add("Faculty Register", "", "", "");
            dtCash.Rows.Add("Fees Collection Register", "", "", "");
            dtCash.Rows.Add("Patient Register", "", "", "");
            dtCash.Rows.Add("Outlab Register", "", "", "");
            dtCash.Rows.Add("Inventory Register", "", "", "");
            dtCash.Rows.Add("Call Register", "", "", "");
            dtCash.Rows.Add("Bills System and Manual Verification", "", "", "");
            dtCash.Rows.Add("Marketing Files", "", "", "");
            dtCash.Rows.Add("Equipment items", "", "", "");

            GridRegisters.DataSource = dtCash;
            GridRegisters.DataBind();
            dtCash.Rows.Clear();

            dtCash.Rows.Add("XRAY", "", "", "");
            dtCash.Rows.Add("ULTRASOUND", "", "", "");
            dtCash.Rows.Add("ECHO", "", "", "");
            dtCash.Rows.Add("TMT", "", "", "");
            dtCash.Rows.Add("ENDOSCOPY", "", "", "");
            dtCash.Rows.Add("ECG", "", "", "");
            dtCash.Rows.Add("DENTAL", "", "", "");
            dtCash.Rows.Add("CT", "", "", "");
            dtCash.Rows.Add("PHARMACY", "", "", "");
            dtCash.Rows.Add("LAB", "", "", "");

            GridVertical.DataSource = dtCash;
            GridVertical.DataBind();

        }
        #region Submit_Click
        public void Load_file1()
        {
            DataTable dt1 = new DataTable(); DataTable dt7 = new DataTable();
            DataTable dt2 = new DataTable(); DataTable dt8 = new DataTable();
            DataTable dt3 = new DataTable(); DataTable dt9 = new DataTable();
            DataTable dt4 = new DataTable(); DataTable dt10 = new DataTable();
            DataTable dt5 = new DataTable(); DataTable dt11 = new DataTable();
            DataTable dt6 = new DataTable(); DataTable dt12 = new DataTable();

            if (GridCashPosition1.HeaderRow != null)
            {

                for (int k = 0; k < GridCashPosition1.HeaderRow.Cells.Count; k++)
                {
                    dt1.Columns.Add(GridCashPosition1.HeaderRow.Cells[k].Text);
                }
            }
            //dthead1.Rows.Add("CASH POSITION STATUS");
            //  add each of the data rows to the table
            //GridViewRow row in GridCashPosition1.Rows
            for (int i = 0; i < GridCashPosition1.Rows.Count; i++)
            {
                DataRow dr;
                GridViewRow row = GridCashPosition1.Rows[i];
                dr = dt1.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //dr[j] = row.Cells[j].Text;
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                // }
                dt1.Rows.Add(dr);
            }
            GridView gridview11 = new GridView();
            gridview11.DataSource = dt1;
            gridview11.DataBind();

            if (GridCashPosition2.HeaderRow != null)
            {

                for (int k = 0; k < GridCashPosition2.HeaderRow.Cells.Count; k++)
                {
                    dt2.Columns.Add(GridCashPosition2.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridCashPosition2.Rows)
            {
                DataRow dr;
                dr = dt2.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                dt2.Rows.Add(dr);
            }
            GridView gridview12 = new GridView();
            gridview12.DataSource = dt2;
            gridview12.DataBind();
            if (GridKeyStatus.HeaderRow != null)
            {

                for (int k = 0; k < GridKeyStatus.HeaderRow.Cells.Count; k++)
                {
                    dt3.Columns.Add(GridKeyStatus.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridKeyStatus.Rows)
            {
                DataRow dr;
                dr = dt3.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Name");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Count");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Mis");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                dt3.Rows.Add(dr);
            }
            GridView gridview13 = new GridView();
            gridview13.DataSource = dt3;
            gridview13.DataBind();

            if (GridRegisters.HeaderRow != null)
            {
                for (int k = 0; k < GridRegisters.HeaderRow.Cells.Count; k++)
                {
                    dt4.Columns.Add(GridRegisters.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridRegisters.Rows)
            {
                DataRow dr;
                dr = dt4.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Upd");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Status");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dt4.Rows.Add(dr);
            }
            GridView gridview14 = new GridView();
            gridview14.DataSource = dt4;
            gridview14.DataBind();

            if (GridMisAsset.HeaderRow != null)
            {
                for (int k = 1; k < GridMisAsset.HeaderRow.Cells.Count - 1; k++)
                {
                    dt5.Columns.Add(GridMisAsset.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridMisAsset.Rows)
            {
                DataRow dr;
                dr = dt5.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_item");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_make");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_model");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                dt5.Rows.Add(dr);
            }
            GridView gridview15 = new GridView();
            gridview15.DataSource = dt5;
            gridview15.DataBind();

            if (GridDamageAset.HeaderRow != null)
            {
                for (int k = 1; k < GridDamageAset.HeaderRow.Cells.Count - 1; k++)
                {
                    dt6.Columns.Add(GridDamageAset.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridDamageAset.Rows)
            {
                DataRow dr;
                dr = dt6.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_item");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_make");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_model");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                dt6.Rows.Add(dr);
            }
            GridView gridview16 = new GridView();
            gridview16.DataSource = dt6;
            gridview16.DataBind();

            if (GridExcessAst.HeaderRow != null)
            {
                for (int k = 1; k < GridExcessAst.HeaderRow.Cells.Count - 1; k++)
                {
                    dt7.Columns.Add(GridExcessAst.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridExcessAst.Rows)
            {
                DataRow dr;
                dr = dt7.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_item");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_make");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_model");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                dt7.Rows.Add(dr);
            }
            GridView gridview17 = new GridView();
            gridview17.DataSource = dt7;
            gridview17.DataBind();
            if (GridBank.HeaderRow != null)
            {
                for (int k = 1; k < GridBank.HeaderRow.Cells.Count - 1; k++)
                {
                    dt8.Columns.Add(GridBank.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridBank.Rows)
            {
                DataRow dr;
                dr = dt8.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Name");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_item");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_make");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dt8.Rows.Add(dr);
            }
            GridView gridview18 = new GridView();
            gridview18.DataSource = dt8;
            gridview18.DataBind();

            if (GridDoctors.HeaderRow != null)
            {
                for (int k = 1; k < GridDoctors.HeaderRow.Cells.Count - 1; k++)
                {
                    dt9.Columns.Add(GridDoctors.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridDoctors.Rows)
            {
                DataRow dr;
                dr = dt9.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Name");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_dept");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Spcl");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                dt9.Rows.Add(dr);
            }
            GridView gridview19 = new GridView();
            gridview19.DataSource = dt9;
            gridview19.DataBind();

            if (GridVertical.HeaderRow != null)
            {
                for (int k = 0; k < GridVertical.HeaderRow.Cells.Count; k++)
                {
                    dt10.Columns.Add(GridVertical.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridVertical.Rows)
            {
                DataRow dr;
                dr = dt10.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Service");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_MStatus");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_WrkCondtn");
                var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dr[3] = Remarks.Text;
                dt10.Rows.Add(dr);
            }
            GridView gridview10 = new GridView();
            gridview10.DataSource = dt10;
            gridview10.DataBind();
            //if (GridInventory.HeaderRow != null)
            //{
            //    for (int k = 0; k < GridInventory.HeaderRow.Cells.Count; k++)
            //    {
            //        dt11.Columns.Add(GridInventory.HeaderRow.Cells[k].Text);
            //    }
            //}

            //  add each of the data rows to the table
            //foreach (GridViewRow row in GridInventory.Rows)
            //{
            //    DataRow dr;
            //    dr = dt11.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Inventory");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Short");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Excess");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dt11.Rows.Add(dr);
            //}
            //GridView gridview11 = new GridView();
            //gridview11.DataSource = dt11;
            //gridview11.DataBind();



            DataTable dt = (DataTable)Session["Login_Table"];
            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.Text = "CHARGE REPORT";
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
            cell4.Text = "Submitted by: " + dt.Rows[0]["Log_user"].ToString() + " " + dt.Rows[0]["username"].ToString();
            tr4.Cells.Add(cell4);

            TableRow tr5 = new TableRow();
            TableCell cell5 = new TableCell();
            cell5.Text = "Submitted on: " + DateTime.Now.ToString("dd-MM-yyyy");
            tr5.Cells.Add(cell5);

            TableRow tr6 = new TableRow();
            TableCell cell6 = new TableCell();
            cell6.Text = dt.Rows[0]["branch"].ToString();
            tr6.Cells.Add(cell6);

            TableRow tr7 = new TableRow();
            TableCell cell7 = new TableCell();
            cell7.Text = " ";
            tr7.Cells.Add(cell7);

            TableRow tr8 = new TableRow();
            TableCell cell8 = new TableCell();
            cell8.Text = "CASH POSITION STATUS";
            tr8.Cells.Add(cell8);

            TableRow tr9 = new TableRow();
            TableCell cell9 = new TableCell();
            cell9.Controls.Add(gridview11);
            tr9.Cells.Add(cell9);

            TableRow tr10 = new TableRow();
            TableCell cell10 = new TableCell();
            cell10.Text = " ";
            tr10.Cells.Add(cell10);

            TableRow tr11 = new TableRow();
            TableCell cell11 = new TableCell();
            cell11.Controls.Add(gridview12);
            tr11.Cells.Add(cell11);

            TableRow tr12 = new TableRow();
            TableCell cell12 = new TableCell();
            cell12.Text = " ";
            tr12.Cells.Add(cell12);

            TableRow tr13 = new TableRow();
            TableCell cell13 = new TableCell();
            cell13.Text = "KEY STATUS";
            tr13.Cells.Add(cell13);

            TableRow tr14 = new TableRow();
            TableCell cell14 = new TableCell();
            cell14.Controls.Add(gridview13);
            tr14.Cells.Add(cell14);

            TableRow tr15 = new TableRow();
            TableCell cell15 = new TableCell();
            cell15.Text = " ";
            tr15.Cells.Add(cell15);

            TableRow tr16 = new TableRow();
            TableCell cell16 = new TableCell();
            cell16.Text = "REGISTERS";
            tr16.Cells.Add(cell16);

            TableRow tr17 = new TableRow();
            TableCell cell17 = new TableCell();
            cell17.Controls.Add(gridview14);
            tr17.Cells.Add(cell17);

            TableRow tr18 = new TableRow();
            TableCell cell18 = new TableCell();
            cell18.Text = " ";
            tr18.Cells.Add(cell18);

            TableRow tr19 = new TableRow();
            TableCell cell19 = new TableCell();
            cell19.Text = "ASSET VERIFICATION";
            tr19.Cells.Add(cell19);

            TableRow tr20 = new TableRow();
            TableCell cell20 = new TableCell();
            cell20.Text = "MISSING ASSET";
            tr20.Cells.Add(cell20);

            TableRow tr21 = new TableRow();
            TableCell cell21 = new TableCell();
            cell21.Controls.Add(gridview15);
            tr21.Cells.Add(cell21);

            TableRow tr22 = new TableRow();
            TableCell cell22 = new TableCell();
            cell22.Text = " ";
            tr22.Cells.Add(cell22);

            TableRow tr23 = new TableRow();
            TableCell cell23 = new TableCell();
            cell23.Text = "DAMAGE ASSET";
            tr23.Cells.Add(cell23);

            TableRow tr24 = new TableRow();
            TableCell cell24 = new TableCell();
            cell24.Controls.Add(gridview16);
            tr24.Cells.Add(cell24);

            TableRow tr25 = new TableRow();
            TableCell cell25 = new TableCell();
            cell25.Text = " ";
            tr25.Cells.Add(cell25);

            TableRow tr26 = new TableRow();
            TableCell cell26 = new TableCell();
            cell26.Text = "EXCESS ASSET";
            tr26.Cells.Add(cell26);

            TableRow tr27 = new TableRow();
            TableCell cell27 = new TableCell();
            cell27.Controls.Add(gridview17);
            tr27.Cells.Add(cell27);

            TableRow tr28 = new TableRow();
            TableCell cell28 = new TableCell();
            cell28.Text = " ";
            tr28.Cells.Add(cell28);

            TableRow tr29 = new TableRow();
            TableCell cell29 = new TableCell();
            cell29.Text = "BANK RECONCILIATION";
            tr29.Cells.Add(cell29);

            TableRow tr30 = new TableRow();
            TableCell cell30 = new TableCell();
            cell30.Controls.Add(gridview18);
            tr30.Cells.Add(cell30);

            TableRow tr31 = new TableRow();
            TableCell cell31 = new TableCell();
            cell31.Text = " ";
            tr31.Cells.Add(cell31);

            TableRow tr32 = new TableRow();
            TableCell cell32 = new TableCell();
            cell32.Text = "DOCTORS AVAILABILITY";
            tr32.Cells.Add(cell32);

            TableRow tr33 = new TableRow();
            TableCell cell33 = new TableCell();
            cell33.Controls.Add(gridview19);
            tr33.Cells.Add(cell33);

            TableRow tr34 = new TableRow();
            TableCell cell34 = new TableCell();
            cell34.Text = " ";
            tr34.Cells.Add(cell34);

            TableRow tr35 = new TableRow();
            TableCell cell35 = new TableCell();
            cell35.Text = "VERTICAL WISE STATUS";
            tr35.Cells.Add(cell35);

            TableRow tr36 = new TableRow();
            TableCell cell36 = new TableCell();
            cell36.Controls.Add(gridview10);
            tr36.Cells.Add(cell36);

            TableRow tr37 = new TableRow();
            TableCell cell37 = new TableCell();
            cell37.Text = " ";
            tr37.Cells.Add(cell37);

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
            tb.Rows.Add(tr18);
            tb.Rows.Add(tr19);
            tb.Rows.Add(tr20);
            tb.Rows.Add(tr21);
            tb.Rows.Add(tr22);
            tb.Rows.Add(tr23);
            tb.Rows.Add(tr24);
            tb.Rows.Add(tr25);
            tb.Rows.Add(tr26);
            tb.Rows.Add(tr27);
            tb.Rows.Add(tr28);
            tb.Rows.Add(tr29);
            tb.Rows.Add(tr30);
            tb.Rows.Add(tr31);
            tb.Rows.Add(tr32);
            tb.Rows.Add(tr33);
            tb.Rows.Add(tr34);
            tb.Rows.Add(tr35);
            tb.Rows.Add(tr36);
            tb.Rows.Add(tr37);
            //tb.Rows.Add(tr38);
            //tb.Rows.Add(tr39);
            //tb.Rows.Add(tr40);


            //Response.Output.Write(sw.ToString());
            //Response.Flush();

            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = ExcelFile.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();

        }
        #endregion
        public void Load_file()
        {
            DataTable dt = (DataTable)Session["Login_Table"];
            DataTable dtSymCash = new DataTable();
            dtSymCash.Columns.Add("PHYSICAL CASH"); dtSymCash.Columns.Add("SYSTEM CASH"); dtSymCash.Columns.Add("DIFFERENCE"); dtSymCash.Columns.Add("REMARKS");
            DataTable dtRegCash = new DataTable();
            dtRegCash.Columns.Add("PHYSICAL CASH"); dtRegCash.Columns.Add("REGISTER WISE"); dtRegCash.Columns.Add("DIFFERENCE"); dtRegCash.Columns.Add("REMARKS");

            DataTable dtChargeCash = objService.Select_ChargeRpt_Cash(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString()).Tables[0];


            if (dtChargeCash.Rows.Count > 0)
            {
                for (int i = 0; i < dtChargeCash.Rows.Count; i++)
                {
                    if (dtChargeCash.Rows[i]["physical1"].ToString() == "" && dtChargeCash.Rows[i]["system1"].ToString() == "" && dtChargeCash.Rows[i]["diff1"].ToString() == "")
                        dtRegCash.Rows.Add(dtChargeCash.Rows[i]["physical2"].ToString(), dtChargeCash.Rows[i]["system2"].ToString(), dtChargeCash.Rows[i]["diff2"].ToString(), dtChargeCash.Rows[i]["remarks2"].ToString());
                    else dtSymCash.Rows.Add(dtChargeCash.Rows[i]["physical1"].ToString(), dtChargeCash.Rows[i]["system1"].ToString(), dtChargeCash.Rows[i]["diff1"].ToString(), dtChargeCash.Rows[i]["remarks1"].ToString());
                }

                DataTable dtChargeKey = objService.Select_ChargeRpt_Key(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString()).Tables[0];
                DataTable dtChargeKey_copy = dtChargeKey.Copy();
                dtChargeKey_copy.Columns.Remove("Id"); dtChargeKey_copy.Columns.Remove("Branch_Id"); dtChargeKey_copy.Columns.Remove("Log_user");
                dtChargeKey_copy.Columns.Remove("Date_"); dtChargeKey_copy.Columns.Remove("Entered_by");


                DataTable dtChargeReg = objService.Select_ChargeRpt_Registers(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString()).Tables[0];
                DataTable dtChargeReg_copy = dtChargeReg.Copy();
                dtChargeReg_copy.Columns.Remove("Id"); dtChargeReg_copy.Columns.Remove("Branch_Id"); dtChargeReg_copy.Columns.Remove("Log_user");
                dtChargeReg_copy.Columns.Remove("Date_"); dtChargeReg_copy.Columns.Remove("Entered_by");

                DataTable dtMisAsst = new DataTable();
                dtMisAsst.Columns.Add("Asset_id"); dtMisAsst.Columns.Add("Item"); dtMisAsst.Columns.Add("Make"); dtMisAsst.Columns.Add("Model");
                DataTable dtDamAsst = new DataTable();
                dtDamAsst.Columns.Add("Asset_id"); dtDamAsst.Columns.Add("Item"); dtDamAsst.Columns.Add("Make"); dtDamAsst.Columns.Add("Model");
                DataTable dtExcAsst = new DataTable();
                dtExcAsst.Columns.Add("Asset_id"); dtExcAsst.Columns.Add("Item"); dtExcAsst.Columns.Add("Make"); dtExcAsst.Columns.Add("Model");
                DataTable dtBank = new DataTable();
                dtBank.Columns.Add("Asset_id"); dtBank.Columns.Add("Item"); dtBank.Columns.Add("Make");

                DataTable dtChargeAsset = objService.Select_ChargeRpt_Asset(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString()).Tables[0];
                for (int i = 0; i < dtChargeAsset.Rows.Count; i++)
                {
                    if (dtChargeAsset.Rows[i]["Asset_type"].ToString() == "MISSTING ASSET")
                        dtMisAsst.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString(), dtChargeAsset.Rows[i]["Model"].ToString());
                    else if (dtChargeAsset.Rows[i]["Asset_type"].ToString() == "DAMAGE ASSET")
                        dtDamAsst.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString(), dtChargeAsset.Rows[i]["Model"].ToString());
                    else if (dtChargeAsset.Rows[i]["Asset_type"].ToString() == "EXCESS ASSET")
                        dtExcAsst.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString(), dtChargeAsset.Rows[i]["Model"].ToString());
                    else dtBank.Rows.Add(dtChargeAsset.Rows[i]["Asset_id"].ToString(), dtChargeAsset.Rows[i]["Item"].ToString(), dtChargeAsset.Rows[i]["Make"].ToString());
                }

                DataTable dtChargeDctr = objService.Select_ChargeRpt_Doctors(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString()).Tables[0];
                dtChargeDctr.Columns.Remove("Id"); dtChargeDctr.Columns.Remove("Branch_Id"); dtChargeDctr.Columns.Remove("Log_user");
                dtChargeDctr.Columns.Remove("Date_"); dtChargeDctr.Columns.Remove("Entered_by");

                DataTable dtChargeVertical = objService.Select_ChargeRpt_Vertical(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString()).Tables[0];
                dtChargeVertical.Columns.Remove("Id"); dtChargeVertical.Columns.Remove("Branch_Id"); dtChargeVertical.Columns.Remove("Log_user");
                dtChargeVertical.Columns.Remove("Date_"); dtChargeVertical.Columns.Remove("Entered_by");

                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "CHARGE REPORT";
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
                cell4.Text = "Submitted by: " + dtChargeCash.Rows[0]["Log_user"].ToString() + " " + dtChargeCash.Rows[0]["Entered_by"].ToString();
                tr4.Cells.Add(cell4);

                TableRow tr5 = new TableRow();
                TableCell cell5 = new TableCell();
                cell5.Text = "Submitted on: " + dtChargeCash.Rows[0]["Date_"].ToString();
                tr5.Cells.Add(cell5);

                TableRow tr6 = new TableRow();
                TableCell cell6 = new TableCell();
                cell6.Text = dtChargeCash.Rows[0]["Branch_Id"].ToString();
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
                cell13.Text = "KEY STATUS";
                tr13.Cells.Add(cell13);

                GridView grid3 = new GridView();
                grid3.DataSource = dtChargeKey_copy;
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
                cell16.Text = "REGISTERS";
                tr16.Cells.Add(cell16);

                GridView grid4 = new GridView();
                grid4.DataSource = dtChargeReg_copy;
                grid4.DataBind();
                TableRow tr17 = new TableRow();
                TableCell cell17 = new TableCell();
                cell17.Controls.Add(grid4);
                tr17.Cells.Add(cell17);

                TableRow tr18 = new TableRow();
                TableCell cell18 = new TableCell();
                cell18.Text = " ";
                tr18.Cells.Add(cell18);

                TableRow tr19 = new TableRow();
                TableCell cell19 = new TableCell();
                cell19.Text = "ASSET VERIFICATION";
                tr19.Cells.Add(cell19);

                TableRow tr20 = new TableRow();
                TableCell cell20 = new TableCell();
                cell20.Text = "MISSING ASSET";
                tr20.Cells.Add(cell20);

                GridView grid5 = new GridView();
                grid5.DataSource = dtMisAsst;
                grid5.DataBind();
                TableRow tr21 = new TableRow();
                TableCell cell21 = new TableCell();
                cell21.Controls.Add(grid5);
                tr21.Cells.Add(cell21);

                TableRow tr22 = new TableRow();
                TableCell cell22 = new TableCell();
                cell22.Text = " ";
                tr22.Cells.Add(cell22);

                TableRow tr23 = new TableRow();
                TableCell cell23 = new TableCell();
                cell23.Text = "DAMAGE ASSET";
                tr23.Cells.Add(cell23);

                GridView grid6 = new GridView();
                grid6.DataSource = dtDamAsst;
                grid6.DataBind();
                TableRow tr24 = new TableRow();
                TableCell cell24 = new TableCell();
                cell24.Controls.Add(grid6);
                tr24.Cells.Add(cell24);

                TableRow tr25 = new TableRow();
                TableCell cell25 = new TableCell();
                cell25.Text = " ";
                tr25.Cells.Add(cell25);

                TableRow tr26 = new TableRow();
                TableCell cell26 = new TableCell();
                cell26.Text = "EXCESS ASSET";
                tr26.Cells.Add(cell26);

                GridView grid7 = new GridView();
                grid7.DataSource = dtExcAsst;
                grid7.DataBind();
                TableRow tr27 = new TableRow();
                TableCell cell27 = new TableCell();
                cell27.Controls.Add(grid7);
                tr27.Cells.Add(cell27);

                TableRow tr28 = new TableRow();
                TableCell cell28 = new TableCell();
                cell28.Text = " ";
                tr28.Cells.Add(cell28);

                TableRow tr29 = new TableRow();
                TableCell cell29 = new TableCell();
                cell29.Text = "BANK RECONCILIATION";
                tr29.Cells.Add(cell29);

                GridView grid8 = new GridView();
                grid8.DataSource = dtBank;
                grid8.DataBind();
                TableRow tr30 = new TableRow();
                TableCell cell30 = new TableCell();
                cell30.Controls.Add(grid8);
                tr30.Cells.Add(cell30);

                TableRow tr31 = new TableRow();
                TableCell cell31 = new TableCell();
                cell31.Text = " ";
                tr31.Cells.Add(cell31);

                TableRow tr32 = new TableRow();
                TableCell cell32 = new TableCell();
                cell32.Text = "DOCTORS AVAILABILITY";
                tr32.Cells.Add(cell32);

                GridView grid9 = new GridView();
                grid9.DataSource = dtChargeDctr;
                grid9.DataBind();
                TableRow tr33 = new TableRow();
                TableCell cell33 = new TableCell();
                cell33.Controls.Add(grid9);
                tr33.Cells.Add(cell33);

                TableRow tr34 = new TableRow();
                TableCell cell34 = new TableCell();
                cell34.Text = " ";
                tr34.Cells.Add(cell34);

                TableRow tr35 = new TableRow();
                TableCell cell35 = new TableCell();
                cell35.Text = "VERTICAL WISE STATUS";
                tr35.Cells.Add(cell35);

                GridView grid10 = new GridView();
                grid10.DataSource = dtChargeVertical;
                grid10.DataBind();
                TableRow tr36 = new TableRow();
                TableCell cell36 = new TableCell();
                cell36.Controls.Add(grid10);
                tr36.Cells.Add(cell36);

                TableRow tr37 = new TableRow();
                TableCell cell37 = new TableCell();
                cell37.Text = " ";
                tr37.Cells.Add(cell37);

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
                tb.Rows.Add(tr18);
                tb.Rows.Add(tr19);
                tb.Rows.Add(tr20);
                tb.Rows.Add(tr21);
                tb.Rows.Add(tr22);
                tb.Rows.Add(tr23);
                tb.Rows.Add(tr24);
                tb.Rows.Add(tr25);
                tb.Rows.Add(tr26);
                tb.Rows.Add(tr27);
                tb.Rows.Add(tr28);
                tb.Rows.Add(tr29);
                tb.Rows.Add(tr30);
                tb.Rows.Add(tr31);
                tb.Rows.Add(tr32);
                tb.Rows.Add(tr33);
                tb.Rows.Add(tr34);
                tb.Rows.Add(tr35);
                tb.Rows.Add(tr36);
                tb.Rows.Add(tr37);

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
                Load_Grid();
        }
        protected void txt_SCash_TextChanged(object sender, EventArgs e)
        {
            Double cash1, cash2;
            GridViewRow row = ((GridViewRow)((System.Web.UI.WebControls.TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            System.Web.UI.WebControls.TextBox phstk = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash");
            System.Web.UI.WebControls.TextBox lblStk = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash");

            if (phstk.Text == "" || phstk.Text == null) cash1 = 0; else cash1 = Convert.ToDouble(phstk.Text);
            if (lblStk.Text == "" || lblStk.Text == null) cash2 = 0; else cash2 = Convert.ToDouble(lblStk.Text);
            ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff")).Text = (cash1 - cash2).ToString();
            //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl((System.Web.UI.WebControls.TextBox)row.FindControl("txt_PStk"));
            //ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            //scriptMan.RegisterAsyncPostBackControl(phstk);
            ScriptManager currPageScriptManager = ScriptManager.GetCurrent(Page) as ScriptManager;
            if (currPageScriptManager != null)
            {
                currPageScriptManager.RegisterAsyncPostBackControl(phstk);
            }
        }

        #region Submit_Click
        protected void Btn_Submit1_Click(object sender, EventArgs e)
        {
            //#region
            //DataTable dt1 = new DataTable(); DataTable dt7 = new DataTable();
            //DataTable dt2 = new DataTable(); DataTable dt8 = new DataTable();
            //DataTable dt3 = new DataTable(); DataTable dt9 = new DataTable();
            //DataTable dt4 = new DataTable(); DataTable dt10 = new DataTable();
            //DataTable dt5 = new DataTable(); DataTable dt11 = new DataTable();
            //DataTable dt6 = new DataTable(); DataTable dt12 = new DataTable();

            //if (GridCashPosition1.HeaderRow != null)
            //{

            //    for (int k = 0; k < GridCashPosition1.HeaderRow.Cells.Count; k++)
            //    {
            //        dt1.Columns.Add(GridCashPosition1.HeaderRow.Cells[k].Text);
            //    }
            //}
            ////dthead1.Rows.Add("CASH POSITION STATUS");
            ////  add each of the data rows to the table
            ////GridViewRow row in GridCashPosition1.Rows
            //for (int i = 0; i < GridCashPosition1.Rows.Count; i++)
            //{
            //    DataRow dr;
            //    GridViewRow row = GridCashPosition1.Rows[i];
            //    dr = dt1.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //dr[j] = row.Cells[j].Text;
            //    var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    // }
            //    dt1.Rows.Add(dr);
            //}
            //GridView gridview11 = new GridView();
            //gridview11.DataSource = dt1;
            //gridview11.DataBind();

            //if (GridCashPosition2.HeaderRow != null)
            //{

            //    for (int k = 0; k < GridCashPosition2.HeaderRow.Cells.Count; k++)
            //    {
            //        dt2.Columns.Add(GridCashPosition2.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in GridCashPosition2.Rows)
            //{
            //    DataRow dr;
            //    dr = dt2.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    dt2.Rows.Add(dr);
            //}
            //GridView gridview12 = new GridView();
            //gridview12.DataSource = dt2;
            //gridview12.DataBind();
            //if (GridKeyStatus.HeaderRow != null)
            //{

            //    for (int k = 0; k < GridKeyStatus.HeaderRow.Cells.Count; k++)
            //    {
            //        dt3.Columns.Add(GridKeyStatus.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in GridKeyStatus.Rows)
            //{
            //    DataRow dr;
            //    dr = dt3.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Name");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Count");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Mis");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    dt3.Rows.Add(dr);
            //}
            //GridView gridview13 = new GridView();
            //gridview13.DataSource = dt3;
            //gridview13.DataBind();

            //if (GridRegisters.HeaderRow != null)
            //{
            //    for (int k = 0; k < GridRegisters.HeaderRow.Cells.Count; k++)
            //    {
            //        dt4.Columns.Add(GridRegisters.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in GridRegisters.Rows)
            //{
            //    DataRow dr;
            //    dr = dt4.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Upd");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Status");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dt4.Rows.Add(dr);
            //}
            //GridView gridview14 = new GridView();
            //gridview14.DataSource = dt4;
            //gridview14.DataBind();

            //if (Gridview1.HeaderRow != null)
            //{
            //    for (int k = 1; k < Gridview1.HeaderRow.Cells.Count-1; k++)
            //    {
            //        dt5.Columns.Add(Gridview1.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in Gridview1.Rows)
            //{
            //    DataRow dr;
            //    dr = dt5.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_item");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_make");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_model");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    dt5.Rows.Add(dr);
            //}
            //GridView gridview15 = new GridView();
            //gridview15.DataSource = dt5;
            //gridview15.DataBind();

            //if (Gridview2.HeaderRow != null)
            //{
            //    for (int k = 1; k < Gridview2.HeaderRow.Cells.Count-1; k++)
            //    {
            //        dt6.Columns.Add(Gridview2.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in Gridview2.Rows)
            //{
            //    DataRow dr;
            //    dr = dt6.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_item");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_make");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_model");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    dt6.Rows.Add(dr);
            //}
            //GridView gridview16 = new GridView();
            //gridview16.DataSource = dt6;
            //gridview16.DataBind();

            //if (Gridview3.HeaderRow != null)
            //{
            //    for (int k = 1; k < Gridview3.HeaderRow.Cells.Count-1; k++)
            //    {
            //        dt7.Columns.Add(Gridview3.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in Gridview3.Rows)
            //{
            //    DataRow dr;
            //    dr = dt7.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_item");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_make");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_model");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    dt7.Rows.Add(dr);
            //}
            //GridView gridview17 = new GridView();
            //gridview17.DataSource = dt7;
            //gridview17.DataBind();
            //if (Gridview4.HeaderRow != null)
            //{
            //    for (int k = 1; k < Gridview4.HeaderRow.Cells.Count-1; k++)
            //    {
            //        dt8.Columns.Add(Gridview4.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in Gridview4.Rows)
            //{
            //    DataRow dr;
            //    dr = dt8.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Name");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_ReconDate");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dt8.Rows.Add(dr);
            //}
            //GridView gridview18 = new GridView();
            //gridview18.DataSource = dt8;
            //gridview18.DataBind();

            //if (Gridview5.HeaderRow != null)
            //{
            //    for (int k = 1; k < Gridview5.HeaderRow.Cells.Count-1; k++)
            //    {
            //        dt9.Columns.Add(Gridview5.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in Gridview5.Rows)
            //{
            //    DataRow dr;
            //    dr = dt9.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Name");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_dept");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Spcl");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    dt9.Rows.Add(dr);
            //}
            //GridView gridview19 = new GridView();
            //gridview19.DataSource = dt9;
            //gridview19.DataBind();

            //if (GridVertical.HeaderRow != null)
            //{
            //    for (int k = 0; k < GridVertical.HeaderRow.Cells.Count; k++)
            //    {
            //        dt10.Columns.Add(GridVertical.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in GridVertical.Rows)
            //{
            //    DataRow dr;
            //    dr = dt10.NewRow();
            //    //for (int j = 0; j < row.Cells.Count; j++)
            //    //{
            //    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            //    //}
            //    var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Service");
            //    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_MStatus");
            //    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_WrkCondtn");
            //    var Remarks = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks");
            //    dr[0] = PCash.Text;
            //    dr[1] = SCash.Text;
            //    dr[2] = Diff.Text;
            //    dr[3] = Remarks.Text;
            //    dt10.Rows.Add(dr);
            //}
            //GridView gridview10 = new GridView();
            //gridview10.DataSource = dt10;
            //gridview10.DataBind();
            ////if (GridInventory.HeaderRow != null)
            ////{
            ////    for (int k = 0; k < GridInventory.HeaderRow.Cells.Count; k++)
            ////    {
            ////        dt11.Columns.Add(GridInventory.HeaderRow.Cells[k].Text);
            ////    }
            ////}

            ////  add each of the data rows to the table
            ////foreach (GridViewRow row in GridInventory.Rows)
            ////{
            ////    DataRow dr;
            ////    dr = dt11.NewRow();
            ////    //for (int j = 0; j < row.Cells.Count; j++)
            ////    //{
            ////    //    dr[j] = row.Cells[j].Text.Replace(" ", "");
            ////    //}
            ////    var PCash = (System.Web.UI.WebControls.Label)row.FindControl("lbl_Inventory");
            ////    var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Short");
            ////    var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Excess");
            ////    dr[0] = PCash.Text;
            ////    dr[1] = SCash.Text;
            ////    dr[2] = Diff.Text;
            ////    dt11.Rows.Add(dr);
            ////}
            ////GridView gridview11 = new GridView();
            ////gridview11.DataSource = dt11;
            ////gridview11.DataBind();


            //try
            //{
            //    DataTable dt = (DataTable)Session["Login_Table"]; string fname = ""; string branchname = "";
                
            //    fname = "ChargeReport-" + dt.Rows[0]["Branchid"].ToString();// + "-" + dt.Rows[0]["username"].ToString();
            //    branchname = dt.Rows[0]["branch"].ToString();

            //    using (StreamWriter sw = new StreamWriter(Server.MapPath("~/Charge_Rpt/" + fname + ".xls"), true))
            //    {
            //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            //        {
            //            Table tb = new Table();
            //            TableRow tr1 = new TableRow();
            //            TableCell cell1 = new TableCell();
            //            cell1.Text = "CHARGE REPORT";
            //            tr1.Cells.Add(cell1);

            //            TableRow tr2 = new TableRow();
            //            TableCell cell2 = new TableCell();
            //            cell2.Text = " ";
            //            tr2.Cells.Add(cell2);

            //            TableRow tr3 = new TableRow();
            //            TableCell cell3 = new TableCell();
            //            cell3.Text = " ";
            //            tr3.Cells.Add(cell3);

            //            TableRow tr4 = new TableRow();
            //            TableCell cell4 = new TableCell();
            //            cell4.Text = "Submitted by: " + dt.Rows[0]["Log_user"].ToString() + " " + dt.Rows[0]["username"].ToString();
            //            tr4.Cells.Add(cell4);

            //            TableRow tr5 = new TableRow();
            //            TableCell cell5 = new TableCell();
            //            cell5.Text = "Submitted on: " + DateTime.Now.ToString("dd-MM-yyyy");
            //            tr5.Cells.Add(cell5);

            //            TableRow tr6 = new TableRow();
            //            TableCell cell6 = new TableCell();
            //            cell6.Text = branchname;
            //            tr6.Cells.Add(cell6);

            //            TableRow tr7 = new TableRow();
            //            TableCell cell7 = new TableCell();
            //            cell7.Text = " ";
            //            tr7.Cells.Add(cell7);

            //            TableRow tr8 = new TableRow();
            //            TableCell cell8 = new TableCell();
            //            cell8.Text = "CASH POSITION STATUS";
            //            tr8.Cells.Add(cell8);

            //            TableRow tr9 = new TableRow();
            //            TableCell cell9 = new TableCell();
            //            cell9.Controls.Add(gridview11);
            //            tr9.Cells.Add(cell9);

            //            TableRow tr10 = new TableRow();
            //            TableCell cell10 = new TableCell();
            //            cell10.Text = " ";
            //            tr10.Cells.Add(cell10);

            //            TableRow tr11 = new TableRow();
            //            TableCell cell11 = new TableCell();
            //            cell11.Controls.Add(gridview12);
            //            tr11.Cells.Add(cell11);

            //            TableRow tr12 = new TableRow();
            //            TableCell cell12 = new TableCell();
            //            cell12.Text = " ";
            //            tr12.Cells.Add(cell12);

            //            TableRow tr13 = new TableRow();
            //            TableCell cell13 = new TableCell();
            //            cell13.Text = "KEY STATUS";
            //            tr13.Cells.Add(cell13);

            //            TableRow tr14 = new TableRow();
            //            TableCell cell14 = new TableCell();
            //            cell14.Controls.Add(gridview13);
            //            tr14.Cells.Add(cell14);

            //            TableRow tr15 = new TableRow();
            //            TableCell cell15 = new TableCell();
            //            cell15.Text = " ";
            //            tr15.Cells.Add(cell15);

            //            TableRow tr16 = new TableRow();
            //            TableCell cell16 = new TableCell();
            //            cell16.Text = "REGISTERS";
            //            tr16.Cells.Add(cell16);

            //            TableRow tr17 = new TableRow();
            //            TableCell cell17 = new TableCell();
            //            cell17.Controls.Add(gridview14);
            //            tr17.Cells.Add(cell17);

            //            TableRow tr18 = new TableRow();
            //            TableCell cell18 = new TableCell();
            //            cell18.Text = " ";
            //            tr18.Cells.Add(cell18);

            //            TableRow tr19 = new TableRow();
            //            TableCell cell19 = new TableCell();
            //            cell19.Text = "ASSET VERIFICATION";
            //            tr19.Cells.Add(cell19);

            //            TableRow tr20 = new TableRow();
            //            TableCell cell20 = new TableCell();
            //            cell20.Text = "MISSING ASSET";
            //            tr20.Cells.Add(cell20);

            //            TableRow tr21 = new TableRow();
            //            TableCell cell21 = new TableCell();
            //            cell21.Controls.Add(gridview15);
            //            tr21.Cells.Add(cell21);

            //            TableRow tr22 = new TableRow();
            //            TableCell cell22 = new TableCell();
            //            cell22.Text = " ";
            //            tr22.Cells.Add(cell22);

            //            TableRow tr23 = new TableRow();
            //            TableCell cell23 = new TableCell();
            //            cell23.Text = "DAMAGE ASSET";
            //            tr23.Cells.Add(cell23);

            //            TableRow tr24 = new TableRow();
            //            TableCell cell24 = new TableCell();
            //            cell24.Controls.Add(gridview16);
            //            tr24.Cells.Add(cell24);

            //            TableRow tr25 = new TableRow();
            //            TableCell cell25 = new TableCell();
            //            cell25.Text = " ";
            //            tr25.Cells.Add(cell25);

            //            TableRow tr26 = new TableRow();
            //            TableCell cell26 = new TableCell();
            //            cell26.Text = "EXCESS ASSET";
            //            tr26.Cells.Add(cell26);

            //            TableRow tr27 = new TableRow();
            //            TableCell cell27 = new TableCell();
            //            cell27.Controls.Add(gridview17);
            //            tr27.Cells.Add(cell27);

            //            TableRow tr28 = new TableRow();
            //            TableCell cell28 = new TableCell();
            //            cell28.Text = " ";
            //            tr28.Cells.Add(cell28);

            //            TableRow tr29 = new TableRow();
            //            TableCell cell29 = new TableCell();
            //            cell29.Text = "BANK RECONCILIATION";
            //            tr29.Cells.Add(cell29);

            //            TableRow tr30 = new TableRow();
            //            TableCell cell30 = new TableCell();
            //            cell30.Controls.Add(gridview18);
            //            tr30.Cells.Add(cell30);

            //            TableRow tr31 = new TableRow();
            //            TableCell cell31 = new TableCell();
            //            cell31.Text = " ";
            //            tr31.Cells.Add(cell31);

            //            TableRow tr32 = new TableRow();
            //            TableCell cell32 = new TableCell();
            //            cell32.Text = "DOCTORS AVAILABILITY";
            //            tr32.Cells.Add(cell32);

            //            TableRow tr33 = new TableRow();
            //            TableCell cell33 = new TableCell();
            //            cell33.Controls.Add(gridview19);
            //            tr33.Cells.Add(cell33);

            //            TableRow tr34 = new TableRow();
            //            TableCell cell34 = new TableCell();
            //            cell34.Text = " ";
            //            tr34.Cells.Add(cell34);

            //            TableRow tr35 = new TableRow();
            //            TableCell cell35 = new TableCell();
            //            cell35.Text = "VERTICAL WISE STATUS";
            //            tr35.Cells.Add(cell35);

            //            TableRow tr36 = new TableRow();
            //            TableCell cell36 = new TableCell();
            //            cell36.Controls.Add(gridview10);
            //            tr36.Cells.Add(cell36);

            //            TableRow tr37 = new TableRow();
            //            TableCell cell37 = new TableCell();
            //            cell37.Text = " ";
            //            tr37.Cells.Add(cell37);

            //            //TableRow tr38 = new TableRow();
            //            //TableCell cell38 = new TableCell();
            //            //cell38.Text = "INVENTORY STATUS";
            //            //tr38.Cells.Add(cell38);

            //            //TableRow tr39 = new TableRow();
            //            //TableCell cell39 = new TableCell();
            //            //cell39.Controls.Add(gridview11);
            //            //tr39.Cells.Add(cell39);

            //            //TableRow tr40 = new TableRow();
            //            //TableCell cell40 = new TableCell();
            //            //cell40.Text = " ";
            //            //tr40.Cells.Add(cell40);

            //            tb.Rows.Add(tr1);
            //            tb.Rows.Add(tr2);
            //            tb.Rows.Add(tr3);
            //            tb.Rows.Add(tr4);
            //            tb.Rows.Add(tr5);
            //            tb.Rows.Add(tr6);
            //            tb.Rows.Add(tr7);
            //            tb.Rows.Add(tr8);
            //            tb.Rows.Add(tr9);
            //            tb.Rows.Add(tr10);
            //            tb.Rows.Add(tr11);
            //            tb.Rows.Add(tr12);
            //            tb.Rows.Add(tr13);
            //            tb.Rows.Add(tr14);
            //            tb.Rows.Add(tr15);
            //            tb.Rows.Add(tr16);
            //            tb.Rows.Add(tr17);
            //            tb.Rows.Add(tr18);
            //            tb.Rows.Add(tr19);
            //            tb.Rows.Add(tr20);
            //            tb.Rows.Add(tr21);
            //            tb.Rows.Add(tr22);
            //            tb.Rows.Add(tr23);
            //            tb.Rows.Add(tr24);
            //            tb.Rows.Add(tr25);
            //            tb.Rows.Add(tr26);
            //            tb.Rows.Add(tr27);
            //            tb.Rows.Add(tr28);
            //            tb.Rows.Add(tr29);
            //            tb.Rows.Add(tr30);
            //            tb.Rows.Add(tr31);
            //            tb.Rows.Add(tr32);
            //            tb.Rows.Add(tr33);
            //            tb.Rows.Add(tr34);
            //            tb.Rows.Add(tr35);
            //            tb.Rows.Add(tr36);
            //            tb.Rows.Add(tr37);
            //            //tb.Rows.Add(tr38);
            //            //tb.Rows.Add(tr39);
            //            //tb.Rows.Add(tr40);

            //            tb.RenderControl(hw);

            //            //Response.Output.Write(sw.ToString());
            //            //Response.Flush();
            //            if (File.Exists(Server.MapPath("~/Charge_Rpt/" + fname + ".xls")))
            //            {
            //                int result = objService.OperationStatus_InsertUpdate("Chargereport", "~/Charge_Rpt/" + fname + ".xls", " ", " ", " ", " ");
            //                if (result == 1)
            //                {
            //                }
            //                Response.Redirect("Charge_Rpt/" + fname + ".xls");
            //            }
            //        }
            //    }
            //    //}
            //}
            //catch (Exception ex)
            //{
            //    Response.Write(ex.ToString());
            //}
            //finally
            //{
            //    Response.End();

            //}
            //#endregion
        }
        #endregion

        protected void txt_SCash_TextChanged1(object sender, EventArgs e)
        {
            Double cash1, cash2;
            GridViewRow row = ((GridViewRow)((System.Web.UI.WebControls.TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            System.Web.UI.WebControls.TextBox phstk = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash");
            System.Web.UI.WebControls.TextBox lblStk = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash");

            if (phstk.Text == "" || phstk.Text == null) cash1 = 0; else cash1 = Convert.ToDouble(phstk.Text);
            if (lblStk.Text == "" || lblStk.Text == null) cash2 = 0; else cash2 = Convert.ToDouble(lblStk.Text);
            ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff")).Text = (cash1 - cash2).ToString();
            //ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl((System.Web.UI.WebControls.TextBox)row.FindControl("txt_PStk"));
            //ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            //scriptMan.RegisterAsyncPostBackControl(phstk);
            ScriptManager currPageScriptManager = ScriptManager.GetCurrent(Page) as ScriptManager;
            if (currPageScriptManager != null)
            {
                currPageScriptManager.RegisterAsyncPostBackControl(phstk);
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["Login_Table"];
            //string fname = "ChargeReport- " + dt.Rows[0]["Branchid"].ToString();// + "-" + dt.Rows[0]["username"].ToString(); 
            Load_Grid();
            Btn_Submit1.Visible = true;
            //if (File.Exists(Server.MapPath("~/BranchVisit_Rpt/" + fname + ".xls")))
            //{
            //    //GridRegisters.Visible = false;
            //    //GridAssetVerifn.Visible = false;
            //    //GridCashPosition1.Visible = false;
            //    //GridCashPosition2.Visible = false;
            //    Label12.Visible = false;
            //    cmb_branch.Visible = false;
            //    BtnSubmit.Visible = false;
            //    Btn_Submit1.Visible = false;
            //    Response.Redirect("Charge_Rpt/" + fname + ".xls");
            //}
            //else
            //{
            //    Label12.Visible = true;
            //    cmb_branch.Visible = true;
            //    BtnSubmit.Visible = true;
            //    Btn_Submit1.Visible = true;
            //    Load_Grid();
            //}
        }

        protected void Btn_Submit2_Click(object sender, EventArgs e)
        {
            int result1 = 0; DataTable dt = (DataTable)Session["Login_Table"];
            for (int i = 0; i < GridCashPosition1.Rows.Count; i++)
            {
                GridViewRow row = GridCashPosition1.Rows[i];
                result1 = objService.ChargeRpt_Cash_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(),((System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks")).Text, "", "", "","");
            }
            for (int i = 0; i < GridCashPosition2.Rows.Count; i++)
            {
                GridViewRow row = GridCashPosition2.Rows[i];
                result1 = objService.ChargeRpt_Cash_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(), "", "", "", "",((System.Web.UI.WebControls.TextBox)row.FindControl("txt_PCash")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_SCash")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks")).Text);
            }
            for (int i = 0; i < GridKeyStatus.Rows.Count; i++)
            {
                GridViewRow row = GridKeyStatus.Rows[i];
                result1 = objService.ChargeRpt_Key_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(),((System.Web.UI.WebControls.Label)row.FindControl("lbl_Name")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Count")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Mis")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks")).Text);
            }
            for (int i = 0; i < GridRegisters.Rows.Count; i++)
            {
                GridViewRow row = GridRegisters.Rows[i];
                result1 = objService.ChargeRpt_Registers_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(), ((System.Web.UI.WebControls.Label)row.FindControl("lbl_Upd")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Status")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks")).Text);
            }
            for (int i = 0; i < GridMisAsset.Rows.Count; i++)
            {
                GridViewRow row = GridMisAsset.Rows[i];
                result1 = objService.ChargeRpt_Asset_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(), "MISSTING ASSET", ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_item")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_make")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_model")).Text);
            }
            for (int i = 0; i < GridDamageAset.Rows.Count; i++)
            {
                GridViewRow row = GridDamageAset.Rows[i];
                result1 = objService.ChargeRpt_Asset_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(), "DAMAGE ASSET", ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_item")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_make")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_model")).Text);
            }
            for (int i = 0; i < GridExcessAst.Rows.Count; i++)
            {
                GridViewRow row = GridExcessAst.Rows[i];
                result1 = objService.ChargeRpt_Asset_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(), "EXCESS ASSET", ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_asset")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_item")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_make")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_model")).Text);
            }
            for (int i = 0; i < GridBank.Rows.Count; i++)
            {
                GridViewRow row = GridBank.Rows[i];
                result1 = objService.ChargeRpt_Asset_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(), "BANK RECONCILIATION", ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Name")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_item")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_make")).Text," ");
            }
            for(int i=0;i<GridDoctors.Rows.Count;i++)
            {
                GridViewRow row = GridDoctors.Rows[i];
                result1 = objService.ChargeRpt_Doctors_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(),((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Name")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_dept")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Spcl")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks")).Text);

            }
            for (int i=0;i<GridVertical.Rows.Count;i++)
            {
                GridViewRow row = GridVertical.Rows[i];
                result1 = objService.ChargeRpt_Vertical_InsertUpdate(Convert.ToInt32(dt.Rows[0]["branchid"].ToString()), dt.Rows[0]["username"].ToString(),((System.Web.UI.WebControls.Label)row.FindControl("lbl_Service")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_MStatus")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_WrkCondtn")).Text, ((System.Web.UI.WebControls.TextBox)row.FindControl("txt_Remarks")).Text);

            }
            if (result1 > 0)
            {
                Response.Write("<script>alert('Added Successfully');</script>");
                Load_file1();
                Load_Grid();
            }
            else
            {
                Response.Write("<script>alert('Error Occured');</script>");
            }
        }

        #region MissedAsset
        private ArrayList GetDummyData()
        {

            ArrayList arr = new ArrayList();

            arr.Add(new ListItem("Item1", "1"));
            arr.Add(new ListItem("Item2", "2"));
            arr.Add(new ListItem("Item3", "3"));
            arr.Add(new ListItem("Item4", "4"));
            arr.Add(new ListItem("Item5", "5"));

            return arr;
        }
        private void SetInitialRow()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Status", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Diff", typeof(string)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Name"] = string.Empty;
            dr["Status"] = string.Empty;
            dr["Diff"] = string.Empty;
            dr["Remarks"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            GridMisAsset.DataSource = dt;
            GridMisAsset.DataBind();

        }

        private void AddNewRowToGrid()
        {

            if (ViewState["CurrentTable"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)GridMisAsset.Rows[i].Cells[1].FindControl("txt_asset");
                        TextBox box2 = (TextBox)GridMisAsset.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridMisAsset.Rows[i].Cells[3].FindControl("txt_make");
                        TextBox box4 = (TextBox)GridMisAsset.Rows[i].Cells[4].FindControl("txt_model");

                        dtCurrentTable.Rows[i]["Name"] = box1.Text;
                        dtCurrentTable.Rows[i]["Status"] = box2.Text;
                        dtCurrentTable.Rows[i]["Diff"] = box3.Text;
                        dtCurrentTable.Rows[i]["Remarks"] = box4.Text;

                        //extract the DropDownList Selected Items   

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridMisAsset.DataSource = dtCurrentTable;
                    GridMisAsset.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData();
        }

        private void SetPreviousData()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridMisAsset.Rows[i].Cells[1].FindControl("txt_asset");
                        TextBox box2 = (TextBox)GridMisAsset.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridMisAsset.Rows[i].Cells[3].FindControl("txt_make");
                        TextBox box4 = (TextBox)GridMisAsset.Rows[i].Cells[4].FindControl("txt_model");

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Name"].ToString();
                            box2.Text = dt.Rows[i]["Status"].ToString();
                            box3.Text = dt.Rows[i]["Diff"].ToString();
                            box4.Text = dt.Rows[i]["Remarks"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks  

                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }

        protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                GridMisAsset.DataSource = dt;
                GridMisAsset.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData();
        }

        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        #endregion

        #region DmageAsset
        //private ArrayList GetDummyData1()
        //{

        //    ArrayList arr = new ArrayList();

        //    arr.Add(new ListItem("Item1", "1"));
        //    arr.Add(new ListItem("Item2", "2"));
        //    arr.Add(new ListItem("Item3", "3"));
        //    arr.Add(new ListItem("Item4", "4"));
        //    arr.Add(new ListItem("Item5", "5"));

        //    return arr;
        //}



        private void SetInitialRow1()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Status", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Diff", typeof(string)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Name"] = string.Empty;
            dr["Status"] = string.Empty;
            dr["Diff"] = string.Empty;
            dr["Remarks"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable1"] = dt;

            //Bind the Gridview   
            GridDamageAset.DataSource = dt;
            GridDamageAset.DataBind();

        }

        private void AddNewRowToGrid1()
        {

            if (ViewState["CurrentTable1"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable1"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)GridDamageAset.Rows[i].Cells[1].FindControl("txt_asset");
                        TextBox box2 = (TextBox)GridDamageAset.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridDamageAset.Rows[i].Cells[3].FindControl("txt_make");
                        TextBox box4 = (TextBox)GridDamageAset.Rows[i].Cells[4].FindControl("txt_model");

                        dtCurrentTable.Rows[i]["Name"] = box1.Text;
                        dtCurrentTable.Rows[i]["Status"] = box2.Text;
                        dtCurrentTable.Rows[i]["Diff"] = box3.Text;
                        dtCurrentTable.Rows[i]["Remarks"] = box4.Text;

                        //extract the DropDownList Selected Items   

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridDamageAset.DataSource = dtCurrentTable;
                    GridDamageAset.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData1();
        }

        private void SetPreviousData1()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridDamageAset.Rows[i].Cells[1].FindControl("txt_asset");
                        TextBox box2 = (TextBox)GridDamageAset.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridDamageAset.Rows[i].Cells[3].FindControl("txt_make");
                        TextBox box4 = (TextBox)GridDamageAset.Rows[i].Cells[4].FindControl("txt_model");

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Name"].ToString();
                            box2.Text = dt.Rows[i]["Status"].ToString();
                            box3.Text = dt.Rows[i]["Diff"].ToString();
                            box4.Text = dt.Rows[i]["Remarks"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks  

                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click1(object sender, EventArgs e)
        {
            AddNewRowToGrid1();
        }

        protected void Gridview2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable1"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable1"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable1"] = dt;

                //Re bind the GridView for the updated data  
                GridDamageAset.DataSource = dt;
                GridDamageAset.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData1();
        }

        private void ResetRowID1(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        #endregion

        #region excessAsset
        //private ArrayList GetDummyData2()
        //{

        //    ArrayList arr = new ArrayList();

        //    arr.Add(new ListItem("Item1", "1"));
        //    arr.Add(new ListItem("Item2", "2"));
        //    arr.Add(new ListItem("Item3", "3"));
        //    arr.Add(new ListItem("Item4", "4"));
        //    arr.Add(new ListItem("Item5", "5"));

        //    return arr;
        //}



        private void SetInitialRow2()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Status", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Diff", typeof(string)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Name"] = string.Empty;
            dr["Status"] = string.Empty;
            dr["Diff"] = string.Empty;
            dr["Remarks"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable3"] = dt;

            //Bind the Gridview   
            GridExcessAst.DataSource = dt;
            GridExcessAst.DataBind();

        }

        private void AddNewRowToGrid2()
        {

            if (ViewState["CurrentTable3"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable3"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable3"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)GridExcessAst.Rows[i].Cells[1].FindControl("txt_asset");
                        TextBox box2 = (TextBox)GridExcessAst.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridExcessAst.Rows[i].Cells[3].FindControl("txt_make");
                        TextBox box4 = (TextBox)GridExcessAst.Rows[i].Cells[4].FindControl("txt_model");

                        dtCurrentTable.Rows[i]["Name"] = box1.Text;
                        dtCurrentTable.Rows[i]["Status"] = box2.Text;
                        dtCurrentTable.Rows[i]["Diff"] = box3.Text;
                        dtCurrentTable.Rows[i]["Remarks"] = box4.Text;

                        //extract the DropDownList Selected Items   

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridExcessAst.DataSource = dtCurrentTable;
                    GridExcessAst.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData2();
        }

        private void SetPreviousData2()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable3"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable3"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridExcessAst.Rows[i].Cells[1].FindControl("txt_asset");
                        TextBox box2 = (TextBox)GridExcessAst.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridExcessAst.Rows[i].Cells[3].FindControl("txt_make");
                        TextBox box4 = (TextBox)GridExcessAst.Rows[i].Cells[4].FindControl("txt_model");

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Name"].ToString();
                            box2.Text = dt.Rows[i]["Status"].ToString();
                            box3.Text = dt.Rows[i]["Diff"].ToString();
                            box4.Text = dt.Rows[i]["Remarks"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks  

                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click2(object sender, EventArgs e)
        {
            AddNewRowToGrid2();
        }

        protected void Gridview3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable3"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void LinkButton1_Click2(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable3"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable3"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable3"] = dt;

                //Re bind the GridView for the updated data  
                GridExcessAst.DataSource = dt;
                GridExcessAst.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData2();
        }

        private void ResetRowID2(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        #endregion

        #region BANK RECONCILIATION
        //private ArrayList GetDummyData2()
        //{

        //    ArrayList arr = new ArrayList();

        //    arr.Add(new ListItem("Item1", "1"));
        //    arr.Add(new ListItem("Item2", "2"));
        //    arr.Add(new ListItem("Item3", "3"));
        //    arr.Add(new ListItem("Item4", "4"));
        //    arr.Add(new ListItem("Item5", "5"));

        //    return arr;
        //}



        private void SetInitialRow3()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Status", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Diff", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Name"] = string.Empty;
            dr["Status"] = string.Empty;
            dr["Diff"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable4"] = dt;

            //Bind the Gridview   
            GridBank.DataSource = dt;
            GridBank.DataBind();

        }

        private void AddNewRowToGrid3()
        {

            if (ViewState["CurrentTable4"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable4"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable4"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)GridBank.Rows[i].Cells[1].FindControl("txt_Name");
                        TextBox box2 = (TextBox)GridBank.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridBank.Rows[i].Cells[3].FindControl("txt_make");

                        dtCurrentTable.Rows[i]["Name"] = box1.Text;
                        dtCurrentTable.Rows[i]["Status"] = box2.Text;
                        dtCurrentTable.Rows[i]["Diff"] = box3.Text;

                        //extract the DropDownList Selected Items   

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridBank.DataSource = dtCurrentTable;
                    GridBank.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData3();
        }

        private void SetPreviousData3()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable4"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable4"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridBank.Rows[i].Cells[1].FindControl("txt_Name");
                        TextBox box2 = (TextBox)GridBank.Rows[i].Cells[2].FindControl("txt_item");
                        TextBox box3 = (TextBox)GridBank.Rows[i].Cells[3].FindControl("txt_make");

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Name"].ToString();
                            box2.Text = dt.Rows[i]["Status"].ToString();
                            box3.Text = dt.Rows[i]["Diff"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks  

                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click3(object sender, EventArgs e)
        {
            AddNewRowToGrid3();
        }

        protected void Gridview4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable4"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void LinkButton1_Click3(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable4"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable4"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable4"] = dt;

                //Re bind the GridView for the updated data  
                GridBank.DataSource = dt;
                GridBank.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData3();
        }

        private void ResetRowID3(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        #endregion

        #region DOCTORS AVAILABILITY
        //private ArrayList GetDummyData2()
        //{

        //    ArrayList arr = new ArrayList();

        //    arr.Add(new ListItem("Item1", "1"));
        //    arr.Add(new ListItem("Item2", "2"));
        //    arr.Add(new ListItem("Item3", "3"));
        //    arr.Add(new ListItem("Item4", "4"));
        //    arr.Add(new ListItem("Item5", "5"));

        //    return arr;
        //}



        private void SetInitialRow4()
        {

            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Name", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Status", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Diff", typeof(string)));
            dt.Columns.Add(new DataColumn("Remarks", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Name"] = string.Empty;
            dr["Status"] = string.Empty;
            dr["Diff"] = string.Empty;
            dr["Remarks"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable5"] = dt;

            //Bind the Gridview   
            GridDoctors.DataSource = dt;
            GridDoctors.DataBind();

        }

        private void AddNewRowToGrid4()
        {

            if (ViewState["CurrentTable5"] != null)
            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable5"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = dtCurrentTable.Rows.Count + 1;

                    //add new row to DataTable   
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    //Store the current data to ViewState for future reference   

                    ViewState["CurrentTable5"] = dtCurrentTable;


                    for (int i = 0; i < dtCurrentTable.Rows.Count - 1; i++)
                    {

                        //extract the TextBox values   

                        TextBox box1 = (TextBox)GridDoctors.Rows[i].Cells[1].FindControl("txt_Name");
                        TextBox box2 = (TextBox)GridDoctors.Rows[i].Cells[2].FindControl("txt_dept");
                        TextBox box3 = (TextBox)GridDoctors.Rows[i].Cells[3].FindControl("txt_Spcl");
                        TextBox box4 = (TextBox)GridDoctors.Rows[i].Cells[4].FindControl("txt_Remarks");

                        dtCurrentTable.Rows[i]["Name"] = box1.Text;
                        dtCurrentTable.Rows[i]["Status"] = box2.Text;
                        dtCurrentTable.Rows[i]["Diff"] = box3.Text;
                        dtCurrentTable.Rows[i]["Remarks"] = box4.Text;

                        //extract the DropDownList Selected Items   

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridDoctors.DataSource = dtCurrentTable;
                    GridDoctors.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");

            }
            //Set Previous Data on Postbacks   
            SetPreviousData4();
        }

        private void SetPreviousData4()
        {

            int rowIndex = 0;
            if (ViewState["CurrentTable5"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable5"];
                if (dt.Rows.Count > 0)
                {

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        TextBox box1 = (TextBox)GridDoctors.Rows[i].Cells[1].FindControl("txt_Name");
                        TextBox box2 = (TextBox)GridDoctors.Rows[i].Cells[2].FindControl("txt_dept");
                        TextBox box3 = (TextBox)GridDoctors.Rows[i].Cells[3].FindControl("txt_Spcl");
                        TextBox box4 = (TextBox)GridDoctors.Rows[i].Cells[4].FindControl("txt_Remarks");

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Name"].ToString();
                            box2.Text = dt.Rows[i]["Status"].ToString();
                            box3.Text = dt.Rows[i]["Diff"].ToString();
                            box4.Text = dt.Rows[i]["Remarks"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks  

                        }

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click4(object sender, EventArgs e)
        {
            AddNewRowToGrid4();
        }

        protected void Gridview5_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable5"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }

        protected void LinkButton1_Click4(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable5"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentTable5"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data and reset row number  
                        dt.Rows.Remove(dt.Rows[rowID]);
                        ResetRowID(dt);
                    }
                }

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable5"] = dt;

                //Re bind the GridView for the updated data  
                GridDoctors.DataSource = dt;
                GridDoctors.DataBind();
            }

            //Set Previous Data on Postbacks  
            SetPreviousData2();
        }

        private void ResetRowID4(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        #endregion
    }
}