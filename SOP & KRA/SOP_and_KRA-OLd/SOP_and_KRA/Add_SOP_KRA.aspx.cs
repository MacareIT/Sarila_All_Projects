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
    public partial class Add_SOP_KRA : System.Web.UI.Page
    {
        ServiceReference1.Service_SOPandKRASoapClient objservice = new ServiceReference1.Service_SOPandKRASoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindddldept();
            }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = objservice.Get_sopkraid();
            string sopkraid = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            string sop = "sop";
            string kra = "kra";

            string filename_sop = Path.GetFileName(file_sop.PostedFile.FileName);
            file_sop.SaveAs(Server.MapPath("~/Sop/" +sopkraid+sop+ filename_sop));
            string filename_kra = Path.GetFileName(file_kra.PostedFile.FileName);
            file_kra.SaveAs(Server.MapPath("~/Kra/" +sopkraid+kra+ filename_kra));

            objservice.Add_Sopkra(sopkraid,ddl_dept.SelectedValue, txt_designation.Text, "~/Sop/" + sopkraid + sop + filename_sop, "~/Kra/" + sopkraid + kra + filename_kra);

            txt_designation.Text = string.Empty;
            ddl_dept.ClearSelection();
            Response.Write("<script>alert('SOP And KRA Uploaded Successfully...!!')</script>");

        }
    }
}