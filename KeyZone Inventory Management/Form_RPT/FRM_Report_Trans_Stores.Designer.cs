namespace KeyZone_Inventory_Management.Form_RPT
{
    partial class FRM_Report_Trans_Stores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Report_Trans_Stores));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Store_Name = new System.Windows.Forms.TextBox();
            this.rd_AllStores = new System.Windows.Forms.RadioButton();
            this.rd_StoreNo = new System.Windows.Forms.RadioButton();
            this.btn_View_Store_No = new System.Windows.Forms.Button();
            this.textBox_Store_No = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTime_To = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTime_from = new System.Windows.Forms.DateTimePicker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Store_Name);
            this.groupBox1.Controls.Add(this.rd_AllStores);
            this.groupBox1.Controls.Add(this.rd_StoreNo);
            this.groupBox1.Controls.Add(this.btn_View_Store_No);
            this.groupBox1.Controls.Add(this.textBox_Store_No);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(506, 106);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "المستودع";
            // 
            // textBox_Store_Name
            // 
            this.textBox_Store_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Store_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Store_Name.Location = new System.Drawing.Point(12, 26);
            this.textBox_Store_Name.MaxLength = 9;
            this.textBox_Store_Name.Name = "textBox_Store_Name";
            this.textBox_Store_Name.ReadOnly = true;
            this.textBox_Store_Name.Size = new System.Drawing.Size(232, 20);
            this.textBox_Store_Name.TabIndex = 6;
            // 
            // rd_AllStores
            // 
            this.rd_AllStores.AutoSize = true;
            this.rd_AllStores.Checked = true;
            this.rd_AllStores.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_AllStores.ForeColor = System.Drawing.Color.Red;
            this.rd_AllStores.Location = new System.Drawing.Point(361, 73);
            this.rd_AllStores.Name = "rd_AllStores";
            this.rd_AllStores.Size = new System.Drawing.Size(131, 18);
            this.rd_AllStores.TabIndex = 5;
            this.rd_AllStores.TabStop = true;
            this.rd_AllStores.Text = "جميع المستودعات";
            this.rd_AllStores.UseVisualStyleBackColor = true;
            this.rd_AllStores.CheckedChanged += new System.EventHandler(this.rd_AllStores_CheckedChanged);
            // 
            // rd_StoreNo
            // 
            this.rd_StoreNo.AutoSize = true;
            this.rd_StoreNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_StoreNo.Location = new System.Drawing.Point(384, 26);
            this.rd_StoreNo.Name = "rd_StoreNo";
            this.rd_StoreNo.Size = new System.Drawing.Size(108, 18);
            this.rd_StoreNo.TabIndex = 4;
            this.rd_StoreNo.Text = "رقم المستودع";
            this.rd_StoreNo.UseVisualStyleBackColor = true;
            this.rd_StoreNo.CheckedChanged += new System.EventHandler(this.rd_StoreNo_CheckedChanged);
            // 
            // btn_View_Store_No
            // 
            this.btn_View_Store_No.Enabled = false;
            this.btn_View_Store_No.FlatAppearance.BorderSize = 0;
            this.btn_View_Store_No.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_View_Store_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_View_Store_No.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_View_Store_No.ForeColor = System.Drawing.Color.White;
            this.btn_View_Store_No.Image = global::KeyZone_Inventory_Management.Properties.Resources.view_file_32px;
            this.btn_View_Store_No.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View_Store_No.Location = new System.Drawing.Point(344, 16);
            this.btn_View_Store_No.Name = "btn_View_Store_No";
            this.btn_View_Store_No.Size = new System.Drawing.Size(39, 35);
            this.btn_View_Store_No.TabIndex = 3;
            this.btn_View_Store_No.UseVisualStyleBackColor = true;
            this.btn_View_Store_No.Click += new System.EventHandler(this.btn_View_Store_No_Click);
            // 
            // textBox_Store_No
            // 
            this.textBox_Store_No.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Store_No.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Store_No.Enabled = false;
            this.textBox_Store_No.Location = new System.Drawing.Point(250, 26);
            this.textBox_Store_No.MaxLength = 9;
            this.textBox_Store_No.Name = "textBox_Store_No";
            this.textBox_Store_No.Size = new System.Drawing.Size(90, 20);
            this.textBox_Store_No.TabIndex = 0;
            this.textBox_Store_No.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Store_No_KeyDown);
            this.textBox_Store_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Store_No_KeyPress);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Blue;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(151, 206);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(205, 31);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "موافق";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateTime_To);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTime_from);
            this.groupBox2.Location = new System.Drawing.Point(5, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(505, 73);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الفترة";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(157, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "إلى :";
            // 
            // dateTime_To
            // 
            this.dateTime_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_To.Location = new System.Drawing.Point(11, 30);
            this.dateTime_To.Name = "dateTime_To";
            this.dateTime_To.RightToLeftLayout = true;
            this.dateTime_To.Size = new System.Drawing.Size(140, 20);
            this.dateTime_To.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(395, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "خلال الفترة من :";
            // 
            // dateTime_from
            // 
            this.dateTime_from.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dateTime_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_from.Location = new System.Drawing.Point(249, 29);
            this.dateTime_from.Name = "dateTime_from";
            this.dateTime_from.RightToLeftLayout = true;
            this.dateTime_from.Size = new System.Drawing.Size(140, 20);
            this.dateTime_from.TabIndex = 0;
            // 
            // FRM_Report_Trans_Stores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 250);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_Report_Trans_Stores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف حركات المستودعات";
            this.Load += new System.EventHandler(this.FRM_Report_Trans_Stores_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rd_AllStores;
        private System.Windows.Forms.RadioButton rd_StoreNo;
        private System.Windows.Forms.Button btn_View_Store_No;
        public System.Windows.Forms.TextBox textBox_Store_No;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dateTime_To;
        public System.Windows.Forms.DateTimePicker dateTime_from;
        public System.Windows.Forms.TextBox textBox_Store_Name;
    }
}