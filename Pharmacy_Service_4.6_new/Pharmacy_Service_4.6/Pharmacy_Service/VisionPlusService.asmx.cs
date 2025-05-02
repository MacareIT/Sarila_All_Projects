using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Pharmacy_Service
{
    /// <summary>
    /// Summary description for VisionPlusService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class VisionPlusService : System.Web.Services.WebService
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
        public DataSet ListClinic()
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from HOSPITAL.CLINIC_MASTER t where t.status=1 and t.firm_id=16 and t.branch_type=3";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public DataSet ListDetails_branch(string branchid)
        {
            ds = new DataSet();
            string query = "select t.*, t.rowid from HOSPITAL.CLINIC_MASTER t where t.status=1 and t.firm_id=16 and t.branch_type=3 and branch_id="+branchid+"";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int Changepassword(string id, string newpwd)
        {
            int res;
            string query = "update LOGIN_USERS set password='" + newpwd + "' where userid=" + Convert.ToInt32(id) + "";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet VisionBranchdetails_byoptometrist(string userid)
        {
            ds = new DataSet();
            string query = "select usr.userid,usr.log_user,cm.phone1,cm.phone2,cm.address,'MANAPPURAM MACARE VISIONPLUS '||cm.location branch_name,cm.branch_id from login_users usr " +
                           "join hospital.clinic_master cm on cm.branch_id = usr.branchid where usr.username="+userid+"";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
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
        public DataSet LOginUsers(string type)
        {
            ds = new DataSet();
            string query = "select * from LOGIN_USERS where type='" + type + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public int Create_visionCustomer_process(string paramdata)
        {
            int retval;
            try
            {
                string[] norms = paramdata.Split('*');
                OracleParameter[] oracleParamArray = new OracleParameter[8];
                OracleParameter objOracleParam;

                objOracleParam = new OracleParameter("prm_name", OracleType.VarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = norms[0];
                oracleParamArray[0] = objOracleParam;

                objOracleParam = new OracleParameter("prm_place", OracleType.VarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = norms[1];
                oracleParamArray[1] = objOracleParam;

                objOracleParam = new OracleParameter("prm_contact", OracleType.VarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = norms[2];
                oracleParamArray[2] = objOracleParam;

                objOracleParam = new OracleParameter("prm_powerright", OracleType.NVarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = norms[3];
                oracleParamArray[3] = objOracleParam;

                objOracleParam = new OracleParameter("prm_powerleft", OracleType.NVarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = norms[4];
                oracleParamArray[4] = objOracleParam;

                objOracleParam = new OracleParameter("prm_lens", OracleType.NVarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = norms[5];
                oracleParamArray[5] = objOracleParam;

                objOracleParam = new OracleParameter("prm_userid", OracleType.Number);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = Convert.ToInt32(norms[6]);
                oracleParamArray[6] = objOracleParam;

                objOracleParam = new OracleParameter("prm_flag", OracleType.VarChar);
                objOracleParam.Direction = ParameterDirection.Input;
                objOracleParam.Value = norms[7];
                oracleParamArray[7] = objOracleParam;
                retval = Objorclhelper.executeNonQuery_procedure("proc_visionProcess", oracleParamArray);
            }
            catch (Exception ex)
            {
                retval = 0;
            }

            return retval;
        }
        [WebMethod]
        public int REgvision(string name, string place, string contact, string right, string left, string lens, string userid)
        {
            string query; int res = 0;
            query = "insert into VISION_REGISTRATION values(seq_visionreg.nextval,'" + name + "','" + place + "','" + contact + "','" + right + "','" + left + "','" + lens + "','" + userid + "',sysdate)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int AddCustomer(string name, string address, string place, string contact1, string contact2, string left, string right,string lens,string enterduser,string age,string gender,string visitpurpose)
        {
            string query; int res = 0;
            query = "insert into OPTICAL_REGISTRATION values(SEQ_OPTICALREG.nextval,'" + name + "','" + address + "','"+place+"','" + contact1 + "','','" + left + "','" + right + "','" + lens + "','" + enterduser + "',sysdate,"+age+",'"+gender+"','"+visitpurpose+"')";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int AddOptometrist(string name,string qualification,string branchid)
        {
            string query; int res = 0;
            query = "insert into OPTICAL_OPTOMETRIST values(SEQ_OPTOMETRIST.nextval,'" + name + "','" + qualification + "','" + branchid + "',1)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet LoadCustomers()
        {
            ds = new DataSet();
            string query = "select * from OPTICAL_REGISTRATION";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet LoadCustomer_data(string id)
        {
            ds = new DataSet();
            string query = "select r.custname,r.address,r.place,r.contact1,r.contact2,r.powerright,r.powerleft,r.lens,r.age,r.gender,r.purposeofvisit from optical_Registration r where r.id=" + id+"";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet LoadCustomerPrescription_data(string id)
        {
            ds = new DataSet();
            string query = "select p.rt_sph,p.rt_cyl,p.rt_axi,p.rt_pd,p.rt_nearaddition,p.rt_distancevision,p.rt_nearvision,p.lt_sph,p.lt_cyl,p.lt_axi,p.lt_pd,p.lt_nearsddition,p.lt_distancevision,p.lt_nearvision,r.custname,r.age,r.gender,r.purposeofvisit,r.contact1,r.place from optical_prescription p join optical_registration r on r.id=p.customerid where p.id in(select max(id) from optical_prescription where customerid = "+id+")";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet LoadOptometrist(string branchid)
        {
            ds = new DataSet();
            string query = "select s.id,s.name,s.qualification,s.branchid from optical_optometrist s where s.status=1 and s.branchid="+branchid+"";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;

        }
        [WebMethod]
        public int AddPrescription(string custid,string RT_sph,string RT_cyl,string RT_axi,string RT_pd,string RT_nearaddition,string RT_distancevision,string RT_nearvision, string LT_sph, string LT_cyl, string LT_axi, string LT_pd, string LT_nearaddition, string LT_distancevision, string LT_nearvision,string optometricid,string enteredby,string branchid)
        {
            string query; int res = 0;
            query = "insert into optical_prescription values(SEQ_OPTICAL_PRES.nextval," + custid + ",'" + RT_sph + "','" + RT_cyl + "','" + RT_axi + "','" + RT_pd + "','" + RT_nearaddition + "','" + RT_distancevision + "','" + RT_nearvision + "','"+LT_sph+"','"+LT_cyl+"','"+LT_axi+"','"+LT_pd+"','"+LT_nearaddition+"','"+LT_distancevision+"','"+LT_nearvision+"',"+optometricid+",sysdate,"+enteredby+","+branchid+")";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public DataSet Vision_RegisteredCustomer(string contact)
        {
            ds = new DataSet();
            string query = "select * from vision_registration where contactno='" + contact + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Vision_RegisteredCustomerBy_ID(string id)
        {
            ds = new DataSet();
            string query = "select * from vision_registration where id='" + id + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Vision_ListCustomers(string frmdate, string todate,string branchid)
        {
            ds = new DataSet();
            string query = "select distinct reg.id,reg.custname,reg.place,reg.contact1,reg.createdate,reg.purposeofvisit from  OPTICAL_PRESCRIPTION p join optical_registration reg on reg.id = p.customerid where p.branchid = "+branchid+" and to_date(p.createdate,'dd-MM-yyyy') between '"+frmdate+"' and '"+todate+"'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public DataSet Optical_ListCustomers(string frmdate, string todate,string branchid)
        {
            ds = new DataSet();
            string query = "select distinct t.*, t.rowid,t.createdate from OPTICAL_REGISTRATION t left outer join  OPTICAL_PRESCRIPTION p on t.id=p.customerid where p.branchid=" + branchid + " and to_date(t.createdate,'dd-MM-yyyy') between '" + frmdate + "' and '" + todate + "'";
            ds = Objorclhelper.ExecuteDataset(query);
            return ds;
        }
        [WebMethod]
        public int Optical_NewRegCOUNT(string frmdate, string todate, string branchid)
        {
            int count;
            string query = "select count( distinct t.id) TotalReg from OPTICAL_REGISTRATION t left outer join  OPTICAL_PRESCRIPTION p on t.id=p.customerid where p.branchid=" + branchid + " and to_date(t.createdate,'dd-MM-yyyy') between '" + frmdate + "' and '" + todate + "'";
            count= Objorclhelper.executeScalar(query);
            return count;
        }
        [WebMethod]
        public int Optical_ExistingRegCOUNT(string frmdate, string todate, string branchid)
        {
            int count;
            string query = "select count(distinct p.id) ExistingCount from  OPTICAL_PRESCRIPTION p where p.customerid not in (select r.id from optical_registration r where to_date(r.createdate,'dd-MM-yyyy') between '"+frmdate+"' and '"+todate+"' ) and p.branchid = "+branchid+" and to_date(p.createdate,'dd-MM-yyyy') between '"+frmdate+"' and '"+todate+"'";
            count = Objorclhelper.executeScalar(query);
            return count;
        }
        [WebMethod]
        public int Optical_TotalColl(string frmdate, string todate, string branchid)
        {
            int collection;
            string query = "select nvl(sum(t.bill_amt),0) Collection from HOSPITAL.OPTICAL_SALES_MASTER t where to_date(t.tra_dt,'dd-MM-yyyy')between '"+frmdate+"' and '"+todate+"' and t.BRANCH_ID in("+branchid+")";
            collection = Objorclhelper.executeScalar(query);
            return collection;
        }
        [WebMethod]
        public int Optical_OptometristCount(string branchid)
        {
            int count;
            string query = "select count(*) from optical_optometrist op where op.branchid="+branchid+" ";
            count = Objorclhelper.executeScalar(query);
            return count;
        }
        [WebMethod]
        public int Vision_UpdateCustomerBy_ID(string id, string name, string place, string contact, string right, string left, string lens)
        {
            int res;
            string query = "update vision_registration set name='" + name + "', place='" + place + "' , contactno='" + contact + "' , power_right='" + right + "' , power_left='" + left + "' , lens='" + lens + "' where id=" + Convert.ToInt32(id) + "";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
        [WebMethod]
        public int updateUsage(string path, string userid)
        {
            string query; int res = 0;
            query = "insert into CRF_USAGE values(SEQ_CRFUSAGE.nextval,0,1," + userid + ",'" + path + "',sysdate)";
            res = Objorclhelper.executeNonQuery(query);
            return res;
        }
    }
}
