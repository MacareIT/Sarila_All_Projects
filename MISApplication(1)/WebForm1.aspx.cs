using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Collections;

namespace MISApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var arlist1 = new ArrayList()
                {
                    08.30,08.00,11.00,06.00,10.00,09.00,19.00,07.00,12.00
                };
            var arlist2 = new ArrayList()
                {
                    1,2,3,4,5,6,7,8,9
                };
            string systime = DateTime.Now.ToString("HH:mm:ss tt");
           
        }
        protected void btnupload_Click(object sender, EventArgs e)
        {


        }
    }
}