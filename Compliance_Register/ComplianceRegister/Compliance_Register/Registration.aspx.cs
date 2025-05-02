using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace Compliance_Register
{
    public partial class Registration : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddldept();
                DataTable dt_Internal = objservice.Select_Compliance_REG(Convert.ToInt32(Ddl_dept.SelectedValue), DropDownList1.SelectedValue).Tables[0];
                if (dt_Internal.Rows.Count > 0)
                {
                    ddl_com_incident.DataSource = dt_Internal;
                    ddl_com_incident.DataBind();
                }
                else
                {
                    ddl_com_incident.DataSource = null;
                    ddl_com_incident.DataBind();
                }
                if (DropDownList1.SelectedValue == "Internal")
                {
                    lbl_com_name.InnerText = "Internal Compliance Register";
                }
                else
                {
                    lbl_com_name.InnerText = "Statutory Compliance Register";
                }
                bindgrid();
            }
            Label1.Visible = false;
        }

        private void bindddldept()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_depertment().Tables[0];
            Ddl_dept.DataSource = dt1;
            Ddl_dept.DataTextField = "dept_name";
            Ddl_dept.DataValueField = "dept_id";
            Ddl_dept.DataBind();
            Ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        public void bindgrid()
        {
            DataTable dt_grid = objservice.Select_com_Register(Convert.ToInt32(Ddl_dept.SelectedValue), DropDownList1.SelectedValue).Tables[0];
            if(dt_grid.Rows.Count>0)
            {
                GridView1.DataSource = dt_grid;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            if (Session["USERID"] != null)
            {
                if (file_compliance.HasFile)
                {
                    string filename = Path.GetFileName(file_compliance.PostedFile.FileName);
                    string contentType = file_compliance.PostedFile.ContentType;
                    byte[] bytes;
                    using (Stream fs = file_compliance.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                        }
                    }
                    int result = 0;
                    if (DropDownList1.SelectedValue == "Internal")
                        result = objservice.Insert_Compliance_internal(Convert.ToInt32(ddl_com_incident.SelectedValue), Session["USERID"].ToString(), DateTime.Now.ToString("dd-MM-yyyy"), "", "", "", "", 1, "", bytes, filename, contentType, 1);
                    else result = objservice.Insert_Compliance_statutory(Convert.ToInt32(ddl_com_incident.SelectedValue), Session["USERID"].ToString(), DateTime.Now.ToString("dd-MM-yyyy"), "", "", "", "", 1, "", bytes, filename, contentType, 1);
                    if (result > 0)
                    {
                        int rslt = objservice.update_Compliance_status(Convert.ToInt32(ddl_com_incident.SelectedValue));
                        if (rslt > 0)
                            Response.Write("<script>alert('Compliance Added Successfully')</script>");
                        else
                        {
                            Response.Write("<script>alert('Error')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Error')</script>");
                    }
                }
                
                bindgrid();
            }
            else
            {
                Response.Write("<script>alert('Session Out!!!')</script>");
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt_Internal = objservice.Select_Compliance_REG(Convert.ToInt32(Ddl_dept.SelectedValue), DropDownList1.SelectedValue).Tables[0];
            if (dt_Internal.Rows.Count > 0)
            {
                ddl_com_incident.DataSource = dt_Internal;
                ddl_com_incident.DataBind();
            }
            else
            {
                ddl_com_incident.DataSource = null;
                ddl_com_incident.DataBind();
            }
            if (DropDownList1.SelectedValue == "Internal")
            {
                lbl_com_name.InnerText = "Internal Compliance Register";
            }
            else
            {
                lbl_com_name.InnerText = "Statutory Compliance Register";
            }
            bindgrid();
        }

        protected void Ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataSet dt_type = objservice.Select_Compliance_type(Convert.ToInt32(Ddl_dept.SelectedValue));
            DataTable dt_Internal = objservice.Select_Compliance_REG(Convert.ToInt32(Ddl_dept.SelectedValue), DropDownList1.SelectedValue).Tables[0];
            if (dt_Internal.Rows.Count > 0)
            {
                ddl_com_incident.DataSource = dt_Internal;
                ddl_com_incident.DataBind();
            }
            else
            {
                ddl_com_incident.DataSource = null;
                ddl_com_incident.DataBind();
            }
            if (DropDownList1.SelectedValue == "Internal")
            {
                lbl_com_name.InnerText = "Internal Compliance Register";
            }
            else
            {
                lbl_com_name.InnerText = "Statutory Compliance Register";
            }
           
            bindgrid();
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string arg = string.Empty;
            arg = (sender as LinkButton).CommandArgument.ToString();
            
            byte[] bytes;
            string fileName, contentType;
            ds = objservice.Get_file(Convert.ToInt32(arg), DropDownList1.SelectedValue);
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int index = e.NewSelectedIndex;
            //GridViewRow row = GridView1.Rows[index];
            //int Id = Convert.ToInt32(GridView1.DataKeys[e.NewSelectedIndex].Values[0]);
            //ddl_Dept.SelectedValue = Id.ToString();
            //txtAutoComplete.Text = row.Cells[2].Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            GridViewRow row = GridView1.Rows[index];
            int com_REG_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            objservice.Delete_Compliance_Register(com_REG_id,DropDownList1.SelectedValue);
            //objservice.update_Compliance_status_back(Convert.ToInt32(ddl_com_incident.SelectedValue));
            bindgrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    foreach (Button button in e.Row.Cells[5].Controls.OfType<Button>())
            //    {
            //        if (button.CommandName == "Delete")
            //        {
            //            button.Attributes["onclick"] = "if(!confirm('Do you want to delete?')){ return false; };";
            //        }
            //    }
            //}
        }
    }
}