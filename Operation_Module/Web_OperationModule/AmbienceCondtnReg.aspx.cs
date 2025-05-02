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
    public partial class AmbienceCondtnReg : System.Web.UI.Page
    {
        ServiceMacare.WebService_OperationSoapClient objService = new ServiceMacare.WebService_OperationSoapClient();

        public void Load_Month()
        {
            DataTable dtMonth = new DataTable();
            dtMonth.Columns.Add("MonthNo");
            dtMonth.Columns.Add("MonthName");
            dtMonth.Rows.Add("1", "January"); dtMonth.Rows.Add("2", "February"); dtMonth.Rows.Add("3", "March");
            dtMonth.Rows.Add("4", "April"); dtMonth.Rows.Add("5", "May"); dtMonth.Rows.Add("6", "June");
            dtMonth.Rows.Add("7", "July"); dtMonth.Rows.Add("8", "August"); dtMonth.Rows.Add("9", "September");
            dtMonth.Rows.Add("10", "October"); dtMonth.Rows.Add("11", "November"); dtMonth.Rows.Add("12", "December");
            cmbMnth.DataSource = dtMonth;
            cmbMnth.DataBind();
            cmbMnth.SelectedValue = DateTime.Now.Month.ToString();
        }
        public void Load_Year()
        {
            //DataTable dtYear = new DataTable();
            //dtYear = objService.Select_Year().Tables[0];
            //if (dtYear.Rows.Count > 0)
            //{
            //    cmbYr.DataSource = dtYear;
            //    cmbYr.DataBind();
            //}
            //else
            //{
            //    DataTable dtYr = new DataTable();
            //    dtYr.Columns.Add("Year");
            //    dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
            //    cmbYr.DataSource = dtYr;
            //    cmbYr.DataBind();
            //}
            //...................................................

            int status = 0;
            DataTable dtYear = new DataTable();
            dtYear.Columns.Add("Year");
            DataTable dtYear1 = objService.Select_Year().Tables[0];
            if (dtYear1.Rows.Count > 0)
            {
                for (int i = 0; i < dtYear1.Rows.Count; i++)
                {
                    dtYear.Rows.Add(dtYear1.Rows[i]["Year"].ToString());
                    if (dtYear1.Rows[i]["Year"].ToString() == DateTime.Now.ToString("yyyy"))
                        status = 1;
                }
                if (status == 0)
                    dtYear.Rows.Add(DateTime.Now.ToString("yyyy"));

                cmbYr.DataSource = dtYear;
                cmbYr.DataBind();
            }
            else
            {
                DataTable dtYr = new DataTable();
                dtYr.Columns.Add("Year");
                dtYr.Rows.Add(DateTime.Now.ToString("yyyy"));
                cmbYr.DataSource = dtYr;
                cmbYr.DataBind();
            }
        }
        public void Load_Amb()
        {
            DataSet dsAmb = new DataSet(); //int year_; int Month_;
            //if (string.IsNullOrEmpty(cmbYr.SelectedValue))
            //{
            //    year_= Convert.ToInt32(DateTime.Now.ToString("yyyy")); 
            //}
            //else year_ = Convert.ToInt32(cmbYr.Text);
            //Month_ = Convert.ToInt32(DateTime.Now.ToString("MM"));
            DataTable dt = (DataTable)Session["Login_Table"];
            dsAmb = objService.Select_AmbienceCondition(Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue));

            DataTable dtNewAmb = new DataTable();
            dtNewAmb.Columns.Add("Amb_Id"); dtNewAmb.Columns.Add("Amb_Name");
            dtNewAmb.Columns.Add("Amb_Count"); dtNewAmb.Columns.Add("Amb_Condtn"); dtNewAmb.Columns.Add("Amb_Remarks");

            if (dsAmb.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsAmb.Tables[0].Rows.Count; i++)
                {
                    dtNewAmb.Rows.Add(dsAmb.Tables[0].Rows[i]["Amb_Id"].ToString(), dsAmb.Tables[0].Rows[i]["Amb_Name"].ToString(), dsAmb.Tables[0].Rows[i]["Amb_Count"].ToString(), dsAmb.Tables[0].Rows[i]["Amb_Condtn"].ToString(), dsAmb.Tables[0].Rows[i]["Amb_Remarks"].ToString());
                }
            }

            DataTable dtAmb = objService.Select_AmbienceConditionWithExcessAmbID(Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue)).Tables[0];
            if (dtAmb.Rows.Count > 0)
            {
                for (int i = 0; i < dtAmb.Rows.Count; i++)
                {
                    dtNewAmb.Rows.Add(dtAmb.Rows[i]["Amb_Id"].ToString(), dtAmb.Rows[i]["Amb_Name"].ToString(), " ", " ", " ");
                }
            }
            GridAmbCondtn.DataSource = dtNewAmb;
            GridAmbCondtn.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Month(); Load_Year();
                Btn_Submit.Visible = false;
                Load_Amb();
                
                if (GridAmbCondtn.Rows.Count > 0)
                    Btn_Submit.Visible = true;
                else Btn_Submit.Visible = false;
                Image1.Visible = false;Image2.Visible = false;
                Image3.Visible = false;Image4.Visible = false;
                Load_AmbPIc();
            }
        }
        public void Load_AmbPIc()
       {
            if (Session["Login_Table"] != null)
            {
                DataTable dt = (DataTable)Session["Login_Table"];Image1.Visible = false;Image2.Visible = false;Image3.Visible = false;Image4.Visible = false;
                lbl_Picid1.Text = "0";Lbl_Picid2.Text = "0";Lbl_Picid3.Text = "0";Lbl_Picid4.Text = "0";
                DataTable dtpic = objService.AmbiencePic_Select(Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(dt.Rows[0]["Branchid"].ToString())).Tables[0];
                //string fileName = "";
                for (int i = 0; i < dtpic.Rows.Count; i++)
                {
                    //fileName = dtpic.Rows[i]["amb_pic_path"].ToString();
                    //string filePath = Server.MapPath("~/Ambience_Image/");
                    //string fileextention = Path.GetExtension(fileName);
                    //fileextention = fileextention.ToLower();
                    //string link = "~/Images/FacultyPics/" + fileName;
                    //if (fileextention == ".jpg" || fileextention == ".png" || fileextention == ".gif" || fileextention == ".bmp")
                    //{

                    //}
                    if (dtpic.Rows[i]["amb_pic_name"].ToString() == "Lab")
                    {
                        if (dtpic.Rows[i]["amb_pic_path"].ToString() == "")
                        {
                            Image1.Visible = false;
                            lbl_Picid1.Text = "";
                        }
                        else
                        {
                            //Image1.ImageUrl = "~/Ambience_Image/" + dtpic.Rows[i]["amb_pic_path"].ToString();
                            Image1.Visible = true;
                            Image1.ImageUrl = dtpic.Rows[i]["amb_pic_path"].ToString();
                            lbl_Picid1.Text = dtpic.Rows[i]["amb_pic_id"].ToString();
                        }
                    }
                   
                    else if (dtpic.Rows[i]["amb_pic_name"].ToString() == "Board")
                    {
                        if (dtpic.Rows[i]["amb_pic_path"].ToString() == "")
                        {
                            Image2.Visible = false;
                            Lbl_Picid2.Text = "";
                        }
                        else
                        {
                            Image2.Visible = true;
                            Image2.ImageUrl = dtpic.Rows[i]["amb_pic_path"].ToString();
                            Lbl_Picid2.Text = dtpic.Rows[i]["amb_pic_id"].ToString();
                        }
                    }
                   
                    else if (dtpic.Rows[i]["amb_pic_name"].ToString() == "Toilet")
                    {
                        if (dtpic.Rows[i]["amb_pic_path"].ToString() == "")
                        {
                            Image3.Visible = false;
                            Lbl_Picid3.Text = "";
                        }
                        else
                        {
                            Image3.Visible = true; 
                            Image3.ImageUrl = dtpic.Rows[i]["amb_pic_path"].ToString();
                            Lbl_Picid3.Text = dtpic.Rows[i]["amb_pic_id"].ToString();
                        }
                    }
                   
                    else if (dtpic.Rows[i]["amb_pic_name"].ToString() == "Reception Area")
                    {
                        if (dtpic.Rows[i]["amb_pic_path"].ToString() == "")
                        {
                            Image4.Visible = false;
                            Lbl_Picid4.Text = "";
                        }
                        else
                        {
                            Image4.Visible = true; 
                            Image4.ImageUrl = dtpic.Rows[i]["amb_pic_path"].ToString();
                            Lbl_Picid4.Text = dtpic.Rows[i]["amb_pic_id"].ToString();
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
            else Response.Write("<script>alert('Session time out!!!');</script>");
        }
        protected void Grid_Ambience_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void Btn_Submit_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (Session["Login_Table"] != null)
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                try
                {
                    DataTable dtVerify = (objService.Select_VerifiedAmbience(Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue))).Tables[0];
                    if (dtVerify.Rows.Count == 0)
                    {
                        int reslt = objService.AmbienceCondtn_Delete(Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()));
                        for (int i = 0; i < GridAmbCondtn.Rows.Count; i++)
                        {
                            result = objService.AmbienceCondtn_InsertUpdate(Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()), Convert.ToInt32(((Label)GridAmbCondtn.Rows[i].Cells[0].FindControl("lbl_Id")).Text), ((TextBox)GridAmbCondtn.Rows[i].Cells[2].FindControl("txtCount")).Text, ((TextBox)GridAmbCondtn.Rows[i].Cells[3].FindControl("txtCndtn")).Text, ((TextBox)GridAmbCondtn.Rows[i].Cells[4].FindControl("txtRemarks")).Text, Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(cmbYr.SelectedValue), DateTime.Now.ToString("dd-MM-yyyy"), dt.Rows[0]["username"].ToString());
                        }
                        if (result > 0)
                        {
                            Response.Write("<script>alert('Added Successfully');</script>");
                            Load_Amb();
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Ambience Already Verified');</script>");
                        Load_Amb();
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else Response.Write("<script>alert('Session time out!!!');</script>");
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            Load_Amb();
            if (GridAmbCondtn.Rows.Count > 0)
                Btn_Submit.Visible = true;
            else Btn_Submit.Visible = false;
            Load_AmbPIc();
        }

        protected void btnUpload1_Click(object sender, EventArgs e)
        {
            if (Session["Login_Table"] != null)
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                File.Delete(Server.MapPath(Path.Combine("~/Ambience_Image/", Lbl_Lab.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload1.FileName)));
                FileUpload1.SaveAs(Server.MapPath("~/Ambience_Image/") + Lbl_Lab.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload1.FileName);
                //FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~\ATR_Reply\" + lblATRId.Text + FileUpload1.FileName));
                Session.Add("Filename", Lbl_Lab.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload1.FileName);
                DataSet dsresult = objService.AmbiencePic_InsertUpdate(Convert.ToInt32(lbl_Picid1.Text), "~/Ambience_Image/"+Lbl_Lab.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload1.FileName, Lbl_Lab.Text, Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()));
                if (dsresult.Tables[0].Rows.Count > 0)
                {
                    Load_AmbPIc();
                    //Image1.ImageUrl = "~/Ambience_Image/" + Lbl_Lab.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload1.FileName;
                    //lbl_Picid1.Text = Convert.ToInt32(dsresult.Tables[0].Rows[0]["amb_pic_id"].ToString()).ToString();
                }
            }
            else Response.Write("<script>alert('Session time out!!!');</script>");
        }
        //public int Upload_image(int pic_id, string picsname, string filename, string month, string year)
        //{


        //int picid = 0;
        //File.Delete(Server.MapPath(Path.Combine("~/Ambience_Image/", picsname + "-" + month + "-" + year + "-" + filename)));
        //string path = Path.GetFileName(FileUpload1.FileName);
        //path = path.Replace(" ", "");
        //string fileName=image
        //string filePath = Server.MapPath("~/Ambience_Image/");
        //string fileextention = Path.GetExtension(filename);
        //fileextention = fileextention.ToLower();
        //FileUpload1.SaveAs(Server.MapPath("~/Ambience_Image/" + picsname + " - " + month + " - " + year + " - " + filename));
        ////FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~\ATR_Reply\" + lblATRId.Text + FileUpload1.FileName));
        //Session.Add("Filename", picsname + "-" + month + "-" + year + "-" + filename);
        //DataSet dsresult = objService.AmbiencePic_InsertUpdate(pic_id, filename, picsname, Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()));
        //if (dsresult.Tables[0].Rows.Count > 0)
        //{
        //    Image1.ImageUrl = "~/Ambience_Image/" + picsname + "-" + month + "-" + year + "-" + filename;
        //    picid = Convert.ToInt32(dsresult.Tables[0].Rows[0]["amb_pic_id"].ToString());
        //}
        //return picid;
        //}

        protected void btnUpload2_Click(object sender, EventArgs e)
        {
            if (Session["Login_Table"] != null)
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                //int id=Upload_image(Convert.ToInt32(Lbl_Picid2.Text), Lbl_Board.Text, FileUpload2.FileName, cmbMnth.SelectedValue.ToString(), cmbYr.SelectedValue.ToString());
                //Lbl_Picid2.Text = id.ToString();
                File.Delete(Server.MapPath(Path.Combine("~/Ambience_Image/", Lbl_Board.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload2.FileName)));
                //string path = Path.GetFileName(FileUpload1.FileName);
                //path = path.Replace(" ", "");
                FileUpload2.SaveAs(Server.MapPath("~/Ambience_Image/") + Lbl_Board.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload2.FileName);
                //FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~\ATR_Reply\" + lblATRId.Text + FileUpload1.FileName));
                Session.Add("Filename", Lbl_Board.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload2.FileName);
                DataSet dsresult = objService.AmbiencePic_InsertUpdate(Convert.ToInt32(Lbl_Picid2.Text), "~/Ambience_Image/" + Lbl_Board.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload2.FileName, Lbl_Board.Text, Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()));
                if (dsresult.Tables[0].Rows.Count > 0)
                {
                    Load_AmbPIc();
                    //Image2.ImageUrl = "~/Ambience_Image/" + Lbl_Board.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload2.FileName;
                    //Lbl_Picid2.Text = Convert.ToInt32(dsresult.Tables[0].Rows[0]["amb_pic_id"].ToString()).ToString();
                }
            }
            else Response.Write("<script>alert('Session time out!!!');</script>");
        }

        protected void btnUpload3_Click(object sender, EventArgs e)
        {
            if (Session["Login_Table"] != null)
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                File.Delete(Server.MapPath(Path.Combine("~/Ambience_Image/", Lbl_Toilet.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload3.FileName)));
                FileUpload3.SaveAs(Server.MapPath("~/Ambience_Image/") + Lbl_Toilet.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload3.FileName);
                //FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~\ATR_Reply\" + lblATRId.Text + FileUpload1.FileName));
                Session.Add("Filename", Lbl_Toilet.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload3.FileName);
                DataSet dsresult = objService.AmbiencePic_InsertUpdate(Convert.ToInt32(Lbl_Picid3.Text), "~/Ambience_Image/" + Lbl_Toilet.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload3.FileName, Lbl_Toilet.Text, Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()));
                if (dsresult.Tables[0].Rows.Count > 0)
                {
                    Load_AmbPIc();
                    //Image3.ImageUrl = "~/Ambience_Image/" + Lbl_Toilet.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload3.FileName;
                    //Lbl_Picid3.Text = Convert.ToInt32(dsresult.Tables[0].Rows[0]["amb_pic_id"].ToString()).ToString();
                }
            }
            else Response.Write("<script>alert('Session time out!!!');</script>");
        }

        protected void btnUpload4_Click(object sender, EventArgs e)
        {
            if (Session["Login_Table"] != null)
            {
                DataTable dt = (DataTable)Session["Login_Table"];
                File.Delete(Server.MapPath(Path.Combine("~/Ambience_Image/", Lbl_Recptn.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload4.FileName)));
                FileUpload4.SaveAs(Server.MapPath("~/Ambience_Image/") + Lbl_Recptn.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload4.FileName);
                //FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~\ATR_Reply\" + lblATRId.Text + FileUpload1.FileName));
                Session.Add("Filename", Lbl_Recptn.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload4.FileName);
                DataSet dsresult = objService.AmbiencePic_InsertUpdate(Convert.ToInt32(Lbl_Picid4.Text), "~/Ambience_Image/" + Lbl_Recptn.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload4.FileName, Lbl_Recptn.Text, Convert.ToInt32(cmbYr.SelectedValue), Convert.ToInt32(cmbMnth.SelectedValue), Convert.ToInt32(dt.Rows[0]["Branchid"].ToString()));
                if (dsresult.Tables[0].Rows.Count > 0)
                {
                    Load_AmbPIc();
                    //Image4.ImageUrl = "~/Ambience_Image/" + Lbl_Recptn.Text + cmbMnth.SelectedValue.ToString() + cmbYr.SelectedValue.ToString() + FileUpload4.FileName;
                    //Lbl_Picid4.Text = Convert.ToInt32(dsresult.Tables[0].Rows[0]["amb_pic_id"].ToString()).ToString();
                }
            }
            else Response.Write("<script>alert('Session time out!!!');</script>");
        }
    }
}