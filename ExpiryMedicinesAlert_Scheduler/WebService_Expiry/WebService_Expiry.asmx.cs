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

        #region ..
        [WebMethod]
        public DataSet Get_ExpiryMedicines()
        {
            DataSet DS_Val = new DataSet();
            DS_Val = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS, SUM((t.PRI_STOCK + t.SEC_STOCK)*CONV_UNITS) As TOTAL_QUANTITY,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                             "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak " +
                                             "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                             "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                             "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= 90 and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 2435 GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS order by BRANCH_NAME, t.expiry_dt");
            //DataSet DS_New = new DataSet();
            //DS_New = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS, SUM((t.PRI_STOCK + t.SEC_STOCK)*CONV_UNITS) As TOTAL_QUANTITY,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
            //                                  "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak " +
            //                                  "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
            //                                  "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
            //                                  "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= 90 and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3348 GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS order by BRANCH_NAME, t.expiry_dt");
            //DataSet DS_Store = new DataSet();
            //DS_Store = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS, SUM((t.PRI_STOCK + t.SEC_STOCK)*CONV_UNITS) As TOTAL_QUANTITY,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
            //                                    "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak " +
            //                                    "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
            //                                    "and loc.location = 'S' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
            //                                    "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= 90 and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 2435 GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS order by BRANCH_NAME, t.expiry_dt");
            //DataSet DS_Vdply = new DataSet();
            //DS_Vdply = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS, SUM((t.PRI_STOCK + t.SEC_STOCK)*CONV_UNITS) As TOTAL_QUANTITY,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
            //                                    "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak " +
            //                                    "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
            //                                    "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
            //                                    "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= 90 and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3391 GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS order by BRANCH_NAME, t.expiry_dt");
            //DataSet Ds_Cherp = new DataSet();
            //Ds_Cherp = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS, SUM((t.PRI_STOCK + t.SEC_STOCK)*CONV_UNITS) As TOTAL_QUANTITY,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
            //                                   "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak " +
            //                                   "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
            //                                   "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
            //                                   "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= 90 and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3463 GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS order by BRANCH_NAME, t.expiry_dt");
            //DataSet DS_Kanjany = new DataSet();
            //DS_Kanjany = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS, SUM((t.PRI_STOCK + t.SEC_STOCK)*CONV_UNITS) As TOTAL_QUANTITY,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
            //                                 "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak " +
            //                                 "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
            //                                 "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
            //                                 "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= 90 and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3460 GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS order by BRANCH_NAME, t.expiry_dt");
            //DataSet DS_Katr = new DataSet();
            //DS_Katr = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS, SUM((t.PRI_STOCK + t.SEC_STOCK)*CONV_UNITS) As TOTAL_QUANTITY,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
            //                                  "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak " +
            //                                  "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
            //                                  "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
            //                                  "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= 90 and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3390 GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS order by BRANCH_NAME, t.expiry_dt");
            return DS_Val;
        }
        #endregion

        [WebMethod]
        public void Get_ExpiryMedicines_Valapad()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                             "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                             "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                             "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                             "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 2435 and mg.group_id=a.group_id " +
                                             "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            DataSet DS5 = new DataSet();
            DS5 = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                              "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                              "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                              "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                              "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3348 and mg.group_id=a.group_id " +
                                              "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            DataSet DS6 = new DataSet();
            DS6 = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                                "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                                "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                                "and loc.location = 'S' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                                "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 2435 and mg.group_id=a.group_id " +
                                                "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");

            MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("unitheadvalapad@macare.in"));
            //MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("itcoordinator@macare.in"));
            if (DS.Tables[0].Rows.Count > 0)
            {
                DS.Tables[0].TableName = "ExpiringMedicines_Valapad";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);

                        //Convert MemoryStream to Byte array.
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes), "ExpiringMedicines_Valapad.xlsx"));
                    }
                }
            }
            if (DS5.Tables[0].Rows.Count > 0)
            {
                DS5.Tables[0].TableName = "ExpiringMedicineslist_New";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS5.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);

                        //Convert MemoryStream to Byte array.
                        byte[] bytes5 = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes5), "ExpiringMedicines_New.xlsx"));
                    }
                }
            }
            if (DS6.Tables[0].Rows.Count > 0)
            {
                DS6.Tables[0].TableName = "ExpiringMedicines_Store";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS6.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);

                        //Convert MemoryStream to Byte array.
                        byte[] bytes6 = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes6), "ExpiringMedicines_Store.xlsx"));
                    }
                }
            }
            MailMsg.Subject = "Expiring Medicine List Valapad";
            MailMsg.Body = "Expiring Medicine List Alert Attachment";
            // Add a carbon copy recipient.

            MailMsg.CC.Add(new MailAddress("techlead@macare.in")); MailMsg.CC.Add(new MailAddress("operationhead@macare.in"));
            MailMsg.CC.Add(new MailAddress("purchase@macare.in")); MailMsg.CC.Add(new MailAddress("medicalsvalapad@macare.in"));
            //MailMsg.CC.Add(new MailAddress("md@macare.in")); 
            MailMsg.CC.Add(new MailAddress("cfo@macare.in")); MailMsg.CC.Add(new MailAddress("businesshead@macare.in"));
            MailMsg.IsBodyHtml = true;

            SecurityProtocolType SecurityProtocolType = new SecurityProtocolType();//new
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.rediffmailpro.com";
            smtp.EnableSsl = false;
            System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
            NetworkCred.UserName = "info@macare.in";
            NetworkCred.Password = "infomacare@78";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//new // Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//new
                                                             //smtp.Port = 586;
            smtp.Port = 587;//for local host
                            //smtp.Port = 465;
            smtp.Send(MailMsg);


        }

        [WebMethod]
        public void Get_ExpiryMedicines_Vdply()
        {
            DataSet DS1 = new DataSet();
            DS1 = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                               "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                               "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                               "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                               "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3391 and mg.group_id=a.group_id " +
                                               "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("vadanapallyunithead@macare.in"));
            if (DS1.Tables[0].Rows.Count > 0)
            {
                DS1.Tables[0].TableName = "ExpiringMedicines_Vdplly";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS1.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);

                        //Convert MemoryStream to Byte array.
                        byte[] bytes1 = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes1), "ExpiringMedicines_Vdplly.xlsx"));
                    }
                }
                MailMsg.Subject = "Expiring Medicine List Vdplly";
                MailMsg.Body = "Expiring Medicine List Alert Attachment";
                // Add a carbon copy recipient.

                MailMsg.CC.Add(new MailAddress("techlead@macare.in")); MailMsg.CC.Add(new MailAddress("operationhead@macare.in"));
                MailMsg.CC.Add(new MailAddress("purchase@macare.in")); MailMsg.CC.Add(new MailAddress("cfo@macare.in"));
               // MailMsg.CC.Add(new MailAddress("md@macare.in"));
                MailMsg.CC.Add(new MailAddress("businesshead@macare.in"));

                MailMsg.IsBodyHtml = true;

                SecurityProtocolType SecurityProtocolType = new SecurityProtocolType();//new
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "info@macare.in";
                NetworkCred.Password = "infomacare@78";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//new // Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//new
                                                                 //smtp.Port = 586;
                smtp.Port = 587;//for local host
                                //smtp.Port = 465;
                smtp.Send(MailMsg);
            }

        }

        [WebMethod]
        public void Get_ExpiryMedicines_Cherpu()
        {
            DataSet DS2 = new DataSet();
            DS2 = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                               "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg " +
                                               "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                               "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                               "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3463 and mg.group_id=a.group_id " +
                                               "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("unitheadcherpu@macare.in"));
            if (DS2.Tables[0].Rows.Count > 0)
            {
                DS2.Tables[0].TableName = "ExpiringMedicines_Cherpu";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS2.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);

                        //Convert MemoryStream to Byte array.
                        byte[] bytes2 = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes2), "ExpiringMedicines_Cherpu.xlsx"));
                    }
                }
                MailMsg.Subject = "Expiring Medicine List Cherpu";
                MailMsg.Body = "Expiring Medicine List Alert Attachment";
                // Add a carbon copy recipient.

                MailMsg.CC.Add(new MailAddress("techlead@macare.in")); MailMsg.CC.Add(new MailAddress("operationhead@macare.in"));
                MailMsg.CC.Add(new MailAddress("purchase@macare.in")); MailMsg.CC.Add(new MailAddress("cfo@macare.in"));
                //MailMsg.CC.Add(new MailAddress("md@macare.in")); 
                MailMsg.CC.Add(new MailAddress("businesshead@macare.in"));
                MailMsg.IsBodyHtml = true;

                SecurityProtocolType SecurityProtocolType = new SecurityProtocolType();//new
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "info@macare.in";
                NetworkCred.Password = "infomacare@78";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//new // Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//new
                                                                 //smtp.Port = 586;
                smtp.Port = 587;//for local host
                                //smtp.Port = 465;
                smtp.Send(MailMsg);
            }
        }

        [WebMethod]
        public void Get_ExpiryMedicines_Kanjany()
        {
            DataSet DS3 = new DataSet();
            DS3 = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                             "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg  " +
                                             "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                             "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                             "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3460 and mg.group_id=a.group_id " +
                                             "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("kanjanyunithead@macare.in"));
            if (DS3.Tables[0].Rows.Count > 0)
            {
                DS3.Tables[0].TableName = "ExpiringMedicines_Kanjany";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS3.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);

                        //Convert MemoryStream to Byte array.
                        byte[] bytes3 = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes3), "ExpiringMedicines_Kanjany.xlsx"));
                    }
                }
                MailMsg.Subject = "Expiring Medicine List Kanjany";
                MailMsg.Body = "Expiring Medicine List Alert Attachment";
                // Add a carbon copy recipient.

                MailMsg.CC.Add(new MailAddress("techlead@macare.in")); MailMsg.CC.Add(new MailAddress("operationhead@macare.in"));
                MailMsg.CC.Add(new MailAddress("purchase@macare.in")); MailMsg.CC.Add(new MailAddress("cfo@macare.in"));
                //MailMsg.CC.Add(new MailAddress("md@macare.in")); 
                MailMsg.CC.Add(new MailAddress("businesshead@macare.in"));

                SecurityProtocolType SecurityProtocolType = new SecurityProtocolType();//new
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "info@macare.in";
                NetworkCred.Password = "infomacare@78";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//new // Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//new
                                                                 //smtp.Port = 586;
                smtp.Port = 587;//for local host
                                //smtp.Port = 465;
                smtp.Send(MailMsg);
            }
        }


        [WebMethod]
        public void Get_ExpiryMedicines_Kattoor()
        {
            DataSet DS4 = new DataSet();
            DS4 = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,rak.rack_name, t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS,Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP, " +
                                              "a.igst As TaxRate from hospital.pharma_inventory t, hospital.PHARMA_ITEM_MASTER A,hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, HOSPITAL.PHARMA_ITEM_LOCATION loc, HOSPITAL.PHARMA_RACK_MASTER rak,hospital.pharma_medicine_group mg  " +
                                              "WHERE A.ITEM_ID = T.ITEM_ID AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND loc.item_id = A.ITEM_ID and loc.branch_id = b.branch_id " +
                                              "and loc.location = 'P' and loc.shelf_id = rak.shelf_id and loc.rack_id = rak.rack_id and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) " +
                                              "and to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate, 'dd-MM-yyyy') <= (case when mg.group_id=4 then 30 else 90 end) and (to_date(t.expiry_dt, 'dd-MM-yyyy')> to_date(sysdate, 'dd-MM-yyyy')) and B.BRANCH_ID = 3390 and mg.group_id=a.group_id " +
                                             "GROUP BY BRANCH_NAME, A.ITEM_NAME, t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, rak.rack_name,CONV_UNITS,mg.group_name order by BRANCH_NAME, t.expiry_dt");
            MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("kattoorunithead@macare.in"));
            if (DS4.Tables[0].Rows.Count > 0)
            {
                DS4.Tables[0].TableName = "ExpiringMedicines_Kattoor";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS4.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);
                        //Convert MemoryStream to Byte array.
                        byte[] bytes4 = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes4), "ExpiringMedicines_Kattoor.xlsx"));
                    }
                }
                MailMsg.Subject = "Expiring Medicine List Kattoor";
                MailMsg.Body = "Expiring Medicine List Alert Attachment";
                // Add a carbon copy recipient.

                MailMsg.CC.Add(new MailAddress("techlead@macare.in")); MailMsg.CC.Add(new MailAddress("operationhead@macare.in"));
                MailMsg.CC.Add(new MailAddress("purchase@macare.in")); MailMsg.CC.Add(new MailAddress("cfo@macare.in"));
                //MailMsg.CC.Add(new MailAddress("md@macare.in")); 
                MailMsg.CC.Add(new MailAddress("businesshead@macare.in"));

                SecurityProtocolType SecurityProtocolType = new SecurityProtocolType();//new
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "info@macare.in";
                NetworkCred.Password = "infomacare@78";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//new // Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//new
                                                                 //smtp.Port = 586;
                smtp.Port = 587;//for local host
                                //smtp.Port = 465;
                smtp.Send(MailMsg);
            }
        }

        [WebMethod]
        public void Get_ExpiryMedicines_Wholesale()
        {
            DataSet DS1 = new DataSet();
            DS1 = ObjOrclHelper.ExecuteDataSet("select t.branch_id, B.BRANCH_NAME, A.ITEM_NAME,mg.group_name,t.batch_no,t.expiry_dt,sum(t.PRI_STOCK + t.SEC_STOCK) quantity,CONV_UNITS," +
                "Round(T.PRI_MRP / max(t.conv_units), 2) UNITMRP,a.igst As TaxRate from hospital.pharma_inventory t, " +
                "hospital.PHARMA_ITEM_MASTER A, hospital.pharmacy_master B, hospital.PHARMA_PRIMARY_UNITS C, hospital.pharma_medicine_group mg where A.ITEM_ID = T.ITEM_ID " +
                "AND B.BRANCH_ID = T.BRANCH_ID AND A.PRI_UNIT_ID = C.PRI_UNIT_ID AND t.branch_id = 3350 AND  to_date(t.expiry_dt, 'dd-MM-yyyy') - to_date(sysdate) <= (case when mg.group_id=4 then 30 else 90 end) " +
                "and(to_date(t.expiry_dt, 'dd-MM-yyyy') > to_date(sysdate, 'dd-MM-yyyy')) and(t.PRI_STOCK <> 0 OR t.SEC_STOCK <> 0) and mg.group_id = a.group_id GROUP BY BRANCH_NAME, A.ITEM_NAME, " +
                "t.branch_id, T.PRI_MRP, a.igst, t.batch_no, t.expiry_dt, CONV_UNITS, mg.group_name order by BRANCH_NAME, t.expiry_dt");

            MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("purchasehead@macare.in"));
            if (DS1.Tables[0].Rows.Count > 0)
            {
                DS1.Tables[0].TableName = "ExpiringMedicines_Wholesale";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(DS1.Tables[0]);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        //Save the Excel Workbook to MemoryStream.
                        wb.SaveAs(memoryStream);

                        //Convert MemoryStream to Byte array.
                        byte[] bytes1 = memoryStream.ToArray();
                        memoryStream.Close();
                        MailMsg.Attachments.Add(new Attachment(new MemoryStream(bytes1), "ExpiringMedicines_Wholesale.xlsx"));
                    }
                }
                MailMsg.Subject = "Expiring Medicine List Wholesale";
                MailMsg.Body = "Expiring Medicine List Alert Attachment";
                // Add a carbon copy recipient.

                MailMsg.CC.Add(new MailAddress("techlead@macare.in")); MailMsg.CC.Add(new MailAddress("operationhead@macare.in"));
                MailMsg.CC.Add(new MailAddress("purchase@macare.in")); MailMsg.CC.Add(new MailAddress("cfo@macare.in"));
                //MailMsg.CC.Add(new MailAddress("md@macare.in")); 
                MailMsg.CC.Add(new MailAddress("businesshead@macare.in"));

                MailMsg.IsBodyHtml = true;

                SecurityProtocolType SecurityProtocolType = new SecurityProtocolType();//new
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.rediffmailpro.com";
                smtp.EnableSsl = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "info@macare.in";
                NetworkCred.Password = "infomacare@78";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;//new // Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;//new
                                                                 //smtp.Port = 586;
                smtp.Port = 587;//for local host
                                //smtp.Port = 465;
                smtp.Send(MailMsg);
            }

        }
    }
}




            
