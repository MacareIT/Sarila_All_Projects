using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class Change_Pswd : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                txtUname.Text = dt.Rows[0]["username"].ToString();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUname.Text == " " || txtOld.Text == " " || txtNew.Text == " " || txtConfirm.Text == " ")
            {
                Response.Write("<script>alert('');</script>");
            }
            else
            if (txtNew.Text == txtConfirm.Text)
            {
                int result = objService.Change_Pswd(txtUname.Text, txtOld.Text, txtNew.Text);
                if (result == 1)
                {
                    Response.Write("<script>alert('Password changed successfully');</script>");
                    txtOld.Text = "";
                    txtNew.Text = "";
                    txtConfirm.Text = "";
                    lblValidtn.Visible = false;
                }
                else
                {
                    Response.Write("<script>alert('Enter Correct values');</script>");
                    lblValidtn.Visible = false;
                }
            }
            else
            {
                lblValidtn.Visible = true;
            }
        }
    }
}