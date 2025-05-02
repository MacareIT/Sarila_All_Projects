using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace SOP_and_KRA
{
    public partial class Edit_SOP_KRA : System.Web.UI.Page
    {
        ServiceReference1.Service_SOPandKRASoapClient objservice = new ServiceReference1.Service_SOPandKRASoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddldept();
            }
            div_kra.Visible = false;
            div_sop.Visible = false;
        }

        private void bindddldept()
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_dapartment().Tables[0];
            ddl_dept.DataSource = dt2;
            ddl_dept.DataTextField = "dep_name";
            ddl_dept.DataValueField = "dep_name";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            dt2 = objservice.Get_registerddesignation(ddl_dept.SelectedValue).Tables[0];
            ddl_designation.DataSource = dt2;
            ddl_designation.DataTextField = "designation";
            ddl_designation.DataValueField = "sop_kra_id";
            ddl_designation.DataBind();
            ddl_designation.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddl_update.SelectedValue== "Update SOP")
            {
                div_sop.Visible = true;
                div_kra.Visible = false;
            }
            else if(ddl_update.SelectedValue== "Update KRA")
            {
                div_kra.Visible = true;
                div_sop.Visible = false;
            }
            else if (ddl_update.SelectedValue == "Update Both SOP and KRA")
            {
                div_sop.Visible = true;
                div_kra.Visible = true;
            }
            else
            {
                div_kra.Visible = false;
                div_sop.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ddl_update.SelectedValue == "Update SOP")
            {
                DataTable dt = new DataTable();
                dt = objservice.Get_registerdsopkra(ddl_designation.SelectedValue).Tables[0];
                string dfilename_sop = dt.Rows[0]["sop_doc"].ToString();
                string path = Server.MapPath(dfilename_sop);
                FileInfo file = new FileInfo(path);
                file.Delete();
                string sop = "sop";

                string filename_sop = Path.GetFileName(file_sop.PostedFile.FileName);
                file_sop.SaveAs(Server.MapPath("~/Sop/" + ddl_designation.SelectedValue + sop + filename_sop));

                objservice.Update_sop(ddl_designation.SelectedValue, "~/Sop/" + ddl_designation.SelectedValue + sop + filename_sop);
            }
            else if (ddl_update.SelectedValue == "Update KRA")
            {
                DataTable dt = new DataTable();
                dt = objservice.Get_registerdsopkra(ddl_designation.SelectedValue).Tables[0];
                string dfilename_kra = dt.Rows[0]["kra_doc"].ToString();
                string path = Server.MapPath(dfilename_kra);
                FileInfo file = new FileInfo(path);
                file.Delete();
                string kra = "kra";

                string filename_kra = Path.GetFileName(file_kra.PostedFile.FileName);
                file_kra.SaveAs(Server.MapPath("~/Kra/" + ddl_designation.SelectedValue + kra + filename_kra));

                objservice.Update_sop(ddl_designation.SelectedValue, "~/Kra/" + ddl_designation.SelectedValue + kra + filename_kra);
            }
            else if (ddl_update.SelectedValue == "Update Both SOP and KRA")
            {
                DataTable dt = new DataTable();
                dt = objservice.Get_registerdsopkra(ddl_designation.SelectedValue).Tables[0];
                string dfilename_sop = dt.Rows[0]["sop_doc"].ToString();
                string path1 = Server.MapPath(dfilename_sop);
                FileInfo file1 = new FileInfo(path1);
                file1.Delete();

                string dfilename_kra = dt.Rows[0]["kra_doc"].ToString();
                string path2 = Server.MapPath(dfilename_kra);
                FileInfo file2 = new FileInfo(path2);
                file2.Delete();

                string sop = "sop";
                string kra = "kra";

                string filename_sop = Path.GetFileName(file_sop.PostedFile.FileName);
                file_sop.SaveAs(Server.MapPath("~/Sop/" + ddl_designation.SelectedValue + sop + filename_sop));
                string filename_kra = Path.GetFileName(file_kra.PostedFile.FileName);
                file_kra.SaveAs(Server.MapPath("~/Kra/" + ddl_designation.SelectedValue + kra + filename_kra));

                objservice.Update_sopkra(ddl_designation.SelectedValue, "~/Kra/" + ddl_designation.SelectedValue + kra + filename_kra, "~/Sop/" + ddl_designation.SelectedValue + sop + filename_sop);
            }
        }
    }
}