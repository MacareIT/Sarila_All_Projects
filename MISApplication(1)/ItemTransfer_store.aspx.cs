using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class ItemTransfer_store : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["USERID"] = "123";
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
            }
        }
        protected void showreport(object sender, EventArgs e)
        {
            string header = string.Empty;
            try
            {
                ds = new DataSet();
                ds = objService.ItemTransfer_tostore(txtfrmdt.Text, txttodate.Text);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/ItemTransfertoStore.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                ReportParameter Prm;
                Prm = new ReportParameter("prm_head1");
                Prm.Values.Add("ITEM TRANSFER TO VALAPAD STORE ");
                ReportViewer1.LocalReport.SetParameters(Prm);
                Prm = new ReportParameter("prm_head2");
                header = "REPORT AS ON  " + txtfrmdt.Text + " to " + txttodate.Text;
                Prm.Values.Add(header);
                ReportViewer1.LocalReport.SetParameters(Prm);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
            catch (Exception ex)
            {

            }

        }
    }
}