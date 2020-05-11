namespace KeyZone_Inventory_Management.Form_RPT
{
    partial class FRM_Report_Invoice_Parchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Report_Invoice_Parchase));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_View_Bond_No = new System.Windows.Forms.Button();
            this.textBox_Invoice__Number = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Year = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_View_Bond_No);
            this.groupBox1.Controls.Add(this.textBox_Invoice__Number);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_Year);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(404, 123);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "طباعة";
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
            this.btn_View_Bond_No.Location = new System.Drawing.Point(267, 64);
            this.btn_View_Bond_No.Name = "btn_View_Bond_No";
            this.btn_View_Bond_No.Size = new System.Drawing.Size(39, 41);
            this.btn_View_Bond_No.TabIndex = 3;
            this.btn_View_Bond_No.UseVisualStyleBackColor = true;
            this.btn_View_Bond_No.Click += new System.EventHandler(this.btn_View_Bond_No_Click);
            // 
            // textBox_Invoice__Number
            // 
            this.textBox_Invoice__Number.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Invoice__Number.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Invoice__Number.Location = new System.Drawing.Point(108, 77);
            this.textBox_Invoice__Number.MaxLength = 9;
            this.textBox_Invoice__Number.Name = "textBox_Invoice__Number";
            this.textBox_Invoice__Number.Size = new System.Drawing.Size(156, 20);
            this.textBox_Invoice__Number.TabIndex = 0;
            this.textBox_Invoice__Number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Invoice__Number_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(312, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "رقم الفاتورة :";
            // 
            // textBox_Year
            // 
            this.textBox_Year.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Year.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Year.Location = new System.Drawing.Point(229, 24);
            this.textBox_Year.MaxLength = 4;
            this.textBox_Year.Name = "textBox_Year";
            this.textBox_Year.Size = new System.Drawing.Size(99, 20);
            this.textBox_Year.TabIndex = 1;
            this.textBox_Year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Year_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(334, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "السنة :";
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Blue;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(12, 136);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(121, 31);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "موافق";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // FRM_Report_Invoice_Parchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 172);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FRM_Report_Invoice_Parchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "طباعة فاتورة الشراء";
            this.Load += new System.EventHandler(this.FRM_Report_Invoice_Parchase_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_View_Bond_No;
        public System.Windows.Forms.TextBox textBox_Invoice__Number;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox_Year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Save;
    }
}