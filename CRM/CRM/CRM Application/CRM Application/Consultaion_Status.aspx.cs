using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRM_Application
{
    public partial class Consultaion_Status : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //bindddldept();
                bindddldoctor();
            }
            //Btn_submit.Visible = false;
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            bindddldoctor();
        }

        protected void ChangeDate_Event(object sender, EventArgs e)
        {
            bindddldoctor();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void ddl_dr_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            DataTable dt = new DataTable();
            string branch_id = Session["BRANCHID"].ToString();
            dt = objservice.Get_BookingDtls_forconsultationstatus(Convert.ToInt32( Session["BRANCHID"]), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
            //dt = objservice.Get_BookingDtls_forconsultationstatus(1256, Convert.ToInt32(Ddl_dept.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                //Btn_submit.Visible = true;
            }
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
            dt = objservice.Get_Doctor_departmentforconfirmation(Convert.ToInt32(Session["BRANCHID"]), Text_date.Text).Tables[0];
            //dt = objservice.Get_Doctor_availability(1256, Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataTextField = "doctor_name";
            Ddl_doctor.DataValueField = "dr_id";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            foreach (GridViewRow gr in GridView1.Rows)
            {
                if (((CheckBox)gr.Cells[0].FindControl("CheckBox1")).Checked == true)
                {
                    string booking_id = ((Label)gr.Cells[0].FindControl("lbl_bookingid")).Text;
                    string a = booking_id;
                    objservice.Update_BookingStatus_Arrived(Convert.ToInt32(((Label)gr.Cells[0].FindControl("lbl_bookingid")).Text),"Arrived");                   
                }
                else
                {
                    objservice.Update_BookingStatus_Arrived(Convert.ToInt32(((Label)gr.Cells[0].FindControl("lbl_bookingid")).Text), "Confirmed");
                }
            }
            Response.Write("<script>alert('Booking Status Updated Successfully')</script>");
        }
    }
}