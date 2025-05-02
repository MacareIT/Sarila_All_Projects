using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.OracleClient;

namespace WebService_PurchaseCommittee
{
    /// <summary>
    /// Summary description for Service_PurchaseCommittee
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service_PurchaseCommittee : System.Web.Services.WebService
    {
        OracleHelper ObjOrclHelper = new OracleHelper();
        DataSet ObjDataSet = new DataSet();
        DataTable ObjDatatb = new DataTable();

        [WebMethod]
        public DataSet Get_login(string username, string password)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from LOGIN_USERS where username = '" + username + "' and password = '" + password + "'");
            return DS;
        }

        [WebMethod]
        public DataSet Get_Branch()
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select branch_id,name from hospital.clinic_master where " +
            //"clinic_id not in (11,13,14,6,8,9,10,22,26,17,19,29,31,35,36,25,32,33,34) and name is not null and name != '0'");
            DS = ObjOrclHelper.ExecuteDataSet("select * from (select branch_id,name branch_name from  hospital.clinic_master where branch_id=0 union select branch_id, name branch_name " +
                "from hospital.clinic_master where firm_id in (16, 33) and status = 1 and clinic_id not in (6, 8, 9, 10, 14, 17, 19, 25, 29, 31, 37) union select branch_id,branch_name " +
                "from hospital.pharmacy_master where firm_id =16 and status=1) z order by z.branch_name");
            return DS;
        }

        [WebMethod]
        public DataSet Get_dapartment()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct dep_name from HOSPITAL.DEPARTMENT_MST where firm_id=16 and status=1");
            return DS;
        }

        [WebMethod]
        public int Add_quotationdetails(string item_id,string dep_id, string product_name, string purpose)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into purchasecommittee_master (item_id, dept_name, product_name, purpose, status) values" +
                "('" + item_id + "', '" + dep_id + "', '" + product_name + "', '" + purpose + "', 'Requested')");
            return id;
        }

        [WebMethod]
        public int Add_schedule(string date, string venue,string item_id)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update purchasecommittee_master set date_ = '" + date + "', venue = '" + venue + "', status = " +
                "'Scheduled' where item_id = '" + item_id + "' ");
            return id;
        }

        [WebMethod]
        public DataSet View_Schedule()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select distinct date_, venue from purchasecommittee_master where status = 'Scheduled' ");
            return DS;
        }

        [WebMethod]
        public DataSet View_Details(string date,string venue)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_master where date_ = '" + date + "' and venue = '" + venue + "' " +
                "and status = 'Scheduled' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_pendingquotations()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_master where status = 'Requested' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_rejectedquotations()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_master where status = 'Rejected' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_minutesdtl()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_master where status = 'Approved' or status = 'Rejected' order by " +
                "to_date(date_, 'DD-MM-YYYY') desc ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_quotationforgeneratepo()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_master m join purchasecommittee_quotation q on m.item_id = " +
                "q.item_id where m.status = 'Approved' and q.status = 1 ");
            return DS;
        }

        [WebMethod]
        public DataSet View_Quotations(string item_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_quotation where item_id = '" + item_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet View_IndividualQuotations(string quotation_id)
        {
            DataSet DS = new DataSet();
            //DS = ObjOrclHelper.ExecuteDataSet("select quotation from purchasecommittee_quotation where quotation_id = '" + quotation_id + "' ");
            DS = ObjOrclHelper.ExecuteDataSet("select filename,attachment,content_type from purchasecommittee_quotation where quotation_id='"+ quotation_id + "'");
            return DS;
        }
        

        [WebMethod]
        public DataSet Get_individualpendingquotations(string item_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_master where item_id = '" + item_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_purchaseordrdtl(string quotation_id)
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select * from purchasecommittee_master m join purchasecommittee_quotation q on m.item_id = " +
                "q.item_id where q.quotation_id = '" + quotation_id + "' ");
            return DS;
        }

        [WebMethod]
        public DataSet Get_itemid()
        {
            DataSet DS = new DataSet();
            DS = ObjOrclHelper.ExecuteDataSet("select SEQ_PURCHASECOMMITEE.nextval from dual");
            return DS;
        }


        [WebMethod]
        public int Add_quotation(string item_id, string quotation,string vendor_name,string item_dec,string amount)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("insert into purchasecommittee_quotation (quotation_id, item_id, quotation, status, vendor_name, " +
                "item_description, amount) values(SEQ_PURCHASECOMMITEEQUOTATION.nextval, '" + item_id + "', '" + quotation + "', 0, " +
                "'" + vendor_name + "', '" + item_dec + "', '" + amount + "')");
            return id;
        }

        [WebMethod]
        public int Add_minutes(string itemid, string quotationid, string participants,string decision,string status,string negotianted_amt)
        {
            int id = 0;
            int id1 = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update purchasecommittee_master set participants = '" + participants + "', decision = " +
                "'" + decision + "', status = '" + status + "' where item_id = '" + itemid + "' ");
            id1= ObjOrclHelper.ExecuteNonQuery("update purchasecommittee_quotation set status = 1, negotiated_amount = '" + negotianted_amt + "' " +
                "where quotation_id = '" + quotationid + "' ");
            return id;
        }

        [WebMethod]
        public int Add_nonapprovedminutes(string itemid, string quotationid, string participants, string decision, string status, string negotianted_amt)
        {
            int id = 0;
            int id1 = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update purchasecommittee_master set participants = '" + participants + "', decision = " +
                "'" + decision + "', status = '" + status + "' where item_id = '" + itemid + "' ");
            id1 = ObjOrclHelper.ExecuteNonQuery("update purchasecommittee_quotation set negotiated_amount = '" + negotianted_amt + "' where " +
                "quotation_id = '" + quotationid + "' ");
            return id;
        }

        [WebMethod]
        public int Add_negotiatedamt( string quotationid, string negotianted_amt)
        {
            int id = 0;
            id = ObjOrclHelper.ExecuteNonQuery("update purchasecommittee_quotation set status = 1, negotiated_amount = '" + negotianted_amt + "' " +
                "where quotation_id = '" + quotationid + "' ");
            return id;
        }




        //------------------------------------Dashboard-----------------------------------------------------------------------------------------------------

        [WebMethod()]
        public int Get_totalrequested()
        {
            int result = 0;
            result = ObjOrclHelper.executeScalar("select count(*) from purchasecommittee_master where status = 'Requested' ");
            return result;
        }

        [WebMethod()]
        public int Get_totalpending()
        {
            int result = 0;
            result = ObjOrclHelper.executeScalar("select count(*) from purchasecommittee_master where status = 'Scheduled' ");
            return result;
        }

        [WebMethod()]
        public int Get_totalrejected()
        {
            int result = 0;
            result = ObjOrclHelper.executeScalar("select count(*) from purchasecommittee_master where status = 'Rejected' ");
            return result;
        }

        [WebMethod()]
        public int Insert_Quotation(string item_id, string vendor_name, string item_dec, string amount, byte[] attachment, string file_name, string contenttype, string submitted_by, string submitted_on)
        {
            try
            {
                int id = 0; int s = 0;

                string constr = "Data Source=mbisdb;User ID=hospital;Password=koothara999;Unicode=True";
                //string constr = "Data Source=MACUAT;User ID=Macare_Internal;Password=pass#1234;Unicode=True;";
                using (OracleConnection con = new OracleConnection(constr))
                {
                    string query = "insert into PURCHASECOMMITTEE_QUOTATION(quotation_id, item_id, status, vendor_name,item_description, amount,attachment,filename,content_type,submitted_by,submitted_on) values" +
                        "(SEQ_PURCHASECOMMITEEQUOTATION.nextval,:item_id,:status,:vendor_name,:item_description,:amount,:attachment,:filename,:content_type,:submitted_by,:submitted_on)";

                    using (OracleCommand cmd = new OracleCommand(query))
                    {
                        cmd.Connection = con;
                        //cmd.Parameters.AddWithValue(":quotation_id", 0);
                        cmd.Parameters.AddWithValue(":item_id", item_id);
                        cmd.Parameters.AddWithValue(":status", 0);
                        cmd.Parameters.AddWithValue(":vendor_name", vendor_name);
                        cmd.Parameters.AddWithValue(":item_description", item_dec);
                        cmd.Parameters.AddWithValue(":amount", amount);
                        cmd.Parameters.AddWithValue(":attachment", attachment);
                        cmd.Parameters.AddWithValue(":filename", file_name);
                        cmd.Parameters.AddWithValue(":content_type", contenttype);
                        cmd.Parameters.AddWithValue(":submitted_by", submitted_by);
                        cmd.Parameters.AddWithValue(":submitted_on", submitted_on);

                        con.Open();
                        s = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                //int id1 = 0;
                return s;
            }
            catch(Exception ex)
            {
                return 0;
            }
        }

    }
}
