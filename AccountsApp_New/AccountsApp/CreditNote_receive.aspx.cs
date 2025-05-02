using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AccountsApp
{
    public partial class CreditNote_receive : System.Web.UI.Page
    {
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                    Response.Redirect("Login.aspx");
                }

            }
        }
        protected void viewreport(object sender, EventArgs e)
        {
            DataSet dsView1 = objService.Accounts_PR_Status_transfer_select(txtfrmdate.Text, txttodate.Text);
            if (dsView1.Tables[0].Rows.Count > 0)//DataSet dsView = objService.Debit_Credit_note_Report(txtfrmdate.Text, txttodate.Text, "0", "1");
                Gridview1.DataSource = dsView1;
            Gridview1.DataBind();
        }

        protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gridview1.EditIndex = -1;
            DataTable dtt = new DataTable();
            dtt = objService.Accounts_PR_Status_transfer_select(txtfrmdate.Text, txttodate.Text).Tables[0];
            Gridview1.DataSource = dtt;
            Gridview1.DataBind();
        }

        protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridview1.EditIndex = e.NewEditIndex;
            DataTable dtt = new DataTable();
            dtt = objService.Accounts_PR_Status_transfer_select(txtfrmdate.Text, txttodate.Text).Tables[0];
            Gridview1.DataSource = dtt;
            Gridview1.DataBind();
            //set_manhours();
        }

        protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string cr_no = ((Label)Gridview1.Rows[e.RowIndex].FindControl("Label2")).Text;
            int received = Convert.ToInt32(((CheckBox)Gridview1.Rows[e.RowIndex].FindControl("CheckBox3")).Checked);
            string user_id = Session["userid"].ToString();
            int result = objService.Update_AccountsPRStatus_receive(cr_no, received, user_id);
            if (result == 1)
            {
                Gridview1.EditIndex = -1;
                DataTable dtt = new DataTable();
                dtt = objService.Accounts_PR_Status_transfer_select(txtfrmdate.Text, txttodate.Text).Tables[0];
                Gridview1.DataSource = dtt;
                Gridview1.DataBind();
            }
        }

    }
}