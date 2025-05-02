using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRF_Tracker_Latest
{
    public partial class CRF_Report : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objService = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dsCRF = objService.Get_CrfDtls("0").Tables[0];
                if(dsCRF.Rows.Count>0)
                {
                    int count = 0;
                    count = dsCRF.AsEnumerable().Count(row => (row.Field<string>("crf_status") == "Development Started" && row.Field<string>("head_remarks") == "In Progress") || (row.Field<string>("crf_status") == "Development Completed" && row.Field<string>("head_remarks") == "In Progress")
                                                            ||(row.Field<string>("crf_status") == "QA Started" && row.Field<string>("head_remarks") == "In Progress") || (row.Field<string>("crf_status") == "QA Completed" && row.Field<string>("head_remarks") == "In Progress") 
                                                            ||(row.Field<string>("crf_status") == "UAT Confirmed" && row.Field<string>("head_remarks") == "In Progress") ||(row.Field<string>("crf_status") == "UAT Completed" && row.Field<string>("head_remarks") == "In Progress") 
                                                            ||(row.Field<string>("crf_status") == "UAT Started" && row.Field<string>("head_remarks") == "In Progress") || (row.Field<string>("crf_status") == "Live" && row.Field<string>("head_remarks") == "In Progress"));
                    lblPrgs.Text = count.ToString();

                    count = dsCRF.AsEnumerable().Count(row => row.Field<string>("crf_status") == "User Confirmed");
                    lbllive.Text = count.ToString();

                    count = dsCRF.AsEnumerable().Count(row => row.Field<string>("head_remarks") == "Delayed" && row.Field<string>("crf_status") != "User Confirmed");
                    lbldelay.Text = count.ToString();

                    count = dsCRF.AsEnumerable().Count(row => row.Field<string>("crf_status") == "TA Completed");
                    lblTA.Text = count.ToString();
                }
                btn_qadoc.Visible = false;
            }
        }

        protected void Btnqadoc_Click(object sender, EventArgs e)
        {
            Table tb = new Table();
            TableRow tr1 = new TableRow();
            TableCell cell1 = new TableCell();
            cell1.Text = "Internal CRF Status ";
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
            cell4.Controls.Add(GridView1);
            tr4.Cells.Add(cell4);
           
            tb.Rows.Add(tr1);
            tb.Rows.Add(tr2);
            tb.Rows.Add(tr3);
            tb.Rows.Add(tr4);

            Response.ContentType = "application/x-msexcel";
            Response.AddHeader("Content-Disposition", "attachment;filename = CRFFile.xls");
            Response.ContentEncoding = Encoding.UTF8;
            StringWriter tw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(tw);
            tb.RenderControl(hw);
            Response.Write(tw.ToString());
            Response.End();
        }

        protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_type.SelectedValue == "---Select---")
            { }
            else
            {
                DataTable dt = objService.Get_CRFreport(ddl_type.SelectedValue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    btn_qadoc.Visible = true;
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    btn_qadoc.Visible = false;
                }
            }
        }
    }
}