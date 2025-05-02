using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class Camp_Patients : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        static string  patientid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               Session["USERID"] = "12";
                if (Session["USERID"] == null)
                {
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillCampdetails();
            }
        }
        private void fillCampdetails()
        {
            try
            {
                ds = new DataSet();
                ds = objService.Campdetails();
                ddlcamp.DataSource = ds.Tables[0];
                ddlcamp.DataTextField = "campname";
                ddlcamp.DataValueField = "campid";
                ddlcamp.DataBind();
                ddlcamp.Items.Insert(0, new ListItem("---Choose Camp--", "0"));

            }
            catch (Exception ex)
            {

            }
        }
        protected void addpatient(object sender, EventArgs e)
        {
            if (patientid == "0")
            {
                try
                {
                    if(ddlcamp.SelectedIndex>0)
                    {
                    int res = objService.AddCampPatient(ddlcamp.SelectedValue, txtpatientname.Text, txtage.Text, txtphone.Text, ddlbloodgroup.SelectedValue, rblstatus.SelectedValue, txtremark.Text);
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registered sucessfully....');", true);
                        txtpatientname.Text = string.Empty;
                        txtage.Text = string.Empty;
                        txtphone.Text = string.Empty;
                        txtremark.Text = string.Empty;
                        fillPatientDetails(ddlcamp.SelectedValue);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to add patient....');", true);
                    }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Please choose camp....');", true);

                    }

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('unable to add Patient....');", true);
                }
            }
            else
            {
                try
                {
                    int res = objService.UpdateCampPatient(patientid, ddlcamp.SelectedValue, txtpatientname.Text, txtage.Text, txtphone.Text, ddlbloodgroup.SelectedValue, rblstatus.SelectedValue, txtremark.Text);
                    if (res > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Updated sucessfully....');", true);
                        txtpatientname.Text = string.Empty;
                        txtage.Text = string.Empty;
                        txtphone.Text = string.Empty;
                        txtremark.Text = string.Empty;
                        fillPatientDetails(ddlcamp.SelectedValue);
                        patientid = "0";
                    }
                    else
                    {
                        patientid = "0";
                        ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to update record....');", true);
                    }
                }
                catch(Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to update record....');", true);
                    patientid = "0";
                }

            }
          
        }

        private void fillPatientDetails(string campid)
        {
            try
            {
                ds = new DataSet();
                ds = objService.CampPatientdetails_campId(campid,"","");
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
            catch(Exception ex)
            {

            }
           
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            patientid = GridView1.DataKeys[e.NewSelectedIndex].Value.ToString();
            ds = new DataSet();
            ds = objService.CampPatientdetails_ID(patientid);
            txtage.Text = ds.Tables[0].Rows[0]["age"].ToString();
            txtpatientname.Text= ds.Tables[0].Rows[0]["name"].ToString();
            txtphone.Text= ds.Tables[0].Rows[0]["phone"].ToString();
            txtremark.Text= ds.Tables[0].Rows[0]["remark"].ToString();
        }

        protected void ddlcamp_SelectedIndexChanged(object sender, EventArgs e)
        {
            patientid = "0";
            fillPatientDetails(ddlcamp.SelectedValue);
        }
    }
}