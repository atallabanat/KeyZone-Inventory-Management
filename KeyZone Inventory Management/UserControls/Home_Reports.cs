using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyZone_Inventory_Management.Form_RPT;
using System.Configuration;
using System.Data.SqlClient;

namespace KeyZone_Inventory_Management.UserControls
{
    public partial class Home_Reports : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Home_Reports()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية طلب الشراء-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=27", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        FRM_Report_Orders_Parchase FRM_Report_Orders_Parchase2 = new FRM_Report_Orders_Parchase();
                        FRM_Report_Orders_Parchase2.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 27 طباعة طلب الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 27 طباعة طلب الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية فاتورة الشراء-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=28", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        FRM_Report_Invoice_Parchase FRM_Report_Invoice_Parchase2 = new FRM_Report_Invoice_Parchase();
                        FRM_Report_Invoice_Parchase2.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 28 طباعة فاتورة الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 28 طباعة فاتورة الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية فاتورة البيع-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=35", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        FRM_Report_Invoice_Sales FRM_Report_Invoice_Sales2 = new FRM_Report_Invoice_Sales();
                        FRM_Report_Invoice_Sales2.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 35 طباعة فاتورة البيع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 35 طباعة فاتورة البيع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية طلب البيع-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=34", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        FRM_Report_Orders_Sales FRM_Report_Orders_Sales2 = new FRM_Report_Orders_Sales();
                        FRM_Report_Orders_Sales2.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 34 طباعة طلب البيع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 34 طباعة طلب البيع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------


            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            try

            {
                //---------------------------- صلاحية سند الإدخال-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=30", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        FRM_Report_Entry_Bond fRM_Report_Entry_Bond = new FRM_Report_Entry_Bond();
                        fRM_Report_Entry_Bond.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 30 طباعة سند الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 30 طباعة سند الإدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية سند الاتلاف-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=33", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {



                        FRM_Report_Destruction_Bond fRM_Report_Destruction_Bond = new FRM_Report_Destruction_Bond();
                        fRM_Report_Destruction_Bond.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 33 طباعة سند الاتلاف", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 33 طباعة سند الاتلاف", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية سند الإخراج-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=31", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        FRM_Report_Out_Bond fRM_Report_Out_Bond = new FRM_Report_Out_Bond();
                        fRM_Report_Out_Bond.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 31 طباعة سند الإخراج", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 31 طباعة سند الإخراج", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                //---------------------------- صلاحية سند النقل-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=32", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {


                        FRM_Report_Transfer_Bond fRM_Report_Transfer_Bond = new FRM_Report_Transfer_Bond();
                        fRM_Report_Transfer_Bond.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 32 طباعة سند النقل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 32 طباعة سند النقل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية مردود الشراء-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=29", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        FRM_Report_Return_Parchase fRM_Report_Return_Parchase = new FRM_Report_Return_Parchase();
                        fRM_Report_Return_Parchase.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 29 طباعة مردود الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 29 طباعة مردود الشراء", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1009 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية مردود البيع-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=36", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        FRM_Report_Return_Sales fRM_Report_Return_Sales = new FRM_Report_Return_Sales();
                        fRM_Report_Return_Sales.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 36 طباعة مردود البيع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 36 طباعة مردود البيع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1010 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية حركات المستودع-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=37", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {


                        FRM_Report_Trans_Stores fRM_Report_Trans_Stores = new FRM_Report_Trans_Stores();
                        fRM_Report_Trans_Stores.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 37 طباعة حركات المستودع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 37 طباعة حركات المستودع", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1011 Home_Reports", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            FRM_ALL_Report_Invoice_Sales fRM_ALL_Report_Invoice_Sales = new FRM_ALL_Report_Invoice_Sales();
            fRM_ALL_Report_Invoice_Sales.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            FRM_ALL_Report_Invoice_Parchase fRM_ALL_Report_Invoice_Sales = new FRM_ALL_Report_Invoice_Parchase();
            fRM_ALL_Report_Invoice_Sales.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            FRM_Report_Item_Now fRM_Report_Item_Now = new FRM_Report_Item_Now();
            fRM_Report_Item_Now.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FRM_Account_Manf fRM_Account_Manf = new FRM_Account_Manf();
            fRM_Account_Manf.Show();
        }
    }
}
