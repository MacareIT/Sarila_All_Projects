using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class Ambience_View : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                if (dt.Rows.Count > 0)
                {
                    BtnVerify.Visible = false;
                    Load_Branch();
                    Load_Month(); Load_Year();
                    //cmbYr.SelectedValue = DateTime.Now.ToString("yyyy");
                    cmbMnth.SelectedValue = DateTime.Now.Month.ToString();
                    load_Data();
                }
                else
                    Response.Write("<script>alert('Session Expired')</script>");

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
        }
        public void Load_Year()
        {
            DataTable dtYear = new DataTable();
            dtYear = objService.Select_Year().Tables[0];
            if (dtYear.Rows.Count > 0)
            {
                cmbYr.DataSource = dtYear;
                cmbYr.DataBind();
            }
            else
            {
                DataTable dtYr = new DataTable();
                dtYr.Columns.Add("Year");
                dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
                cmbYr.DataSource = dtYr;
                cmbYr.DataBind();
            }

        }
        protected void Grid_Ambience_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Grid_Ambience.EditIndex = e.NewEditIndex;
            load_Data();
        }

        protected void Grid_Ambience_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int chkvalue = 0;
            Label id = Grid_Ambience.Rows[e.RowIndex].FindControl("lbl_conId") as Label;
            TextBox reason = Grid_Ambience.Rows[e.RowIndex].FindControl("txtExplanation") as TextBox;
            CheckBox chk1 = Grid_Ambience.Rows[e.RowIndex].FindControl("chkbox") as CheckBox;
            if (chk1.Checked == true)
                chkvalue = 1;
            else chkvalue = 0;

            Grid_Ambience.EditIndex = -1;
            //Call ShowData method for displaying updated data  
            int result = 0;
            result = objService.AmbienceCondtn_StatusUpdate(Convert.ToInt32(id.Text), reason.Text, chkvalue);
            if (result == 1)
                load_Data();
        }
        public void load_Data()
        {
            if (string.IsNullOrEmpty(cmbYr.SelectedValue))
            {
            }
            else
            {
                DataTable dtAmbience = objService.Select_AmbienceCondition(Convert.ToInt32(cmbBranch.SelectedValue), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue)).Tables[0];
                if (dtAmbience.Rows.Count > 0)
                {
                    Grid_Ambience.DataSource = dtAmbience;
                    Grid_Ambience.DataBind();
                    BtnVerify.Visible = true;
                }
                else
                {
                    Grid_Ambience.DataSource = null;
                    Grid_Ambience.DataBind();
                    BtnVerify.Visible = false;
                }
                DataTable dtImage = objService.AmbiencePic_Select(Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbBranch.SelectedValue)).Tables[0];
                //Grid_Image.DataSource = dtImage;
                //Grid_Image.DataBind();
                DataList1.DataSource = dtImage;
                DataList1.DataBind();
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            load_Data();
        }

        protected void Grid_Ambience_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    CheckBox CheckBox1 = (e.Row.FindControl("chkbox") as CheckBox);
            //    CheckBox1.Enabled = false;
            //}
        }

        protected void Grid_Ambience_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Grid_Ambience.EditIndex = -1;
            load_Data();
        }

        protected void BtnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbYr.SelectedValue))
                {
                }
                else
                {
                    int result = objService.AmbienceCondtn_VerifyStatusUpdate(Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbBranch.SelectedValue), ((DataTable)Session["Login_Table"]).Rows[0]["username"].ToString());
                    int result1 = objService.AmbiencePic_VerifyStatusUpdate(Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbBranch.SelectedValue));
                    if (result > 0 && result1>0)
                    {
                        Response.Write("<script>alert('Verified');</script>");
                    }
                    else
                        Response.Write("<script>alert('Exception Occurs');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}