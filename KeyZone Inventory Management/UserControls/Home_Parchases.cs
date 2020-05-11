using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyZone_Inventory_Management.parchases;
using KeyZone_Inventory_Management.purchases;
using System.Configuration;
using System.Data.SqlClient;

namespace KeyZone_Inventory_Management.UserControls
{
    public partial class Home_Parchases : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public virable
        int t1;
        int t2;
        int t3;
        int coount1 = 0;
        int coount2 = 0;
        int coount3 = 0;
        public Home_Parchases()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية طلب الشراء-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=11", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        Orders_parchase ss = new Orders_parchase();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 11 طلب الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 11 طلب الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Home_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية فاتورة الشراء-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=12", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        Invoice_Parchase ss = new Invoice_Parchase();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 12 فاتورة الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 12 فاتورة الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Home_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Home_Parchases_Load(object sender, EventArgs e)
        {
            try
            {
                //--------------------- عدد طلبات الشراء ------------------------------------------------

                SqlCommand cmd2 = con.CreateCommand();

                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select  count(DISTiNCT Order_No) from Orders_Parchase";
                con.Open();

                Int32 rows_count1 = Convert.ToInt32(cmd2.ExecuteScalar());
                label3.Text = rows_count1.ToString() + "";
                t1 = Convert.ToInt32(label3.Text);



                con.Close();
                //-------------------------------------------------------------------------------------

                //--------------------- عدد فواتير الشراء ------------------------------------------------

                SqlCommand cmd3 = con.CreateCommand();

                cmd3.CommandType = CommandType.Text;
                cmd3.CommandText = "select  count(DISTiNCT Invoice_No) from Invoice_Parchase";
                con.Open();

                Int32 rows_count3 = Convert.ToInt32(cmd3.ExecuteScalar());
                label2.Text = rows_count3.ToString() + "";
                t2 = Convert.ToInt32(label2.Text);


                con.Close();
                //-------------------------------------------------------------------------------------

                ////--------------------- عدد مردود الشراء ------------------------------------------------

                SqlCommand cmd4 = con.CreateCommand();

                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "select  count(DISTiNCT Bond_No) from return_parchase";
                con.Open();

                Int32 rows_count4 = Convert.ToInt32(cmd4.ExecuteScalar());
                label5.Text = rows_count4.ToString() + "";
                t3 = Convert.ToInt32(label5.Text);


                con.Close();
                ////-------------------------------------------------------------------------------------
                ///}
                ///
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Home_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية مردود الشراء-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=13", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        return_parchase ss = new return_parchase();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 13 مردود الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 13 مردود الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Home_Parchases", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            coount1 = coount1 +1;


            bar_orders_parchase.Value = coount1;

            if(coount1 >= t1)
            {
                timer1.Stop();
                coount1 = 0;
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            coount2 = coount2 + 1;


            bar_invoice_parchase.Value = coount2;

            if (coount2 >= t2)
            {
                timer2.Stop();
                coount2 = 0;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            coount3 = coount3 + 1;


            bar_back_parchase.Value = coount3;

            if (coount3 >= t3)
            {
                timer3.Stop();
                coount3 = 0;
            }
        }
    }
}
