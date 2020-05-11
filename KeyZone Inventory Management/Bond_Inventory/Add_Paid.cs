using KeyZone_Inventory_Management.Grid;
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

namespace KeyZone_Inventory_Management.Bond_Inventory
{
    public partial class Add_Paid : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static Add_Paid add_Paid;
        public Add_Paid()
        {
            add_Paid = this;
            InitializeComponent();
        }

        private void textBox_Paid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Stores_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (textBox_Stores_No.Text == "")
            {
                MessageBox.Show("يرجى تعبئة رقم المستودع ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Stores_No.Focus();
                return;
            }
            if (textBox_Stores_Name.Text == "")
            {
                MessageBox.Show("يرجى تعبئة اسم المستودع ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Stores_No.Focus();
                return;
            }
            if (textBox_Paid.Text == "")
            {
                MessageBox.Show("يرجى تعبئة قيمة الدفعة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Paid.Focus();
                return;
            }
            Save_Doc();
            clear_Screen();
        }
        private void Save_Doc()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_ADD_Paid";

            cmd.Parameters.AddWithValue("@Date_Paid", dateTime_Date_Paid.Value);
            cmd.Parameters.AddWithValue("@Note_Paid1", textBox_Note.Text);
            cmd.Parameters.AddWithValue("@Store_No", textBox_Stores_No.Text);
            cmd.Parameters.AddWithValue("@Store_Name", textBox_Stores_Name.Text);
            cmd.Parameters.AddWithValue("@Cost_Paid", textBox_Paid.Text);
            cmd.Parameters.AddWithValue("@ID_User", 1);

            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("تم تسجيل الدفعة  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox_Stores_No_Leave(object sender, EventArgs e)
        {
            if (textBox_Stores_No.Text != "")
            {
                SqlCommand cmd = new SqlCommand("select SNo,SName  from Stores where SNo=@SNo", con);
                cmd.Parameters.Add(new SqlParameter("@SNo", textBox_Stores_No.Text));

                con.Open();
                SqlDataReader Ra = cmd.ExecuteReader();

                if (Ra.Read())
                {
                    textBox_Stores_Name.Text = Ra["SName"].ToString();

                }
                else
                {
                    MessageBox.Show("لا يوجد مستودع بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Stores_Name.Text = "";
                }
                Ra.Close();
                con.Close();
            }
        }

        private void btn_View_Bond_No_Click(object sender, EventArgs e)
        {
            Grid_Stores.SCR_Add_Paid = true;
            Grid_Stores ss = new Grid_Stores();
            ss.ShowDialog();
            Grid_Stores.SCR_Add_Paid = false;
        }
        private void clear_Screen()
        {
            textBox_Stores_No.Text = "";
            textBox_Stores_Name.Text = "";
            textBox_Note.Text = "";
            textBox_Paid.Text = "";
        }
    }
}
