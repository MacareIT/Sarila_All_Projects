using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PurchaseCommittee
{
    public partial class View_Quotation : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string item_id = Request.QueryString["item_id"].ToString();
                DataSet ds = new DataSet();
                ds = objservice.View_Quotations(item_id);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "quotation_view")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string item_id = (row.FindControl("lbl_quotationid") as Label).Text;

                DataTable dt = new DataTable();
                dt = objservice.View_IndividualQuotations(item_id).Tables[0];
                byte[] bytes;
                string fileName, contentType;
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["filename"].ToString() == "")
                    {
                        Response.Write("<script>alert('No file Uploaded')</script>");
                    }
                    else
                    {
                        fileName = dt.Rows[0]["filename"].ToString();
                        contentType = dt.Rows[0]["content_type"].ToString();
                        bytes = (byte[])dt.Rows[0]["attachment"];

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
                }
                else
                {
                    Response.Write("<script>alert('No file Uploaded')</script>");
                }
            }
        }
    }
}