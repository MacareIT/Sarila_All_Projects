using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRM_Application
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddlbranch();
                bindddldept();
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

        private void bindddldept()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Department().Tables[0];
            Ddl_dept.DataSource = dt;
            Ddl_dept.DataTextField = "dept_name";
            Ddl_dept.DataValueField = "dept_id";
            Ddl_dept.DataBind();
            Ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddldoctor()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Doctor(Convert.ToInt32(Ddl_branch.SelectedValue),Convert.ToInt32(Ddl_dept.SelectedValue),Text_date.Text).Tables[0];
            Ddl_doctor.DataSource = dt;
            Ddl_doctor.DataTextField = "dr_name";
            Ddl_doctor.DataValueField = "dr_id";
            Ddl_doctor.DataBind();
            Ddl_doctor.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddltime()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_VisitTime(Convert.ToInt32(Ddl_branch.SelectedValue),Convert.ToInt32(Ddl_dept.SelectedValue),Convert.ToInt32(Ddl_doctor.SelectedValue),Text_date.Text).Tables[0];
            Ddl_visitingtime.DataSource = dt;
            Ddl_visitingtime.DataTextField = "time_";
            Ddl_visitingtime.DataValueField = "time_";
            Ddl_visitingtime.DataBind();
            Ddl_visitingtime.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ChangeDate_Event(object sender, EventArgs e)
        {
            bindddldoctor();
            if(Ddl_branch.Items==null || Ddl_dept.Items==null || Ddl_doctor.Items==null)
            {

            }
            else
            {
                bindddltime();
            }           
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindddldoctor();
        }

        protected void ddl_dr_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_NextToken(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text).Tables[0];
            Text_tocken.Text = dt.Rows[0].ItemArray[0].ToString();
            bindddltime();
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            objservice.Insert_NewBooking(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Convert.ToInt32(Ddl_doctor.SelectedValue), Text_date.Text, Ddl_visitingtime.SelectedValue, Text_patientname.Text, Text_phone.Text, Text_tocken.Text, "151639", "Booked");
            Response.Write("<script>alert('Booking Confirmed Successfully')</script>");
            Ddl_branch.ClearSelection();
            Ddl_dept.ClearSelection();
            Ddl_doctor.Items.Clear();
            Ddl_visitingtime.Items.Clear();
            Text_date.Text = string.Empty;
            Text_patientname.Text = string.Empty;
            Text_phone.Text = string.Empty;
            Text_tocken.Text = string.Empty;
        }
    }
}