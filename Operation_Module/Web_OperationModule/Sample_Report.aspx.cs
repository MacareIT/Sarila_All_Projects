using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_OperationModule
{
    public partial class Sample_Report : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                DataSet dsPath = objService.AmbiencePic_Select(2022, 9, 0);
                ReportDataSource datasource = new ReportDataSource("DataSet1", dsPath.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.Refresh();
                GridView1.DataSource = dsPath.Tables[0];
                GridView1.DataBind();
            }
        }
    }
}