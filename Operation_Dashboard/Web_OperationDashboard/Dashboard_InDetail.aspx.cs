using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationDashboard
{
    public partial class Dashboard_InDetail : System.Web.UI.Page
    {
        ServiceReference1.WebService_OperationDashboardSoapClient objService = new ServiceReference1.WebService_OperationDashboardSoapClient();
        protected void Page_Load(object sender, EventArgs e) 
        {
            if(!IsPostBack)
            {
                string branch = Request.QueryString["Parameter1"].ToString();
                string operation= Request.QueryString["Parameter2"].ToString();
                Lbl_name.Text = operation;
                string fromdate= Request.QueryString["Parameter3"].ToString();
                string todate= Request.QueryString["Parameter4"].ToString();
                DataSet ds_dashboard = new DataSet();
                if (operation == "Cash_position")
                {
                  ds_dashboard = objService.Load_CashPosition_InDtl(branch, fromdate, todate);
                }
                else if(operation== "Debitnote_Create")
                {
                  ds_dashboard = objService.Load_DebitCreate_InDtl(branch, fromdate, todate);
                }
                else if(operation== "DailyInventory_Chk")
                {
                   ds_dashboard = objService.Load_Inventory_Chk(branch, fromdate, todate);
                }
                else
                {

                }
                if (ds_dashboard.Tables[0].Rows.Count > 0)
                    GridView1.DataSource = ds_dashboard;
                else GridView1.DataSource = null;
                GridView1.DataBind();
                Btn_back.Visible = true;
            }
        }
    }
}