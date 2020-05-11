namespace KeyZone_Inventory_Management.UserControls
{
    partial class Home_Parchases
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home_Parchases));
            this.panelControls = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bar_orders_parchase = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.bar_invoice_parchase = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.bar_back_parchase = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.panelControls.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.White;
            this.panelControls.Controls.Add(this.groupBox2);
            this.panelControls.Controls.Add(this.groupBox1);
            this.panelControls.Location = new System.Drawing.Point(4, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1114, 630);
            this.panelControls.TabIndex = 40;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bar_orders_parchase);
            this.groupBox2.Controls.Add(this.bar_invoice_parchase);
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.bar_back_parchase);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(14, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(1086, 373);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "معلومات عامة";
            // 
            // bar_orders_parchase
            // 
            this.bar_orders_parchase.animated = false;
            this.bar_orders_parchase.animationIterval = 5;
            this.bar_orders_parchase.animationSpeed = 300;
            this.bar_orders_parchase.BackColor = System.Drawing.Color.White;
            this.bar_orders_parchase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bar_orders_parchase.BackgroundImage")));
            this.bar_orders_parchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bar_orders_parchase.ForeColor = System.Drawing.Color.DarkBlue;
            this.bar_orders_parchase.LabelVisible = true;
            this.bar_orders_parchase.LineProgressThickness = 8;
            this.bar_orders_parchase.LineThickness = 5;
            this.bar_orders_parchase.Location = new System.Drawing.Point(842, 174);
            this.bar_orders_parchase.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bar_orders_parchase.MaxValue = 100;
            this.bar_orders_parchase.Name = "bar_orders_parchase";
            this.bar_orders_parchase.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bar_orders_parchase.ProgressColor = System.Drawing.Color.SeaGreen;
            this.bar_orders_parchase.Size = new System.Drawing.Size(182, 182);
            this.bar_orders_parchase.TabIndex = 37;
            this.bar_orders_parchase.Value = 0;
            // 
            // bar_invoice_parchase
            // 
            this.bar_invoice_parchase.animated = false;
            this.bar_invoice_parchase.animationIterval = 5;
            this.bar_invoice_parchase.animationSpeed = 300;
            this.bar_invoice_parchase.BackColor = System.Drawing.Color.White;
            this.bar_invoice_parchase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bar_invoice_parchase.BackgroundImage")));
            this.bar_invoice_parchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bar_invoice_parchase.ForeColor = System.Drawing.Color.SeaGreen;
            this.bar_invoice_parchase.LabelVisible = true;
            this.bar_invoice_parchase.LineProgressThickness = 8;
            this.bar_invoice_parchase.LineThickness = 5;
            this.bar_invoice_parchase.Location = new System.Drawing.Point(462, 174);
            this.bar_invoice_parchase.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bar_invoice_parchase.MaxValue = 100;
            this.bar_invoice_parchase.Name = "bar_invoice_parchase";
            this.bar_invoice_parchase.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bar_invoice_parchase.ProgressColor = System.Drawing.Color.SeaGreen;
            this.bar_invoice_parchase.Size = new System.Drawing.Size(182, 182);
            this.bar_invoice_parchase.TabIndex = 35;
            this.bar_invoice_parchase.Value = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Maroon;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(22, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 87);
            this.panel3.TabIndex = 34;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::KeyZone_Inventory_Management.Properties.Resources.ContentMarketing_Icon1;
            this.pictureBox3.Location = new System.Drawing.Point(15, 28);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(103, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "label4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(35, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "عدد مردودات المشتريات";
            // 
            // bar_back_parchase
            // 
            this.bar_back_parchase.animated = false;
            this.bar_back_parchase.animationIterval = 5;
            this.bar_back_parchase.animationSpeed = 300;
            this.bar_back_parchase.BackColor = System.Drawing.Color.White;
            this.bar_back_parchase.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bar_back_parchase.BackgroundImage")));
            this.bar_back_parchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.bar_back_parchase.ForeColor = System.Drawing.Color.Maroon;
            this.bar_back_parchase.LabelVisible = true;
            this.bar_back_parchase.LineProgressThickness = 8;
            this.bar_back_parchase.LineThickness = 5;
            this.bar_back_parchase.Location = new System.Drawing.Point(40, 174);
            this.bar_back_parchase.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.bar_back_parchase.MaxValue = 100;
            this.bar_back_parchase.Name = "bar_back_parchase";
            this.bar_back_parchase.ProgressBackColor = System.Drawing.Color.Gainsboro;
            this.bar_back_parchase.ProgressColor = System.Drawing.Color.SeaGreen;
            this.bar_back_parchase.Size = new System.Drawing.Size(182, 182);
            this.bar_back_parchase.TabIndex = 36;
            this.bar_back_parchase.Value = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(436, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 87);
            this.panel1.TabIndex = 32;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::KeyZone_Inventory_Management.Properties.Resources.imgbin_computer_icons_purchase_order_blog_order_L63FuVseRSCzp73RzAqfRrHEQ;
            this.pictureBox1.Location = new System.Drawing.Point(15, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(93, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "label4";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(65, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "عدد فواتير الشراء";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkBlue;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(809, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 87);
            this.panel2.TabIndex = 33;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::KeyZone_Inventory_Management.Properties.Resources.order_list_listing_form_2_512;
            this.pictureBox2.Location = new System.Drawing.Point(13, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(102, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "label4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(45, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "عدد طلبات المشتريات";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(15, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(1086, 187);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الأوامر";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Blue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.Location = new System.Drawing.Point(854, 72);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(203, 60);
            this.button1.TabIndex = 23;
            this.button1.Text = "طلب الشراء";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Green;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.Location = new System.Drawing.Point(440, 72);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(203, 60);
            this.button2.TabIndex = 24;
            this.button2.Text = "فاتورة الشراء";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.Location = new System.Drawing.Point(21, 72);
            this.button9.Name = "button9";
            this.button9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button9.Size = new System.Drawing.Size(203, 60);
            this.button9.TabIndex = 31;
            this.button9.Text = "مردوات المشتريات";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Interval = 50;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Home_Parchases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControls);
            this.Name = "Home_Parchases";
            this.Size = new System.Drawing.Size(1122, 630);
            this.Load += new System.EventHandler(this.Home_Parchases_Load);
            this.panelControls.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.GroupBox groupBox2;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bar_orders_parchase;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bar_invoice_parchase;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Bunifu.Framework.UI.BunifuCircleProgressbar bar_back_parchase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
    }
}
