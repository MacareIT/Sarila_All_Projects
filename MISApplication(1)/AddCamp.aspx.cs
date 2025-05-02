using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MISApplication
{
    public partial class AddCamp : System.Web.UI.Page
    {
        DataSet ds;
        ServiceReference1.ClinicServiceSoapClient objService = new ServiceReference1.ClinicServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Session["USERID"] = "12";
                if (Session["USERID"] == null)
                {
                    Response.Redirect("https://macare.mactech.net.in/MACARE_MIS/MAcareIT_Modules/Login.aspx");
                }
                fillCampdetails();
                //fillbranch();
                SetInitialRow();

            }
        }
        private void SetInitialRow()

        {

            DataTable dt = new DataTable();

            DataRow dr = null;

            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Column1", typeof(string)));

            dt.Columns.Add(new DataColumn("Column2", typeof(string)));

            dt.Columns.Add(new DataColumn("Column3", typeof(string)));

            dr = dt.NewRow();

            dr["RowNumber"] = 1;

            dr["Column1"] = string.Empty;

            dr["Column2"] = string.Empty;

            dr["Column3"] = string.Empty;

            dt.Rows.Add(dr);

            //dr = dt.NewRow();



            //Store the DataTable in ViewState

            ViewState["CurrentTable"] = dt;



            Gridview1.DataSource = dt;

            Gridview1.DataBind();
            DropDownList box1 = (DropDownList)Gridview1.Rows[0].Cells[1].FindControl("ddlbranch");

            fillbranch(box1);

        }
        private void fillbranch(DropDownList ddlbranch)
        {
            ds = new DataSet();
            ds = objService.ListClinic_Microlab();
            ddlbranch.DataSource = ds.Tables[0];
            ddlbranch.DataTextField = "name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
            ddlbranch.Items.Insert(0, new ListItem("---Choose Unit--", "0"));

        }

        protected void addcamp(object sender, EventArgs e)
        {
            
            try
            {

                foreach (GridViewRow r in Gridview1.Rows)
                {
                    string unitid,place;
                    DropDownList ddl = (DropDownList)Gridview1.Rows[r.RowIndex].Cells[1].FindControl("ddlbranch");
                    unitid = ddl.SelectedValue.ToString();
                    TextBox txt = (TextBox)Gridview1.Rows[r.RowIndex].Cells[2].FindControl("TextBox2");
                    place = txt.Text;
                    if(unitid!="0")
                    {
                    int res = objService.AddCamp(txtcampdate.Text,txtname.Text,txtdescription.Text,place,txtftime.Text,txtttime.Text,unitid);
                        if (res <=0)
                        {
                           ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Unable to add Camp of row no....'"+r.Cells[0].Text+");", true);

                        }   
                    }                            
                }
                fillCampdetails();
                txtdescription.Text = "NILL";
                txtcampdate.Text = string.Empty;
                txtname.Text = string.Empty;
                SetInitialRow();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('unable to add Camp....');", true);
            }
        }

        private void fillCampdetails()
        {
            try
            {
                ds = new DataSet();
                ds = objService.Campdetails();
                grdcamp.DataSource = ds.Tables[0];
                grdcamp.DataBind();
            }
            catch (Exception ex)
            {

            }
            

        }

        //protected void ddlcamp_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ds = new DataSet();
        //    ds = objService.Campdetails_ID(ddlcamp.SelectedValue);
        //    if(ds.Tables.Count>0)
        //    {
        //        if(ds.Tables[0].Rows.Count>0)
        //        {
        //            txteditdate.Text = ds.Tables[0].Rows[0]["campdate"].ToString();
        //            txteditname.Text = ds.Tables[0].Rows[0]["name"].ToString();
        //            txteditplace.Text = ds.Tables[0].Rows[0]["place"].ToString();
        //            txteditdesc.Text = ds.Tables[0].Rows[0]["description"].ToString();
        //        }
        //        else
        //        {
        //            txteditdesc.Text = string.Empty;
        //            txteditdate.Text = string.Empty;
        //            txteditname.Text = string.Empty;
        //            txteditplace.Text = string.Empty;
        //        }

        //    }
        //    else
        //    {
        //        txteditdesc.Text = "NILL";
        //        txteditdate.Text = string.Empty;
        //        txteditname.Text = string.Empty;
        //        txteditplace.Text = string.Empty;
        //    }



        //}

        protected void ButtonAdd_Click(object sender, EventArgs e)

        {

            AddNewRowToGrid();

        }

        private void AddNewRowToGrid()

        {

            int rowIndex = 0;



            if (ViewState["CurrentTable"] != null)

            {

                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)

                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)

                    {

                        //extract the TextBox values
                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlbranch");

                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");


                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;

                        dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;




                        rowIndex++;

                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;



                    Gridview1.DataSource = dtCurrentTable;

                    Gridview1.DataBind();

                }

            }

            else

            {

                Response.Write("ViewState is null");

            }



            //Set Previous Data on Postbacks

            SetPreviousData();

        }

        private void SetPreviousData()

        {

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)

            {

                DataTable dt = (DataTable)ViewState["CurrentTable"];

                if (dt.Rows.Count > 0)

                {

                    for (int i = 0; i < dt.Rows.Count; i++)

                    {

                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddlbranch");

                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("TextBox2");



                        fillbranch(box1);
                        box1.Text = dt.Rows[i]["Column1"].ToString();

                        box2.Text = dt.Rows[i]["Column2"].ToString();



                        rowIndex++;

                    }

                }

            }

        }
    }
}