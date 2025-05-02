using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace PurchaseCommittee
{
    public partial class Generate_purchaseorder : System.Web.UI.Page
    {
        ServiceReference1.Service_PurchaseCommitteeSoapClient objservice = new ServiceReference1.Service_PurchaseCommitteeSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_submit_Click(object sender, EventArgs e)
        {
            string quotation_id = Request.QueryString["quotation_id"].ToString();

            DataSet ds = new DataSet();
            ds = objservice.Get_purchaseordrdtl(quotation_id);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportParameter Prm;

            Prm = new ReportParameter("po_num");
            Prm.Values.Add(txt_purchaseordernum.Text);
            ReportViewer1.LocalReport.SetParameters(Prm);

            Prm = new ReportParameter("subject");
            Prm.Values.Add(txt_subject.Text);
            ReportViewer1.LocalReport.SetParameters(Prm);

            Prm = new ReportParameter("terms");
            Prm.Values.Add(txt_termsandconditions.Text);
            ReportViewer1.LocalReport.SetParameters(Prm);

            Prm = new ReportParameter("address");
            Prm.Values.Add(txt_deliveryaddress.Text);
            ReportViewer1.LocalReport.SetParameters(Prm);

            Prm = new ReportParameter("date");
            Prm.Values.Add(txt_date.Text);
            ReportViewer1.LocalReport.SetParameters(Prm);

            ReportViewer1.DataBind();
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            //DataSet ds = new DataSet();
            //ds = objservice.Get_purchaseordrdtl(quotation_id);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.ProcessingMode = ProcessingMode.Local;
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report1.rdlc");
            //ReportDataSource datasource1 = new ReportDataSource("DataSet1", ds.Tables[0]);
            //ReportParameter Prm;

            //Prm = new ReportParameter("po_num");
            //Prm.Values.Add(txt_purchaseordernum.Text);
            //ReportViewer1.LocalReport.SetParameters(Prm);

            ////Prm = new ReportParameter("vendor_name");
            ////Prm.Values.Add(txt_vendorname.Text);
            ////ReportViewer1.LocalReport.SetParameters(Prm);

            //Prm = new ReportParameter("subject");
            //Prm.Values.Add(txt_subject.Text);
            //ReportViewer1.LocalReport.SetParameters(Prm);

            ////Prm = new ReportParameter("desc");
            ////Prm.Values.Add(txt_description.Text);
            ////ReportViewer1.LocalReport.SetParameters(Prm);

            ////Prm = new ReportParameter("amt");
            ////Prm.Values.Add(txt_amount.Text);
            ////ReportViewer1.LocalReport.SetParameters(Prm);

            //Prm = new ReportParameter("terms");
            //Prm.Values.Add(txt_termsandconditions.Text);
            //ReportViewer1.LocalReport.SetParameters(Prm);

            //Prm = new ReportParameter("address");
            //Prm.Values.Add(txt_deliveryaddress.Text);
            //ReportViewer1.LocalReport.SetParameters(Prm);

            //Prm = new ReportParameter("date");
            //Prm.Values.Add(txt_date.Text);
            //ReportViewer1.LocalReport.SetParameters(Prm);

            //ReportViewer1.DataBind();
            ////ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(datasource1);
        }
    }
}