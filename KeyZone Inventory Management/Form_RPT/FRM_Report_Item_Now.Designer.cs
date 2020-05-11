namespace KeyZone_Inventory_Management.Form_RPT
{
    partial class FRM_Report_Item_Now
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Report_Item_Now));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_Store_Name = new System.Windows.Forms.TextBox();
            this.rd_StoreNo = new System.Windows.Forms.RadioButton();
            this.textBox_Store_No = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_View_Store_No = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_Store_Name);
            this.groupBox1.Controls.Add(this.rd_StoreNo);
            this.groupBox1.Controls.Add(this.btn_View_Store_No);
            this.groupBox1.Controls.Add(this.textBox_Store_No);
            this.groupBox1.Location = new System.Drawing.Point(3, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(506, 72);
            this.groupBox1.TabIndex = 3;
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
            // rd_StoreNo
            // 
            this.rd_StoreNo.AutoSize = true;
            this.rd_StoreNo.Checked = true;
            this.rd_StoreNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rd_StoreNo.Location = new System.Drawing.Point(384, 26);
            this.rd_StoreNo.Name = "rd_StoreNo";
            this.rd_StoreNo.Size = new System.Drawing.Size(108, 18);
            this.rd_StoreNo.TabIndex = 4;
            this.rd_StoreNo.TabStop = true;
            this.rd_StoreNo.Text = "رقم المستودع";
            this.rd_StoreNo.UseVisualStyleBackColor = true;
            // 
            // textBox_Store_No
            // 
            this.textBox_Store_No.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Store_No.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Store_No.Location = new System.Drawing.Point(250, 26);
            this.textBox_Store_No.MaxLength = 9;
            this.textBox_Store_No.Name = "textBox_Store_No";
            this.textBox_Store_No.Size = new System.Drawing.Size(90, 20);
            this.textBox_Store_No.TabIndex = 0;
            this.textBox_Store_No.Leave += new System.EventHandler(this.textBox_Store_No_Leave);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Blue;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(158, 105);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(205, 31);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "موافق";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_View_Store_No
            // 
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
            // FRM_Report_Item_Now
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(513, 145);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_Report_Item_Now";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "كشف الاصناف المتواجدة في المستودع";
            this.Load += new System.EventHandler(this.FRM_Report_Item_Now_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBox_Store_Name;
        private System.Windows.Forms.RadioButton rd_StoreNo;
        private System.Windows.Forms.Button btn_View_Store_No;
        public System.Windows.Forms.TextBox textBox_Store_No;
        private System.Windows.Forms.Button btn_Save;
    }
}