using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web_OperationDashboard
{
    public partial class Dashboard : System.Web.UI.Page
    {
        ServiceReference1.WebService_OperationDashboardSoapClient objService = new ServiceReference1.WebService_OperationDashboardSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)
                {
                    lbl_agr_alert.Text = "";
                    Load_Agreement_Due_date();
                    txtfrmdate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    txttodate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                    Load_Dashboard(txtfrmdate.Text, txttodate.Text);
                }
                else Response.Redirect("Login.aspx");
            }
        }
        public void Load_Agreement_Due_date()
        {
            DataTable dt_agrmnt_due = objService.get_AgreementRenewal_notifn().Tables[0];
            if(dt_agrmnt_due.Rows.Count>0)
            {
                lbl_agr_alert.Text = "Agreement Renewal Alert!!!";
                GridView_agr.DataSource = dt_agrmnt_due;
                GridView_agr.DataBind();
            }
            else
            {
                lbl_agr_alert.Text = "";
                GridView_agr.DataSource = null;
                GridView_agr.DataBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Load_Agreement_Due_date();
            Load_Dashboard(txtfrmdate.Text, txttodate.Text);
        }

        public void Load_Dashboard(string fromdate,string todate)
        {
            Lbl_name.Text = "Dashboard summary from " + txtfrmdate.Text + " to  " + txttodate.Text;
            DataTable dtCashPosition = new DataTable();
            dtCashPosition = objService.Get_Cashposition(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtCashPosition.Rows.Count > 0)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("BranchName", typeof(string));
                dtResult.Columns.Add("SystemCash", typeof(double));
                dtResult.Columns.Add("PhysicalCash", typeof(double));
                dtResult.Columns.Add("Difference", typeof(double));

                var custs = from a in dtCashPosition.AsEnumerable()
                            where a.Field<string>("branch").Contains("VALAPAD")
                            select a;
                
                var custs1 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("VAPALAD")
                             select a;
                
                var custs2 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("MEDICALS NEW")
                             select a;
                            
                decimal P_Cash = 0; decimal S_Cash = 0; 
                foreach (var p in custs)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                foreach (var p in custs1)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                foreach (var p in custs2)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }

                dtResult.Rows.Add("VALAPAD", S_Cash, P_Cash, P_Cash- S_Cash);
                //.....................................................................................................................
                var custs3 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("VADANA")
                             select a;

                var custs4 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("VATANA")
                             select a;
                             
                P_Cash = 0; S_Cash = 0; 

                foreach (var p in custs3)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                foreach (var p in custs4)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("VATANAPALLY", S_Cash, P_Cash, P_Cash-S_Cash);
                //.....................................................................................................................
                var custs5 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("CHERPU")
                             select a;
                             
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs5)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("CHERPU", S_Cash, P_Cash, P_Cash - S_Cash);

                //......................................................................................
                var custs6 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("KANJANY")
                             select a;
                            
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs6)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("KANJANY", S_Cash, P_Cash, P_Cash - S_Cash);

                //......................................................................................

                var custs7 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("KATTOOR")
                             select a;
                            
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs7)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }

                dtResult.Rows.Add("KATTOOR", S_Cash, P_Cash, P_Cash - S_Cash);
                //.......................................................................................

                var custs8 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("MicroLab")
                             select a;
                             
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs8)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }

                dtResult.Rows.Add("MICROLAB", S_Cash, P_Cash, P_Cash - S_Cash);
                //.......................................................................................
                var custs9 = from a in dtCashPosition.AsEnumerable()
                             where a.Field<string>("branch").Contains("MACARE VISION PLUS MATHILAKAM")
                             select a;

                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs9)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("MATHILAKAM OPTICALS", S_Cash, P_Cash, P_Cash - S_Cash);
                //...................................................................................

                var custs10 = from a in dtCashPosition.AsEnumerable()
                              where a.Field<string>("branch").Contains("VISION PLUS HSR LAYOUT")
                              select a;
               
                var custs11 = from a in dtCashPosition.AsEnumerable()
                              where a.Field<string>("branch").Contains("KAMANAHALLI")
                              select a;

                var custs111 = from a in dtCashPosition.AsEnumerable()
                              where a.Field<string>("branch").Contains("VISIONPLUS JAYANAGAR")
                              select a;

                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs10)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                foreach (var p in custs11)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                foreach (var p in custs111)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }

                dtResult.Rows.Add("BANGALORE OPTICALS", S_Cash, P_Cash, P_Cash - S_Cash);
                //.............................................................................
                var custs12 = from a in dtCashPosition.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS KECHERY")
                              select a;
                              
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs12)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("KECHERY OPTICALS", S_Cash, P_Cash, P_Cash - S_Cash);
                //..............................................................................
                var custs13 = from a in dtCashPosition.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS CHELAKKARA")
                              select a;
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs13)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("CHELAKKARA OPTICALS", S_Cash, P_Cash, P_Cash - S_Cash);
                //..............................................................................
                var custs14 = from a in dtCashPosition.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS KUNNATHANGADI")
                              select a;
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs14)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("KUNNATHANGADI OPTICALS", S_Cash, P_Cash, P_Cash - S_Cash);
                //..............................................................................
                var custs15 = from a in dtCashPosition.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS PUNNAYURKULAM")
                              select a;
                P_Cash = 0; S_Cash = 0; 
                foreach (var p in custs15)
                {
                    P_Cash = P_Cash + Convert.ToDecimal(p.Field<string>("physical_cash"));
                    S_Cash = S_Cash + Convert.ToDecimal(p.Field<string>("system_cash"));
                }
                dtResult.Rows.Add("PUNNAYURKULAM OPTICALS", S_Cash, P_Cash, P_Cash - S_Cash);

                //..............................................................................
                if (dtResult.Rows.Count > 0)
                {
                    GridView1.DataSource = dtResult;
                }
                else GridView1.DataSource = null; GridView1.DataBind();
            }

            DataTable dtBillCancel = new DataTable();
            dtBillCancel = objService.Get_BillCancelDetails(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtBillCancel.Rows.Count > 0)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("BranchName", typeof(string));
                dtResult.Columns.Add("Bill_Cancellation_Count", typeof(decimal));
                dtResult.Columns.Add("Bill_Cancellation_Amount", typeof(decimal));
                DataTable dt = dtBillCancel;
                //....................................................................................
                var custs = from a in dt.AsEnumerable()
                            where a.Field<string>("branch").Contains("VALAPAD")
                            select a;
                            
                decimal count_ = 0; decimal Amount_ = 0; 
                foreach (var p in custs)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("VALAPAD", count_, Amount_);
                //....................................................................................
                var custs1 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("VATANAP")
                             select a;
                             
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs1)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("VATANAPILLY", count_, Amount_);
                //.....................................................................................
                var custs2 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("CHERPU")
                             select a;
                             
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs2)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("CHERPU", count_, Amount_);
                //.....................................................................................
                var custs3 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KANJANY")
                             select a;
                             
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs3)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("KANJANY", count_, Amount_);
                //.....................................................................................
                var custs4 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KATTOOR")
                             select a;
                            
                count_ = 0; Amount_ = 0;
                foreach (var p in custs4)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("KATTOOR", count_, Amount_);
                //......................................................................................
                var custs5 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("MicroLab")
                             select a;
                             
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs5)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("MICROLAB", count_, Amount_);
                //....................................................................................
                var custs6 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("MACARE VISION PLUS MATHILAKAM")
                             select a;
                             
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs6)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("MATHILAKAM OPTICALS", count_, Amount_);
                //...................................................................................

                var custs7 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("VISION PLUS HSR LAYOUT")
                             select a;
               
                var custs8 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KAMANAHALLI")
                             select a;

                var custs1111 = from a in dt.AsEnumerable()
                               where a.Field<string>("branch").Contains("VISIONPLUS JAYANAGAR")
                               select a;

                count_ = 0; Amount_ = 0; 
                foreach (var p in custs7)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                foreach (var p in custs8)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                foreach (var p in custs1111)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }

                dtResult.Rows.Add("BANGALORE OPTICALS", count_, Amount_);
                //....................................................................................
                var custs12 = from a in dt.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS KECHERY")
                              select a;
                              
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs12)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("KECHERY OPTICALS", count_, Amount_);
                //...................................................................................
                var custs13 = from a in dt.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS CHELAKKARA")
                              select a;
               
                count_ = 0; Amount_ = 0;
                foreach (var p in custs13)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("CHELAKKARA OPTICALS", count_, Amount_);
                //...................................................................................
                var custs14 = from a in dt.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS KUNNATHANGADI")
                              select a;
               
                count_ = 0; Amount_ = 0;
                foreach (var p in custs14)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("KUNNATHANGADI OPTICALS", count_, Amount_);
                //...................................................................................
                var custs15 = from a in dt.AsEnumerable()
                              where a.Field<string>("branch").Contains("MACARE VISION PLUS PUNNAYURKULAM")
                              select a;
                
                count_ = 0; Amount_ = 0;
                foreach (var p in custs15)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("PUNNAYURKULAM OPTICALS", count_, Amount_);
                //...................................................................................
                if (dtResult.Rows.Count > 0)
                {
                    GridView2.DataSource = dtResult;
                }
                else GridView2.DataSource = null;
                GridView2.DataBind();
            }

            DataTable dtSReturn = new DataTable();
            dtSReturn = objService.Load_Sales_return(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtSReturn.Rows.Count > 0)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("BranchName", typeof(string));
                dtResult.Columns.Add("Sales_Return_Count", typeof(decimal));
                dtResult.Columns.Add("Sales_Return_Amount", typeof(decimal));
                DataTable dt = dtSReturn;

                var custs = from a in dt.AsEnumerable()
                            where a.Field<string>("branch").Contains("VAPALAD")
                            select a;
                
                var custs1 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("NEW")
                             select a;
                            
                decimal count_ = 0; decimal Amount_ = 0; 
                foreach (var p in custs)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                foreach (var p in custs1)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("VALAPAD", count_, Amount_);
                //.......................................................................................

                var custs2 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("VADANA")
                             select a;
                            
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs2)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("VADANAPPILLY", count_, Amount_);
                //........................................................................................

                var custs3 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("CHERPU")
                             select a;
                            
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs3)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("CHERPU", count_, Amount_);

                //.......................................................................................
                var custs4 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KANJANY")
                             select a;
                             
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs4)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("KANJANY", count_, Amount_);
                //.....................................................................................

                var custs5 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KATTOOR")
                             select a;
                             
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs5)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<string>("Amount"));
                }
                dtResult.Rows.Add("KATTOOR", count_, Amount_);

                //.....................................................................................

                dtResult.Rows.Add("MICROLAB", 0, 0);
                dtResult.Rows.Add("MATHILAKAM OPTICALS", 0, 0);
                dtResult.Rows.Add("BANGALORE OPTICALS", 0, 0);
                dtResult.Rows.Add("KECHERY OPTICALS", 0, 0);
                dtResult.Rows.Add("CHELAKKARA OPTICALS", 0, 0);
                dtResult.Rows.Add("KUNNATHANGADI OPTICALS", 0, 0); 
                dtResult.Rows.Add("PUNNAYURKULAM OPTICALS", 0, 0);

                if (dtResult.Rows.Count > 0)
                {
                    GridView3.DataSource = dtResult;
                }
                else GridView3.DataSource = null;
                GridView3.DataBind();
            }

            DataTable dtConsumption = new DataTable();
            dtConsumption = objService.Load_Consumption(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtConsumption.Rows.Count > 0)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("BranchName", typeof(string));
                dtResult.Columns.Add("Manual_Consumption", typeof(decimal));

                DataTable dt = dtConsumption;

                var custs = from a in dt.AsEnumerable()
                            where a.Field<string>("branch").Contains("VALAPAD")
                            select a;
                            
                decimal Amount_ = 0; 
                foreach (var p in custs)
                {
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("VALAPAD", Amount_);

                //.............................................................................

                var custs1 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("VATANA")
                             select a;
                             
                Amount_ = 0; 
                foreach (var p in custs1)
                {
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("VATANAPALLY", Amount_);

                //............................................................................

                var custs2 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("CHERPU")
                             select a;
                             
                Amount_ = 0; 
                foreach (var p in custs2)
                {
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("CHERPU", Amount_);

                //............................................................................

                var custs3 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KANJANY")
                             select a;
                             
                Amount_ = 0; 
                foreach (var p in custs3)
                {
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("KANJANY", Amount_);

                //..............................................................................

                var custs4 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KATTOOR")
                             select a;
                             
                Amount_ = 0; 
                foreach (var p in custs4)
                {
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("KATTOOR", Amount_);

                //.............................................................................

                var custs5 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("MicroLab")
                             select a;
                             
                Amount_ = 0; 
                foreach (var p in custs5)
                {
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("MICROLAB", Amount_);

                //...............................................................................

                dtResult.Rows.Add("MATHILAKAM OPTICALS", 0);
                dtResult.Rows.Add("BANGALORE OPTICALS", 0);
                dtResult.Rows.Add("KECHERY OPTICALS", 0);
                dtResult.Rows.Add("CHELAKKARA OPTICALS", 0);
                dtResult.Rows.Add("KUNNATHANGADI OPTICALS", 0);
                dtResult.Rows.Add("PUNNAYURKULAM OPTICALS", 0);

                if (dtResult.Rows.Count > 0)
                {
                    GridView4.DataSource = dtResult;
                }
                else GridView4.DataSource = null;
                GridView4.DataBind();
            }

            DataTable dtDedit = new DataTable();
            dtDedit = objService.Get_Debitnote_Created(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtDedit.Rows.Count > 0)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("BranchName", typeof(string));
                dtResult.Columns.Add("Debit_Note Created", typeof(decimal));
                dtResult.Columns.Add("Debit_Note Amount", typeof(decimal));

                DataTable dt = dtDedit;

                var custs = from a in dt.AsEnumerable()
                            where a.Field<string>("branch").Contains("VAPALAD")
                            select a;
         
                var custs1 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("NEW")
                             select a;

                decimal count_ = 0; decimal Amount_ = 0; 
                foreach (var p in custs)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }
                foreach (var p in custs1)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("VALAPAD", count_, Amount_);

                //.....................................................................................
                var custs2 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("VADANA")
                             select a;
         
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs2)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("VATANAPALLY", count_, Amount_);
                //......................................................................................
                var custs3 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("CHERPU")
                             select a;
               
                count_ = 0; Amount_ = 0; 
                foreach (var p in custs3)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("CHERPU", count_, Amount_);

                //......................................................................................
                var custs4 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KANJANY")
                             select a;
         
                count_ = 0; Amount_ = 0;
                foreach (var p in custs4)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("KANJANY", count_, Amount_);

                //......................................................................................

                var custs5 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KATTOOR")
                             select a;
                  
                count_ = 0; Amount_ = 0;
                foreach (var p in custs5)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    Amount_ = Amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("KATTOOR", count_, Amount_);
                //....................................................................................
                dtResult.Rows.Add("MICROLAB", 0, 0);
                dtResult.Rows.Add("MATHILAKAM OPTICALS", 0, 0);
                dtResult.Rows.Add("BANGALORE OPTICALS", 0, 0);
                dtResult.Rows.Add("KECHERY OPTICALS", 0, 0);
                dtResult.Rows.Add("CHELAKKARA OPTICALS", 0, 0);
                dtResult.Rows.Add("KUNNATHANGADI OPTICALS", 0, 0);
                dtResult.Rows.Add("PUNNAYURKULAM OPTICALS", 0, 0);

                if (dtResult.Rows.Count > 0)
                {
                    GridView5.DataSource = dtResult;
                }
                else GridView5.DataSource = null;
                GridView5.DataBind();
            }

            DataTable dtCreditAdj = new DataTable();
            dtCreditAdj = objService.Get_Creditnote_Adjust(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtCreditAdj.Rows.Count > 0)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("BranchName", typeof(string));
                dtResult.Columns.Add("Credit_Note Adjust", typeof(decimal));
                dtResult.Columns.Add("Credit_Note Amount", typeof(decimal));

                DataTable dt = dtCreditAdj;

                var custs = from a in dt.AsEnumerable()
                            where a.Field<string>("branch").Contains("VAPALAD")
                            select a;
                            
                var custs1 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("NEW")
                             select a;
                             
                decimal count_ = 0;decimal amount_ = 0; 
                foreach (var p in custs)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    amount_ = amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }
                foreach (var p in custs1)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    amount_ = amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("VALAPAD", count_,amount_);

                //.....................................................................................
                var custs2 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("VADANA")
                             select a;
                             
                count_ = 0;amount_ = 0; 
                foreach (var p in custs2)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    amount_ = amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("VATANAPALLY", count_,amount_);
                //......................................................................................
                var custs3 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("CHERPU")
                             select a;
                            
                count_ = 0;amount_ = 0; 
                foreach (var p in custs3)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    amount_ = amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("CHERPU", count_,amount_);

                //......................................................................................
                var custs4 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KANJANY")
                             select a;
                             
                count_ = 0;amount_ = 0; 
                foreach (var p in custs4)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    amount_ = amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("KANJANY", count_,amount_);

                //......................................................................................

                var custs5 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KATTOOR")
                             select a;
                            
                count_ = 0;amount_ = 0; 
                foreach (var p in custs5)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("Count"));
                    amount_ = amount_ + Convert.ToDecimal(p.Field<decimal>("Amount"));
                }

                dtResult.Rows.Add("KATTOOR", count_,amount_);
                //....................................................................................
                dtResult.Rows.Add("MICROLAB", 0, 0);
                dtResult.Rows.Add("MATHILAKAM OPTICALS", 0, 0);
                dtResult.Rows.Add("BANGALORE OPTICALS", 0, 0);
                dtResult.Rows.Add("KECHERY OPTICALS", 0, 0);
                dtResult.Rows.Add("CHELAKKARA OPTICALS", 0, 0);
                dtResult.Rows.Add("KUNNATHANGADI OPTICALS", 0, 0);
                dtResult.Rows.Add("PUNNAYURKULAM OPTICALS", 0, 0);

                if (dtResult.Rows.Count > 0)
                {
                    GridView6.DataSource = dtResult;
                }
                else GridView6.DataSource = null;
                GridView6.DataBind();
            }

            DataTable dtInventory = new DataTable();
            dtInventory = objService.Get_Chk_Inventory(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtInventory.Rows.Count > 0)
            {
                DataTable dtResult = new DataTable();
                dtResult.Columns.Add("BranchName", typeof(string));
                dtResult.Columns.Add("CheckedBy", typeof(decimal));
                dtResult.Columns.Add("Items", typeof(decimal));

                DataTable dt = dtInventory;

                var custs = from a in dt.AsEnumerable()
                            where a.Field<string>("branch").Contains("VAPALAD")
                            select a;
                
                var custs1 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("NEW")
                             select a;
                             
                decimal count_ = 0; decimal items = 0; 
                foreach (var p in custs)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("checked_by"));
                    items = items + Convert.ToDecimal(p.Field<decimal>("items"));
                }
                foreach (var p in custs1)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("checked_by"));
                    items = items + Convert.ToDecimal(p.Field<decimal>("items"));
                }

                dtResult.Rows.Add("VALAPAD", count_, items);

                //.....................................................................................
                var custs2 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("VADANA")
                             select a;
                             
                count_ = 0;items = 0; 
                foreach (var p in custs2)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("checked_by"));
                    items = items + Convert.ToDecimal(p.Field<decimal>("items"));
                }

                dtResult.Rows.Add("VATANAPALLY", count_, items);
                //......................................................................................
                var custs3 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("CHERPU")
                             select a;
                            
                count_ = 0;items = 0; 
                foreach (var p in custs3)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("checked_by"));
                    items = items + Convert.ToDecimal(p.Field<decimal>("items"));
                }

                dtResult.Rows.Add("CHERPU", count_, items);

                //......................................................................................
                var custs4 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KANJANY")
                             select a;
                             
                count_ = 0;items = 0; 
                foreach (var p in custs4)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("checked_by"));
                    items = items + Convert.ToDecimal(p.Field<decimal>("items"));
                }

                dtResult.Rows.Add("KANJANY", count_, items);

                //......................................................................................

                var custs5 = from a in dt.AsEnumerable()
                             where a.Field<string>("branch").Contains("KATTOOR")
                             select a;
                            
                count_ = 0;items = 0; 
                foreach (var p in custs5)
                {
                    count_ = count_ + Convert.ToDecimal(p.Field<decimal>("checked_by"));
                    items = items + Convert.ToDecimal(p.Field<decimal>("items"));
                }

                dtResult.Rows.Add("KATTOOR", count_, items);
                //....................................................................................
                dtResult.Rows.Add("MICROLAB", 0, 0);
                dtResult.Rows.Add("MATHILAKAM OPTICALS", 0, 0);
                dtResult.Rows.Add("BANGALORE OPTICALS", 0, 0);
                dtResult.Rows.Add("KECHERY OPTICALS", 0, 0);
                dtResult.Rows.Add("CHELAKKARA OPTICALS", 0, 0);
                dtResult.Rows.Add("KUNNATHANGADI OPTICALS", 0, 0);
                dtResult.Rows.Add("PUNNAYURKULAM OPTICALS", 0, 0);

                if (dtResult.Rows.Count > 0)
                {
                    GridView7.DataSource = dtResult;
                }
                else GridView7.DataSource = null;
                GridView7.DataBind();
            }

            DataTable dtOptical = new DataTable();
            dtOptical=objService.Select_OpticalStockEntry(txtfrmdate.Text, txttodate.Text).Tables[0];
            if (dtOptical.Rows.Count > 0)
            {
                GridView8.DataSource = dtOptical;
                Label1.Visible = true;
            }
            else
            {
                GridView8.DataSource = null;
                Label1.Visible = false;
            }
                GridView8.DataBind();
            
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            string Branch = GridView1.DataKeys[rowIndex].Values[0].ToString();
            Response.Redirect("~/Dashboard_InDetail.aspx?Parameter1=" +Branch+"&Parameter2=Cash_position&Parameter3="+txtfrmdate.Text+"&Parameter4="+txttodate.Text);

        }
        protected void GridView5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            string Branch = GridView5.DataKeys[rowIndex].Values[0].ToString(); //Dashboard_InDetail.aspx % 20 ?% 20Parameter1 % 20 = VALAPAD & Parameter2 = Cash_position & Parameter3 = 26 - 04 - 2011 & Parameter4 = 26 - 04 - 2023
            //Response.Redirect("~/Dashboard_InDetail.aspx?Parameter1 =" + Branch + "&Parameter2=Debitnote_Create&Parameter3=" + txtfrmdate.Text + "&Parameter4=" + txttodate.Text);
            Response.Redirect("~/Dashboard_InDetail.aspx?Parameter1=" + Branch + "&Parameter2=Debitnote_Create&Parameter3=" + txtfrmdate.Text + "&Parameter4=" + txttodate.Text);
        }
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            int rowIndex = ((sender as LinkButton).NamingContainer as GridViewRow).RowIndex;
            string Branch = GridView1.DataKeys[rowIndex].Values[0].ToString();
            Response.Redirect("~/Dashboard_InDetail.aspx?Parameter1=" + Branch + "&Parameter2=DailyInventory_Chk&Parameter3=" + txtfrmdate.Text + "&Parameter4=" + txttodate.Text);

        }

        protected void Btn_viewrpt_Click(object sender, EventArgs e)
        {
            
            DataTable dtDashboard = new DataTable();
            dtDashboard.Columns.Add("Unit"); dtDashboard.Columns.Add("SystemCash"); dtDashboard.Columns.Add("PhysicalCash"); dtDashboard.Columns.Add("BillCancel_Count");
            dtDashboard.Columns.Add("BillCancel_AMount"); dtDashboard.Columns.Add("SReturn_Count"); dtDashboard.Columns.Add("SReturn_Amount"); dtDashboard.Columns.Add("MCons_Value");
            dtDashboard.Columns.Add("Debit_Note"); dtDashboard.Columns.Add("Debit_NoteAmt"); dtDashboard.Columns.Add("Credit_Note"); dtDashboard.Columns.Add("Credit_Amount"); dtDashboard.Columns.Add("Inventory_ChkBy");
            dtDashboard.Columns.Add("Inventory_ChkItems");
            //dtDashboard.Rows.Add(((Label)GridView1.Rows[0].Cells[0].FindControl("lbl_branch")).Text,0,0,0,0,0,0,0,0,0,0,0,0);
            dtDashboard.Rows.Add(((Label)GridView1.Rows[0].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[0].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[0].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[0].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[0].Cells[0].FindControl("lbl_BAmt")).Text,
                                  ((Label)GridView3.Rows[0].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[0].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[0].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[0].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[0].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                  ((Label)GridView6.Rows[0].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[0].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[0].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[0].Cells[0].FindControl("lbl_Modul")).Text);
            
            dtDashboard.Rows.Add(((Label)GridView1.Rows[1].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[1].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[1].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[1].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[1].Cells[0].FindControl("lbl_BAmt")).Text,
                                  ((Label)GridView3.Rows[1].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[1].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[1].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[1].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[1].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                  ((Label)GridView6.Rows[1].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[1].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[1].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[1].Cells[0].FindControl("lbl_Modul")).Text);
            
            dtDashboard.Rows.Add(((Label)GridView1.Rows[2].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[2].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[2].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[2].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[2].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[2].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[2].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[2].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[2].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[2].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[2].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[2].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[2].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[2].Cells[0].FindControl("lbl_Modul")).Text);
            
            dtDashboard.Rows.Add(((Label)GridView1.Rows[3].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[3].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[3].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[3].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[3].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[3].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[3].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[3].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[3].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[3].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[3].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[3].Cells[0].FindControl("lbl_crtAmt")).Text,((Label)GridView7.Rows[3].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[3].Cells[0].FindControl("lbl_Modul")).Text);
            
            dtDashboard.Rows.Add(((Label)GridView1.Rows[4].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[4].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[4].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[4].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[4].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[4].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[4].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[4].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[4].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[4].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[4].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[4].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[4].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[4].Cells[0].FindControl("lbl_Modul")).Text);
           
            dtDashboard.Rows.Add(((Label)GridView1.Rows[5].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[5].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[5].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[5].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[5].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[5].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[5].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[5].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[5].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[5].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[5].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[5].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[5].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[5].Cells[0].FindControl("lbl_Modul")).Text);
            
            dtDashboard.Rows.Add(((Label)GridView1.Rows[6].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[6].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[6].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[6].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[6].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[6].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[6].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[6].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[6].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[6].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[6].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[6].Cells[0].FindControl("lbl_crtAmt")).Text,((Label)GridView7.Rows[6].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[6].Cells[0].FindControl("lbl_Modul")).Text);
           
            dtDashboard.Rows.Add(((Label)GridView1.Rows[7].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[7].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[7].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[7].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[7].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[7].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[7].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[7].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[7].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[7].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[7].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[7].Cells[0].FindControl("lbl_crtAmt")).Text,((Label)GridView7.Rows[7].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[7].Cells[0].FindControl("lbl_Modul")).Text);

            dtDashboard.Rows.Add(((Label)GridView1.Rows[8].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[8].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[8].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[8].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[8].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[8].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[8].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[8].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[8].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[8].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[8].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[8].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[8].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[8].Cells[0].FindControl("lbl_Modul")).Text);

            dtDashboard.Rows.Add(((Label)GridView1.Rows[9].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[9].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[9].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[9].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[9].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[9].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[9].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[9].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[9].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[9].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[9].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[9].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[9].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[9].Cells[0].FindControl("lbl_Modul")).Text);

            dtDashboard.Rows.Add(((Label)GridView1.Rows[10].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[10].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[10].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[10].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[10].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[10].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[10].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[10].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[10].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[10].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[10].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[10].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[10].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[10].Cells[0].FindControl("lbl_Modul")).Text);
            
            dtDashboard.Rows.Add(((Label)GridView1.Rows[11].Cells[0].FindControl("lbl_branch")).Text, ((Label)GridView1.Rows[11].Cells[0].FindControl("lbl_Scash")).Text, ((Label)GridView1.Rows[11].Cells[0].FindControl("lbl_Pcash")).Text, ((Label)GridView2.Rows[11].Cells[0].FindControl("lbl_BCount")).Text, ((Label)GridView2.Rows[11].Cells[0].FindControl("lbl_BAmt")).Text,
                                   ((Label)GridView3.Rows[11].Cells[0].FindControl("lbl_SCount")).Text, ((Label)GridView3.Rows[11].Cells[0].FindControl("lbl_SAmount")).Text, ((Label)GridView4.Rows[11].Cells[0].FindControl("lbl_MConsumption")).Text, ((Label)GridView5.Rows[11].Cells[0].FindControl("lbl_dbt")).Text, ((Label)GridView5.Rows[11].Cells[0].FindControl("lbl_dbtAmt")).Text,
                                   ((Label)GridView6.Rows[11].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView6.Rows[11].Cells[0].FindControl("lbl_crtAmt")).Text, ((Label)GridView7.Rows[11].Cells[0].FindControl("lbl_Module")).Text, ((Label)GridView7.Rows[11].Cells[0].FindControl("lbl_Modul")).Text);

            Session.Add("Dashboard_Rpt", dtDashboard);
            Response.Redirect("~/Dashboard_Report.aspx?Parameter3=" + txtfrmdate.Text + "&Parameter4=" + txttodate.Text); 
            
        }
    }
}