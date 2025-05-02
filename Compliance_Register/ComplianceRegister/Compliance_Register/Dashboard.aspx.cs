using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Compliance_Register
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ServiceReference1.WebService_Compliance_RegisterSoapClient objservice = new ServiceReference1.WebService_Compliance_RegisterSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int dept_id = 0; Lbl_status.Visible = false;
                //if (Session["USERTYPE"].ToString()=="cs" || Session["USERTYPE"].ToString() == "internalaudit")
                //{
                DataTable dt_dsh = objservice.Select_Compliance_Dashboard(0).Tables[0];
                if (dt_dsh.Rows.Count > 0)
                {
                    GridView1.DataSource = dt_dsh;
                    GridView1.DataBind();
                    Lbl_status.Text = "";
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    Lbl_status.Visible = true;
                    Lbl_status.Text = "No Due!!!";
                    Lbl_status.ForeColor = System.Drawing.Color.Red;
                }
                //}
                //else
                //{
                //    DataTable dt_dept = objservice.Select_Head_dept(Session["USERID"].ToString()).Tables[0];
                //    if (dt_dept.Rows[0][0].ToString() != "")

                //    {
                //        dept_id = Convert.ToInt32(dt_dept.Rows[0][0].ToString());
                //        DataTable dt_dash = objservice.Select_Compliance_Dashboard(dept_id).Tables[0];
                //        if (dt_dash.Rows.Count > 0)
                //        {
                //            GridView1.DataSource = dt_dash;
                //            GridView1.DataBind();
                //            Lbl_status.Text = "";
                //        }
                //        else
                //        {
                //            GridView1.DataSource = null;
                //            GridView1.DataBind();
                //            Lbl_status.Visible = true;
                //            Lbl_status.Text = "No Due!!!";
                //            Lbl_status.ForeColor = System.Drawing.Color.Red;
                //        }    
                //    }
                //    else
                //    {
                //        GridView1.DataSource = null;
                //        GridView1.DataBind();
                //    }
                //}
            }
        }
    }
}