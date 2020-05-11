namespace KeyZone_Inventory_Management.Grid
{
    partial class Grid_Sales_Order
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid_Sales_Order));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Return_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTime_Doc_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Return_ID,
            this.dateTime_Doc_Date});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(514, 213);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // Return_ID
            // 
            this.Return_ID.DataPropertyName = "Order_Number";
            this.Return_ID.HeaderText = "رقم الطلب";
            this.Return_ID.Name = "Return_ID";
            this.Return_ID.ReadOnly = true;
            this.Return_ID.Width = 200;
            // 
            // dateTime_Doc_Date
            // 
            this.dateTime_Doc_Date.DataPropertyName = "Order_Date";
            this.dateTime_Doc_Date.HeaderText = "تاريخ الطلب";
            this.dateTime_Doc_Date.Name = "dateTime_Doc_Date";
            this.dateTime_Doc_Date.ReadOnly = true;
            this.dateTime_Doc_Date.Width = 270;
            // 
            // Grid_Sales_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 213);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Grid_Sales_Order";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "قائمة طلبات البيع";
            this.Load += new System.EventHandler(this.Grid_Sales_Order_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Return_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateTime_Doc_Date;
    }
}