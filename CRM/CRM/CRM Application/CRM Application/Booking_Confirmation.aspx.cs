using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRM_Application
{
    public partial class Booking_Confirmation : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        public string booking_id = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request.QueryString.Count != 0)
                {
                    //bindddldept();
                    bindddlbranch();
                    
                    booking_id = Request.QueryString["bookingid"].ToString();
                    DataTable dt = new DataTable();
                    dt = objservice.Get_BookingDtlstoreschedule(Convert.ToInt32(booking_id)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        Text_date.Text = dt.Rows[0]["booking_date"].ToString();
                        //Ddl_dept.SelectedValue = dt.Rows[0]["dept_id"].ToString();
                        Ddl_branch.SelectedValue = dt.Rows[0]["branch_id"].ToString();
                        bindddldoctor();
                        Ddl_doctor.SelectedValue = dt.Rows[0]["doctor_id"].ToString();
                        
                        GridView1.DataSource = null;
                        GridView1.DataBind();
                        GridView1.Visible = true;
                        DataTable dt1 = new DataTable();
                        dt1 = objservice.Get_BookingDtls_forconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
                        if (dt1.Rows.Count > 0)
                        {
                            GridView1.DataSource = dt1;
                            GridView1.DataBind();
                        }
                    }
                    
                }
                else
                {
                    //bindddldept();
                    bindddlbranch();
                    GridView1.Visible = false;
                }
                
            }
        }

        private void bindddlbranch()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Branch().Tables[0];
            Ddl_branch.DataSource = dt;
            Ddl_branch.DataTextField = "name";
            Ddl_branch.DataValueField = "branch_id";
            Ddl_branch.DataBind();
            Ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        //private void bindddldept()
        //{
        //    DataTable dt = new DataTable();
        //    dt = objservice.Get_Department().Tables[0];
        //    Ddl_dept.DataSource = dt;
        //    Ddl_dept.DataTextField = "dept_name";
        //    Ddl_dept.DataValueField = "dept_id";
        //    Ddl_dept.DataBind();
        //    Ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        //}

        private void bindddldoctor()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctor_departmentforconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue),Text_date.Text).Tables[0];
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataTextField = "doctor_name";
            Ddl_doctor.DataValueField = "dr_id";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {       
            GridView1.Visible = false;
            bindddldoctor();
        }

        protected void ddl_dr_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void ChangeDate_Event(object sender, EventArgs e)
        {
            bindddldoctor();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "confirm")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                //Label_drid.Text = (row.FindControl("lbl_drid") as Label).Text;
                objservice.Update_BookingStatus_Confirm(Convert.ToInt32((row.FindControl("lbl_bookingid") as Label).Text), Session["USERID"].ToString(), "Confirmed");
                DataTable dt = new DataTable();
                dt = objservice.Get_BookingDtls_forconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                Response.Write("<script>alert('Booking Confirmed Successfully')</script>");
            }
            if (e.CommandName == "cancel")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                Label1.Text = (row.FindControl("lbl_bookingid") as Label).Text;
                Text_patientname.Text = (row.FindControl("lbl_patientname") as Label).Text;
                mp1.Show();
                DataTable dt = new DataTable();
                dt = objservice.Get_BookingDtls_forconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            if (e.CommandName == "reschedule")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string bookingid= (row.FindControl("lbl_bookingid") as Label).Text;
                Response.Redirect("Doctor_Availability.aspx?bookingid=" + bookingid );

            }
        }

        protected void View_click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView1.Visible = true;
            DataTable dt = new DataTable();
            dt = objservice.Get_BookingDtls_forconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }

        protected void GridView1_RowUpdating(object sender, GridViewEditEventArgs e)
        {
            // Write here code for edit Rows 
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void Cancelsubmit_click(object sender, EventArgs e)
        {
            objservice.Add_BookingStatus_Cancel(Convert.ToInt32(Label1.Text), Text_reason.Text, Session["USERID"].ToString());
            Label1.Text = string.Empty;
            Text_reason.Text = string.Empty;
            Text_patientname.Text = string.Empty;
            DataTable dt = new DataTable();
            dt = objservice.Get_BookingDtls_forconfirmation(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            Response.Write("<script>alert('Booking Cancelled Successfully')</script>");
        }
    }
}