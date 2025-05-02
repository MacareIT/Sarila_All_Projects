using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Compliance_Register
{
    public partial class Verify : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Lbl_status.Visible = false;
                bindgrid();
                //mp1.Show();
            }
        }

        private void bindgrid()
        {
            DataTable dt = new DataTable();
            dt = objservice.Select_for_CSVerifn(Ddl_type.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                Lbl_status.Text = "";
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                Lbl_status.Visible = true;
                Lbl_status.Text = "No Verification Pending !!!";
                Lbl_status.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string arg = string.Empty;
            arg = (sender as LinkButton).CommandArgument.ToString();

            byte[] bytes;
            string fileName, contentType;
            ds = objservice.Get_file(Convert.ToInt32(arg), Ddl_type.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                fileName = ds.Tables[0].Rows[0]["filename1"].ToString();
                contentType = ds.Tables[0].Rows[0]["content_type1"].ToString();
                bytes = (byte[])ds.Tables[0].Rows[0]["attachment1"];

                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('No file Uploaded')</script>");
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "verify")
            {
                int result = 0;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];

                int com_REG_id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);
                int com_id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[1]);
                string duration= GridView1.DataKeys[rowIndex].Values[4].ToString();
                result =objservice.Update_Verify_CS(com_REG_id, Session["USERID"].ToString(), Ddl_type.SelectedValue);
                if (result == 1 && duration != "Monthly")
                {
                    Txt_comp.Text = row.Cells[0].Text;
                    Label1.Text = GridView1.DataKeys[rowIndex].Values[1].ToString();
                    txt_Predue.Text = GridView1.DataKeys[rowIndex].Values[2].ToString();
                    txt_PreAlrt.Text = GridView1.DataKeys[rowIndex].Values[3].ToString();
                    mp1.Show();
                }
                else if (result == 1)
                {
                    Response.Write("<script>alert('Verified Successfully')</script>");
                    bindgrid();
                }
                else
                {
                    Response.Write("<script>alert('Error Occured')</script>");
                    bindgrid();
                }
            }
        }

        protected void Ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgrid();
        }
        protected void Cancelsubmit_click(object sender, EventArgs e)
        {
            objservice.update_Compliance_afterverify(Convert.ToInt32(Label1.Text), txt_NewDue.Text, txt_NewAlrt.Text);
            txt_NewAlrt.Text = string.Empty;
            txt_NewDue.Text= string.Empty;
            txt_PreAlrt.Text= string.Empty;
            txt_Predue.Text= string.Empty;
            Txt_comp.Text= string.Empty;
            bindgrid();
            Response.Write("<script>alert('Verified Successfully')</script>");
        }
    }
}