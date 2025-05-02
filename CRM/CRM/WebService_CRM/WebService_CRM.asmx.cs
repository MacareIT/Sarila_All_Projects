using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OracleClient;


namespace WebService_CRM
{
    /// <summary>
    /// Summary description for WebService_CRM
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService_CRM : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper(); 

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataSet Get_login(string username, string password)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from LOGIN_USERS where username = '" + username + "' and password = '" + password + "'");
            return DS;
        }

        //Doctor Booking
        [WebMethod]
        public int Insert_NewBooking(int BranchID, int DeptID, int DoctorID,string BookDate,string VisitTime,string PatientName,string Phone,string Token,string CreatedBy,string status)
        {
            int id = 0;
            DataSet ds = ObjOrclHelper.ExecuteDataSet("select booking_id from CRM_DoctorBooking where branch_id=" + BranchID + " and dept_id=" + DeptID + " and doctor_id=" + DoctorID + " " +
                "and to_date(booking_date,'dd-MM-yyyy')=to_date('"+BookDate+"','dd-MM-yyyy') and token=" + Token + " and patient_name='" + PatientName + "' and phone='" + Phone + "'");
            if (ds.Tables[0].Rows.Count > 0) { }
            else
            {
                id = ObjOrclHelper.ExecuteNonQuery("insert into CRM_DoctorBooking (Booking_ID, Branch_ID, Dept_ID, Doctor_ID, Booking_date, visit_time, Patient_Name, " +
                "Phone, Token, CreatedBy, CreatedDate, Status) values (Seq_CRM_BookId.nextval, " + BranchID + ", " + DeptID + ", " + DoctorID + ", " +
                "'" + BookDate + "', '" + VisitTime + "', '" + PatientName + "', '" + Phone + "', '" + Token + "', '" + CreatedBy + "', sysdate, '" + status + "')");
                
            }
            return id;
        }

        [WebMethod]
        public int Insert_Doctor(int DoctorID)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into crm_drreg values (SEQ_CRM_DRREG.nextval, " + DoctorID + ")");
            return id;
        }

        //Doctor Reschedule Booking
        [WebMethod]
        public int Insert_RescheduledBooking(int Booking_Id, int BranchID, int DeptID, int DoctorID, string BookDate, string VisitTime, string PatientName, string Phone, string Token, string CreatedBy, string status)
        {
            int id = 0;

            id = ObjOrclHelper.ExecuteNonQuery("insert into CRM_DoctorBooking (Booking_ID, Branch_ID, Dept_ID, Doctor_ID, Booking_date, visit_time, Patient_Name, " +
                "Phone, Token, CreatedBy, CreatedDate, Status) values (Seq_CRM_BookId.nextval, " + BranchID + ", " + DeptID + ", " + DoctorID + ", " +
                "'" + BookDate + "', '" + VisitTime + "', '" + PatientName + "', '" + Phone + "', '" + Token + "', '" + CreatedBy + "', sysdate, '" + status + "')");
            if (id > 0)
                id = ObjOrclHelper.ExecuteNonQuery("insert into Crm_BookingReschedule (Booking_Id, Rescheduled_Id) values (" + Booking_Id + ", Seq_CRM_BookId.currval)");
            return id;

        }

        //Edit Doctor Booking
        [WebMethod]
        public int Update_CRMBooking(int Booking_id,int BranchID, int DeptID, int DoctorID, string BookDate, string VisitTime, string PatientName, string Phone, string Token, string CreatedBy, string status)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update CRM_DoctorBooking set Branc_ID = " + BranchID + ", Dept_ID = " + DeptID + ", Doctor_ID = " + DoctorID + ", " +
                "Booking_date = '" + BookDate + "', VisitTime = '" + VisitTime + "', PatientName = '" + PatientName + "', Phone = '" + Phone + "', Token = " +
                "'" + Token + "', CreatedBy = '" + CreatedBy + "', CreatedDate = sysdate, Status = '" + status + "' where Booking_id = '" + Booking_id + "'");
            return id;
        }

        [WebMethod]
        public int Update_Bookingdtl(int Booking_id, string PatientName, string Phone)
        {
            int id = 0;
            string query = "";
            query = ("update CRM_DoctorBooking set patient_name = '" + PatientName + "', Phone = '" + Phone + "' where Booking_id = '" + Booking_id + "'");
            id = ObjOrclHelper.ExecuteNonQuery(query);
            return id;
        }

        [WebMethod]
        public int Update_BookingStatus_Arrived(int Booking_id, string status)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update CRM_DoctorBooking set Status = '" + status + "' where Booking_id = '" + Booking_id + "'");
            return id;
        }

        //Edit Doctor Booking Status Confirmed/Arrived
        [WebMethod]
        public int Update_BookingStatus_Confirm(int Booking_id,string confirmby,string status)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update CRM_DoctorBooking set Status = '" + status + "', confirmedby = '" + confirmby + "', confirmedon = sysdate " +
                "where Booking_id = '" + Booking_id + "'");
            return id;
        }

        //Add Doctor Booking Status_Cancel
        [WebMethod]
        public int Add_BookingStatus_Cancel(int Booking_id, string Reason_ForCancel,string cancelledby)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into Crm_BookingCancel (Booking_ID, Reason_ForCancel, Cancelledby, Cancelledon) values (" + Booking_id + ", " +
                "'" + Reason_ForCancel + "', '" + cancelledby + "', sysdate)");
            return id;
        }

        //Add Doctor Booking Status_Reschedule
        [WebMethod]
        public int Add_BookingStatus_Reschedule(int Booking_id, string Reason_ForCancel, string cancelledby)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into Crm_BookingCancel (Booking_ID, Reason_ForCancel, Cancelledby, Cancelledon) values (" + Booking_id + ", " +
                "'" + Reason_ForCancel + "', '" + cancelledby + "', sysdate)");
            return id;
        }

        [WebMethod]
        public DataSet Get_Branch()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select clinic_id, branch_id, name from hospital.clinic_master where clinic_id in (1, 27, 43, 44, 41, 42, 24, 39, " +
                "18, 40) and name is not null and name != '0'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Registereddoctors(int branchid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct d.dr_id, d.dr_name, d.dept_name from CRM_DRREG c join doctorsonduty_drreg d on c.doctor_id = " +
                "d.dr_id where d.branch_id = " + branchid + " order by d.dept_name, d.dr_name ");
            return DS;
        }

        [WebMethod]
        public DataSet delete_select(int drid)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("delete from CRM_DRREG where doctor_id = " + drid + "");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Department()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from HOSPITAL.DEPARTMENT");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctor(int branch_id,int dept_id,string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select d.dr_name, d.dr_id from doctorsonduty_drreg d join CRM_DRREG c on c.doctor_id = d.dr_id where weekly_monthly " +
                "= 'Monthly' and day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and week_number = (select to_char(to_date" +
                "('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, " +
                "'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + " "+
                "union select d.dr_name, d.dr_id from doctorsonduty_drreg d join CRM_DRREG c on c.doctor_id = d.dr_id where weekly_monthly = 'Weekly' and " +
                "day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.dept_id = " + dept_id + " and " +
                "d.branch_id = " + branch_id + " "+
                "union select d.dr_name, d.dr_id from doctorsonduty_drreg d join CRM_DRREG c on c.doctor_id = d.dr_id join doctorsonduty_shiftchange s on " +
                "d.duty_id = s.duty_id where to_date(s.updated_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and d.dept_id = " + dept_id + " and " +
                "d.branch_id = " + branch_id + "");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctor1(int dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct Dr_id, Dr_name from DOCTORSONDUTY_DRREG where dept_id = " + dept_id + "");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorfrmdrrreg(int branch_id,int dept_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct Dr_id, Dr_name from DOCTORSONDUTY_DRREG where dept_id = " + dept_id + " and branch_id = " +
                "" + branch_id + " and Dr_id not in (select doctor_id from CRM_DRREG) ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctorattendance_avail(string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from doctorsonduty_drattendance where to_date(date_, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctor_availability(int branch_id,int dept_id,string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select d.dr_name, d.dr_id, d.duty_id, d.to_time || '-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number" +
                "(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = " +
                "d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = " +
                "d.dr_id where d.weekly_monthly = 'Monthly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and d.duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.dept_id = " + dept_id + " and " +
                "d.branch_id = " + branch_id + " " +
                "union select d.dr_name, d.dr_id, d.duty_id, d.to_time || '-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number" +
                "(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = " +
                "d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = " +
                "d.dr_id where d.weekly_monthly = 'Weekly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', " +
                "'DD-MM-YYYY')) and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + " " +
                "union select d.dr_name, d.dr_id, s.shiftchange_id, s.updated_from_time || '-' || s.updated_to_time time_, case when d.duty_id > 0 then (select nvl" +
                "(max(to_number(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and " +
                "c.doctor_id = d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join " +
                "doctorsonduty_shiftchange s on d.duty_id = s.duty_id join CRM_DRREG cd on cd.doctor_id = d.dr_id where to_date(s.updated_date, 'DD-MM-YYYY') = " +
                "to_date('" + date + "', 'DD-MM-YYYY') and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + "");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctor_availabilityattend(int branch_id, int dept_id, string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select d.dr_name || case when a.attend_bool = 0 then '    ( ' || a.attendance || ' ) ' else '' end dr_name, d.dr_id, d.duty_id, d.to_time || " +
                "'-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number(c.Token)), 0) from crm_doctorbooking c where to_date" +
                "(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = d.dr_id and c.dept_id = d.dept_id and c.branch_id = " +
                "d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = d.dr_id join doctorsonduty_drattendance a on a.duty_id " +
                "= d.duty_id where d.weekly_monthly = 'Monthly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and d.duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.dept_id = " + dept_id + " and " +
                "d.branch_id = " + branch_id + " and to_date(a.date_, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') " +
                "union select d.dr_name || case when a.attend_bool = 0 then '    ( ' || a.attendance || ' ) ' else '' end dr_name, d.dr_id, d.duty_id, d.to_time " +
                "|| '-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number(c.Token)), 0) from crm_doctorbooking c where to_date" +
                "(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = d.dr_id and c.dept_id = d.dept_id and c.branch_id = " +
                "d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = d.dr_id join doctorsonduty_drattendance a on a.duty_id " +
                "= d.duty_id where d.weekly_monthly = 'Weekly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) " +
                "and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + " and to_date(a.date_, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') " +
                "union select d.dr_name || case when a.attend_bool = 0 then '    ( ' || a.attendance || ' ) ' else '' end dr_name, d.dr_id, s.shiftchange_id, " +
                "s.updated_from_time || '-' || s.updated_to_time time_, case when d.duty_id > 0 then (select nvl(max(to_number(c.Token)), 0) from " +
                "crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = d.dr_id and c.dept_id = " +
                "d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join doctorsonduty_shiftchange s on d.duty_id = s.duty_id join " +
                "CRM_DRREG cd on cd.doctor_id = d.dr_id join doctorsonduty_drattendance a on a.duty_id = d.duty_id where to_date(s.updated_date, 'DD-MM-YYYY') = " +
                "to_date('" + date + "', 'DD-MM-YYYY') and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + " and to_date(a.date_, 'DD-MM-YYYY') = " +
                "to_date('" + date + "', 'DD-MM-YYYY') " +
                "union select d.dr_name, d.dr_id, d.duty_id, d.to_time || '-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number" +
                "(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = " +
                "d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id " +
                "= d.dr_id where d.weekly_monthly = 'Monthly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and d.duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.dept_id = " + dept_id + " " +
                "and d.branch_id = " + branch_id + " and d.duty_id not in (select duty_id from doctorsonduty_drattendance where to_date(date_, 'DD-MM-YYYY') = " +
                "to_date('" + date + "', 'DD-MM-YYYY')) " +
                "union select d.dr_name, d.dr_id, d.duty_id, d.to_time || '-' || d.from_time time_, case when d.duty_id > 0 then (select nvl(max(to_number" +
                "(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and c.doctor_id = " +
                "d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = " +
                "d.dr_id where d.weekly_monthly = 'Weekly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.duty_id not in (select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) " +
                "and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + " and d.duty_id not in (select duty_id from doctorsonduty_drattendance where " +
                "to_date(date_, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) " +
                "union select d.dr_name, d.dr_id, s.shiftchange_id, s.updated_from_time || '-' || s.updated_to_time time_, case when d.duty_id > 0 then (select nvl" +
                "(max(to_number(c.Token)), 0) from crm_doctorbooking c where to_date(c.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') and " +
                "c.doctor_id = d.dr_id and c.dept_id = d.dept_id and c.branch_id = d.branch_id) end Booking_no from doctorsonduty_drreg d join " +
                "doctorsonduty_shiftchange s on d.duty_id = s.duty_id join CRM_DRREG cd on cd.doctor_id = d.dr_id where to_date(s.updated_date, 'DD-MM-YYYY') = " +
                "to_date('" + date + "', 'DD-MM-YYYY') and d.dept_id = " + dept_id + " and d.branch_id = " + branch_id + " and d.duty_id not in (select duty_id " +
                "from doctorsonduty_drattendance where to_date(date_, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY'))");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_Doctor_departmentforconfirmation(int branch_id, string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select * from (select d.dr_id, d.dept_name || ' - ' || d.dr_name doctor_name from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = " +
                "d.dr_id where d.weekly_monthly = 'Monthly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and " +
                "d.week_number = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and d.duty_id not in (select duty_id from " +
                "doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.branch_id = '" + branch_id + "' " +
                "union select d.dr_id, d.dept_name || ' - ' || d.dr_name doctor_name from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = d.dr_id where " +
                "d.weekly_monthly = 'Weekly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and d.duty_id not in " +
                "(select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.branch_id " +
                "= '" + branch_id + "' " +
                "union select d.dr_id, d.dept_name || ' - ' || d.dr_name doctor_name from doctorsonduty_drreg d join doctorsonduty_shiftchange s on d.duty_id = " +
                "s.duty_id join CRM_DRREG cd on cd.doctor_id = d.dr_id where to_date(s.updated_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and " +
                "d.branch_id = '" + branch_id + "' " +
                "union select d.dr_id dr_id, d.dept_name || ' - ' || d.dr_name || ' (Shift Change)' doctor_name from crm_doctorbooking b join doctorsonduty_drreg " +
                "d on d.dr_id = b.doctor_id where to_date(b.booking_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and b.doctor_id not in (select " +
                "x.dr_id from (select d.dr_id, d.dept_name || '-' || d.dr_name doctor_name from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = d.dr_id " +
                "where d.weekly_monthly = 'Monthly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and d.week_number = " +
                "(select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'W') from dual) and d.duty_id not in (select duty_id from doctorsonduty_shiftchange where " +
                "to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.branch_id = '" + branch_id + "' " +
                "union select d.dr_id, d.dept_name || ' - ' || d.dr_name doctor_name from doctorsonduty_drreg d join CRM_DRREG cd on cd.doctor_id = d.dr_id where " +
                "d.weekly_monthly = 'Weekly' and d.day_of_duty = (select to_char(to_date('" + date + "', 'DD-MM-YYYY'), 'D') from dual) and d.duty_id not in " +
                "(select duty_id from doctorsonduty_shiftchange where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY')) and d.branch_id " +
                "= '" + branch_id + "' " +
                "union select d.dr_id, d.dept_name || ' - ' || d.dr_name doctor_name from doctorsonduty_drreg d join doctorsonduty_shiftchange s on d.duty_id = " +
                "s.duty_id join CRM_DRREG cd on cd.doctor_id = d.dr_id where to_date(s.updated_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and " +
                "d.branch_id = '" + branch_id + "') x)) y order by y.doctor_name");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }



        [WebMethod]
        public DataSet Get_Report(int branch_id, string date1,string date2)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select m.booking_id, m.patient_name, m.phone, m.dr_name, m.dept_name, m.createdby, m.createddate,m.booking_date,m.status from(select distinct b.booking_id, " +
                "b.patient_name, b.phone, d.dr_name, d.dept_name, b.createdby, b.createddate,b.booking_date, case when (b.status = 'Booked' " +
                "and b.booking_id in (select booking_id from crm_bookingcancel)) then 'Cancelled' end status from crm_doctorbooking b join doctorsonduty_drreg d " +
                "on b.doctor_id = d.dr_id join crm_bookingcancel c on c.booking_id = b.booking_id where b.branch_id = " + branch_id + " and to_date" +
                "(b.booking_date, 'dd-MM-yyyy') between to_date('"+date1+ "', 'dd-MM-yyyy') and to_date('" + date2 + "', 'dd-MM-yyyy')  " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name, b.createdby, b.createddate,b.booking_date, case when (b.status = 'Booked' " +
                "and b.booking_id in (select booking_id from crm_bookingreschedule)) then 'Rescheduled' end status from crm_doctorbooking b join " +
                "doctorsonduty_drreg d on b.doctor_id = d.dr_id join crm_bookingreschedule c on c.booking_id = b.booking_id where b.branch_id = " + branch_id + " " +
                "and to_date(b.booking_date, 'dd-MM-yyyy') between to_date('" + date1 + "', 'dd-MM-yyyy') and to_date('" + date2 + "', 'dd-MM-yyyy') " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name, b.createdby, b.createddate,b.booking_date, case when b.status = 'Booked' " +
                "then 'Booked' end from crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id = d.dr_id and b.booking_id not in (select booking_id from " +
                "crm_bookingcancel) and b.booking_id not in (select booking_id from crm_bookingreschedule) and b.status = 'Booked' and b.branch_id = " +
                "" + branch_id + " and to_date(b.booking_date, 'dd-MM-yyyy') between to_date('" + date1 + "', 'dd-MM-yyyy') and to_date('" + date2 + "', 'dd-MM-yyyy') " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name, b.createdby, b.createddate,b.booking_date, case when b.status = 'Confirmed' " +
                "then 'Confirmed' end from crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id = d.dr_id and b.booking_id not in (select booking_id from " +
                "crm_bookingcancel) and b.booking_id not in (select booking_id from crm_bookingreschedule) and b.status = 'Confirmed' and b.branch_id = " +
                "" + branch_id + " and to_date(b.booking_date, 'dd-MM-yyyy') between to_date('" + date1 + "', 'dd-MM-yyyy') and to_date('" + date2 + "', 'dd-MM-yyyy') " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name, b.createdby, b.createddate,b.booking_date, case when b.status = 'Arrived' " +
                "then 'Arrived' end from crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id = d.dr_id and b.booking_id not in (select booking_id from " +
                "crm_bookingcancel) and b.status = 'Arrived' and b.branch_id = " + branch_id + " and to_date(b.booking_date, 'dd-MM-yyyy') " +
                "between to_date('" + date1 + "', 'dd-MM-yyyy') and to_date('" + date2 + "', 'dd-MM-yyyy'))m order by m.dr_name,m.booking_date,m.status");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_NextToken(int branch_id,int dept_id, int doctor_id,string date_)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select nvl(max(Token), 0) + 1 from CRM_DoctorBooking where branch_id = " + branch_id + " and doctor_id = " +
                "" + doctor_id + " and dept_id = " + dept_id + " and to_date(booking_date, 'dd-MM-yyyy') = to_date('" + date_ + "', 'dd-MM-yyyy')");
            return DS;
        }

        [WebMethod]
        public DataSet Get_VisitTime(int branch_id,int dept_id, int doctor_id, string date_)
        {
            DataSet DS = new DataSet();
            string query = "";
            query=("select d.to_time || '-' || d.from_time time_, (select count(*) from crm_doctorbooking where to_date(booking_date, 'dd-MM-yyyy') = to_date" +
                "(sysdate, 'dd-MM-yyyy') and branch_id = '" + branch_id + "' and dept_id = '" + dept_id + "' and dr_id = '" + doctor_id + "') Noofbooking from " +
                "doctorsonduty_drreg d where weekly_monthly = 'Monthly' and day_of_duty = (select to_char(to_date('" + date_ + "', 'DD-MM-YYYY'), 'D') from dual) " +
                "and week_number = (select to_char(to_date('" + date_ + "', 'DD-MM-YYYY'), 'W') from dual) and branch_id = " + branch_id + " and dept_id = " +
                "" + dept_id + " and dr_id = " + doctor_id + " and duty_id not in (select a.duty_id from doctorsonduty_shiftchange a join doctorsonduty_drreg b on " +
                "a.duty_id = b.duty_id where to_date(actual_date, 'DD-MM-YYYY') = to_date('" + date_ + "', 'DD-MM-YYYY') and branch_id = " + branch_id + " and " +
                "dept_id = " + dept_id + " and dr_id = " + doctor_id + ") " +
                "union select d.to_time || '-' || d.from_time time_, (select count(*) from crm_doctorbooking where to_date (booking_date, 'dd-MM-yyyy') = to_date" +
                "(sysdate, 'dd-MM-yyyy') and branch_id = '" + branch_id + "' and dept_id = '" + dept_id + "' and dr_id = '" + doctor_id + "') Noofbooking from " +
                "doctorsonduty_drreg d where weekly_monthly = 'Weekly' and day_of_duty = (select to_char(to_date('" + date_ + "', 'DD-MM-YYYY'), 'D') from dual) " +
                "and branch_id = " + branch_id + " and dept_id = " + dept_id + " and dr_id = " + doctor_id + " and duty_id not in (select a.duty_id from " +
                "doctorsonduty_shiftchange a join doctorsonduty_drreg b on a.duty_id = b.duty_id where to_date(actual_date, 'DD-MM-YYYY') = to_date" +
                "('" + date_ + "', 'DD-MM-YYYY') and branch_id = " + branch_id + " and dept_id = " + dept_id + " and dr_id = " + doctor_id + ") " +
                "union select s.updated_from_time || '-' || s.updated_to_time time_, (select count(*) from crm_doctorbooking where to_date(booking_date, " +
                "'dd-MM-yyyy') = to_date(sysdate, 'dd-MM-yyyy') and branch_id = '" + branch_id + "' and dept_id = '" + dept_id + "' and dr_id = " +
                "'" + doctor_id + "') Noofbooking from doctorsonduty_drreg d join doctorsonduty_shiftchange s on d.duty_id = s.duty_id where to_date" +
                "(s.updated_date, 'DD-MM-YYYY') = to_date('" + date_ + "', 'DD-MM-YYYY') and branch_id = " + branch_id + " and dept_id = " + dept_id + " and dr_id " +
                "= " + doctor_id + "");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_BookingDtlstoreschedule(int booking_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from crm_doctorbooking where booking_id = " + booking_id + "");
            return DS;
        }

        [WebMethod]
        public DataSet Get_BookingDtls_forconsultationstatus(int branch_id, int dr_id, string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select booking_id, patient_name, phone, token, case when status = 'Arrived' then 1 else 0 end status1 from " +
                "crm_doctorbooking where branch_id = " + branch_id + " and doctor_id = " + dr_id + " and to_date(booking_date, 'DD-MM-YYYY') = to_date" +
                "('" + date + "', 'DD-MM-YYYY') and (status = 'Confirmed' or status = 'Arrived') and booking_id not in (select booking_id from crm_bookingcancel) " +
                "and booking_id not in (select booking_id from crm_bookingreschedule) order by token ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_BookingDtls_forconfirmation(int branch_id,int dr_id,string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            //query=("select booking_id, patient_name, phone, token from crm_doctorbooking where branch_id = " + branch_id + " and doctor_id = " + dr_id + " and " +
            //    "to_date(booking_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and status! = 'Confirmed' and booking_id not in (select booking_id " +
            //    "from crm_bookingcancel) and booking_id not in (select booking_id from crm_bookingreschedule) order by token ");
            query = ("select booking_id, patient_name, phone, token from crm_doctorbooking where branch_id = " + branch_id + " and doctor_id = " + dr_id + " and " +
                   "to_date(booking_date,'dd-MM-yyyy') = to_date('" + date + "','dd-MM-yyyy') and status='Booked'  and booking_id not in (select booking_id " +
                   "from crm_bookingcancel union select booking_id from crm_bookingreschedule) order by booking_id");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_BookingDtls_foredit(int branch_id, int dr_id, string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select booking_id, patient_name, phone, token from crm_doctorbooking where branch_id = " + branch_id + " and doctor_id = " + dr_id + " and " +
                "to_date(booking_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and booking_id not in (select booking_id from crm_bookingcancel) and " +
                "booking_id not in (select booking_id from crm_bookingreschedule) order by token ");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_BookingDtls(int branch_id, int dept_id, int dr_id, string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select booking_id, patient_name, phone, token from crm_doctorbooking where branch_id = " + branch_id + " and " +
                "dept_id = " + dept_id + " and doctor_id = " + dr_id + " and to_date(booking_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and " +
                "status != 'Confirmed' and booking_id not in (select booking_id from crm_bookingcancel) and booking_id not in (select booking_id from " +
                "crm_bookingreschedule) order by token ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_BookingDtls_Todaybooking(int branch_id, int dept_id, int dr_id, string date)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select booking_id, patient_name, phone, token from crm_doctorbooking where branch_id = " + branch_id + " and " +
                "dept_id = " + dept_id + " and doctor_id = " + dr_id + " and to_date(booking_date, 'DD-MM-YYYY') = to_date('" + date + "', 'DD-MM-YYYY') and " +
                "status = 'Confirmed' and booking_id not in (select booking_id from crm_bookingcancel) and booking_id not in (select booking_id from " +
                "crm_bookingreschedule) order by token ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Report_Todaybooking(int branch_id, int dept_id, int dr_id, string date)
        {
            DataSet DS = new DataSet();
            string query = "";
            query = ("select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name, b.token, case when (b.status = 'Booked' and b.booking_id in " +
                "(select booking_id from crm_bookingcancel)) then 'Cancelled' end status from crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id = " +
                "d.dr_id join crm_bookingcancel c on c.booking_id = b.booking_id where b.branch_id = " + branch_id + " and d.dept_id = " + dept_id + " and d.dr_id " +
                "= " + dr_id + " and to_date(b.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name,b.token, case when (b.status = 'Booked' and b.booking_id in " +
                "(select booking_id from crm_bookingreschedule)) then 'Rescheduled' end status from crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id " +
                "= d.dr_id join crm_bookingreschedule c on c.booking_id = b.booking_id where b.branch_id = " + branch_id + " and d.dept_id = " + dept_id + " and " +
                "d.dr_id = " + dr_id + " and to_date(b.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name,b.token, case when b.status = 'Booked' then 'Booked' end from " +
                "crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id = d.dr_id and b.booking_id not in (select booking_id from crm_bookingcancel) and " +
                "b.booking_id not in (select booking_id from crm_bookingreschedule) and b.status = 'Booked' and b.branch_id = " + branch_id + " and d.dept_id = " +
                "" + dept_id + " and d.dr_id = " + dr_id + " and to_date(b.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy') " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name, b.token, case when b.status = 'Confirmed' then 'Confirmed' " +
                "end from crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id = d.dr_id and b.booking_id not in (select booking_id from " +
                "crm_bookingcancel) and b.booking_id not in (select booking_id from crm_bookingreschedule) and b.status = 'Confirmed' and b.branch_id = " +
                "" + branch_id + " and d.dept_id = " + dept_id + " and d.dr_id = " + dr_id + " and to_date(b.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', " +
                "'dd-MM-yyyy') " +
                "union select distinct b.booking_id, b.patient_name, b.phone, d.dr_name, d.dept_name, b.token, case when b.status = 'Arrived' then 'Arrived' end " +
                "from crm_doctorbooking b join doctorsonduty_drreg d on b.doctor_id = d.dr_id and b.booking_id not in (select booking_id from crm_bookingcancel) " +
                "and b.status = 'Arrived' and b.branch_id = " + branch_id + " and d.dept_id = " + dept_id + " and d.dr_id = " + dr_id + " and to_date" +
                "(b.booking_date, 'dd-MM-yyyy') = to_date('" + date + "', 'dd-MM-yyyy')");
            DS = ObjOrclHelper.ExecuteDataSet(query);
            return DS;
        }

        [WebMethod]
        public DataSet Get_PatientDtls(int branch_id,int dept_id,int doctor_id,string date_,string visit_time )
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select patient_name, token || '-' || patient_name paient, case when status = 'Arrived' then 1 else 0 end from " +
                "crm_doctorbooking where booking_date = '" + date_ + "' and branch_id = " + branch_id + " and dept_id = " + dept_id + " and doctor_id = " +
                "" + doctor_id + " and visit_time = " + visit_time + "");
            return DS;
        }

        [WebMethod]
        public DataSet Get_BookingReport(int branch_id, int dept_id, int doctor_id, string date_, string visit_time,string type)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select patient_name, Phone, Status, (select count(*) from crm_doctorbooking where status = 'Arrived' and " +
                "booking_date = '" + date_ + "' and branch_id = " + branch_id + " and dept_id = " + dept_id + " and doctor_id = " + doctor_id + " and visit_time = " +
                "'" + visit_time + "') Arrived, (select count(*) from crm_doctorbooking where status = 'Confirmed' and booking_date = '" + date_ + "' and " +
                "branch_id = " + branch_id + " and dept_id = " + dept_id + " and doctor_id = " + doctor_id + " and visit_time = '" + visit_time + "') Confirmed, " +
                "(select count(*) from crm_doctorbooking where status = 'Booked' and booking_date = '" + date_ + "' and branch_id = " + branch_id + " and dept_id " +
                "= " + dept_id + " and doctor_id = " + doctor_id + " and visit_time = '" + visit_time + "') Booked, (select count(*) from crm_doctorbooking a join " +
                "crm_bookingcancel b on a.booking_id = b.booking_id where booking_date = '" + date_ + "' and branch_id = " + branch_id + " and dept_id = " +
                "" + dept_id + " and doctor_id = " + doctor_id + " and visit_time = '" + visit_time + "') Cancelled, (select count(*) from crm_doctorbooking a " +
                "join crm_bookingreschedule b on a.booking_id = b.booking_id where booking_date = '" + date_ + "' and branch_id = " + branch_id + " and dept_id = " +
                "" + dept_id + " and doctor_id = " + doctor_id + " and visit_time = '" + visit_time + "') Rescheduled from crm_doctorbooking where booking_date = " +
                "'" + date_ + "' and branch_id = " + branch_id + " and dept_id = " + dept_id + " and doctor_id = " + doctor_id + " and visit_time = " +
                "'" + visit_time + "'");
            return DS;
        }

        [WebMethod]
        public int Insert_Usage(string username)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into module_usage_log values ('CRM Module', '" + username + "', sysdate)");
            return id;
        }
    }
}
