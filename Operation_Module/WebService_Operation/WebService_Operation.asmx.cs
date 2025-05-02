using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OracleClient;

namespace WebService_Operation
{
    /// <summary>
    /// Summary description for WebService_Operation
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_Operation : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        DataSet ObjDataSet = new DataSet();
        DataTable ObjDatatb = new DataTable();
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int updateUsage(string path, string userid)
        {
            string query; int res;
            query = "insert into CRF_USAGE values(SEQ_CRFUSAGE.nextval,0,1," + userid + ",'" + path + "',sysdate)";
            res = ObjOrclHelper.ExecuteNonQuery(query);
            return res;
        }

        #region Login
        [WebMethod()]
        public DataSet Login(string u_name, string pswd)
        {
            DataSet ds;
            ds = ObjOrclHelper.ExecuteDataSet("select a.*,b.name branch from Login_users a join hospital.clinic_master b on a.branchid=b.branch_id where username ='" + u_name + "' and password='" + pswd + "' and active=1");
            return ds;
        }
        #endregion

        #region Micro_Incharge_Select
        [WebMethod()]
        public DataSet Micro_Incharge_Select()
        {
            DataSet ds;
            ds = ObjOrclHelper.ExecuteDataSet("select * from Login_users where type ='microlabincharge' or type ='unithead'");
            return ds;
        }
        #endregion

