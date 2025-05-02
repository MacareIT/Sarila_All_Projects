using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsService_ExpiryAlert_Vlpd
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer;
        private string timeString;
        public int getCallType;
        private static System.Threading.Timer _timer;
        ServiceReference1.WebService_ExpirySoapClient objService = new ServiceReference1.WebService_ExpirySoapClient();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.timer = new System.Timers.Timer((60 * 1000));  // 30000 milliseconds = 30 seconds // 60 * 1000 (1 minute) // 60 * 60 * 1000 (1 hour)
            this.timer.AutoReset = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            this.timer.Start();
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            DataTable dtVlpd = objService.Get_ExpiryMedicines_Valapad().Tables[0];
            MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("unitheadvalapad@macare.in"));
            //MailMessage MailMsg = new MailMessage(new MailAddress("MacareIT@macare.in"), new MailAddress("itcoordinator@macare.in"));
            if (dtVlpd.Rows.Count > 0)
            {
                dtVlpd.TableName = "ExpiringMedicines_Valapad";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(dtVlpd);

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
            DataTable dtNew = objService.Get_ExpiryMedicines_Valapad_New().Tables[0];
            if (dtNew.Rows.Count > 0)
            {
                dtNew.TableName = "ExpiringMedicineslist_New";
                using (XLWorkbook wb = new XLWorkbook())
                {
                    //Add the DataTable as Excel Worksheet.
                    wb.Worksheets.Add(dtNew);

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
 
            MailMsg.Subject = "Expiring Medicine List Valapad";
            MailMsg.Body = "Expiring Medicine List Alert Attachment";
            // Add a carbon copy recipient.

            MailMsg.CC.Add(new MailAddress("techlead@macare.in")); MailMsg.CC.Add(new MailAddress("operationhead@macare.in"));
            MailMsg.CC.Add(new MailAddress("purchase@macare.in")); MailMsg.CC.Add(new MailAddress("medicalsvalapad@macare.in"));
            MailMsg.CC.Add(new MailAddress("md@macare.in")); MailMsg.CC.Add(new MailAddress("cfo@macare.in")); MailMsg.CC.Add(new MailAddress("businesshead@macare.in"));
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
        protected override void OnStop()
        {
        }
    }
}
