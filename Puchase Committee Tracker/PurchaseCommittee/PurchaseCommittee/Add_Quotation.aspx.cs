using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

namespace PurchaseCommittee
{
    public partial class Add_Quotation : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        ServiceReference2.Service_SOPandKRASoapClient objservice1 = new ServiceReference2.Service_SOPandKRASoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindddlbranch();
                bindddldept();
            }
        }

        private void bindddldept()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_dapartment().Tables[0];
            ddl_dept.DataSource = dt;
            ddl_dept.DataTextField = "dep_name";
            ddl_dept.DataValueField = "dep_name";
            ddl_dept.DataBind();
            ddl_dept.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void bindddlbranch()
        {
            DataTable dt = new DataTable();
            dt = objservice.Get_Branch().Tables[0];
            ddl_branch.DataSource = dt;
            ddl_branch.DataTextField = "branch_name";
            ddl_branch.DataValueField = "branch_id";
            ddl_branch.DataBind();
            ddl_branch.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Session["USERID"] != null)
            {
                if (file_quotation.HasFile)
                {
                    string filename = Path.GetFileName(file_quotation.PostedFile.FileName);
                    string contentType = file_quotation.PostedFile.ContentType;
                    byte[] bytes;
                    using (Stream fs = file_quotation.PostedFile.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            bytes = br.ReadBytes((Int32)fs.Length);
                        }
                    }

                    DataSet ds = new DataSet();
                    ds = objservice.Get_itemid();
                    string itemid = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                    //string filename_quotation = Path.GetFileName(file_quotation.PostedFile.FileName);
                    //file_quotation.SaveAs(Server.MapPath("~/Quotation/" + itemid + filename_quotation));

                    string productname = txt_productname.Text;
                    productname = productname.Replace("'", "''");

                    string amt = txt_amt.Text;
                    amt = amt.Replace("'", "''");

                    string dec = txt_dec.Text;
                    dec = dec.Replace("'", "''");

                    string purpose = txt_purpose.Text;
                    purpose = purpose.Replace("'", "''");

                    string vendorname = txt_vendorname.Text;
                    vendorname = vendorname.Replace("'", "''");

                    objservice.Add_quotationdetails(itemid, ddl_dept.SelectedValue, productname, purpose);
                    objservice.Insert_Quotation(itemid, vendorname, dec, amt, bytes, filename, contentType,Session["USERID"].ToString(), DateTime.Now.ToString("dd-MM-yyyy"));
                    Response.Write("<script>alert('Uploaded Successfully...!!')</script>");
                    txt_amt.Text = string.Empty;
                    txt_dec.Text = string.Empty;
                    txt_productname.Text = string.Empty;
                    txt_purpose.Text = string.Empty;
                    txt_vendorname.Text = string.Empty;
                    ddl_branch.ClearSelection();
                    ddl_dept.ClearSelection();
                }
                else
                {
                    Response.Write("<script>alert('Please Upload Quotation...!!')</script>");
                }
            }
        }
    }
}