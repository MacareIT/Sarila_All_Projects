using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.IO;
using ClosedXML.Excel;

namespace WebService_Expiry
{
    /// <summary>
    /// Summary description for WebService_Expiry
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_Expiry : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();

        [WebMethod]
        public DataSet Get_ExpiryMedicines_Valapad()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                             "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                             "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                             "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                             "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 2435 and mg.group_id=a.group_id " +
                                             "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            return DS;
        }

        [WebMethod]
        public DataSet Get_ExpiryMedicines_Valapad_New()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                              "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                              "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                              "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                              "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3348 and mg.group_id=a.group_id " +
                                              "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            return DS;
        }

        [WebMethod]
        public DataSet Get_ExpiryMedicines_Vdply()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                               "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                               "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                               "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                               "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3391 and mg.group_id=a.group_id " +
                                               "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            return DS;
        }

        [WebMethod]
        public DataSet Get_ExpiryMedicines_Cherpu()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                               "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                               "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                               "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                               "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3463 and mg.group_id=a.group_id " +
                                               "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            return DS;
        }

        [WebMethod]
        public DataSet Get_ExpiryMedicines_Kanjany()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                             "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg  " +
                                             "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                             "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                             "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3460 and mg.group_id=a.group_id " +
                                             "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            return DS;
        }


        [WebMethod]
        public DataSet Get_ExpiryMedicines_Kattoor()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                              "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg  " +
                                              "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                              "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                              "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3390 and mg.group_id=a.group_id " +
                                             "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            return DS;
        }

        [WebMethod]
        public DataSet Get_ExpiryMedicines_Wholesale()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS," +
                "Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP,a.igst As TaxRate from hospital.pharma_inventory t, " +
                "hospital.PHARMA_ITEM_MASTER A, hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, hospital.pharma_medicine_group mg where A.ITEM_ID = T.ITEM_ID " +
                "AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND t.branch_id = 3350 AND  to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate) <= (case when mg.group_id=4 then 30 else 90 end) " +
                "and(to_date(t.expiry_dt, 'dd-MM-yyyy') > to_date(sysdate, 'dd-MM-yyyy')) and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) and mg.group_id = a.group_id GROUP BY BRANCH_NAME, A.ITEM_NAME, " +
                "t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, CONV_UNITS, mg.group_name order by BRANCH_NAME, t.expiry_dt");
            return DS;
        }
    }
}




            
