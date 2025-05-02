using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class AmbienceRegister : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Ambience(0);
            }
        }
        
        public void Load_Ambience(int amb_id)
        {
            DataSet dsAmb = objService.Select_Ambience(amb_id);
            if (dsAmb.Tables[0].Rows.Count > 0)
            {
                Grid_Ambience.DataSource = dsAmb.Tables[0];
                Grid_Ambience.DataBind();
            }
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void Grid_Ambience_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //txtItem.Text = Convert.ToString(e.CommandArgument.ToString());
                Session.Add("Amb_Id", e.CommandArgument.ToString());
                DataSet Ds = objService.Select_Ambience(Convert.ToInt32(Session["Amb_Id"]));
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    txtItem.Text = Ds.Tables[0].Rows[0]["amb_name"].ToString();
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Session.Add("Amb_Id", null);
            txtItem.Text = "";
        }

        protected void BtnSubmit_Click1(object sender, EventArgs e)
        {
            try
            {
                if (txtItem.Text != "")
                {
                    int result = 0;
                    if (Session["Amb_Id"] == null)
                        result = objService.Ambience_InsertUpdate(0, txtItem.Text);
                    else result = objService.Ambience_InsertUpdate(Convert.ToInt32(Session["Amb_Id"].ToString()), txtItem.Text);
                    if (result == 1)
                    {
                        Response.Write("<script>alert('Operation successfully done');</script>");
                        txtItem.Text = "";
                        Load_Ambience(0);
                        Session.Add("Amb_Id", null);
                    }
                    else
                    {
                        Response.Write("<script>alert('Exception Occurs');</script>");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}