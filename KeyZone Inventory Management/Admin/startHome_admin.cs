using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using KeyZone_Inventory_Management.UserControls;

namespace KeyZone_Inventory_Management.Admin
{
    public partial class startHome_admin : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public startHome_admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_employee add_Employee = new add_employee();
            add_Employee.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            controls_user controls_User = new controls_user();
            controls_User.ShowDialog();
        }

        private void startHome_admin_Load(object sender, EventArgs e)
        {
            try
            {
                //--------------------- عدد الموظفين ------------------------------------------------

                SqlCommand cmd4 = con.CreateCommand();

                cmd4.CommandType = CommandType.Text;
                cmd4.CommandText = "select count(id) from tbl_user";
                con.Open();

                Int32 rows_count2 = Convert.ToInt32(cmd4.ExecuteScalar());
                label2.Text = rows_count2.ToString() + "";


                con.Close();
                //-------------------------------------------------------------------------------------


                //--------------------- عدد المستودعات ------------------------------------------------

                SqlCommand cmd5 = con.CreateCommand();

                cmd5.CommandType = CommandType.Text;
                cmd5.CommandText = "select count(SNo) from Stores";
                con.Open();

                Int32 rows_count3 = Convert.ToInt32(cmd5.ExecuteScalar());
                label32.Text = rows_count3.ToString() + "";


                con.Close();
                //-------------------------------------------------------------------------------------
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 StartHome_admin", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NOTE nOTE = new NOTE();
            nOTE.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Comf_image comf_Image = new Comf_image();
            comf_Image.Show();
        }
    }
}
