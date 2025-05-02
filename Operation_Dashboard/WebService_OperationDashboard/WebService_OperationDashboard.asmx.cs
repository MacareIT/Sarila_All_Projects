using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;

namespace WebService_OperationDashboard
{
    /// <summary>
    /// Summary description for WebService_OperationDashboard
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_OperationDashboard : System.Web.Services.WebService
    {
        OracleHelper objOrclHeplr = new OracleHelper();
        
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataSet Login(string username, string password)
        {
            DataSet dsLogin = objOrclHeplr.ExecuteDataSet("select * from login_users where username='" + username + "' and password='" + password + "'");
            return dsLogin;
        }

        [WebMethod]
        public DataSet Get_BillCancelDetails(string startdate, string enddate)
        {
            DataSet dsDashBoard = objOrclHeplr.ExecuteDataSet("select cm.branch_id,cm.name branch,(select count(*) from HOSPITAL.CLINIC_PAYMENT_MASTER_DELHIS pm join hospital.clinic_master c on pm.clinic_id=c.clinic_id where c.branch_id=cm.branch_id and to_date(pm.bill_date, 'dd-MM-yyyy') between to_date('" + startdate + "', 'dd-MM-yyyy') and to_date('" + enddate + "', 'dd-MM-yyyy')) count," +
                                                              "(select nvl(to_char(sum(pm.rcvd_amount),99999999.99), 0) from HOSPITAL.CLINIC_PAYMENT_MASTER_DELHIS pm join hospital.clinic_master c on pm.clinic_id = c.clinic_id where c.branch_id = cm.branch_id and to_date(pm.bill_date, 'dd-MM-yyyy') between to_date('" + startdate + "','dd-MM-yyyy') and to_date('" + enddate + "','dd-MM-yyyy')) Amount from hospital.clinic_master cm where cm.branch_id in (1256, 3458, 3250, 3153, 3465, 3114, 3412, 3469) " +
                                                              "union all select cm.branch_id,cm.name || ' Lab' branch,(select count(*) from HOSPITAL.DGN_BILL_CANCEL dc join hospital.dgn_bill_master bm on bm.bill_id = dc.bill_id join hospital.clinic_master c on c.branch_id = bm.branch_id where to_date(dc.approved_on, 'dd-MM-yyyy') between to_date('" + startdate + "','dd-MM-yyyy') and to_date('" + enddate + "','dd-MM-yyyy') and c.branch_id = cm.branch_id) count," +
                                                              "(select nvl(to_char(sum(bm.bill_amt),99999999.99), 0) from HOSPITAL.DGN_BILL_CANCEL dc join hospital.dgn_bill_master bm on bm.bill_id = dc.bill_id join hospital.clinic_master c on c.branch_id = bm.branch_id where to_date(dc.approved_on, 'dd-MM-yyyy') between to_date('" + startdate + "','dd-MM-yyyy') and to_date('" + enddate + "','dd-MM-yyyy') and c.branch_id = cm.branch_id) Amount from hospital.clinic_master cm where cm.branch_id in (1256, 3458, 3250, 3153, 3465) " +
                                                              "union all select cm.branch_id,cm.name || ' MicroLab' branch,(select count(*) from HOSPITAL.DGN_BILL_CANCEL dc join hospital.dgn_bill_master bm on bm.bill_id = dc.bill_id join hospital.clinic_master c on c.branch_id = bm.branch_id where to_date(dc.approved_on, 'dd-MM-yyyy') between to_date('" + startdate + "','dd-MM-yyyy') and to_date('" + enddate + "','dd-MM-yyyy') and c.branch_id = cm.branch_id) count," +
                                                              "(select nvl(to_char(sum(bm.bill_amt),99999999.99), 0) from HOSPITAL.DGN_BILL_CANCEL dc join hospital.dgn_bill_master bm on bm.bill_id = dc.bill_id join hospital.clinic_master c on c.branch_id = bm.branch_id where to_date(dc.approved_on, 'dd-MM-yyyy') between to_date('" + startdate + "','dd-MM-yyyy') and to_date('" + enddate + "','dd-MM-yyyy') and c.branch_id = cm.branch_id) Amount from hospital.clinic_master cm where " +
                                                              "cm.branch_id in (3143, 3295, 3300, 3191, 3199, 1257, 2386, 2592, 2646, 3139, 3215,3504,3513,3519,3531) " +
                                                              "union all select cm.branch_id,cm.name branch,(select count(*) from HOSPITAL.OPTICAL_CUST_ADVANCE ad where to_date(ad.tra_date, 'dd-MM-yyyy') between to_date('" + startdate + "', 'dd-MM-yyyy') and to_date('" + enddate + "', 'dd-MM-yyyy') and ad.status_id = 2 and ad.firm_id = 16 and ad.branch_id = cm.branch_id) count,(select nvl(to_char(sum(ad.advance_amount),99999999.99), 0)  from HOSPITAL.OPTICAL_CUST_ADVANCE ad " +
                                                              "where to_date(ad.tra_date, 'dd-MM-yyyy') between to_date('" + startdate + "','dd-MM-yyyy') and to_date('" + enddate + "','dd-MM-yyyy') and ad.status_id = 2 and ad.firm_id = 16 and ad.branch_id = cm.branch_id) Amount from hospital.clinic_master cm where cm.branch_id in (3464, 3284, 3449, 3459, 3451, 3487, 3486, 3476, 3481, 3482,3510,3512,3518)");
            return dsDashBoard;
        }

        [WebMethod]
        public DataSet Load_Sales_return(string startdate, string enddate)
        {
            DataSet dsSreturn = objOrclHeplr.ExecuteDataSet("select p.branch_id, p.branch_name branch,(select count(m.sr_no) count from HOSPITAL.PHARMA_SR_MASTER m  where to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') and m.branch_id = p.branch_id) count," +
                                                            "(select nvl(to_char(sum(m.sr_amt),99999999.99), 0)  from HOSPITAL.PHARMA_SR_MASTER m where to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') and m.branch_id = p.branch_id) Amount from hospital.pharmacy_master p where p.status = 1 and p.branch_id not in (3350, 3352, 3353)");

            return dsSreturn;
        }


        [WebMethod]
        public DataSet Load_Consumption(string startdate, string enddate)
        {
            DataSet dsSreturn = objOrclHeplr.ExecuteDataSet("select cm.branch_id,cm.name||'MicroLab' branch,(select nvl(sum(t.consumed_qty*v.unit_value),0)  from hospital.lab_manual_cons_dtl t, hospital.clinic_master p, hospital.dgn_test_master q, hospital.clinstore_item_master r," +
                                                            "hospital.clinstore_secondary_units s, hospital.clinstore_primary_units u, hospital.clinstore_item_unitrate v where to_date(t.tradt, 'dd-MM-yyyy') between to_date('" + startdate + "', 'dd-MM-yyyy') and to_date('" + enddate + "', 'dd-MM-yyyy') " +
                                                            "and t.branch_id = p.branch_id and t.test_id = q.test_id(+) and t.item_id = r.item_id and r.sec_unit_id = s.sec_unit_id and r.pri_unit_id = u.pri_unit_id and r.item_id = v.item_id and v.item_id = t.item_id and t.branch_id = v.branchid and t.branch_id = cm.branch_id) Amount " +
                                                            "from hospital.clinic_master cm where cm.branch_id in (3143, 3295, 3300, 3191, 3199, 1257, 2386, 2592, 2646, 3139, 3215,3504,3513,3519,3531) union all select cm.branch_id,cm.name branch,(select nvl(sum(t.consumed_qty * v.unit_value),0) from hospital.lab_manual_cons_dtl t, hospital.clinic_master p, " +
                                                            "hospital.dgn_test_master q, hospital.clinstore_item_master r,hospital.clinstore_secondary_units s, hospital.clinstore_primary_units u, hospital.clinstore_item_unitrate v where to_date(t.tradt, 'dd-MM-yyyy') between to_date('" + startdate + "', 'dd-MM-yyyy') and to_date('" + enddate + "', 'dd-MM-yyyy') " +
                                                            "and t.branch_id = p.branch_id and t.test_id = q.test_id(+) and t.item_id = r.item_id and r.sec_unit_id = s.sec_unit_id and r.pri_unit_id = u.pri_unit_id and r.item_id = v.item_id and v.item_id = t.item_id and t.branch_id = v.branchid and t.branch_id = cm.branch_id) Amount from hospital.clinic_master cm where cm.branch_id in (1256, 3250, 3458, 3153, 3465)");
            return dsSreturn;
        }

        [WebMethod]
        public DataSet Get_Debitnote_Created(string startdate, string enddate)
        {
            DataSet dsSreturn = objOrclHeplr.ExecuteDataSet("select m.branch_id, p.branch_name branch, count(m.pr_no) Count, sum(m.pr_value) Amount from hospital.pharma_pr_master m join hospital.pharmacy_master p on m.branch_id = p.branch_id " +
                                                          "where p.status = 1 and p.branch_id not in (3350, 3352, 3353) and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by m.branch_id, p.branch_name " +
                                                          "union select branch_id, branch_name branch, 0 Count, 0 Amount from hospital.pharmacy_master where branch_id not in (select branch_id from hospital.pharma_pr_master where to_date(tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')) and status = 1 and branch_id not in (3350, 3352, 3353)");

            return dsSreturn;
        }

        [WebMethod]
        public DataSet Get_Creditnote_Adjust(string startdate, string enddate)
        {
            DataSet dsSreturn = objOrclHeplr.ExecuteDataSet("select p.branch_id,p.branch_name branch,(select count(*) from HOSPITAL.PHARMA_ADJUSTCREDITNOTE ad join HOSPITAL.PHARMA_PR_MASTER pr on pr.pr_no = ad.prnumber " +
                                                            "join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id where to_date(ad.tra_dt, 'dd-MM-yyyy') " +
                                                            "between to_date('" + startdate + "', 'dd-MM-yyyy') and to_date('" + enddate + "', 'dd-MM-yyyy') and ph.firm_id = 16 and ph.branch_id = p.branch_id) count," +
                                                            "(select nvl(sum(ad.pramount),0) from HOSPITAL.PHARMA_ADJUSTCREDITNOTE ad join HOSPITAL.PHARMA_PR_MASTER pr on pr.pr_no = ad.prnumber join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id " +
                                                            "join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id where to_date(ad.tra_dt, 'dd-MM-yyyy') between to_date('" + startdate + "', 'dd-MM-yyyy') and to_date('" + enddate + "', 'dd-MM-yyyy') " +
                                                            "and ph.firm_id = 16 and ph.branch_id = p.branch_id) Amount from hospital.pharmacy_master p where p.status = 1 and p.branch_id not in (3350, 3352, 3353)");

            return dsSreturn;
        }

        [WebMethod]
        public DataSet Get_Cashposition(string startdate, string enddate)
        {
            
            DataSet dsSreturn = objOrclHeplr.ExecuteDataSet("select ca.branch_id, p.branch_name branch, nvl(to_char(sum(ca.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ca.physical_cash),99999999.99), 0) physical_cash " +
                                                            "from HOSPITAL.PHARMA_CASH_HANDOVER ca join hospital.pharmacy_master p on ca.branch_id = p.branch_id where p.status = 1 and p.branch_id not in (3350, 3352, 3353) and to_date(ca.tra_dt, 'dd-mm-yyyy') " +
                                                            "between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ca.branch_id, p.branch_name union select branch_id, branch_name branch, nvl(to_char(0,99999999.99), 0) system_cash, nvl(to_char(0,99999999.99), 0) physical_cash " +
                                                            "from hospital.pharmacy_master where branch_id not in (select branch_id from HOSPITAL.PHARMA_CASH_HANDOVER where to_date(tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')) " +
                                                            "and status = 1 and branch_id not in (3350, 3352, 3353) " +
                                                            "union all select hd.branch_id, c.name || 'MicroLab' branch, nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash from HOSPITAL.MACARE_CASH_HANDOVER hd join hospital.clinic_master c on hd.branch_id = c.branch_id " +
                                                            "where c.branch_id  in (3143, 3295, 3300, 3191, 3199, 1257, 2386, 2592, 2646, 3139, 3215,3504,3513,3519,3531) and to_date(hd.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hd.branch_id, c.name " +
                                                            "union select branch_id, name branch, nvl(to_char(0,99999999.99), 0) system_cash, nvl(to_char(0,99999999.99), 0) physical_cash from hospital.clinic_master where branch_id not in (select branch_id from HOSPITAL.MACARE_CASH_HANDOVER where to_date(tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')) " +
                                                            "and branch_id in (3143, 3295, 3300, 3191, 3199, 1257, 2386, 2592, 2646, 3139, 3215,3504,3513,3519,3531) " +
                                                            "union all select hc.branch_id, c.name branch, nvl(to_char(sum(hc.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hc.physical_cash),99999999.99), 0) physical_cash from HOSPITAL.MACARE_CASH_HANDOVER hc join hospital.clinic_master c on hc.branch_id = c.branch_id where c.branch_id  in (1256, 3458, 3250, 3153, 3465,3412, 3469) " +
                                                            "and to_date(hc.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hc.branch_id, c.name union select branch_id, name branch, nvl(to_char(0,99999999.99), 0) system_cash, nvl(to_char(0,99999999.99), 0) physical_cash from hospital.clinic_master " +
                                                            "where branch_id not in (select branch_id from HOSPITAL.MACARE_CASH_HANDOVER where to_date(entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')) and branch_id in (1256, 3458, 3250, 3153, 3465,3412, 3469) " +
                                                            "union all select hc.branch_id, c.name branch,nvl(to_char(sum(hc.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hc.physical_cash),99999999.99), 0) physical_cash from HOSPITAL.MACARE_CASH_HANDOVER hc join hospital.clinic_master c on hc.branch_id = c.branch_id where c.branch_id  in (3114) and to_date(hc.tra_dt, 'dd-mm-yyyy') " +
                                                            "between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hc.branch_id, c.name union select branch_id,name branch, nvl(to_char(0,99999999.99), 0) system_cash, nvl(to_char(0,99999999.99), 0) physical_cash from hospital.clinic_master where branch_id not in (select branch_id from HOSPITAL.MACARE_CASH_HANDOVER where to_date(tra_dt, 'dd-mm-yyyy') " +
                                                            "between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')) and branch_id in (3114) " +
                                                            "union all select hq.branch_id, c.name branch, nvl(to_char(sum(hq.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hq.physical_cash),99999999.99), 0) physical_cash from HOSPITAL.OPTICAL_CASH_HANDOVER hq join hospital.clinic_master c on hq.branch_id = c.branch_id where c.branch_id  in (3464, 3284, 3449, 3459, 3451, 3487, 3486, 3476, 3481, 3482,3510,3512,3518) " +
                                                            "and to_date(hq.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hq.branch_id, c.name union select branch_id, name branch, nvl(to_char(0,99999999.99), 0) system_cash, nvl(to_char(0,99999999.99), 0) physical_cash from hospital.clinic_master " +
                                                            "where branch_id not in (select branch_id from HOSPITAL.OPTICAL_CASH_HANDOVER where to_date(tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')) and branch_id in (3464, 3284, 3449, 3459, 3451, 3487, 3486, 3476, 3481, 3482, 3510,3512,3518)");

            return dsSreturn;
        }

        [WebMethod]
        public DataSet Get_Chk_Inventory(string startdate, string enddate)
        {
            DataSet dsSreturn = objOrclHeplr.ExecuteDataSet("select chk.branch_id, p.branch_name branch, count(distinct chk.checked_by) checked_by,count(distinct chk.item_id) items from HOSPITAL.PHARMA_STOCK_CHECKING chk join hospital.pharma_item_master itm on chk.item_id = itm.item_id join hospital.pharmacy_master p on chk.branch_id = p.branch_id " +
                "where p.status = 1 and p.branch_id not in (3350, 3352, 3353) and to_date(chk.checked_on, 'dd-mm-yyyy') between to_date('"+startdate+"', 'dd-mm-yyyy') and to_date('"+enddate+"', 'dd-mm-yyyy') and chk.checked_by is not null group by chk.branch_id, p.branch_name union select branch_id, branch_name branch, 0 checked_by, 0 items from hospital.pharmacy_master " +
                "where branch_id not in (select branch_id from HOSPITAL.PHARMA_STOCK_CHECKING chk where to_date(chk.checked_on, 'dd-mm-yyyy') between to_date('"+startdate+"', 'dd-mm-yyyy') and to_date('"+enddate+"', 'dd-mm-yyyy') and checked_by is not null) and status = 1 and branch_id not in (3350, 3352, 3353)");
            return dsSreturn;
        }

        [WebMethod]
        public DataSet select_user()
        {
            DataSet ds_user = objOrclHeplr.ExecuteDataSet("select * from login_users");
            return ds_user;
        }
        [WebMethod]
        public DataSet Load_CashPosition_InDtl(string branch, string startdate, string enddate)
        {
            DataSet ds_CashVal = new DataSet();
            if (branch == "VALAPAD")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ca.branch_id, p.branch_name branch,'' counter_name,nvl(to_char(sum(ca.system_cash),99999999.99), 0) system_cash,nvl(to_char(sum( ca.physical_cash),99999999.99), 0) physical_cash,nvl(to_char(sum(ca.physical_cash),99999999.99), 0) - nvl(to_char(sum( ca.system_cash),99999999.99), 0) difference,ca.reason,to_char(ca.tra_dt,'dd-MM-yyyy') tra_dt,ca.tfr_by,ca.rcvd_by " +
                    "from HOSPITAL.PHARMA_CASH_HANDOVER ca join hospital.pharmacy_master p on ca.branch_id = p.branch_id where p.status = 1 and p.branch_id in (2435, 3348) and to_date(ca.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') " +
                    "and to_date('" + enddate + "', 'dd-mm-yyyy') group by ca.branch_id, p.branch_name,ca.reason,ca.tra_dt,ca.tfr_by,ca.rcvd_by union all select DISTINCT hd.branch_id, c.name branch,ct.counter_name, nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) - nvl(to_char(sum(hd.system_cash),99999999.99), 0) difference, hd.reason_today reason,to_char(hd.tra_dt,'dd-MM-yyyy') tra_dt, hd.tfr_by, hd.rcvd_by from " +
                    "HOSPITAL.MACARE_CASH_HANDOVER hd join hospital.clinic_master c on hd.branch_id = c.branch_id join hospital.macare_bill_counter ct on ct.counter_id=hd.counter_id where c.branch_id  in (1256) and to_date(hd.tra_dt, 'dd-MM-yyyy') between to_date('"+startdate+"', 'dd-mm-yyyy') " +
                    "and to_date('"+enddate+ "', 'dd-mm-yyyy') and (ct.counter_name is null or ct.counter_name not like '%Clinic%') group by hd.branch_id, c.name,ct.counter_name,hd.tra_dt,hd.tfr_by,hd.rcvd_by,hd.tra_dt,hd.tfr_by, hd.rcvd_by,hd.reason_today union all select DISTINCT hd.branch_id, c.name branch,ct.counter_name, nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) - nvl(to_char(sum(hd.system_cash),99999999.99), 0) difference, hd.reason_today reason,to_char(hd.tra_dt,'dd-MM-yyyy') tra_dt, hd.tfr_by, hd.rcvd_by from " +
                    "HOSPITAL.MACARE_CASH_HANDOVER hd join hospital.clinic_master c on hd.branch_id = c.branch_id join hospital.macare_bill_counter ct on ct.counter_id=hd.counter_id where c.branch_id  in (3114) and to_date(hd.tra_dt, 'dd-MM-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') " +
                    "and to_date('" + enddate + "', 'dd-mm-yyyy') and (ct.counter_name is not null) group by hd.branch_id, c.name,ct.counter_name,hd.tra_dt,hd.tfr_by,hd.rcvd_by,hd.tra_dt,hd.tfr_by, hd.rcvd_by,hd.reason_today " +
                    "union all select DISTINCT ho.branch_id, c.name branch,'' counter_name, " +
                    "nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference, ho.reason, to_char(ho.tra_dt,'dd-MM-yyyy') tra_dt, ho.tfr_by, ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  in (3284) " +
                    "and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");

            }
            else if (branch == "VATANAPALLY")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ca.branch_id, p.branch_name branch, nvl(to_char(sum(ca.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum( ca.physical_cash),99999999.99), 0) physical_cash,nvl(to_char(sum(ca.physical_cash),99999999.99), 0) - nvl(to_char(sum( ca.system_cash),99999999.99), 0) difference,ca.reason,to_char(ca.entered_date,'dd-MM-yyyy') entered_date,ca.tfr_by,ca.rcvd_by " +
                    "from HOSPITAL.PHARMA_CASH_HANDOVER ca join hospital.pharmacy_master p on ca.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3391) and to_date(ca.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') " +
                    "and to_date('" + enddate + "', 'dd-mm-yyyy') group by ca.branch_id, p.branch_name,ca.reason,ca.entered_date,ca.tfr_by,ca.rcvd_by union all select DISTINCT hd.branch_id, c.name branch,  nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) - nvl(to_char(sum(hd.system_cash),99999999.99), 0) difference, hd.reason_today reason, to_char(hd.entered_date,'dd-MM-yyyy') entered_date, hd.tfr_by, hd.rcvd_by from HOSPITAL.MACARE_CASH_HANDOVER hd " +
                    "join hospital.clinic_master c on hd.branch_id = c.branch_id where c.branch_id  in (3250) and to_date(hd.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hd.branch_id, c.name,hd.tra_dt,hd.tfr_by,hd.rcvd_by,hd.entered_date,hd.tfr_by, hd.rcvd_by,hd.reason_today union all select DISTINCT ho.branch_id, c.name branch, " +
                    "nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference, ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date, ho.tfr_by, ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  in (3449) " +
                    "and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");
            }
            else if (branch == "CHERPU")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ca.branch_id, p.branch_name branch, nvl(to_char(sum(ca.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum( ca.physical_cash),99999999.99), 0) physical_cash,nvl(to_char(sum(ca.physical_cash),99999999.99), 0) - nvl(to_char(sum( ca.system_cash),99999999.99), 0) difference,ca.reason,to_char(ca.entered_date,'dd-MM-yyyy') entered_date,ca.tfr_by,ca.rcvd_by " +
                     "from HOSPITAL.PHARMA_CASH_HANDOVER ca join hospital.pharmacy_master p on ca.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3463) and to_date(ca.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') " +
                     "and to_date('"+enddate+ "', 'dd-mm-yyyy') group by ca.branch_id, p.branch_name,ca.reason,ca.entered_date,ca.tfr_by,ca.rcvd_by union all select DISTINCT hd.branch_id, c.name branch, nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) - nvl(to_char(sum(hd.system_cash),99999999.99), 0) difference, hd.reason_today reason, to_char(hd.entered_date,'dd-MM-yyyy') entered_date, hd.tfr_by, hd.rcvd_by from HOSPITAL.MACARE_CASH_HANDOVER hd " +
                     "join hospital.clinic_master c on hd.branch_id = c.branch_id where c.branch_id  in (3469,3465) and to_date(hd.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hd.branch_id, c.name,hd.entered_date,hd.tfr_by,hd.rcvd_by,hd.tra_dt,hd.tfr_by, hd.rcvd_by,hd.reason_today union all select DISTINCT ho.branch_id, c.name branch, " +
                     "nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference, ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date, ho.tfr_by, ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  in (3464) " +
                     "and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");

            }
            else if (branch == "KANJANY")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ca.branch_id, p.branch_name branch, nvl(to_char(sum(ca.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum( ca.physical_cash),99999999.99), 0) physical_cash,nvl(to_char(sum(ca.physical_cash),99999999.99), 0) - nvl(to_char(sum( ca.system_cash),99999999.99), 0) difference,ca.reason,to_char(ca.entered_date,'dd-MM-yyyy') entered_date,ca.tfr_by,ca.rcvd_by " +
                     "from HOSPITAL.PHARMA_CASH_HANDOVER ca join hospital.pharmacy_master p on ca.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3460) and to_date(ca.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') " +
                     "and to_date('" + enddate + "', 'dd-mm-yyyy') group by ca.branch_id, p.branch_name,ca.reason,ca.entered_date,ca.tfr_by,ca.rcvd_by union all select DISTINCT hd.branch_id, c.name branch, nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) - nvl(to_char(sum(hd.system_cash),99999999.99), 0) difference, hd.reason_today reason, to_char(hd.entered_date,'dd-MM-yyyy') entered_date, hd.tfr_by, hd.rcvd_by from HOSPITAL.MACARE_CASH_HANDOVER hd " +
                     "join hospital.clinic_master c on hd.branch_id = c.branch_id where c.branch_id  in (3458) and to_date(hd.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hd.branch_id, c.name,hd.entered_date,hd.tfr_by,hd.rcvd_by,hd.tfr_by, hd.rcvd_by,hd.reason_today union all select DISTINCT ho.branch_id, c.name branch, " +
                     "nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference, ho.reason, to_char(ho.tra_dt,'dd-MM-yyyy') entered_date, ho.tfr_by, ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  in (3459) " +
                     "and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");

            }
            else if (branch == "KATTOOR")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ca.branch_id, p.branch_name branch, nvl(to_char(sum(ca.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum( ca.physical_cash),99999999.99), 0) physical_cash,nvl(to_char(sum(ca.physical_cash),99999999.99), 0) - nvl(to_char(sum( ca.system_cash),99999999.99), 0) difference,ca.reason,to_char(ca.entered_date,'dd-MM-yyyy') entered_date,ca.tfr_by,ca.rcvd_by " +
                     "from HOSPITAL.PHARMA_CASH_HANDOVER ca join hospital.pharmacy_master p on ca.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3390) and to_date(ca.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') " +
                     "and to_date('" + enddate + "', 'dd-mm-yyyy') group by ca.branch_id, p.branch_name,ca.reason,ca.entered_date,ca.tfr_by,ca.rcvd_by union all select DISTINCT hd.branch_id, c.name branch, nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) - nvl(to_char(sum(hd.system_cash),99999999.99), 0) difference, hd.reason_today reason, to_char(hd.entered_date,'dd-MM-yyyy') entered_date, hd.tfr_by, hd.rcvd_by from HOSPITAL.MACARE_CASH_HANDOVER hd " +
                     "join hospital.clinic_master c on hd.branch_id = c.branch_id where c.branch_id  in (3412,3153) and to_date(hd.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hd.branch_id, c.name,hd.entered_date,hd.tfr_by,hd.rcvd_by,hd.tfr_by, hd.rcvd_by,hd.reason_today union all select DISTINCT ho.branch_id, c.name branch, " +
                     "nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference, ho.reason, to_char(ho.tra_dt,'dd-MM-yyyy') entered_date, ho.tfr_by, ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  in (3451) " +
                     "and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");
            }

            else if (branch == "MICROLAB")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT hd.branch_id, c.name branch, nvl(to_char(sum(hd.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(hd.physical_cash),99999999.99), 0) - nvl(to_char(sum(hd.system_cash),99999999.99), 0) difference,hd.reason_today reason,to_char(hd.entered_date,'dd-MM-yyyy') entered_date,hd.tfr_by,hd.rcvd_by from HOSPITAL.MACARE_CASH_HANDOVER hd join hospital.clinic_master c on hd.branch_id = c.branch_id " +
                    "where c.branch_id  in (3143, 3295, 3300, 3191, 3199, 1257, 2386, 2592, 2646, 3139, 3215,3504,3513,3519,3531) and to_date(hd.entered_date, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by hd.branch_id, c.name,hd.entered_date,hd.tfr_by,hd.rcvd_by,hd.tfr_by, hd.rcvd_by,hd.reason_today ");
            }

            else if (branch == "MATHILAKAM OPTICALS")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ho.branch_id, c.name branch,nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference,ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date,ho.tfr_by,ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  " +
                    "in (3486) and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");
            }

            else if (branch == "BANGALORE OPTICALS")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ho.branch_id, c.name branch,nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference,ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date,ho.tfr_by,ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  " +
                    "in (3481,3482,3476)  and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");
            }

            else if (branch == "KECHERY OPTICALS")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ho.branch_id, c.name branch,nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference,ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date,ho.tfr_by,ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  " +
                    "in (3487)  and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");
            }
            else if(branch == "CHELAKKARA OPTICALS")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ho.branch_id, c.name branch,nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference,ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date,ho.tfr_by,ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  " +
                    "in (3510)  and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");

            }
            else if(branch== "KUNNATHANGADI OPTICALS")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ho.branch_id, c.name branch,nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference,ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date,ho.tfr_by,ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  " +
                   "in (3512)  and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");

            }
            else if (branch == "PUNNAYURKULAM OPTICALS")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select DISTINCT ho.branch_id, c.name branch,nvl(to_char(sum(ho.system_cash),99999999.99), 0) system_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) physical_cash, nvl(to_char(sum(ho.physical_cash),99999999.99), 0) - nvl(to_char(sum(ho.system_cash),99999999.99), 0) difference,ho.reason,to_char(ho.tra_dt,'dd-MM-yyyy') entered_date,ho.tfr_by,ho.rcvd_by from HOSPITAL.OPTICAL_CASH_HANDOVER ho join hospital.clinic_master c on ho.branch_id = c.branch_id where c.branch_id  " +
                   "in (3518)  and to_date(ho.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') group by ho.branch_id, c.name,ho.reason,ho.tra_dt, ho.tfr_by, ho.rcvd_by");

            }
            return ds_CashVal;
        }

        [WebMethod]
        public DataSet Load_DebitCreate_InDtl(string branch, string startdate, string enddate)
        {
            DataSet ds_CashVal = new DataSet();
            if (branch == "VALAPAD")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select m.branch_id, p.branch_name branch, m.pr_no,m.amount,m.discount, m.pr_value,m.tra_dt,supp.supplier_name from hospital.pharma_pr_master m join hospital.pharmacy_master p on m.branch_id = p.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = m.supplier_id where p.status = 1 and p.branch_id in (2435, 3348) and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')");

            }
            else if (branch == "VATANAPALLY")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select m.branch_id, p.branch_name branch, m.pr_no,m.amount,m.discount, m.pr_value,m.tra_dt,supp.supplier_name from hospital.pharma_pr_master m join hospital.pharmacy_master p on m.branch_id = p.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = m.supplier_id where p.status = 1 and p.branch_id in (3391) and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')");
            }
            else if (branch == "CHERPU")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select m.branch_id, p.branch_name branch, m.pr_no,m.amount,m.discount, m.pr_value,m.tra_dt,supp.supplier_name from hospital.pharma_pr_master m join hospital.pharmacy_master p on m.branch_id = p.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = m.supplier_id where p.status = 1 and p.branch_id in (3463) and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')");
            }
            else if (branch == "KANJANY")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select m.branch_id, p.branch_name branch, m.pr_no,m.amount,m.discount, m.pr_value,m.tra_dt,supp.supplier_name from hospital.pharma_pr_master m join hospital.pharmacy_master p on m.branch_id = p.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = m.supplier_id where p.status = 1 and p.branch_id in (3460) and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')");
            }
            else if (branch == "KATTOOR")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select m.branch_id, p.branch_name branch, m.pr_no,m.amount,m.discount, m.pr_value,m.tra_dt,supp.supplier_name from hospital.pharma_pr_master m join hospital.pharmacy_master p on m.branch_id = p.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = m.supplier_id where p.status = 1 and p.branch_id in (3390) and to_date(m.tra_dt, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy')");
            }

            return ds_CashVal;
        }

        [WebMethod]
        public DataSet Select_OpticalStockEntry(string fromdte, string todate)
        {
            DataSet ds_Stock = objOrclHeplr.ExecuteDataSet("select distinct st.branch_id,cm.name,st.category,st.stock,st.pstock,st.entered_by,st.entered_date,st.pstock-st.stock diff from Operation_Optical_StockEntry st " +
                "join hospital.clinic_master cm on st.branch_id = cm.branch_id where  to_date(st.entered_date, 'dd-MM-yyyy') between to_date('"+fromdte+"', 'dd-MM-yyyy') " +
                "and to_date('"+todate+"', 'dd-MM-yyyy') order by st.branch_id, st.category");//EXTRACT (MONTH FROM to_date(Entered_date,'dd-MM-yyyy')) ='" + month+ "' and EXTRACT (YEAR FROM to_date(Entered_date,'dd-MM-yyyy')) = '" + year+"'
            return ds_Stock;
        }

        [WebMethod]
        public DataSet Load_Inventory_Chk(string branch, string startdate, string enddate)
        {
            DataSet ds_CashVal = new DataSet();
            if (branch == "VALAPAD")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select chk.branch_id, p.branch_name branch, chk.item_id items,itm.item_name,chk.system_stock,chk.physical_stock,chk.difference,chk.checked_by checked_by,chk.checked_on from " +
                    "HOSPITAL.PHARMA_STOCK_CHECKING chk join hospital.pharma_item_master itm on chk.item_id = itm.item_id join hospital.pharmacy_master p on chk.branch_id = p.branch_id where p.status = 1 and p.branch_id in (2435, 3348) " +
                    "and to_date(chk.checked_on, 'dd-mm-yyyy') between to_date('"+startdate+"', 'dd-mm-yyyy') and to_date('"+enddate+ "', 'dd-mm-yyyy') and chk.checked_by is not null order by chk.checked_on, chk.checked_by");

            }
            else if (branch == "VATANAPALLY")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select chk.branch_id, p.branch_name branch, chk.item_id items,itm.item_name,chk.system_stock,chk.physical_stock,chk.difference,chk.checked_by checked_by,chk.checked_on from " +
                    "HOSPITAL.PHARMA_STOCK_CHECKING chk join hospital.pharma_item_master itm on chk.item_id = itm.item_id join hospital.pharmacy_master p on chk.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3391) " +
                    "and to_date(chk.checked_on, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') and chk.checked_by is not null order by chk.checked_on, chk.checked_by");
            }
            else if (branch == "CHERPU")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select chk.branch_id, p.branch_name branch, chk.item_id items,itm.item_name,chk.system_stock,chk.physical_stock,chk.difference,chk.checked_by checked_by,chk.checked_on from " +
                    "HOSPITAL.PHARMA_STOCK_CHECKING chk join hospital.pharma_item_master itm on chk.item_id = itm.item_id join hospital.pharmacy_master p on chk.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3463) " +
                    "and to_date(chk.checked_on, 'dd-mm-yyyy') between to_date('" + startdate + "', 'dd-mm-yyyy') and to_date('" + enddate + "', 'dd-mm-yyyy') and chk.checked_by is not null order by chk.checked_on, chk.checked_by");
            }
            else if (branch == "KANJANY")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select chk.branch_id, p.branch_name branch, chk.item_id items,itm.item_name,chk.system_stock,chk.physical_stock,chk.difference,chk.checked_by checked_by,chk.checked_on from " +
                   "HOSPITAL.PHARMA_STOCK_CHECKING chk join hospital.pharma_item_master itm on chk.item_id = itm.item_id join hospital.pharmacy_master p on chk.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3460) " +
                   "and to_date(chk.checked_on, 'dd-mm-yyyy') between to_date('"+startdate+"', 'dd-mm-yyyy') and to_date('"+enddate+ "', 'dd-mm-yyyy') and chk.checked_by is not null order by chk.checked_on, chk.checked_by");
            }
            else if (branch == "KATTOOR")
            {
                ds_CashVal = objOrclHeplr.ExecuteDataSet("select chk.branch_id, p.branch_name branch, chk.item_id items,itm.item_name,chk.system_stock,chk.physical_stock,chk.difference,chk.checked_by checked_by,chk.checked_on from " +
                   "HOSPITAL.PHARMA_STOCK_CHECKING chk join hospital.pharma_item_master itm on chk.item_id = itm.item_id join hospital.pharmacy_master p on chk.branch_id = p.branch_id where p.status = 1 and p.branch_id in (3390) " +
                   "and to_date(chk.checked_on, 'dd-mm-yyyy') between to_date('"+startdate+"', 'dd-mm-yyyy') and to_date('"+enddate+ "', 'dd-mm-yyyy') and chk.checked_by is not null order by chk.checked_on, chk.checked_by");
            }
            return ds_CashVal;
        }

        //......................................................Agreement Alert...........................................................

        [WebMethod]
        public int Insert_AgreementRenewal(int agrmnt_id, string agrmnt_type, string agrmnt_party, string date_of_exectn, string next_renewal, string first_alert, string second_alert, string third_alert, string updated_on, string updated_by)
        {
            int id = 0;
            string query = "";
            query = "select nvl(max(agrmnt_id),0)+1 from AGREEMENT_RENEWAL";
            DataTable dt = objOrclHeplr.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into AGREEMENT_RENEWAL values (" + id+ ",'" + agrmnt_type + "','" + agrmnt_party + "','" + date_of_exectn + "','" + next_renewal + "','" + first_alert + "','" + second_alert + "','" + third_alert + "','" + updated_on + "','" + updated_by + "')";
            id = objOrclHeplr.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int update_AgreementRenewal(int agrmnt_id, string agrmnt_type, string agrmnt_party, string date_of_exectn, string next_renewal, string first_alert, string second_alert, string third_alert, string updated_on, string updated_by)
        {
            int id = 0;
            string query = "";
            query = "update AGREEMENT_RENEWAL set agrmnt_type='" + agrmnt_type + "',agrmnt_party='" + agrmnt_party + "',date_of_execution='" + date_of_exectn + "',next_renewal='" + next_renewal + "',first_alert='" + first_alert + "',second_alert='" + second_alert + "',third_alert='" + third_alert + "',updated_on='" + updated_on + "',updated_by='" + updated_by + "' where agrmnt_id=" + agrmnt_id + "";
            id = objOrclHeplr.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Get_grid_Agrmnt_renewal()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from AGREEMENT_RENEWAL");
            DS = objOrclHeplr.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public int delete_AgreementRenewal(int agrmnt_id)
        {
            int id = 0;
            string query = "";
            query = "delete from AGREEMENT_RENEWAL  where agrmnt_id=" + agrmnt_id + "";
            id = objOrclHeplr.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet get_AgreementRenewal_notifn()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = "select a.agrmnt_type Agreement_type,a.agrmnt_party Agreement_Party,a.date_of_execution,a.next_renewal " +
                "from agreement_renewal a where to_date(a.next_renewal, 'dd-MM-yyyy') <= to_date(sysdate, 'dd-MM-yyyy') or to_date(a.first_alert,'dd-MM-yyyy')<= to_date(sysdate, 'dd-MM-yyyy') " +
                "or to_date(a.second_alert,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy') or to_date(a.third_alert,'dd-MM-yyyy')< to_date(sysdate, 'dd-MM-yyyy')";
            DS = objOrclHeplr.ExecuteDataSet(query);
            return DS;
        }

    }
}
