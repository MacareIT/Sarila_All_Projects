using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Compliance_Register
{
    public partial class Head_Verification : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Lbl_status.Visible = false;
                load_grid(); 
            }
        }
        public void load_grid()
        {
            int dept = 0;
            DataTable dt_dept = objservice.Select_Head_dept(Session["USERID"].ToString()).Tables[0];
            if (dt_dept.Rows.Count > 0)
            {
                if (dt_dept.Rows[0][0].ToString() != "")
                {
                    dept = Convert.ToInt32(dt_dept.Rows[0][0].ToString());

                    DataTable dt_grid = objservice.Select_for_HeadVerifn(dept, Ddl_type.SelectedValue).Tables[0];
                    if (dt_grid.Rows.Count > 0)
                    {
                        Lbl_status.Text = "";
                        GridView1.DataSource = dt_grid;
                        GridView1.DataBind();
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
            }
           
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "verify")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                
                int com_REG_id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);

                objservice.Update_Verify_Head(com_REG_id, Session["USERID"].ToString(), Ddl_type.SelectedValue);
                Response.Write("<script>alert('Verified Successfully')</script>");
                load_grid();

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

        protected void Ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid();
        }
    }
}