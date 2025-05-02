using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Feedback
{
    public partial class Form1 : Form
    {
        ServiceMacare.WebService_CustComplaintSoapClient objService = new ServiceMacare.WebService_CustComplaintSoapClient();
        public Form1()
        {
            InitializeComponent();
            Load_EMail();
        }
        public void Load_EMail()
        {
            DataTable dtMail = new DataTable();
            dtMail.Columns.Add("MailId");
            dtMail.Columns.Add("Department");
            dtMail.Rows.Add("Sarilakarthik@gmail.com", "Test");
            dtMail.Rows.Add("medicalsvalapad@macare.in", "PharmacyValappad");
            dtMail.Rows.Add("unitheadvalapad@macare.in", "LabValappad");
            cmbDept.ValueMember = "MailId";
            cmbDept.DisplayMember = "Department";
            cmbDept.DataSource = dtMail;
        }
        public int Validate_()
        {
            int flag = 0;
            if (txtName.Text == "")
            {
               L1.Visible = true; flag = 1;
            }
            else L1.Visible = false;
            if (txtMob.Text == "")
            {
                L2.Visible = true; flag = 1;
            }
            else L2.Visible = false;
            if (txtComplaint.Text == "")
            {
                L4.Visible = true; flag = 1;
            }
            else L4.Visible = false;
          

            Regex rx = new Regex(@"^([0]|\+91)?[789]\d{9}$");
            if (rx.IsMatch(txtMob.Text))
            {

            }
            else
            {
                MessageBox.Show("Not Valid phone number!");
                L2.Visible = true; flag = 1;
            }

            return flag;

        }
        public void clear()
        {
            txtComplaint.Text = "";
            txtMob.Text = "";
            txtName.Text = "";
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage obj = new MailMessage();
                SmtpClient serverobj = new SmtpClient();
                serverobj.Credentials = new NetworkCredential("programmer2macare@gmail.com", "Sarila@1");
                serverobj.Port = 587;
                serverobj.Host = "smtp.gmail.com";
                serverobj.EnableSsl = true;
                obj = new MailMessage();
                obj.From = new MailAddress("programmer2macare@gmail.com", "Sarila", System.Text.Encoding.UTF8);
                obj.To.Add(cmbDept.SelectedValue.ToString());
                obj.CC.Add(new MailAddress("vishnuvb2252@gmail.com"));
                obj.CC.Add(new MailAddress("programmer2@macare.in"));
                obj.Priority = MailPriority.High;
                obj.Subject = "CustomerComplaint";
                string msg = "CustomerName: " + txtName.Text+"  ContactNo: "+txtMob.Text+"\n Against: "+cmbDept.Text+"\n\n\n"+txtComplaint.Text;
                obj.Body = msg;
                serverobj.Send(obj);
                MessageBox.Show("Your message has been sent.");
               

                string result = objService.Customer_Complaint_insert(txtName.Text, txtMob.Text, cmbDept.Text, cmbDept.SelectedValue.ToString(), txtComplaint.Text, "Not replied");
                MessageBox.Show(result);
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View_Complaints obj = new View_Complaints();
            this.Hide();
            obj.ShowDialog();
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtMob.Text = "";
            txtComplaint.Text = "";
            cmbDept.SelectedIndex = 0;
        }
    }
}
