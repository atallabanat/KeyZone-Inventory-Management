namespace KeyZone_Inventory_Management.Distributor
{
    partial class Distributor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Distributor));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Distributor_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_ID_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Date_Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Car_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTime_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.textBox_Address = new System.Windows.Forms.TextBox();
            this.textBox_Phone2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Phone1 = new System.Windows.Forms.TextBox();
            this.textBox_Car_Type = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ID_Number = new System.Windows.Forms.TextBox();
            this.label_Cost_Sales = new System.Windows.Forms.Label();
            this.comboBox_Rank = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.textBox_Distributor_Number = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1_Basic_Information = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_search = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1_Basic_Information.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 50;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Distributor_Number,
            this.Column_Name,
            this.Column_Rank,
            this.Column_ID_Number,
            this.Column_Phone1,
            this.Column_Phone2,
            this.Column_Address,
            this.Column_Date_Time,
            this.Column_Car_Type});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.GridColor = System.Drawing.Color.SteelBlue;
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dataGridView1.Location = new System.Drawing.Point(0, 411);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1212, 204);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // Column_Distributor_Number
            // 
            this.Column_Distributor_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Distributor_Number.DataPropertyName = "Distributor_Number";
            this.Column_Distributor_Number.HeaderText = "رقم المندوب";
            this.Column_Distributor_Number.Name = "Column_Distributor_Number";
            this.Column_Distributor_Number.ReadOnly = true;
            this.Column_Distributor_Number.Width = 75;
            // 
            // Column_Name
            // 
            this.Column_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Name.DataPropertyName = "Name";
            this.Column_Name.HeaderText = "اسم المندوب";
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            this.Column_Name.Width = 250;
            // 
            // Column_Rank
            // 
            this.Column_Rank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Rank.DataPropertyName = "Rank";
            this.Column_Rank.HeaderText = "رتبة المندوب";
            this.Column_Rank.Name = "Column_Rank";
            this.Column_Rank.ReadOnly = true;
            // 
            // Column_ID_Number
            // 
            this.Column_ID_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_ID_Number.DataPropertyName = "ID_Number";
            this.Column_ID_Number.HeaderText = "الرقم الوطني";
            this.Column_ID_Number.Name = "Column_ID_Number";
            this.Column_ID_Number.ReadOnly = true;
            this.Column_ID_Number.Width = 130;
            // 
            // Column_Phone1
            // 
            this.Column_Phone1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Phone1.DataPropertyName = "Phone1";
            this.Column_Phone1.HeaderText = "رقم الهاتف 1";
            this.Column_Phone1.Name = "Column_Phone1";
            this.Column_Phone1.ReadOnly = true;
            this.Column_Phone1.Width = 130;
            // 
            // Column_Phone2
            // 
            this.Column_Phone2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Phone2.DataPropertyName = "Phone2";
            this.Column_Phone2.HeaderText = "رقم الهاتف 2";
            this.Column_Phone2.Name = "Column_Phone2";
            this.Column_Phone2.ReadOnly = true;
            this.Column_Phone2.Width = 130;
            // 
            // Column_Address
            // 
            this.Column_Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Address.DataPropertyName = "Address";
            this.Column_Address.HeaderText = "عنوان المندوب";
            this.Column_Address.Name = "Column_Address";
            this.Column_Address.ReadOnly = true;
            this.Column_Address.Width = 250;
            // 
            // Column_Date_Time
            // 
            this.Column_Date_Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Date_Time.DataPropertyName = "Start_Date";
            this.Column_Date_Time.HeaderText = "تاريخ التعين";
            this.Column_Date_Time.Name = "Column_Date_Time";
            this.Column_Date_Time.ReadOnly = true;
            this.Column_Date_Time.Width = 200;
            // 
            // Column_Car_Type
            // 
            this.Column_Car_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Car_Type.DataPropertyName = "Car_Type";
            this.Column_Car_Type.HeaderText = "نوع السيارة المستلمة";
            this.Column_Car_Type.Name = "Column_Car_Type";
            this.Column_Car_Type.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dateTime_Start_Date);
            this.groupBox1.Controls.Add(this.textBox_Address);
            this.groupBox1.Controls.Add(this.textBox_Phone2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBox_Phone1);
            this.groupBox1.Controls.Add(this.textBox_Car_Type);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_ID_Number);
            this.groupBox1.Controls.Add(this.label_Cost_Sales);
            this.groupBox1.Location = new System.Drawing.Point(0, 88);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1200, 190);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "معلومات إضافية";
            // 
            // dateTime_Start_Date
            // 
            this.dateTime_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_Start_Date.Location = new System.Drawing.Point(253, 28);
            this.dateTime_Start_Date.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTime_Start_Date.Name = "dateTime_Start_Date";
            this.dateTime_Start_Date.RightToLeftLayout = true;
            this.dateTime_Start_Date.Size = new System.Drawing.Size(208, 21);
            this.dateTime_Start_Date.TabIndex = 1;
            // 
            // textBox_Address
            // 
            this.textBox_Address.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Address.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Address.Location = new System.Drawing.Point(253, 91);
            this.textBox_Address.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Address.MaxLength = 50;
            this.textBox_Address.Name = "textBox_Address";
            this.textBox_Address.Size = new System.Drawing.Size(208, 21);
            this.textBox_Address.TabIndex = 3;
            // 
            // textBox_Phone2
            // 
            this.textBox_Phone2.Location = new System.Drawing.Point(790, 148);
            this.textBox_Phone2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Phone2.MaxLength = 15;
            this.textBox_Phone2.Name = "textBox_Phone2";
            this.textBox_Phone2.Size = new System.Drawing.Size(208, 21);
            this.textBox_Phone2.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(491, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 56;
            this.label4.Text = "عنوان المندوب :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(1025, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 14);
            this.label5.TabIndex = 55;
            this.label5.Text = "رقم الهاتف 2 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(1025, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 14);
            this.label6.TabIndex = 54;
            this.label6.Text = "رقم الهاتف 1 :";
            // 
            // textBox_Phone1
            // 
            this.textBox_Phone1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Phone1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Phone1.Location = new System.Drawing.Point(790, 86);
            this.textBox_Phone1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Phone1.MaxLength = 15;
            this.textBox_Phone1.Name = "textBox_Phone1";
            this.textBox_Phone1.Size = new System.Drawing.Size(208, 21);
            this.textBox_Phone1.TabIndex = 2;
            // 
            // textBox_Car_Type
            // 
            this.textBox_Car_Type.Location = new System.Drawing.Point(253, 148);
            this.textBox_Car_Type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Car_Type.MaxLength = 50;
            this.textBox_Car_Type.Name = "textBox_Car_Type";
            this.textBox_Car_Type.Size = new System.Drawing.Size(208, 21);
            this.textBox_Car_Type.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(482, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 14);
            this.label1.TabIndex = 50;
            this.label1.Text = "نوع السيارة المستلمة :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(491, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 14);
            this.label3.TabIndex = 48;
            this.label3.Text = "تاريخ التعين :";
            // 
            // textBox_ID_Number
            // 
            this.textBox_ID_Number.Location = new System.Drawing.Point(790, 31);
            this.textBox_ID_Number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_ID_Number.MaxLength = 15;
            this.textBox_ID_Number.Name = "textBox_ID_Number";
            this.textBox_ID_Number.Size = new System.Drawing.Size(208, 21);
            this.textBox_ID_Number.TabIndex = 0;
            // 
            // label_Cost_Sales
            // 
            this.label_Cost_Sales.AutoSize = true;
            this.label_Cost_Sales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label_Cost_Sales.ForeColor = System.Drawing.Color.Blue;
            this.label_Cost_Sales.Location = new System.Drawing.Point(1020, 33);
            this.label_Cost_Sales.Name = "label_Cost_Sales";
            this.label_Cost_Sales.Size = new System.Drawing.Size(93, 14);
            this.label_Cost_Sales.TabIndex = 44;
            this.label_Cost_Sales.Text = "الرقم الوطني :";
            // 
            // comboBox_Rank
            // 
            this.comboBox_Rank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Rank.FormattingEnabled = true;
            this.comboBox_Rank.Location = new System.Drawing.Point(35, 24);
            this.comboBox_Rank.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Rank.Name = "comboBox_Rank";
            this.comboBox_Rank.Size = new System.Drawing.Size(151, 21);
            this.comboBox_Rank.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(205, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 14);
            this.label2.TabIndex = 64;
            this.label2.Text = "رتبة المندوب :";
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.Orange;
            this.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(206, 21);
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
            this.btn_delete.Location = new System.Drawing.Point(31, 21);
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
            this.btn_add.Location = new System.Drawing.Point(384, 21);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(121, 31);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "اضافة";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // textBox_Distributor_Number
            // 
            this.textBox_Distributor_Number.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Distributor_Number.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Distributor_Number.Enabled = false;
            this.textBox_Distributor_Number.Location = new System.Drawing.Point(643, 24);
            this.textBox_Distributor_Number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Distributor_Number.MaxLength = 9;
            this.textBox_Distributor_Number.Name = "textBox_Distributor_Number";
            this.textBox_Distributor_Number.Size = new System.Drawing.Size(109, 21);
            this.textBox_Distributor_Number.TabIndex = 0;
            this.textBox_Distributor_Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Distributor_Number_KeyPress);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label_Name.ForeColor = System.Drawing.Color.Red;
            this.label_Name.Location = new System.Drawing.Point(528, 27);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(91, 14);
            this.label_Name.TabIndex = 43;
            this.label_Name.Text = "اسم المندوب :";
            // 
            // label_ID
            // 
            this.label_ID.AutoSize = true;
            this.label_ID.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label_ID.ForeColor = System.Drawing.Color.Red;
            this.label_ID.Location = new System.Drawing.Point(767, 26);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(87, 14);
            this.label_ID.TabIndex = 42;
            this.label_ID.Text = "رقم المندوب :";
            // 
            // textBox_Name
            // 
            this.textBox_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Name.Location = new System.Drawing.Point(305, 24);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Name.MaxLength = 50;
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(208, 21);
            this.textBox_Name.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.btn_edit);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Location = new System.Drawing.Point(352, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(525, 65);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الأوامر";
            // 
            // groupBox1_Basic_Information
            // 
            this.groupBox1_Basic_Information.BackColor = System.Drawing.Color.White;
            this.groupBox1_Basic_Information.Controls.Add(this.textBox_Distributor_Number);
            this.groupBox1_Basic_Information.Controls.Add(this.label_ID);
            this.groupBox1_Basic_Information.Controls.Add(this.comboBox_Rank);
            this.groupBox1_Basic_Information.Controls.Add(this.label2);
            this.groupBox1_Basic_Information.Controls.Add(this.textBox_Name);
            this.groupBox1_Basic_Information.Controls.Add(this.label_Name);
            this.groupBox1_Basic_Information.ForeColor = System.Drawing.Color.Red;
            this.groupBox1_Basic_Information.Location = new System.Drawing.Point(173, 17);
            this.groupBox1_Basic_Information.Name = "groupBox1_Basic_Information";
            this.groupBox1_Basic_Information.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1_Basic_Information.Size = new System.Drawing.Size(876, 62);
            this.groupBox1_Basic_Information.TabIndex = 0;
            this.groupBox1_Basic_Information.TabStop = false;
            this.groupBox1_Basic_Information.Text = "معلومات أساسية";
            this.groupBox1_Basic_Information.Enter += new System.EventHandler(this.groupBox1_Basic_Information_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.textBox_search);
            this.groupBox3.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox3.Location = new System.Drawing.Point(15, 357);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(1192, 52);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بحث  ( اسم المندوب ، رقم الهاتف ، رتبة المندوب ، عنوان المندوب )";
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
            // Distributor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1212, 615);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1_Basic_Information);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Distributor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعريف مندوب";
            this.Load += new System.EventHandler(this.Distributor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Distributor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1_Basic_Information.ResumeLayout(false);
            this.groupBox1_Basic_Information.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox_Address;
        private System.Windows.Forms.TextBox textBox_Phone2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBox_Phone1;
        private System.Windows.Forms.TextBox textBox_Car_Type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBox_Distributor_Number;
        private System.Windows.Forms.TextBox textBox_ID_Number;
        private System.Windows.Forms.Label label_Cost_Sales;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_ID;
        public System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DateTimePicker dateTime_Start_Date;
        private System.Windows.Forms.ComboBox comboBox_Rank;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Distributor_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Phone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Date_Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Car_Type;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1_Basic_Information;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_search;
    }
}