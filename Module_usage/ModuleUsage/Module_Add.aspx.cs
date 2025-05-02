using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ModuleUsage
{
    public partial class Module_Add : System.Web.UI.Page
    {
        ServiceReference1.WebService_ModuleUsageSoapClient objService = new ServiceReference1.WebService_ModuleUsageSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Session["Username"] = "150739";
                Load_dept();
                Load_Module();
            }
        }
        public void Load_dept()
        {
            DataTable dtModule = objService.Dept_Select().Tables[0];
            if (dtModule.Rows.Count > 0)
            {
                Ddl_dept.DataSource = dtModule;
                Ddl_dept.DataBind();
            }
        }
        public void Load_Module()
        {
            DataTable dtModule = objService.Modules_Select().Tables[0];
            if (dtModule.Rows.Count > 0)
            {
                GridView1.DataSource = dtModule;
                GridView1.DataBind();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            string Module = GridView1.DataKeys[rowIndex].Values[0].ToString();
            //string module = GridView1.DataKeys[((LinkButton)GridView1.FindControl("LinkButton1")).RowIndex].Value.ToString();
            int result = objService.delete_Module(Module);
            if (result > 0)
                Load_Module();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int result = objService.Module_InsertUpdate(Convert.ToInt32(Ddl_dept.SelectedValue), txtModule.Text, txtPath.Text, Session["Username"].ToString());
            if (result > 0)
            {
                txtModule.Text = string.Empty;txtPath.Text = string.Empty;
                Load_Module();
            }
        }
    }
}