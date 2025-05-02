
namespace Customer_Feedback
{
    partial class View_Complaints
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Complaint_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complaint_Against = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Complaint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.replay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Explanation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Update = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Complaint_Id,
            this.Customer,
            this.Mob,
            this.Complaint_Against,
            this.Email_Id,
            this.Complaint,
            this.DateTime,
            this.replay,
            this.DateTime2,
            this.Explanation});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1382, 519);
            this.dataGridView1.TabIndex = 0;
            // 
            // Complaint_Id
            // 
            this.Complaint_Id.DataPropertyName = "Complaint_Id";
            this.Complaint_Id.HeaderText = "Complaint_Id";
            this.Complaint_Id.MinimumWidth = 6;
            this.Complaint_Id.Name = "Complaint_Id";
            this.Complaint_Id.ReadOnly = true;
            this.Complaint_Id.Visible = false;
            this.Complaint_Id.Width = 125;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer_Name";
            this.Customer.HeaderText = "Customer";
            this.Customer.MinimumWidth = 6;
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            this.Customer.Width = 130;
            // 
            // Mob
            // 
            this.Mob.DataPropertyName = "Customer_Mob";
            this.Mob.HeaderText = "Mob";
            this.Mob.MinimumWidth = 6;
            this.Mob.Name = "Mob";
            this.Mob.ReadOnly = true;
            this.Mob.Width = 130;
            // 
            // Complaint_Against
            // 
            this.Complaint_Against.DataPropertyName = "Department";
            this.Complaint_Against.HeaderText = "Complaint_Against";
            this.Complaint_Against.MinimumWidth = 6;
            this.Complaint_Against.Name = "Complaint_Against";
            this.Complaint_Against.ReadOnly = true;
            this.Complaint_Against.Width = 130;
            // 
            // Email_Id
            // 
            this.Email_Id.DataPropertyName = "Email";
            this.Email_Id.HeaderText = "Email_Id";
            this.Email_Id.MinimumWidth = 6;
            this.Email_Id.Name = "Email_Id";
            this.Email_Id.ReadOnly = true;
            this.Email_Id.Visible = false;
            this.Email_Id.Width = 115;
            // 
            // Complaint
            // 
            this.Complaint.DataPropertyName = "Complaint";
            this.Complaint.HeaderText = "Complaint";
            this.Complaint.MinimumWidth = 6;
            this.Complaint.Name = "Complaint";
            this.Complaint.ReadOnly = true;
            this.Complaint.Width = 250;
            // 
            // DateTime
            // 
            this.DateTime.DataPropertyName = "Com_Date";
            this.DateTime.HeaderText = "Date&Time";
            this.DateTime.MinimumWidth = 6;
            this.DateTime.Name = "DateTime";
            this.DateTime.ReadOnly = true;
            this.DateTime.Width = 120;
            // 
            // replay
            // 
            this.replay.DataPropertyName = "reply";
            this.replay.HeaderText = "reply";
            this.replay.MinimumWidth = 6;
            this.replay.Name = "replay";
            this.replay.ReadOnly = true;
            this.replay.Visible = false;
            this.replay.Width = 125;
            // 
            // DateTime2
            // 
            this.DateTime2.DataPropertyName = "Rep_Date";
            this.DateTime2.HeaderText = "Date&Time";
            this.DateTime2.MinimumWidth = 6;
            this.DateTime2.Name = "DateTime2";
            this.DateTime2.ReadOnly = true;
            this.DateTime2.Visible = false;
            this.DateTime2.Width = 120;
            // 
            // Explanation
            // 
            this.Explanation.HeaderText = "Explanation";
            this.Explanation.MinimumWidth = 6;
            this.Explanation.Name = "Explanation";
            this.Explanation.Width = 700;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(34, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 46);
            this.button1.TabIndex = 19;
            this.button1.Text = "<<Send Mail";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 100);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1382, 519);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btn_Update);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 515);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1382, 104);
            this.panel3.TabIndex = 22;
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.Transparent;
            this.btn_Update.FlatAppearance.BorderColor = System.Drawing.Color.DimGray;
            this.btn_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Location = new System.Drawing.Point(432, 9);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(549, 50);
            this.btn_Update.TabIndex = 20;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // View_Complaints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Customer_Feedback.Properties.Resources.Feedback_Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1382, 619);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MV Boli", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "View_Complaints";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complaint_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mob;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complaint_Against;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Complaint;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn replay;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Explanation;
    }
}