using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService_NABLAccredtn
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer;
        private string timeString;
        public int getCallType;
        private static System.Threading.Timer _timer;

        ServiceReference1.WebService_OperationSoapClient objService = new ServiceReference1.WebService_OperationSoapClient();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.timer = new System.Timers.Timer(60 * 60 * 1000 * 24);  // 30000 milliseconds = 30 seconds // 60 * 1000 (1 minute) // 60 * 60 * 1000 (1 hour)
            this.timer.AutoReset = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            this.timer.Start();
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataSet ds = new DataSet();
            //ds = objservice.Pharma_punch_alert(DateTime.Now.ToString(), shiftid.ToString());
            ds = objService.Check_ReminderDate();
            //...................................................................................
            //string msg = "Branch - 1257-Manappuram Health Care Ltd - PERINGOTTUKARA -- Shift - MORNING-59- (07:00:00 to 16:00:00) -- Shortage - 2 ##Branch - 2592-Manappuram Health Care Ltd - PERINJANAM -- Shift - MORNING-59- (07:00:00 to 16:00:00) -- Shortage - 1 ##Branch - 2646-Manappuram Health Care Ltd - CHAVAKKAD -- Shift - MORNING-59- (07:00:00 to 16:00:00) -- Shortage - 1 ##" +
            //    "Branch - 3139-Manappuram Health Care Ltd - KECHERY -- Shift - MORNING-59- (07:00:00 to 16:00:00) -- Shortage - 1 ##Branch - 3215-Manappuram Health Care Ltd - CHENTHRAPINNI -- Shift - MORNING-59- (07:00:00 to 16:00:00) -- Shortage - 2 ##Branch - 3143-Manappuram Health Care Ltd - THALIKKULAM  -- Shift - MORNING-59- (07:00:00 to 16:00:00) -- Shortage - 1 ##";
            //string[] msgs = msg.Split('##');
            //...................................................................................
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("itcoordinator@macare.in"));

                    MailMsg.Subject = "NABL Accreditation Alert";
                    MailMsg.Body = "";
                    // Add a carbon copy recipient.

                    MailAddress copy = new MailAddress("techlead@macare.in");
                    MailMsg.CC.Add(copy);
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
        protected override void OnStop()
        {
        }
    }
}
