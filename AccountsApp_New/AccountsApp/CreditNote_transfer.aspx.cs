using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AccountsApp
{
    public partial class CreditNote_transfer : System.Web.UI.Page
    {
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "150739";
                if (Session["USERID"] == null)
                {
                    //Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                    Response.Redirect("Login.aspx");
                }

            }
        }
        protected void viewreport(object sender, EventArgs e)
        {
            DataSet dsView1 = objService.Accounts_PR_Status_select(txtfrmdate.Text, txttodate.Text);
            if (dsView1.Tables[0].Rows.Count > 0)
            {
                Gridview1.DataSource = dsView1;
                Gridview1.DataBind();
            }
            else
            {
                Gridview1.DataSource = null;
                Gridview1.DataBind();
            }
        }

        protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gridview1.EditIndex = -1;
            DataTable dtt = new DataTable();
            dtt = objService.Accounts_PR_Status_select(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtt.Rows.Count > 0)
            {
                Gridview1.DataSource = dtt;
                Gridview1.DataBind();
            }
            else
            {
                Gridview1.DataSource = null;
                Gridview1.DataBind();
            }
        }

        protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridview1.EditIndex = e.NewEditIndex;
            DataTable dtt = new DataTable();
            dtt = objService.Accounts_PR_Status_select(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtt.Rows.Count > 0)
            {
                Gridview1.DataSource = dtt;
                Gridview1.DataBind();
            }
            else
            {
                Gridview1.DataSource = null;
                Gridview1.DataBind();
                //set_manhours();
            }
        }
        protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string cr_no = ((Label)Gridview1.Rows[e.RowIndex].FindControl("Label2")).Text;
            int recieved = Convert.ToInt32(((CheckBox)Gridview1.Rows[e.RowIndex].FindControl("CheckBox4")).Checked);
            if (recieved == 1)
            {
                //Response.Write("<script>alert('Can't Edit Status')</script>");
                Gridview1.EditIndex = -1;
                DataTable dtt = new DataTable();
                dtt = objService.Accounts_PR_Status_select(txtfrmdate.Text, txttodate.Text).Tables[0];
                if (dtt.Rows.Count > 0)
                {
                    Gridview1.DataSource = dtt;
                    Gridview1.DataBind();
                }
                else
                {
                    Gridview1.DataSource = null;
                    Gridview1.DataBind();
                }
            }
            else
            {

                if (Convert.ToInt32(((CheckBox)Gridview1.Rows[e.RowIndex].FindControl("CheckBox3")).Checked) == 1)
                {
                    string user_id = Session["userid"].ToString();
                    int result1 = objService.Delete_AccountsPRStatus(cr_no);
                    int result = objService.Add_AccountsPRStatus(cr_no, 1, user_id);
                    if (result == 1)
                    {
                        Gridview1.EditIndex = -1;
                        DataTable dtt = new DataTable();
                        int tranfered = Convert.ToInt32(((CheckBox)Gridview1.Rows[e.RowIndex].FindControl("CheckBox3")).Checked);
                        dtt = objService.Accounts_PR_Status_select(txtfrmdate.Text, txttodate.Text).Tables[0];
                        if (dtt.Rows.Count > 0)
                        {
                            Gridview1.DataSource = dtt;
                            Gridview1.DataBind();
                        }
                        else
                        {
                            Gridview1.DataSource = null;
                            Gridview1.DataBind();
                        }
                    }
                }
                else
                {
                    DataTable dtt = new DataTable();
                    int result2 = objService.Delete_AccountsPRStatus(cr_no);
                    Gridview1.EditIndex = -1;
                    dtt = objService.Accounts_PR_Status_select(txtfrmdate.Text, txttodate.Text).Tables[0];
                    if (dtt.Rows.Count > 0)
                    {
                        Gridview1.DataSource = dtt;
                        Gridview1.DataBind();
                    }
                    else
                    {
                        Gridview1.DataSource = null;
                        Gridview1.DataBind();
                    }
                }
                
            }
        }
    }
}