using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class Optical_StockUpdation : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objkService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Laod_branch();
                DataTable dt = (DataTable)Session["Login_Table"];
                if (dt.Rows.Count > 0)
                {
                    Load_OpticalStock(cmbBranch.SelectedValue.ToString());
                }
                else
                    Response.Write("<script>alert('Session time out!!!')</script>");
            }
        }
        public void Load_OpticalStock(string branch_id)
        {
            //DataTable dt = (DataTable)Session["Login_Table"];
            DataTable dtStk = new DataTable();

            dtStk = objkService.Select_OpticalStock(Convert.ToInt32(branch_id)).Tables[0];
            if (dtStk.Rows.Count > 0)
            {
                GridAmbCondtn.DataSource = dtStk;
                GridAmbCondtn.DataBind();
                Btn_Submit.Visible = true;
            }
            else
            {
                Btn_Submit.Visible = false;
                GridAmbCondtn.DataSource = null;
                GridAmbCondtn.DataBind();
            }
        }
        public void Laod_branch()
        {
            DataTable dtbranch = objkService.Select_Macare_Opticals().Tables[0];
            if(dtbranch.Rows.Count>0)
            {
                cmbBranch.DataSource = dtbranch;
                cmbBranch.DataBind();
                cmbBranch.DataTextField = "branch_name";
                cmbBranch.DataValueField = "branch_id";
            }
        }
        protected void txt_PStk_TextChanged(object sender, EventArgs e)
        {
            
        }
        protected void GridAmbCondtn_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridAmbCondtn.PageIndex = e.NewSelectedIndex;
        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            if (Session["Login_Table"] != null)
            {
                try
                {
                    DataTable dt = (DataTable)Session["Login_Table"];int result = 0;
                   
                    foreach (GridViewRow row1 in GridAmbCondtn.Rows)
                    {
                        result = objkService.OpticalStock_InsertUpdate(Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()), ((System.Web.UI.WebControls.Label)(row1.Cells[1].FindControl("lbl_ITemName"))).Text, Convert.ToInt32(((System.Web.UI.WebControls.Label)(row1.Cells[2].FindControl("lbl_stock"))).Text), Convert.ToInt32(((System.Web.UI.WebControls.TextBox)(row1.Cells[3].FindControl("txt_PStk"))).Text),dt.Rows[0]["username"].ToString());
                    }
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Added Successfully');</script>");
                    }

                    else
                    {
                        Response.Write("<script>alert('Error Occured');</script>");
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else Response.Write("<script>alert('Session time out!!!');</script>");
        }

        protected void txt_PStk_TextChanged1(object sender, EventArgs e)
        {
            //GridViewRow row = ((GridViewRow)((System.Web.UI.WebControls.TextBox)sender).NamingContainer);
            ////NamingContainer return the container that the control sits in
            //System.Web.UI.WebControls.TextBox phstk = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_PStk");
            //System.Web.UI.WebControls.Label lblStk = (System.Web.UI.WebControls.Label)row.FindControl("lbl_stock");
            //((System.Web.UI.WebControls.Label)row.FindControl("lbl_Diff")).Text = (Convert.ToDouble(phstk.Text) - Convert.ToDouble(lblStk.Text)).ToString();
            ////ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl((System.Web.UI.WebControls.TextBox)row.FindControl("txt_PStk"));
            ////ScriptManager scriptMan = ScriptManager.GetCurrent(this);
            ////scriptMan.RegisterAsyncPostBackControl(phstk);
            //ScriptManager currPageScriptManager = ScriptManager.GetCurrent(Page) as ScriptManager;
            //if (currPageScriptManager != null)
            //{
            //    currPageScriptManager.RegisterAsyncPostBackControl(phstk);
            //}
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Load_OpticalStock(cmbBranch.SelectedValue.ToString());
        }
    }
}