using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pharmacy_Service
{
    /// <summary>
    /// Summary description for Pharma_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Pharma_Service : System.Web.Services.WebService
    {

        public DataSet ds;
        public DataTable dt;
        public OracleHelper Objorclhelper = new OracleHelper();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public DataSet Validate_TaskLogin(string username, string password)
        {
            ds = new DataSet();
            string query = "select * from LOGIN_USERS where username='" + username + "' and password='" + password + "' and active=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Hospital_pharmacy_Branch()
        {
            ds = new DataSet();
            string query = "select t.branch_id,t.branch_name from HOSPITAL.PHARMACY_MASTER t where t.firm_id=16  and t.STATUS=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Fill_OTCItems()
        {
            ds = new DataSet();
            string query = "select t.item_id,t.item_name,c.category_name,c.category_id from HOSPITAL.PHARMA_ITEM_MASTER t join hospital.pharma_medicine_category c on t.category_id = c.category_id where t.group_id = 4";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Fill_OTCItems_DateRange(string frmdate, string todate, string branchid)
        {
            //ds = new DataSet();
            //string query = "select t.* from HOSPITAL.PHARMA_SALES_MASTER t where t.tra_dt between '" + frmdate + "' and '" + todate + "' and t.home_delivery!='N' and t.branch_id='" + Convert.ToInt32(branchid) + "'";
            //ds = Objorclhelper.ExecuteDataset(query);
            //return ds;
            ds = new DataSet();
            string query = "select sum(t.total) Total, t1.bill_no,t1.tra_dt,t1.patient from HOSPITAL.PHARMA_SALES_DTL t join HOSPITAL.PHARMA_SALES_MASTER t1 on t1.bill_no=t.bill_no join HOSPITAL.PHARMA_ITEM_MASTER itm on t.item_id = itm.item_id where  t1.branch_id='" + Convert.ToInt32(branchid) + "' and t1.tra_dt between '" + frmdate + "' and '" + todate + "' and  t1.home_delivery != 'N' and itm.group_id = 4 group by t1.bill_no,t1.tra_dt,t1.patient";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Fill_OTCItems_BillNo(string billno)
        {
            ds = new DataSet();
            //string query = "select t.*,t1.item_name from HOSPITAL.PHARMA_SALES_DTL t join HOSPITAL.PHARMA_ITEM_MASTER t1 on t.item_id=t1.item_id where t.bill_no='" + billno + "' and t1.group_id = 4";
            string query = "select t1.bill_no,t1.tra_dt,itm.item_name,t.* from HOSPITAL.PHARMA_SALES_DTL t join HOSPITAL.PHARMA_SALES_MASTER t1 on t1.bill_no=t.bill_no join HOSPITAL.PHARMA_ITEM_MASTER itm on t.item_id = itm.item_id where itm.group_id = 4 and t1.bill_no = '"+billno+"'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Inventory_BarcodedItems(string branchid)
        {
            ds = new DataSet();
            string query = "select t1.item_name,t.batch_no,t.expiry_dt,t.pri_cost,t.pri_mrp,t.pri_stock,t.conv_units,t.sec_stock,t.order_no,t.invoice_id,t.margin,t.quantity,t.branch_id from HOSPITAL.PHARMA_INVENTORY t join HOSPITAL.PHARMA_ITEM_MASTER t1 on t1.item_id = t.item_id left outer join HOSPITAL.PHARMA_INVOICE_MASTER m on t.invoice_id = m.invoice_id where t.barcode = 'NULL' and t.branch_id = " + branchid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Inventory_NotBarcodedItems(string branchid)
        {
            ds = new DataSet();
            string query = "select t1.item_name,t.batch_no,t.expiry_dt,t.pri_cost,t.pri_mrp,t.pri_stock,t.conv_units,t.sec_stock,t.order_no,t.invoice_id,t.margin,t.quantity,t.branch_id from HOSPITAL.PHARMA_INVENTORY t join HOSPITAL.PHARMA_ITEM_MASTER t1 on t1.item_id = t.item_id left outer join HOSPITAL.PHARMA_INVOICE_MASTER m on t.invoice_id = m.invoice_id where t.barcode != 'NULL' and t.branch_id = "+branchid+"";
            ds = Objorclhelper.ExecuteDataset(query);

            return ds;
        }
        [WebMethod]
        public DataSet Sales_Report(string branchid,string frmdt,string todt)
        {
            ds = new DataSet();
            string query = "select itm.item_name,itm.item_id,sum(t.quantity) qty,t.batch_no,rc.rack_name,v.qty from hospital.pharma_sales_master s " +
                            "join HOSPITAL.PHARMA_SALES_DTL t on t.bill_no = s.bill_no "+
                            "join HOSPITAL.PHARMA_ITEM_MASTER itm on t.item_id = itm.item_id left outer " +
                            "join HOSPITAL.PHARMA_ITEM_LOCATION loc on loc.item_id = t.item_id left outer " +
                            "join HOSPITAL.PHARMA_RACK_MASTER rc on loc.rack_id = rc.rack_id " +
                            "join(select inv.item_id, inv.batch_no, sum(inv.quantity) qty from hospital.pharma_inventory inv " +
                            "where inv.branch_id = "+branchid+" group by inv.item_id, inv.batch_no)v on t.item_id = v.item_id and t.batch_no = v.batch_no " +
                            "where to_date(s.tra_dt,'dd-MM-yyyy') between '"+frmdt+"' and '"+todt+"' and loc.branch_id = "+branchid+" and s.branch_id = "+branchid+" " +
                            "group by itm.item_name,itm.item_id,t.batch_no,rc.rack_name,v.qty order by item_name";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public int updateUsage(string path, string userid)
        {
            string query; int res;
            query = "insert into CRF_USAGE values(SEQ_CRFUSAGE.nextval,0,1," + userid + ",'" + path + "',sysdate)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }

    }
}
