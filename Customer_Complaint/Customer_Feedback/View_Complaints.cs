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
    public partial class View_Complaints : Form
    {
        ServiceMacare.WebService_CustComplaintSoapClient objService = new ServiceMacare.WebService_CustComplaintSoapClient();
        public View_Complaints()
        {
            InitializeComponent();
            DataSet ds = objService.All_ComplaintSelect();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string result = "";
            for(int i=0;i<dataGridView1.Rows.Count;i++)
            {
                if(dataGridView1.Rows[i].Cells["Explanation"].Value!=null)
                     result = objService.Customer_Complaint_replay(Convert.ToInt32(dataGridView1.Rows[i].Cells["Complaint_Id"].Value.ToString()),dataGridView1.Rows[i].Cells["Explanation"].Value.ToString()); 
            }
            DataSet ds = objService.All_ComplaintSelect();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            this.Hide();
            obj.ShowDialog();
            this.Close();
        }
    }
}
