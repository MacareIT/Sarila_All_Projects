using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


namespace Web_OperationModule
{
    public partial class Ambience_Report : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Load_Branch();
                Load_Month(); 
                Load_Year();
                Load_Ambience();
                Load_Image();
                cmbMonth.SelectedValue = DateTime.Now.Month.ToString();
                Button1.Visible = false;
            }
        }
        public void Load_Branch()
        {
            DataTable dtBranch = objService.Select_Branch().Tables[0];
            cmb_branch.DataSource = dtBranch;
            cmb_branch.DataBind();
        }
        public void Load_Month()
        {
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("MonthNo");
            dtMonth.Columns.Add("MonthName");
            dtMonth.Rows.Add("1", "January"); dtMonth.Rows.Add("2", "February"); dtMonth.Rows.Add("3", "March");
            dtMonth.Rows.Add("4", "April"); dtMonth.Rows.Add("5", "May"); dtMonth.Rows.Add("6", "June");
            dtMonth.Rows.Add("7", "July"); dtMonth.Rows.Add("8", "August"); dtMonth.Rows.Add("9", "September");
            dtMonth.Rows.Add("10", "October"); dtMonth.Rows.Add("11", "November"); dtMonth.Rows.Add("12", "December");
            cmbMonth.DataSource = dtMonth;
            cmbMonth.DataBind();
        }
        public void Load_Year()
        {
            DataTable dtYear = new DataTable();
            dtYear = objService.Select_Year().Tables[0];
            if (dtYear.Rows.Count > 0)
            {
                cmbYear.DataSource = dtYear;
                cmbYear.DataBind();
            }
            else
            {
                DataTable dtYr = new DataTable();
                dtYr.Columns.Add("Year");
                dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
                cmbYear.DataSource = dtYr;
                cmbYear.DataBind();
            }
        }
        public void Load_Ambience()
        {
            DataSet ds = objService.Select_AmbienceReport(Convert.ToInt32(cmbMonth.Text), Convert.ToInt32(cmbYear.Text), Convert.ToInt32(cmb_branch.SelectedValue));
            if (ds.Tables[0].Rows.Count > 0)
            {
                Grid_Ambience.DataSource = ds.Tables[0];
                Grid_Ambience.DataBind();
                Session.Add("AmbienceRpt", ds.Tables[0]);
                Button1.Visible = true;
            }
        }
        public void Load_Image()
        {
            DataTable dtImage = objService.AmbiencePic_Select(Convert.ToInt32(cmbYear.SelectedValue), Convert.ToInt32(cmbMonth.SelectedValue), Convert.ToInt32(cmb_branch.SelectedValue)).Tables[0];
            if (dtImage.Rows.Count > 0)
            {
                Grid_Image.DataSource = dtImage;
                Grid_Image.DataBind();
                Button1.Visible = true;
            }
            else
            {
                Grid_Image.DataSource = null;
                Grid_Image.DataBind();
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Load_Ambience();
            Load_Image();
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Clear();
            //Response.Buffer = true;
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.Charset = "";
            //string FileName = "Ambience-" + DateTime.Now + "-" + cmb_branch.SelectedValue.ToString() + ".doc";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentType = "application/msword";
            //Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            //Grid_Ambience.GridLines = GridLines.Both;
            //Grid_Ambience.HeaderStyle.Font.Bold = true;
            //Grid_Ambience.RenderControl(hw);
            //Response.Write(sw.ToString());
            //Response.End();

            //Response.Clear();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment;filename-WordDoc.doc");
            //Response.Charset = "";
            //Response.ContentType = "application/vnd.ms-word";
            //StringWriter sw1 = new StringWriter();
            //HtmlTextWriter hw1 = new HtmlTextWriter(sw1);
            //DataTable dt = new DataTable();string columns = "";
            //.......................................................................
            //foreach (DataListItem item in DataList1.Items)
            //{
            //    string name = ((Label)item.FindControl("Label1")).Text;
            //    dt.Columns.Add(name);
            //    if(columns=="")
            //        columns= ((Label)item.FindControl("Label1")).Text;
            //    else
            //        columns = columns +","+ ((Label)item.FindControl("Label1")).Text;
            //    //string image = ((Label)item.FindControl("Image1")).Text;
            //    ////adding rows
            //    //dt.Rows.Add(id, name);
            //}
            //string[] str = columns.Split(',');
            ////foreach (DataListItem item in DataList1.Items)
            ////{
            ////    dt.Rows.Add(((Label)item.FindControl("Image1")).Text);
            ////}
            //string rowlist = "";string[] k = new string[20];
            //for(int i=0;i<str.Length;i++)
            //{
            //    if(i==0)
            //    {
            //        dt.Rows.Clear();
            //        dt.Rows.Add(((Image)DataList1.Items[i].FindControl("Image1")).ImageUrl);
            //    }
            //    else if(i==1)
            //    {
            //        dt.Rows.Clear();
            //        dt.Rows.Add(((Image)DataList1.Items[i-1].FindControl("Image1")).ImageUrl, ((Image)DataList1.Items[i].FindControl("Image1")).ImageUrl);
            //    }
            //    else if(i==2)
            //    {
            //        dt.Rows.Clear();
            //        dt.Rows.Add(((Image)DataList1.Items[i - 2].FindControl("Image1")).ImageUrl, ((Image)DataList1.Items[i-1].FindControl("Image1")).ImageUrl,((Image)DataList1.Items[i].FindControl("Image1")).ImageUrl);

            //    }
            //    else if(i==3)
            //    {
            //        dt.Rows.Clear();
            //        dt.Rows.Add(((Image)DataList1.Items[i - 3].FindControl("Image1")).ImageUrl, ((Image)DataList1.Items[i - 2].FindControl("Image1")).ImageUrl, ((Image)DataList1.Items[i - 1].FindControl("Image1")).ImageUrl,((Image)DataList1.Items[i].FindControl("Image1")).ImageUrl);
            //    }
            //    else { }
            //}
            //......................................................................................................

            //GridView gv = new GridView(); 
            //gv.DataSource = dt; gv.DataBind();
            //Grid_Image.RenderControl(hw);
            //Response.Output.Write(sw.ToString());
            //Response.Flush();
            //Response.End();
            //...........................................................................................

            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
            //pdfDoc.Close();
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Write(pdfDoc);
            //Response.End();

            //try
            //{
            //    Response.Clear();
            //    Response.Buffer = true;
            //    Response.AddHeader("content-disposition",
            //        "attachment;filename=EmployeeInfo.xls");
            //    Response.Charset = "";
            //    Response.ContentType = "application/vnd.ms-excel";
            //    StringWriter sw = new StringWriter();
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);
            //    gridInformation.AllowPaging = false;
            //    gridInformation.DataBind();
            //    for (int i = 0; i < gridInformation.Rows.Count; i++)
            //    {
            //        GridViewRow row = gridInformation.Rows[i];
            //        //Apply text style to each Row
            //        row.Attributes.Add("class", "textmode");
            //    }
            //    gridInformation.RenderControl(hw);

            //    //style to format numbers to string
            //    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            //    Response.Write(style);
            //    Response.Output.Write(sw.ToString());
            //    Response.Flush();
            //    Response.End();
            //}

            //catch (Exception)
            //{

            //}
            try
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                string fname = "Amb-" + cmb_branch.SelectedValue.ToString() + "-" + cmbMonth.SelectedValue.ToString() + "-" + cmbYear.SelectedValue.ToString();

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        Table tb = new Table();
                        TableRow tr1 = new TableRow();
                        TableCell cell1 = new TableCell();
                        cell1.Text = " ";
                        tr1.Cells.Add(cell1);

                        TableRow tr2 = new TableRow();
                        TableCell cell2 = new TableCell();
                        cell2.Text = "BRANCHWISE AMBIENCE REPORT ON " + cmbMonth.SelectedValue.ToString() + " " + cmbYear.SelectedValue.ToString();
                        tr2.Cells.Add(cell2);

                        TableRow tr3 = new TableRow();
                        TableCell cell3 = new TableCell();
                        cell3.Text = " ";
                        tr3.Cells.Add(cell3);

                        TableRow tr4 = new TableRow();
                        TableCell cell4 = new TableCell();
                        cell4.Text = cmb_branch.SelectedItem.ToString();
                        tr4.Cells.Add(cell4);

                        TableRow tr5 = new TableRow();
                        TableCell cell5 = new TableCell();
                        cell5.Text = "Entered by:" + ((DataTable)Session["AmbienceRpt"]).Rows[0]["amb_entered"].ToString() + "," + ((DataTable)Session["AmbienceRpt"]).Rows[0]["Designation"].ToString() + ",on:" + ((DataTable)Session["AmbienceRpt"]).Rows[0]["amb_date"].ToString();
                        tr5.Cells.Add(cell5);

                        TableRow tr6 = new TableRow();
                        TableCell cell6 = new TableCell();
                        cell6.Text = " ";
                        tr6.Cells.Add(cell6);

                        TableRow tr7 = new TableRow();
                        TableCell cell7 = new TableCell();
                        cell7.Controls.Add(Grid_Ambience);
                        tr7.Cells.Add(cell7);

                        TableRow tr8 = new TableRow();
                        TableCell cell8 = new TableCell();
                        cell8.Text = " ";
                        tr8.Cells.Add(cell8);

                        TableRow tr9 = new TableRow();
                        TableCell cell9 = new TableCell();
                        cell9.Controls.Add(Grid_Image);
                        tr9.Cells.Add(cell9);

                        tb.Rows.Add(tr1);
                        tb.Rows.Add(tr2);
                        tb.Rows.Add(tr3);
                        tb.Rows.Add(tr4);
                        tb.Rows.Add(tr5);
                        tb.Rows.Add(tr6);
                        tb.Rows.Add(tr7);
                        tb.Rows.Add(tr8);
                        tb.Rows.Add(tr9);
                        tb.RenderControl(hw);
                        Response.Output.Write(sw.ToString());
                        Response.Flush();

                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            finally
            {
                Response.End();
            }
        }
    }
}