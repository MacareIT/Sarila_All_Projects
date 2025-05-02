using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountsApp
{
    public partial class accounts : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Session["USERID"] = "150739";
                //lbluser.Text = Session["USERID"].ToString();
            }
        }
    }
}