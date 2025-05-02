using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class testpopup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void viewexcel(object sender, EventArgs e)
        {
            try
            {
               
                    string path = string.Concat(Server.MapPath("~/Excel/" + "exportexcel"));
                    //FileUploadProduct.SaveAs(path);
                    Session["name"] = path;
                    // Response.Redirect("WebForm1.aspx");
                    string physicalPath = path;
                    OleDbCommand cmd = new OleDbCommand();
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    DataSet ds = new DataSet();
                    String strNewPath = physicalPath;
                    String connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strNewPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    String query = "SELECT * FROM [Sheet1$]"; // You can use any different queries to get the data from the excel sheet
                    OleDbConnection conn = new OleDbConnection(connString);
                    if (conn.State == ConnectionState.Closed) conn.Open();
                    try
                    {
                        cmd = new OleDbCommand(query, conn);
                        da = new OleDbDataAdapter(cmd);
                        da.Fill(ds);

                    }
                    catch
                    {
                        // Exception Msg 

                    }
                    finally
                    {
                        da.Dispose();
                        conn.Close();
                    }
                
            }
            catch (Exception ex)
            {

            }
        }
        }
}