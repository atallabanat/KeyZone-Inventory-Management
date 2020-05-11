namespace KeyZone_Inventory_Management.Defenition
{
    partial class Customers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customers));
            this.groupBox1_Basic_Information = new System.Windows.Forms.GroupBox();
            this.dateTime_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Customers_Name = new System.Windows.Forms.TextBox();
            this.textBox_Customers_No = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Cost_Sales = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Customers_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Customers_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Start_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2_Additonal_Information = new System.Windows.Forms.GroupBox();
            this.textBox_Phone = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.textBox_Fax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_search = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.groupBox1_Basic_Information.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2_Additonal_Information.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1_Basic_Information
            // 
            this.groupBox1_Basic_Information.BackColor = System.Drawing.Color.White;
            this.groupBox1_Basic_Information.Controls.Add(this.dateTime_Start_Date);
            this.groupBox1_Basic_Information.Controls.Add(this.label1);
            this.groupBox1_Basic_Information.Controls.Add(this.textBox_Customers_Name);
            this.groupBox1_Basic_Information.Controls.Add(this.textBox_Customers_No);
            this.groupBox1_Basic_Information.Controls.Add(this.label6);
            this.groupBox1_Basic_Information.Controls.Add(this.label_Cost_Sales);
            this.groupBox1_Basic_Information.ForeColor = System.Drawing.Color.Red;
            this.groupBox1_Basic_Information.Location = new System.Drawing.Point(227, 12);
            this.groupBox1_Basic_Information.Name = "groupBox1_Basic_Information";
            this.groupBox1_Basic_Information.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1_Basic_Information.Size = new System.Drawing.Size(738, 62);
            this.groupBox1_Basic_Information.TabIndex = 5;
            this.groupBox1_Basic_Information.TabStop = false;
            this.groupBox1_Basic_Information.Text = "معلومات أساسية";
            // 
            // dateTime_Start_Date
            // 
            this.dateTime_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_Start_Date.Location = new System.Drawing.Point(16, 22);
            this.dateTime_Start_Date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTime_Start_Date.Name = "dateTime_Start_Date";
            this.dateTime_Start_Date.RightToLeftLayout = true;
            this.dateTime_Start_Date.Size = new System.Drawing.Size(121, 22);
            this.dateTime_Start_Date.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(143, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 14);
            this.label1.TabIndex = 118;
            this.label1.Text = "تاريخ بداية التعامل :";
            // 
            // textBox_Customers_Name
            // 
            this.textBox_Customers_Name.Location = new System.Drawing.Point(285, 22);
            this.textBox_Customers_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Customers_Name.MaxLength = 50;
            this.textBox_Customers_Name.Name = "textBox_Customers_Name";
            this.textBox_Customers_Name.Size = new System.Drawing.Size(121, 22);
            this.textBox_Customers_Name.TabIndex = 1;
            // 
            // textBox_Customers_No
            // 
            this.textBox_Customers_No.Enabled = false;
            this.textBox_Customers_No.Location = new System.Drawing.Point(515, 22);
            this.textBox_Customers_No.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Customers_No.MaxLength = 9;
            this.textBox_Customers_No.Name = "textBox_Customers_No";
            this.textBox_Customers_No.Size = new System.Drawing.Size(121, 22);
            this.textBox_Customers_No.TabIndex = 0;
            this.textBox_Customers_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Customers_No_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(412, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 14);
            this.label6.TabIndex = 112;
            this.label6.Text = "اسم العميل :";
            // 
            // label_Cost_Sales
            // 
            this.label_Cost_Sales.AutoSize = true;
            this.label_Cost_Sales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label_Cost_Sales.ForeColor = System.Drawing.Color.Red;
            this.label_Cost_Sales.Location = new System.Drawing.Point(642, 25);
            this.label_Cost_Sales.Name = "label_Cost_Sales";
            this.label_Cost_Sales.Size = new System.Drawing.Size(79, 14);
            this.label_Cost_Sales.TabIndex = 111;
            this.label_Cost_Sales.Text = "رقم العميل :";
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.Orange;
            this.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(198, 21);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(121, 31);
            this.btn_edit.TabIndex = 1;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Red;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(22, 21);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(121, 31);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Blue;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(366, 21);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(121, 31);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "اضافة";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Customers_No,
            this.Column_Customers_Name,
            this.Column_Start_Date,
            this.Column_Phone,
            this.Column_Address,
            this.Column_Fax,
            this.Column_Email});
            this.dataGridView1.Location = new System.Drawing.Point(4, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1198, 179);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // Column_Customers_No
            // 
            this.Column_Customers_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Customers_No.DataPropertyName = "Customers_No";
            this.Column_Customers_No.FillWeight = 20.64248F;
            this.Column_Customers_No.HeaderText = "رقم العميل";
            this.Column_Customers_No.Name = "Column_Customers_No";
            this.Column_Customers_No.ReadOnly = true;
            this.Column_Customers_No.Width = 75;
            // 
            // Column_Customers_Name
            // 
            this.Column_Customers_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Customers_Name.DataPropertyName = "Customers_Name";
            this.Column_Customers_Name.FillWeight = 57.89811F;
            this.Column_Customers_Name.HeaderText = "اسم العميل";
            this.Column_Customers_Name.Name = "Column_Customers_Name";
            this.Column_Customers_Name.ReadOnly = true;
            this.Column_Customers_Name.Width = 250;
            // 
            // Column_Start_Date
            // 
            this.Column_Start_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Start_Date.DataPropertyName = "Start_Date";
            this.Column_Start_Date.FillWeight = 19.38704F;
            this.Column_Start_Date.HeaderText = "تاريخ بداية التعامل";
            this.Column_Start_Date.Name = "Column_Start_Date";
            this.Column_Start_Date.ReadOnly = true;
            this.Column_Start_Date.Width = 200;
            // 
            // Column_Phone
            // 
            this.Column_Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Phone.DataPropertyName = "Phone";
            this.Column_Phone.FillWeight = 19.38704F;
            this.Column_Phone.HeaderText = "رقم الهاتف";
            this.Column_Phone.Name = "Column_Phone";
            this.Column_Phone.ReadOnly = true;
            this.Column_Phone.Width = 150;
            // 
            // Column_Address
            // 
            this.Column_Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Address.DataPropertyName = "Address";
            this.Column_Address.FillWeight = 19.38704F;
            this.Column_Address.HeaderText = "العنوان";
            this.Column_Address.Name = "Column_Address";
            this.Column_Address.ReadOnly = true;
            this.Column_Address.Width = 250;
            // 
            // Column_Fax
            // 
            this.Column_Fax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Fax.DataPropertyName = "Fax";
            this.Column_Fax.FillWeight = 160.9162F;
            this.Column_Fax.HeaderText = "الفاكس";
            this.Column_Fax.Name = "Column_Fax";
            this.Column_Fax.ReadOnly = true;
            this.Column_Fax.Width = 150;
            // 
            // Column_Email
            // 
            this.Column_Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Email.DataPropertyName = "Email";
            this.Column_Email.FillWeight = 19.38704F;
            this.Column_Email.HeaderText = "البريد الالكتروني";
            this.Column_Email.Name = "Column_Email";
            this.Column_Email.ReadOnly = true;
            this.Column_Email.Width = 110;
            // 
            // groupBox2_Additonal_Information
            // 
            this.groupBox2_Additonal_Information.BackColor = System.Drawing.Color.White;
            this.groupBox2_Additonal_Information.Controls.Add(this.textBox_Phone);
            this.groupBox2_Additonal_Information.Controls.Add(this.textBox_Email);
            this.groupBox2_Additonal_Information.Controls.Add(this.textBox_Address);
            this.groupBox2_Additonal_Information.Controls.Add(this.textBox_Fax);
            this.groupBox2_Additonal_Information.Controls.Add(this.label5);
            this.groupBox2_Additonal_Information.Controls.Add(this.label4);
            this.groupBox2_Additonal_Information.Controls.Add(this.label3);
            this.groupBox2_Additonal_Information.Controls.Add(this.label2);
            this.groupBox2_Additonal_Information.Location = new System.Drawing.Point(227, 76);
            this.groupBox2_Additonal_Information.Name = "groupBox2_Additonal_Information";
            this.groupBox2_Additonal_Information.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2_Additonal_Information.Size = new System.Drawing.Size(738, 108);
            this.groupBox2_Additonal_Information.TabIndex = 124;
            this.groupBox2_Additonal_Information.TabStop = false;
            this.groupBox2_Additonal_Information.Text = "معلومات اضافية";
            // 
            // textBox_Phone
            // 
            this.textBox_Phone.Location = new System.Drawing.Point(422, 28);
            this.textBox_Phone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Phone.MaxLength = 15;
            this.textBox_Phone.Name = "textBox_Phone";
            this.textBox_Phone.Size = new System.Drawing.Size(121, 22);
            this.textBox_Phone.TabIndex = 0;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(16, 70);
            this.textBox_Email.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Email.MaxLength = 50;
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(256, 22);
            this.textBox_Email.TabIndex = 3;
            // 
            // textBox_Address
            // 
            this.textBox_Address.Location = new System.Drawing.Point(16, 28);
            this.textBox_Address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Address.MaxLength = 50;
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(256, 22);
            this.textBox_Address.TabIndex = 1;
            // 
            // textBox_Fax
            // 
            this.textBox_Fax.Location = new System.Drawing.Point(422, 70);
            this.textBox_Fax.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Fax.MaxLength = 50;
            this.textBox_Fax.Name = "textBox_Fax";
            this.textBox_Fax.Size = new System.Drawing.Size(121, 22);
            this.textBox_Fax.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(287, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 14);
            this.label5.TabIndex = 131;
            this.label5.Text = "البريد الالكتروني :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(564, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 14);
            this.label4.TabIndex = 130;
            this.label4.Text = "الفاكس :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(291, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 129;
            this.label3.Text = "العنوان :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(549, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 128;
            this.label2.Text = "رقم الهاتف :";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btn_add);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_edit);
            this.groupBox1.Location = new System.Drawing.Point(331, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(525, 65);
            this.groupBox1.TabIndex = 125;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الأوامر";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.textBox_search);
            this.groupBox2.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox2.Location = new System.Drawing.Point(7, 256);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1192, 52);
            this.groupBox2.TabIndex = 126;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "بحث  ( اسم العميل ، رقم الهاتف ، العنوان  )";
            // 
            // textBox_search
            // 
            this.textBox_search.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_search.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.textBox_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBox_search.HintForeColor = System.Drawing.Color.Empty;
            this.textBox_search.HintText = "";
            this.textBox_search.isPassword = false;
            this.textBox_search.LineFocusedColor = System.Drawing.Color.Crimson;
            this.textBox_search.LineIdleColor = System.Drawing.Color.SeaGreen;
            this.textBox_search.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.textBox_search.LineThickness = 3;
            this.textBox_search.Location = new System.Drawing.Point(542, 14);
            this.textBox_search.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(641, 33);
            this.textBox_search.TabIndex = 0;
            this.textBox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox_search.OnValueChanged += new System.EventHandler(this.textBox_search_OnValueChanged);
            // 
            // Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1204, 499);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2_Additonal_Information);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1_Basic_Information);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Customers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعريف عميل";
            this.Load += new System.EventHandler(this.Customers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Customers_KeyDown);
            this.groupBox1_Basic_Information.ResumeLayout(false);
            this.groupBox1_Basic_Information.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2_Additonal_Information.ResumeLayout(false);
            this.groupBox2_Additonal_Information.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1_Basic_Information;
        private System.Windows.Forms.TextBox textBox_Customers_Name;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox textBox_Customers_No;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Cost_Sales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTime_Start_Date;
        private System.Windows.Forms.GroupBox groupBox2_Additonal_Information;
        private System.Windows.Forms.TextBox textBox_Phone;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.TextBox textBox_Fax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Customers_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Customers_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Start_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Email;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_search;
    }
}