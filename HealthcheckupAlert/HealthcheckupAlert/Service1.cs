using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Net;

namespace HealthcheckupAlert
{

    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer timer;
        private string timeString;
        public int getCallType;
        private static System.Threading.Timer _timer;
        ServiceReference_HealthCheckupalert.Service_HealthCheckupReminderSoapClient objservice = new ServiceReference_HealthCheckupalert.Service_HealthCheckupReminderSoapClient();


        public Service1()
        {
            InitializeComponent();
        }


        protected override void OnStart(string[] args)
        {
            this.timer = new System.Timers.Timer(60*60*1000*24);  // 30000 milliseconds = 30 seconds // 60 * 1000 (1 minute) // 60 * 60 * 1000 (1 hour)
            this.timer.AutoReset = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            this.timer.Start();
        }


        private void sendSMS(int i)
        {
            DataTable dt = new DataTable();
            dt = objservice.GetTestdate().Tables[0];
            //string phnnumber = "7025873154";
            string phnnumber = dt.Rows[i]["PATIENTPHNUM"].ToString();
            string custname = dt.Rows[i]["PATIENTNAME"].ToString();
            string branch_name = dt.Rows[i]["BRANCHNAME"].ToString();
            string branchphno = dt.Rows[i]["BRANCHPHNUM"].ToString();
            string strUrl = @"https://api-alerts.kaleyra.com/v4/?api_key=Abd88b2ea9b53fb33eaadddf377595748&method=sms&message= Dear " + custname + ", Your Health Check Up is due, now we are having attractive discounts on health check up's. Please contact " + branch_name + "," + branchphno + " MANAPPURAM HEALTHCARE LTD&to=" + phnnumber + "&sender=MHCALT";
            // Create a request object  
            WebRequest request = HttpWebRequest.Create(strUrl);
            // Get the response back  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();


            //DataTable dt = new DataTable();
            //dt = objservice.GetTestdate().Tables[0];
            //int rowcount = dt.Rows.Count;
            //int i;
            //for (i = 0; i < rowcount; i++)
            //{
            //    string phnnumber = "7025873154";
            //    //string phnumber = dt.Rows[i]["PATIENTPHNUM"].ToString();
            //    string custname = dt.Rows[i]["PATIENTNAME"].ToString();
            //    string branch_name = dt.Rows[i]["BRANCHNAME"].ToString();
            //    string branchphno = dt.Rows[i]["BRANCHPHNUM"].ToString();
            //    //string checkupname = dt.Rows[i]["CHECKUPNAME"].ToString();

            //    //string strUrl = @"https://api-alerts.kaleyra.com/v4/?api_key=Abd88b2ea9b53fb33eaadddf377595748&method=sms&message=<%23>Hi SRUTHY, your result is ready, please click to download your lab result https://gen.mactech.net.in/MACARE/MobileAppApi/TestResults/Lab/RtpcrTest/D68B0F37F56425E8E054005056972EA0 MANAPPURAM HEALTHCARE LTD&to=7025873154&sender=MHCALT";
            //    //string strUrl = @"https://api-alerts.kaleyra.com/v4/?api_key=Abd88b2ea9b53fb33eaadddf377595748&method=sms&message= Hi SRUTHY, your result is ready, please click to download your lab result https://gen.mactech.net.in/MACARE/MobileAppApi/TestResults/Lab/RtpcrTest/result MANAPPURAM HEALTHCARE LTD&to=7025873154&sender=MHCALT";


            //    string strUrl = @"https://api-alerts.kaleyra.com/v4/?api_key=Abd88b2ea9b53fb33eaadddf377595748&method=sms&message= Dear " + custname + ", Your Health Check Up is due, now we are having attractive discounts on health check up's. Please contact " + branch_name + "," + branchphno + " MANAPPURAM HEALTHCARE LTD&to=" + phnnumber + "&sender=MHCALT";

            //    // Create a request object  
            //    WebRequest request = HttpWebRequest.Create(strUrl);
            //    // Get the response back  
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    Stream s = (Stream)response.GetResponseStream();
            //    StreamReader readStream = new StreamReader(s);
            //    string dataString = readStream.ReadToEnd();
            //    response.Close();
            //    s.Close();
            //    readStream.Close();
            //}
        }
        protected override void OnStop()
        {
            this.timer.Stop();
            this.timer = null;
            this.timer.AutoReset = false;
            this.timer.Enabled = false;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = objservice.GetTestdate().Tables[0];
            int rowcount = dt.Rows.Count;
            int i;
            for (i = 0; i < rowcount; i++)
            {
                sendSMS(i); // my separate static method for do work
            }
                
        }
    }        
}
