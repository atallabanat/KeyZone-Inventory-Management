namespace KeyZone_Inventory_Management
{
    partial class OPEN_TAX_ACCOUNT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OPEN_TAX_ACCOUNT));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Total_Account = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Account_Rate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Account_Name = new System.Windows.Forms.TextBox();
            this.textBox_Account_Number = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label_Cost_Sales = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_edit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_search = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Account_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Account_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Account_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Total_Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.textBox_Total_Account);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_Account_Rate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Account_Name);
            this.groupBox1.Controls.Add(this.textBox_Account_Number);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label_Cost_Sales);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(722, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "فتح حساب ضريبي";
            // 
            // textBox_Total_Account
            // 
            this.textBox_Total_Account.Enabled = false;
            this.textBox_Total_Account.Location = new System.Drawing.Point(133, 67);
            this.textBox_Total_Account.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Total_Account.MaxLength = 9;
            this.textBox_Total_Account.Name = "textBox_Total_Account";
            this.textBox_Total_Account.Size = new System.Drawing.Size(121, 21);
            this.textBox_Total_Account.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(260, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 14);
            this.label2.TabIndex = 116;
            this.label2.Text = "رصيد الحساب :";
            // 
            // textBox_Account_Rate
            // 
            this.textBox_Account_Rate.Location = new System.Drawing.Point(133, 30);
            this.textBox_Account_Rate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Account_Rate.MaxLength = 50;
            this.textBox_Account_Rate.Name = "textBox_Account_Rate";
            this.textBox_Account_Rate.Size = new System.Drawing.Size(121, 21);
            this.textBox_Account_Rate.TabIndex = 2;
            this.textBox_Account_Rate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Account_Rate_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(260, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 14);
            this.label1.TabIndex = 114;
            this.label1.Text = "نسبة الحساب :";
            // 
            // textBox_Account_Name
            // 
            this.textBox_Account_Name.Location = new System.Drawing.Point(482, 67);
            this.textBox_Account_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Account_Name.MaxLength = 50;
            this.textBox_Account_Name.Name = "textBox_Account_Name";
            this.textBox_Account_Name.Size = new System.Drawing.Size(121, 21);
            this.textBox_Account_Name.TabIndex = 1;
            // 
            // textBox_Account_Number
            // 
            this.textBox_Account_Number.Location = new System.Drawing.Point(482, 30);
            this.textBox_Account_Number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Account_Number.MaxLength = 9;
            this.textBox_Account_Number.Name = "textBox_Account_Number";
            this.textBox_Account_Number.Size = new System.Drawing.Size(121, 21);
            this.textBox_Account_Number.TabIndex = 0;
            this.textBox_Account_Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Account_Number_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(609, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 14);
            this.label6.TabIndex = 112;
            this.label6.Text = "اسم الحساب :";
            // 
            // label_Cost_Sales
            // 
            this.label_Cost_Sales.AutoSize = true;
            this.label_Cost_Sales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label_Cost_Sales.ForeColor = System.Drawing.Color.Red;
            this.label_Cost_Sales.Location = new System.Drawing.Point(609, 32);
            this.label_Cost_Sales.Name = "label_Cost_Sales";
            this.label_Cost_Sales.Size = new System.Drawing.Size(87, 14);
            this.label_Cost_Sales.TabIndex = 111;
            this.label_Cost_Sales.Text = "رقم الحساب :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.btn_delete);
            this.groupBox2.Controls.Add(this.btn_edit);
            this.groupBox2.Location = new System.Drawing.Point(116, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(525, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "الأوامر";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Blue;
            this.btn_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_add.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_add.FlatAppearance.BorderSize = 2;
            this.btn_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(388, 21);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(121, 31);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "اضافة";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.Red;
            this.btn_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_delete.FlatAppearance.BorderSize = 2;
            this.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_delete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(33, 21);
            this.btn_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(121, 31);
            this.btn_delete.TabIndex = 2;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.BackColor = System.Drawing.Color.Orange;
            this.btn_edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_edit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_edit.FlatAppearance.BorderSize = 2;
            this.btn_edit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_edit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_edit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_edit.ForeColor = System.Drawing.Color.White;
            this.btn_edit.Location = new System.Drawing.Point(211, 21);
            this.btn_edit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(121, 31);
            this.btn_edit.TabIndex = 1;
            this.btn_edit.Text = "تعديل";
            this.btn_edit.UseVisualStyleBackColor = false;
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.White;
            this.groupBox3.Controls.Add(this.textBox_search);
            this.groupBox3.ForeColor = System.Drawing.Color.SeaGreen;
            this.groupBox3.Location = new System.Drawing.Point(3, 218);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox3.Size = new System.Drawing.Size(750, 57);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بحث (رقم الحساب , اسم الحساب , نسبة الحساب)";
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
            this.textBox_search.Location = new System.Drawing.Point(309, 17);
            this.textBox_search.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(421, 33);
            this.textBox_search.TabIndex = 0;
            this.textBox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.textBox_search.OnValueChanged += new System.EventHandler(this.textBox_search_OnValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Account_Number,
            this.Column_Account_Name,
            this.Column_Account_Rate,
            this.Column_Total_Account});
            this.dataGridView1.Location = new System.Drawing.Point(3, 290);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(750, 162);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // Column_Account_Number
            // 
            this.Column_Account_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Account_Number.DataPropertyName = "Account_Number";
            this.Column_Account_Number.HeaderText = "رقم الحساب";
            this.Column_Account_Number.Name = "Column_Account_Number";
            this.Column_Account_Number.ReadOnly = true;
            this.Column_Account_Number.Width = 150;
            // 
            // Column_Account_Name
            // 
            this.Column_Account_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Account_Name.DataPropertyName = "Account_Name";
            this.Column_Account_Name.HeaderText = "اسم الحساب";
            this.Column_Account_Name.Name = "Column_Account_Name";
            this.Column_Account_Name.ReadOnly = true;
            this.Column_Account_Name.Width = 250;
            // 
            // Column_Account_Rate
            // 
            this.Column_Account_Rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Account_Rate.DataPropertyName = "Account_Rate";
            this.Column_Account_Rate.HeaderText = "نسبة الحساب";
            this.Column_Account_Rate.Name = "Column_Account_Rate";
            this.Column_Account_Rate.ReadOnly = true;
            this.Column_Account_Rate.Width = 150;
            // 
            // Column_Total_Account
            // 
            this.Column_Total_Account.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column_Total_Account.DataPropertyName = "Total_Account";
            this.Column_Total_Account.HeaderText = "رصيد الحساب";
            this.Column_Total_Account.Name = "Column_Total_Account";
            this.Column_Total_Account.ReadOnly = true;
            this.Column_Total_Account.Width = 150;
            // 
            // OPEN_TAX_ACCOUNT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 464);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "OPEN_TAX_ACCOUNT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فتح حساب ضريبي";
            this.Load += new System.EventHandler(this.OPEN_TAX_ACCOUNT_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OPEN_TAX_ACCOUNT_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Account_Rate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Account_Name;
        private System.Windows.Forms.TextBox textBox_Account_Number;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_Cost_Sales;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.GroupBox groupBox3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox_search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_Total_Account;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Account_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Account_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Account_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Total_Account;
    }
}