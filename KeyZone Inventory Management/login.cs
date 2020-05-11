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
    public partial class login : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public login()
        {
            this.KeyPreview = true;
            InitializeComponent();
            ////textBox_name.Text = "admin";
        }
        // public vairable

        public static string username;

        public static string Recby
        {
            get { return username; }
            set { username = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select * from tbl_User where username=@username and password=@password", con);
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.NChar)).Value = textBox_name.Text.Trim();
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NChar)).Value = textBox_password.Text.Trim();

                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                dr.Read();
                if (dr.HasRows)
                {
                    Program.user_ID = dr[0].ToString();
                    Recby = textBox_name.Text;

                    this.Hide();
                    Home Home = new Home();
                    Home.Show();



                }
                else
                {
                    MessageBox.Show("اسم المستخدم وكلمة المرور خطأ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }               
                textBox_name.Text="";
                textBox_password.Text="";
                textBox_name.Focus();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
