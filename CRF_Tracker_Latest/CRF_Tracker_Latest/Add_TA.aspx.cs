using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

namespace CRF_Tracker_Latest
{
    public partial class Add_TA : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRFTrackerSoapClient objService = new ServiceReference1.WebService_CRFTrackerSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null)
                {
                    Response.Redirect("signin.aspx");
                }
                bindddlcrf();
                Panel1.Visible = false;
            }
        }
        private void bindddlcrf()
        {
            DataTable dt = new DataTable();
            dt = objService.Get_Crf_forTA().Tables[0];
            ddl_crf.DataSource = dt;
            ddl_crf.DataTextField = "crf_name";
            ddl_crf.DataValueField = "crf_id";
            ddl_crf.DataBind();
            ddl_crf.Items.Insert(0, new ListItem("---Select---", "0"));
        }
        protected void ddlcrf_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objService.Get_CrfDtls(ddl_crf.SelectedValue).Tables[0];
            if (dt.Rows.Count > 0)
            {
                Panel1.Visible = true;
                label2.Text = dt.Rows[0]["crf_description"].ToString();
                Label4.Text = dt.Rows[0]["requestor_name"].ToString();
                Load_ta();
            }

        }
        private void Load_ta()
        {
            DataTable dtt = new DataTable();
            dtt = objService.Get_ta(ddl_crf.SelectedValue).Tables[0];
            if (dtt.Rows.Count > 0)
            {
                GridView1.DataSource = dtt;
                GridView1.DataBind();
            }
            else
            {
                dtt.Rows.Add(dtt.NewRow());
                GridView1.DataSource = dtt;
                GridView1.DataBind();
                int TotalColumns = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = TotalColumns;
                GridView1.Rows[0].Cells[0].Text = "No Record Found";

            }

            DataTable dt3 = new DataTable();
            dt3 = objService.Get_CrfDtls(ddl_crf.SelectedValue).Tables[0];
            txt_devenddate.Visible = true; txt_startdate.Visible = true;
            txt_trgdate.Visible = true; txt_ttlmanhours.Visible = true;
            txt_devenddate.Text = dt3.Rows[0]["dev_enddate"].ToString();
            txt_startdate.Text = dt3.Rows[0]["dev_startdate"].ToString();
            txt_trgdate.Text = dt3.Rows[0]["target_date"].ToString();
            txt_ttlmanhours.Text = dt3.Rows[0]["manhours"].ToString();
            txt_qastart.Text = dt3.Rows[0]["qa_startdate"].ToString();
            txt_qaend.Text = dt3.Rows[0]["qa_enddate"].ToString();
        }

        protected void Btncrfdoc_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objService.Get_CrfDtls(ddl_crf.SelectedValue).Tables[0];
            string docpath = dt.Rows[0]["reference_doc"].ToString();
            Response.Redirect(docpath);
        }
        public void set_manhours()
        {
            int man_hours = 0;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((Label)GridView1.Rows[i].FindControl("Label3")).Text != string.Empty)
                    man_hours = man_hours + Convert.ToInt32(((Label)GridView1.Rows[i].FindControl("Label3")).Text);
            }

            txt_ttlmanhours.Text = man_hours.ToString();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            DataTable contactTypes = objService.Get_developers().Tables[0];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblType = (Label)e.Row.FindControl("lblType");
                //if (lblType != null)
                //{
                //    int typeId = Convert.ToInt32(lblType.Text);
                //    lblType.Text = (string)contactType.GetTypeById(typeId);
                //}
                DropDownList cmbdev = (DropDownList)e.Row.FindControl("developer");
                if (cmbdev != null)
                {
                    cmbdev.DataSource = contactTypes;
                    cmbdev.DataTextField = "log_user";
                    cmbdev.DataValueField = "developer";
                    cmbdev.DataBind();
                    cmbdev.SelectedValue = GridView1.DataKeys[e.Row.RowIndex].Values[0].ToString();
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList cmbdev = (DropDownList)e.Row.FindControl("developer");
                cmbdev.DataSource = contactTypes;
                cmbdev.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            DataTable dtt = new DataTable();
            dtt = objService.Get_ta(ddl_crf.SelectedValue).Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            DataTable dtt = new DataTable();
            dtt = objService.Get_ta(ddl_crf.SelectedValue).Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();
            set_manhours();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool flag = false;
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string s = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlphase")).Text;
            int result = objService.Update_TA(id, ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlphase")).Text, ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox1")).Text.Replace("'", "''"), ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox3")).Text.Replace("'", "''"), ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox4")).Text.Replace("'", "''"), ((TextBox)GridView1.Rows[e.RowIndex].FindControl("Textbox5")).Text.Replace("'", "''"), ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("developer")).SelectedValue);
            GridView1.EditIndex = -1;
            DataTable dtt = new DataTable();
            dtt = objService.Get_ta(ddl_crf.SelectedValue).Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();
            set_manhours();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0].ToString());
            int result = objService.Delete_TA(id);
            DataTable dtt = new DataTable();
            dtt = objService.Get_ta(ddl_crf.SelectedValue).Tables[0];
            GridView1.DataSource = dtt;
            GridView1.DataBind();
            set_manhours();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                string a = ddl_crf.SelectedValue.ToString(); string b = ((DropDownList)GridView1.FooterRow.FindControl("ddlphase")).Text; string c = ((TextBox)GridView1.FooterRow.FindControl("Textbox1")).Text.Replace("'", "''");
                string d = ((TextBox)GridView1.FooterRow.FindControl("Textbox3")).Text.Replace("'", "''") + ((TextBox)GridView1.FooterRow.FindControl("Textbox4")).Text.Replace("'", "''") + ((TextBox)GridView1.FooterRow.FindControl("Textbox5")).Text.Replace("'", "''") + ((DropDownList)GridView1.FooterRow.FindControl("developer")).SelectedValue;
                int result = objService.Insert_ta(ddl_crf.SelectedValue, ((DropDownList)GridView1.FooterRow.FindControl("ddlphase")).Text, ((TextBox)GridView1.FooterRow.FindControl("Textbox1")).Text.Replace("'", "''"), ((TextBox)GridView1.FooterRow.FindControl("Textbox3")).Text.Replace("'", "''"), ((TextBox)GridView1.FooterRow.FindControl("Textbox4")).Text.Replace("'", "''"), ((TextBox)GridView1.FooterRow.FindControl("Textbox5")).Text.Replace("'", "''"), ((DropDownList)GridView1.FooterRow.FindControl("developer")).SelectedValue);
                if (result > 0)
                {
                    //txt_devenddate.Text = dtEnddate.Rows[0]["end_date"].ToString();
                    DataTable dtt = new DataTable();
                    dtt = objService.Get_ta(ddl_crf.SelectedValue).Tables[0];
                    GridView1.DataSource = dtt;
                    GridView1.DataBind();
                    set_manhours();

                    objService.Update_CRFwithTA(ddl_crf.SelectedValue, txt_startdate.Text, txt_devenddate.Text, txt_trgdate.Text, txt_ttlmanhours.Text, txt_qastart.Text, txt_qaend.Text);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int result = objService.Update_CRFwithTA(ddl_crf.SelectedValue, txt_startdate.Text, txt_devenddate.Text, txt_trgdate.Text, txt_ttlmanhours.Text, txt_qastart.Text, txt_qaend.Text);
            Response.Write("<script>alert('TA Added Successfully...!!')</script>");
        }

    }
}