namespace KeyZone_Inventory_Management.Grid
{
    partial class Grid_Qauntity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid_Qauntity));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.R_Item_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R_Item_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Qauntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_R_A_qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_Store_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.R_Item_No,
            this.R_Item_Name,
            this.Col_Qauntity,
            this.Col_R_A_qty,
            this.Col_EndDate,
            this.Col_Store_Name});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersWidth = 5;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1053, 213);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // R_Item_No
            // 
            this.R_Item_No.DataPropertyName = "R_Item_No";
            this.R_Item_No.HeaderText = "رمز المادة";
            this.R_Item_No.Name = "R_Item_No";
            this.R_Item_No.ReadOnly = true;
            this.R_Item_No.Width = 200;
            // 
            // R_Item_Name
            // 
            this.R_Item_Name.DataPropertyName = "R_Item_Name";
            this.R_Item_Name.HeaderText = "اسم المادة";
            this.R_Item_Name.Name = "R_Item_Name";
            this.R_Item_Name.ReadOnly = true;
            this.R_Item_Name.Width = 250;
            // 
            // Col_Qauntity
            // 
            this.Col_Qauntity.HeaderText = "الكمية المتاحة (كبرى )";
            this.Col_Qauntity.Name = "Col_Qauntity";
            this.Col_Qauntity.ReadOnly = true;
            this.Col_Qauntity.Width = 135;
            // 
            // Col_R_A_qty
            // 
            this.Col_R_A_qty.DataPropertyName = "R_A_qty";
            this.Col_R_A_qty.HeaderText = "الكمية المتاحة ( صغرى )";
            this.Col_R_A_qty.Name = "Col_R_A_qty";
            this.Col_R_A_qty.ReadOnly = true;
            this.Col_R_A_qty.Width = 150;
            // 
            // Col_EndDate
            // 
            this.Col_EndDate.DataPropertyName = "R_End_Date";
            this.Col_EndDate.HeaderText = "تاريخ الصلاحية";
            this.Col_EndDate.Name = "Col_EndDate";
            this.Col_EndDate.ReadOnly = true;
            this.Col_EndDate.Width = 150;
            // 
            // Col_Store_Name
            // 
            this.Col_Store_Name.DataPropertyName = "R_Stores_Name";
            this.Col_Store_Name.HeaderText = "اسم المستودع";
            this.Col_Store_Name.Name = "Col_Store_Name";
            this.Col_Store_Name.ReadOnly = true;
            this.Col_Store_Name.Width = 160;
            // 
            // Grid_Qauntity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 213);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Grid_Qauntity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "الكمية المتاحة لهذه المادة";
            this.Load += new System.EventHandler(this.Grid_Qauntity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_Item_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn R_Item_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Qauntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_R_A_qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_Store_Name;
    }
}