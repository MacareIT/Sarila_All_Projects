using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceExpiryKtr
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
           // this.timer = new System.Timers.Timer((24 * 60 * 60 * 1000));  // 30000 milliseconds = 30 seconds // 60 * 1000 (1 minute) // 60 * 60 * 1000 (1 hour)// 24*60*60*1000 (1 Day)
            this.timer = new System.Timers.Timer((10 * 60 * 1000));                                                              //this.timer = new System.Timers.Timer((10 * 60 * 1000));
            this.timer.AutoReset = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);
            this.timer.Start();
        }
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            
            objService.Get_ExpiryMedicines_Kattoor();

        }
        protected override void OnStop()
        {
        }
    }
}
