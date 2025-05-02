using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.IO;

namespace CRM_Application
{
    public partial class Doctor_Availability : System.Web.UI.Page
    {
        ServiceReference1.WebService_CRMSoapClient objservice = new ServiceReference1.WebService_CRMSoapClient();
        public string booking_id = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            CalendarExtender1.StartDate = DateTime.Now;
            if(Request.QueryString.Count != 0)
            {
                booking_id = Request.QueryString["bookingid"].ToString();
            }           
            if (!IsPostBack)
            {
                bindddlbranch();
                bindddldept();
                div_booking.Visible = false;
                Label_requiredname.Visible = false;
                Label_requiredphone.Visible = false;
                if(booking_id!="0")
                {
                    DataTable dt = new DataTable();
                    dt = objservice.Get_BookingDtlstoreschedule(Convert.ToInt32(booking_id)).Tables[0];
                    if(dt.Rows.Count>0)
                    {
                        Text_date.Text= dt.Rows[0]["booking_date"].ToString();
                        Ddl_branch.SelectedValue= dt.Rows[0]["branch_id"].ToString();
                        Ddl_dept.SelectedValue= dt.Rows[0]["dept_id"].ToString();
                        Text_patientname.Text= dt.Rows[0]["patient_name"].ToString();
                        Text_phone.Text = dt.Rows[0]["phone"].ToString();
                        Text_patientname.ReadOnly = true;
                        Text_phone.ReadOnly = true;
                        DataTable dt2 = new DataTable();
                        DataTable dt1 = new DataTable();
                        dt2 = objservice.Get_Doctorattendance_avail(Text_date.Text).Tables[0];
                        if(dt2.Rows.Count>0)
                        {
                            dt1 = objservice.Get_Doctor_availabilityattend(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                            if (dt1.Rows.Count > 0)
                            {
                                GridView1.DataSource = dt1;
                                GridView1.DataBind();
                            }
                        }
                        else
                        {
                            dt1 = objservice.Get_Doctor_availability(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                            if (dt1.Rows.Count > 0)
                            {
                                GridView1.DataSource = dt1;
                                GridView1.DataBind();
                            }
                        }
                        
                    }
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

        protected void ChangeDate_Event(object sender, EventArgs e)
        {
            div_booking.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dt1 = objservice.Get_Doctorattendance_avail(Text_date.Text).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                dt = objservice.Get_Doctor_availabilityattend(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            else
            {
                dt = objservice.Get_Doctor_availability(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }               
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            div_booking.Visible = false;
            GridView1.DataSource = null;
            GridView1.DataBind();
            DataTable dt1 = new DataTable();
            DataTable dt = new DataTable();
            dt1 = objservice.Get_Doctorattendance_avail(Text_date.Text).Tables[0];
            if (dt1.Rows.Count > 0)
            {
                dt = objservice.Get_Doctor_availabilityattend(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
            else
            {
                dt = objservice.Get_Doctor_availability(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "booknow")
            {
                div_booking.Visible = true;
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                Label_drid.Text = (row.FindControl("lbl_drid") as Label).Text;

                Text_tocken.Text = (Convert.ToInt32((row.FindControl("lbl_bookinno") as Label).Text) + 1).ToString();
                Text_doctor.Text = (row.FindControl("lbl_drname") as Label).Text;
                Text_time.Text= (row.FindControl("lbl_time") as Label).Text;

                //DataTable dt = new DataTable();
                //dt = objservice.View_attachment(ta_id).Tables[0];
                //string docpath = dt.Rows[0]["ticket_file"].ToString();
            }
        }

        protected void Submit_click(object sender, EventArgs e)
        {
            if(booking_id!="0")
            {
                objservice.Insert_RescheduledBooking(Convert.ToInt32(booking_id),Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Convert.ToInt32(Label_drid.Text), Text_date.Text, Text_time.Text, Text_patientname.Text, Text_phone.Text, Text_tocken.Text, Session["USERID"].ToString(), "Booked");
                Response.Redirect("Booking_Confirmation.aspx?bookingid=" + booking_id);
            }
            else if(Text_patientname.Text==null || Text_patientname.Text == "")
            {
                Label_requiredname.Visible = true;
                Label_requiredphone.Visible = false;
            }
            else if(Text_phone.Text==null || Text_phone.Text == "")
            {
                Label_requiredname.Visible = false;
                Label_requiredphone.Visible = true;
            }
            else
            {
                Label_requiredname.Visible = false;
                Label_requiredphone.Visible = false;
                objservice.Insert_NewBooking(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Convert.ToInt32(Label_drid.Text), Text_date.Text, Text_time.Text, Text_patientname.Text, Text_phone.Text, Text_tocken.Text, Session["USERID"].ToString(), "Booked");
                //string strUrl = @"https://api-alerts.kaleyra.com/v4/?api_key=Abd88b2ea9b53fb33eaadddf377595748&method=sms&message= Dear Customer, your appointment with "+Text_doctor.Text+" has been scheduled for "+Text_date.Text+" , please be on time. For any changes , kindly contact us on 1800 309 1555 –Macare&to="+Text_phone.Text+"&sender=MHCALT";
                //div_booking.Visible = false;
                //Text_date.Text = string.Empty;
                Text_patientname.Text = string.Empty;
                Text_phone.Text = string.Empty;
                div_booking.Visible = false;
                Response.Write("<script>alert('Booking Added Successfully')</script>");
                //Text_tocken.Text = string.Empty;
                //Text_doctor.Text = string.Empty;
                //Text_time.Text = string.Empty;
                DataTable dt1 = new DataTable();
                DataTable dt = new DataTable();
                dt1 = objservice.Get_Doctorattendance_avail(Text_date.Text).Tables[0];
                if (dt1.Rows.Count > 0)
                {
                    dt = objservice.Get_Doctor_availabilityattend(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                else
                {
                    dt = objservice.Get_Doctor_availability(Convert.ToInt32(Ddl_branch.SelectedValue), Convert.ToInt32(Ddl_dept.SelectedValue), Text_date.Text).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt;
                        GridView1.DataBind();
                    }
                }
                //Ddl_branch.ClearSelection();
                //Ddl_dept.ClearSelection();

                //Response.Write("<script>alert('Booking Added Successfully')</script>");
                //GridView1.DataSource = null;
                //GridView1.DataBind();
                //try
                //{
                //    // Create a request object  
                //    WebRequest request = HttpWebRequest.Create(strUrl);
                //    // Get the response back  
                //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    Stream s = (Stream)response.GetResponseStream();
                //    StreamReader readStream = new StreamReader(s);
                //    string dataString = readStream.ReadToEnd();
                //    response.Close();
                //    s.Close();
                //    readStream.Close();
                //}
                //catch(Exception ex)
                //{

                //}


            }
            
        }
    }
}