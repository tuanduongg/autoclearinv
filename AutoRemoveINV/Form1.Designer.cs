namespace AutoRemoveINV
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonOpenWeb = new System.Windows.Forms.Button();
            this.radioBH = new System.Windows.Forms.RadioButton();
            this.radioMH = new System.Windows.Forms.RadioButton();
            this.radioSX = new System.Windows.Forms.RadioButton();
            this.radioBDHH = new System.Windows.Forms.RadioButton();
            this.tb_inv = new System.Windows.Forms.TextBox();
            this.grbox_typeINV = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grb_result = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lb_processing = new System.Windows.Forms.Label();
            this.grb_mode = new System.Windows.Forms.GroupBox();
            this.radio_product = new System.Windows.Forms.RadioButton();
            this.radio_dev = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_ready = new System.Windows.Forms.Label();
            this.btnReprocess = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_companyCode = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tb_ID = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tb_pw = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lb_total_inv = new System.Windows.Forms.Label();
            this.grbox_typeINV.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grb_result.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grb_mode.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenWeb
            // 
            this.buttonOpenWeb.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonOpenWeb.ForeColor = System.Drawing.Color.White;
            this.buttonOpenWeb.Location = new System.Drawing.Point(10, 278);
            this.buttonOpenWeb.Name = "buttonOpenWeb";
            this.buttonOpenWeb.Size = new System.Drawing.Size(137, 32);
            this.buttonOpenWeb.TabIndex = 0;
            this.buttonOpenWeb.Text = "Chạy";
            this.buttonOpenWeb.UseVisualStyleBackColor = false;
            this.buttonOpenWeb.Click += new System.EventHandler(this.buttonOpenWeb_Click);
            // 
            // radioBH
            // 
            this.radioBH.AutoSize = true;
            this.radioBH.Location = new System.Drawing.Point(6, 19);
            this.radioBH.Name = "radioBH";
            this.radioBH.Size = new System.Drawing.Size(40, 17);
            this.radioBH.TabIndex = 2;
            this.radioBH.TabStop = true;
            this.radioBH.Text = "SO";
            this.radioBH.UseVisualStyleBackColor = true;
            // 
            // radioMH
            // 
            this.radioMH.AutoSize = true;
            this.radioMH.Location = new System.Drawing.Point(6, 42);
            this.radioMH.Name = "radioMH";
            this.radioMH.Size = new System.Drawing.Size(35, 17);
            this.radioMH.TabIndex = 3;
            this.radioMH.TabStop = true;
            this.radioMH.Text = "PI";
            this.radioMH.UseVisualStyleBackColor = true;
            // 
            // radioSX
            // 
            this.radioSX.AutoSize = true;
            this.radioSX.Location = new System.Drawing.Point(6, 65);
            this.radioSX.Name = "radioSX";
            this.radioSX.Size = new System.Drawing.Size(43, 17);
            this.radioSX.TabIndex = 4;
            this.radioSX.TabStop = true;
            this.radioSX.Text = "WP";
            this.radioSX.UseVisualStyleBackColor = true;
            // 
            // radioBDHH
            // 
            this.radioBDHH.AutoSize = true;
            this.radioBDHH.Location = new System.Drawing.Point(6, 88);
            this.radioBDHH.Name = "radioBDHH";
            this.radioBDHH.Size = new System.Drawing.Size(43, 17);
            this.radioBDHH.TabIndex = 5;
            this.radioBDHH.TabStop = true;
            this.radioBDHH.Text = "INV";
            this.radioBDHH.UseVisualStyleBackColor = true;
            this.radioBDHH.CheckedChanged += new System.EventHandler(this.radioBDHH_CheckedChanged);
            // 
            // tb_inv
            // 
            this.tb_inv.Location = new System.Drawing.Point(6, 18);
            this.tb_inv.Multiline = true;
            this.tb_inv.Name = "tb_inv";
            this.tb_inv.Size = new System.Drawing.Size(263, 81);
            this.tb_inv.TabIndex = 6;
            this.tb_inv.TextChanged += new System.EventHandler(this.tb_inv_TextChanged);
            // 
            // grbox_typeINV
            // 
            this.grbox_typeINV.Controls.Add(this.label4);
            this.grbox_typeINV.Controls.Add(this.label3);
            this.grbox_typeINV.Controls.Add(this.label2);
            this.grbox_typeINV.Controls.Add(this.label1);
            this.grbox_typeINV.Controls.Add(this.radioBH);
            this.grbox_typeINV.Controls.Add(this.radioMH);
            this.grbox_typeINV.Controls.Add(this.radioBDHH);
            this.grbox_typeINV.Controls.Add(this.radioSX);
            this.grbox_typeINV.Location = new System.Drawing.Point(11, 74);
            this.grbox_typeINV.Name = "grbox_typeINV";
            this.grbox_typeINV.Size = new System.Drawing.Size(217, 126);
            this.grbox_typeINV.TabIndex = 7;
            this.grbox_typeINV.TabStop = false;
            this.grbox_typeINV.Text = "Loại INV";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Biến động hàng hóa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sản xuất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mua hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bán hàng";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_total_inv);
            this.groupBox1.Controls.Add(this.tb_inv);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(238, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 126);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập danh sách INV";
            // 
            // grb_result
            // 
            this.grb_result.Controls.Add(this.dataGridView1);
            this.grb_result.Location = new System.Drawing.Point(9, 330);
            this.grb_result.Name = "grb_result";
            this.grb_result.Size = new System.Drawing.Size(501, 145);
            this.grb_result.TabIndex = 11;
            this.grb_result.TabStop = false;
            this.grb_result.Text = "Kết Quả";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(495, 126);
            this.dataGridView1.TabIndex = 12;
            // 
            // lb_processing
            // 
            this.lb_processing.AutoSize = true;
            this.lb_processing.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_processing.ForeColor = System.Drawing.Color.Green;
            this.lb_processing.Location = new System.Drawing.Point(329, 282);
            this.lb_processing.Name = "lb_processing";
            this.lb_processing.Size = new System.Drawing.Size(82, 17);
            this.lb_processing.TabIndex = 13;
            this.lb_processing.Text = "Đang xử lý..";
            this.lb_processing.Visible = false;
            // 
            // grb_mode
            // 
            this.grb_mode.Controls.Add(this.radio_product);
            this.grb_mode.Controls.Add(this.radio_dev);
            this.grb_mode.Location = new System.Drawing.Point(9, 226);
            this.grb_mode.Name = "grb_mode";
            this.grb_mode.Size = new System.Drawing.Size(504, 46);
            this.grb_mode.TabIndex = 15;
            this.grb_mode.TabStop = false;
            this.grb_mode.Text = "Chế độ";
            // 
            // radio_product
            // 
            this.radio_product.AutoSize = true;
            this.radio_product.Location = new System.Drawing.Point(110, 17);
            this.radio_product.Name = "radio_product";
            this.radio_product.Size = new System.Drawing.Size(62, 17);
            this.radio_product.TabIndex = 1;
            this.radio_product.Text = "Thực tế";
            this.radio_product.UseVisualStyleBackColor = true;
            // 
            // radio_dev
            // 
            this.radio_dev.AutoSize = true;
            this.radio_dev.Checked = true;
            this.radio_dev.Location = new System.Drawing.Point(6, 17);
            this.radio_dev.Name = "radio_dev";
            this.radio_dev.Size = new System.Drawing.Size(81, 17);
            this.radio_dev.TabIndex = 0;
            this.radio_dev.TabStop = true;
            this.radio_dev.Text = "Thử nghiệm";
            this.radio_dev.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(329, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Đang xử lý..";
            this.label6.Visible = false;
            // 
            // lb_ready
            // 
            this.lb_ready.AutoSize = true;
            this.lb_ready.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ready.ForeColor = System.Drawing.Color.SteelBlue;
            this.lb_ready.Location = new System.Drawing.Point(329, 286);
            this.lb_ready.Name = "lb_ready";
            this.lb_ready.Size = new System.Drawing.Size(68, 17);
            this.lb_ready.TabIndex = 14;
            this.lb_ready.Text = "Sẵn sàng";
            // 
            // btnReprocess
            // 
            this.btnReprocess.BackColor = System.Drawing.Color.Silver;
            this.btnReprocess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReprocess.Location = new System.Drawing.Point(164, 278);
            this.btnReprocess.Name = "btnReprocess";
            this.btnReprocess.Size = new System.Drawing.Size(75, 32);
            this.btnReprocess.TabIndex = 1;
            this.btnReprocess.Text = "Chạy lại";
            this.btnReprocess.UseVisualStyleBackColor = false;
            this.btnReprocess.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_companyCode);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 41);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mã Công Ty";
            // 
            // tb_companyCode
            // 
            this.tb_companyCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_companyCode.Location = new System.Drawing.Point(3, 16);
            this.tb_companyCode.Name = "tb_companyCode";
            this.tb_companyCode.Size = new System.Drawing.Size(146, 20);
            this.tb_companyCode.TabIndex = 0;
            this.tb_companyCode.Text = "168426";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tb_ID);
            this.groupBox3.Location = new System.Drawing.Point(183, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 41);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tài Khoản";
            // 
            // tb_ID
            // 
            this.tb_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_ID.Location = new System.Drawing.Point(3, 16);
            this.tb_ID.Name = "tb_ID";
            this.tb_ID.Size = new System.Drawing.Size(133, 20);
            this.tb_ID.TabIndex = 0;
            this.tb_ID.Text = "TUANIT";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tb_pw);
            this.groupBox4.Location = new System.Drawing.Point(347, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(172, 41);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Mật Khẩu";
            // 
            // tb_pw
            // 
            this.tb_pw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_pw.Location = new System.Drawing.Point(3, 16);
            this.tb_pw.Name = "tb_pw";
            this.tb_pw.Size = new System.Drawing.Size(166, 20);
            this.tb_pw.TabIndex = 0;
            this.tb_pw.Text = "Toilatuan201@";
            this.tb_pw.UseSystemPasswordChar = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Tổng :";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // lb_total_inv
            // 
            this.lb_total_inv.AutoSize = true;
            this.lb_total_inv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total_inv.Location = new System.Drawing.Point(40, 102);
            this.lb_total_inv.Name = "lb_total_inv";
            this.lb_total_inv.Size = new System.Drawing.Size(14, 13);
            this.lb_total_inv.TabIndex = 20;
            this.lb_total_inv.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 492);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grb_mode);
            this.Controls.Add(this.lb_ready);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lb_processing);
            this.Controls.Add(this.grb_result);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbox_typeINV);
            this.Controls.Add(this.btnReprocess);
            this.Controls.Add(this.buttonOpenWeb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUTO CLEAR INV";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbox_typeINV.ResumeLayout(false);
            this.grbox_typeINV.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grb_result.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grb_mode.ResumeLayout(false);
            this.grb_mode.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenWeb;
        private System.Windows.Forms.RadioButton radioBH;
        private System.Windows.Forms.RadioButton radioMH;
        private System.Windows.Forms.RadioButton radioSX;
        private System.Windows.Forms.RadioButton radioBDHH;
        private System.Windows.Forms.TextBox tb_inv;
        private System.Windows.Forms.GroupBox grbox_typeINV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grb_result;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lb_processing;
        private System.Windows.Forms.GroupBox grb_mode;
        private System.Windows.Forms.RadioButton radio_product;
        private System.Windows.Forms.RadioButton radio_dev;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_ready;
        private System.Windows.Forms.Button btnReprocess;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_companyCode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tb_ID;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tb_pw;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_total_inv;
    }
}

