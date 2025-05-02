using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace Web_OperationDashboard
{
    public partial class Dashboard_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    string fromdt = Request.QueryString["Parameter3"].ToString();
                    string todt = Request.QueryString["Parameter4"].ToString();
                    DataTable dtReport = new DataTable();
                    dtReport = (DataTable)Session["Dashboard_Rpt"];
                    ReportViewer1.ProcessingMode = ProcessingMode.Local;
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report1.rdlc");
                    ReportParameter Prm;
                    Prm = new ReportParameter("ReportParameter1");

                    Prm.Values.Add("OPERATION DASHBOARD DATED ON BETWEEN "+fromdt+" AND "+todt);


                    ReportViewer1.LocalReport.SetParameters(Prm);
                    ReportDataSource datasource = new ReportDataSource("DataSet1", dtReport);
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
}