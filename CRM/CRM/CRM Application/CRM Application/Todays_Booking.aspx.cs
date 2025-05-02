using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Text;

namespace CRM_Application
{
    public partial class Todays_Booking : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddldept();
                bindddlbranch();
            }
            Button1.Visible = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }

        private void bindddldept()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Department().Tables[0];
            Ddl_dept.DataSource = dt;
            Ddl_dept.DataTextField = "dept_name";
            Ddl_dept.DataValueField = "dept_id";
            Ddl_dept.DataBind();
            Ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddlbranch()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Branch().Tables[0];
            Ddl_branch.DataSource = dt;
            Ddl_branch.DataTextField = "name";
            Ddl_branch.DataValueField = "branch_id";
            Ddl_branch.DataBind();
            Ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldoctor()
        {
            DateTime today = DateTime.Today;
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctor_availability(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), today.ToString("dd-MM-yyyy")).Tables[0];
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataTextField = "dr_name";
            Ddl_doctor.DataValueField = "dr_id";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddldoctor();
        }

        protected void View_click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DataTable dt = new DataTable();
            dt = objservice.Get_Report_Todaybooking(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue),Convert.ToInt32(Ddl_doctor.SelectedValue), today.ToString("dd-MM-yyyy")).Tables[0];
            if(dt.Rows.Count>0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Button1.Visible = true;
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }


            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/Todays_Booking.rdlc");
            //ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            //ReportParameter Prm;
            //Prm = new ReportParameter("ReportParameter1");
            //Prm.Values.Add("TODAYS BOOKING AT " + Ddl_branch.SelectedItem.Text + " OF " + Ddl_doctor.SelectedItem.Text + " - " + Ddl_dept.SelectedItem.Text + " [ "+ today.ToString("dd-MM-yyyy") + " ] ");
            //ReportViewer1.LocalReport.SetParameters(Prm);
            //ReportViewer1.DataBind();
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(datasource1);
        }

        protected void Export_click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.Charset = "";
            //string FileName = "Booking"+ Ddl_doctor.SelectedItem.Text + DateTime.Now + ".xls";
            //StringWriter strwritter = new StringWriter();
            //HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/vnd.ms-excel";
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //GridView1.GridLines = GridLines.Both;
            //GridView1.HeaderStyle.Font.Bold = true;
            //GridView1.RenderControl(htmltextwrtter);
            //Response.Write(strwritter.ToString());
            //Response.End();

            DateTime today = DateTime.Today;
            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.Text = "TODAYS BOOKING AT " + Ddl_branch.SelectedItem.Text + " OF " + Ddl_doctor.SelectedItem.Text + " - " + Ddl_dept.SelectedItem.Text + " [ " + today.ToString("dd-MM-yyyy") + " ] ";
            tr1.Cells.Add(cell1);

            TableRow tr2 = new TableRow();
            TableCell cell2 = new TableCell();
            cell2.Controls.Add(GridView1);
            tr2.Cells.Add(cell2);


            tb.Rows.Add(tr1);
            tb.Rows.Add(tr2);
            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = ExcelFile.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }
    }
}