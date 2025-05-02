using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class NABL_Accreditatn_Reg : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objseervice = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_branch();
                Load_NABL();
            }
        }
        public void Load_branch()
        {
            DataTable dtbranch = objseervice.Select_Macare_Labs().Tables[0];
            if(dtbranch.Rows.Count>0)
            {
                cmbBranch.DataSource = dtbranch;
                cmbBranch.DataBind();
                cmbBranch.DataTextField = "branch_name";
                cmbBranch.DataValueField = "branch_id";
            }
        }
        public void Load_NABL()
        {
            DataSet ds = objseervice.Select_NABL();
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    Grid_Ambience.DataSource = dt;
                    Grid_Ambience.DataBind();
                }
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dtend = Convert.ToDateTime(txt_issuedate.Text).AddYears(2);
            
            DateTime dtremind = dtend.AddMonths(-6);
            int result = objseervice.NABL_Renew_InsertUpdate(Convert.ToInt32(cmbBranch.SelectedValue), txt_issuedate.Text, dtend.Date.ToString(), dtremind.Date.ToString());
            if (result==1)
            {
                Load_NABL();
            }
        }
    }
}