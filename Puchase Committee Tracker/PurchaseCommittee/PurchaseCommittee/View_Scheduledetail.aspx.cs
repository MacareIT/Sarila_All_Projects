using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PurchaseCommittee
{
    public partial class View_Scheduledetail : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            string date = Request.QueryString["date"].ToString();
            string venue = Request.QueryString["venue"].ToString();
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = objservice.View_Details(date,venue).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "quotation_view")
            {

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string item_id = (row.FindControl("lbl_itemid") as Label).Text;

                Response.Redirect("Add_Minutes.aspx?item_id=" + item_id);
            }
        }
    }
}