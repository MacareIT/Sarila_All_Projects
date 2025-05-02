using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace Compliance_Register
{
    public partial class Report : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddldept();
                load_grid();
            }
        }

        private void bindddldept()
        {
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_depertment().Tables[0];
            ddl_Dept.DataSource = dt1;
            ddl_Dept.DataTextField = "dept_name";
            ddl_Dept.DataValueField = "dept_id";
            ddl_Dept.DataBind();
            ddl_Dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        public void load_grid()
        {
            DataTable dt_grid = objservice.Select_for_Report(Ddl_type.SelectedValue, Convert.ToInt32(ddl_Dept.SelectedValue)).Tables[0];
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
            DataTable dt = new DataTable();
            dt.Columns.Add("Compliance incident"); dt.Columns.Add("Dept name"); dt.Columns.Add("Compliance type");
            dt.Columns.Add("Duration type"); dt.Columns.Add("Entered date"); dt.Columns.Add("Entered by");
            dt.Columns.Add("Head verify date"); dt.Columns.Add("CS verify date"); dt.Columns.Add("File Download");
            foreach (GridViewRow row in GridView1.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < GridView1.Columns.Count; j++)
                {
                    dr[j] = row.Cells[j].Text;
                }

                dt.Rows.Add(dr);
            }
            if(dt.Rows.Count>0)
            {
                dt.Columns.Remove("File Download");

                GridView grid = new GridView();
                grid.DataSource = dt;
                grid.DataBind();

                Table tb = new Table();
                TableRow tr1 = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = "COMPLIANCE REPORT " ;
                tr1.Cells.Add(cell1);

                TableRow tr2 = new TableRow();
                TableCell cell2 = new TableCell();
                cell2.Controls.Add(grid);
                tr2.Cells.Add(cell2);

                tb.Rows.Add(tr1);
                tb.Rows.Add(tr2);

                Response.ContentType = "application/x-msexcel";
                Response.AddHeader("Content-Disposition", "attachment;filename = Compliance_rpt.xls");
                Response.ContentEncoding = Encoding.UTF8;
                StringWriter tw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(tw);
                tb.RenderControl(hw);
                Response.Write(tw.ToString());
                Response.End();
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

        protected void ddl_Dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_grid();
        }
    }
}