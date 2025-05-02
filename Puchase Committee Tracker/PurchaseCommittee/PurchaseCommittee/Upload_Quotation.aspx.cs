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
    public partial class Upload_Quotation : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (file_quotation.HasFile)
            //{
            //    string item_id = Request.QueryString["item_id"].ToString();

            //    string filename_quotation = Path.GetFileName(file_quotation.PostedFile.FileName);
            //    file_quotation.SaveAs(Server.MapPath("~/Quotation/" + filename_quotation));

            //    string amt = txt_amt.Text;
            //    amt = amt.Replace("'", "''");

            //    string dec = txt_dec.Text;
            //    dec = dec.Replace("'", "''");

            //    string vendorname = txt_vendorname.Text;
            //    vendorname = vendorname.Replace("'", "''");

            //    objservice.Add_quotation(item_id, "~/Quotation/" + filename_quotation, vendorname, dec, amt);
            //    Response.Redirect("View_PendingQuotations.aspx");
            //}
            //else
            //{
            //    Response.Write("<script>alert('Please Upload Quotation...!!')</script>");
            //}
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
                    string itemid = Request.QueryString["item_id"].ToString();

                    //string filename_quotation = Path.GetFileName(file_quotation.PostedFile.FileName);
                    //file_quotation.SaveAs(Server.MapPath("~/Quotation/" + itemid + filename_quotation));

                    string amt = txt_amt.Text;
                    amt = amt.Replace("'", "''");

                    string dec = txt_dec.Text;
                    dec = dec.Replace("'", "''");

                    string vendorname = txt_vendorname.Text;
                    vendorname = vendorname.Replace("'", "''");

                    //objservice.Add_quotationdetails(itemid, ddl_dept.SelectedValue, productname, purpose);
                    objservice.Insert_Quotation(itemid, vendorname, dec, amt, bytes, filename, contentType, Session["USERID"].ToString(), DateTime.Now.ToString("dd-MM-yyyy"));
                    Response.Write("<script>alert('Uploaded Successfully...!!')</script>");
                    txt_amt.Text = string.Empty;
                    txt_dec.Text = string.Empty;
                    txt_vendorname.Text = string.Empty;
                }
                else
                {
                    Response.Write("<script>alert('Please Upload Quotation...!!')</script>");
                }
            }
        }
    }
}