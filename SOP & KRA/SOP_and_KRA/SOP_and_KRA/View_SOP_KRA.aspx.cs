using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SOP_and_KRA
{
    public partial class View_SOP_KRA : System.Web.UI.Page
    {
        ServiceReference1.Service_SOPandKRASoapClient objservice = new ServiceReference1.Service_SOPandKRASoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddldept();
            }
        }

        private void bindddldept()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_dapartment().Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "dep_name";
            ddl_dept.DataValueField = "dep_name";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_registerddesignation(ddl_dept.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "sop_view")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string sopkra_id = (row.FindControl("lbl_sopkraid") as Label).Text;

                DataTable dt = new DataTable();
                dt = objservice.Get_registerdsopkra(sopkra_id).Tables[0];
                string docpath = dt.Rows[0]["sop_doc"].ToString();
                Response.Redirect(docpath);
            }
            else if (e.CommandName == "kra_view")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string sopkra_id = (row.FindControl("lbl_sopkraid") as Label).Text;

                DataTable dt = new DataTable();
                dt = objservice.Get_registerdsopkra(sopkra_id).Tables[0];
                string docpath = dt.Rows[0]["kra_doc"].ToString();
                Response.Redirect(docpath);
            }
        }
    }
}