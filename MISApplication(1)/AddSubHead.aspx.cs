using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AddSubHead : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillhead();
                filldepartment();

            }
        }
        private void filldepartment()
        {
            ds = new DataSet();
            ds = objService.Listdepartment();
            ddl_subhead.DataSource = ds.Tables[0];
            ddl_subhead.DataTextField = "dep_name";
            ddl_subhead.DataValueField = "dep_id";
            ddl_subhead.DataBind();
            ddl_subhead.Items.Insert(0, new ListItem("---Choose Subhead--", "0"));
        }
        private void fillhead()
        {
            ds = new DataSet();
            ds = objService.ListIncentiveHead();
            ddl_incentivehead.DataSource = ds.Tables[0];
            ddl_incentivehead.DataTextField = "incentivehead";
            ddl_incentivehead.DataValueField = "id";
            ddl_incentivehead.DataBind();
            ddl_incentivehead.Items.Insert(0, new ListItem("---Choose Head--", "0"));
        }

        protected void addincentivesubhead(object sender, EventArgs e)
        {
            try
            {
                int res = objService.AddincentiveSubHead(ddl_incentivehead.SelectedValue, ddl_subhead.SelectedItem.Text);
                if (res > 0)
                {
                    fillgrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to add head....');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('unable to add head....');", true);
            }
        }
        private void fillgrid()
        {
            try
            {
                ds = new DataSet();
                ds = objService.ListIncentiveSubHead(ddl_incentivehead.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data not found!!!!');", true);
            }

        }

        protected void ddl_incentivehead_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillgrid();
        }
    }
}