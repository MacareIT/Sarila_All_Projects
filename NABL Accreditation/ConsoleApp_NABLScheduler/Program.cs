using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.Net.Mail;

namespace ConsoleApp_NABLScheduler
{
    class Program
    {
        //https://macare.mactech.net.in/MACARE_MIS_Service/WebService_Operation/WebService_Operation.asmx

        ServiceReference1.WebService_OperationSoapClient objService = new ServiceReference1.WebService_OperationSoapClient();
        static void Main(string[] args)
        {
            Program P = new Program();
            P.nabl_alert();
            P.load_agreement_renewal();
        }
        public void load_agreement_renewal()
        {
            string textBody = " <table border=" + 1 + " cellpadding=" + 7 + " cellspacing=" + 0 + " width = " + 1500 + "><tr><td><b>Agreement Type    </b></td> <td width='60px'><b>Agreement Party              </b></td> <td width='60px'><b>Date of Execution        </b></td> <td width='60px'1><b>Next Renewal</b></td></tr>";

            MailMessage mail = new MailMessage();
            System.Net.Mail.SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            DataTable dt_attende = objService.Check_Agrmnt_renewal().Tables[0];
            if (dt_attende.Rows.Count > 0)
            {
                for (int loopCount = 0; loopCount < dt_attende.Rows.Count; loopCount++)
                {
                    textBody += "<tr><td>" + dt_attende.Rows[loopCount]["Agrmnt_type"] + "</td><td> " + dt_attende.Rows[loopCount]["Agrmnt_party"] + "</td><td> " + dt_attende.Rows[loopCount]["Date_of_execution"] + "</td><td> " + dt_attende.Rows[loopCount]["Next_renewal"] + "</td> </tr>";
                }
                textBody += "</table>";

                mail.From = new MailAddress("MacareIT@macare.in");
               
                mail.Subject = "Agreement Renewal Alert";
                mail.Body = "Dear Sir,<br/>" + "Agreement Renewal date Assigned as <br/><br/>" + textBody + "<br/><br/><br/>Please do not reply to this email ID as this is an automatically generated email and reply to this ID is not being monitored";
                mail.IsBodyHtml = true;
                mail.To.Add("operationhead@macare.in");
                //mail.To.Add("techlead@macare.in");

                mail.CC.Add("CS@macare.in");
                mail.CC.Add("operation@macare.in");
                //mail.CC.Add("accounts@macare.in");
                mail.CC.Add("techlead@macare.in");
                mail.CC.Add("internalauditinghead@macare.in");

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
                smtp.Send(mail);
            }

        }
        public void nabl_alert()
        {

            DataSet ds = objService.Check_ReminderDate_Alert();
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    MailMessage mail = new MailMessage();
                    System.Net.Mail.SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    //MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("operationhead@macare.in"));

                    mail.From = new MailAddress("MacareIT@macare.in");
                    mail.Subject = "NABL Accreditation Alert";
                    //MailMsg.Body = "Dear sir NABL Accreditation valid up to";
                    mail.Body = "Dear Sir,<br/><br/>" + "NABL Accreditation valid upto: " + ds.Tables[0].Rows[0]["end_date"].ToString();
                    mail.IsBodyHtml = true;
                    // Add a carbon copy recipient.

                    mail.To.Add("operationhead@macare.in");
                    mail.CC.Add("techlead@macare.in");

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
                    smtp.Send(mail);
                }
                else
                {
                    MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("techlead@macare.in"));

                    MailMsg.Subject = "NABL Accreditation Alert";
                    MailMsg.Body = "test";
                    // Add a carbon copy recipient.

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
            else
            {
                MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("techlead@macare.in"));

                MailMsg.Subject = "NABL Accreditation Alert";
                MailMsg.Body = "test";
                // Add a carbon copy recipient.

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