        #region Branch_Select
        [WebMethod]
        public DataSet Select_Branch()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select branch_id,name from hospital.clinic_master where clinic_id not in (11,13,14,6,8,9,10,22,26,17,19,29,31,35,36,25,32,33,34) " +
                                                                           "and name is not null and name != '0'");
            return ObjDataSet;
        }
        #endregion

        #region Micro_lab_Select
        [WebMethod]
        public DataSet Select_Microlab()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select cm.branch_id, cm.name from hospital.clinic_master cm where cm.branch_type= 4 and cm.firm_id= 16 "+
                                                      "and cm.clinic_id not in (37, 14, 18)");
            return ObjDataSet;
        }
        #endregion

        #region Ambience Selection
        [WebMethod]
        public DataSet Select_Ambience(int amb_Id)
        {
            if (amb_Id == 0)
                ObjDataSet = ObjOrclHelper.ExecuteDataSet("select amb_id,amb_name from operation_ambienceregister");
            else
                ObjDataSet = ObjOrclHelper.ExecuteDataSet("select amb_id,amb_name from operation_ambienceregister where amb_id=" + amb_Id);
            return ObjDataSet;
        }
        #endregion

        #region Ambience Insert/Update
        [WebMethod()]
        public int Ambience_InsertUpdate(int amb_Id, string amb_name)
        {
            int result = 0;
            try
            {
                DataSet dsDistr = ObjOrclHelper.ExecuteDataSet("select amb_id from operation_ambienceregister where amb_name = '" + amb_name + "' and amb_id!=" + amb_Id);
                if (dsDistr.Tables[0].Rows.Count == 0)
                {
                    if (amb_Id > 0)
                    {
                        result = ObjOrclHelper.ExecuteNonQuery("update operation_ambienceregister set amb_name='" + amb_name + "' where amb_id=" + amb_Id);
                    }
                    else
                    {
                        DataSet dsMax = ObjOrclHelper.ExecuteDataSet("select nvl(max(amb_id),0)+1 from operation_ambienceregister");
                        result = ObjOrclHelper.ExecuteNonQuery("insert into operation_ambienceregister (amb_id,amb_name) values(" + Convert.ToInt32(dsMax.Tables[0].Rows[0][0].ToString()) + ",'" + amb_name + "')");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            //try
            //{
            //    DataSet dsDistr = ObjOrclHelper.ExecuteDataSet("select amb_id from operation_ambienceregister where amb_name = '" + amb_name + "' and amb_id!=" + amb_Id);
            //    if (dsDistr.Tables[0].Rows.Count == 0)
            //    {
            //        if (amb_Id > 0)
            //        {
            //            result = ObjOrclHelper.ExecuteNonQuery("update operation_ambienceregister set amb_name='" + amb_name + "' where amb_id=" + amb_Id);
            //        }
            //        else
            //        {
            //            DataSet dsMax = ObjOrclHelper.ExecuteDataSet("select nvl(max(amb_id),0)+1 from operation_ambienceregister");
            //            result = ObjOrclHelper.ExecuteNonQuery("insert into operation_ambienceregister (amb_id,amb_name) values(" + Convert.ToInt32(dsMax.Tables[0].Rows[0][0].ToString()) + ",'" + amb_name + "')");
            //            if (result == 1)
            //            {
            //                DataSet dsBrnch = ObjOrclHelper.ExecuteDataSet("select branch_id,name from hospital.clinic_master where clinic_id not in (11,12,13,14,6,8,9,10,22,26,17,19,29,31,35,36,25,32,33,34) " +
            //                                                               "and name is not null and name != '0'");
            //                if (dsBrnch.Tables[0].Rows.Count > 0)
            //                {
            //                    for (int i = 0; i < dsBrnch.Tables[0].Rows.Count; i++)
            //                    {
            //                        DataSet dscon = ObjOrclHelper.ExecuteDataSet("select nvl(max(AMB_CONDTNID),0)+1 from OPERATION_AMBIENCECONDTN");
            //                        result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_AMBIENCECONDTN(AMB_CONDTNID,branch_id,amb_id,amb_count,amb_condtn,amb_remarks,amb_checked,amb_reason,Month_,Dateverified,year_) " +
            //                            "values(" + Convert.ToInt32(dscon.Tables[0].Rows[0][0].ToString()) + "," + Convert.ToInt32(dsBrnch.Tables[0].Rows[i]["branch_id"].ToString()) + "," +
            //                            Convert.ToInt32(dsMax.Tables[0].Rows[0][0].ToString()) + ",' ',' ',' ',0,' ',' ',' ',' ')");
            //                    }
            //                }
            //            }
            //        }
            //    }

            //}
            //catch (Exception ex)
            //{
            //    result = 0;
            //}

            return result;
        }
        #endregion

        #region AmbienceCondition Selection
        [WebMethod]
        public DataSet Select_AmbienceCondition(int BranchId,int Month_,int Year_)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select OPERATION_AMBIENCECONDTN.*,OPERATION_AMBIENCEREGISTER.AMB_NAME "+
                                                      " from OPERATION_AMBIENCECONDTN join OPERATION_AMBIENCEREGISTER ON "+
                                                      " OPERATION_AMBIENCECONDTN.AMB_ID = OPERATION_AMBIENCEREGISTER.AMB_ID where branch_id = " + BranchId+" " +
                                                      " and Month_="+Month_+" and Year_="+Year_+ " order by AMB_CONDTNID");
            return ObjDataSet;
        }
        #endregion

        #region AmbienceCondition Selection with AMB_CONDTNID
        [WebMethod]
        public DataSet Select_AmbienceCondition_WithId(int AMB_CONDTNID)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select OPERATION_AMBIENCECONDTN.*,OPERATION_AMBIENCEREGISTER.AMB_NAME " +
                                                      " from OPERATION_AMBIENCECONDTN join OPERATION_AMBIENCEREGISTER ON " +
                                                      " OPERATION_AMBIENCECONDTN.AMB_ID = OPERATION_AMBIENCEREGISTER.AMB_ID where AMB_CONDTNID=" + AMB_CONDTNID);
            return ObjDataSet;
        }
        #endregion

        #region Ambience Insert/Update
        [WebMethod()]
        public int AmbienceCondtn_InsertUpdate(int branch_id,int amb_id,string count,string condtn,string remarks,int Month_,int year_,string Amb_Date,string Amb_Entered)
        {
            int result = 0;
            try
            {
                DataSet dsamb = ObjOrclHelper.ExecuteDataSet("select amb_id from operation_ambiencecondtn where amb_id = " + amb_id + " and Month_=" + Month_ + " and Year_=" + year_ + " and Branch_id="+branch_id+"");
                if (dsamb.Tables[0].Rows.Count == 0)
                {
                    //if (amb_CondtnId == 0)
                    //{
                        result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_AMBIENCECONDTN(amb_condtnid,branch_id,amb_id,amb_count,amb_condtn,amb_remarks,amb_checked,amb_reason,Month_,year_,Amb_Date,Amb_Entered) " +
                            "values(Seq_Amb.nextval," + branch_id + "," + amb_id + ",'" + count + "','" + condtn + "','" + remarks + "',0,' '," + Month_ + "," + year_ + ",'"+Amb_Date+"','"+Amb_Entered+"')");
                    //}
                    //else
                        //result = ObjOrclHelper.ExecuteNonQuery("update OPERATION_AMBIENCECONDTN set amb_count='" + count + "',amb_condtn='" + condtn + "',amb_remarks='" + remarks + "' where amb_CondtnId=" + amb_CondtnId);
                }
            }
            catch(Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Ambience status update
        [WebMethod()]
        public int AmbienceCondtn_StatusUpdate(int amb_CondtnId,string reason,int checked_)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("update OPERATION_AMBIENCECONDTN set amb_reason='" +reason+ "',amb_checked=" + checked_ + "  where amb_CondtnId=" + amb_CondtnId);
            return result;
        }
        #endregion

        #region AmbienceReport Selection 
        [WebMethod]
        public DataSet Select_AmbienceReport(int month_,int year_,int branchId)
        {
            //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select OPERATION_AMBIENCECONDTN.AMB_CONDTNID,OPERATION_AMBIENCECONDTN.BRANCH_ID,OPERATION_AMBIENCECONDTN.Amb_Id,"+
            //                                          "OPERATION_AMBIENCECONDTN.Amb_Count, OPERATION_AMBIENCECONDTN.Amb_Condtn, OPERATION_AMBIENCECONDTN.Amb_Remarks,"+
            //                                          "OPERATION_AMBIENCEREGISTER.AMB_NAME, OPERATION_AMBIENCECONDTN.Amb_Reason, OPERATION_AMBIENCECONDTN.Amb_Checked,"+
            //                                          "(SELECT TO_CHAR(TO_DATE(OPERATION_AMBIENCECONDTN.Month_, 'MM'), 'MONTH') AS monthname FROM DUAL) Month_,"+
            //                                          "OPERATION_AMBIENCECONDTN.Dateverified,OPERATION_AMBIENCECONDTN.Year_,clinic_master.Name as Branch_Name "+
            //                                          "from OPERATION_AMBIENCECONDTN join OPERATION_AMBIENCEREGISTER ON OPERATION_AMBIENCECONDTN.AMB_ID = OPERATION_AMBIENCEREGISTER.AMB_ID "+
            //                                          "join hospital.clinic_master on clinic_master.branch_id = OPERATION_AMBIENCECONDTN.BRANCH_ID " +
            //                                          " where OPERATION_AMBIENCECONDTN.BRANCH_ID=" +branchId+ " and OPERATION_AMBIENCECONDTN.Year_="+year_+ " " +
            //                                          "and OPERATION_AMBIENCECONDTN.month_="+month_+ "");//and OPERATION_AMBIENCECONDTN.verified=1
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select OPERATION_AMBIENCECONDTN.AMB_CONDTNID,OPERATION_AMBIENCECONDTN.BRANCH_ID,OPERATION_AMBIENCECONDTN.Amb_Id," +
                                                      "OPERATION_AMBIENCECONDTN.Amb_Count Count, OPERATION_AMBIENCECONDTN.Amb_Condtn Condition, OPERATION_AMBIENCECONDTN.Amb_Remarks Remarks," +
                                                      "OPERATION_AMBIENCEREGISTER.AMB_NAME Ambience, OPERATION_AMBIENCECONDTN.Amb_Reason Reason, OPERATION_AMBIENCECONDTN.Amb_Checked Checked," +
                                                      "(SELECT TO_CHAR(TO_DATE(OPERATION_AMBIENCECONDTN.Month_, 'MM'), 'MONTH') AS monthname FROM DUAL) Month_," +
                                                      "OPERATION_AMBIENCECONDTN.Dateverified,OPERATION_AMBIENCECONDTN.Year_,operation_ambiencecondtn.verified," +
                                                      "operation_ambiencecondtn.amb_date,operation_ambiencecondtn.amb_entered,operation_ambiencecondtn.verifn_entered," +
                                                      "clinic_master.Name as Branch_Name,(select designation from Login_users where username = operation_ambiencecondtn.amb_entered) Designation, " +
                                                      "(select Log_User from Login_users where username=operation_ambiencecondtn.amb_entered) Log_user " +
                                                      "from OPERATION_AMBIENCECONDTN join OPERATION_AMBIENCEREGISTER ON OPERATION_AMBIENCECONDTN.AMB_ID = OPERATION_AMBIENCEREGISTER.AMB_ID " +
                                                      "join hospital.clinic_master on clinic_master.branch_id = OPERATION_AMBIENCECONDTN.BRANCH_ID " +
                                                      "where OPERATION_AMBIENCECONDTN.BRANCH_ID=" + branchId + " and OPERATION_AMBIENCECONDTN.Year_=" + year_ + " " +
                                                      "and OPERATION_AMBIENCECONDTN.month_=" + month_ + "");
            //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select OPERATION_AMBIENCEREGISTER.AMB_NAME Ambience,OPERATION_AMBIENCECONDTN.Amb_Count Count, OPERATION_AMBIENCECONDTN.Amb_Condtn Condition, "+
            //                                          "OPERATION_AMBIENCECONDTN.Amb_Remarks Remarks, OPERATION_AMBIENCECONDTN.Amb_Checked Checked, OPERATION_AMBIENCECONDTN.Amb_Reason Reason from OPERATION_AMBIENCECONDTN "+
            //                                          "join operation_ambienceregister on operation_ambienceregister.amb_id = operation_ambiencecondtn.amb_id "+
            //                                          "where OPERATION_AMBIENCECONDTN.BRANCH_ID=" + branchId + " and OPERATION_AMBIENCECONDTN.Year_=" + year_ + " " +
            //                                          "and OPERATION_AMBIENCECONDTN.month_=" + month_ + "");
            return ObjDataSet;
        }
        #endregion

        #region Ambience Delete
        [WebMethod()]
        public int AmbienceCondtn_Delete(int Month_, int Year_, int Branch_id)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("delete from OPERATION_AMBIENCECONDTN where Month_="+Month_+" and Year_="+Year_+" and Branch_Id="+Branch_id+" and Verified=0");
            return result;
        }
        #endregion

        #region Ambience Verificationstatus update
        [WebMethod()]
        public int AmbienceCondtn_VerifyStatusUpdate(int Month_, int Year_,int Branch_Id,string Verifn_Entered)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("update OPERATION_AMBIENCECONDTN set Verified=1,DateVerified='"+DateTime.Now.ToString("dd-MM-yyyy")+"',verifn_Entered='"+Verifn_Entered+"' where Year_="+Year_+" and Month_="+Month_+" and Branch_Id="+Branch_Id+"");
            return result;
        }
        #endregion

        #region AmbienceCondition Selection with excess Ambid
        [WebMethod]
        public DataSet Select_AmbienceConditionWithExcessAmbID(int BranchId, int Month_, int Year_)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select OPERATION_AMBIENCEREGISTER.Amb_id,OPERATION_AMBIENCEREGISTER.Amb_Name from OPERATION_AMBIENCEREGISTER minus " +
                                                      "select OPERATION_AMBIENCECONDTN.Amb_id,OPERATION_AMBIENCEREGISTER.Amb_Name from OPERATION_AMBIENCECONDTN join " +
                                                      "OPERATION_AMBIENCEREGISTER on OPERATION_AMBIENCECONDTN.Amb_Id = operation_ambienceregister.Amb_Id where " +
                                                      "(branch_id = " + BranchId + " and Month_ = " + Month_ + " and Year_ = " + Year_ + ") order by amb_id");
            return ObjDataSet;
        }
        #endregion

        #region Ambience Year Selection
        [WebMethod]
        public DataSet Select_Year()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select distinct year_ as Year from operation_ambiencecondtn order by year desc");
            return ObjDataSet;
        }
        #endregion

        #region AmbienceVerify Selection
        [WebMethod]
        public DataSet Select_VerifiedAmbience(int BranchId, int Month_, int Year_)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select Amb_Condtnid from operation_ambiencecondtn where branch_id = " + BranchId + " and Month_ = " + Month_ + " and Year_ = " + Year_ + " and verified=1");
            return ObjDataSet;
        }
        #endregion

        #region Change password
        [WebMethod()]
        public int Change_Pswd(string uname, string pswd, string newpswd)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("update login_users set password='"+newpswd+"' where username='" + uname + "' and password='" + pswd + "' and active=1");
            return result;
        }
        #endregion

        #region AmbiencePic Insert/Update
        [WebMethod()]
        public DataSet AmbiencePic_InsertUpdate(int amb_PicId, string amb_pic_path,string amb_pic_name,int year_,int month_,int branch_id)
        {
            int result = 0;DataSet dtRowNo = new DataSet();
            try
            {
                if (amb_PicId > 0)
                {
                    result = ObjOrclHelper.ExecuteNonQuery("update operation_ambiencephoto set amb_pic_path='"+amb_pic_path+"',amb_pic_name='"+amb_pic_name+"',year_="+year_+",month_="+month_+",date_added='"+DateTime.Now.ToString()+"' where amb_pic_id="+amb_PicId+" and verified=0");
                    if(result>0)
                    {
                        dtRowNo = ObjOrclHelper.ExecuteDataSet("select * from operation_ambiencephoto where amb_Pic_Id ="+amb_PicId);
                    }
                }
                else
                {
                    DataSet dsMax = ObjOrclHelper.ExecuteDataSet("select nvl(max(amb_pic_id),0)+1 from operation_ambiencephoto");
                    result = ObjOrclHelper.ExecuteNonQuery("insert into operation_ambiencephoto(amb_pic_id,amb_pic_path,amb_pic_name,year_,month_,branch_id,date_added) values (" + Convert.ToInt32(dsMax.Tables[0].Rows[0][0].ToString()) + ",'"+amb_pic_path+"','"+amb_pic_name+"',"+year_+","+month_+","+branch_id+",'"+DateTime.Now.ToString()+"')");
                    if(result>0)
                    {
                        dtRowNo = ObjOrclHelper.ExecuteDataSet("select * from operation_ambiencephoto where amb_Pic_Id = (select max(amb_Pic_Id) from operation_ambiencephoto)");
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return dtRowNo;
        }
        #endregion

        #region AmbiencePic Select
        [WebMethod()]
        public DataSet AmbiencePic_Select(int year_, int month_,int branch_id)
        {
            DataSet dtpic = new DataSet();
            dtpic = ObjOrclHelper.ExecuteDataSet("select * from operation_ambiencephoto where year_="+year_+" and month_="+month_+" and branch_id="+branch_id+""); 
            return dtpic;
        }
        #endregion

        #region AmbiencePic Verificationstatus update
        [WebMethod()]
        public int AmbiencePic_VerifyStatusUpdate(int Month_, int Year_, int Branch_Id)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("update OPERATION_AMBIENCEPHOTO set Verified=1 where Year_=" + Year_ + " and Month_=" + Month_ + " and Branch_Id=" + Branch_Id + "");
            return result;
        }
        #endregion

        #region OPeration_type Insert/Update
        [WebMethod()]
        public int OperationStatus_InsertUpdate(string type, string filename, string branch_id, string dept_id,string month,string year)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_Type(type,filename,branch_id,dept_id,month,year) " +
                    "values('" + type + "','" + filename + "','" + branch_id + "','" + dept_id + "','" + month + "','"+year+"')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        //.........................................................................................................................................//

        #region Inventory_Status Insert/Update
        [WebMethod()]
        public int InventoryStatus_InsertUpdate(string File_name, int Status, string Entered_By, string Checked_By)
        {
            int result = 0;
            try
            {
                    result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_INVENTORYSTATUS(File_name,Status,Entered_By,Checked_By,Date_) " +
                        "values('" + File_name + "'," + Status + ",'" + Entered_By + "','" + Checked_By + "','"+DateTime.Now.ToString("dd-MM-yyyy")+"')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Inventory_Status update
        [WebMethod()]
        public int Inventory_StatusUpdate(string File_name,string Checked_By)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("update OPERATION_INVENTORYSTATUS set Status=1,Checked_By='" + Checked_By + "' where File_name='" +File_name+"'");
            return result;
        }
        #endregion

        #region Department selection with branch_id
        [WebMethod]
        public DataSet Select_Department(int branch_id)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select distinct dpt.sdep_id,dpt.sdep_name from HOSPITAL.CLINSTORE_DEPTINV_MASTER Inv join HOSPITAL.LAB_DENTAL_SDEPARTMENT dpt on Inv.Sdept_Id=dpt.sdep_id "+
                                                      "where inv.branch_id = "+branch_id);
            return ObjDataSet;
        }
        #endregion

        #region Inventory Selection with branch_id
        [WebMethod]
        public DataSet Select_Inventory(int branch_id, int deptid)
        {
            #region
            //if (deptid == -1)
            //{
            //    //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select item_name,round(current_stock,2) current_stock,sub_measurement,round(unit_rate,2) unit_rate,round((current_stock*unit_rate),2)  Tot_Amt," +
            //    //                                          "'' as Phy_Stk,'' as Diff from HOSPITAL.VEW_CLINIC_BRANCHSTOCK_GROUP1 " +
            //    //                                          "where branch_id =" + branch_id + " order by item_name");
            //    //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select * from hospital.clinstore_Inventory_master a join hospital.clinstore_item_master b on a.item_id=b.item_id "+ 
            //    //                                          "join hospital.clinstore_secondary_units c on c.sec_unit_id = b.sec_unit_id join hospital.branch_master d on d.branch_id = a.branch_id "+
            //    //                                          "join hospital.clinstore_item_unitrate e on e.branchid = a.branch_id and b.item_id = e.item_id where a.branch_id = 0 and d.status_id <> 0 " +
            //    //                                          "and b.type_id not in (2, 3) and a.current_stock <> 0 and b.group_id <> 16 order by b.item_name " +
            //    //                                          "where branch_id =" + branch_id + " order by item_name");
            //    ObjDataSet = ObjOrclHelper.ExecuteDataSet("select a.item_id,b.item_name,a.min_stock,a.max_stock,a.current_stock,c.sec_unit_name as Sub_measurement,"+
            //                                              "d.BRANCH_NAME, e.unit_value unit_rate from hospital.clinstore_Inventory_master a join hospital.clinstore_item_master b on a.item_id = b.item_id "+
            //                                              "join hospital.clinstore_secondary_units c on c.sec_unit_id = b.sec_unit_id join hospital.branch_master d "+
            //                                              "on d.branch_id = a.branch_id join hospital.clinstore_item_unitrate e on e.branchid = a.branch_id "+
            //                                              "and b.item_id = e.item_id where a.branch_id = "+branch_id+" and d.status_id <> 0 and b.type_id not in (2, 3) and a.firm_id = 16 "+
            //                                              "and a.current_stock <> 0 and b.group_id <> 16 "+
            //                                              "minus "+
            //                                              "select a.item_id, b.item_name, a.min_stock, a.max_stock, a.current_stock, c.sec_unit_name as Sub_measurement,"+
            //                                              "d.BRANCH_NAME, e.unit_value unit_rate from hospital.clinstore_Inventory_master a join hospital.clinstore_item_master b on a.item_id = b.item_id "+
            //                                              "join hospital.clinstore_secondary_units c on c.sec_unit_id = b.sec_unit_id join hospital.branch_master d " +
            //                                              "on d.branch_id = a.branch_id join hospital.clinstore_item_unitrate e on e.branchid = a.branch_id "+
            //                                              "and b.item_id = e.item_id where a.branch_id = "+branch_id+" and d.status_id <> 0 and b.type_id not in (2, 3) and a.firm_id = 16 "+
            //                                              "and a.current_stock <> 0 and b.group_id <> 16 and sdep_mst_id = 6 order by item_name");
            //}
            //else
            //{
            //    //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select distinct b.item_name,a.current_stock,c.sec_unit_name sub_measurement,e.unit_value unit_rate,f.sdept_id,a.current_stock*e.unit_value as Tot_Amt, " +
            //    //                                          "'' as Phy_Stk,'' as Diff from hospital.clinstore_inventory_master a join hospital.clinstore_item_master b on a.item_id = b.item_id join hospital.clinstore_secondary_units c " +
            //    //                                          "on c.sec_unit_id = b.sec_unit_id join hospital.branch_master d on d.BRANCH_ID = a.branch_id join hospital.clinstore_item_unitrate e on b.item_id = e.item_id "+
            //    //                                          "join hospital.clinstore_deptinv_master f on f.item_id = b.item_ID where f.branch_id = "+branch_id+ " and f.sdept_id="+deptid);
            //    //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select x.firm_id,x.branch_id,x.BRANCH_NAME,x.item_id,x.item_name,x.sdep_name,x.sdep_id,x.current_stock,x.sec_unit_name sub_measurement,x.unit_value unit_rate,x.rate Tot_Amt, y.ExpDate, x.max_output, x.testrate,'' as Phy_Stk,'' as Diff " +
            //    //                                          "from(select a.firm_id, a.branch_id, a.name BRANCH_NAME, b.item_id, b.item_name, c.sdep_name, c.sdep_id,t.current_stock, e.sec_unit_name,d.unit_value, round(t.current_stock * d.unit_value, 2) rate, " +
            //    //                                          "Case When b.max_output = 0 Then null Else b.max_output End max_output,Case when(b.max_output = 0 Or b.alternative_uomvalue = 0) then null  " +
            //    //                                          "Else  round(d.unit_value / (b.max_output / b.alternative_uomvalue), 2)End  testrate from hospital.clinstore_deptinv_master t, hospital.clinstore_item_master b, " +
            //    //                                          "(select distinct t.sdep_id, t.sdep_name from hospital.lab_dental_sdepartment t) c,hospital.clinic_master a, hospital.clinstore_item_unitrate d, " +
            //    //                                          "hospital.clinstore_secondary_units e where t.item_id = b.item_id and c.sdep_id = t.sdept_id and a.branch_id = t.branch_id and d.item_id = t.item_id and d.branchid = t.branch_id " +
            //    //                                          "and e.sec_unit_id = b.sec_unit_id and t.current_stock > 0) x left outer join(select f.branch_id, f.item_id, max(f.expiry_date) ExpDate from hospital.clinstore_inventory_dtl f " +
            //    //                                          "group by f.branch_id, f.item_id) y on (x.branch_id = y.branch_id and x.item_id = y.item_id) where x.current_stock<>0 and x.sdep_id = "+deptid+" and x.branch_id = "+ branch_id + " order by item_name");
            //    ObjDataSet = ObjOrclHelper.ExecuteDataSet("select x.firm_id,x.branch_id,x.BRANCH_NAME,x.item_id,x.item_name,x.sdep_name,x.sdep_id,x.current_stock,x.sec_unit_name sub_measurement,x.unit_value unit_rate,x.rate Tot_Amt,"+
            //                                              "y.ExpDate, x.max_output, x.testrate, '' as Phy_Stk, '' as Diff "+
            //                                              "from(select a.firm_id, a.branch_id, a.name BRANCH_NAME, b.item_id, b.item_name, c.sdep_name, c.sdep_id, t.current_stock, e.sec_unit_name, d.unit_value, round(t.current_stock * d.unit_value, 2) rate, "+
            //                                              "Case When b.max_output = 0 Then null Else b.max_output End max_output, Case when(b.max_output = 0 Or b.alternative_uomvalue = 0) then null "+
            //                                              "Else  round(d.unit_value / (b.max_output / b.alternative_uomvalue), 2)End  testrate from hospital.clinstore_deptinv_master t, hospital.clinstore_item_master b,"+
            //                                              "(select distinct t.sdep_id, t.sdep_name from hospital.lab_dental_sdepartment t) c, hospital.clinic_master a, hospital.clinstore_item_unitrate d, "+
            //                                              "hospital.clinstore_secondary_units e where t.item_id = b.item_id and c.sdep_id = t.sdept_id and a.branch_id = t.branch_id and d.item_id = t.item_id and d.branchid = t.branch_id "+
            //                                              "and e.sec_unit_id = b.sec_unit_id and t.current_stock > 0) x left outer join(select f.branch_id, f.item_id, max(f.expiry_date) ExpDate from hospital.clinstore_inventory_dtl f "+
            //                                              "group by f.branch_id, f.item_id) y on(x.branch_id = y.branch_id and x.item_id = y.item_id) where x.current_stock<>0 and x.sdep_id = 0 and x.branch_id = 1256 and x.firm_id = 16 order by item_name");
            //}
            //return ObjDataSet;
            #endregion
            if (deptid == -1)
            {
                //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select item_name,round(current_stock,2) current_stock,sub_measurement,round(unit_rate,2) unit_rate,round((current_stock*unit_rate),2)  Tot_Amt," +
                //                                          "'' as Phy_Stk,'' as Diff from HOSPITAL.VEW_CLINIC_BRANCHSTOCK_GROUP1 " +
                //                                          "where branch_id =" + branch_id + " order by item_name");

                ObjDataSet = ObjOrclHelper.ExecuteDataSet("select item_name,round(current_stock,2) current_stock,sub_measurement,round(unit_rate,2) unit_rate,round((current_stock*unit_rate),2)  Tot_Amt, " +
                                                          "'' as Phy_Stk,'' as Diff from Hospital.Vew_Clinic_BranchStock_Group1 where branch_Id Not in(2675, 1256, 3268) and firm_id = 16 and branch_id ="+branch_id+" order by item_name");

            }
            else
            {
                                
                //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select x.firm_id,x.BRANCH_NAME,x.item_id,x.item_name,x.sdep_name,x.sdep_id,x.current_stock,x.sec_unit_name sub_measurement,x.unit_value unit_rate,x.rate Tot_Amt,y.ExpDate ,x.max_output, "+
                //                                          "x.testrate,'' as Phy_Stk,'' as Diff  from(select a.firm_id, a.branch_id, a.name BRANCH_NAME, b.item_id, b.item_name, c.sdep_name, c.sdep_id, t.current_stock, e.sec_unit_name,d.unit_value," +
                //                                          "round(t.current_stock * d.unit_value, 2) rate, Case When b.max_output = 0 Then null Else b.max_output End max_output, "+
                //                                          "Case when(b.max_output = 0 Or b.alternative_uomvalue = 0) then null  Else  round(d.unit_value / (b.max_output / b.alternative_uomvalue), 2)End "+
                //                                          "testrate from hospital.clinstore_deptinv_master t, hospital.clinstore_item_master b, (select distinct t.sdep_id, t.sdep_name from hospital.lab_dental_sdepartment t)  c, "+
                //                                          "hospital.clinic_master a, hospital.clinstore_item_unitrate d, hospital.clinstore_secondary_units e where t.item_id = b.item_id and c.sdep_id = t.sdept_id "+
                //                                          "and a.branch_id = t.branch_id and d.item_id = t.item_id and d.branchid = t.branch_id and e.sec_unit_id = b.sec_unit_id and t.current_stock > 0) x "+
                //                                          "left outer join(select f.branch_id, f.item_id, max(f.expiry_date) ExpDate from hospital.clinstore_inventory_dtl f group by f.branch_id, f.item_id) y "+
                //                                          "on(x.branch_id = y.branch_id and x.item_id = y.item_id) where x.current_stock<>0 and x.sdep_id = "+deptid+" and y.branch_id = "+branch_id+ " order by item_name");

                ObjDataSet = ObjOrclHelper.ExecuteDataSet("select x.firm_id,x.BRANCH_NAME,x.item_id,x.item_name,x.sdep_name,x.sdep_id,x.current_stock,x.sec_unit_name sub_measurement,x.unit_value unit_rate, x.rate Tot_Amt, x.ExpDate, x.max_output, x.testrate," +
                                                          " '' as Phy_Stk, '' as Diff from(select a.firm_id,a.branch_id, a.name BRANCH_NAME, b.item_id, b.item_name, c.sdep_name, c.sdep_id, t.current_stock, e.sec_unit_name, d.unit_value,round(t.current_stock * d.unit_value, 2) rate, " +
                                                          "Case When b.max_output = 0 Then null Else b.max_output End max_output,Case when(b.max_output = 0 Or b.alternative_uomvalue = 0) then null  Else  round(d.unit_value / (b.max_output / b.alternative_uomvalue), 2)End testrate," +
                                                          "(select max(f.expiry_date) ExpDate from hospital.clinstore_inventory_dtl f where f.branch_id = a.branch_id and f.item_id = b.item_id) ExpDate from hospital.clinstore_deptinv_master t, hospital.clinstore_item_master b, " +
                                                          "(select distinct t.sdep_id, t.sdep_name from hospital.lab_dental_sdepartment t)  c, hospital.clinic_master a, hospital.clinstore_item_unitrate d, hospital.clinstore_secondary_units e where t.item_id = b.item_id and " +
                                                          "c.sdep_id = t.sdept_id and a.branch_id = t.branch_id and d.item_id = t.item_id and d.branchid = t.branch_id and e.sec_unit_id = b.sec_unit_id and t.current_stock > 0 and t.current_stock <> 0 and c.sdep_id = " + deptid + " and a.branch_id = " + branch_id + ")x ");
            }
            return ObjDataSet;
        }
        #endregion

        #region Select BranchVisit_Registertypes
        [WebMethod]
        public DataSet Select_BranchVisir_RegType()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select * from OPERATION_BRANCHVISITREGISTER");
            return ObjDataSet;
        }
        #endregion

        #region Select BranchVisit_AsstVerfn
        [WebMethod]
        public DataSet Select_BranchVisir_AsstVerfn()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select * from OPERATION_BRANCHVISITASSTVERFN");
            return ObjDataSet;
        }
        #endregion

        //...................................................................................................

        #region Select Inventory_TocheckExists
        [WebMethod]
        public DataSet Select_Inventory_Exists(int BranchID,int dept_id,string Month_,int Year_,string month_type)
        {
            DataSet dsInventory = ObjOrclHelper.ExecuteDataSet("select * from OPERATION_INVENTORY_STATUS where Branch_Id=" + BranchID + " and dept_id=" + dept_id + " and Month_='" + Month_ + "' and Year_=" + Year_ + " and month_type='" + month_type + "'");
            return dsInventory;
        }
        #endregion

        #region InventoryStatus_Register Insert/Update
        [WebMethod()]
        public int InventoryRegister_InsertUpdate(int BranchID, int dept_id, string department, string Month_, int Year_, string Entered_by, string Itemname, string Stock, string Measurement, string Unitrate, string TotalAmount, string PhysicalStock, string Deviation, string month_type)
        {
            int result = 0;
            try
            {

                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_INVENTORY_STATUS(Id,Branch_Id,Dept_id,Department,Month_,Year_,Date_,Entered_by,itemname,stock,measurement,unitrate,Totalamount,physicalstock,deviation,month_type) " +
                    "values(SEQ_AMB.nextval," + BranchID + "," + dept_id + ",'" + department + "','" + Month_ + "'," + Year_ + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + Itemname + "','" + Stock + "','" + Measurement + "','" + Unitrate + "','" + TotalAmount + "','" + PhysicalStock + "','" + Deviation + "','" + month_type + "')");

            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select InventoryStatus
        [WebMethod]
        public DataSet Select_InventoryStatus(int branch_id,int dept_id,string month,int year,string month_type)
        {
            if(dept_id==0 && branch_id!=1256)
                 ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_INVENTORY_STATUS a join login_users b on a.entered_by=b.username where a.branch_id=" + branch_id+" and a.month_='"+month+"' and a.year_="+year+" and month_type='"+month_type+"'");
            else ObjDataSet = ObjOrclHelper.ExecuteDataSet("" +
                "select b.log_user,a.* from OPERATION_INVENTORY_STATUS a join login_users b on a.entered_by=b.username where a.branch_id=" + branch_id + " and a.month_='" + month + "' and a.year_=" + year + " and a.dept_id="+dept_id+" and a.month_type='"+month_type+"'");
            return ObjDataSet;
        }
        #endregion

        #region BranchVisit_Asset Insert/Update
        [WebMethod()]
        public int BranchVisit_Asset_InsertUpdate(int BranchID,string Month_, int Year_, string Entered_by, string AssetVerifn, string WorkingStatus, string Remarks)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_BRANCH_ASSET(Id,Branch_Id,Month_,Year_,Date_,Entered_by,Asset_Verification,Workingstatus,Remarks) " +
                    "values(SEQ_AMB.nextval," + BranchID + ",'" + Month_ + "'," + Year_ + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + AssetVerifn + "','" + WorkingStatus + "','" + Remarks + "')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select BranchVisit_Asset
        [WebMethod]
        public DataSet Select_Branchvisit_Asset(int branch_id,string month, int year, string Entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_BRANCH_ASSET a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.month_='" + month + "' and a.year_=" + year + " and a.entered_by='" + Entered_by + "'");
            return ObjDataSet;
        }
        #endregion

        #region BranchVisit_CashPosition Insert/Update
        [WebMethod()]
        public int BranchVisit_CashPosition_InsertUpdate(int BranchID, string Month_, int Year_, string Entered_by, string physicalcash1,string systemcash1, string diff1, string physicalcash2, string systemcash2, string diff2)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_BRANCH_CASHPOSITION(Id,Branch_Id,Month_,Year_,Date_,Entered_by,physicalcash1,systemcash1,diff1,physicalcash2,systemcash2,diff2) " +
                    "values(SEQ_AMB.nextval," + BranchID + ",'" + Month_ + "'," + Year_ + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + physicalcash1 + "','" + systemcash1 + "','" + diff1 + "','"+physicalcash2+"','"+systemcash2+"','"+diff2+"')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select BranchVisit_Cashposition
        [WebMethod]
        public DataSet Select_Branchvisit_Cashposition(int branch_id, string month, int year, string Entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_BRANCH_CASHPOSITION a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.month_='" + month + "' and a.year_=" + year + " and a.entered_by='"+Entered_by+"'");
            return ObjDataSet;
        }
        #endregion

        #region BranchVisit_Registers Insert/Update
        [WebMethod()]
        public int BranchVisit_Registers_InsertUpdate(int BranchID, string Month_, int Year_, string Entered_by, string updateregister, string status, string remarks)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_BRANCH_REGISTERS(Id,Branch_Id,Month_,Year_,Date_,Entered_by,updateregister,status,remarks) " +
                    "values(SEQ_AMB.nextval," + BranchID + ",'" + Month_ + "'," + Year_ + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + updateregister + "','" + status + "','" + remarks + "')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select BranchVisit_Registers
        [WebMethod]
        public DataSet Select_Branchvisit_Registers(int branch_id, string month, int year, string Entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_BRANCH_REGISTERS a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.month_='" + month + "' and a.year_=" + year + " and a.entered_by='" + Entered_by + "'");
            return ObjDataSet;
        }
        #endregion

        #region ChargeRpt_Asset Insert/Update
        [WebMethod()]
        public int ChargeRpt_Asset_InsertUpdate(int BranchID,string Entered_by, string Asset_type, string Asset_id, string item,string make,string model)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_CHARGERPT_ASSET(Id,Branch_Id,Date_,Entered_by,Asset_Type,Asset_id,item,make,model)" +
                    " values(SEQ_AMB.nextval," + BranchID + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + Asset_type + "','" + Asset_id + "','" + item + "','"+make+"','"+model+"')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select ChargeRpt_Asset
        [WebMethod]
        public DataSet Select_ChargeRpt_Asset(int branch_id,string entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_CHARGERPT_ASSET a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.entered_by='"+entered_by+"'");
            return ObjDataSet;
        }
        #endregion

        #region ChargeRpt_Cash Insert/Update
        [WebMethod()]
        public int ChargeRpt_Cash_InsertUpdate(int BranchID, string Entered_by, string Physical1, string System1, string Diff1, string Remarks1, string Physical2, string System2, string Diff2, string Remarks2)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_CHARGERPT_CASH(Id,Branch_Id,Date_,Entered_by,Physical1,System1,Diff1,Remarks1,Physical2,System2,Diff2,Remarks2)" +
                    " values(SEQ_AMB.nextval," + BranchID + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + Physical1 + "','" + System1 + "','"+ Diff1 + "','" +Remarks1+ "','" + Physical2 + "','" + System2 + "','" + Diff2 + "','"+Remarks2+"')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select ChargeRpt_Cash
        [WebMethod]
        public DataSet Select_ChargeRpt_Cash(int branch_id, string Entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_CHARGERPT_CASH a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.entered_by='"+Entered_by+"'");
            return ObjDataSet;
        }
        #endregion

        #region ChargeRpt_Registers Insert/Update
        [WebMethod()]
        public int ChargeRpt_Registers_InsertUpdate(int BranchID, string Entered_by, string UpdateReg, string status, string remarks)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_CHARGERPT_REGISTERS(Id,Branch_Id,Date_,Entered_by,updateregister,status,Remarks) " +
                    " values(SEQ_AMB.nextval," + BranchID + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + UpdateReg + "','" + status + "','" + remarks + "')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select ChargeRpt_Registers
        [WebMethod]
        public DataSet Select_ChargeRpt_Registers(int branch_id, string entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_CHARGERPT_REGISTERS a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.entered_by='" + entered_by + "'");
            return ObjDataSet;
        }
        #endregion

        #region ChargeRpt_Doctors Insert/Update
        [WebMethod()]
        public int ChargeRpt_Doctors_InsertUpdate(int BranchID, string Entered_by, string Name, string Department, string Specialyst, string Visitday)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_CHARGERPT_DOCTORS(Id,Branch_Id,Date_,Entered_by,Name,Department,Specialyst,VisitDay)" +
                    " values(SEQ_AMB.nextval," + BranchID + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" +Name+ "','" + Department + "','" + Specialyst + "','" + Visitday + "')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select ChargeRpt_Doctors
        [WebMethod]
        public DataSet Select_ChargeRpt_Doctors(int branch_id, string entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_CHARGERPT_DOCTORS a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.entered_by='" + entered_by + "'");
            return ObjDataSet;
        }
        #endregion

        #region ChargeRpt_Key Insert/Update
        [WebMethod()]
        public int ChargeRpt_Key_InsertUpdate(int BranchID, string Entered_by, string KeyName, string Count, string Missing, string Remarks)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_CHARGERPT_KEY(Id,Branch_Id,Date_,Entered_by,KeyName,Count,Missing,Remarks)" +
                    " values(SEQ_AMB.nextval," + BranchID + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + KeyName + "','" + Count + "','" + Missing + "','" + Remarks + "')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select ChargeRpt_Key
        [WebMethod]
        public DataSet Select_ChargeRpt_Key(int branch_id, string entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_CHARGERPT_KEY a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.entered_by='" + entered_by + "'");
            return ObjDataSet;
        }
        #endregion

        #region ChargeRpt_Vertical Insert/Update
        [WebMethod()]
        public int ChargeRpt_Vertical_InsertUpdate(int BranchID, string Entered_by, string Service, string Machine_Status, string WorkingCondition, string Remarks)
        {
            int result = 0;
            try
            {
                result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_CHARGERPT_VERTICAL(Id,Branch_Id,Date_,Entered_by,Service,Machine_Status,WorkingCondition,Remarks)" +
                    " values(SEQ_AMB.nextval," + BranchID + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + Entered_by + "','" + Service + "','" + Machine_Status + "','" + WorkingCondition + "','" + Remarks + "')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region Select ChargeRpt_Vertical
        [WebMethod]
        public DataSet Select_ChargeRpt_Vertical(int branch_id, string entered_by)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.log_user,a.* from OPERATION_CHARGERPT_VERTICAL a join login_users b on a.entered_by = b.username where a.branch_id=" + branch_id + " and a.entered_by='" + entered_by + "'");
            return ObjDataSet;
        }
        #endregion

        #region Select BranchVisit_Enteredstaff
        [WebMethod]
        public DataSet Select_Branchvisit_EnteredStaff(int branch_id, string month, int year)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select distinct b.log_user||'--'||a.entered_by as staff,a.entered_by from operation_branch_cashposition a join login_users b on a.entered_by=b.username where a.branch_id=" + branch_id + " and a.month_='" + month + "' and a.year_=" + year + "");
            return ObjDataSet;
        }
        #endregion

        #region Select ChargeRpt_Enteredstaff
        [WebMethod]
        public DataSet Select_ChargeRpt_EnteredStaff(int branch_id)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select distinct b.log_user||'--'||a.entered_by as staff,a.entered_by from operation_chargerpt_cash a join login_users b on a.entered_by=b.username where a.branch_id=" + branch_id + "");
            return ObjDataSet;
        }
        #endregion

        #region Select BranchVisit_Registers
        [WebMethod]
        public DataSet Select_AmbienceRpt(int branch_id, int month, int year)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select OPERATION_AMBIENCEREGISTER.AMB_NAME Ambience,OPERATION_AMBIENCECONDTN.Amb_Count Count, OPERATION_AMBIENCECONDTN.Amb_Condtn Condition, OPERATION_AMBIENCECONDTN.Amb_Remarks Remarks," +
                                                      "CASE WHEN OPERATION_AMBIENCECONDTN.Amb_Checked = 1 THEN 'checked' ELSE 'Not checked' END as Checked,OPERATION_AMBIENCECONDTN.Amb_Reason Reason,OPERATION_AMBIENCECONDTN.AMB_ENTERED,OPERATION_AMBIENCECONDTN.AMB_DATE" +
                                                      "clinic_master.Name as Branch_Name, (select designation from Login_users where username = operation_ambiencecondtn.amb_entered) Designation,"+
                                                      "(select Log_User from Login_users where username = operation_ambiencecondtn.amb_entered) Log_user "+
                                                      "from OPERATION_AMBIENCECONDTN join OPERATION_AMBIENCEREGISTER ON OPERATION_AMBIENCECONDTN.AMB_ID = OPERATION_AMBIENCEREGISTER.AMB_ID "+
                                                      "join hospital.clinic_master on clinic_master.branch_id = OPERATION_AMBIENCECONDTN.BRANCH_ID where OPERATION_AMBIENCECONDTN.BRANCH_ID=" + branch_id + " and " +
                                                      "OPERATION_AMBIENCECONDTN.Year_=" + year + " and OPERATION_AMBIENCECONDTN.month_ = " + month + "");
            return ObjDataSet;
        }
        #endregion

        //.................................................................................................

        #region Select Optical_Stock
        [WebMethod]
        public DataSet Select_OpticalStock(int branch_id)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select p.branch_id,p.name,sum(p.quantity) stock,p.category,'' PStock,'' Diff from (select brn.branch_id, brn.name, sup.supplier_name, dtl.ORDER_NO, inv.grn_no, dtl.INVOICE_ID, inv.invoice_no, inv.invoice_dt, inv.tra_dt,q.item_name,dtl.BATCH_NO, dtl.QUANTITY, dtl.PRI_MRP, dtl.PRI_COST, " +
                "dtl.SEC_STOCK * dtl.PRI_COST StockValue, dtl.itemtype_name1, dtl.itemsubtype_name1, dtl.itemtype_name2,dtl.itemsubtype_name2, dtl.itemtype_name3, dtl.itemsubtype_name3, dtl.itemtype_name4, dtl.itemsubtype_name4, dtl.itemtype_name5, dtl.itemsubtype_name5,dtl.itemtype_name6, dtl.itemsubtype_name6, " +
                "dtl.itemtype_name7, dtl.itemsubtype_name7, dtl.itemtype_name8, dtl.itemsubtype_name8, dtl.itemtype_name9,dtl.itemsubtype_name9, dtl.itemtype_name10, dtl.itemsubtype_name10, dtl.itemtype_name11, dtl.itemsubtype_name11, dtl.itemtype_name12, dtl.itemsubtype_name12,dtl.itemtype_name13, dtl.itemsubtype_name13, " +
                "decode(dtl.ITEM_ID, '1', 'FRAMES', '2', 'LENSES', '3', 'SUNGLASS', '4', 'CONTACT LENSES', '6', 'READING GLASSES') Category from hospital.optical_vew_inventory_dtl dtl inner join hospital.optical_invoice_master inv on dtl.INVOICE_ID = inv.invoice_id inner join hospital.optical_item_master q on " +
                "dtl.ITEM_ID = q.item_id Left outer join hospital.clinic_master brn on dtl.BRANCH_ID = brn.branch_id Left outer join hospital.optical_supplier_master sup on dtl.SUPPLIER_ID = sup.supplier_id where dtl.SEC_STOCK > 0 and /*inv.status_id=1 and*/ brn.branch_id = "+branch_id+" order by brn.name, sup.supplier_name, Category, q.item_name) p " +
                "where p.category not in ('OTHER ITEMS') group by p.branch_id,p.category,p.name");
            return ObjDataSet;
        }
        #endregion

        #region Optical_Stock Insert/Update
        [WebMethod()]
        public int OpticalStock_InsertUpdate(int branchid, string category, int stk, int Pstk, string entered_by)
        {
            int result = 0;
            DataSet dtexists = ObjOrclHelper.ExecuteDataSet("select * from Operation_Optical_StockEntry where branch_id="+branchid+" and entered_date=to_char(sysdate,'dd-MM-yyyy') and category='"+category+"'");
            if (dtexists.Tables[0].Rows.Count == 0)
            {
                try
                {
                    result = ObjOrclHelper.ExecuteNonQuery("insert into Operation_Optical_StockEntry(BRANCH_ID,category,STOCK,PSTOCK,ENTERED_DATE,ENTERED_BY) " +
                        "values(" + branchid + ",'" + category + "'," + stk + "," + Pstk + ",'" + DateTime.Now.ToString("dd-MM-yyyy") + "','" + entered_by + "')");
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }
        #endregion

        #region Select Optical_Stock
        [WebMethod]
        public DataSet Select_OpticalStockEntry(int branch_id,string fromdte,string todate)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select branch_id,category,stock,pstock,entered_by,entered_date,pstock-stock diff from Operation_Optical_StockEntry where branch_id=" + branch_id+ " and to_date(entered_date,'dd-MM-yyyy') between to_date('"+fromdte+"','dd-MM-yyyy') and to_date('"+todate+"','dd-MM-yyyy') order by entered_date,category");//EXTRACT (MONTH FROM to_date(Entered_date,'dd-MM-yyyy')) ='" + month+ "' and EXTRACT (YEAR FROM to_date(Entered_date,'dd-MM-yyyy')) = '" + year+"'
            return ObjDataSet;
        }
        #endregion

        #region Branch_Select
        [WebMethod]
        public DataSet Select_unit()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select branch_id,branch_name from MACARE_UNITMASTER where branch_type like '%Opticals%'");
            return ObjDataSet;
        }
        #endregion

        #region Select Optical_Stock
        [WebMethod]
        public DataSet Select_FixedAsset(int branch_id, int Month_, int Year_)
        {
            //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select branch_id,category,stock,pstock,entered_by,entered_date,pstock-stock diff from Operation_Optical_StockEntry where branch_id=" + branch_id + " and Month_=" + Month_ + " and Year_=" + Year_ + " order by entered_date,category");//EXTRACT (MONTH FROM to_date(Entered_date,'dd-MM-yyyy')) ='" + month+ "' and EXTRACT (YEAR FROM to_date(Entered_date,'dd-MM-yyyy')) = '" + year+"'
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.class_name,a.asset_id,c.item_name,d.make_name,e.model_name,cm.name branch " +
                                                      "from mactech.FA_MASTER a join mactech.FA_Class_master b on a.class_id=b.class_id join mactech.fa_item_master c on a.item_id=c.item_id " +
                                                      "join mactech.fa_make_master d on d.make_id = a.make_id join mactech.fa_model_master e on e.model_id = a.model_id join hospital.clinic_master cm on " +
                                                      "cm.branch_id = a.branch_id where branch_id=" + branch_id + " and Month_=" + Month_ + " and Year_=" + Year_ + " order by class_name, item_name");
            return ObjDataSet;
        }
        #endregion

        #region Select Macare_units
        [WebMethod]
        public DataSet Select_Macare_Opticals()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select * from macare_unitmaster where branch_type='Bangalore Opticals' or branch_type='Opticals'");
            return ObjDataSet;
        }
        #endregion

        //................................................................................................

        #region FixedAsset Insert/Update
        [WebMethod()]
        public int FixedAsset_InsertUpdate(string class_name,string asset_id,string item_name,string make_name,string model_name,string working,string notworking,string available,int branchid,int month,int year,string entered_by,string entered_date)
        {
            int result = 0;
            DataSet dtexists = ObjOrclHelper.ExecuteDataSet("select * from OPERATION_FIXEDASSETCONDTN where branchid=" + branchid + " and month="+month+" and year="+year+" and class_name='"+class_name+"' and asset_id='"+asset_id+"' and item_name='"+item_name+"' and make_name='"+make_name+"' and model_name='"+model_name+"'");
            if (dtexists.Tables[0].Rows.Count == 0)
            {
                try
                {
                    result = ObjOrclHelper.ExecuteNonQuery("insert into OPERATION_FIXEDASSETCONDTN(class_name,asset_id,item_name,make_name,model_name,working,notworking,available,branchid,month,year,entered_by,entered_date) " +
                        "values('" + class_name + "','" + asset_id + "','" + item_name +"','" + make_name+ "','" + model_name+ "','"+working+"','"+notworking+"','"+available+"',"+branchid+","+month+","+year+",'"+entered_by+"','"+entered_date+"')");
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }
        #endregion

        #region Select FixedAsset_Entry
        [WebMethod]
        public DataSet Select_FixedAssetEntry_ForVerifn(int branch_id, int month, int year)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select distinct f.*,lg.log_user,cm.name branch from OPERATION_FIXEDASSETCONDTN f join login_users lg on lg.username=f.ENTERED_BY join hospital.clinic_master cm on cm.branch_id= f.BRANCHID where f.branchid=" + branch_id + " and f.month="+month+" and f.year="+year+" order by f.class_name");//EXTRACT (MONTH FROM to_date(Entered_date,'dd-MM-yyyy')) ='" + month+ "' and EXTRACT (YEAR FROM to_date(Entered_date,'dd-MM-yyyy')) = '" + year+"'
            return ObjDataSet;
        }
        #endregion

        #region Select FixedAsset_Entry
        [WebMethod]
        public DataSet Select_FixedAssetEntry(int branch_id, int month, int year)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select distinct f.class_name,f.asset_id,f.item_name,f.make_name,f.model_name,case when f.working='0' then 'NO' else 'YES' end working,case when f.notworking='0' then 'NO' else 'YES' end notworking," +
                                                      "case when f.available = '0' then 'NO' else 'YES' end available, f.branchid,f.month,f.year,f.entered_by,f.entered_date,lg.log_user,cm.name branch from OPERATION_FIXEDASSETCONDTN f join login_users lg on lg.username = f.ENTERED_BY " +
                                                      "join hospital.clinic_master cm on cm.branch_id = f.BRANCHID where f.branchid=" + branch_id + " and f.month=" + month + " and f.year=" + year + " order by f.class_name");//EXTRACT (MONTH FROM to_date(Entered_date,'dd-MM-yyyy')) ='" + month+ "' and EXTRACT (YEAR FROM to_date(Entered_date,'dd-MM-yyyy')) = '" + year+"'
            return ObjDataSet;
        }
        #endregion

        #region Select Fixed_Asset
        [WebMethod]
        public DataSet Select_FixedAsset_Load(int branch_id)
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select b.class_name,a.asset_id,c.item_name,d.make_name,e.model_name,cm.name branch,cm.branch_id,'0' working,'0' Notworking,'0' Available from mactech.FA_MASTER a join mactech.FA_Class_master b on a.class_id=b.class_id join mactech.fa_item_master c on a.item_id=c.item_id " +
                                                      "join mactech.fa_make_master d on d.make_id = a.make_id join mactech.fa_model_master e on e.model_id = a.model_id join hospital.clinic_master cm on cm.branch_id = a.branch_id where a.branch_id = "+branch_id+ "  and c.firm_id=16 order by class_name, item_name");//EXTRACT (MONTH FROM to_date(Entered_date,'dd-MM-yyyy')) ='" + month+ "' and EXTRACT (YEAR FROM to_date(Entered_date,'dd-MM-yyyy')) = '" + year+"'
            return ObjDataSet;
        }
        #endregion

        //..........................................................................................................................................................

        #region NABL Insert/Update
        [WebMethod()]
        public int NABL_Renew_InsertUpdate(int branch_id,string Issue_date, string end_date, string reminder_date)
        {
            int result = 0;
            try
            {
                DataTable ds = ObjOrclHelper.ExecuteDataSet("select nvl(max(Id),0) from NABL_ACCREDITATION").Tables[0];
                int Id = Convert.ToInt32(ds.Rows[0][0])+1;
                result = ObjOrclHelper.ExecuteNonQuery("insert into NABL_ACCREDITATION(branch_id,issued_date,end_date,reminder_date,Id) " +
                    "values(" + branch_id + ",'" + Issue_date + "','" + end_date + "','" + reminder_date + "','"+Id+"')");
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        #endregion

        #region NABL delete
        [WebMethod()]
        public int NABL_Renew_Delete(int Id)
        {
            int result = ObjOrclHelper.ExecuteNonQuery("delete from NABL_ACCREDITATION OPERATION_INVENTORYSTATUS  where Id=" + Id + "");
            return result;
        }
        #endregion

        #region Select NABL
        [WebMethod]
        public DataSet Select_NABL()
        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select a.*,b.name branch_name from NABL_ACCREDITATION a join hospital.clinic_master b on a.branch_id=b.branch_id");
            return ObjDataSet;
        }
        #endregion

        #region Select NABL_Reminder
        [WebMethod]
        public DataSet Check_ReminderDate()
        {
            //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select a.*,b.name branch_name from NABL_ACCREDITATION a join hospital.clinic_master b on a.branch_id=b.branch_id where to_date(a.reminder_date,'dd-MM-yyyy')=to_date(sysdate,'dd-MM-yyyy')");
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select * from (select a.branch_id,to_date(a.issued_date,'dd-MM-yyyy') issued_date,to_date(replace(end_date,'00:00:00',null),'dd-MM-yyyy') end_date,to_date(replace(reminder_date, '00:00:00', null), 'dd-MM-yyyy') reminder_date, " +
                "a.id, (select to_char(sysdate, 'dd-MM-yyyy') from dual)sysdate_ from NABL_ACCREDITATION a where a.Id = (select max(ID)from NABL_ACCREDITATION) )m where to_date(m.reminder_date, 'dd-MM-yyyy') <= to_date(m.sysdate_, 'dd-MM-yyyy')");
            return ObjDataSet;
        }
        #endregion

        #region Select NABL_Reminder
        [WebMethod]
        public DataSet Check_ReminderDate_Alert()
        {
            //ObjDataSet = ObjOrclHelper.ExecuteDataSet("select * from (select a.branch_id,to_date(a.issued_date,'dd-MM-yyyy') issued_date,to_date(replace(end_date,'00:00:00',null),'dd-MM-yyyy') end_date,to_date(replace(reminder_date, '00:00:00', null), 'dd-MM-yyyy') reminder_date, " +
            //    "a.id, (select to_char(sysdate, 'dd-MM-yyyy') from dual)sysdate_ from NABL_ACCREDITATION a where a.Id = (select max(ID)from NABL_ACCREDITATION) )m where to_date(m.reminder_date, 'dd-MM-yyyy') = to_date(m.sysdate_, 'dd-MM-yyyy')");
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select a.* from NABL_ACCREDITATION a where a.id=(select max(ID)from NABL_ACCREDITATION) and to_date(a.reminder_date,'dd-MM-yyyy')=to_date(sysdate,'dd-MM-yyyy')");
            return ObjDataSet;
        }
        #endregion

        #region Select Macare_units
        [WebMethod]
        public DataSet Select_Macare_Labs()

        {
            ObjDataSet = ObjOrclHelper.ExecuteDataSet("select * from macare_unitmaster where branch_type='Lab'");
            return ObjDataSet;
        }
        #endregion
        [WebMethod]
        public int Insert_AgreementRenewal(int agrmnt_id, string agrmnt_type, string agrmnt_party, string date_of_exectn, string next_renewal, string first_alert, string second_alert, string third_alert, string updated_on, string updated_by)
        {
            int id = 0;
            string query = "";
            query = "select max(agrmnt_id)+1 from AGREEMENT_RENEWAL";
            DataTable dt = ObjOrclHelper.ExecuteDataSet(query).Tables[0];
            if (dt.Rows[0][0].ToString() == "")
                id = 1;
            else id = Convert.ToInt32(dt.Rows[0][0].ToString());
            query = "insert into AGREEMENT_RENEWAL values (" + agrmnt_id + ",'" + agrmnt_type + "','" + agrmnt_party + "','" + date_of_exectn + "','" + next_renewal + "','" + first_alert + "','" + second_alert + "','" + third_alert + "','" + updated_on + "','" + updated_by + "')";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int update_AgreementRenewal(int agrmnt_id, string agrmnt_type, string agrmnt_party, string date_of_exectn, string next_renewal, string first_alert, string second_alert, string third_alert, string updated_on, string updated_by)
        {
            int id = 0;
            string query = "";
            query = "update AGREEMENT_RENEWAL set agrmnt_type='" + agrmnt_type + "',agrmnt_party='" + agrmnt_party + "',date_of_execution='" + date_of_exectn + "',next_renewal='" + next_renewal + "',first_alert='" + first_alert + "',second_alert='" + second_alert + "',third_alert='" + third_alert + "',updated_on='" + updated_on + "',updated_by='" + updated_by + "' where agrmnt_id=" + agrmnt_id + "";
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public DataSet Get_grid_Agrmnt_renewal()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from AGREEMENT_RENEWAL");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Check_Agrmnt_renewal()
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select a.agrmnt_type,a.agrmnt_party,a.date_of_execution,a.next_renewal " +
                "from agreement_renewal a where to_date(a.next_renewal,'dd-MM-yyyy')=to_date(sysdate,'dd-MM-yyyy') " +
                "or to_date(a.first_alert,'dd-MM-yyyy')=to_date(sysdate,'dd-MM-yyyy') or to_date(a.second_alert,'dd-MM-yyyy')= to_date(sysdate, 'dd-MM-yyyy') " +
                "or to_date(a.third_alert,'dd-MM-yyyy')= to_date(sysdate, 'dd-MM-yyyy')");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }
    }
}
