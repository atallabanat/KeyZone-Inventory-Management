namespace KeyZone_Inventory_Management.Bond_Inventory
{
    partial class Add_Paid
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Paid));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Note = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTime_Date_Paid = new System.Windows.Forms.DateTimePicker();
            this.label_Date = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_Paid = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Stores_No = new System.Windows.Forms.TextBox();
            this.textBox_Stores_Name = new System.Windows.Forms.TextBox();
            this.btn_View_Bond_No = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Note);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTime_Date_Paid);
            this.groupBox1.Controls.Add(this.label_Date);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.textBox_Stores_No);
            this.groupBox1.Controls.Add(this.textBox_Stores_Name);
            this.groupBox1.Controls.Add(this.btn_View_Bond_No);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(471, 273);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الدفع";
            // 
            // textBox_Note
            // 
            this.textBox_Note.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Note.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Note.Location = new System.Drawing.Point(19, 117);
            this.textBox_Note.MaxLength = 250;
            this.textBox_Note.Multiline = true;
            this.textBox_Note.Name = "textBox_Note";
            this.textBox_Note.Size = new System.Drawing.Size(333, 74);
            this.textBox_Note.TabIndex = 67;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(358, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 14);
            this.label2.TabIndex = 66;
            this.label2.Text = "وذلك عن :";
            // 
            // dateTime_Date_Paid
            // 
            this.dateTime_Date_Paid.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTime_Date_Paid.Location = new System.Drawing.Point(31, 75);
            this.dateTime_Date_Paid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTime_Date_Paid.Name = "dateTime_Date_Paid";
            this.dateTime_Date_Paid.RightToLeftLayout = true;
            this.dateTime_Date_Paid.Size = new System.Drawing.Size(320, 22);
            this.dateTime_Date_Paid.TabIndex = 64;
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label_Date.ForeColor = System.Drawing.Color.Red;
            this.label_Date.Location = new System.Drawing.Point(358, 81);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(83, 14);
            this.label_Date.TabIndex = 65;
            this.label_Date.Text = "تاريخ الدفعة :";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox_Paid);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.Color.DarkGreen;
            this.groupBox6.Location = new System.Drawing.Point(73, 199);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox6.Size = new System.Drawing.Size(331, 61);
            this.groupBox6.TabIndex = 63;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "قيمة الدفعة";
            // 
            // textBox_Paid
            // 
            this.textBox_Paid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.textBox_Paid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_Paid.Font = new System.Drawing.Font("Adobe Gothic Std B", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Paid.ForeColor = System.Drawing.Color.Crimson;
            this.textBox_Paid.HintForeColor = System.Drawing.Color.DarkGreen;
            this.textBox_Paid.HintText = "";
            this.textBox_Paid.isPassword = false;
            this.textBox_Paid.LineFocusedColor = System.Drawing.Color.Crimson;
            this.textBox_Paid.LineIdleColor = System.Drawing.Color.DarkGreen;
            this.textBox_Paid.LineMouseHoverColor = System.Drawing.Color.Crimson;
            this.textBox_Paid.LineThickness = 4;
            this.textBox_Paid.Location = new System.Drawing.Point(73, 19);
            this.textBox_Paid.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Paid.Name = "textBox_Paid";
            this.textBox_Paid.Size = new System.Drawing.Size(247, 37);
            this.textBox_Paid.TabIndex = 2;
            this.textBox_Paid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Paid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Paid_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "دينار";
            // 
            // textBox_Stores_No
            // 
            this.textBox_Stores_No.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Stores_No.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Stores_No.Location = new System.Drawing.Point(244, 22);
            this.textBox_Stores_No.MaxLength = 9;
            this.textBox_Stores_No.Name = "textBox_Stores_No";
            this.textBox_Stores_No.Size = new System.Drawing.Size(58, 22);
            this.textBox_Stores_No.TabIndex = 61;
            this.textBox_Stores_No.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Stores_No_KeyPress);
            this.textBox_Stores_No.Leave += new System.EventHandler(this.textBox_Stores_No_Leave);
            // 
            // textBox_Stores_Name
            // 
            this.textBox_Stores_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Stores_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Stores_Name.Location = new System.Drawing.Point(33, 22);
            this.textBox_Stores_Name.MaxLength = 9;
            this.textBox_Stores_Name.Name = "textBox_Stores_Name";
            this.textBox_Stores_Name.ReadOnly = true;
            this.textBox_Stores_Name.Size = new System.Drawing.Size(203, 22);
            this.textBox_Stores_Name.TabIndex = 62;
            // 
            // btn_View_Bond_No
            // 
            this.btn_View_Bond_No.FlatAppearance.BorderSize = 0;
            this.btn_View_Bond_No.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_View_Bond_No.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_View_Bond_No.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_View_Bond_No.ForeColor = System.Drawing.Color.White;
            this.btn_View_Bond_No.Image = global::KeyZone_Inventory_Management.Properties.Resources.view_file_32px;
            this.btn_View_Bond_No.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_View_Bond_No.Location = new System.Drawing.Point(308, 8);
            this.btn_View_Bond_No.Name = "btn_View_Bond_No";
            this.btn_View_Bond_No.Size = new System.Drawing.Size(45, 44);
            this.btn_View_Bond_No.TabIndex = 59;
            this.btn_View_Bond_No.UseVisualStyleBackColor = true;
            this.btn_View_Bond_No.Click += new System.EventHandler(this.btn_View_Bond_No_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(358, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 60;
            this.label1.Text = "رقم المستودع :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Blue;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(175, 288);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(141, 33);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "دفع";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // Add_Paid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 330);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Blue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Add_Paid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تسجيل دفعة جديدة للمندوب";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.TextBox textBox_Stores_No;
        public System.Windows.Forms.TextBox textBox_Stores_Name;
        private System.Windows.Forms.Button btn_View_Bond_No;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTime_Date_Paid;
        private System.Windows.Forms.Label label_Date;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_Paid;
        public System.Windows.Forms.TextBox textBox_Note;
        private System.Windows.Forms.Label label2;
    }
}