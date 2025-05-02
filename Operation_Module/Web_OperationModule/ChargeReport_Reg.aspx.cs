using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Collections;

namespace Web_OperationModule
{
    public partial class ChargeReport_Reg : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        #region missedAsset
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
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));//for TextBox value   
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));//for DropDownList selected item   
            dt.Columns.Add(new DataColumn("Column4", typeof(string)));//for DropDownList selected item   

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dt.Rows.Add(dr);

            //Store the DataTable in ViewState for future reference   
            ViewState["CurrentTable"] = dt;

            //Bind the Gridview   
            GridMissAsset.DataSource = dt;
            GridMissAsset.DataBind();

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

                        TextBox box1 = (TextBox)GridMissAsset.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridMissAsset.Rows[i].Cells[2].FindControl("TextBox2");

                        dtCurrentTable.Rows[i]["Column1"] = box1.Text;
                        dtCurrentTable.Rows[i]["Column2"] = box2.Text;

                        //extract the DropDownList Selected Items   

                    }

                    //Rebind the Grid with the current data to reflect changes   
                    GridMissAsset.DataSource = dtCurrentTable;
                    GridMissAsset.DataBind();
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

                        TextBox box1 = (TextBox)GridMissAsset.Rows[i].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridMissAsset.Rows[i].Cells[2].FindControl("TextBox2");

                        if (i < dt.Rows.Count - 1)
                        {

                            //Assign the value from DataTable to the TextBox   
                            box1.Text = dt.Rows[i]["Column1"].ToString();
                            box2.Text = dt.Rows[i]["Column2"].ToString();

                            //Set the Previous Selected Items on Each DropDownList  on Postbacks  

                        }

                        rowIndex++;
                    }
                }
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            //Load_Grid();
            if (!IsPostBack)
            {
                SetInitialRow();
                DataTable dt = (DataTable)Session["Login_Table"];
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["type"].ToString() == "unithead")
                    {
                        Load_Grid();
                        //string fname = "ChargeReport-" + dt.Rows[0]["Branchid"].ToString(); //+ "-" + dt.Rows[0]["username"].ToString();
                        //if (File.Exists(Server.MapPath("~/Charge_Rpt/" + fname + ".xls")))
                        //{
                        //    Label1.Visible = false;
                        //    Label2.Visible = false;
                        //    Label3.Visible = false;
                        //    Label4.Visible = false;
                        //    Label5.Visible = false;
                        //    Label6.Visible = false;
                        //    Label7.Visible = false;
                        //    Label8.Visible = false;
                        //    Label9.Visible = false;
                        //    Label10.Visible = false;
                        //    Label11.Visible = false;
                        //    Label12.Visible = false;
                        //    cmb_branch.Visible = false;
                        //    BtnSubmit.Visible = false;
                        //    Btn_Submit1.Visible = false;
                        //    Response.Redirect("~/Charge_Rpt/" + fname + ".xls");
                        //}
                        //else
                        //{
                        //    Label1.Visible = true;
                        //    Label2.Visible = true;
                        //    Label3.Visible = true;
                        //    Label4.Visible = true;
                        //    Label5.Visible = true;
                        //    Label6.Visible = true;
                        //    Label7.Visible = true;
                        //    Label8.Visible = true;
                        //    Label9.Visible = true;
                        //    Label10.Visible = true;
                        //    Label11.Visible = true;
                        //    Label12.Visible = false;
                        //    cmb_branch.Visible = false;
                        //    BtnSubmit.Visible = false;
                        //    Btn_Submit1.Visible = true;
                        //    Load_Grid();
                        //}
                    }
                    else if (dt.Rows[0]["type"].ToString() == "microlabincharge")
                    {
                        Load_Branch();
                        Load_Grid();
                        //string fname = "ChargeReport-" + cmb_branch.SelectedValue.ToString();// + "-" + dt.Rows[0]["username"].ToString();
                        //if (File.Exists(Server.MapPath("~/Charge_Rpt/" + fname + ".xls")))
                        //{
                        //    Label1.Visible = false;
                        //    Label2.Visible = false;
                        //    Label3.Visible = false;
                        //    Label4.Visible = false;
                        //    Label5.Visible = false;
                        //    Label6.Visible = false;
                        //    Label7.Visible = false;
                        //    Label8.Visible = false;
                        //    Label9.Visible = false;
                        //    Label10.Visible = false;
                        //    Label11.Visible = false;
                        //    Label12.Visible = true;
                        //    cmb_branch.Visible = true;
                        //    BtnSubmit.Visible = true;
                        //    Btn_Submit1.Visible = false;
                        //    Response.Redirect("~/Charge_Rpt/" + fname + ".xls");
                        //}
                        //else
                        //{
                        //    Label1.Visible = true;
                        //    Label2.Visible = true;
                        //    Label3.Visible = true;
                        //    Label4.Visible = true;
                        //    Label5.Visible = true;
                        //    Label6.Visible = true;
                        //    Label7.Visible = true;
                        //    Label8.Visible = true;
                        //    Label9.Visible = true;
                        //    Label10.Visible = true;
                        //    Label11.Visible = true;
                        //    Label12.Visible = true;
                        //    cmb_branch.Visible = true;
                        //    BtnSubmit.Visible = true;
                        //    Btn_Submit1.Visible = true;
                        //    Load_Grid();
                        //}
                    }
                    else
                    {
                        //Response.Write("<script>alert('Permission denied');</script>");
                        //Response.Redirect("~/AmbienceCondtnReg.aspx");
                        //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "InsertedMessage", "alert('Permission denied');", true);
                        //Response.Redirect("~/AmbienceCondtnReg.aspx");
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

        public void Load_Branch()
        {
            DataTable dtBranch = objService.Select_Microlab().Tables[0];
            cmb_branch.DataSource = dtBranch;
            cmb_branch.DataBind();
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

            dtCash.Rows.Add("", "", "", "");
            //ViewState["Curtbl"] = dtCash;
            //GridMissAsset.DataSource = dtCash;
            //GridMissAsset.DataBind();

            //GridDamageAsset.DataSource = dtCash;
            //GridDamageAsset.DataBind();

            //GridExcessAsset.DataSource = dtCash;
            //GridExcessAsset.DataBind();
            SetInitialRow();
            //SetInitialRow(GridDamageAsset);
            //SetInitialRow(GridExcessAsset);

            GridBankRec.DataSource = dtCash;
            GridBankRec.DataBind();

            GridDr.DataSource = dtCash;
            GridDr.DataBind();
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
            //dtCash.Rows.Clear();

            //dtCash.Rows.Add("PHARMACY", "", "", "");
            //dtCash.Rows.Add("LAB", "", "", "");
            //dtCash.Rows.Add("STORE", "", "", "");

            //GridInventory.DataSource = dtCash;
            //GridInventory.DataBind();
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
            GridView gridview1 = new GridView();
            gridview1.DataSource = dt1;
            gridview1.DataBind();

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
            GridView gridview2 = new GridView();
            gridview2.DataSource = dt2;
            gridview2.DataBind();
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
            GridView gridview3 = new GridView();
            gridview3.DataSource = dt3;
            gridview3.DataBind();

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
            GridView gridview4 = new GridView();
            gridview4.DataSource = dt4;
            gridview4.DataBind();

            //if (GridMissAsset.HeaderRow != null)
            //{
            //    for (int k = 0; k < GridMissAsset.HeaderRow.Cells.Count; k++)
            //    {
            //        dt5.Columns.Add(GridMissAsset.HeaderRow.Cells[k].Text);
            //    }
            //}

            ////  add each of the data rows to the table
            //foreach (GridViewRow row in GridMissAsset.Rows)
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
            //GridView gridview5 = new GridView();
            //gridview5.DataSource = dt5;
            //gridview5.DataBind();
            if (GridDamageAsset.HeaderRow != null)
            {
                for (int k = 0; k < GridDamageAsset.HeaderRow.Cells.Count; k++)
                {
                    dt6.Columns.Add(GridDamageAsset.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridDamageAsset.Rows)
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
            GridView gridview6 = new GridView();
            gridview6.DataSource = dt6;
            gridview6.DataBind();

            if (GridExcessAsset.HeaderRow != null)
            {
                for (int k = 0; k < GridExcessAsset.HeaderRow.Cells.Count; k++)
                {
                    dt7.Columns.Add(GridExcessAsset.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridExcessAsset.Rows)
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
            GridView gridview7 = new GridView();
            gridview7.DataSource = dt7;
            gridview7.DataBind();
            if (GridBankRec.HeaderRow != null)
            {
                for (int k = 0; k < GridBankRec.HeaderRow.Cells.Count; k++)
                {
                    dt8.Columns.Add(GridBankRec.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridBankRec.Rows)
            {
                DataRow dr;
                dr = dt8.NewRow();
                //for (int j = 0; j < row.Cells.Count; j++)
                //{
                //    dr[j] = row.Cells[j].Text.Replace(" ", "");
                //}
                var PCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Name");
                var SCash = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_ReconDate");
                var Diff = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_Diff");
                dr[0] = PCash.Text;
                dr[1] = SCash.Text;
                dr[2] = Diff.Text;
                dt8.Rows.Add(dr);
            }
            GridView gridview8 = new GridView();
            gridview8.DataSource = dt8;
            gridview8.DataBind();

            if (GridDr.HeaderRow != null)
            {
                for (int k = 0; k < GridDr.HeaderRow.Cells.Count; k++)
                {
                    dt9.Columns.Add(GridDr.HeaderRow.Cells[k].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GridDr.Rows)
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
            GridView gridview9 = new GridView();
            gridview9.DataSource = dt9;
            gridview9.DataBind();

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


            try
            {
                DataTable dt = (DataTable)Session["Login_Table"]; string fname = "";string branchname = "";
                if (dt.Rows[0]["type"].ToString() == "microlabincharge")
                {
                    fname = "ChargeReport-" + cmb_branch.SelectedValue.ToString();// + "-" + dt.Rows[0]["username"].ToString();
                    branchname = cmb_branch.SelectedItem.ToString();
                }
                else
                {
                    fname = "ChargeReport-" + dt.Rows[0]["Branchid"].ToString();// + "-" + dt.Rows[0]["username"].ToString();
                    branchname = dt.Rows[0]["branch"].ToString();
                }
                //if (File.Exists(Server.MapPath("~/Charge_Rpt/" + fname + ".xls")))
                //{
                //    Response.Redirect("Charge_Rpt/" + fname + ".xls");
                //}
                //else
                //{
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment;filename="+fname+".xls");
                    //Response.Charset = "";
                    //Response.ContentType = "application/vnd.ms-excel";

                    using (StreamWriter sw = new StreamWriter(Server.MapPath("~/Charge_Rpt/" + fname + ".xls"), true))
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
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
                            cell6.Text = branchname;
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
                            cell9.Controls.Add(gridview1);
                            tr9.Cells.Add(cell9);

                            TableRow tr10 = new TableRow();
                            TableCell cell10 = new TableCell();
                            cell10.Text = " ";
                            tr10.Cells.Add(cell10);

                            TableRow tr11 = new TableRow();
                            TableCell cell11 = new TableCell();
                            cell11.Controls.Add(gridview2);
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
                            cell14.Controls.Add(gridview3);
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
                            cell17.Controls.Add(gridview4);
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
                            //cell21.Controls.Add(gridview5);
                            //tr21.Cells.Add(cell21);

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
                        cell24.Controls.Add(gridview6);
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
                            cell27.Controls.Add(gridview7);
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
                            cell30.Controls.Add(gridview8);
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
                            cell33.Controls.Add(gridview9);
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

                            tb.RenderControl(hw);

                            //Response.Output.Write(sw.ToString());
                            //Response.Flush();
                            if (File.Exists(Server.MapPath("~/Charge_Rpt/" + fname + ".xls")))
                            {
                                Response.Redirect("Charge_Rpt/" + fname + ".xls");
                            }
                        }
                    }
                //}
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                Response.End();

            }
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
            string fname = "ChargeReport- " + cmb_branch.SelectedValue.ToString();// + "-" + dt.Rows[0]["username"].ToString(); 
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

        //.............................................................................................................

        #region missedAsset
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
                GridMissAsset.DataSource = dt;
                GridMissAsset.DataBind();
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
    }
}