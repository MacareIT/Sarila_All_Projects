using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PurchaseCommittee
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["USERTYPE"] == null && Session["USERID"] == null && Session["LOGUSER"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}