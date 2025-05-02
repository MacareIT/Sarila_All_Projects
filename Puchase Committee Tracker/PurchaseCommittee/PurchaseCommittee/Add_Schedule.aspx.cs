using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace PurchaseCommittee
{
    public partial class Add_Schedule : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = new DataTable();
                dt = objservice.Get_pendingquotations().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    div_hide.Visible = true;
                }
                else
                {
                    div_hide.Visible = false;
                }
            }
        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_pendingquotations().Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    if (((CheckBox)gr.Cells[0].FindControl("CheckBox1")).Checked == true)
                    {
                        string venue = txt_venue.Text;
                        venue = venue.Replace("'", "''");

                        objservice.Add_schedule(txt_date.Text,venue, ((Label)gr.Cells[0].FindControl("lbl_itemid")).Text);
                    }
                }
            }
            txt_date.Text = string.Empty;
            txt_venue.Text = string.Empty;
            DataTable dt1 = new DataTable();
            dt1 = objservice.Get_pendingquotations().Tables[0];
            if (dt1.Rows.Count > 0)
            {
                GridView1.DataSource = dt1;
                GridView1.DataBind();
                div_hide.Visible = true;
            }
            else
            {
                div_hide.Visible = false;
            }
            Response.Write("<script>alert('Purchase Committee Scheduled Successfully...!!')</script>");
        }
    }
}