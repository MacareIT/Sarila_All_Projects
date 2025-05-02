using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Feedback
{
    public partial class Login : Form
    {
        ServiceMacare.WebService_CustComplaintSoapClient objService = new ServiceMacare.WebService_CustComplaintSoapClient();
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            DataSet dsLogin = objService.Login(txtUname.Text, txtPswd.Text);
            if (dsLogin.Tables[0].Rows.Count > 0)
            {
                //................After Login, Login form closed and home page open....................//
                Form1 obj = new Form1();
                this.Hide();
                obj.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Please Enter correct Username and Password");
        }

        private void txtPswd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(13)))
            {
                btn_Login_Click(sender, e);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            txtUname.Text = "";
            txtPswd.Text = "";
        }
    }
}
