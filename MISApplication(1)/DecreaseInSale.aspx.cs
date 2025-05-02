using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class DecreaseInSale : System.Web.UI.Page
    {
        DataSet ds, ds1, dsdepart;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERID"] == null)
                {
                    //ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Invalid User!! Please Relogin..');", true);
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillclinic();
                fillpharmacy();
            }
        }

        private void fillpharmacy()
        {
            ds = new DataSet();
            ds = objService.ListPharmacy();
            ddlpharmacy.DataSource = ds.Tables[0];
            ddlpharmacy.DataTextField = "branch_name";
            ddlpharmacy.DataValueField = "branch_id";
            ddlpharmacy.DataBind();
            ddlpharmacy.Items.Insert(0, new ListItem("---Choose Pharmacy--", "0"));
        }

        private void fillclinic()
        {
            ds = new DataSet();
            ds = objService.ListClinic();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "name";
            ddlbranch.DataValueField = "clinic_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Branch--", "0"));
        }
        protected void showbillvalue(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                ds = objService.MIS_PharmacyBillvalue(txtfrmdt.Text, txttodate.Text, "sales", "1", ddlpharmacy.SelectedValue);
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data will upload soon..');", true);
                GridView2.DataSource = null;
                GridView2.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }

        }
        protected void showreport(object sender, EventArgs e)
        {
            string header = string.Empty;
            try
            {
                ds = new DataSet();
                ds = objService.MIS_SalesDecr_TotalCount(txtfrmdt.Text, txttodate.Text, "0", ddlpharmacy.SelectedValue);
                GridView2.DataSource = ds.Tables[0];
                GridView2.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Data will upload soon..');", true);
                for (int i = 0; i < GridView2.Rows.Count; i++)
                {
                    double billval = Convert.ToDouble(GridView1.Rows[i].Cells[1].Text);
                    double vcount = Convert.ToDouble(GridView2.Rows[i].Cells[0].Text);
                    double noncount = Convert.ToDouble(GridView2.Rows[i].Cells[1].Text);
                    double avgval = (vcount == 0 ? vcount : Convert.ToDouble(billval / vcount));
                    GridView2.Rows[i].Cells[3].Text = Math.Round(avgval, 2).ToString();
                    GridView2.Rows[i].Cells[4].Text = Math.Round((avgval * noncount), 2).ToString();
                }

                /* ds = objService.MIS_PharmacyBillvalue(txtfrmdt.Text, txttodate.Text, "sales", "1", ddlpharmacy.SelectedValue);
                 DataTable MyTable = new DataTable();
                 MyTable.Columns.Add("department", typeof(string));
                 MyTable.Columns.Add("billvalue", typeof(string));
                 MyTable.Columns.Add("vcount", typeof(string));
                 MyTable.Columns.Add("avgval", typeof(string));
                 MyTable.Columns.Add("noncount", typeof(string));
                 MyTable.Columns.Add("totpat", typeof(string));
                 MyTable.Columns.Add("dsal", typeof(string));
                 DataRow resrw;
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                       int deptid = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                       resrw = MyTable.NewRow();
                       resrw[0] = ds.Tables[0].Rows[i][1].ToString();
                       resrw[1] = ds.Tables[0].Rows[i][2].ToString();
                       double billval = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());
                       double vcount = Convert.ToDouble(objService.MIS_SalesDecr_visitcount(txtfrmdt.Text, txttodate.Text, deptid.ToString(), ddlpharmacy.SelectedValue));
                       double avgval =Math.Round( (vcount == 0 ? vcount : Convert.ToDouble(billval / vcount)),2);
                      double noncount = Convert.ToDouble(objService.MIS_SalesDecr_noncount(txtfrmdt.Text, txttodate.Text, deptid.ToString(), ddlpharmacy.SelectedValue).ToString());
                       resrw[2] = vcount.ToString();
                       resrw[3] = avgval;
                       resrw[4] = noncount.ToString();
                       double dval = Math.Round((avgval * noncount),2);
                       resrw[5] = (vcount + noncount).ToString();//objService.MIS_SalesDecr_totpat(txtfrmdt.Text, txttodate.Text, deptid.ToString(), ddlpharmacy.SelectedValue).ToString();
                       resrw[6] =dval.ToString();
                       MyTable.Rows.Add(resrw);
                 }
                 if (MyTable.Rows.Count>0)
                 {
                     GridView3.DataSource = MyTable;
                     GridView3.DataBind();
                 }
                 else
                 {
                     ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Error occured while fetching data!!!');", true);
                 }*/

                //ReportViewer1.ProcessingMode = ProcessingMode.Local;
                //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Dsales.rdlc");
                //ReportDataSource datasource = new ReportDataSource("DataSet2", MyTable);
                ////ReportParameter Prm;
                ////Prm = new ReportParameter("prm_head1");
                ////Prm.Values.Add("DECREASE IN SALES VALUES ");
                ////ReportViewer1.LocalReport.SetParameters(Prm);
                ////Prm = new ReportParameter("prm_head2");
                ////header = "AS ON  " + txtfrmdt.Text + " to " + txttodate.Text;
                ////Prm.Values.Add(header);
                ////ReportViewer1.LocalReport.SetParameters(Prm);
                //ReportViewer1.DataBind();                
                //ReportViewer1.LocalReport.DataSources.Clear();
                //ReportViewer1.LocalReport.DataSources.Add(datasource);               

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }


    }
}