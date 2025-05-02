using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.ReportingServices;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace ModuleUsage
{
    public partial class Module_Usage : System.Web.UI.Page
    {
        ServiceReference1.WebService_ModuleUsageSoapClient objService = new ServiceReference1.WebService_ModuleUsageSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds1 = new DataSet();
                DataSet ds2 = new DataSet();
                DataSet ds3 = new DataSet();
                ds1 = objService.Usage_Select(txtfrmdate.Text, txttodate.Text);
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Rpt_ModuleUsage.rdlc");

                ReportParameter Prm1, Prm2;
                Prm1 = new ReportParameter("fromdate"); Prm2 = new ReportParameter("todate");
                Prm1.Values.Add(txtfrmdate.Text); Prm2.Values.Add(txttodate.Text);
                ReportViewer1.LocalReport.SetParameters(Prm1); ReportViewer1.LocalReport.SetParameters(Prm2);
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds1.Tables[0]);
                ReportViewer1.DataBind();
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("Module", typeof(string));
                dtResult.Columns.Add("usagecount", typeof(decimal));
                var re = from a in ds1.Tables[0].AsEnumerable()
                         where a.Field<decimal>("usagecount") != 0
                         select a;

                foreach (var p in re)
                {
                    dtResult.Rows.Add(p.Field<string>("Module"), p.Field<decimal>("usagecount"));
                }
                ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Rpt_ModuleUsage_pie.rdlc");
                ReportDataSource datasource2 = new ReportDataSource("DataSet1", dtResult);
                ReportViewer2.DataBind();
                ReportViewer2.LocalReport.DataSources.Clear();
                ReportViewer2.LocalReport.DataSources.Add(datasource2);

                ds2 = objService.Usage_Select_dtl(txtfrmdate.Text, txttodate.Text);
                ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/Rpt_ModuleUsage_dtl.rdlc");
                ReportDataSource datasource1 = new ReportDataSource("DataSet2", ds2.Tables[0]);
                ReportViewer2.DataBind();
                ReportViewer2.LocalReport.DataSources.Clear();
                ReportViewer2.LocalReport.DataSources.Add(datasource1);

                //ReportViewer3.LocalReport.ReportPath = Server.MapPath("~/Rpt_ModuleUsg.rdlc");
                //ReportDataSource datasource3 = new ReportDataSource("DataSet1", ds1.Tables[0]);
                //ReportViewer3.DataBind();
                //ReportViewer3.LocalReport.DataSources.Clear();
                //ReportViewer3.LocalReport.DataSources.Add(datasource3);

            }
            catch (Exception ex)
            {

            }
        }
    }
}