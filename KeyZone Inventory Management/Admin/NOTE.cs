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

namespace KeyZone_Inventory_Management.Admin
{
    public partial class NOTE : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public NOTE()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE  NOTE  SET  note =@note where id=1", con);

                cmd.Parameters.AddWithValue("@note", textBox1.Text.Trim());




                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم إرسال التنبيه بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Note", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void NOTE_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select note from note where id=1", con);
                SqlDataReader dr;
                con.Open();
                dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    textBox1.Text = dr["note"].ToString();
                }
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Note", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
