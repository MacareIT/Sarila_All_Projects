using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pharmacy_Service
{
    /// <summary>
    /// Summary description for ClinicService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ClinicService : System.Web.Services.WebService
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
        public DataSet List_medicines()
        {
            ds = new DataSet();
            string query = " select * from HOSPITAL.PHARMA_ITEM_MASTER";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Hospital_Clinic_MicrolabList()
        {
            ds = new DataSet();
            string query = "select * from hospital.clinic_master cm where cm.firm_id=16 and cm.clinic_id not in (37,14,18) and  cm.branch_type =4 union select * from hospital.clinic_master cmm where cmm.clinic_id=2";
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
        public DataSet ListClinic()
        {
            ds = new DataSet();
            //string query = "select t.*, t.rowid from HOSPITAL.CLINIC_MASTER t where t.status=1 and t.firm_id=16 and t.branch_type=1";
            string query = "select a.* from HOSPITAL.CLINIC_MASTER a join macare_unitmaster b on a.branch_id=b.branch_id where b.branch_type in ('Clinic','Dental','Opticals') or a.branch_id=1257 order by a.clinic_id";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet ListClinic_Microlab()
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from HOSPITAL.CLINIC_MASTER t where t.status=1 and t.firm_id=16";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet MacareClinic_Microlab()
        {
            ds = new DataSet();
            string query = "select t.* from HOSPITAL.CLINIC_MASTER t where t.status=1 and t.firm_id=16 and t.branch_type=1 and t.clinic_id not in (8) union select * from hospital.clinic_master cm where cm.firm_id=16 and cm.clinic_id not in (37,14,18,8) and  cm.branch_type =4 union select * from hospital.clinic_master cmm where cmm.clinic_id = 2";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Listdepartment()
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from HOSPITAL.DGN_DEPARTMENT_MASTER t";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet ListPharmacy()
        {
            ds = new DataSet();
            string query = "select * from hospital.pharmacy_master where firm_id=16 and status=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Hospital_Departments()
        {
            ds = new DataSet();
            string query = "select t.dept_id, t.dept_name from HOSPITAL.DEPARTMENT t ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet ListDoctors_VisitCount(string frmdt, string todt, string branchid)
        {
            ds = new DataSet();
            string query = "select * from (select sm.name, sm.staff_id,d.dept_name,(select count(*) from HOSPITAL.CLINIC_PAYMENT_MASTER t where sm.staff_id = t.dr_id and to_date(t.bill_date,'dd-MM-yyyy')between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + ")PatientCount,(select sum(count(distinct to_date(t.bill_date, 'dd-MM-yyyy'))) from HOSPITAL.CLINIC_PAYMENT_MASTER t where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy')between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + " group by to_date(t.bill_date, 'dd-MM-yyyy'))VisitCount from HOSPITAL.STAFF_MASTER sm join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id  order by sm.dept_id ) m where m.VisitCount>0";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet ListDoctors_VisitCount_Datewise(string frmdt, string todt, string branchid, string deptid, string option, string value)
        {
            ds = new DataSet(); string query;
            if (Convert.ToInt32(deptid) <= 0)
            {
                if (option == "ALL")
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + "  group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name order by d.dept_name";
                else if (option == "GREATER")
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + "  group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name having count(to_date(t.bill_date,'dd-MM-yyyy'))>=" + value + " order by d.dept_name";
                else if (option == "LESSER")
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + " group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name having count(to_date(t.bill_date,'dd-MM-yyyy'))<" + value + " order by d.dept_name";
                else
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + " group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name having count(to_date(t.bill_date,'dd-MM-yyyy'))=" + value + " order by d.dept_name";
                ds = Objorclhelper.ExecuteDataset(query);
            }
            else
            {
                if (option == "ALL")
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + " and d.dept_id = " + deptid + " group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name order by sm.name";
                else if (option == "GREATER")
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + " and d.dept_id = " + deptid + " group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name having count(to_date(t.bill_date,'dd-MM-yyyy'))>=" + value + " order by sm.name";
                else if (option == "LESSER")
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + " and d.dept_id = " + deptid + " group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name having count(to_date(t.bill_date,'dd-MM-yyyy'))<" + value + " order by sm.name";
                else
                    query = "select sm.name,d.dept_name,count(to_date(t.bill_date,'dd-MM-yyyy')) PatientCount ,to_date(t.bill_date,'dd-MM-yyyy') VisitDate from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.STAFF_MASTER sm on t.dr_id = sm.staff_id join HOSPITAL.DEPARTMENT d on d.dept_id = sm.dept_id where t.dr_id = sm.staff_id and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + branchid + " and d.dept_id = " + deptid + " group by to_date(t.bill_date, 'dd-MM-yyyy'),sm.name,d.dept_name having count(to_date(t.bill_date,'dd-MM-yyyy'))=" + value + " order by sm.name";
                ds = Objorclhelper.ExecuteDataset(query);
            }
            return ds;

        }
        [WebMethod]
        public DataSet List_Visit_Doctorwise(string frmdt, string todt, string staffid, string clinicid)
        {
            ds = new DataSet();
            string query = "select t.bill_id,t.opnumber,t.reg_fee,t.consult_fee,t.treatment_charge,t.discount,t.rcvd_amount from HOSPITAL.CLINIC_PAYMENT_MASTER t where t.dr_id = " + staffid + " and to_date(t.bill_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and t.clinic_id = " + clinicid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        //[WebMethod]
        //public DataSet PatientsList_NotVisitPharma(string fromdt, string todt, string clinicid)
        //{
        //    ds = new DataSet();
        //    string query = "select p.name,p.mobile_no,sm.name doctor from HOSPITAL.CLINIC_PAYMENT_MASTER t join HOSPITAL.PATIENT_MASTER p on t.opnumber = p.opnumber join HOSPITAL.staff_MASTER sm on t.dr_id = sm.staff_id where to_date(t.bill_date,'dd-MM-yyyy') between '"+fromdt+"' and '"+todt+"' and t.clinic_id = "+clinicid+" and p.name not in(select t1.patient from HOSPITAL.PHARMA_SALES_MASTER t1 where to_date(t1.tra_dt,'dd-MM-yyyy') between '"+fromdt+"' and '"+todt+"' and t1.branch_id = 2435) order by name";
        //    ds = Objorclhelper.ExecuteDataset(query);

        //    return ds;
        //}
        [WebMethod]
        public DataSet PatientsList_NotVisitPharma(string fromdt, string todt, string clinicid, string pharmacyid1, string pharmacyid2)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[7];
            OracleParameter objOracleParam;

            objOracleParam = new OracleParameter("Prm_fromdt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = fromdt;
            oracleParamArray[0] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_todt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = todt;
            oracleParamArray[1] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_clinicid", OracleType.Int32);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = Convert.ToInt32(clinicid);
            oracleParamArray[2] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_Message", OracleType.VarChar, 500);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[3] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_result", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[4] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_pharmacyid1", OracleType.Int32);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = Convert.ToInt32(pharmacyid1);
            oracleParamArray[5] = objOracleParam;

            objOracleParam = new OracleParameter("prm_pharmacyid2", OracleType.Int32);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = Convert.ToInt32(pharmacyid2);
            oracleParamArray[6] = objOracleParam;

            ds = Objorclhelper.executeNonQuery_dataset("PROC_PATIENT_NOTVISIT_PHARMA", oracleParamArray);
            return ds;
        }
        [WebMethod]
        public DataSet Incentive_calc(string branchid, string date, string pharmacyid1, string pharmacyid2, string opticalid1, string dentalid)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[7];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("cur1", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[0] = objOracleParam;
            objOracleParam = new OracleParameter("prm_branchid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = branchid;
            oracleParamArray[1] = objOracleParam;
            objOracleParam = new OracleParameter("prm_date", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = date;
            oracleParamArray[2] = objOracleParam;
            objOracleParam = new OracleParameter("prm_pharmacyid1", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = pharmacyid1;
            oracleParamArray[3] = objOracleParam;
            objOracleParam = new OracleParameter("prm_pharmacyid2", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = pharmacyid2;
            oracleParamArray[4] = objOracleParam;
            objOracleParam = new OracleParameter("prm_opticalid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = opticalid1;
            oracleParamArray[5] = objOracleParam;
            objOracleParam = new OracleParameter("prm_dentalid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = dentalid;
            oracleParamArray[6] = objOracleParam;
            if (branchid == "1256")
                ds = Objorclhelper.executeNonQuery_dataset("proc_calc_incentive", oracleParamArray);
            else
                ds = Objorclhelper.executeNonQuery_dataset("proc_calc_incentiveBranch", oracleParamArray);
            return ds;
        }
        [WebMethod]
        public DataSet Incentive_calcMicrolab(string branchid, string date)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[2];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("cur1", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[0] = objOracleParam;
            objOracleParam = new OracleParameter("prm_date", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = date;
            oracleParamArray[1] = objOracleParam;
            ds = Objorclhelper.executeNonQuery_dataset("proc_calc_incentive_microlab", oracleParamArray);
            return ds;
        }

        [WebMethod]
        public int MIS_SalesDecr_Billvalue(string fromdt, string todt, string deptid, string pharmacyid)
        {
            int billvalue;
            string query = "select nvl(sum(t.bill_amt),0) billvalue from HOSPITAL.PHARMA_SALES_MASTER t join HOSPITAL.staff_MASTER sm on sm.staff_id = t.doctor_id where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and sm.dept_id = " + deptid + " and t.branch_id = " + pharmacyid + "";
            billvalue = Objorclhelper.executeScalar(query);
            return billvalue;
        }

        [WebMethod]
        public string MIS_SalesDecr_visitcount(string fromdt, string todt, string deptid, string pharmacyid)
        {
            int visitcnt;
            string query = "select count(*) visitcnt from hospital.clinic_payment_master cp join Hospital.Patient_Master pm on cp.opnumber = pm.opnumber where cp.depid = " + deptid + " and to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and pm.name in (select t.patient from HOSPITAL.PHARMA_SALES_MASTER t  where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and t.branch_id = " + pharmacyid + " and t.doctor_id = cp.dr_id)";
            visitcnt = Objorclhelper.executeScalar(query);
            return visitcnt.ToString();
        }
        [WebMethod]
        public int MIS_SalesDecr_noncount(string fromdt, string todt, string deptid, string pharmacyid)
        {
            int billvalue;
            string query = "select count(*) noncount from hospital.clinic_payment_master cp join Hospital.Patient_Master pm on cp.opnumber = pm.opnumber where cp.depid = " + deptid + " and to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and pm.name not in (select t.patient from HOSPITAL.PHARMA_SALES_MASTER t  where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and t.branch_id = " + pharmacyid + " and t.doctor_id = cp.dr_id)";
            billvalue = Objorclhelper.executeScalar(query);
            return billvalue;
        }
        [WebMethod]
        public int MIS_SalesDecr_totpat(string fromdt, string todt, string deptid, string pharmacyid)
        {
            int billvalue;
            string query = "select count(*) totpat from HOSPITAL.Clinic_Payment_Master cp where to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and d.dept_id = " + deptid + "";
            billvalue = Objorclhelper.executeScalar(query);
            return billvalue;
        }
        [WebMethod]
        public DataSet MIS_PharmacyBillvalue(string fromdt, string todt, string flag, string clinicid, string pharmacyid)
        {
            ds = new DataSet();
            string query = "select d.dept_id, d.dept_name deptname,(select nvl(sum(t.bill_amt),0) from HOSPITAL.PHARMA_SALES_MASTER t join HOSPITAL.staff_MASTER sm on sm.staff_id = t.doctor_id where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and sm.dept_id = d.dept_id and t.branch_id = " + pharmacyid + ")billvalue from HOSPITAL.Department d ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet MIS_SalesDecr_TotalCount(string fromdt, string todt, string deptid, string pharmacyid)
        {
            ds = new DataSet();
            string query = "select d.dept_name deptname,(select count(*) from hospital.clinic_payment_master cp join Hospital.Patient_Master pm on cp.opnumber = pm.opnumber where cp.depid = d.dept_id and to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and pm.name in (select t.patient from HOSPITAL.PHARMA_SALES_MASTER t  where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and t.branch_id = " + pharmacyid + " and t.doctor_id = cp.dr_id))vcount, " +
                            "(select count(*) from hospital.clinic_payment_master cp join Hospital.Patient_Master pm on cp.opnumber = pm.opnumber where cp.depid = d.dept_id and to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and pm.name not in (select t.patient from HOSPITAL.PHARMA_SALES_MASTER t  where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and t.branch_id = " + pharmacyid + " and t.doctor_id = cp.dr_id))noncount, " +
                            "(select count(*) from HOSPITAL.Clinic_Payment_Master cp where to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and d.dept_id = cp.depid)totpat from HOSPITAL.Department d ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet MIS_SalesDecr_ValueRPT(string fromdt, string todt, string flag, string clinicid, string pharmacyid)
        {
            ds = new DataSet();
            string query = "select d.dept_name deptname,(select count(*) from hospital.clinic_payment_master cp , HOSPITAL.PHARMA_SALES_MASTER t where cp.depid=d.dept_id and t.doctor_id=cp.dr_id and to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and t.branch_id = 2435  )billvalue, " +
                           "(select count(*) from hospital.clinic_payment_master cp join Hospital.Patient_Master pm on cp.opnumber = pm.opnumber where cp.depid = d.dept_id and to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and pm.name in (select t.patient from HOSPITAL.PHARMA_SALES_MASTER t  where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and t.branch_id = " + pharmacyid + " and t.doctor_id = cp.dr_id))vcount, " +
                           "(select count(*) from hospital.clinic_payment_master cp join Hospital.Patient_Master pm on cp.opnumber = pm.opnumber where cp.depid = d.dept_id and to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and pm.name not in (select t.patient from HOSPITAL.PHARMA_SALES_MASTER t  where to_date(t.tra_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and t.branch_id = " + pharmacyid + " and t.doctor_id = cp.dr_id))noncount, " +
                           "(select count(*) from HOSPITAL.Clinic_Payment_Master cp where to_date(cp.bill_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and d.dept_id = cp.depid)totpat from HOSPITAL.Department d ";

            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet MIS_PurchaseRPT
            (string fromdt, string todt, string flag)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[5];
            OracleParameter objOracleParam;

            objOracleParam = new OracleParameter("Prm_fromdt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = fromdt;
            oracleParamArray[0] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_todt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = todt;
            oracleParamArray[1] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_flag", OracleType.VarChar);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = flag;
            oracleParamArray[2] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_Message", OracleType.VarChar, 500);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[3] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_result", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[4] = objOracleParam;

            ds = Objorclhelper.executeNonQuery_dataset("PROC_MIS_PURCHASE_RPT", oracleParamArray);
            return ds;
        }
        [WebMethod]
        public DataSet MIS_SalesValueLoss_Report(string fromdt, string todt, string clinicid, string pharmacyid)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[5];
            OracleParameter objOracleParam;

            objOracleParam = new OracleParameter("Prm_frmdt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = fromdt;
            oracleParamArray[0] = objOracleParam;

            objOracleParam = new OracleParameter("Prm_todt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = todt;
            oracleParamArray[1] = objOracleParam;

            objOracleParam = new OracleParameter("prm_clinicid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = clinicid;
            oracleParamArray[2] = objOracleParam;

            objOracleParam = new OracleParameter("prm_pharmacyid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = pharmacyid;
            oracleParamArray[3] = objOracleParam;

            objOracleParam = new OracleParameter("cur1", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[4] = objOracleParam;

            ds = Objorclhelper.executeNonQuery_dataset("PROC_MIS_SalesDecrease", oracleParamArray);
            return ds;
        }
        [WebMethod]
        public DataSet MIS_SalesRPT(string frmdt, string todt)
        {
            ds = new DataSet();
            string query = "select d.branch_name, b.bill_no, c.item_name,dtl.batch_no, a.tra_dt, dtl.quantity, case when inv.quantity=0 then nvl(round(((inv.rate)/(inv.strip_size))*dtl.quantity,2),0) else nvl(round(((inv.amount-inv.discount)/(inv.strip_size*inv.quantity))*dtl.quantity,2),0) end as taxlesspurchasecost, Round((b.cess/b.quantity)*dtl.quantity,2) cess, Round((b.discount/b.quantity)*dtl.quantity,2) discount, Round((b.item_val/b.quantity)*dtl.quantity,2) as MRP, Round(((b.item_val-b.igst_value-b.sgst_value-b.cgst_value-b.cess)/b.quantity)*dtl.quantity,4) LedgerAmt, Round((b.tax/b.quantity)*dtl.quantity,2) tax, ((Round(((b.item_val-b.igst_value-b.sgst_value-b.cgst_value-b.cess)/b.quantity)*dtl.quantity,4)) - (case when inv.quantity=0 then nvl(round(((inv.rate)/(inv.strip_size))*dtl.quantity,2),0) else nvl(round(((inv.amount-inv.discount)/(inv.strip_size*inv.quantity))*dtl.quantity,2),0) end)-nvl(Round((b.discount/b.quantity)*dtl.quantity,2),0)) ProfitValue /*round((b.item_val - (nvl(((inv.rate)/(inv.strip_size))*b.quantity,0) + b.discount + b.igst_value + b.cgst_value + b.sgst_value+b.cess)),2) OldProfitValue*/ from hospital.pharma_sales_master a inner join hospital.pharma_sales_dtl b on a.bill_no = b.bill_no inner join hospital.pharma_item_master c on b.item_id = c.item_id Left outer join hospital.pharma_inventory_tran dtl on b.bill_no = dtl.tran_id and b.item_id = dtl.item_id and b.batch_no = dtl.batch_no and b.expiry = dtl.expiry_dt and b.item_id = dtl.item_id and b.batch_no = dtl.batch_no left outer join hospital.pharma_invoice_dtl inv on dtl.invoice_id=inv.invoice_id and dtl.item_id=inv.item_id and dtl.batch_no= inv.batch_no and dtl.expiry_dt=inv.expiry left outer join mactech.branch_master d on a.branch_id = d.branch_id where to_date(a.tra_dt) between To_Date('" + frmdt + "') and To_Date('" + todt + "') and d.firm_id=16 order by a.bill_no,c.item_name";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet SuppliersList()
        {
            ds = new DataSet();
            string query = "select t.* from HOSPITAL.PHARMA_SUPPLIER_MASTER t where t.active=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int updateUsage(string path, string userid)
        {
            //string query; int res = 0;
            //query = "update  CRF_USAGE set USAGE_COUNT=USAGE_COUNT+1,UPDATED_DATE=sysdate  where UPDATED_USER=" + userid + " and path='" + path + "'";
            //res = Objorclhelper.executeNonQuery(query);
            //return res;
            string query; int res = 0;
            query = "insert into CRF_USAGE values(SEQ_CRFUSAGE.nextval,0,1," + userid + ",'" + path + "',sysdate)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int AddincentiveHead(string headname, string userid)
        {
            string query; int res;
            query = "insert into INCENTIVE_HEAD values(SEQ_INCENTIVEHEAD.nextval,'" + headname + "'," + userid + ",sysdate,1)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet ListIncentiveHead()
        {
            ds = new DataSet();
            string query = "select * from INCENTIVE_HEAD";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int AddincentiveSubHead(string headid, string headname)
        {
            string query; int res;
            query = "insert into INCENTIVE_SUBHEAD values(SEQ_INCENTIVEHEAD.nextval," + headid + ",'" + headname + "')";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Incentive_StaffList(string headid, string branchid, string incentivedate, string phramid1, string pharmid2, string opticid1, string dentid1)
        {
            ds = new DataSet(); string query;
            if (headid == "0")
            {
                query = "select sf.* from incentive_staff sf join incentive_head hd on hd.id = sf.headid where lower(hd.incentivehead) like 'microlab'  and sf.branchid = " + branchid + " and sf.empcode in(select emp_code from mactech.attend where to_date(curr_date, 'dd-MM-yyyy') = '" + incentivedate + "' and m_time is not null and branch_id = " + branchid + " )";

            }
            else
            {
                query = "select sf.empcode,sf.empname from incentive_staff sf where sf.branchid=" + branchid + " and sf.headid=" + headid + " and sf.empcode in(select emp_code from mactech.attend where to_date(curr_date, 'dd-MM-yyyy') = '" + incentivedate + "' and m_time is not null and branch_id in (" + branchid + "," + phramid1 + "," + pharmid2 + "," + opticid1 + "," + dentid1 + "))";

            }
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet ListIncentiveStaff(string type, string branchid)
        {
            ds = new DataSet(); string query;
            if (type == "")
            {
                query = "select empname,type from incentive_staff where branchid=" + branchid + " and  type like '%head%' or type like '%microlabincharge%'";
            }
            else
            {
                query = "select empname,sf.empcode,type,hd.incentivehead from incentive_staff sf join incentive_head hd on hd.id=sf.headid where sf.branchid=" + branchid + " and  sf.type = '" + type + "' order by hd.incentivehead";

            }
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet ListIncentiveSubHead(string headid)
        {
            ds = new DataSet();
            string query = "select * from INCENTIVE_SUBHEAD where headid=" + headid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public int AddincentivePercent(string depid, string percnt1, string percnt2, string percent3, string targetcollection, string uptdate, string userid, string branchid)
        {
            string query; int res;
            query = "insert into INCENTIVE_MASTER values(SEQ_INCENTIVE.nextval," + depid + "," + percnt1 + ",'" + uptdate + "'," + userid + ",0," + branchid + "," + percnt2 + "," + percent3 + "," + targetcollection + ",0,0,0)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int AddincentiveAmountPercent(string branchid, string percnt1, string percnt2, string percent3)
        {
            string query; int res;
            query = "insert into INCENTIVE_AMOUNTPERCENT values(SEQ_INCENTIVE.nextval," + branchid + "," + percnt1 + "," + percnt2 + "," + percent3 + ",sysdate,1)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet ListPercentage(string branchid)
        {
            ds = new DataSet();
            string query = "select m.branchid,h.incentivehead,m.incentive_percent1,m.incentive_percent2,m.incentive_percent3,m.targetcollection,m.totalcollection,TO_CHAR(m.update_date, 'FMMonth DD, YYYY') update_date,m.achievedtarget,m.incentiveamount,m.staffcount from incentive_master m join incentive_head h on h.id=m.incentive_headid where m.branchid=" + branchid + " and (m.update_date,m.incentive_headid) in (select max(m1.update_date),m1.incentive_headid from incentive_master m1  where m1.branchid=" + branchid + " group by m1.incentive_headid)";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet ListMainDepartment()
        {
            ds = new DataSet();
            //string query = "select * from hospital.department_mst and firm_id=16";
            string query = "select * from hospital.department_mst";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet ListDepartment_Staff(string deptid, string search)
        {
            ds = new DataSet(); string query;
            if (search == string.Empty)
            {
                // string query = "select em.branch_id,em.firm_id,em.emp_code,em.emp_name,dep.dep_name,em.department_id from hospital.employee_master em join hospital.DEPARTMENT_MST dep on dep.dep_id = em.department_id where em.firm_id = 16 and em.department_id = "+deptid+"";
                query = "select emp_code,emp_name,emp_name ||' - '|| emp_code name from hospital.employee_master order by emp_name";
            }
            else
            {
                query = "select emp_code,emp_name from hospital.employee_master where lower(emp_name) like lower('%" + search + "%') order by emp_name";
            }

            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet ListDepartment_Staffcode(string deptid, string search)
        {
            ds = new DataSet(); string query;
            if (search == string.Empty)
            {
                // string query = "select em.branch_id,em.firm_id,em.emp_code,em.emp_name,dep.dep_name,em.department_id from hospital.employee_master em join hospital.DEPARTMENT_MST dep on dep.dep_id = em.department_id where em.firm_id = 16 and em.department_id = "+deptid+"";
                query = "select emp_code,emp_name from hospital.employee_master order by emp_name";
            }
            else
            {
                query = "select emp_code,emp_name from hospital.employee_master where emp_code like '%" + search + "%' order by emp_name";
            }

            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveData_details(string branchid)
        {
            ds = new DataSet();
            string query = "select  m.branchid,m.incentive_headid headid,h.incentivehead,m.incentive_percent1,m.incentive_percent2,m.incentive_percent3,m.targetcollection,m.totalcollection,TO_CHAR(m.update_date, 'FMMonth DD, YYYY') update_date,m.achievedtarget achievedpercent,m.incentiveamount IncentiveAmount,m.staffcount TotalStaff from incentive_master m join incentive_head h on h.id = m.incentive_headid where (m.update_date, m.incentive_headid) in (select max(m1.update_date),m1.incentive_headid from incentive_master m1 where m1.branchid = " + branchid + "  group by m1.incentive_headid)and m.branchid=" + branchid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Incentive_details(string branchid, string incentivedate)
        {
            ds = new DataSet();
            string query = "select  h.incentivehead,m.* from incentive_collection m join incentive_head h on h.id = m.incentive_headid where m.branchid = " + branchid + " and to_date(m.update_date,'dd-MM-yyyy')= '" + incentivedate + "' order by h.incentivehead";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet PunchingStaff_List(string branchid, string dentalid, string opticalid, string pharmacy, string pharmacynew, string date)
        {
            ds = new DataSet();
            string query = "select hd.incentivehead,sf.empcode,sf.empname,sf.type from incentive_staff sf join incentive_head hd on hd.id = sf.headid where sf.branchid = " + branchid + " and sf.headid = hd.id and sf.type = 'permenent' and sf.empcode in(select emp_code from mactech.attend  where to_date(curr_date, 'dd-MM-yyyy') = '" + date + "' and m_time is not null and branch_id in(" + branchid + ", " + dentalid + ", " + opticalid + ", " + pharmacy + ", " + pharmacynew + "))"
                            + " union all select hd.incentivehead,sf.empcode,sf.empname,sf.type from incentive_staff sf join incentive_head hd on hd.id = sf.headid where sf.branchid = " + branchid + " and sf.headid = hd.id and sf.type = 'temporary'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveStaff_ListAmount(string branchid, string dentalid, string opticalid, string pharmacy, string pharmacynew, string date)
        {
            ds = new DataSet();
            string query = "select hd.incentivehead,sf.empcode,sf.empname,sf.type,coll.incentive_staffamount amount,sf.bankname,sf.ifsccode,sf.accountno,sf.branch from incentive_staff sf join incentive_head hd on hd.id = sf.headid join incentive_collection coll on coll.incentive_headid=hd.id where sf.branchid = " + branchid + " and coll.branchid=" + branchid + " and coll.update_date='" + date + "' and sf.headid = hd.id and sf.type = 'permenent' and sf.empcode in(select emp_code from mactech.attend  where to_date(curr_date, 'dd-MM-yyyy') = '" + date + "' and m_time is not null and branch_id in(" + branchid + "," + pharmacy + "," + pharmacynew + "," + opticalid + "," + dentalid + "))"
                            + " union all select hd.incentivehead,sf.empcode,sf.empname,sf.type,coll.incentive_staffamount amount,sf.bankname,sf.ifsccode,sf.accountno,sf.branch from incentive_staff sf join incentive_head hd on hd.id = sf.headid join incentive_collection coll on coll.incentive_headid=hd.id where sf.branchid = " + branchid + " and coll.branchid=" + branchid + " and coll.update_date='" + date + "' and sf.headid = hd.id and sf.type = 'temporary'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveHeadAmount_details(string branchid, string incentivedate)
        {
            ds = new DataSet();
            string query = "select distinct sf.empcode,sf.empname,upper(sf.type) type,t.amount from INCENTIVE_HEADAMOUNT t join incentive_staff sf on sf.id = t.staffid where sf.branchid = " + branchid + " and to_date(t.incentivedate,'dd-MM-yyyy')= '" + incentivedate + "' and sf.type like '%head%' or sf.type like '%microlabincharge%' ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveStaffAmount_details(string branchid, string incentivedate, string headid)
        {
            ds = new DataSet();
            string query = "select hd.incentivehead,coll.incentive_staffamount amount,sf.empname,sf.empcode,sf.type from incentive_collection coll left outer join incentive_head hd on hd.id = coll.incentive_headid right outer join incentive_staff sf on sf.headid = hd.id where to_date(coll.update_date,'dd-MM-yyyy')= '" + incentivedate + "' and sf.branchid = " + branchid + " and coll.branchid = " + branchid + " order by hd.incentivehead ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveMicrolabStaffAmount_details(string incentivedate)
        {
            ds = new DataSet();
            string query = "select coll.branchid,cm.name branchname,sf.empcode,sf.empname,sf.type,coll.staffincentive_amount amount,sf.bankname,sf.ifsccode,sf.accountno,sf.branch from incentive_microlab coll " +
                "join incentive_staff sf on sf.branchid=coll.branchid join incentive_head hd on hd.id = sf.headid join hospital.clinic_master cm on cm.branch_id=coll.branchid where  coll.incentive_date='" + incentivedate + "' and sf.type = 'permenent' and sf.empcode in(select emp_code from mactech.attend where to_date(curr_date, 'dd-MM-yyyy') = '" + incentivedate + "' and m_time is not null and branch_id in(sf.branchid)) " +
                "union all select coll.branchid,cm.name,sf.empcode,sf.empname,sf.type,coll.staffincentive_amount amount,sf.bankname,sf.ifsccode,sf.accountno,sf.branch from incentive_microlab coll join incentive_staff sf on sf.branchid = coll.branchid join incentive_head hd on hd.id = sf.headid join hospital.clinic_master cm on cm.branch_id = coll.branchid where coll.incentive_date = '" + incentivedate + "' and sf.headid = hd.id and sf.type = 'temporary'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveAmount_reportHead(string branchid, string frmdt, string todt)
        {
            ds = new DataSet();
            string query = "select upper(sf.type) Type,sf.empname,amt.amount,amt.incentivedate,sf.bankname,sf.ifsccode,sf.accountno,sf.branch from incentive_headamount amt join incentive_staff sf on sf.id=amt.staffid where to_date(amt.incentivedate,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "' and amt.branchid = " + branchid + " order by incentivedate";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveAmount_reportstaff(string branchid, string frmdt, string todt)
        {
            ds = new DataSet();
            string query = "select coll.update_date, hd.incentivehead,coll.incentiveamount,coll.staffcount, coll.incentive_staffamount from incentive_collection coll join incentive_head hd on hd.id = coll.incentive_headid where to_date(coll.update_date,'dd-MM-yyyy') between '" + frmdt + "' and '" + todt + "'  and coll.branchid=" + branchid + " order by coll.update_date,incentivehead ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IncentiveMonthlyCollection_details(string branchid, string fromdt, string todt)
        {
            ds = new DataSet();
            string query = "select  h.incentivehead,m.* from incentive_collection m join incentive_head h on h.id = m.incentive_headid where m.branchid = " + branchid + " and to_date(m.update_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' order by h.incentivehead,m.update_date";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int Incentive_assignstaff(string branchid, string headid, string empcode, string empname, string type, string percent)
        {
            try
            {
                int result;

                OracleParameter[] oracleParamArray = new OracleParameter[5];
                OracleParameter objOracleParam;
                //objOracleParam = new OracleParameter("prm_dtstaff", OracleType.Cursor);
                //objOracleParam.Direction = ParameterDirection.Input;
                //objOracleParam.Value = dsXml;
                //oracleParamArray[0] = objOracleParam;
                objOracleParam = new OracleParameter("prm_branchid", OracleType.Number);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = branchid;
                oracleParamArray[0] = objOracleParam;

                objOracleParam = new OracleParameter("prm_headid", OracleType.Number);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = headid;
                oracleParamArray[1] = objOracleParam;

                objOracleParam = new OracleParameter("prm_empcode", OracleType.Number);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = empcode;
                oracleParamArray[2] = objOracleParam;

                objOracleParam = new OracleParameter("prm_name", OracleType.VarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = empname;
                oracleParamArray[3] = objOracleParam;

                objOracleParam = new OracleParameter("prm_type", OracleType.VarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = type;
                oracleParamArray[4] = objOracleParam;


                result = Objorclhelper.executeNonQuery_procedure("proc_incentive_assign_staff", oracleParamArray);
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        [WebMethod]
        public DataSet Incentive_calc_phase3(string branchid, string date, string pharmacyid1, string pharmacyid2, string opticalid1, string dentalid, string userid)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[8];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("cur1", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[0] = objOracleParam;
            objOracleParam = new OracleParameter("prm_branchid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = branchid;
            oracleParamArray[1] = objOracleParam;
            objOracleParam = new OracleParameter("prm_date", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = date;
            oracleParamArray[2] = objOracleParam;
            objOracleParam = new OracleParameter("prm_pharmacyid1", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = pharmacyid1;
            oracleParamArray[3] = objOracleParam;
            objOracleParam = new OracleParameter("prm_pharmacyid2", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = pharmacyid2;
            oracleParamArray[4] = objOracleParam;
            objOracleParam = new OracleParameter("prm_opticalid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = opticalid1;
            oracleParamArray[5] = objOracleParam;
            objOracleParam = new OracleParameter("prm_dentalid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = dentalid;
            oracleParamArray[6] = objOracleParam;
            objOracleParam = new OracleParameter("prm_userid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = userid;
            oracleParamArray[7] = objOracleParam;
            if (branchid == "1256")
                ds = Objorclhelper.executeNonQuery_dataset("proc_IncentiveValpad", oracleParamArray);
            else
                ds = Objorclhelper.executeNonQuery_dataset("proc_IncentiveValpad", oracleParamArray);
            return ds;
        }
        [WebMethod]
        public DataSet Incentive_calcamount_phase3(string branchid, string date, string pharmacyid1, string pharmacyid2, string dentalid, string opticalid)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[7];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("cur1", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[0] = objOracleParam;
            objOracleParam = new OracleParameter("prm_branchid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = branchid;
            oracleParamArray[1] = objOracleParam;
            objOracleParam = new OracleParameter("prm_date", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = date;
            oracleParamArray[2] = objOracleParam;
            objOracleParam = new OracleParameter("prm_pharmacyid1", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = pharmacyid1;
            oracleParamArray[3] = objOracleParam;
            objOracleParam = new OracleParameter("prm_pharmacyid2", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = pharmacyid2;
            oracleParamArray[4] = objOracleParam;
            objOracleParam = new OracleParameter("prm_dentalid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = dentalid;
            oracleParamArray[5] = objOracleParam;
            objOracleParam = new OracleParameter("prm_opticalid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = opticalid;
            oracleParamArray[6] = objOracleParam;

            if (branchid == "1256")
                ds = Objorclhelper.executeNonQuery_dataset("proc_IncentiveAmountCal_Valpad", oracleParamArray);
            else
                ds = Objorclhelper.executeNonQuery_dataset("proc_IncentiveAmountCal_Valpad", oracleParamArray);
            return ds;
        }

        [WebMethod]
        public DataSet LabBilldetails(string branchid, string fromdt, string todt)
        {
            ds = new DataSet();
            string query = "select cm.name,bm.branch_id,bm.bill_id,bm.rcvd_amt,to_date(bm.tra_dt,'dd-Mon-yyyy') BillDate,TO_CHAR (bm.tra_dt, 'HH24:MI:SS') BillTime from HOSPITAL.DGN_BILL_MASTER bm join hospital.clinic_master cm on bm.branch_id = cm.branch_id " +
                            "where cm.firm_id = 16 and to_date(bm.tra_date,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' and bm.branch_id =" + branchid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet IndentReport(string branchid, string fromdt, string todt)
        {
            ds = new DataSet();
            string query = "select t.indent_id,t.branch_id branch,mst.branch_name,t.to_branch Tobranch,itm.item_name,d.requested,d.transfered,d.received,d.cancelled from HOSPITAL.PHARMA_INDENT t " +
                "join HOSPITAL.PHARMA_INDENT_ITEMS d on t.indent_id = d.indent_id join HOSPITAL.PHARMA_ITEM_MASTER itm on itm.item_id = d.item_id join Hospital.pharmacy_master mst on mst.branch_id = t.branch_id " +
                "where to_date(t.request_dt,'dd-MM-yyyy') between '" + fromdt + "' and '" + todt + "' order by t.indent_id";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Transfered_PendingRpt()
        {
            ds = new DataSet();
            string query = "select t.indent_id,t.branch_id branch,mst.branch_name,t.to_branch Tobranch,itm.item_name,d.requested,d.transfered,d.received,d.cancelled from HOSPITAL.PHARMA_INDENT t " +
                "join HOSPITAL.PHARMA_INDENT_ITEMS d on t.indent_id = d.indent_id join HOSPITAL.PHARMA_ITEM_MASTER itm on itm.item_id = d.item_id join Hospital.pharmacy_master mst on mst.branch_id = t.branch_id " +
                "where d.transfered!=d.requested order by t.indent_id";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }

        [WebMethod]
        public DataSet MIS_IndentReport(string branchid, string frmdt, string todt, string itemid, string flag, string indentid)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[7];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("prm_cursor", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[0] = objOracleParam;
            objOracleParam = new OracleParameter("prm_branchid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = branchid;
            oracleParamArray[1] = objOracleParam;
            objOracleParam = new OracleParameter("prm_frmdt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = frmdt;
            oracleParamArray[2] = objOracleParam;
            objOracleParam = new OracleParameter("prm_todt", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = todt;
            oracleParamArray[3] = objOracleParam;
            objOracleParam = new OracleParameter("prm_Flag", OracleType.VarChar);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = flag;
            oracleParamArray[4] = objOracleParam;
            objOracleParam = new OracleParameter("prm_indentid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = indentid;
            oracleParamArray[5] = objOracleParam;
            objOracleParam = new OracleParameter("prm_itemid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = itemid;
            oracleParamArray[6] = objOracleParam;
            ds = Objorclhelper.executeNonQuery_dataset("Pro_MIS_IndentProcess", oracleParamArray);
            return ds;
        }
        [WebMethod]
        public int AddCamp(string conducton, string name, string description, string place, string ftime, string ttime, string unitid)
        {
            string query; int res;
            query = "insert into CAMP_REGISTER values(SEQ_CAMPREG.nextval,'" + name + "','" + description + "','" + conducton + "','" + place + "',1,'" + ftime + "','" + ttime + "'," + unitid + ")";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int AddCampPatient(string campid, string name, string age, string phone, string bloodgroup, string gender, string remark)
        {
            string query; int res;
            query = "insert into CAMP_PATIENT values(SEQ_CAMPPAT.nextval," + campid + ",'" + name + "'," + age + "," + phone + ",'" + bloodgroup + "','" + gender + "','" + remark + "')";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Campdetails()
        {
            ds = new DataSet();
            string query = "select r.conductdate||' '||r.place campname ,r.*,to_char(r.conductdate,'dd-Mon-yyyy') campdate,r.fromtime ||' - '|| r.totime camptime from CAMP_REGISTER r where r.status=1";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Campdetails_ID(string id)
        {
            ds = new DataSet();
            string query = "select r.conductdate||' '||r.name campname ,r.*,to_char(r.conductdate,'dd-Mon-yyyy') campdate from CAMP_REGISTER r where r.status=1 and r.campid=" + id + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int UpdateCamp(string id, string name, string description, string conductdate, string place, string status, string ftime, string ttime, string unitid)
        {
            int res;
            string query = "update CAMP_REGISTER set name='" + name + "',description='" + description + "',conductdate='" + conductdate + "',place='" + place + "',status=" + status + ",fromtime='" + ftime + "',totime='" + ttime + "',unitid=" + unitid + " where campid=" + id + "";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int UpdateCampPatient(string patientid, string campid, string name, string age, string phone, string bloodgroup, string gender, string remark)
        {
            int res;
            string query = "update CAMP_PATIENT set campid=" + campid + ",name='" + name + "',age=" + age + ",phone=" + phone + ",bloodgroup='" + bloodgroup + "',gender='" + gender + "',remark='" + remark + "' where patientid=" + patientid + "";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet CampPatientdetails_ID(string patientid)
        {
            ds = new DataSet();
            string query = "select * from CAMP_PATIENT where patientid=" + patientid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet CampPatientdetails_campId(string campid, string frmdt, string todt)
        {
            ds = new DataSet();
            string query;
            if (campid == "0")
                query = "select p.*,r.name||' '||r.conductdate campname from CAMP_PATIENT p join camp_register r on r.campid=p.campid " +
                     "where r.conductdate between '" + frmdt + "' and '" + todt + "'";
            else
                query = "select p.*,r.name||' '||r.conductdate campname from CAMP_PATIENT p join camp_register r on r.campid=p.campid " +
                    "where r.campid=" + campid + "";

            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet CampPatient_ConversionReport(string campid, string frmdt, string todt)
        {
            ds = new DataSet(); string query;
            if (campid == "0")
                query = "select p.name,p.mobile_no,t.opnumber ,sm.designation,sm.name doctorname,t.rcvd_amount from HOSPITAL.CLINIC_PAYMENT_MASTER t join hospital.staff_master sm on sm.staff_id = t.dr_id  join hospital.patient_master p on p.opnumber=t.opnumber join camp_patient c on c.phone=p.mobile_no join camp_register r on r.campid=c.campid" +
                       " where  t.bill_date between r.conductdate and r.conductdate+31 and r.conductdate between '" + frmdt + "' and '" + todt + "' " +
                       " union select p.name,p.mobile_no,p.opnumber,sm.designation,sm.name doctorname,t1.rcvd_amt from HOSPITAL.Dgn_Bill_Master t1 join hospital.patient_master p on p.opnumber = t1.patient_id join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.staff_master sm on sm.staff_id = t1.doct_id join hospital.clinic_master mas on mas.branch_id = r.unitid " +
                       "where t1.tra_dt between r.conductdate and r.conductdate + 31  and r.conductdate between '01-Nov-2022' and '20-Nov-2022'";
            else
                query = "select p.name,p.mobile_no,t.opnumber ,sm.designation,sm.name doctorname,t.rcvd_amount from HOSPITAL.CLINIC_PAYMENT_MASTER t join hospital.staff_master sm on sm.staff_id = t.dr_id  join hospital.patient_master p on p.opnumber=t.opnumber join camp_patient c on c.phone=p.mobile_no join camp_register r on r.campid=c.campid " +
                       "where r.campid=" + campid + " and  t.bill_date between r.conductdate and r.conductdate+31 " +
                       " union select p.name,p.mobile_no,p.opnumber,sm.designation,sm.name doctorname,t1.rcvd_amt from HOSPITAL.Dgn_Bill_Master t1 join hospital.patient_master p on p.opnumber = t1.patient_id join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.staff_master sm on sm.staff_id = t1.doct_id join hospital.clinic_master mas on mas.branch_id = r.unitid " +
                       "where r.campid =" + campid + " and t1.tra_dt between r.conductdate and r.conductdate + 31  and r.conductdate between '01-Nov-2022' and '20-Nov-2022'";

            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Allcamp_ConversionReport(string fromdate, string todate)
        {
            ds = new DataSet();
            //string query = "select r1.campid,r1.name,r1.conductdate,r1.place,r1.fromtime||' - '||r1.totime camptime,((select count(*)  from HOSPITAL.CLINIC_PAYMENT_MASTER t join hospital.patient_master p on p.opnumber = t.opnumber join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid where t.bill_date between r.conductdate and r.conductdate + 31  and r1.campid = r.campid and r.conductdate between '"+fromdate+"' and '"+todate+"') + (select count(distinct(t.patient_id)) from HOSPITAL.Dgn_Bill_Master t join hospital.patient_master p on p.opnumber = t.patient_id join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid where  t.tra_dt between r.conductdate and r.conductdate + 31  and r.campid = r1.campid and  r.conductdate between '"+fromdate+"' and '"+todate+"'))ConversionCount, " +
            //    "((select nvl(sum(t.rcvd_amount), 0)  from HOSPITAL.CLINIC_PAYMENT_MASTER t join hospital.patient_master p on p.opnumber = t.opnumber join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid where t.bill_date between r.conductdate and r.conductdate + 31  and r1.campid = r.campid and r.conductdate between '"+fromdate+"' and '"+todate+"')+(select nvl(sum(t.rcvd_amt), 0) from HOSPITAL.Dgn_Bill_Master t join hospital.patient_master p on p.opnumber = t.patient_id  where to_date(t.tra_dt, 'dd-MM-yyyy')  between '"+fromdate+"' and '"+todate+"' and p.opnumber in (select distinct(t.patient_id) from HOSPITAL.Dgn_Bill_Master t  join hospital.patient_master p on p.opnumber = t.patient_id join camp_patient c on c.phone = p.mobile_no  join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid  where t.tra_dt between r.conductdate and r.conductdate + 31  and r.campid = r1.campid and   r.conductdate between '"+fromdate+"' and '"+todate+"')))ConversionAmount," +
            //    " mas.name Unitname from camp_register r1 join hospital.clinic_master mas on mas.branch_id = r1.unitid where r1.conductdate between '"+fromdate+"' and '"+todate+"'";
            string query = "select r1.campid,r1.name,r1.conductdate,r1.place,r1.fromtime||' - '||r1.totime camptime," +
                "(select count(distinct(t.patient_id)) from HOSPITAL.Dgn_Bill_Master t join hospital.patient_master p on p.opnumber = t.patient_id join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid where t.tra_dt between r.conductdate and r.conductdate + 31  and r.campid = r1.campid and  r.conductdate between '" + fromdate + "' and '" + todate + "')DGNcount," +
                "(select count(*)  from HOSPITAL.CLINIC_PAYMENT_MASTER t join hospital.patient_master p on p.opnumber = t.opnumber join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid where t.bill_date between r.conductdate and r.conductdate + 31  and r1.campid = r.campid and r.conductdate between '" + fromdate + "' and '" + todate + "') cliniccount, " +
                "(select nvl(sum(t.rcvd_amount), 0)  from HOSPITAL.CLINIC_PAYMENT_MASTER t join hospital.patient_master p on p.opnumber = t.opnumber join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid where t.bill_date between r.conductdate and r.conductdate + 31  and r1.campid = r.campid and r.conductdate between '" + fromdate + "' and '" + todate + "')Clinicamount," +
                "(select nvl(sum(t.rcvd_amt), 0) from HOSPITAL.Dgn_Bill_Master t join hospital.patient_master p on p.opnumber = t.patient_id join camp_patient c on c.phone = p.mobile_no join camp_register r on r.campid = c.campid join hospital.clinic_master mas on mas.branch_id = r.unitid where t.tra_dt between r.conductdate and r.conductdate + 31  and r.campid = r1.campid and r.conductdate between '" + fromdate + "' and '" + todate + "')DGNAmount," +
                "mas.name Unitname from camp_register r1 join hospital.clinic_master mas on mas.branch_id = r1.unitid where r1.conductdate between '" + fromdate + "' and '" + todate + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Supplier_AuthorizationReport(string fromdate, string todate)
        {
            ds = new DataSet();
            //string query = "select t.payment_id,supp.supplier_name,t.cheque_no,t.amount,t.verify_dt,t.verify_by,t.tra_dt,LISTAGG(inv.invoice_no, ',') WITHIN GROUP(ORDER BY inv.invoice_no) InvoiceID from HOSPITAL.PHARMA_PAYMENTS t " +
            //    "left outer join HOSPITAL.PHARMA_PAYMENT_DTL d on d.payment_id = t.payment_id left outer join HOSPITAL.PHARMA_INVOICE_MASTER inv on inv.invoice_id=d.invoice_id left outer join hospital.pharma_supplier_master supp on supp.supplier_id = t.supplier_id " +
            //    "where t.firm_id = 16  and t.status_id in(1) and to_date(t.verify_dt,'dd-MM-yyyy' ) between '" + fromdate + "'  and '" + todate + "' group by  supp.supplier_name,t.payment_id,t.amount,t.cheque_no,t.verify_dt,t.verify_by,t.tra_dt";
            string query = "select cc.cr_no,cc.pr_no,supp.supplier_name,aa.invoice_number,to_char(m.invoice_dt,'dd-MM-yyyy') invoice_dt,m.invoice_value,cc.vendor_amount credit_amount,d.amount amount_paid,to_char(pm.tra_dt,'dd-MM-yyyy') tra_dt from hospital.pharma_credit_note cc " +
                "join hospital.pharma_adjustcreditnote aa on cc.pr_no = aa.prnumber join HOSPITAL.PHARMA_PAYMENT_DTL d on d.invoice_id = aa.invoice_number join hospital.pharma_payments pm on pm.payment_id = d.payment_id join hospital.pharma_invoice_master m on aa.invoice_number = m.invoice_id  " +
                "join hospital.pharma_supplier_master supp on supp.supplier_id = aa.supplier_id where to_date(pm.tra_dt, 'dd-MM-yyyy') between to_date('"+fromdate+"','dd-MM-yyyy')  and to_date('"+todate+"','dd-MM-yyyy') order by to_date(pm.tra_dt, 'dd-MM-yyyy') ";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet Debit_Credit_note_Report(string fromdate, string todate, string branchid, string type)
        {
            ds = new DataSet();
            string query = "";
            if (branchid == "0")
            {
                if (type == "1")
                    query = "select ph.branch_name,s.supplier_name,b.pr_no,b.amount,b.tax,b.cess,b.discount,b.pr_value,TO_CHAR (a.tra_dt, 'DD-MM-YYYY HH12:MI:SSAM') TRA_DT, a.cr_no,a.vendor_credit_note,a.pr_no,a.tra_dt,a.vendor_amount,a.user_id status,a.trans_id,a.profit,a.loss from HOSPITAL.PHARMA_CREDIT_NOTE a join hospital.pharma_pr_master b on a.pr_no = b.pr_no join hospital.pharma_supplier_master s on s.supplier_id = b.supplier_id join hospital.pharmacy_master ph on ph.branch_id = b.branch_id where to_date(a.tra_dt,'dd-MM-yyyy') between to_date('" + fromdate+"','dd-MM-yyyy') and to_date('"+todate+ "','dd-MM-yyyy') and ph.firm_id=16"; 
                else
                    query = "select ph.branch_name,supp.supplier_name,pr.pr_no,pr.amount,pr.tax,pr.cess,pr.discount,pr.pr_value,TO_CHAR (pr.tra_dt, 'DD-MM-YYYY HH12:MI:SSAM') TRA_DT,ad.user_id status from HOSPITAL.PHARMA_ADJUSTCREDITNOTE ad join HOSPITAL.PHARMA_PR_MASTER pr on pr.pr_no = ad.prnumber join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id where to_date(ad.tra_dt, 'dd-MM-yyyy') between to_date('" + fromdate + "','dd-MM-yyyy') and to_date('" + todate + "','dd-MM-yyyy') and ph.firm_id = 16";
            }
            else
            {
                if (type == "1")
                    query = "select ph.branch_name,s.supplier_name,b.pr_no,b.amount,b.tax,b.cess,b.discount,b.pr_value,TO_CHAR (a.tra_dt, 'DD-MM-YYYY HH12:MI:SSAM') TRA_DT,a.cr_no,a.vendor_credit_note,a.pr_no,a.tra_dt,a.vendor_amount,a.user_id status,a.trans_id,a.profit,a.loss from HOSPITAL.PHARMA_CREDIT_NOTE a join hospital.pharma_pr_master b on a.pr_no = b.pr_no join hospital.pharma_supplier_master s on s.supplier_id = b.supplier_id join hospital.pharmacy_master ph on ph.branch_id = b.branch_id where to_date(a.tra_dt,'dd-MM-yyyy') between to_date('" + fromdate + "','dd-MM-yyyy') and to_date('"+todate+"','dd-MM-yyyy') and ph.firm_id = 16 and b.branch_id = 2435 and b.status_id = 2";
                else
                    query = "select ph.branch_name,supp.supplier_name,pr.pr_no,pr.amount,pr.tax,pr.cess,pr.discount,pr.pr_value,TO_CHAR (ad.tra_dt, 'DD-MM-YYYY HH12:MI:SSAM') TRA_DT,ad.user_id status from HOSPITAL.PHARMA_ADJUSTCREDITNOTE ad join HOSPITAL.PHARMA_PR_MASTER pr on pr.pr_no = ad.prnumber join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id where to_date(ad.tra_dt, 'dd-MM-yyyy') between to_date('" + fromdate + "','dd-MM-yyyy') and to_date('" + todate + "','dd-MM-yyyy') and ph.firm_id = 16 and pr.branch_id = " + branchid + "";
            }
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        ///////////////INCENTIVE FOURTH PHASE/////////////////////
        ///
        //[WebMethod]
        //public int Add_incentiveheadstaff_percent(string type, string branchid, string incentive_percent, string entereddate, string enterdby)
        //{
        //    int res;
        //    string query = "insert into INCENTIVE_HEADPERCENTHIS values(seq_incentivehead_type.nextval,'" + type + "'," + branchid + "," + incentive_percent + ",'" + entereddate + "'," + enterdby + ")";
        //    res = Objorclhelper.executeNonQuery(query);
        //    return res;
        //}
        [WebMethod]
        public int Add_incentiveheadstaff_percent(string branchid, string frmdt, string type, string percent, string user, string percentid)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[7];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("prm_branchid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = branchid;
            oracleParamArray[0] = objOracleParam;
            objOracleParam = new OracleParameter("prm_date", OracleType.DateTime);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = frmdt;
            oracleParamArray[1] = objOracleParam;
            objOracleParam = new OracleParameter("prm_stafftype", OracleType.VarChar);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = type;
            oracleParamArray[2] = objOracleParam;
            objOracleParam = new OracleParameter("prm_percent", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = percent;
            oracleParamArray[3] = objOracleParam;
            objOracleParam = new OracleParameter("prm_userid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = user;
            oracleParamArray[4] = objOracleParam;
            objOracleParam = new OracleParameter("prm_editid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = percentid;
            oracleParamArray[5] = objOracleParam;
            objOracleParam = new OracleParameter("prm_status", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[6] = objOracleParam;
            int status = Objorclhelper.executeNonQuery_procedure("proc_Incentivestaff_percent", oracleParamArray);
            return status;
        }
        [WebMethod]
        public DataSet LoadHeadPercentDetails(string branchid)
        {
            ds = new DataSet();
            string query = "select t.*, to_char(t.entered_date, 'DD-MM-YYYY') entereddate from INCENTIVE_HEADPERCENTHIS t where t.branchid=" + branchid + " and t.id in" +
                " (select max(t1.id) from INCENTIVE_HEADPERCENTHIS t1 where t1.branchid = t.branchid and t.incentive_headtype = t1.incentive_headtype)";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet LoadHeadPercentDetails_ID(string percentid)
        {
            ds = new DataSet();
            string query = "select t.*,to_char(t.entered_date, 'DD-MM-YYYY') entereddate from INCENTIVE_HEADPERCENTHIS t where t.id=" + percentid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet LoadIncentive_dep_staff(string branchid, string headid)
        {
            ds = new DataSet();
            string query = "select * from incentive_staff sf where sf.headid=" + headid + " and sf.branchid=" + branchid + "";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int UpdateStaffAccountDetails(string editid, string bankname, string ifsccode, string accountno, string empcode, string branch, string branchid)
        {
            string query; int res;
            query = "update incentive_staff sf set sf.bankname='" + bankname + "',sf.ifsccode='" + ifsccode + "',sf.accountno='" + accountno + "',sf.branch='" + branch + "' where sf.id=" + editid + " and sf.empcode=" + empcode + " and sf.branchid=" + branchid + "";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet LoadMicrolab_incentive(string frmdate, string todate)
        {
            string query; ds = new DataSet();
            query = "select  m.incentive_date,m.branchid,m.name,m.totalcollection,m.percent1,m.percent2 ,m.percent3,m.targetcollection,m.achievedpercent achievedpercent, m.incentiveamount as var_incentiveamount,m.staffcount TotalStaff, m.staffincentive_amount from incentive_microlab m where m.incentive_date between '" + frmdate + "' and '" + todate + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Fill_pharmacymargin()
        {
            string query; ds = new DataSet();
            query = "select sb.amount_upto,sb.amount_above,sb.percent3,sb.percent2,sb.percent1,to_char(sb.updatedate, 'DD-MM-YYYY') updatedate,sb.branchid,sb.targetmargin from incentive_pharmacyslab sb where sb.updatedate in (select max(s.updatedate)  from incentive_pharmacyslab s where s.branchid = sb.branchid)";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public int AddPharmacymargin(string amtbelow, string amtabove, string percent3, string percent1, string percent2, string updatedate, string branchid, string targetmargin)
        {
            string query; int res;
            query = "insert into INCENTIVE_PHARMACYSLAB values(SEQ_INCENTIVEPHARMACY_SLAB.nextval," + amtbelow + "," + amtbelow + "," + percent3 + "," + percent1 + "," + percent2 + ",'" + updatedate + "'," + branchid + "," + targetmargin + ")";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Agewise_stockReport(string branchid)
        {
            string query; ds = new DataSet();
            query = "select distinct c.item_id,c.item_name,g.group_name,a.batch_no,a.sec_stock,to_char(a.expiry_dt,'dd-MM-yyyy') as Expiry_date,(case when(a.conv_units > 1) then round(((a.quantity/a.conv_units)*a.pri_cost),2) else round((a.quantity*a.pri_cost),2) end) as Cost," +
                "to_char(inm.invoice_dt, 'dd-MM-yyyy') as Invoice_date,trunc(to_date(sysdate, 'dd-MM-yyyy')) - trunc(to_date(inm.invoice_dt, 'dd-MM-yyyy')) as TotalDays " +
                "from HOSPITAL.PHARMA_INVENTORY a join hospital.pharma_invoice_master inm on a.invoice_id = inm.invoice_id left outer join HOSPITAL.PHARMA_INVOICE_DTL t on t.invoice_id = a.invoice_id " +
                "join hospital.pharma_item_master c on a.item_id = c.item_id join HOSPITAL.pharma_medicine_group g on c.group_id = g.group_id left outer join hospital.pharma_grn_dtl grn on grn.item_id = a.item_id and grn.batch_no = a.batch_no " +
                "left outer join hospital.pharma_grn_master gm on gm.grn_no = grn.grn_no and gm.branch_id = " + branchid + " where a.branch_id = " + branchid + " and sec_stock> 0 order by c.item_name";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet Optical_Invoice_confirmation(string branchid, string frmdate, string todate)
        {
            string query; ds = new DataSet();
            query = "select mas.branch_name,supp.supplier_name,t.* from HOSPITAL.OPTICAL_INVOICE_MASTER t join HOSPITAL.OPTICAL_SUPPLIER_MASTER supp on supp.supplier_id = t.supplier_id join HOSPITAL.OPTICAL_MASTER mas on mas.branch_id = t.branch_id where to_date(t.tra_dt,'dd-MM-yyyy') between to_date('"+frmdate+"','dd-MM-yyyy') and to_date('"+todate+"','dd-MM-yyyy')";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet ItemTransfer_tostore(string frmdate, string todate)
        {
            string query; ds = new DataSet();
            query = "select distinct d.indent_id,itm.item_name,to_char(mas.tra_dt,'dd-MM-yyyy') Tra_date,d.req_qty,dt.tfr_qty,d.rcvd_qty Total_Rcvd,t.trans_by,t.rcvd_by,t.rcvd_date,(case when(t.status_id = 1) then 'Requested' when(t.status_id = 2) then 'Transfered' when(t.status_id = 0) then 'Received' else 'Requested' end) as Status " +
                "from hospital.CLINSTORE_INDENT_MASTER mas join hospital.CLINSTORE_INDENT_DETAIL d on mas.indent_id = d.indent_id join HOSPITAL.CLINSTORE_ITEM_MASTER itm on itm.item_id = d.item_id " +
                "left outer join HOSPITAL.CLINSTORE_TRANSFER_MASTER t on t.indent_id = mas.indent_id join HOSPITAL.CLINSTORE_TRANSFER_DETAIL dt on dt.trans_id = t.trans_id and dt.item_id = d.item_id " +
                "where to_date(mas.tra_dt, 'dd-MM-yyyy')between to_date('"+frmdate+"','dd-MM-yyyy') and to_date('"+todate+"','dd-MM-yyyy') and mas.firm_id = 16 order by d.indent_id";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet Agewise_stock_criteria(string branchid)
        {
            ds = new DataSet();
            OracleParameter[] oracleParamArray = new OracleParameter[2];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("cur1", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[0] = objOracleParam;
            objOracleParam = new OracleParameter("prm_branchid", OracleType.Number);
            objOracleParam.Direction = ParameterDirection.Input;
            objOracleParam.Value = branchid;
            oracleParamArray[1] = objOracleParam;
            ds = Objorclhelper.executeNonQuery_dataset("proc_Agewise_stock", oracleParamArray);
            return ds;
        }

        [WebMethod]
        public DataSet VendorsList()
        {
            ds = new DataSet();
            string query = "select * from hospital.clinstore_vendor_mst v order by v_name";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet Vendor_Ledgerdetails(string vendorid)
        {
                ds = new DataSet();
                string query = "select inv.* from HOSPITAL.CLINSTORE_INVOICE_MASTER inv where inv.vendor_id="+vendorid+" and inv.ststus=2 order by inv.tra_dt";
                ds = Objorclhelper.ExecuteDataset(query);
                return ds;           
        }

        [WebMethod]
        public DataSet Pharma_punch_alert()
        {
            DataSet msg;
            OracleParameter[] oracleParamArray = new OracleParameter[1];
            OracleParameter objOracleParam;
            objOracleParam = new OracleParameter("prm_cursor", OracleType.Cursor);
            objOracleParam.Direction = ParameterDirection.Output;
            oracleParamArray[0] = objOracleParam;
            //objOracleParam = new OracleParameter("prm_date", OracleType.DateTime);
            //objOracleParam.Direction = ParameterDirection.Input;
            //objOracleParam.Value = date;
            //oracleParamArray[1] = objOracleParam;
            //objOracleParam = new OracleParameter("prm_shiftid", OracleType.Number);
            //objOracleParam.Direction = ParameterDirection.Input;
            //objOracleParam.Value = 1;
            //oracleParamArray[2] = objOracleParam;
            msg = Objorclhelper.executeNonQuery_dataset("proc_pharmashift_alert", oracleParamArray);
            return msg;
        }

        [WebMethod]
        public int Add_PRNo_StatusChange(string status, string cr_no,int tran_status, string tran_userid, string tran_date, int rec_status, string rec_userid, string rec_date)
        {
            string query; int res;
            if (status == "transfered")
            {
                query = "insert into Accounts_PR_Status values('" + cr_no + "'," + tran_status + ",'" + tran_userid + "','" + tran_date + "'," + rec_status + ",'" + rec_userid + "','" + rec_date + "')";
                res = Objorclhelper.executeNonQuery(query);
            }
            else
            {
                query = "update Accounts_PR_Status set Received=" + rec_status + ",Rec_userid='" + rec_userid + "',rec_date=" + rec_date + " where pr_no=" + cr_no + "";
                res = Objorclhelper.executeNonQuery(query);
            }
            return res;
        }

        [WebMethod]
        public DataSet Pr_No_details(string pr_no)
        {
            ds = new DataSet();
            string query = "select supp.supplier_name,pr.pr_no,pr.pr_value from HOSPITAL.PHARMA_PR_MASTER pr join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id where  ph.firm_id = 16  and pr.pr_no='" + pr_no + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet Accounts_PR_Status_select(string fromdate, string todate)
        {
            ds = new DataSet();
            string query = "";
           
            //query = "select distinct pr.pr_no,a.cr_no,a.vendor_credit_note, acc.transfered, acc.tran_userid, acc.tran_date, acc.received, acc.rec_userid, acc.rec_date, ph.branch_name, supp.supplier_name, pr.amount,pr.tax, pr.cess, pr.discount, pr.pr_value from HOSPITAL.PHARMA_CREDIT_NOTE a " +
            //        "left outer join HOSPITAL.PHARMA_PR_MASTER pr on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id left outer join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id join accounts_pr_status acc on acc.pr_no = a.cr_no " +
            //        "where to_date(a.tra_dt, 'dd-MM-yyyy') between to_date('"+fromdate+"', 'dd-MM-yyyy') and to_date('"+todate+ "', 'dd-MM-yyyy') and ph.firm_id = 16 union (select distinct pr.pr_no, a.cr_no,a.vendor_credit_note, 0 transfered, null tran_userid, null tran_date, 0 received, null rec_userid, null rec_date, " +
            //        "ph.branch_name, supp.supplier_name, pr.amount, pr.tax, pr.cess, pr.discount, pr.pr_value from HOSPITAL.PHARMA_CREDIT_NOTE a left outer join HOSPITAL.PHARMA_PR_MASTER pr on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id " +
            //        "left outer join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id where to_date(a.tra_dt, 'dd-MM-yyyy') between to_date('"+fromdate+"', 'dd-MM-yyyy') and to_date('"+todate+"', 'dd-MM-yyyy') and ph.firm_id = 16 and a.cr_no not in (select pr_no from accounts_pr_status))";

            query = "select rownum,y.* from (select x.pr_no,x.cr_no,x.vendor_credit_note, x.transfered, x.tran_userid, x.tran_date, x.received, x.rec_userid, x.rec_date, x.branch_name, x.supplier_name, x.amount,x.tax, x.cess, x.discount, x.pr_value from (select distinct pr.pr_no,a.cr_no,a.vendor_credit_note, acc.transfered, acc.tran_userid, acc.tran_date, " +
                "acc.received, acc.rec_userid, acc.rec_date, ph.branch_name, supp.supplier_name, pr.amount,pr.tax, pr.cess, pr.discount, pr.pr_value from HOSPITAL.PHARMA_CREDIT_NOTE a left outer join HOSPITAL.PHARMA_PR_MASTER pr on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id left outer join " +
                "hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id join accounts_pr_status acc on acc.pr_no = a.cr_no where to_date(a.tra_dt, 'dd-MM-yyyy') between to_date('" + fromdate + "', 'dd-MM-yyyy') and to_date('" + todate + "', 'dd-MM-yyyy') and ph.firm_id = 16 union(select distinct pr.pr_no, a.cr_no, a.vendor_credit_note, " +
                "0 transfered, null tran_userid, null tran_date, 0 received, null rec_userid, null rec_date,ph.branch_name, supp.supplier_name, pr.amount, pr.tax, pr.cess, pr.discount, pr.pr_value from HOSPITAL.PHARMA_CREDIT_NOTE a left outer join HOSPITAL.PHARMA_PR_MASTER pr on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id " +
                "left outer join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id where to_date(a.tra_dt, 'dd-MM-yyyy') between to_date('" + fromdate + "', 'dd-MM-yyyy') and to_date('" + todate + "', 'dd-MM-yyyy') and ph.firm_id = 16 and a.cr_no not in (select pr_no from accounts_pr_status)))x order by x.supplier_name) y";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet Accounts_PR_Status_transfer_select(string fromdate, string todate)
        {
            ds = new DataSet();
            string query = "";
            //query = "select distinct pr.pr_no,a.cr_no,a.vendor_credit_note,acc.transfered,acc.tran_userid,acc.tran_date,acc.received,acc.rec_userid,a.tra_dt,acc.rec_date,ph.branch_name,supp.supplier_name,pr.amount,pr.tax,pr.cess,pr.discount,pr.pr_value from HOSPITAL.PHARMA_CREDIT_NOTE a left outer join HOSPITAL.PHARMA_PR_MASTER pr " +
            //    "on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id left outer join hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id left outer join accounts_pr_status acc on acc.pr_no = a.cr_no where ph.firm_id = 16 and to_date(acc.tran_date,'dd-MM-yyyy') between to_date('"+fromdate+"','dd-MM-yyyy') and to_date('"+todate+"','dd-MM-yyyy')";
            query = "select x.pr_no,x.cr_no,x.vendor_credit_note,x.transfered,x.tran_userid,x.tran_date,x.received,x.rec_userid,x.tra_dt,x.rec_date,x.branch_name,x.supplier_name,x.amount,x.tax,x.cess,x.discount,x.pr_value from(select distinct pr.pr_no, a.cr_no, a.vendor_credit_note, acc.transfered, acc.tran_userid, acc.tran_date, acc.received, " +
                "acc.rec_userid, a.tra_dt, acc.rec_date, ph.branch_name,supp.supplier_name, pr.amount, pr.tax, pr.cess, pr.discount, pr.pr_value from HOSPITAL.PHARMA_CREDIT_NOTE a left outer join HOSPITAL.PHARMA_PR_MASTER pr on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id left outer join " +
                "hospital.pharma_supplier_master supp on supp.supplier_id = pr.supplier_id left outer join accounts_pr_status acc on acc.pr_no = a.cr_no where ph.firm_id = 16 and to_date(acc.tran_date,'dd-MM-yyyy') between to_date('"+fromdate+"','dd-MM-yyyy') and to_date('"+todate+"','dd-MM-yyyy'))x order by x.supplier_name";

             ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public int Delete_AccountsPRStatus(string cr_no)
        {
            string query1;int res1 = 0;
            query1 = "delete from ACCOUNTS_PR_STATUS where pr_no='" + cr_no + "'";
            res1 = Objorclhelper.executeNonQuery(query1);
            return res1;
        }

        [WebMethod]
        public int Add_AccountsPRStatus(string cr_no, int transfered, string tran_userid)
        {
            string query1; int res1 = 0;
            query1 = "insert into ACCOUNTS_PR_STATUS (pr_no,transfered,tran_userid,tran_date) values('" + cr_no + "'," + transfered + ",'" + tran_userid + "',sysdate)";
            res1 = Objorclhelper.executeNonQuery(query1);
            return res1;
        }

        [WebMethod]
        public int Update_AccountsPRStatus_receive(string cr_no, int received, string rec_userid)
        {
            string query; int res;
            query = "update ACCOUNTS_PR_STATUS set  received='"+received+"',rec_userid='"+rec_userid+"',rec_date=sysdate where pr_no='"+cr_no+"'";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }

        [WebMethod]
        public DataSet Accounts_CR_transfer_Report(string fromdate, string todate)
        {
            ds = new DataSet();
            string query = "";
                query = "select distinct pr.pr_no,a.cr_no,a.vendor_credit_note,acc.tran_userid,acc.tran_date,a.tra_dt,ph.branch_name,supp.supplier_name," +
                        "pr.amount,pr.tax,pr.cess,pr.discount,pr.pr_value,'' rec_userid,'' rec_date from HOSPITAL.PHARMA_CREDIT_NOTE a left outer join HOSPITAL.PHARMA_PR_MASTER pr " +
                        "on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id left outer join hospital.pharma_supplier_master supp " +
                        "on supp.supplier_id = pr.supplier_id join accounts_pr_status acc on acc.pr_no = a.cr_no where ph.firm_id = 16 and acc.transfered = 1 and acc.received = 0 " +
                        "and to_date(acc.tran_date,'dd-MM-yyyy') between to_date('" + fromdate + "','dd-MM-yyyy') and to_date('" + todate + "','dd-MM-yyyy') order by supp.supplier_name";            
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }

        [WebMethod]
        public DataSet Accounts_CR_Receive_Report(string fromdate, string todate)
        {
            ds = new DataSet();
            string query = "";
                query = "select distinct pr.pr_no,a.cr_no,a.vendor_credit_note,acc.tran_userid,acc.tran_date,acc.rec_userid,a.tra_dt,acc.rec_date,ph.branch_name,supp.supplier_name," +
                        "pr.amount,pr.tax,pr.cess,pr.discount,pr.pr_value from HOSPITAL.PHARMA_CREDIT_NOTE a left outer join HOSPITAL.PHARMA_PR_MASTER pr " +
                        "on a.pr_no = pr.pr_no join hospital.pharmacy_master ph on ph.branch_id = pr.branch_id left outer join hospital.pharma_supplier_master supp " +
                        "on supp.supplier_id = pr.supplier_id join accounts_pr_status acc on acc.pr_no = a.cr_no where ph.firm_id = 16 and acc.transfered = 1 and acc.received = 1 " +
                        "and to_date(acc.tran_date,'dd-MM-yyyy') between to_date('" + fromdate + "','dd-MM-yyyy') and to_date('" + todate + "','dd-MM-yyyy') order by supp.supplier_name";

            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
    }

}