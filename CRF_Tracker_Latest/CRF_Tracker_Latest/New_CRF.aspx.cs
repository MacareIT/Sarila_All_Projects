using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace CRF_Tracker_Latest
{
    public partial class New_CRF : System.Web.UI.Page
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
                else
                {
                    if(Session["USERTYPE"].ToString()== "techlead" || Session["USERTYPE"].ToString() == "itcoordinator"|| Session["USERTYPE"].ToString() == "developer")
                    {
                        appear.Visible = true;
                        Load_designtn();Load_users();
                    }
                    else
                    {
                        appear.Visible = false;
                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); int result = 0;
            ds = objService.Get_CrfId();
            string Crfid = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~/reference_doc/" + Crfid + filename));
            if(appear.Visible==true)
            {
                result = objService.Insert_NewCrf(Crfid, txt_crfname.Text.Replace("'", "''"), txt_description.Text.Replace("'", "''"), ddl_reqtype.SelectedValue, radio_priority.SelectedValue, txt_scope.Text.Replace("'", "''"), "~/reference_doc/" + Crfid + filename, ddl_emp.SelectedValue.ToString(), ddl_emp.SelectedItem.ToString(), ddl_dept.SelectedValue + " Requested", ddl_dept.SelectedItem.ToString());
            }
            else result = objService.Insert_NewCrf(Crfid, txt_crfname.Text.Replace("'", "''"), txt_description.Text.Replace("'", "''"), ddl_reqtype.SelectedValue, radio_priority.SelectedValue, txt_scope.Text.Replace("'", "''"), "~/reference_doc/" + Crfid + filename, Session["USERID"].ToString(), Session["LOGUSER"].ToString(), Session["USERTYPE"].ToString() + " Requested",Session["DESIGNATION"].ToString());
            if (result == 1)
            {
                Response.Write("<script>alert('CRF Added Successfully...!!')</script>");
                txt_crfname.Text = string.Empty;
                txt_description.Text = string.Empty;
                txt_scope.Text = string.Empty;
                ddl_reqtype.ClearSelection();
                radio_priority.ClearSelection();
            }
        }

        public void Load_designtn()
        {
            DataSet ds = new DataSet();
            ds = objService.Get_designation();
            if(ds.Tables[0].Rows.Count>0)
            {
                ddl_dept.DataSource = ds.Tables[0];
                ddl_dept.DataTextField = "designation";
                ddl_dept.DataValueField = "type";
                ddl_dept.DataBind();
               
            }
        }

        public void Load_users()
        {
            DataSet ds = new DataSet();
            ds = objService.Get_users(ddl_dept.SelectedItem.ToString());
            if(ds.Tables[0].Rows.Count>0)
            {
                ddl_emp.DataSource = ds.Tables[0];
                ddl_emp.DataTextField = "log_user";
                ddl_emp.DataValueField = "username";
                ddl_emp.DataBind();
            }
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_users();
        }
    }
}