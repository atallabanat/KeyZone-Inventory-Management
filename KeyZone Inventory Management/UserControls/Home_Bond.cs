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
using KeyZone_Inventory_Management.Bond_Inventory;
using System.Configuration;
using System.Data.SqlClient;

namespace KeyZone_Inventory_Management.UserControls
{
    public partial class Home_Bond : UserControl
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Home_Bond()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية سند الإتلاف وشطب-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=17", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        Destruction_Bond ss = new Destruction_Bond();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 17 سند إتلاف وشطب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 17 سند إتلاف وشطب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Home_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية سند النقل-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=16", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        Transfer_Bond ss = new Transfer_Bond();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 16 سند النقل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 16 سند النقل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Home_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية سند الإدخال-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=14", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {

                        Entity_Bond ss = new Entity_Bond();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 14 سند إدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 14 سند إدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Home_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //---------------------------- صلاحية سند الإخراج-------------------------------------------------
                SqlDataReader ddr;
                SqlCommand ccmd = new SqlCommand("select Priv_Display from TB_Priv where Priv_User_ID=" + Convert.ToInt32(Program.user_ID) + " and Priv_Screen_ID=15", con);
                con.Open();
                ddr = ccmd.ExecuteReader();
                if (ddr.Read())
                {
                    if (ddr["Priv_Display"].ToString() == "True")
                    {
                        Out_Bond ss = new Out_Bond();
                        ss.Show();
                    }
                    else
                    {
                        MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 15 سند إخراج", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("عذرا ، أنت لا تملك صلاحية للدخول الى هذه الشاشة", " 15 سند إخراج", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ddr.Close();
                con.Close();

                //---------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Home_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
