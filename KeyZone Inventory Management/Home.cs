using KeyZone_Inventory_Management.Admin;
using KeyZone_Inventory_Management.Bond_Inventory;
using KeyZone_Inventory_Management.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyZone_Inventory_Management
{
    public partial class Home : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        int panelWidth;
        bool isCollapsed;
        public DateTime current;
        DataTable Dt = new DataTable();

        public Home()
        {
            InitializeComponent();

            panelWidth = panel1.Width;
            isCollapsed = false;
            timer2.Start();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel1.Width = panel1.Width + 10;

                if (panel1.Width >= panelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();

                }
            }
            else
            {
                panel1.Width = panel1.Width - 10;
                if (panel1.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();

                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt = DateTime.Now;
                lbl_date.Text = DateTime.Now.ToShortDateString();
                current = DateTime.Now;
                lbl_time.Text = dt.ToString("HH:MM:ss");
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Home", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        //------------ الشريط المتحرك بجانب الزر ---------------------//
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;



        }
        //--------------------------الصفحات المتنقلة ------------------------//
        private void addControlsTopanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);

        }

        private void btn_Side_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            try
            {


                label7.Text = login.Recby;

                KZ ssa = new KZ();
                addControlsTopanel(ssa);







                //---------------------------- صلاحية التعريفات-------------------------------------------------
                SqlDataReader ddr;                
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=21", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        btn_New_Mat.Visible = true;
                    }
                    else
                    {
                        btn_New_Mat.Visible = false;
                    }
                }
                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

                //---------------------------- صلاحية المشتريات-------------------------------------------------
                SqlDataReader ddr2;
                SqlCommand ccmd2 = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=22", con);
                con.Open();
                ddr2 = ccmd2.ExecuteReader();
                if (ddr2.Read())
                {
                    if (ddr2["Priv_Display"].ToString() == "True")
                    {
                        btn_parchase.Visible = true;
                    }
                    else
                    {
                        btn_parchase.Visible = false;
                    }
                }
                ddr2.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

                //---------------------------- صلاحية المستودعات-------------------------------------------------
                SqlDataReader ddr3;
                SqlCommand ccmd3 = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=23", con);
                con.Open();
                ddr3 = ccmd3.ExecuteReader();
                if (ddr3.Read())
                {
                    if (ddr3["Priv_Display"].ToString() == "True")
                    {
                        btn_Inventory.Visible = true;
                    }
                    else
                    {
                        btn_Inventory.Visible = false;
                    }
                }
                ddr3.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

                //---------------------------- صلاحية المبيعات-------------------------------------------------
                SqlDataReader ddr4;
                SqlCommand ccmd4 = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=24", con);
                con.Open();
                ddr4 = ccmd4.ExecuteReader();
                if (ddr4.Read())
                {
                    if (ddr4["Priv_Display"].ToString() == "True")
                    {
                        btn_sales.Visible = true;
                    }
                    else
                    {
                        btn_sales.Visible = false;
                    }
                }
                ddr4.Close();
                con.Close();

                //---------------------------------------------------------------------------------------


                //---------------------------- صلاحية التقارير-------------------------------------------------
                SqlDataReader ddr5;
                SqlCommand ccmd5 = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=25", con);
                con.Open();
                ddr5 = ccmd5.ExecuteReader();
                if (ddr5.Read())
                {
                    if (ddr5["Priv_Display"].ToString() == "True")
                    {
                        btn_Report.Visible = true;
                    }
                    else
                    {
                        btn_Report.Visible = false;
                    }
                }
                ddr5.Close();
                con.Close();

                //---------------------------------------------------------------------------------------


                //---------------------------- صلاحية لوحة التحكم-------------------------------------------------
                SqlDataReader ddr6;
                SqlCommand ccmd6 = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=26", con);
                con.Open();
                ddr6 = ccmd6.ExecuteReader();
                if (ddr6.Read())
                {
                    if (ddr6["Priv_Display"].ToString() == "True")
                    {
                        btn_Controls.Visible = true;
                    }
                    else
                    {
                        btn_Controls.Visible = false;
                    }
                }
                ddr6.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Home", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_logout);

            this.Close();
            login Login = new login();
            Login.Show();
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_home);
            KZ kZ = new KZ();
            addControlsTopanel(kZ);
        }



        private void btn_New_Mat_Click_1(object sender, EventArgs e)
        {
            moveSidePanel(btn_New_Mat);
            Definitions Definitions = new Definitions();
            addControlsTopanel(Definitions);
        }

        private void btn_parchase_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_parchase);
            Home_Parchases Home_Parchases = new Home_Parchases();
            addControlsTopanel(Home_Parchases);

        }

        private void btn_sales_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_sales);
            Home_Sales Home_Sales = new Home_Sales();
            addControlsTopanel(Home_Sales);
        }

        private void btn_Inventory_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_Inventory);
            Home_Bond Home_Bond = new Home_Bond();
            addControlsTopanel(Home_Bond);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_Controls);
            startHome_admin startHome_Admin = new startHome_admin();
            addControlsTopanel(startHome_Admin);
        }

        private void btn_Report_Click(object sender, EventArgs e)
        {
            moveSidePanel(btn_Report);
            Home_Reports home_Reports = new Home_Reports();
            addControlsTopanel(home_Reports);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Paid ss = new Add_Paid();
            ss.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sett_Inventory ss = new sett_Inventory();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
