using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class Site_Master : System.Web.UI.MasterPage
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            //{
            //    
            //}
            load_NABL_accreditn();
        }
        public void load_NABL_accreditn()
        {
            DataSet ds = objService.Check_ReminderDate();
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];

                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() != string.Empty)
                    {
                        string str = dt.Rows[0]["issued_date"].ToString().Replace("00:00:00", null);
                        notfn.Text = "NABL Accreditation valid upto :" + str;
                    }
                    else notfn.Text = "";
                }
                else notfn.Text = "";
            }
        }
    }
}