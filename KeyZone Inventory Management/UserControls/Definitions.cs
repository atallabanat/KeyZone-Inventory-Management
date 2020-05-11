using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyZone_Inventory_Management.Defenition;
using KeyZone_Inventory_Management.Distributor;
using System.Configuration;
using System.Data.SqlClient;

namespace KeyZone_Inventory_Management.UserControls
{
    public partial class Definitions : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Definitions()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            string input = Microsoft.VisualBasic.Interaction.InputBox("هذه الشاشة تخص المبرمجين ، يرجى وضع كلمة المرور للدخول اليها", "كلمة المرور", "*****", 0, 0);
            
            if (input == "KeyZ0ne")
            {
                Defenition.Screen ss = new Defenition.Screen();
                ss.Show();
            }
            else
            {
                MessageBox.Show("يرجى إدخال كلمة المرور الصحيحة", "كلمة المرور خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية أنواع المندوبين-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=9", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        Type_Distributor ss = new Type_Distributor();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 9 تعريف أنواع المندوبين", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 9 تعريف أنواع المندوبين", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                //---------------------------- صلاحية المادة-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=6", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        INV_F ss = new INV_F();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 6 تعريف مادة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 6 تعريف مادة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية العملاء-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=2", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        Customers ss = new Customers();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 2 العملاء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 2 العملاء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية الوحدات-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=5", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        Unit ss = new Unit();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 5 الوحدات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 5 الوحدات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية المندوبين-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=3", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        Distributor.Distributor ss = new Distributor.Distributor();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 3 تعريف مندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 3 تعريف مندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية الموردين-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=4", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        Supplier ss = new Supplier();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 4 تعريف مورد", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 4 تعريف مورد", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OPEN_TAX_ACCOUNT ss = new OPEN_TAX_ACCOUNT();
            ss.Show();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية المستودع-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=7", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        Stores ss = new Stores();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 7 تعريف مستودع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 7 تعريف مستودع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Definitions_Load(object sender, EventArgs e)
        {
            try
            {
                //--------------------- عدد العملاء ------------------------------------------------

                SqlCommand cmd1 = con.CreateCommand();

                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "select count(Customers_No) from Customers";
                con.Open();

                Int32 rows_count2 = Convert.ToInt32(cmd1.ExecuteScalar());
                label2.Text = rows_count2.ToString() + "";


                con.Close();
                //-------------------------------------------------------------------------------------

                //--------------------- عدد المندوبين ------------------------------------------------

                SqlCommand cmd2 = con.CreateCommand();

                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "select count(Customers_No) from Customers";
                con.Open();

                Int32 rows_count1 = Convert.ToInt32(cmd2.ExecuteScalar());
                label32.Text = rows_count1.ToString() + "";


                con.Close();
                //-------------------------------------------------------------------------------------


                //---------------------------- صلاحية فتح حساب ضريبي-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=10", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        button7.Visible = true;
                    }
                    else
                    {
                        button7.Visible = false;
                    }

                }
                else
                {
                    button7.Visible = false;

                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Definitions", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
