using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationModule
{
    public partial class BranchVisit_ViewDtls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string[] str = GetSoundFile().Split('|');
                DataTable dttable = new DataTable();
                dttable.Columns.Add("Link");
                for(int i=0;i<str.Length;i++)
                {
                    dttable.Rows.Add(str[i]);
                }
                Grid_Ambience.DataSource = dttable;
                Grid_Ambience.DataBind();
            }
        }
        public string GetSoundFile()
        {
            var files = Directory.GetFiles(HttpContext.Current.Server.MapPath("~/BranchVisit_Rpt"));
            return String.Join("|", files);
        }

        protected void Grid_Ambience_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                string path = (string)e.CommandArgument;
                Response.Clear();
                Response.ContentType = "application/ms-excel";
                Response.AddHeader("Content-Disposition", "attachment; filename=test.xls");
                Response.TransmitFile(path);
                Response.End();
            }
        }
    }
}